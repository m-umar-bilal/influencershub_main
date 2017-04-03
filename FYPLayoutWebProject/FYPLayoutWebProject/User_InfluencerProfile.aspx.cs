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
            int a = 1 + 2;
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
    }
}