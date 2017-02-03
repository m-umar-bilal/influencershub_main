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
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Type"].Equals("User"))
                {
                    
                }
                else
                {
                    Response.Redirect("/SignIn.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }

            catch (Exception ee)
            {
                Response.Redirect("/SignIn.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            User u = new User();
            bool answer = false;
            String code = ConfirmCode.Value;
            Task.Run(async () =>
            {
                try
                {
                  answer =  await u.ConfirmEmail("muhammad.abdullah5678@gmail.com", code);
                }
                catch (Exception eee)
                {
                    //Console.WriteLine(e.Message);
                    // Perform cleanup here.
                }

            }).Wait();

            if (answer)
            {
                ConfirmMessage.Text = "Your Email Is Confirmed";
                //ConfirmMessage.ApplyStyle =

                ConfirmCode.Visible = false;
                Button1.Visible = false;
                EnterCode.Visible = false;

            }
            else
            {
                ConfirmMessage.Text = "Enter Valid Code";
               
            }
            
        }
    }
}