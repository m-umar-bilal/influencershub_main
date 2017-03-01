using DAL;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using UserAccess;


namespace UserAccess 
{
    public class Login
    {
      

        public async Task<bool> ConfirmUserMail(User user)
        {
            LoginDb ldb = new LoginDb();
           return await ldb.ConfirmUserMail(user);
        }

        public static async Task<bool> ForgottenPassword(String email)
        {
            LoginDb ldb = new LoginDb();
            return await ldb.ForgottenPassword(email);
        }

        public async Task<Admin> getLoginAdmin(String email, String password)
        {
          
            LoginDb ldb = new LoginDb();
            return await ldb.getLoginAdmin(email, password);
        }
        public async Task<User> getLogin(String email, String password)
        {

            LoginDb ldb = new LoginDb();
            return await ldb.getLogin(email, password);
        }
        }

}