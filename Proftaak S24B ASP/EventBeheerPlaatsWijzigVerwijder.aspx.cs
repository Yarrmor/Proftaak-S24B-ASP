using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proftaak_S24B_ASP
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        private BeheerSysteem bs;
        private Event evt;
        private List<Plek> plekken;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SelectedEvent"] != null)
            {
                bs = new BeheerSysteem();
                evt = (Event)Session["SelectedEvent"];
                if (Session["PlekkenWV"] == null && Session["PlekkenWV"] == null && !IsPostBack)
                {
                    plekken = bs.VerkrijgPlekken(); //Todo: later misschien ook nog een eventID aan plek toevoegen aangezien die nu alle plaatsen ophaalt.
                    if (plekken != null && plekken.Count != 0)
                    {
                        Session["PlekkenWV"] = plekken;
                        VulLbxPlekkenWV();
                        if (cblFilters.Items.Count == 0)
                        {
                            List<string> filters = bs.VerkrijgFilters();
                            foreach (string s in filters)
                            {
                                cblFilters.Items.Add(s);
                            }
                        }
                    }
                    else
                    {
                        Response.Write("Er kon geen product worden gevonden!");
                    }
                }
                else
                {
                    plekken = (List<Plek>)Session["PlekkenWV"];
                    if (plekken == null && plekken.Count == 0)
                    {
                        Response.Write("Er kon geen product worden gevonden!");
                    }
                    else if (lbxVerwijderWijzigPlek.Items.Count == 0)
                    {
                        VulLbxPlekkenWV();
                    }
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        private void VulLbxPlekkenWV()
        {
            lbxVerwijderWijzigPlek.DataSource = plekken;
            lbxVerwijderWijzigPlek.DataBind();
        }

        protected void lbxVerwijderWijzigPlek_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxVerwijderWijzigPlek.SelectedItem != null)
            {
                Plek plek = VerkrijgPlek(lbxVerwijderWijzigPlek.SelectedItem.ToString());
                if (plek != null)
                {
                    lblPlekID.Text = plek.ID.ToString();

                    tbxWijzigPlekCapaciteit.Text = plek.Capaciteit.ToString();
                    tbxWijzigPlekNummer.Text = plek.Nummer.ToString();
                    tbxWijzigPlekPrijs.Text = plek.DagPrijs.ToString();
                    tbxWijzigPlekLocatieNaam.Text = plek.Locatie.Naam;
                    tbxWijzigPlekLocatieNR.Text = plek.Locatie.HuisNR;
                    tbxWijzigPlekLocatiePlaats.Text = plek.Locatie.Plaats;
                    tbxWijzigPlekLocatiePostcode.Text = plek.Locatie.Postcode;
                    tbxWijzigPlekLocatieStraat.Text = plek.Locatie.Straat;

                    foreach (string filter in plek.Filters)
                    {
                        foreach (ListItem l in cblFilters.Items)
                        {
                            if (l.Value.ToString() == filter)
                            {
                                l.Selected = true;
                            }
                        }
                    }
                }
                else
                {
                    lblPlekID.Text = "Error";
                }
            }
        }

        private Plek VerkrijgPlek(string plekString)
        {
            foreach (Plek p in plekken)
            {
                if (p.ToString() == plekString)
                {
                    return p;
                }
            }
            return null;
        }

        private Plek VerkrijgPlekLabel()
        {
            foreach (Plek p in plekken)
            {
                if (p.ID == Convert.ToInt32(lblPlekID.Text))
                {
                    return p;
                }
            }
            return null;
        }

        protected void btnWijzigPlek_Click(object sender, EventArgs e)
        {
            Plek p = VerkrijgPlekLabel();
            if (p != null)
            {
                List<string> filters = new List<string>();
                foreach (ListItem item in cblFilters.Items)
                {
                    if (item.Selected)
                    {
                        filters.Add(item.Value.ToString());
                    }
                }

                p = new Plek(Convert.ToInt32(lblPlekID.Text) , Convert.ToInt32(tbxWijzigPlekNummer.Text), Convert.ToInt32(tbxWijzigPlekCapaciteit.Text), Convert.ToInt32(tbxWijzigPlekPrijs.Text), new Locatie(tbxWijzigPlekLocatieNaam.Text, tbxWijzigPlekLocatieStraat.Text, tbxWijzigPlekLocatieNR.Text, tbxWijzigPlekLocatiePostcode.Text, tbxWijzigPlekLocatiePlaats.Text), filters);
                if (p.Wijzig())
                {
                    lblWijzigError.Text = "Wijziging is gelukt!";
                    plekken = bs.VerkrijgPlekken();
                    Session["PlekkenWV"] = plekken;
                    Response.Redirect("EventBeheerPlaatsWijzigVerwijder.aspx");
                }
                else
                {
                    lblWijzigError.Text = "Wijziging is mislukt!";
                }
            }
            else
            {
                lblWijzigError.Text = "ID kon niet worden gevonden!";
            }
        }

        protected void btnVerwijderPlek_Click(object sender, EventArgs e)
        {

        }
    }
}