using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPLayoutWebProject;
using TextClassification;
using TextPreProcessing;

namespace Views
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        public int SchedTime { get; set; } = Settings1.Default.Time;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Type"].Equals("Admin"))
                {
                    //var a=((bs_binary_admin_MainMaster)this.Master).SchedTime;
                    DropDownList1.Items.Add("5");
                    DropDownList1.Items.Add("10");
                    DropDownList1.Items.Add("15");
                    Button2.Attributes.Add("onclick", "window.open('ChangeTime.aspx','','height=300,width=300');return false");
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

        void startApp()
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {



        }

        /*  protected void Button2_Click(object sender, EventArgs e)
          {

          }*/
    }
}