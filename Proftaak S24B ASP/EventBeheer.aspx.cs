﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proftaak_S24B_ASP
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEventAanmaken_Click(object sender, EventArgs e)
        {
            Response.Redirect("EventBeheerNieuwEvent.aspx");
        }

        protected void btnPlaatsMateriaalToevoegen_Click(object sender, EventArgs e)
        {
            Response.Redirect("EventBeheerProductPlaatsToevoegen.aspx");
        }

        protected void btnMateriaalVerwijderenWijzigen_Click(object sender, EventArgs e)
        {
            Response.Redirect("EventBeheerProductWijzigVerwijder.aspx");
        }

        protected void btnPlaatsVerwijderenWijzigen_Click(object sender, EventArgs e)
        {
            Response.Redirect("EventBeheerPlaatsWijzigVerwijder.aspx");
        }

        protected void btnVerhuur_Click(object sender, EventArgs e)
        {

        }
    }
}