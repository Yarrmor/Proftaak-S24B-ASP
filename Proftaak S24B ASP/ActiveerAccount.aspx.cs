﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proftaak_S24B_ASP
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string activatieHash = Request.QueryString["activate"];
            if (activatieHash == null)
            {
                Response.Redirect("Default.aspx");
            }

            Session["Account"] = VerkrijgAccount(activatieHash);

            Account acc = Session["Account"] as Account;

            if (acc != null)
            {
                if (!acc.Geactiveerd)
                {
                    lblValInformatie.Text = "Stel wachtwoord in voor: " + acc.Email;
                    ActiveerControls();
                }
                else
                {
                    lblActivatieHashGebruikt.Visible = true;
                    lblValOngeldig.Visible = false;
                    DeActiveerControls();
                }
            }
            else
            {
                lblValOngeldig.Visible = true;
                lblActivatieHashGebruikt.Visible = false;
                DeActiveerControls();
                Response.Write("U heeft een ongeldige activatie code ingevoerd!");
            }
        }

        private void ActiveerControls()
        {
            tbxBevestigWachtwoord.Enabled = true;
            tbxGebruikersnaam.Enabled = true;
            tbxWachtwoord.Enabled = true;
            btnActiveer.Enabled = true;
            lblValOngeldig.Visible = false;
            lblActivatieHashGebruikt.Visible = false;
        }

        private void DeActiveerControls()
        {
            tbxBevestigWachtwoord.Enabled = false;
            tbxGebruikersnaam.Enabled = false;
            tbxWachtwoord.Enabled = false;
            btnActiveer.Enabled = false;
        }

        private Account VerkrijgAccount(string activatieHash)
        {
            DatabaseManager dm = new DatabaseManager();
            return dm.VerkrijgAccount(activatieHash);
        }

        protected void btnActiveer_Click(object sender, EventArgs e)
        {
            lblActivatieMislukt.Visible = false;
            DatabaseManager dm = new DatabaseManager();
            InlogSysteem inlog = new InlogSysteem();

            Account acc = Session["Account"] as Account;

            if (acc != null)
            {
                if (dm.ActiveerAccount(acc.ID, tbxGebruikersnaam.Text, inlog.getHashSha256(tbxWachtwoord.Text)))
                {
                    Response.Redirect("InlogPagina.aspx");
                }
                else
                {
                    lblActivatieMislukt.Visible = true;
                }
            }
        }
    }
}