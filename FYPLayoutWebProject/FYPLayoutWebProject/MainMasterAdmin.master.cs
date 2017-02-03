using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class bs_binary_admin_MainMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void logout(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("/Admin.aspx", false);
        Context.ApplicationInstance.CompleteRequest();
    }
}
