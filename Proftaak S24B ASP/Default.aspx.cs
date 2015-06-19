using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proftaak_S24B_ASP
{
    public partial class Default : System.Web.UI.Page
    {

        protected void ddlTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("Inloggen.aspx");
        }
    }
}