using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proftaak_S24B_ASP
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        private BeheerSysteem bs;
        private List<ProductCategorie> productCats;

        protected void Page_Load(object sender, EventArgs e)
        {
            bs = new BeheerSysteem();
            if (Session["SelectedEvent"] != null)
            {
                productCats = bs.VerkrijgProductCategorieen();
                VulDropDownListCategorieen(productCats);
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnVoegProductToe_Click(object sender, EventArgs e)
        {

            
        }

        protected void btnVoegPlekToe_Click(object sender, EventArgs e)
        {
            if (tbxLocatieNaam.Text != "" && tbxLocatieStraat.Text != "" && tbxLocatieNR.Text != "" && tbxLocatiePostcode.Text != "" && tbxLocatiePlaats.Text != "" && tbxPlekPrijs.Text != "" && tbxPlekNummer.Text != "" && tbxCapaciteit.Text != "")
            {
                Locatie lo = new Locatie(tbxLocatieNaam.Text, tbxLocatieStraat.Text, tbxLocatieNR.Text, tbxLocatiePostcode.Text, tbxLocatiePlaats.Text);
                if (lo.VoegToe())
                {
                    Plek pl = new Plek(Convert.ToInt32(tbxPlekNummer.Text), Convert.ToInt32(tbxCapaciteit.Text), Convert.ToInt32(tbxPlekPrijs.Text), lo);

                    if (pl.VoegToe())
                    {
                        lblPlekError.Text = "Plek is toegevoegd!";
                    }
                    else
                    {
                        lblPlekError.Text = "Plek toevoegen is mislukt!";
                    }
                }
                else
                {
                    lblPlekError.Text = "Locatie toevoegen is mislukt!";
                }
            }
        }

        private void VulDropDownListCategorieen(List<ProductCategorie> productCategorieen)
        {
            //todo categorieen die een subcategorie hebben ook aan een ddl toevoegen. (andere)
            foreach (ProductCategorie p in productCategorieen)
            {
                ddlProductCategorieen.Items.Add(p.Naam);
            }
        }
    }
}