using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPLayoutWebProject;
using TextClassification;
using TextPreProcessing;
using UserAccess;

namespace Views
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        protected string tcount { get; set; }
        protected string tfavourite { get; set; }
        protected string ttotalfavourite { get; set; }
        protected string tfriends { get; set; }
        protected string tstatuses { get; set; }
        protected string tfollowers { get; set; }
        protected string tretweets { get; set; }
        protected string ttime { get; set; }

        public int SchedTime { get; set; } = Settings1.Default.Time;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Type"].Equals("Admin"))
                {
                    //var a=((bs_binary_admin_MainMaster)this.Master).SchedTime;
                    StreamReader reader = new StreamReader(@"C:\Users\Umar Bilal\Documents\fyp-2\TextPreProcessing\TextPreProcessing\Settings.txt");
                    string x = reader.ReadLine();
                    this.tcount = x;
                    x = reader.ReadLine();
                    this.tfavourite = x;
                    x = reader.ReadLine();
                    this.ttotalfavourite = x;
                    x = reader.ReadLine();
                    this.tfriends = x;
                    x = reader.ReadLine();
                    this.tstatuses = x;
                    x = reader.ReadLine();
                    this.tfollowers = x;
                    x = reader.ReadLine();
                    this.tretweets = x;
                    x = reader.ReadLine();
                    this.ttime = x;
                    //Button2.Attributes.Add("onclick", "window.open('ChangeTime.aspx','','height=300,width=300');return false");

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

        protected void Button3_Click(object sender, EventArgs e)
        {
            string a = String.Format("{0}", Request.Form["onee"]);
            string r = String.Format("{0}", Request.Form["22"]);
            string f = String.Format("{0}", Request.Form["33"]);
            string aa = String.Format("{0}", Request.Form["44"]);
            string t = String.Format("{0}", Request.Form["55"]);
            string y = String.Format("{0}", Request.Form["66"]);
            string u = String.Format("{0}", Request.Form["77"]);
            string ii = String.Format("{0}", Request.Form["88"]);
            if (Convert.ToInt32(a) + Convert.ToInt32(r) + Convert.ToInt32(f) + Convert.ToInt32(aa) + Convert.ToInt32(t) +
                Convert.ToInt32(y) + Convert.ToInt32(u) != 100)
            {
                Response.Write("sum should be 100");
            }
            else
            {


                Response.Write(a);
                Response.Write(a);
                Response.Write(a);
                Response.Write(a);
                Response.Write(a);
                StreamWriter writer =
                    new StreamWriter(
                        @"C:\Users\Umar Bilal\Documents\fyp-2\TextPreProcessing\TextPreProcessing\Settings.txt", false);
                writer.WriteLine(a);
                writer.WriteLine(r);
                writer.WriteLine(f);
                writer.WriteLine(aa);
                writer.WriteLine(t);
                writer.WriteLine(y);
                writer.WriteLine(u);
                writer.WriteLine(ii);
                writer.Close();

            }
        }

        protected void UpdateInfluencer(object sender, EventArgs e)
        {
            Influencer inf = new Influencer();
            inf.FillInfluencers();
            Influencer i = new Influencer();
            i.UpdateAllInfluencersScore();
        }
    }
}