using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TweetsAndTrends;
using TextClassification;
using System.Threading.Tasks;

namespace Views
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        public async Task LoadSomeData()
        {
            var getListTask = await DAL.TrendsDb.GetAllTrends();
            
            TweetView.DataSource = getListTask;
            TweetView.DataBind();

        }
        public async Task LoadTweets()
        {
            var getListTask = await DAL.TrendsDb.GetAllTrends();

            TrendList.DataSource = getListTask;
            TrendList.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Type"].Equals("Admin"))
                {

                    //RegisterAsyncTask(new PageAsyncTask(LoadSomeData));
                }
                else
                {
                    Response.Redirect("/Admin.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ee)
            {
                Response.Redirect("/Admin.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
           
        }
        public void getTweets()
        {
            Tweets tweet = new TweetsAndTrends.Tweets();
            TweetView.DataSource = tweet.getTweetsOfTrendsToDisplay(TrendList.SelectedItem.ToString());

        }

        protected void TrendList_SelectedIndexChanged(object sender, EventArgs e)
        {
            getTweets();
        }

       public void getTrendsList()
        {
            Trends tre = new Trends();
            var tem =tre.getTrendList("");
            List<String> list = new List<string>(tem.Keys);
            TrendList.DataSource = list;
            TrendList.DataBind();   
        }
    }
}