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
        public bool sendConfirmationMail(String Email)
        {
            String FromEmailID = ConfigurationManager.AppSettings["EMailId"];
            String Password = ConfigurationManager.AppSettings["Password"];

            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(Email);
            mailMessage.From = new MailAddress(FromEmailID, "Email head", System.Text.Encoding.UTF8);
            mailMessage.Subject = ConfigurationManager.AppSettings["Subject"];
            mailMessage.Body = ConfigurationManager.AppSettings["Message"];
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
            mailMessage.IsBodyHtml = true;
            mailMessage.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(FromEmailID, Password);
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            try
            {
                client.Send(mailMessage);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

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