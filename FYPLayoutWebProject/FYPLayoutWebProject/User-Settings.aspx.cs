using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYPLayoutWebProject
{
    public partial class User_Settings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Type"].Equals("User"))
                {


                    if (!Page.IsPostBack)
                    {
                        Cat_List.DataSource = TextClassification.Category.categorylist;
                        Cat_List.DataBind();
                    }
                }
                else
                {
                    Response.Redirect("/SignIn.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ee)
            {
                Response.Redirect("/SignIn.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }
        protected async void btn_Select_Click(object sender, EventArgs e)
        {
            UserAccess.User user = new UserAccess.User();
            await user.AddCategory(Session["Email"].ToString(), Cat_List.SelectedValue.ToString());
            Session["Category"] = Cat_List.SelectedValue.ToString();
            Message.Text = "Category Changed to " + Cat_List.SelectedValue.ToString();
        }
    }

}