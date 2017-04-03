using DAL;
using DBHandler;
using LinqToTwitter;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAccess;
using TwitterHandler;

namespace TweetsAndTrends
{
    public class Tweets
    {
        public ObjectId id { get; set; }
        public string Text { get; set; }
        public string UserName { get; set; }

        public string Trend { get; set; }

        public DateTime DateTime { get; set; }



        public Tweets()
        {

        }
        public Tweets(String text, String username, String trend, DateTime datetime)
        {
            this.Text = text;
            this.UserName = username;
            this.Trend = trend;
            this.DateTime = datetime;


        }
        public async Task GetTweetsOfTrendFromTwitter(String trend)
        {


            SingleUserAuthorizer authorizer = TwitterDeveloper.authorizeTwitter();
            var twitterContext = new TwitterContext(authorizer);

            List<Tweets> tweetList = new List<Tweets>();

            var searchResponse =
                await
                (from search in twitterContext.Search
                 where search.Type == SearchType.Search && search.GeoCode == "30.441851,69.359703,1500mi" &&
                       search.Query == trend
                 select search)
                .SingleOrDefaultAsync();

            if (searchResponse != null && searchResponse.Statuses != null)
                searchResponse.Statuses.ForEach(tweet => tweetList.Add(new Tweets(tweet.Text, Convert.ToString(tweet.User.ScreenNameResponse), trend, tweet.CreatedAt)));

            await addtweetsIntoDb(tweetList);

        }

        public async Task addtweetsIntoDb(List<Tweets> tweetlist, string var)
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

        public List<String> GetTweetsOfTrendsFromDB(String Trend)
        {

            var Client = new MongoClient();
            var db = Client.GetDatabase("InfluencersHub");
            var Collec = db.GetCollection<BsonDocument>("trends_Tweets");
            var filter = Builders<BsonDocument>.Filter.Eq("Trend", Trend);

            try
            {
                var list = Collec.Find(filter).Project(Builders<BsonDocument>.Projection.Include("Tweet").Exclude("_id")).ToList();

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

        public async Task InsertCleanedTweet(string tweet, string trend, string collectionName)
        {

            string cleanedTweet = TextCleaner.cleanText(tweet);
            if (!String.IsNullOrWhiteSpace(tweet) && !String.IsNullOrWhiteSpace(trend) && !String.IsNullOrWhiteSpace(collectionName))
            {
                var collection = DBConnector.Database.GetCollection<BsonDocument>(collectionName);
                var keys = Builders<BsonDocument>.IndexKeys.Ascending("trend").Ascending("tweet");
                var options = new CreateIndexOptions();
                options.Unique = true;
                await collection.Indexes.CreateOneAsync(keys, options);
                var document = new BsonDocument
            {
                { "trend", trend },
                { "tweet", cleanedTweet }
            };

                await collection.InsertOneAsync(document);
            }
            else
            {
                throw new System.ArgumentException("Parameters cannot be null");
            }
        }

        public async Task InsertCleanedTweet(string tweet, string collectionName)
        {

            string cleanedTweet = TextCleaner.cleanText(tweet);
            if (!String.IsNullOrWhiteSpace(tweet) && !String.IsNullOrWhiteSpace(collectionName))
            {
                var collection = DBConnector.Database.GetCollection<BsonDocument>(collectionName);
                var keys = Builders<BsonDocument>.IndexKeys.Ascending("tweet");
                var options = new CreateIndexOptions();
                options.Unique = true;
                await collection.Indexes.CreateOneAsync(keys, options);
                var document = new BsonDocument
            {

                { "tweet", cleanedTweet }
            };

                await collection.InsertOneAsync(document);
            }
            else
            {
                throw new System.ArgumentException("Parameters cannot be null");
            }
        }

        public async Task StoreCleanedTweetsOfCategory(string collectionName, string category, string newCollecion)
        {
            try
            {
                var collection = DBConnector.Database.GetCollection<BsonDocument>(collectionName);
                var projection = Builders<BsonDocument>.Projection.Include("tweet").Exclude("_id");
                var builder = Builders<BsonDocument>.Filter;
                var filter = builder.Eq("trend_category", category);
                var options = new FindOptions<BsonDocument> { Projection = projection };

                using (var cursor = await collection.FindAsync(filter, options))
                {

                    while (await cursor.MoveNextAsync())
                    {
                        var batch = cursor.Current;
                        foreach (var document in batch)
                        {
                            // Console.WriteLine(document[0]);
                            try
                            {
                                // Start the task.
                                await InsertCleanedTweet(TextCleaner.cleanText(document[0].ToString()), newCollecion);

                                // Await the task.

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                continue;
                                // Perform cleanup here.
                            }



                        }
                    }
                }
                Console.WriteLine("DataInserted");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                // Perform cleanup here.
            }
        }
        public async Task addtweetsIntoDb(List<Tweets> tweetlist)
        {
            TweetsDb tb = new TweetsDb();
            await tb.addtweetsIntoDb(tweetlist);
        }

        public async Task<List<String>> getTweetsOfTrends(String Trend)
        {
            TweetsDb tb = new TweetsDb();
            return await tb.getTweetsOfTrendsFromDB(Trend);
        }

        public async Task<Dictionary<String, String>> getTweetsOfTrendsToDisplay(String Trend)
        {
            TweetsDb tb = new TweetsDb();
            return await tb.getTweetsOfTrendsToDisplayFromDb(Trend);
        }


        public async Task StoreCleanedTweetsOfCategory(string collectionName, string newCollecion)
        {
            try
            {
                var collection = DBConnector.Database.GetCollection<BsonDocument>(collectionName);
                var projection = Builders<BsonDocument>.Projection.Include("tweet").Exclude("_id");
                var filter = new BsonDocument();
                var options = new FindOptions<BsonDocument> { Projection = projection };

                using (var cursor = await collection.FindAsync(filter, options))
                {

                    while (await cursor.MoveNextAsync())
                    {
                        var batch = cursor.Current;
                        foreach (var document in batch)
                        {
                            // Console.WriteLine(document[0]);
                            try
                            {
                                // Start the task.
                                await InsertCleanedTweet(TextCleaner.cleanText(document[0].ToString()), newCollecion);

                                // Await the task.

                            }
                            catch (Exception)
                            {
                                // Console.WriteLine(e.Message);
                                continue;
                                // Perform cleanup here.
                            }



                        }
                    }
                }
                Console.WriteLine("DataInserted");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                // Perform cleanup here.
            }
        }
    }
}
