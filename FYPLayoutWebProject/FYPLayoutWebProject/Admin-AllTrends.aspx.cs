using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TweetsAndTrends;

namespace Views
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        public async Task LoadSomeData()
        {
            var getListTask = await DAL.TrendsDb.GetAllTrends();

            TrendView.DataSource = getListTask;
            TrendView.DataBind();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Type"].Equals("Admin"))
                {
                    // getTrends();
                    RegisterAsyncTask(new PageAsyncTask(LoadSomeData));
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

        public void getTrends()
        {
            Trends trend = new Trends();
            TrendView.DataSource = trend.getTrendList("");

        }
    }
}