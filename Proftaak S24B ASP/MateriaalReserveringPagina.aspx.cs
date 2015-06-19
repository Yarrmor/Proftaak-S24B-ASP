using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proftaak_S24B_ASP
{
    public partial class MateriaalPagina : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SelectedEvent"] != null)
            {
                if (cbxMateriaalDatumTot.Items.Count == 0)
                {
                    DatabaseManager dm = new DatabaseManager();

                    Event evenement = Session["SelectedEvent"] as Event;

                    List<DateTime> datums = dm.VerkrijgDatums(evenement.ID);

                    foreach (DateTime datum in datums)
                    {
                        cbxMateriaalDatumTot.Items.Add(datum.ToShortDateString());
                        cbxMateriaalDatumVan.Items.Add(datum.ToShortDateString());
                    }
                }
            }

            // Laad materiaal
         // Laad materiaal
         // Laad datums
        }

        protected void lbxMateriaal_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Laad details
        }

        protected void btnReserveer_Click(object sender, EventArgs e)
        {
            // Plaats reservering
        }
    }
}