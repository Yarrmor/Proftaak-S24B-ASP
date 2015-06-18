using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proftaak_S24B_ASP
{
    public partial class InlogPagina : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lblInlogMislukt.Visible = false;
            InlogSysteem inlog = new InlogSysteem();
            Account acc = inlog.Login(tbEmail.Text, tbWachtwoord.Text);
            if (acc != null)
            {
                Session["Account"] = acc;
                Response.Redirect("Default.aspx");
            }
            else
            {
                lblInlogMislukt.Visible = true;
            }
        }
    }
}