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
            if (Session["Account"] != null)
            {
                btnLoginUit.Text = "Uitloggen";
                Account acc = (Account)Session["Account"];
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
            tvwSubMenu = MS.VulSubMenu();
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