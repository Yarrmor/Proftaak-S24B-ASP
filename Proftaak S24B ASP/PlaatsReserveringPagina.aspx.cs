using System;
using System.Collections.Generic;
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
        }

        protected void clbPlaatsFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clbPlaatsFilters.SelectedIndex != -1)
            {

            }
        }

        private void VerversPlaatsen()
        {
            List<Plek> plekken = Session["Plekken"] as List<Plek>;

            if (plekken == null)
                Response.Redirect(Request.RawUrl);

            cbxPlaatsnummer.Items.Clear();

            List<Plek> gefilterdePlekken = new List<Plek>();

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

                    if (match)
                        cbxPlaatsnummer.Items.Add(plek.ID.ToString());
                }
            }
        }

        protected void cbxPlaatsnummer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
        protected void btnReserveren_Click(object sender, EventArgs e)
        {

        }

    }
}