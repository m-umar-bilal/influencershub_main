﻿using System;
using System.Collections.Generic;
using System.Drawing;
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
            ConfirmCode.ForeColor = Color.Black;
            try
            {
                if (Session["Type"].Equals("User"))
                {
                    if (!Session["Category"].Equals("false"))
                    {
                        if (!Session["Token"].Equals("false"))
                        {

                        }
                        else
                        {
                            Response.Redirect("/User-AttachTwitter.aspx", false);
                            Context.ApplicationInstance.CompleteRequest();
                        }
                    }
                    else
                    {
                        Response.Redirect("/User-SelectCategory.aspx", false);
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            User u = new User();
            bool answer = false;
            String code = ConfirmCode.Text;
            Task.Run(async () =>
            {
                try
                {
                 await u.ConfirmEmail(Session["Email"].ToString(), code);
                   
                }
                catch (Exception eee)
                {
                    //Console.WriteLine(e.Message);
                    // Perform cleanup here.
                }

            }).Wait();
            ConfirmMessage.Text = Convert.ToString(Session["EmailConfirm"]);
            if (Convert.ToString(Session["EmailConfirm"]) == code)
            {
                answer = true;
            }
           if (answer)
            {
                Session["EmailConfirm"] = "true";
                ConfirmMessage.Text = "Your Email Is Confirmed";
                //ConfirmMessage.ApplyStyle =

                ConfirmCode.Visible = false;
                Button1.Visible = false;
                EnterCode.Visible = false;
                Response.Redirect("~/UserDashboard.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            else
            {
                ConfirmMessage.Text = "Enter Valid Code";
               
            }
            
        }
    }
}