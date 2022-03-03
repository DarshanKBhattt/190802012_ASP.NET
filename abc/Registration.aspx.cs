using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Registration : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString1"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("INSERT INTO [users] ([name], [email], [password]) VALUES (@name, @email, @password)",con);
        cmd.Parameters.AddWithValue("@Name", TextBox1.Text);
        cmd.Parameters.AddWithValue("@email" , TextBox2.Text);
        cmd.Parameters.AddWithValue("@password" ,TextBox3.Text );

        con.Open();
        int s = cmd.ExecuteNonQuery();
        if (s == 1)
        {

            Response.Redirect("~/Login.aspx");
        }
        else
        {
            Response.Redirect("~/Registration.aspx");
        }
        con.Close();
    }
}