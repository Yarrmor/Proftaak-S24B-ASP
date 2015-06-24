using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proftaak_S24B_ASP
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        private BeheerSysteem bs;
        private List<Plek> plekken;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SelectedEvent"] != null)
            {
                bs = new BeheerSysteem();
                if (Session["ProductenWV"] == null && Session["ProductenWV"] == null && !IsPostBack)
                {
                    plekken = bs.VerkrijgPlekken();
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
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}