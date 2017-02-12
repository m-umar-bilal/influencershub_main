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

        public static async void AddInfluencerToDb(string screenname, string category)
        {
            Influencer tempInfluencer = null;
            tempInfluencer = new Influencer() { Category = category, ScreenName = screenname };
            var Client = new MongoClient();
            var db = Client.GetDatabase("InfluencersHub");
            var Collec = db.GetCollection<Influencer>("Influencers");


            try
            {
                // For Indexing
                var keys = Builders<BsonDocument>.IndexKeys.Ascending("ScreenName").Ascending("Category");
                var Collectemp = db.GetCollection<BsonDocument>("Influencers");
                var options = new CreateIndexOptions();
                options.Unique = true;
                await Collectemp.Indexes.CreateOneAsync(keys, options);
            }
            catch (Exception e)
            {

            }

            try
            {
                 Collec.InsertOne(tempInfluencer);
            }
            catch (Exception e)
            {
                return;
            }
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

      


        public async void FillInfluencers()
        {
            var Client = new MongoClient();
            var db = Client.GetDatabase("InfluencersHub");
            var Collec = db.GetCollection<BsonDocument>("trends_Tweets");

            // For Indexing
            var keys = Builders<BsonDocument>.IndexKeys.Ascending("ScreenName").Ascending("Category");
            var Collectemp = db.GetCollection<BsonDocument>("Influencers");
            var options = new CreateIndexOptions();
            options.Unique = true;
            await Collectemp.Indexes.CreateOneAsync(keys, options);

            try
            {
                var list = await Collec.Aggregate().Lookup("TrendsCategory", "Trend", "trend", "second").ToListAsync();

                foreach (var document in list)
                {
                    // userlist.Add(new Influencer() { Category = "", ScreenName = Convert.ToString(document["UserName"]) } );


                    var category = document["second"].AsBsonArray;
                    var temp1 = category[0].AsBsonDocument;
                    var temp = temp1["category"].AsString;

                    AddInfluencerToDb(document["UserName"].AsString, temp);
                }

            }
            catch (Exception e)
            {

            }

        }
    }
}
