using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAccess;

namespace TextPreProcessing.BLL.UserAccess
{
    class SaveInfluencer
    {
        public String UserName;
        public String InfluencerName;

        public async void SaveInfluencerIntoDB(String userName, String influencerName)
        {
           
            var Client = new MongoClient();
            var db = Client.GetDatabase("InfluencersHub");
            var Collec = db.GetCollection<BsonDocument>("BookMarkInfluencers");
            var document = new BsonDocument
            {
                {"UserName",userName},
                {"InfluencerName",InfluencerName},


            };

            try
            {
                // For Indexing
                var keys = Builders<BsonDocument>.IndexKeys.Ascending("UserName").Ascending("InfluencerName");
                var Collectemp = db.GetCollection<BsonDocument>("BookMarkInfluencers");
                var options = new CreateIndexOptions();
                options.Unique = true;
                await Collectemp.Indexes.CreateOneAsync(keys, options);
               
            }
            catch (Exception e)
            {

            }

            try
            {
                Collec.InsertOne(document);
            }
            catch (Exception e)
            {
                return;
            }
        }

        public static List<SaveInfluencer> GetInfluencersOfUser(string UserName)
        {
            var Client = new MongoClient();
            var db = Client.GetDatabase("InfluencersHub");

            var Collec = db.GetCollection<BsonDocument>("BookMarkInfluencers");
            var filter = Builders<BsonDocument>.Filter.Eq("UserName", UserName);
            List<BsonDocument> inf = new List<BsonDocument>();

                inf = Collec.Find(filter).ToList();
            
            List<SaveInfluencer> infList = new List<SaveInfluencer>();

            foreach (var document in inf)
            {
                try
                {
                    SaveInfluencer tempInf = new SaveInfluencer();
                    tempInf.UserName = Convert.ToString(document["UserName"]);
                    tempInf.InfluencerName = Convert.ToString(document["InfluencerName"]);
                   
                   
                    infList.Add(tempInf);
                }
                catch (Exception e)
                {

                }
            }
            return infList;


        }
    }
}
