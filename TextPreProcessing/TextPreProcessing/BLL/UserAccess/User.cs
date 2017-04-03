using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MongoDB.Driver.Linq;
using System.Threading.Tasks;
using UserAccess;
using DAL;

namespace UserAccess 
{
    public class User
    {
        private static string passSalt = "baf7c501931fe43e6f01f56d882c8aef";
        public ObjectId id { get; set; }
       public  string FirstName { get; set; }
       public  string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

       public String EmailConfirm { get; set; }

        public String Category { get; set; }

        public String OauthToken { get; set; }
        public String OauthTokenSecret { get; set; }

        public String Image { get; set; }
        public static string PassSalt
        {
            get
            {
                return passSalt;
            }

            set
            {
                passSalt = value;
            }
        }

        public User addUser(string fName, string lName, string email, string password)
        {
            password = UserAccess.StringCipher.Encrypt(password, PassSalt);
            User newUser = new User { FirstName = fName, LastName = lName, Email = email, Password = password , Category="false", OauthToken = "false" , OauthTokenSecret ="false" };
            

            bool u = false;
            Task.Run(async () =>
            {
                try
                {
                    // Start the task.
                    UserDb ub = new UserDb();
                    u = await ub.addUserIntoDBNew(newUser);

                    // Await the task.

                }
                catch (Exception eee)
                {
                    //Console.WriteLine(e.Message);
                    // Perform cleanup here.
                }

            }).Wait();
            return newUser;

            
        }

      

        public static String generateEmailCode()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[6];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new String(stringChars);
        }


        public async Task<List<String>> getAllUsersFromDb()
        {
            UserDb ub = new UserDb();
            return await ub.getAllUsersFromDb();
        }

        public async Task<bool> ConfirmEmail(String Email, String Code)
        {
            UserDb ub = new UserDb();
            return await ub.ConfirmEmailDB(Email,Code);
        }

        public async Task AddTwitterAccount(String Email, String oauthToken, String oauthTokenSecret, String ImageUrl)
        {
            UserDb ub = new UserDb();
            await ub.AddTwitterAccountToDB(Email, oauthToken, oauthTokenSecret,ImageUrl);
        }

        public async Task AddCategory(String Email, String Category)
        {
            UserDb ub = new UserDb();
            await ub.AddCategoryTODb(Email, Category);
        }

        }
}


