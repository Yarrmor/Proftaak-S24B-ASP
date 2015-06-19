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
                TreeNodeCollection nodes = verhuurSysteem.VerkrijgProductCategorieen();

                foreach (TreeNode node in nodes)
                {
                    tvwCategorieen.Nodes.Add(node);
                }
            }

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

        protected void lbxMateriaal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxMateriaal.SelectedIndex != -1 && Session["Producten"] != null)
            {
                List<Product> producten = Session["Producten"] as List<Product>;

                Product p = producten[lbxMateriaal.SelectedIndex];

                if (p != null)
                {
                    lblMateriaalNaam.Text = p.ToString();
                    lblMateriaalPrijs.Text = p.Prijs.ToString("C");
                }
            }
        }

        protected void btnReserveer_Click(object sender, EventArgs e)
        {
            // Plaats reservering
        }

        protected void tvwCategorieen_SelectedNodeChanged(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvwCategorieen.SelectedNode;
            
            
            if (selectedNode != null)
            {
                lbxMateriaal.Items.Clear();

                List<Product> producten = verhuurSysteem.VerkrijgProducten(verhuurSysteem.VerkrijgProductCategorie(selectedNode.Text));

                foreach (Product p in producten)
                {
                    lbxMateriaal.Items.Add(p.ToString());
                }
            }
        }
    }
}