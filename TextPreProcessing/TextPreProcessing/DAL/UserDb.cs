using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAccess;
using System.Web;
using System.Configuration;

namespace DAL 
{
    public class UserDb
    {
        public async Task<bool> addUserIntoDBNew(User user)
        {
            var Client = new MongoClient();
            var db = Client.GetDatabase("InfluencersHub");
            var Collec = db.GetCollection<BsonDocument>("User");
            var keys = Builders<BsonDocument>.IndexKeys.Ascending("Email");
            var options = new CreateIndexOptions();
            options.Unique = true;
            await Collec.Indexes.CreateOneAsync(keys, options);

            user.EmailConfirm = User.generateEmailCode();

            var document = new BsonDocument
            {
                {"FirstName",user.FirstName},
                {"LastName",user.LastName},
                {"Email",user.Email},
                {"Password",user.Password},
                { "EmailConfirm",user.EmailConfirm},
                { "Category","false"},
                { "OauthToken" ,"false" },
                { "OauthTokenSecret" , "false"},
                { "Image", "false"}




            };
            try
            {

                await Collec.InsertOneAsync(document);

                Email email = new Email();
                String message = ConfigurationManager.AppSettings["Message"] + " " + user.EmailConfirm;
                email.sendEMail(user.Email, ConfigurationManager.AppSettings["Subject"],message);
                return true;
            }
            catch
            {
                return false;
            }



        }

        public async Task ConfirmEmailToDb(String Email)
        {
            var Client = new MongoClient();
            var db = Client.GetDatabase("InfluencersHub");
            var Collec = db.GetCollection<BsonDocument>("User");
            var filter = Builders<BsonDocument>.Filter.Eq("Email", Email);
            var update = Builders<BsonDocument>.Update.Set("EmailConfirm", "true");
            var result = await Collec.UpdateOneAsync(filter, update);

        }

        public async Task AddTwitterAccountToDB(String Email,String oauthToken,String oauthTokenSecret,String ImageUrl)
        {
            var Client = new MongoClient();
            var db = Client.GetDatabase("InfluencersHub");
            var Collec = db.GetCollection<BsonDocument>("User");
            var filter = Builders<BsonDocument>.Filter.Eq("Email", Email);
            var update = Builders<BsonDocument>.Update.Set("OauthToken",oauthToken).Set("OauthTokenSecret", oauthTokenSecret).Set("ImageUrl",ImageUrl);
            var result = await Collec.UpdateOneAsync(filter, update);

        }

        public async Task AddCategoryTODb(String Email, String Category)
        {
            var Client = new MongoClient();
            var db = Client.GetDatabase("InfluencersHub");
            var Collec = db.GetCollection<BsonDocument>("User");
            var filter = Builders<BsonDocument>.Filter.Eq("Email", Email);
            var update = Builders<BsonDocument>.Update.Set("Category", Category);
            var result = await Collec.UpdateOneAsync(filter, update);

        }

        public async Task<List<String>> getAllUsersFromDb()
        {

            var Client = new MongoClient();
            var db = Client.GetDatabase("InfluencersHub");
            var Collec = db.GetCollection<BsonDocument>("User");


            try
            {
                var list = await Collec.Find(new BsonDocument()).ToListAsync();

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

        public async Task<bool> ConfirmEmailDB(String Email, String Code)
        {
            var Client = new MongoClient();
            var db = Client.GetDatabase("InfluencersHub");
            var Collec = db.GetCollection<BsonDocument>("User");
            var filter = Builders<BsonDocument>.Filter.Eq("Email", Email);

            try
            {
                var list = await Collec.Find(filter).Project(Builders<BsonDocument>.Projection.Include("EmailConfirm").Exclude("_id")).ToListAsync();

                String code = null;

                foreach (var document in list)
                {
                    code = Convert.ToString(document[0]);
                }


                if (code.Equals(Code))
                {
                    Task.Run(async () =>
                    {
                        await ConfirmEmailToDb(Email);
                    }).Wait();
                    return true;
                }
                else
                {

                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}