using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proftaak_S24B_ASP
{
    public partial class PlaatsReserveringPagina : System.Web.UI.Page
    {
        static int maximumAantalPersonen = 8;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SelectedEvent"] == null)
                Response.Redirect("Default.aspx");

            // Als combobox aantal personen leeg is, wordt deze gevuld. maximumAantalPersonen is in dit geval hardcoded
            if (cbxAantalPersonen.Items.Count == 0)
            {
                for (int i = 1; i <= maximumAantalPersonen; i++)
                {
                    cbxAantalPersonen.Items.Add(i.ToString());
                }
            }

            // Als comboboxen datums leeg zijn, worden deze gevuld. Datums komen uit event
            if (cbxDatumVan.Items.Count == 0 && Session["SelectedEvent"] != null)
            {
                List<DateTime> datums = PlaatsReserveringsSysteem.VerkrijgDatums((Session["SelectedEvent"] as Event).ID);

                foreach (DateTime datum in datums)
                {
                    cbxDatumTot.Items.Add(datum.ToShortDateString());
                    cbxDatumVan.Items.Add(datum.ToShortDateString());
                }
            }

            // vult filters in als dit nog niet gedaan is
            if (clbPlaatsFilters.Items.Count == 0)
            {
                List<string> filters = PlaatsReserveringsSysteem.VerkrijgPlekFilters();

                foreach (string filter in filters)
                {
                    clbPlaatsFilters.Items.Add(filter);
                }
            }

            if (Session["Plekken"] == null)
            {
                Event evenement = Session["SelectedEvent"] as Event;

                List<Plek> plekken = PlaatsReserveringsSysteem.VerkrijgPlekken(evenement.ID, evenement.Locatie);

                Session["Plekken"] = plekken;

                VerversPlaatsen();
            }
        }
        
        /// <summary>
        /// Gebaseerd op het aantal geselecteerde personen, worden email velden (on)zichtbaar gemaakt.
        /// Niet live toegevoegd of verwijderd om data te behouden die erin stonden, en om validatie makkelijker te implementeren.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbxAantalPersonen_SelectedIndexChanged(object sender, EventArgs e)
        {
            int aantal = AantalPersonen();

            if (aantal != -1)
            {
                VerversPlaatsen();

                // tblGroepsgegevens.Rows[i].Visible deed geen juiste postback
                List<TableRow> tbrs = new List<TableRow> { tbrEmail2, tbrEmail3, tbrEmail4, tbrEmail5, tbrEmail6, tbrEmail7, tbrEmail8 };

                for (int i = 0; i < 7; i++)
                {
                    tbrs[i].Visible = (i + 2 <= aantal);
                }
            }
        }

        /// <summary>
        /// Haalt het aantal personen geselecteerd voor het event op door te kijken naar de waarde van de dropdown lijst
        /// </summary>
        /// <returns></returns>
        private int AantalPersonen()
        {
            int i;

            if (int.TryParse(cbxAantalPersonen.SelectedValue.ToString(), out i))
                return i;
            else
                return -1;
        }

        protected void cbxDatumVan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDatumVan.SelectedIndex == -1)
                cbxDatumTot.SelectedIndex = -1;
            else
            {
                // Reset eind datum waarden
                cbxDatumTot.Items.Clear();

                foreach (var item in cbxDatumVan.Items)
                    cbxDatumTot.Items.Add(item.ToString());

                // Haal alle datums weg vóór geselecteerde begindatum
                for (int i = 0; i < cbxDatumVan.SelectedIndex; i++)
                    cbxDatumTot.Items.RemoveAt(0);
            }

            BerekenPrijs();
        }

        protected void clbPlaatsFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerversPlaatsen();
            BerekenPrijs();
        }

        private void VerversPlaatsen()
        {
            List<Plek> plekken = Session["Plekken"] as List<Plek>;

            if (plekken == null)
                Response.Redirect(Request.RawUrl);

            cbxPlaatsnummer.Items.Clear();

            // Alle plekken
            foreach (Plek plek in plekken)
            {
                bool match = true;

                // Alle filters
                foreach (ListItem item in clbPlaatsFilters.Items)
                {
                    // Als filter geselecteerd is moet deze voorkomen in de List<string> plek.Filters.
                    // Zo niet, moet deze niet toegevoegd worden aan de lijst van plekken.
                    if (item.Selected)
                    {
                        if (plek.Filters == null)
                            match = false;
                        else if (!plek.Filters.Contains(item.Value.ToString()))
                            match = false;
                    }

                    
                }

                // Check capaciteit
                if (plek.Capaciteit < Convert.ToInt32(cbxAantalPersonen.SelectedItem.ToString()))
                    match = false;

                if (match)
                    cbxPlaatsnummer.Items.Add(plek.Nummer.ToString());
            }

            BerekenPrijs();
        }

        protected void cbxPlaatsnummer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxPlaatsnummer.SelectedIndex == -1)
            {
                tbcTotaalprijs.Text = "";
                tbcTotaalprijs.Text = "";
            }
            else
            {
                BerekenPrijs();
            }
            
        }

        private void BerekenPrijs()
        {
            // Dagprijs
            if (cbxPlaatsnummer.SelectedIndex != -1)
            {
                List<Plek> plekken = Session["Plekken"] as List<Plek>;

                foreach (Plek plek in plekken)
                {
                    if (plek.Nummer == Convert.ToInt32(cbxPlaatsnummer.SelectedValue.ToString()))
                    {
                        CultureInfo ci = new CultureInfo("nl-NL");

                        tbcDagprijs.Text = plek.DagPrijs.ToString("c", ci);

                        break;
                    }
                }
            }
            else
            {
                tbcDagprijs.Text = "";
            }

            // Totaalprijs
            if (cbxDatumVan.SelectedIndex == -1 || cbxDatumTot.SelectedIndex == -1 || cbxPlaatsnummer.SelectedIndex == -1)
                tbcTotaalprijs.Text = "";
            else
            {
                int dagen = cbxDatumTot.SelectedIndex + 1;

                List<Plek> plekken = Session["Plekken"] as List<Plek>;

                foreach (Plek plek in plekken)
                {
                    if (plek.Nummer == Convert.ToInt32(cbxPlaatsnummer.SelectedValue.ToString()))
                    {
                        CultureInfo ci = new CultureInfo("nl-NL");

                        int prijs = plek.DagPrijs * dagen;

                        tbcTotaalprijs.Text = prijs.ToString("c", ci);

                        break;
                    }
                }
            }
        }
       
        protected void btnReserveren_Click(object sender, EventArgs e)
        {
            if (cbxDatumVan.SelectedIndex == -1 || cbxDatumTot.SelectedIndex == -1)
            {
                lblError.Text = "Ingevulde datums zijn onjuist!";
                lblError.Visible = true;
                return;
            }

            if (cbxPlaatsnummer.SelectedIndex == -1)
            {
                lblError.Text = "Geen plaats is geselecteerd!";
                lblError.Visible = true;
                return;
            }

            if (cbxAantalPersonen.SelectedIndex == -1)
            {
                lblError.Text = "Aantal personen is onjuist!";
                lblError.Visible = true;
                return;
            }

            lblError.Visible = false;

            int aantalPersonen = Convert.ToInt32(cbxAantalPersonen.SelectedValue.ToString());
            List<TextBox> tbxEmails = new List<TextBox> { tbxEmail2, tbxEmail3, tbxEmail4, tbxEmail5, tbxEmail6, tbxEmail7, tbxEmail8 };

            // Check of meerdere keren zelfde email is ingevuld en anders of het email ongeldig is
            List<string> emails = new List<string>();
            emails.Add(tbxEmailAdres.Text.ToUpper());

            for (int i = 0; i < aantalPersonen - 1; i++)
            {
                string email = tbxEmails[i].Text;
                if (!IsValidEmail(email) || emails.Contains(email.ToUpper()))
                {
                    lblError.Text = "Een email voor een lid is onjuist!";
                    lblError.Visible = true;
                    return;
                }
                else
                {
                    emails.Add(email);
                }
            }

            List<Plek> plekken  = Session["Plekken"] as List<Plek>;

             foreach (Plek plek in plekken)
            {
                if (plek.Nummer == Convert.ToInt32(cbxPlaatsnummer.SelectedValue.ToString()))
                {
                    PlaatsReserveringsSysteem.ReserveerPlek(plek, Session["SelectedEvent"] as Event, cbxDatumVan.SelectedIndex, cbxDatumTot.SelectedIndex, tbxVoornaam.Text, tbxTussenvoegsel.Text, tbxAchternaam.Text,
                                                            Convert.ToInt32(tbxTelefoonnummer.Text), tbxWoonplaats.Text, tbxStraatnaam.Text, tbxHuisnummer.Text, tbxEmailAdres.Text, tbxBankrekeningnummer.Text,
                                                            aantalPersonen, tbxEmail2.Text, tbxEmail3.Text, tbxEmail4.Text, tbxEmail5.Text, tbxEmail6.Text, tbxEmail7.Text, tbxEmail8.Text);
                    break;
                }
            }

            
        }

        /// <summary>
        /// http://stackoverflow.com/questions/1365407/c-sharp-code-to-validate-email-address
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        protected void cbxDatumTot_SelectedIndexChanged(object sender, EventArgs e)
        {
            BerekenPrijs();
        }

    }
}