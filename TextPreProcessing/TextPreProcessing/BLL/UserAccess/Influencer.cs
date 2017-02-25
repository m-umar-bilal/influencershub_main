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
using TextPreProcessing.BLL.UserAccess;

namespace UserAccess
{
    public class Influencer
    {
        public MongoDB.Bson.ObjectId Id { get; set; }
        public String ScreenName { get; set; }

        public String Category { get; set; }

        public int Score { get; set; }
        

        public static async void AddInfluencerToDb(string screenname, string category)
        {
            Influencer tempInfluencer = null;
            tempInfluencer = new Influencer() { Category = category, ScreenName = screenname, Score = 0 };
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



        public static  List<Influencer> GetInfluencersByCategory(string category)
        {
            var Client = new MongoClient();
            var db = Client.GetDatabase("InfluencersHub");

            var Collec = db.GetCollection<BsonDocument>("Influencers");
            var filter = Builders<BsonDocument>.Filter.Eq("Category", category);
            List<BsonDocument> inf = new List<BsonDocument>();
            Task.Run(async () =>
            {
                inf = await Collec.Find(filter).ToListAsync();
            }).Wait();
            List<Influencer> infList = new List<Influencer>();

            foreach (var document in inf)
            {
                Influencer tempInf = new Influencer();
                tempInf.ScreenName = Convert.ToString(document["ScreenName"]);
                tempInf.Category = Convert.ToString(document["Category"]);
                tempInf.Score = Convert.ToInt32(document["Score"]);
                infList.Add(tempInf);
            }
            return infList;


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
        public void UpdateAllInfluencersScore()
        {
            var Client = new MongoClient();
            var db = Client.GetDatabase("InfluencersHub");

            var Collec = db.GetCollection<BsonDocument>("Influencers");
            List<BsonDocument> inf = new List<BsonDocument>();
            Task.Run(async () =>
            {
                inf = await Collec.Find(new BsonDocument()).ToListAsync();
            }).Wait();
            List<Influencer> infList = new List<Influencer>();

            foreach (var document in inf)
            {
                Influencer tempInf = new Influencer();
                Score score = new Score();
               // Task.Run(async () =>
                //{
                    score.getScoreofInfluencer(Convert.ToString(document["ScreenName"]));
                //}).Wait();

            }
           
        }

        

        public async void UpdateInluencerScore(String InfluencerName, Score score)
        {
            var Client = new MongoClient();
            var db = Client.GetDatabase("InfluencersHub");
            var collection = db.GetCollection<BsonDocument>("Influencers");
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("ScreenName", InfluencerName);
            var update = Builders<BsonDocument>.Update.Set("Score", score.CombinedScore).Set("result.favourites", score.Favourites).Set("result.retweets", score.Retweets).Set("result.totalFav", score.TotalFav).Set("result.followers", score.Followers).Set("result.statuses", score.Statuses).Set("result.friends", score.Friends);
            var result = await collection.UpdateManyAsync(filter, update);
        }
    }
}
