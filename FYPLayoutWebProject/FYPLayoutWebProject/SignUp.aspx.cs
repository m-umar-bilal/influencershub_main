﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserAccess;

namespace Views
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
        }
        protected void register(object sender, EventArgs e)
        {
            string fname = Request.Form["firstname"];
            string lname = Request.Form["lastname"];
            string email = Request.Form["email"];
            string password = Request.Form["password"];


            User u = new User();
            u.addUser(fname, lname, email, password);

            Response.Write(email + " : " + password);
        }

        protected void registerbtn(object sender, EventArgs e)
        {
            string fname = Request.Form["firstname"];
            string lname = Request.Form["lastname"];
            string email = Request.Form["email"];
            string password = Request.Form["password"];

            User u = new User();

            if(u.addUser(fname, lname, email, password))
            {
                Session["FName"] = u.FirstName;
                Session["LName"] = u.LastName;
                Session["Email"] = u.Email;
              
                Session["EmailConfirm"] = u.EmailConfirm;
                Session["Type"] = "User";
                Response.Redirect("/User-ConfirmEmail.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            else
            {
                lblError.Text = "Sorry! This Email is already registered";
            }

            



        }

    }
}