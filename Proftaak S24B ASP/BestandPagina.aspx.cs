using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proftaak_S24B_ASP
{
    public partial class BestandPagina : System.Web.UI.Page
    {
        private MediaSysteem MS;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Bestand)Session["SelectedBestand"] == null)
            {
                Response.Redirect("MediaPagina.aspx");
            }

            MS.Bestand = (Bestand)Session["SelectedBestand"];

            VulBestandInfo();

            VulBerichten();
        }

        public void VulBestandInfo()
        {
            lblNaam.Text = MS.Bestand.Naam;
            if (MS.Bestand.BestandsLocatie.Contains(".jpg") || MS.Bestand.BestandsLocatie.Contains(".png"))
            {
                imgBestand.Visible = true;
                imgBestand.ImageUrl = MS.Bestand.BestandsLocatie;
                imgBestand.Width = 400;
            }
            else if (MS.Bestand.BestandsLocatie.Contains(".txt"))
            {
                lblText.Visible = true;
                lblText.Text = "TODO: FileStream";
                //FILESTREAM
            }
        }

        public void VulBerichten()
        {
            MS.Bestand.VerkrijgBerichten();
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            MS.Bestand.Download();
        }

        protected void lvwBerichten_SelectedIndexChanged(object sender, EventArgs e)
        {
            MS.Bericht = MS.Berichten[lvwBerichten.SelectedIndex];
            tbxTitel.Text = "RE: " + MS.Bericht.Titel;
        }

        protected void btnBericht_Click(object sender, EventArgs e)
        {
            if(tbxBericht.Text.Length >= 10 && tbxTitel.Text != "")
            {
                if (MS.Bericht != null)
                {
                    if(!MS.PlaatsBericht(MS.Bericht, tbxTitel.Text, tbxBericht.Text))
                    {

                    }
                }
                else
                {
                    if(!MS.PlaatsBericht(tbxTitel.Text, tbxBericht.Text))
                    {

                    }
                }
            }
        }
    }
}