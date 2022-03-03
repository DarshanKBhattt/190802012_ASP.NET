using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Literal1.Text = Session["UsrName"].ToString();
    }
    protected void LinkButton1(object sender, EventArgs e)
    {
        Session["UsrName"] = null;
        Response.Redirect("~/Login.aspx");
        Literal1.Text = "";
    }
}
