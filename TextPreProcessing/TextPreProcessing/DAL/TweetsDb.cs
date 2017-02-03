using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using DAL;
using TweetsAndTrends;

namespace DAL 
{
    class TweetsDb
    {
        public async Task<Dictionary<String, String>> getTweetsOfTrendsToDisplayFromDb(String Trend)
        {

            var Client = new MongoClient();
            var db = Client.GetDatabase("InfluencersHub");
            var Collec = db.GetCollection<BsonDocument>("trends_Tweets");
            var filter = Builders<BsonDocument>.Filter.Eq("Trend", Trend);

            try
            {
                var list = await Collec.Find(filter).Project(Builders<BsonDocument>.Projection.Include("UserName").Include("Tweet").Exclude("_id")).ToListAsync();

                Dictionary<String, String> tweetlist = new Dictionary<string, string>();

                foreach (var document in list)
                {
                    tweetlist.Add(Convert.ToString(document[0]), Convert.ToString(document[1]));
                }
                return tweetlist;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public async Task<List<String>> getTweetsOfTrendsFromDB(String Trend)
        {

            var Client = new MongoClient();
            var db = Client.GetDatabase("InfluencersHub");
            var Collec = db.GetCollection<BsonDocument>("trends_Tweets");
            var filter = Builders<BsonDocument>.Filter.Eq("Trend", Trend);

            try
            {
                var list = await Collec.Find(filter).Project(Builders<BsonDocument>.Projection.Include("Tweet").Exclude("_id")).ToListAsync();

                List<String> tweetlist = new List<String>();

                foreach (var document in list)
                {
                    tweetlist.Add(Convert.ToString(document[0]));
                }
                return tweetlist;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public async Task addtweetsIntoDb(List<Tweets> tweetlist)
        {
            var Client = new MongoClient();
            var db = Client.GetDatabase("InfluencersHub");
            var keys = Builders<BsonDocument>.IndexKeys.Ascending("Trend").Ascending("Tweet");
            var Collec = db.GetCollection<BsonDocument>("trends_Tweets");
            var options = new CreateIndexOptions();
            options.Unique = true;
            await Collec.Indexes.CreateOneAsync(keys, options);
            foreach (Tweets t in tweetlist)
            {
                if (true)
                {
                    var document = new BsonDocument
            {
                 {"Trend",t.Trend},
                {"Tweet",t.Text},
                {"UserName",t.UserName},
                {"DateTime",t.DateTime}

            };
                    try
                    {
                        await Collec.InsertOneAsync(document);
                    }
                    catch
                    {
                        continue;
                    }
                }
            }

        }

    }
}