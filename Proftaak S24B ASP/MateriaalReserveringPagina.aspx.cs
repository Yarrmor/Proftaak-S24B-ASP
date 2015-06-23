using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proftaak_S24B_ASP
{
    public partial class MateriaalPagina : System.Web.UI.Page
    {
        VerhuurSysteem verhuurSysteem;

        protected void Page_Load(object sender, EventArgs e)
        {
            verhuurSysteem = new VerhuurSysteem();

            // Laad datums
            if (Session["SelectedEvent"] != null)
            {
                if (cbxMateriaalDatumTot.Items.Count == 0)
                {
                    Event evenement = Session["SelectedEvent"] as Event;

                    List<DateTime> datums = verhuurSysteem.VerkrijgDatums(evenement);

                    foreach (DateTime datum in datums)
                    {
                        cbxMateriaalDatumTot.Items.Add(datum.ToShortDateString());
                        cbxMateriaalDatumVan.Items.Add(datum.ToShortDateString());
                    }
                }
            }

            // Laad categorieen
            if (tvwCategorieen.Nodes.Count == 0)
            {
                VerkrijgCategorieen();
            }

            VerkrijgMaterialen();
            
        }

        #region Categorieen

        protected void btnVerversCategorieen_Click(object sender, EventArgs e)
        {
            VerkrijgCategorieen();
        }

        private void VerkrijgCategorieen()
        {
            TreeNodeCollection nodes = verhuurSysteem.VerkrijgProductCategorieen();

            tvwCategorieen.Nodes.Clear();

            foreach (TreeNode node in nodes)
            {
                tvwCategorieen.Nodes.Add(node);
            }
        }

        /// <summary>
        /// Verandert de lijst van materialen voor de geselecteerde categorie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tvwCategorieen_SelectedNodeChanged(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvwCategorieen.SelectedNode;

            lbxMateriaal.Items.Clear();
            Session["Producten"] = null;
            Session["SelectedProduct"] = null;

            lblMateriaalNaam.Text = "Selecteer eerst een materiaal!";
            lblMateriaalPrijs.Text = "€0.00";

            if (selectedNode != null)
            {
                List<Product> producten = verhuurSysteem.VerkrijgProducten(verhuurSysteem.VerkrijgProductCategorie(selectedNode.Text));

                foreach (Product p in producten)
                {
                    lbxMateriaal.Items.Add(p.ToString());
                }
            }
        }

        #endregion

        #region Materiaal

        /// <summary>
        /// Haalt materialen op en stopt deze in de lb
        /// </summary>
        private void VerkrijgMaterialen()
        {
            // Laad materiaal
            if (Session["SelectedProductCategorie"] != null)
            {
                lbxMateriaal.Items.Clear();

                List<Product> producten = verhuurSysteem.VerkrijgProducten(Session["SelectedProductCategorie"] as ProductCategorie);

                foreach (Product p in producten)
                {
                    lbxMateriaal.Items.Add(p.ToString());
                }
            }
        }

        protected void btnVerversMaterialen_Click(object sender, EventArgs e)
        {
            VerkrijgMaterialen();
        }

        /// <summary>
        /// Vult de gegevens in van het geselecteerde product, en stopt dit product in de sessie (voor btnHuur Event)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbxMateriaal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxMateriaal.SelectedIndex != -1 && Session["Producten"] != null)
            {
                List<Product> producten = Session["Producten"] as List<Product>;

                Product p = producten[lbxMateriaal.SelectedIndex];

                Session["SelectedProduct"] = p;

                if (p != null)
                {
                    lblMateriaalNaam.Text = p.ToString();
                    lblMateriaalPrijs.Text = p.Prijs.ToString("C");
                }
            }
            else
            {
                Session["SelectedProduct"] = null;
            }
        }

        /// <summary>
        /// Gebaseerd op de begindatum wordt de einddatum aangepast.
        /// Einddatum <= begindatum
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbxMateriaalDatumVan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxMateriaalDatumVan.SelectedIndex == -1)
                cbxMateriaalDatumTot.SelectedIndex = -1;
            else
            {
                // Reset eind datum waarden
                cbxMateriaalDatumTot.Items.Clear();

                foreach (var item in cbxMateriaalDatumVan.Items)
                    cbxMateriaalDatumTot.Items.Add(item.ToString());

                // Haal alle datums weg vóór geselecteerde begindatum
                for (int i = 0; i < cbxMateriaalDatumVan.SelectedIndex; i++)
                    cbxMateriaalDatumTot.Items.RemoveAt(0);
            }
        }

        #endregion

        /// <summary>
        /// Probeert een exemplaar van het geselecteerde product te huren.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnHuur_Click(object sender, EventArgs e)
        {
            Account a = Session["IngelogdAccount"] as Account;

            if (a == null)
            {
                lblHuurError.Visible = true;
                lblHuurError.Text = "U moet ingelogd zijn om producten te huren!";
            }
            else if (Session["SelectedProduct"] != null)
            {
                Product p = Session["SelectedProduct"] as Product;

                p.Huur(Session["IngelogdAccount"] as Account, Session["SelectedEvent"] as Event, cbxMateriaalDatumVan.SelectedIndex, cbxMateriaalDatumTot.SelectedIndex);
            }
            else
            {
                lblHuurError.Visible = true;
                lblHuurError.Text = "U moet eerst een product selecteren!";
            }

        }


    }
}