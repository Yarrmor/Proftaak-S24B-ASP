using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proftaak_S24B_ASP
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnNieuwEvent_Click(object sender, EventArgs e)
        {
            if (tbxEindDatum.Text != "" && tbxEventNaam.Text != "" && tbxHuisNummer.Text != "" && tbxLocatieNaam.Text != "" && tbxMaxBezoekers.Text != "" && tbxPostcode.Text != "" && tbxStartDatum.Text != "" && tbxStraat.Text != "" && tbxWoonplaats.Text != "")
            {
                Locatie lo = new Locatie(tbxLocatieNaam.Text, tbxStraat.Text, tbxHuisNummer.Text, tbxPostcode.Text, tbxWoonplaats.Text);
                if (lo.VoegToe())
                {
                    Event ev = new Event(tbxEventNaam.Text, Convert.ToDateTime(tbxStartDatum.Text), Convert.ToDateTime(tbxEindDatum.Text), lo, Convert.ToInt32(tbxMaxBezoekers.Text));

                    if (ev.VoegToe())
                    {
                        Response.Redirect("EventBeheer.aspx");
                    }
                    else
                    {
                        lblEventError.Text = "Het is niet gelukt om het event toe te voegen!";
                    }
                }
                else
                {
                    lblEventError.Text = "De locatie voor het event kon niet worden toegevoegd aan de database, hierdoor is het event ook niet toegevoegd.";
                }
            }
        }
    }
}