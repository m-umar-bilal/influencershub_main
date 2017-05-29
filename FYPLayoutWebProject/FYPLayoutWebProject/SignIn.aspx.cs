using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserAccess;
using TweetsAndTrends;
using TextPreProcessing.BLL.UserAccess;

namespace Views
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           Session.Clear();
            
        }
        protected void loginbtn(object sender, EventArgs e)
        {
            lblError.Text = "";
           

             UserAccess.Login login = new UserAccess.Login();
            String email = Request.Form["email"];
            String password = Request.Form["password"];

            User u = null;
            Task.Run(async () =>
            {
                try
                {
                   u = await login.getLogin(email, password);


                  //Influencer inf = new Influencer();
                   // inf.FillInfluencers();
                    
                }

                catch (Exception ex) {
                    
                }
//               Influencer i = new Influencer();
//              i.UpdateAllInfluencersScore();
            }).Wait();

            
            if (u != null)
            {
                
                Session["FName"] = u.FirstName;
                Session["LName"] = u.LastName;
                Session["Email"] = u.Email;
                Session["Category"] = u.Category;
                Session["Token"] = u.OauthToken;
                Session["Token"] = u.OauthTokenSecret;
                Session["EmailConfirm"] = u.EmailConfirm;
                Session["Type"] = "User";
                Session["Image"] = u.Image;

              //  Response.Redirect("~/User-AttachTwitter.aspx", false);
               Response.Redirect("~/UserDashboard.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            else
            {
                lblError.Text = "Email or Password is incorrect";
            }


        }
       
       
    }
}