using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TweetsAndTrends;
using TextClassification;
using System.Threading.Tasks;
using TextPreProcessing.BLL.TextClassification;

namespace Views
{
    public partial class WebForm8 : System.Web.UI.Page
    {

      
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
                    if (!IsPostBack)
                    {
                        TrendList.DataSource =
                            Trends.GetTrendsOfCurrentWeekThatAreClassified().Select(x => x.trend).ToArray();
                        TrendList.DataBind();

                        GetTweets();
                    }

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
        public void GetTweets()
        {
            Tweets tweet = new TweetsAndTrends.Tweets();
            TweetView.DataSource = tweet.GetTweetsOfTrendsFromDB(TrendList.SelectedItem.ToString());
            TweetView.DataBind();
        }

        protected void TrendList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetTweets();
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