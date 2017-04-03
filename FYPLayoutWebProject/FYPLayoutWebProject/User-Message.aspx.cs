using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TextPreProcessing.BLL.TwitterAccess;
using UserAccess;

namespace FYPLayoutWebProject
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void BtnSend_Click(object sender, EventArgs e)
        {
          

            try
            {
                
                Message m = new Message();

                var text = "@"+Session["TempScrnName"]+ " " + txtMessage.Value;
                await m.PostNewTweet(Session["Token"].ToString(), Session["TokenSecret"].ToString(), text);

                string script = "alert('Message sent successfully');";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
            }
            catch(Exception ex)
            {
                string script = "alert('Internet not available');";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
            }
        }
    }
}