using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserAccess;

namespace Views
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
        }
        protected void loginbtn(object sender, EventArgs e)
        {


            UserAccess.Login login = new UserAccess.Login();
            String email = Request.Form["email"];
            String password = Request.Form["password"];

            Admin admin = null;
            Task.Run(async () =>
            {
                try
                {
                   
                    // Start the task.
                      admin = await login.getLoginAdmin(email, password);

                    // Await the task.

                }
                catch (Exception eee)
                {
                    //Console.WriteLine(e.Message);
                    // Perform cleanup here.
                }

            }).Wait();

            if (admin != null)
            {
                Session["FName"] = admin.FirstName;
                Session["LName"] = admin.LastName;
                Session["Email"] = admin.Email;
               
                Session["Type"] = "Admin";
                Response.Redirect("/Admin-Dashboard.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            else
            {
                lblError.Text = "Email or Password is incorrect";
            }


        }


    }
}