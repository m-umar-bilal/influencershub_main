using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace UserAccess 
{
    public class Email
    {
        public bool sendEMail(String Email,String Subject,String Message)
        {
            String FromEmailID = ConfigurationManager.AppSettings["EMailId"];
            String Password = ConfigurationManager.AppSettings["Password"];

            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(Email);
            mailMessage.From = new MailAddress(FromEmailID);
            mailMessage.Subject = Subject;
            mailMessage.Body = Message;
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
    }
}