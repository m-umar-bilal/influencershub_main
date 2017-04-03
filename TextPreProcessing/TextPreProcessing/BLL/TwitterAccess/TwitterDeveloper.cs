using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LinqToTwitter;
using System.Threading.Tasks;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace TwitterHandler
{
    public static class TwitterDeveloper
    {
        private static string passPhrase = "F740692E336C73C2DF878DE1022069B69B12CB6FF581D138969FCEEFADB028DA";

        public static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = MD5.Create();  //or use SHA1.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

        public static SingleUserAuthorizer authorizeTwitter()
        {
            SingleUserAuthorizer authorizer =
                new SingleUserAuthorizer
                {
                    CredentialStore =
                        new SingleUserInMemoryCredentialStore
                        {
                            ConsumerKey =
                                UserAccess.StringCipher.Decrypt(
                                    System.Configuration.ConfigurationManager.AppSettings["ConsumerKey"], passPhrase),
                            ConsumerSecret =
                                UserAccess.StringCipher.Decrypt(
                                    System.Configuration.ConfigurationManager.AppSettings["ConsumerSecret"], passPhrase),
                            AccessToken =
                                UserAccess.StringCipher.Decrypt(
                                    System.Configuration.ConfigurationManager.AppSettings["AccessToken"], passPhrase),
                            AccessTokenSecret =
                                UserAccess.StringCipher.Decrypt(
                                    System.Configuration.ConfigurationManager.AppSettings["AccessTokenSecret"],
                                    passPhrase)
                        }
                };
            return authorizer;
        }

        public static SingleUserAuthorizer authorizeTwitter(string accessToken, string secret)
        {
            SingleUserAuthorizer authorizer =
                new SingleUserAuthorizer
                {
                    CredentialStore =
                        new SingleUserInMemoryCredentialStore
                        {
                            ConsumerKey =
                                UserAccess.StringCipher.Decrypt(
                                    System.Configuration.ConfigurationManager.AppSettings["ConsumerKey"], passPhrase),
                            ConsumerSecret =
                                UserAccess.StringCipher.Decrypt(
                                    System.Configuration.ConfigurationManager.AppSettings["ConsumerSecret"], passPhrase),
                            AccessToken = accessToken,
                            
                            AccessTokenSecret = secret
                              
                        }
                };
            return authorizer;
        }


        public static AspNetAuthorizer authorizeTwitterForCustomer(HttpResponse res)
        {
            AspNetAuthorizer auth;
            auth = new AspNetAuthorizer
            {
                CredentialStore = new SessionStateCredentialStore
                {
                    ConsumerKey = UserAccess.StringCipher.Decrypt(System.Configuration.ConfigurationManager.AppSettings["ConsumerKey"], passPhrase),
                    ConsumerSecret = UserAccess.StringCipher.Decrypt(System.Configuration.ConfigurationManager.AppSettings["ConsumerSecret"], passPhrase)

                },
                GoToTwitterAuthorization =
                    twitterUrl => res.Redirect(twitterUrl, false)

            };
            return auth;

        }
    }
 }