using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proftaak_S24B_ASP
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        private List<Product> producten;
        private List<ProductCategorie> prodCats;
        private BeheerSysteem bs;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SelectedEvent"] != null)
            {
                bs = new BeheerSysteem();
                if (Session["ProductenWV"] == null && Session["ProductenWV"] == null && !IsPostBack)
                {
                    producten = bs.VerkrijgProducten();
                    prodCats = bs.VerkrijgProductCategorieen();
                    if (producten != null && producten.Count != 0)
                    {
                        Session["ProductenWV"] = producten;
                        Session["ProductVWCats"] = prodCats;
                        VulLbxProductWV();
                        VulDropDownListCategorieen(prodCats);
                    }
                    else
                    {
                        Response.Write("Er kon geen product worden gevonden!");
                    }
                }
                else
                {
                    producten = (List<Product>)Session["ProductenWV"];
                    prodCats = (List<ProductCategorie>)Session["ProductVWCats"];
                    if (producten == null && producten.Count == 0)
                    {
                        Response.Write("Er kon geen product worden gevonden!");
                    }
                    else if (lbxProductWV.Items.Count == 0 && ddlWijzigProductCategorie.Items.Count == 0)
                    {
                        VulLbxProductWV();
                        VulDropDownListCategorieen(prodCats);
                    }
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void lbxProductWV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxProductWV.SelectedItem != null)
            {
                Product selected = VerkrijgProduct(lbxProductWV.SelectedItem.ToString());
                if (selected != null)
                {
                    lblProductWVID.Text = selected.ID.ToString();
                    tbxWijzigProductMerk.Text = selected.Merk;
                    tbxWijzigProductSerie.Text = selected.Serie;
                    tbxWijzigProductTypenummer.Text = selected.Typenummer.ToString();
                    tbxWijzigProductPrijs.Text = selected.Prijs.ToString();

                    int index = VerkrijgIndex(selected.ProductCategorie);
                    if (index != -1)
                    {
                        ddlWijzigProductCategorie.SelectedIndex = index;
                    }

                }
                else
                {
                    lblProductWVID.Text = "Error";
                }
            }
        }

        private int VerkrijgIndex(ProductCategorie prodCat)
        {
            foreach (ListItem l in ddlWijzigProductCategorie.Items)
            {
                if (l.ToString() == prodCat.Naam)
                {
                    return ddlWijzigProductCategorie.Items.IndexOf(l);
                }
                else if (prodCat.HoofdCategorie != null)
                {
                    if (l.ToString() == (prodCat.HoofdCategorie.Naam + " " + prodCat.Naam))
                    {
                        return ddlWijzigProductCategorie.Items.IndexOf(l);
                    }
                }
            }
            return -1;
        }

        private ProductCategorie VerkrijgProductCategorie(int id)
        {
            foreach (ProductCategorie p in prodCats)
            {
                if (p.ID == id)
                {
                    return p;
                }
            }
            return null;
        }

        private void VulLbxProductWV()
        {
            lbxProductWV.DataSource = producten;
            lbxProductWV.DataBind();
        }

        private Product VerkrijgProduct(string productString)
        {
            foreach (Product p in producten)
            {
                if (p.ToString() == productString)
                {
                    return p;
                }
            }
            return null;
        }

        private Product VerkrijgProductLabel()
        {
            foreach (Product p in producten)
            {
                if (p.ID == Convert.ToInt32(lblProductWVID.Text))
                {
                    return p;
                }
            }
            return null;
        }

        private void VulDropDownListCategorieen(List<ProductCategorie> productCategorieen)
        {
            //todo categorieen die een subcategorie hebben ook aan een ddl toevoegen. (andere)
            foreach (ProductCategorie p in productCategorieen)
            {
                if (p.HoofdCategorie != null)
                {
                    ddlWijzigProductCategorie.Items.Add((p.HoofdCategorie.Naam + " " + p.Naam));
                }
                else
                {
                    ddlWijzigProductCategorie.Items.Add(p.Naam);
                }
            }
        }

        private ProductCategorie VerkrijgProductCategorie(string naam)
        {
            foreach (ProductCategorie p in prodCats)
            {
                if (p.Naam == naam)
                {
                    return p;
                }
                else if (p.HoofdCategorie != null)
                {
                    if ((p.HoofdCategorie.Naam + " " + p.Naam) == naam)
                    {
                        return p;
                    }
                }
            }
            return null;
        }

        protected void btnWijzigProduct_Click(object sender, EventArgs e)
        {
            Product p = VerkrijgProductLabel();
            if (p != null)
            {
                p = new Product(p.ID, VerkrijgProductCategorie(ddlWijzigProductCategorie.SelectedItem.ToString()), tbxWijzigProductMerk.Text, tbxWijzigProductSerie.Text, Convert.ToInt32(tbxWijzigProductTypenummer.Text), Convert.ToInt32(tbxWijzigProductPrijs.Text));
                if (p.Wijzig())
                {
                    lblWijzigError.Text = "Wijziging is gelukt!";
                    producten = bs.VerkrijgProducten();
                    Session["ProductenWV"] = producten;
                    Response.Redirect("EventBeheerProductWijzigVerwijder.aspx");
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

        protected void btnVerwijderProduct_Click(object sender, EventArgs e)
        {
            Product p = VerkrijgProductLabel();
            if (p != null)
            {
                p = new Product(p.ID, VerkrijgProductCategorie(ddlWijzigProductCategorie.SelectedItem.ToString()), tbxWijzigProductMerk.Text, tbxWijzigProductSerie.Text, Convert.ToInt32(tbxWijzigProductTypenummer.Text), Convert.ToInt32(tbxWijzigProductPrijs.Text));
                if (p.Verwijder())
                {
                    lblVerwijderError.Text = "Verwijdering is voltooid!";
                    producten = bs.VerkrijgProducten();
                    Session["ProductenWV"] = producten;
                    Response.Redirect("EventBeheerProductWijzigVerwijder.aspx");
                }
                else
                {
                    lblVerwijderError.Text = "Verwijdering is mislukt!";
                }
            }
            else
            {
                lblVerwijderError.Text = "ID kon niet worden gevonden!";
            }
        }
    }
}