using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextPreProcessing.BLL.UserAccess
{
    class CommunicatedInfluencer
    {
        public String UserName;
        public String InfluencerName;
        public String Message;

        public async void SaveInfluencerIntoDB(String userName, String influencerName , String Message)
        {

            var Client = new MongoClient();
            var db = Client.GetDatabase("InfluencersHub");
            var Collec = db.GetCollection<BsonDocument>("CommunicatedInfluencer");
            var document = new BsonDocument
            {
                {"UserName",userName},
                {"InfluencerName",InfluencerName},
                 {"Message",Message},


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

        public static List<CommunicatedInfluencer> GetInfluencersOfUser(string UserName)
        {
            var Client = new MongoClient();
            var db = Client.GetDatabase("InfluencersHub");

            var Collec = db.GetCollection<BsonDocument>("CommunicatedInfluencer");
            var filter = Builders<BsonDocument>.Filter.Eq("UserName", UserName);
            List<BsonDocument> inf = new List<BsonDocument>();
           
                inf = Collec.Find(filter).ToList();
           
            List<CommunicatedInfluencer> infList = new List<CommunicatedInfluencer>();

            foreach (var document in inf)
            {
                try
                {
                    CommunicatedInfluencer tempInf = new CommunicatedInfluencer();
                    tempInf.UserName = Convert.ToString(document["UserName"]);
                    tempInf.InfluencerName = Convert.ToString(document["InfluencerName"]);
                    tempInf.Message = Convert.ToString(document["Message"]);


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
