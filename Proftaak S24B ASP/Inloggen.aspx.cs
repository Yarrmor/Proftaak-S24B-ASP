using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proftaak_S24B_ASP
{
    public partial class Inloggen : System.Web.UI.Page
    {
        private DatabaseManager dm;

        protected void Page_Load(object sender, EventArgs e)
        {
            //dm = new DatabaseManager();
            if(IsPostBack)
            {
                lblLoginError.Text = (string)Session["LoginError"];
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //if(dm.LogIn(tbxLogin.Text, tbxPassword.Text))
            //{
            //    Session["IngelogdAccount"] = dm.GetAccount(tbxLogin.Text);
            //    Session.Remove("LoginError");
            //    Response.Redirect("Default.aspx");
            //}
            //else
            //{
            //    Session["LoginError"] = "Inloggegevens zijn incorrect.";
            //}
        }
    }
}