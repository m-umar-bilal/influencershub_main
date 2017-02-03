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
using UserAccess;
using DBHandler;

namespace DAL 
{
    public class TrendsDb
    {

        public async Task addtrendIntoDb(List<Trends> trendlist)
        {
            var Client = new MongoClient();
            var db = Client.GetDatabase("InfluencersHub");
            var Collec = db.GetCollection<BsonDocument>("trends");
            var keys = Builders<BsonDocument>.IndexKeys.Ascending("Trend");
            var options = new CreateIndexOptions();
            options.Unique = true;
            await Collec.Indexes.CreateOneAsync(keys, options);


            foreach (Trends t in trendlist)
            {
                var document = new BsonDocument
            {
                {"Trend",t.Text},
                {"Country",t.Country},
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
        public static async Task<Dictionary<string,string>> GetAllTrends()
        {
           
            var trends = new Dictionary<string,string>();
            var collection = DBConnector.Database.GetCollection<BsonDocument>("TrendsCategory");
            //var filter = new BsonDocument();

            // var sort = Builders<BsonDocument>.Sort.Ascending("name");
            //var result = await collection.Find(filter).ToListAsync();
            var list = await collection.Find(new BsonDocument()).Project(Builders<BsonDocument>.Projection.Include("trend").Include("category").Exclude("_id")).ToListAsync();
            //
            /*using (var cursor = await collection.FindAsync(filter))
              {

                  while (await cursor.MoveNextAsync())
                  {
                      var batch = cursor.Current;
                      foreach (var document in batch)
                      {
                          Console.WriteLine(document[1]);
                      }
                  }
;
              }*/
            foreach (var document in list)
            {
                if (!trends.Keys.Contains(Convert.ToString(document[0])))
                    {
                    trends.Add(Convert.ToString(document[0]), Convert.ToString(document[1]));
                }
            }
            return trends;
        }
        public async Task getTrendsOfWeekDb(string date)
        {

            var Client = new MongoClient();
            var db = Client.GetDatabase("InfluencersHub");
            var Collec = db.GetCollection<BsonDocument>("trends");
            var filter = Builders<BsonDocument>.Filter.Gte("DateTime", date);
            Tweets t = new Tweets();
            try
            {
                using (var cursor = await Collec.FindAsync(filter))
                {

                    while (await cursor.MoveNextAsync())
                    {
                        var batch = cursor.Current;
                        foreach (var document in batch)
                        {
                            BsonSerializer.Deserialize<User>(document);
                            await t.getTweetsOfTrends(document["Trend"].ToString());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                var a = e;
            }

        }

        public async Task<Dictionary<String, String>> getTrendsFromDb(String category) // Null for All
        {
            var Client = new MongoClient();
            var db = Client.GetDatabase("InfluencersHub");
            var Collec = db.GetCollection<BsonDocument>("TrendsCategory");
            Dictionary<string, string> trendList = new Dictionary<string, string>();
            var filter = Builders<BsonDocument>.Filter.Eq("Category", category);
            try
            {
                if (category.Equals(""))
                {
                    var list = await Collec.Find(new BsonDocument()).ToListAsync();



                    foreach (var document in list)
                    {
                        trendList.Add(Convert.ToString(document[1]), Convert.ToString(document[0]));
                    }
                }
                else
                {
                    var list = await Collec.Find(filter).ToListAsync();
                    foreach (var document in list)
                    {
                        trendList.Add(Convert.ToString(document[1]), Convert.ToString(document[0]));
                    }
                }
                return trendList;
            }
            catch (Exception e)
            {
                return null;
            }

        }
    }
}