using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LinqToTwitter;
using System.Threading.Tasks;
using System.Configuration;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using System.Text.RegularExpressions;
using TwitterHandler;
using TextClassification;
using DBHandler;
using DAL;
using TextPreProcessing.BLL.TextClassification;

namespace TweetsAndTrends
{
    public class Trends
    {
        private static Regex regex = new Regex(@"[A-Za-z0-9 .,-=+(){}\[\]\\]", RegexOptions.Compiled);
        public ObjectId id { get; set; }
        public string Text { get; set; }
        public string Country { get; set; }
        public DateTime DateTime { get; set; }
        
        public Trends()
        {
          
        }
        
        public static bool IsEnglish(string inputstring)
        {
            
            MatchCollection matches = regex.Matches(inputstring);

            if (matches.Count.Equals(inputstring.Length))
                return true;
            else
                return false;
        }
        public async Task<List<Trends>> getTrendsFromTwitter()
        {
            SingleUserAuthorizer authorizer = TwitterDeveloper.authorizeTwitter();
            var twitterContext = new TwitterContext(authorizer);
            List<Trend> trends =new List<Trend>();
            try
            {
                trends =
                   await
                   (from trend in twitterContext.Trends
                    where trend.Type == TrendType.Place &&
                          trend.WoeID == Int32.Parse("23424922")

                    select trend)
                   .ToListAsync();
            }
            catch
            {
                Console.WriteLine("Internet Not Working");
            }
            if (trends != null &&
                trends.Any() &&
                trends.First().Locations != null)
            {

                List<Trends> trendlist = new List<Trends>();

                foreach (Trend t in trends)
                {
                    if (IsEnglish(t.Name))
                    {
                        Trends temptrend = new Trends();
                        temptrend.Text = t.Name;
                        temptrend.Country = t.Locations.ToList().First().Name;
                        temptrend.DateTime = DateTime.Now;
                        trendlist.Add(temptrend);
                    }

                }
                await this.addtrendIntoDb(trendlist);
                return trendlist;
            }
            return null;


        }

        public async Task addtrendIntoDb(List<Trends> trendlist,string v)
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

        public async Task getTrendsOfWeek(string date, string v)
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
                            await t.getTweetsOfTrendsFromDB(document["Trend"].ToString());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                var a = e;
            }

        }

        public async Task ClassifyTrends()
        {
            List<Trends> trendList = null;
            Task.Run(async () =>
            {
                try
                {
                    trendList = await getTrendsFromTwitter();
                }
                catch (Exception eee)
                {
                    
                    //Console.WriteLine(e.Message);
                    // Perform cleanup here.
                   
                }

            }).Wait();

            Tweets tweets = new Tweets();
            List<String> temptweet = null;


            foreach (Trends tre in trendList)
            {

                await tweets.GetTweetsOfTrendFromTwitter(tre.Text);

            }
            NaiveBayes naivebayes = new NaiveBayes() ;
            foreach (Trends t in trendList)
            {
                Task.Run(async () =>
                {
                    try
                    {
                        temptweet = await tweets.getTweetsOfTrendsFromDB(t.Text);
                    }
                    catch (Exception eee)
                    {
                        //Console.WriteLine(e.Message);
                        // Perform cleanup here.
                    }

                }).Wait();
                var now = Convert.ToString(DateTime.Now); 
                
                string result = "";
                result= this.CategorizeTrend(t.Text, temptweet,naivebayes);
                if (!String.IsNullOrWhiteSpace(result))
                {
                    var collection = DBConnector.Database.GetCollection<BsonDocument>("TrendsCategory");
                   
                    
                    var document = new BsonDocument
                    {
                        {"trend",t.Text },
                        { "category", result },
                        {"timestamp",now }
                
                    };

                    await collection.InsertOneAsync(document);
                }
                else
                {
                    throw new System.ArgumentException("Parameter cannot be null", "category");
                }
            }


        }

        public static void ChangeCategoryOfTrend(string tName,string nCategory, string timestamp)
        {
            var Client = new MongoClient();
            var db = Client.GetDatabase("InfluencersHub");
            var Collec = db.GetCollection<BsonDocument>("TrendsCategory");
            var filter = Builders<BsonDocument>.Filter.Eq("trend", tName) & Builders<BsonDocument>.Filter.Eq("timestamp", timestamp);
            var update = Builders<BsonDocument>.Update.Set("category", nCategory);
            Collec.UpdateMany(filter, update);
        }
        public static List<TrendsCategory> GetTrendsOfCurrentWeekThatAreClassified()
        {
            var Client = new MongoClient();
            var db = Client.GetDatabase("InfluencersHub");
            var collection = db.GetCollection<TrendsCategory>("TrendsCategory");
           // var collection = DBConnector.Database.GetCollection<BsonDocument>("TrendsCategory");
            var builder = Builders<TrendsCategory>.Filter;
            var prevweekdate = DateTime.Today.AddDays(-7).Date.ToString("M/d/yyyy");
            var filter = builder.Regex("timestamp", "/"+prevweekdate+"/")|builder.Regex("timestamp", "/"+ DateTime.Today.AddDays(-6).Date.ToString("M/d/yyyy")+ "/") | builder.Regex("timestamp", "/"+ DateTime.Today.AddDays(-5).Date.ToString("M/d/yyyy")+ "/") | builder.Regex("timestamp", "/"+DateTime.Today.AddDays(-4).Date.ToString("M/d/yyyy")+ "/") | builder.Regex("timestamp", "/"+DateTime.Today.AddDays(-3).Date.ToString("M/d/yyyy")+ "/") | builder.Regex("timestamp", "/"+ DateTime.Today.AddDays(-2).Date.ToString("M/d/yyyy")+ "/") | builder.Regex("timestamp", "/"+DateTime.Today.AddDays(-1).Date.ToString("M/d/yyyy")+ "/") | builder.Regex("timestamp", "/"+ DateTime.Today.AddDays(0).Date.ToString("M/d/yyyy")+ "/");
            List<TrendsCategory> result=null;

            try
            {
                result = collection.Find(filter).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            } 
            
           // Console.WriteLine(DateTime.Today.AddDays(-1).Date.ToString("M/d/y"));


            return result;

        }
        private string CategorizeTrend(string text, List<string> temptweet, NaiveBayes n)
        {
            return n.ClassifyTrend(text, temptweet);
        }





        public Dictionary<String, String> getTrendList(String category) // Null for All
        {
            Dictionary<string, string> trendList = new Dictionary<string, string>();
            Task.Run(async () =>
            {
                try
                {
                    trendList = await getTrendsFromDb(category);
                }
                catch (Exception eee)
                {
                    //Console.WriteLine(e.Message);
                    // Perform cleanup here.
                }

            }).Wait();
            return trendList;


        }
        public async Task<Dictionary<String, String>> getTrendsFromDb(String category) // Null for All
        {
            TrendsDb tdb = new TrendsDb();
            return await tdb.getTrendsFromDb(category);
        }
        public async Task addtrendIntoDb(List<Trends> trendlist)
        {
            TrendsDb tdb = new TrendsDb();
            await tdb.addtrendIntoDb(trendlist);
        }
        public async Task getTrendsOfWeek(string date)
        {
            TrendsDb tdb = new TrendsDb();
            await tdb.getTrendsOfWeekDb(date);
        }

    }
}