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
        protected void Page_Load(object sender, EventArgs e)
        {
            if((string)Session["IngelogdAccount"] == "Gebruiker")
            {
                btnAccount.Visible = true;
                btnUpload.Visible = true;

                VulLogin();
            }
            else if((string)Session["IngelogdAccount"] == "Beheerder")
            {
                btnAccount.Visible = true;
                btnUpload.Visible = true;
                btnBeheer.Visible = true;

                VulLogin();
            }
        }

        public void VulLogin()
        {
            tbxGebruikersnaam.Visible = false;
            tbxWachtwoord.Visible = false;
            btnLogin.Visible = false;
            lblIngelogdGebruikersnaam.Visible = true;
            lblIngelogdGebruikersnaam.Text = (string)Session["IngelogdAccount"];
            lblWachtwoord.Visible = false;
            btnLogout.Visible = true;
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
    }
}