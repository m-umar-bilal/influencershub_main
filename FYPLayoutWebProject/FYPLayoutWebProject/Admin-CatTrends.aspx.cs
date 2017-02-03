using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TextClassification;
using TweetsAndTrends;

namespace Views
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Type"].Equals("Admin"))
                {
                    TrendView.DataSource = Category.categorylist;
                    TrendView.DataBind();
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
         //   TrendView.DataSource = trend.getTrendList(CatList.SelectedItem.ToString());

        }

        protected void CatList_SelectedIndexChanged(object sender, EventArgs e)
        {
            getTrends();
        }

        
    }
}