using DAL ;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UserAccess;
namespace DAL 
{
    public class LoginDb
    {
        public async Task<User> getLogin(String email, String password)
        {
            var Client = new MongoClient();
            var db = Client.GetDatabase("InfluencersHub");
            var Collec = db.GetCollection<BsonDocument>("User");
            var filter = Builders<BsonDocument>.Filter.Eq("Email", email) ;
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
                           
                            if (password.Equals(UserAccess.StringCipher.Decrypt(document["Password"].ToString(), User.PassSalt)))
                            {
                                User user = new User();
                                user.FirstName = document["FirstName"].ToString();
                                user.LastName = document["LastName"].ToString();
                                user.Email = document["Email"].ToString();
                                // user.Password = document["Password"].ToString();
                                user.EmailConfirm = (document["EmailConfirm"].ToString());
                                user.Category = (document["Category"].ToString());
                                user.OauthToken = (document["OauthToken"].ToString());
                                user.OauthTokenSecret = (document["OauthTokenSecret"].ToString());
                                user.Image = (document["Image"].ToString());
                                return user;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }
            return null;
        }

        public async Task<Admin> getLoginAdmin(String email, String password)
        {
            var Client = new MongoClient();
            var db = Client.GetDatabase("InfluencersHub");
            var Collec = db.GetCollection<BsonDocument>("Admin");
            var filter = Builders<BsonDocument>.Filter.Eq("Email", email) ;
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
                            if (password.Equals(UserAccess.StringCipher.Decrypt(document["Password"].ToString(), Admin.PassSalt)))
                            {
                                Admin user = new Admin();
                                user.FirstName = document["FirstName"].ToString();
                                user.LastName = document["LastName"].ToString();
                                user.Email = document["Email"].ToString();
                               // user.Password = document["Password"].ToString();
                                return user;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }
            return null;
        }

        public async Task<bool> ForgottenPassword(String email)
        {
            var Client = new MongoClient();
            var db = Client.GetDatabase("InfluencersHub");
            var Collec = db.GetCollection<BsonDocument>("User");
            var filter = Builders<BsonDocument>.Filter.Eq("Email", email);
            User user = new User();
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

                            user.FirstName = document["FirstName"].ToString();
                            user.LastName = document["LastName"].ToString();
                            user.Email = document["Email"].ToString();
                            user.Password = UserAccess.StringCipher.Decrypt(document["Password"].ToString(), User.PassSalt);
                            {
                                // Send Email to User 

                                Email emailclass = new Email();
                                String Message = "Your Password is " + user.Password + " By Influencers Hub!";
                                String Subject = "iHub Password";
                                if (emailclass.sendEMail(email, Subject, Message))
                                {
                                    return true;
                                }

                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return false;

        }

       

        public async Task<bool> ConfirmUserMail(User user)
        {



            var Client = new MongoClient();
            var db = Client.GetDatabase("InfluencersHub");
            var Collec = db.GetCollection<BsonDocument>("User");
            var filter = Builders<BsonDocument>.Filter.Eq("id", user.id);
            var update = Builders<BsonDocument>.Update.Set("EmailConfirm", "true");
            try
            {
                var result = await Collec.UpdateOneAsync(filter, update);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }


        }

    }
}