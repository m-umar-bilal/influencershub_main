using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TextClassification;
namespace Views
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Type"].Equals("Admin"))
                {
                    DropDownList1.Items.Add("5");
                    DropDownList1.Items.Add("10");
                    DropDownList1.Items.Add("15");
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
            ProcessStartInfo startinfo = new ProcessStartInfo();
            startinfo.FileName = @"C:\\Users\\Umar Bilal\\Documents\\fyp-2\\TextPreProcessing\\TextPreProcessing\\bin\\Debug\\TextPreProcessing.exe";
            startinfo.CreateNoWindow = false;
            startinfo.UseShellExecute = false;
            Process myProcess = Process.Start(startinfo);
            myProcess.Start();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string time = DropDownList1.SelectedValue;
            TimeLabel.Text = time;
            double t = Convert.ToDouble(time);
            string output="";
            startApp();























        }
    }
}