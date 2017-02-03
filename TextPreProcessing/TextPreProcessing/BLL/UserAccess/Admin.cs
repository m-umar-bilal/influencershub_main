using DAL;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UserAccess;

namespace UserAccess 
{
    public class Admin
    {
        private static string passSalt = "f92e00585e67bbe5ef0b98faf5392c36";
        public ObjectId id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

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

        public bool addAdmin(string fName, string lName, string email, string password)
        {
            password = TextPreProcessing.StringCipher.Encrypt(password,PassSalt);
            Admin newAdmin = new Admin { FirstName = fName, LastName = lName, Email = email, Password = password };

            bool u = false;
            Task.Run(async () =>
            {
                try
                {
                    // Start the task.
                    AdminDB adb = new AdminDB();
                    u = await adb.addAdminIntoDBNew(newAdmin);

                    // Await the task.

                }
                catch (Exception eee)
                {
                    //Console.WriteLine(e.Message);
                    // Perform cleanup here.
                }

            }).Wait();
            return u;


        }


      
    
       

        
    }
}