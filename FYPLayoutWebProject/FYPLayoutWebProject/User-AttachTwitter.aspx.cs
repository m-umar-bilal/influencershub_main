using LinqToTwitter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TwitterHandler;

namespace FYPLayoutWebProject
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        AspNetAuthorizer auth;
        protected async void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (Session["Type"].Equals("User"))
                {
                    if (!Session["Category"].Equals("false"))
                    {
                        auth = TwitterDeveloper.authorizeTwitterForCustomer(Response);
            if (!Page.IsPostBack && Request.QueryString["oauth_token"] != null)
            {
                await auth.CompleteAuthorizeAsync(Request.Url);
                var tempCrendentials = auth.CredentialStore;
                string oauthToken = tempCrendentials.OAuthToken;
                string oauthTokenSecret = tempCrendentials.OAuthTokenSecret;
                           // string image = tempCrendentials.;
//                  var ctx = new TwitterContext(auth);
                            UserAccess.User user = new UserAccess.User();
                var imgURL = "https://pbs.twimg.com/profile_images/453219211154694144/_3mXZzxU_400x400.jpeg";
//                await
//                (from User in ctx.User
//                 select User.ProfileImageUrl)
//                .ToListAsync();
                            try
                {

                    await user.AddTwitterAccount(Session["Email"].ToString(), oauthToken, oauthTokenSecret,imgURL);
                                Session["Token"] = oauthToken;
                                Session["TokenSecret"] = oauthTokenSecret;

                                Response.Redirect("/User-ConfirmEmail.aspx", false);
                     Context.ApplicationInstance.CompleteRequest();

                            }
                catch(Exception eee)
                {
                    var a = Session["Email"].ToString();
                }


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
        protected async void Button1_Click(object sender, EventArgs e)
        {
            await auth.BeginAuthorizeAsync(Request.Url);
        }
    }

}