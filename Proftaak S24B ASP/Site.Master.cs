﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proftaak_S24B_ASP
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if((string)Session["IngelogdAccount"] == "Gebruiker")
            {
                btnAccount.Visible = true;
                btnUpload.Visible = true;
                btnLogout.Visible = true;
            }
            else if((string)Session["IngelogdAccount"] == "Beheerder")
            {
                btnAccount.Visible = true;
                btnUpload.Visible = true;
                btnBeheer.Visible = true;
                btnLogout.Visible = true;
            }

            VulSubMenu();
        }

        public void VulSubMenu()
        {
            TreeNode tn = new TreeNode("Test");
            TreeNode tn2 = new TreeNode("Test2");
            TreeNode tn3 = new TreeNode("Test2");
            TreeNode tn4 = new TreeNode("Test2");
            TreeNode tn5 = new TreeNode("Test2");
            TreeNode tn6 = new TreeNode("Test2");
            tvwSubMenu.Nodes.Add(tn);
            tn.ChildNodes.Add(tn2);
            tn2.ChildNodes.Add(tn3);
            tn3.ChildNodes.Add(tn4);
            tn4.ChildNodes.Add(tn5);
            tn5.ChildNodes.Add(tn6);
            tvwSubMenu.CollapseAll();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Session["IngelogdAccount"] = "Beheerder";
            Response.Redirect("Default.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Contents.Remove("IngelogdAccount");
            Response.Redirect("Default.aspx");
        }

        protected void btnLogin_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Inloggen.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}