using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPLayoutWebProject.ViewModel;
using LinqToTwitter;
using TwitterHandler;

namespace FYPLayoutWebProject
{
    public partial class BookmarksView : System.Web.UI.Page
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
                        if (!Session["Token"].Equals("false"))
                        {
                            if (Session["EmailConfirm"].Equals("true"))
                            {
                                //  /RegisterAsyncTask(new PageAsyncTask(LoadInfluencers(Session["Category"].ToString())));



                                LoadInfluencers(Session["Category"].ToString());
                                if (!IsPostBack)
                                {
                                    GridView1.DataSource = InfluencerViewModels;
                                    GridView1.DataBind();
                                }

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
            catch (Exception ex)
            {
                Response.Redirect("/SignIn.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }

        }

        protected void FollowBtn_Click(object sender, EventArgs e)
        {



            Button button = (Button)sender;

            string name = Convert.ToString(button.Attributes["scrName"]);
            Response.Redirect("/User_InfluencerProfile.aspx?name=" + name, false);
            Context.ApplicationInstance.CompleteRequest();


        }

        private void LoadInfluencers(String Category)
        {
            foreach (var item in UserAccess.Influencer.GetBookMarkedInfluencers(Convert.ToString(Session["Email"])))
            {



                InfluencerViewModels.Add(new InfluencerViewModel()
                {
                    Location = item.Location,
                    ProfileImageUrl = item.ImageUrl,
                    Name = item.Name,
                    Category = item.Category,
                    Screenname = item.ScreenName,
                    Followers = item.result.followers,
                    Friends = item.result.friends,
                    Score = item.Score

                });


            }

            List<InfluencerViewModel> ordered = InfluencerViewModels.OrderByDescending(f => f.Score).ToList();
            InfluencerViewModels = ordered;
        }

    }
}