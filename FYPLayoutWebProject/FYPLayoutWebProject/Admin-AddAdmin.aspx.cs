using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserAccess;

namespace Views
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Type"].Equals("Admin"))
                {
                    lblError.Text = "";
                }
                else
                {
                    Response.Redirect("/Admin.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch(Exception ee)
            {
                Response.Redirect("/Admin.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            

           
        }
        protected void register(object sender, EventArgs e)
        {
            string fname = Request.Form["firstname"];
            string lname = Request.Form["lastname"];
            string email = Request.Form["email"];
            string password = Request.Form["password"];


            Admin u = new Admin();
            u.addAdmin(fname, lname, email, password);
        }

        protected void registerbtn(object sender, EventArgs e)
        {
            string fname = Request.Form["firstname"];
            string lname = Request.Form["lastname"];
            string email = Request.Form["email"];
            string password = Request.Form["password"];

            Admin u = new Admin();

            if (u.addAdmin(fname, lname, email, password))
            {
                lblError.Text = "New Admin Added!";
            }
            else
            {
                lblError.Text = "Sorry! Admin with this Email is already registered";
            }





        }

    }
}