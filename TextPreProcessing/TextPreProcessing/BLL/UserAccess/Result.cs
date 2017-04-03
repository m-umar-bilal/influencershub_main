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
    public class Result
    {


        public int favourites { get; set; }
        public int retweets { get; set; }
        public int totalFav { get; set; }
        public int followers { get; set; }
        public int statuses { get; set; }
        public int friends { get; set; }



        public  Result()
        {
            
            favourites = 0;
            followers = 0;
            retweets = 0;
            friends = 0;
            statuses = 0;
            totalFav = 0;

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

            var Score = new Result();
            Influencer inf = new Influencer();
            inf.ScreenName = UserName;

            foreach (Status t in tweets)
            {
                if (t.FavoriteCount.HasValue)
                {
                    
                        Score.favourites += t.FavoriteCount.Value;
                    
                }
               
                    Score.retweets += t.RetweetCount;

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

                    Score.totalFav = u.FavoritesCount;
                    Score.friends = u.FriendsCount;
                    Score.followers = u.FollowersCount;
                    Score.statuses = u.StatusesCount;
                    inf.ImageUrl = u.ProfileImageUrl;
                    inf.Location = u.Location;
                    inf.Name = u.Name;
                        
                }
            }
            inf.result = Score;
            inf.Score = CalculateScore(Score);
            inf.UpdateInluencerScore(inf);
    }


        public int CalculateScore(Result score )
        {

            float temp_Fav = (score.favourites * Settings1.Default.Weightage_Fav) / 100;
            float temp_TotalFav = (score.totalFav * Settings1.Default.Weightage_TotalFav) / 100;
            float temp_Status = (score.statuses * Settings1.Default.Weightage_Statuses) / 100;
            float temp_Retweets = (score.retweets * Settings1.Default.Weightage_Retweets) / 100;
            float temp_Friends = (score.friends * Settings1.Default.Weightage_Friends) / 100;
            float temp_Followers = (score.followers * Settings1.Default.Weightage_Followers) / 100;

            

            return Convert.ToInt32(Math.Round(Math.Log(temp_Fav,10) + Math.Log(temp_Friends,10) + Math.Log(temp_Retweets,10) + Math.Log(temp_Status,10) + Math.Log(temp_TotalFav,10) + Math.Log(temp_Followers,10)));


        }
    }
}
