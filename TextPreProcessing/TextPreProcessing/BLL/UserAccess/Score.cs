using LinqToTwitter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetsAndTrends;
using TwitterHandler;
using UserAccess;

namespace TextPreProcessing.BLL.UserAccess
{
    public class Score
    {

        
       public int Favourites { get; set; }

       public int Retweets { get; set; }

        public int TotalFav { get; set; }

        public int Friends { get; set; }

        public int Statuses { get; set; }

        public int Followers { get; set; }


        public int CombinedScore { get; set; }


      public  Score()
        {
            
            Favourites = 0;
            Followers = 0;
            Retweets = 0;
            Friends = 0;
            Statuses = 0;
            TotalFav = 0;
            CombinedScore = 0;
        }


        public async Task getScoreofInfluencer(String UserName)
        {
            SingleUserAuthorizer authorizer = TwitterDeveloper.authorizeTwitter();
        var twitterContext = new TwitterContext(authorizer);



            var tweets =
                await
                (from tweet in twitterContext.Status
                 where tweet.Type == StatusType.User &&
                       tweet.ScreenName == UserName &&
                       tweet.Count == (int)Settings1.Default.TweetsCount


             select tweet)
            .ToListAsync();

            var Score = new Score();

            foreach (Status t in tweets)
            {
                if (t.FavoriteCount.HasValue)
                {
                    
                        Score.Favourites += t.FavoriteCount.Value;
                    
                }
               
                    Score.Retweets += t.RetweetCount;

            }


            var userResponse =
               await
               (from user in twitterContext.User
                where user.Type == UserType.Lookup &&
                      user.ScreenNameList == UserName
                select user)
               .ToListAsync();

            if (userResponse != null)
            {
                foreach (LinqToTwitter.User u in userResponse)
                {

                    Score.TotalFav = u.FavoritesCount;
                    Score.Friends = u.FriendsCount;
                    Score.Followers = u.FollowersCount;
                    Score.Statuses = u.StatusesCount;
                        
                }
            }
            CalculateScore(Score);

            Influencer inf = new Influencer();
            inf.UpdateInluencerScore(UserName, Score);
    }


        public void CalculateScore(Score score )
        {

            float temp_Fav = (score.Favourites * Settings1.Default.Weightage_Fav) / 100;
            float temp_TotalFav = (score.TotalFav * Settings1.Default.Weightage_TotalFav) / 100;
            float temp_Status = (score.Statuses * Settings1.Default.Weightage_Statuses) / 100;
            float temp_Retweets = (score.Retweets * Settings1.Default.Weightage_Retweets) / 100;
            float temp_Friends = (score.Friends * Settings1.Default.Weightage_Friends) / 100;
            float temp_Followers = (score.Followers * Settings1.Default.Weightage_Followers) / 100;


            score.CombinedScore = Convert.ToInt32(Math.Round(temp_Fav + temp_Friends + temp_Retweets + temp_Status + temp_TotalFav + temp_Followers));


        }
    }
}
