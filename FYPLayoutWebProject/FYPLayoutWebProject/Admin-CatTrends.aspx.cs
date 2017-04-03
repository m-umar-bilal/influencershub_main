using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TextClassification;
using TextPreProcessing.BLL.TextClassification;
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
                    // CatList.DataSource= Category.categorylist;
                    // CatList.DataBind();
                    if (!IsPostBack)
                    {
                        TrendView.DataSource = Trends.GetTrendsOfCurrentWeekThatAreClassified();
                        TrendView.DataBind();
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
        public void getTrends()
        {
            Trends trend = new Trends();
            //   TrendView.DataSource = trend.getTrendList(CatList.SelectedItem.ToString());

        }



        // Label1.Text = ((DropDownList)TrendView.Rows[1].FindControl("CatList")).SelectedItem.Text;


        protected void CatList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList dropDownList = (DropDownList)sender;
            GridViewRow gridViewRow = (GridViewRow)dropDownList.Parent.Parent;

            string trend = Convert.ToString(dropDownList.Attributes["trend"]);
            string timestamp = Convert.ToString(dropDownList.Attributes["timestamp"]);
            Trends.ChangeCategoryOfTrend(trend, dropDownList.SelectedItem.Text, timestamp);
            Label1.Text = "CHANGED " + trend + "'s category to " + dropDownList.SelectedItem.Text;
            TrendView.DataSource = Trends.GetTrendsOfCurrentWeekThatAreClassified();
            TrendView.DataBind();
            // Label1.Text = "<b>Name:</b> " + name + " <b>Country:</b> " + country;
        }
    }
}