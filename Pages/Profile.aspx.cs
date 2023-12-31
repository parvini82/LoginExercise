﻿using LoginExercise.model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginExercise.Pages
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            int PersonID = (int)Session["ID"];
            if (!IsPostBack)
            {

                using (TestEntities db = new TestEntities())
                {
                    var user = db.Users.FirstOrDefault(usr => usr.Personid == PersonID);
                    firstname.Text = user.Firstname;
                    lastname.Text = user.Lastname;
                    Email.Text = user.Email;
                    Gender.Text = user.Gender;
                    Address.Text = user.Address;
                    aboutme.Text = user.About_Me;
                    City.Text = user.City;
                    Country.Text = user.Country;
                    Postalcode.Text = user.Postal_Code;
                }
            }

        }

        protected void save_Click(object sender, EventArgs e)
        {
            int personID = (int)Session["ID"];

            using (TestEntities db = new TestEntities())
            {
                var user = db.Users.FirstOrDefault(usr => usr.Personid == personID);
                user.Firstname = firstname.Text;
                user.Lastname = lastname.Text;
                user.Email = Email.Text;
                user.Gender = Gender.Text;
                user.Address = Address.Text;
                user.Country = Country.Text;
                user.City = City.Text;
                user.Postal_Code = Postalcode.Text;
                string directoryPath = Server.MapPath("~/ProfilePictures/");
                string fileNamePattern = personID.ToString() + ".*";
                string[] matchingFiles = Directory.GetFiles(directoryPath, fileNamePattern);

                if (matchingFiles.Length > 0)
                {
                    File.Delete(matchingFiles[0]);
                }
                else
                {

                    profilePictureUpload.SaveAs(Server.MapPath("~/ProfilePictures/" + personID + System.IO.Path.GetExtension(profilePictureUpload.FileName).ToLower()));
                }

            }
        }
    }
}