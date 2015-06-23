using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proftaak_S24B_ASP
{
    public partial class Site : System.Web.UI.MasterPage
    {
        private MediaSysteem MS;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Locatie locatie = new Locatie(1, "Camping De Valkenhof", null, null, null, null);
            Event evenement = new Event(1, "ICT4EVENTS", new DateTime(2015, 7, 16, 0, 0, 0), new DateTime(2015, 7, 20, 0, 0, 0), locatie, 100);
            Session["SelectedEvent"] = evenement;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Event evenement = Session["SelectedEvent"] as Event;

            // Haal alle evenementen op en stop deze in ddl
            if (ddlEvenement.Items.Count == 0)
            {
                ddlEvenement.Items.Add(evenement.Naam);
                ddlEvenement.SelectedIndex = 1;
            }

            if (Session["IngelogdAccount"] != null)
            {
                btnLoginUit.Text = "Uitloggen";
                Account acc = (Account)Session["IngelogdAccount"];
                lblGebruikersnaam.Text = acc.Gebruikersnaam;
                lblGebruikersnaam.Visible = true;
                lblIngelogdAls.Visible = true;
                btnHuur.Visible = true;
                btnAccount.Visible = true;
                btnUpload.Visible = true;
                btnBeheer.Visible = false;
            }
            else
            {
                btnLoginUit.Text = "Inloggen";
                lblGebruikersnaam.Text = "";
                lblGebruikersnaam.Visible = false;
                lblIngelogdAls.Visible = false;
                btnHuur.Visible = false;
                btnAccount.Visible = false;
                btnUpload.Visible = false;
                btnBeheer.Visible = false;
            }

            MS = new MediaSysteem();

            VulSubMenu();
        }

        public void VulSubMenu()
        {
            if(tvwSubMenu.Nodes.Count == 0)
            {
                TreeNodeCollection tnc = MS.VulSubMenu();

                foreach(TreeNode tn in tnc)
                {
                    tvwSubMenu.Nodes.Add(tn);
                }
            }
            
        }

        protected void btnLoginUit_Click(object sender, EventArgs e)
        {
            if (Session["IngelogdAccount"] != null)
            {
                Session["IngelogdAccount"] = null;
                Response.Redirect("Default.aspx");
            }
            else
            {
                Response.Redirect("InlogPagina.aspx");
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void tvwSubMenu_SelectedNodeChanged(object sender, EventArgs e)
        {
            Session["SelectedCategorie"] = MS.VerkrijgCategorie(tvwSubMenu.SelectedNode.Text);
        }

        protected void btnAccount_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException("Pagina bestaat niet");

            Response.Redirect("AccountPagina.aspx");
        }

        protected void btnReserveer_Click(object sender, EventArgs e)
        {
            Response.Redirect("PlaatsReserveringPagina.aspx");
        }

        protected void btnHuur_Click(object sender, EventArgs e)
        {
            Response.Redirect("MateriaalReserveringPagina.aspx");
        }
    }
}