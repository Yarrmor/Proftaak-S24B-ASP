using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proftaak_S24B_ASP
{
    public partial class PlaatsReserveringPagina : System.Web.UI.Page
    {
        static int maximumAantalPersonen = 8;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (cbxAantalPersonen.Items.Count == 0)
            {
                for (int i = 1; i <= maximumAantalPersonen; i++)
                {
                    cbxAantalPersonen.Items.Add(i.ToString());
                }
            }
        }
        
        /// <summary>
        /// Gebaseerd op het aantal geselecteerde personen, worden email velden toegevoegd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbxAantalPersonen_SelectedIndexChanged(object sender, EventArgs e)
        {
            int aantal = AantalPersonen();

            if (aantal != -1)
            {
                // tblGroepsgegevens.Rows[i].Visible deed geen juiste postback
                List<TableRow> tbrs = new List<TableRow> { tbrEmail2, tbrEmail3, tbrEmail4, tbrEmail5, tbrEmail6, tbrEmail7, tbrEmail8 };

                for (int i = 0; i < 7; i++)
                {
                    tbrs[i].Visible = (i + 2 <= aantal);
                }
            }
        }

        /// <summary>
        /// Haalt het aantal personen geselecteerd voor het event op door te kijken naar de waarde van de dropdown lijst
        /// </summary>
        /// <returns></returns>
        private int AantalPersonen()
        {
            int i;

            if (int.TryParse(cbxAantalPersonen.SelectedValue.ToString(), out i))
                return i;
            else
                return -1;
        }

        protected void btnReserveren_Click(object sender, EventArgs e)
        {

        }
    }
}