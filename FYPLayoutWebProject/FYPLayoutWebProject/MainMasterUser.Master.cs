using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Views
{
    public partial class MainMasterUser : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void logout(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("/SignIn.aspx",false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}