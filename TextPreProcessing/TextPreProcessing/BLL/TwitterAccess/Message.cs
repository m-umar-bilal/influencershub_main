using LinqToTwitter;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterHandler;

namespace TextPreProcessing.BLL.TwitterAccess
{
    public class Message
    {
        public async Task NewDirectMessageAsync(string screenName, string text)
        {
            SingleUserAuthorizer authorizer = TwitterDeveloper.authorizeTwitter();
            var twitterContext = new TwitterContext(authorizer);
            var message = await twitterContext.NewDirectMessageAsync(screenName, text);
        }

        public async Task PostNewTweet(string token, string secret,string status)
        {

            var auth = TwitterDeveloper.authorizeTwitter();
        
            var twitterContext = new TwitterContext(auth);
        
            var tweet = await twitterContext.TweetAsync(status);
        }
    }
}
