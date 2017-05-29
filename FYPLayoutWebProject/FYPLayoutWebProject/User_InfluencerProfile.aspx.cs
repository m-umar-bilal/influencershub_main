using FYPLayoutWebProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TextPreProcessing.BLL.TwitterAccess;
using TextPreProcessing.BLL.UserAccess;
using UserAccess;

namespace FYPLayoutWebProject
{
    public partial class User_InfluencerProfile : System.Web.UI.Page
    {
        public string pScrName { get; set; }
        public List<InfluencerViewModel> InfluencerViewModels { get; set; } = new List<InfluencerViewModel>();
        public ProfileViewModel influencer { get; set; } = new ProfileViewModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            pScrName= (string)Request.QueryString["name"];

            LoadInfluencer(pScrName);
            if (Influencer.CheckBookmark(Convert.ToString(Session["Email"]), influencer.ScreenName))
            {
                Button2.Enabled = false;
                Button2.Visible = false;
            }
        }
        private void LoadInfluencer(String name)
        {



            var item = UserAccess.Influencer.GetInfluencer(name);
            influencer = new ProfileViewModel()
            {
                Location = item.Location,
                
                ImageUrl = item.ImageUrl,
                Name = item.Name,
                Category = item.Category,
                ScreenName = item.ScreenName,
                result = new ResultViewModel()
                {
                    favourites = item.result.favourites,
                    totalFav = item.result.totalFav,
                    statuses = item.result.statuses,
                    retweets = item.result.retweets,
                    followers = item.result.followers,
                    friends = item.result.friends
                },
               
                Score = item.Score

                };


            
        }

        protected  void BtnSend_Click(object sender, EventArgs e)
        {
            Session["TempScrnName"] = influencer.ScreenName;
            Response.Redirect("~/User-Message.aspx", false);
            Context.ApplicationInstance.CompleteRequest();

        }


        protected void BtnBookmark_Click(object sender, EventArgs e)
        {
            Influencer bmInfluencer = new Influencer();
            bmInfluencer.bookMarkInfluencer(Convert.ToString(Session["Email"]), influencer.ScreenName);
            Response.Redirect("/User_InfluencerProfile.aspx?name=" + influencer.ScreenName, false);
            Context.ApplicationInstance.CompleteRequest();



        }
    }
}