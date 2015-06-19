using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proftaak_S24B_ASP
{
    public partial class MediaPagina : System.Web.UI.Page
    {
        private MediaSysteem MS;

        protected void Page_Load(object sender, EventArgs e)
        {
            if((Categorie)Session["SelectedCategorie"] != null)
            {
                Categorie cat = (Categorie)Session["SelectedCategorie"];
                lvwMedia.DataSource = MS.VerkrijgBestanden(cat);
                lvwMedia.DataBind();
            }
            else
            {
                lvwMedia.DataSource = MS.VerkrijgBestanden();
                lvwMedia.DataBind();
            }
        }

        protected void lvwMedia_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["SelectedBestand"] = MS.Bestanden[lvwMedia.SelectedIndex];
            Response.Redirect("Bestand.aspx");
        }
    }
}