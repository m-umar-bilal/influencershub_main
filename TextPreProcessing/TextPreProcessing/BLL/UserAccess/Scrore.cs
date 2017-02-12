using LinqToTwitter;
using System;
using System.Collections.Generic;
using System.Linq;
using TweetsAndTrends;
using TwitterHandler;
using MongoDB.Driver;
using DAL;
using DBHandler;
using MongoDB.Bson;
using System.Text;
using System.Threading.Tasks;
using TextPreProcessing;

namespace TextPreProcessing.BLL.UserAccess
{
    class Scrore
    {
        public async Task getScoreofInfluencer(String UserName)
        {
            SingleUserAuthorizer authorizer = TwitterDeveloper.authorizeTwitter();
            var twitterContext = new TwitterContext(authorizer);

            List<Tweets> tweetList = new List<Tweets>();

            var tweets =
                await
                (from tweet in twitterContext.Status
                 where tweet.Type == StatusType.User &&
                       tweet.ScreenName == UserName
                       && tweet.Count < Settings1.Default.TweetsCount

                 select tweet)
                .ToListAsync();


           // if (tweets != null)
           //     tweets..ForEach(tweet => tweetList.Add(new Tweets(tweet.Text, Convert.ToString(tweet.User.ScreenNameResponse), trend, tweet.CreatedAt)));

            

        }
    }
}
