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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            String email = Request.Form["email"];
            UserAccess.Login login = new UserAccess.Login();
            bool check = false;
            Task.Run(async () =>
            {
                try
                {
                    // Start the task.
                   check = await UserAccess.Login.ForgottenPassword(email);

                }
                catch (Exception eee)
                {
                    //Console.WriteLine(e.Message);
                    // Perform cleanup here.
                }

            }).Wait();

            if (check)
            {
              
                String ex = "Password Sent on " + email;
                string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
                Type cstype = this.GetType();
                ClientScriptManager cs = this.Page.ClientScript;
                cs.RegisterClientScriptBlock(cstype, s, s.ToString());
                //Response.Redirect("~/SignIn.aspx");

            }


            else
            {
                lblError.Text = "Email is not registered";
            }
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SignIn.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}