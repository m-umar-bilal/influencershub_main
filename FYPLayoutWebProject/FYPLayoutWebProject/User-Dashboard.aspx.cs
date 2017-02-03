using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Views
{
    public partial class WebForm12 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Type"].Equals("User"))
                {
                
               if (Session["EmailConfirm"].Equals("true"))
                  {

                  }
                 else   
                   {
                        
                       // Response.Redirect("/User-ConfirmEmail.aspx");
                            Response.Redirect("/User-ConfirmEmail.aspx", false);
                            Context.ApplicationInstance.CompleteRequest();
                        
                        
                    }   

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
    }
}