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
            RegisterAsyncTask(new PageAsyncTask(LoadInfluencers));     
        }

        private async Task LoadInfluencers()
        {
            foreach (var item in UserAccess.Influencer.GetInfluencersByCategory("Politics"))
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