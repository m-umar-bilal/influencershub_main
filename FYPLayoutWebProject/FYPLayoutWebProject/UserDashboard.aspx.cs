using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPLayoutWebProject.ViewModel;
using LinqToTwitter;
using TwitterHandler;



namespace FYPLayoutWebProject
{
    public partial class UserDashboard1 : System.Web.UI.Page
    {
        public List<InfluencerViewModel> InfluencerViewModels { get; set; } = new List<InfluencerViewModel>();
        static readonly SingleUserAuthorizer Authorizer = TwitterDeveloper.authorizeTwitter();
        static readonly TwitterContext TwitterContext = new TwitterContext(Authorizer);

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Type"].Equals("User"))
                {


                    if (!Session["Category"].Equals("false"))
                    {
                        if(!Session["Token"].Equals("false"))
                        {
                            if (Session["EmailConfirm"].Equals("true"))
                            {
                                // RegisterAsyncTask(new PageAsyncTask(LoadInfluencers));
                                Task.Run(async () =>
                                {
                                    await LoadInfluencers(Session["Category"].ToString());
                                }).Wait();
                            }
                            else
                            {
                                Response.Redirect("/User-ConfirmEmail.aspx", false);
                                Context.ApplicationInstance.CompleteRequest();
                            }

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

        private async Task LoadInfluencers(String Category)
        {
            foreach (var item in UserAccess.Influencer.GetInfluencersByCategory(Category))
            {
                

                var userResponse =
                    await
                        (from user in TwitterContext.User
                         where user.Type == UserType.Lookup &&
                                   user.ScreenNameList == item.ScreenName
                         select user)
                            .ToListAsync();

                if (userResponse != null)
                    userResponse.ForEach(user =>
                            InfluencerViewModels.Add(new InfluencerViewModel()
                            {
                                    Location = user.Location,
                                    ProfileImageUrl = user.ProfileImageUrl,
                                    Name = user.Name,
                                    Category = item.Category,
                                    Screenname = item.ScreenName
                            })
                    );


            }
        }

     
    }
}