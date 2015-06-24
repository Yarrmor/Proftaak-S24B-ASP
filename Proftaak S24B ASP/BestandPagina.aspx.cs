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
        private int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!int.TryParse(Request.QueryString["id"], out id))
            {
                Response.Redirect("MediaPagina.aspx");
            }

            MS = new MediaSysteem();

            MS.VerkrijgBestand(id);

            if(MS.Bestand == null)
            {
                Response.Redirect("Default.aspx");
            }

            VulBestandInfo();

            VulBerichten();

            Account acc = (Account)Session["IngelogdAccount"];
            if (acc != null)
            {
                if (MS.Bestand.Account.ID == acc.ID)
                {
                    btnVerwijder.Visible = true;
                }
                else
                {
                    btnVerwijder.Visible = false;
                }
            }
            else
            {
                btnVerwijder.Visible = false;
            }

            if(Session["ErrorMessage"] != null)
            {
                lblErrorMessage.Text = (string)Session["ErrorMessage"];
            }
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
            lvwBerichten.DataSource = MS.Bestand.VerkrijgBerichten();
            lvwBerichten.DataBind();
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            MS.Bestand.Download();
        }

        protected void btnBericht_Click(object sender, EventArgs e)
        {
            if(tbxBericht.Text.Length >= 10 && tbxTitel.Text != "")
            {
                if (MS.Bericht != null)
                {
                    if(!MS.PlaatsBericht(MS.Bericht, tbxTitel.Text, tbxBericht.Text))
                    {
                        Session["ErrorMessage"] = "Het plaatsen van het bericht is mislukt. Probeer later nog eens.";
                    }
                    else
                    {
                        Session.Remove("ErrorMessage");
                    }
                }
                else
                {
                    if(!MS.PlaatsBericht(tbxTitel.Text, tbxBericht.Text))
                    {
                        Session["ErrorMessage"] = "Het plaatsen van het bericht is mislukt. Probeer later nog eens.";
                    }
                    else
                    {
                        Session.Remove("ErrorMessage");
                    }
                }
            }
            else
            {
                Session["ErrorMessage"] = "De titel van het bericht kan niet leeg zijn en de inhoud moet minstens 10 tekens lang zijn.";
            }
            Response.Redirect("Bestand.aspx?id=" + id.ToString());
        }

        protected void btnVerwijder_Click(object sender, EventArgs e)
        {
            Account acc = (Account)Session["IngelogdAccount"];
            if(MS.Bestand.Account.ID == acc.ID)
            {
                MS.Bestand.Verwijder();
            }
        }
    }
}