﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LoginExercise.model;

namespace LoginExercise
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int PersonID = (int)Session["ID"];
            using (TestEntities db=new TestEntities())
            {
                var user = db.Users.FirstOrDefault(usr => usr.Personid == PersonID);
                if (user.Accesslevel < 2)
                {
                    nav3.Visible = true;
                }
            }
            
            string currentPage = Path.GetFileName(Request.Url.AbsolutePath);

            if (currentPage.Equals("Dashboard.aspx"))
            {
                nav1.Attributes["class"] = "nav-link active";
            }
            else if (currentPage.Equals("Profile.aspx"))
            {
                nav2.Attributes["class"] = "nav-link active bg-warning";
            }
            else if (currentPage.Equals("UsersTable.aspx"))
            {
                nav3.Attributes["class"] = "nav-link active bg-danger";
            }
            else if (currentPage.Equals("Shop.aspx"))
            {
                nav4.Attributes["class"] = "nav-link active bg-success";
            }
            // Add more conditions for other nav items

            // Remove active class from other nav items
            if (!currentPage.Equals("Dashboard.aspx"))
            {
                nav1.Attributes["class"] = "nav-link";
            }
            if (!currentPage.Equals("Profile.aspx"))
            {
                nav2.Attributes["class"] = "nav-link";
            }
            if (!currentPage.Equals("UsersTable.aspx"))
            {
                nav3.Attributes["class"] = "nav-link";
            }
            if (!currentPage.Equals("Shop.aspx"))
            {
                nav4.Attributes["class"] = "nav-link";
            }
            // Remove active class from other nav items
        }
        protected void tab1_Load(object sender, EventArgs e)
        {

        }

        protected void SignOutBtn_Click(object sender, EventArgs e)
        {
            Session["ID"] = null;
            Response.Redirect("Login.aspx");
        }
    }
}
