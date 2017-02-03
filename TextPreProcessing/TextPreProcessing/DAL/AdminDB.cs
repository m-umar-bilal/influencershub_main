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
using UserAccess;

namespace DAL 
{
    public class AdminDB
    {
        public async Task<bool> addAdminIntoDBNew(Admin Admin)
        {
            var Client = new MongoClient();
            var db = Client.GetDatabase("InfluencersHub");
            var Collec = db.GetCollection<BsonDocument>("Admin");
            var keys = Builders<BsonDocument>.IndexKeys.Ascending("Email");
            var options = new CreateIndexOptions();
            options.Unique = true;
            await Collec.Indexes.CreateOneAsync(keys, options);



            var document = new BsonDocument
            {
                {"FirstName",Admin.FirstName},
                {"LastName",Admin.LastName},
                {"Email",Admin.Email},
                {"Password",Admin.Password}

            };
            try
            {
                await Collec.InsertOneAsync(document);
                return true;
            }
            catch
            {
                return false;
            }



        }

    }
}