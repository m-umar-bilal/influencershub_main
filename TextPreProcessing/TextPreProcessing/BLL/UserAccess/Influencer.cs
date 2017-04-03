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

        public String ImageUrl { get; set; }       

        public String Location { get; set; }

        public String Name { get; set; }

        public Result result { get; set; }
        

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

            var Collec = db.GetCollection<Influencer>("Influencers");
            var filter = Builders<Influencer>.Filter.Eq("Category", category);
            List<Influencer> inf = new List<Influencer>();
            Task.Run(async () =>
            {
                inf = await Collec.Find(filter).ToListAsync();
            }).Wait();
            List<Influencer> infList = new List<Influencer>();
            infList = inf;
           
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
          

            foreach (var document in inf)
            {
                Influencer tempInf = new Influencer();
                Result score = new Result();
               // Task.Run(async () =>
                //{
                    score.getScoreofInfluencer(Convert.ToString(document["ScreenName"]));
                //}).Wait();

            }
           
        }

        public static Influencer GetInfluencer(string scrname)
        {
            var Client = new MongoClient();
            var db = Client.GetDatabase("InfluencersHub");

            var Collec = db.GetCollection<Influencer>("Influencers");
            var filter = Builders<Influencer>.Filter.Eq("ScreenName", scrname);
            List<Influencer> inf = new List<Influencer>();
            Task.Run(async () =>
            {
                inf = await Collec.Find(filter).ToListAsync();
            }).Wait();
            List<Influencer> infList = new List<Influencer>();
            infList = inf;

            return infList[0];
        }

        public async void UpdateInluencerScore(Influencer inf)
        {
            var Client = new MongoClient();
            var db = Client.GetDatabase("InfluencersHub");
            var collection = db.GetCollection<BsonDocument>("Influencers");
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("ScreenName", inf.ScreenName);
            var update = Builders<BsonDocument>.Update.Set("Score", inf.Score).Set("Location",inf.Location).Set("ImageUrl",inf.ImageUrl).Set("Name",inf.Name).Set("result.favourites", inf.result.favourites).Set("result.retweets", inf.result.retweets).Set("result.totalFav", inf.result.totalFav).Set("result.followers", inf.result.followers).Set("result.statuses", inf.result.statuses).Set("result.friends", inf.result.friends);
            var result = await collection.UpdateManyAsync(filter, update);
        }
    }
}
