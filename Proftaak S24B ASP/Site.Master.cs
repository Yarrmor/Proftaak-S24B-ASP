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

        protected void Page_Load(object sender, EventArgs e)
        {
            Locatie locatie = new Locatie(1, "Camping De Valkenhof", null, 0, null, null);
            Session["SelectedEvent"] = new Event(1, "ICT4EVENTS", new DateTime(2015, 7, 16, 0, 0, 0), new DateTime(2015, 7, 20, 0, 0, 0), locatie, 100);

            if (Session["IngelogdAccount"] != null)
            {
                btnLoginUit.Text = "Uitloggen";
                Account acc = (Account)Session["IngelogdAccount"];
                lblGebruikersnaam.Text = acc.Gebruikersnaam;
                lblGebruikersnaam.Visible = true;
                btnAccount.Visible = true;
                btnUpload.Visible = true;
                btnBeheer.Visible = false;
            }
            else
            {
                btnLoginUit.Text = "Inloggen";
                lblGebruikersnaam.Text = "";
                lblGebruikersnaam.Visible = false;
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

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Session["IngelogdAccount"] = "Beheerder";
            Response.Redirect("Default.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Contents.Remove("IngelogdAccount");
            Response.Redirect("Default.aspx");
        }

        protected void btnLoginUit_Click(object sender, EventArgs e)
        {
            if (Session["Account"] != null)
            {
                Session["Account"] = null;
                btnLoginUit.Text = "Inloggen";
                lblGebruikersnaam.Visible = false;
                btnAccount.Visible = false;
                btnUpload.Visible = false;
                btnBeheer.Visible = false;
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
    }
}