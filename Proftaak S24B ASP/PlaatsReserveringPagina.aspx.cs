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
            int aantal;

            if (int.TryParse(cbxAantalPersonen.SelectedValue.ToString(), out aantal))
            {
                lblEmailsLeden.Visible = (aantal != 1);

                int rijen = tblGroepsgegevens.Rows.Count;

                if (rijen > aantal - 1)
                {
                    tblGroepsgegevens.Rows.RemoveAt(aantal);
                }
                else if (rijen < aantal - 1)
                {
                    for (int i = 0; i < aantal - rijen - 1; i++)
                    {
                        TableRow row = new TableRow();

                        TableCell cellLabel = new TableCell();
                        cellLabel.Wrap = false;
                        cellLabel.Text = "Email lid:";
                        row.Cells.Add(cellLabel);

                        TableCell cellTextbox = new TableCell();
                        cellTextbox.Controls.Add(new TextBox());
                        row.Cells.Add(cellTextbox);

                        tblGroepsgegevens.Rows.Add(row);
                    }
                }

            }
        }

        protected void btnReserveren_Click(object sender, EventArgs e)
        {

        }
    }
}