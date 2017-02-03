using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToTwitter;
using MongoDB.Bson;
using MongoDB.Driver;
using TweetsAndTrends;
using TwitterHandler;

namespace UserAccess
{
    public class Influencer
    {
        public MongoDB.Bson.ObjectId Id { get; set; }
        public String ScreenName { get; set; }

        public String Category { get; set; }

        public static void AddInfluencerToDb(string screenname, string category)
        {
            Influencer tempInfluencer=null;
            SingleUserAuthorizer authorizer = TwitterDeveloper.authorizeTwitter();
            var twitterContext = new TwitterContext(authorizer);
            Task.Run(async () =>
            {
                var userResponse =
                    await
                        (from user in twitterContext.User
                                where user.Type == UserType.Lookup &&
                                      user.ScreenNameList == screenname
                                select user)
                            .ToListAsync();

                if (userResponse != null)
                    userResponse.ForEach(user =>
                                tempInfluencer = new Influencer() {Category = category, ScreenName = screenname}
                    );
            }).Wait();




            var Client = new MongoClient();
            var db = Client.GetDatabase("InfluencersHub");

            var Collec = db.GetCollection<Influencer>("Influencers");
            Collec.InsertOne(tempInfluencer);
        }

        public static List<Influencer> GetInfluencersByCategory(string category)
        {
            var Client = new MongoClient();
            var db = Client.GetDatabase("InfluencersHub");

            var Collec = db.GetCollection<Influencer>("Influencers");
            var inf = Collec.Find(x => x.Category == category);
          //  inf = inf.Limit(1);
            var result = inf.ToList();
            return result;
        }
    }
}
