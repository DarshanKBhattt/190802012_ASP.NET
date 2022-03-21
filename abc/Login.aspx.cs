using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class Login : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString1"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
            //DeleteCommand="DELETE FROM [users] WHERE [id] = @id" 
            //InsertCommand="INSERT INTO [users] ([name], [email], [password]) VALUES (@name, @email, @password)" 
            //ProviderName="<%$ ConnectionStrings:DatabaseConnectionString1.ProviderName %>" 
            //SelectCommand="SELECT [id], [name], [email], [password] FROM [users]" 
            //UpdateCommand="UPDATE [users] SET [name] = @name, [email] = @email, [password] = @password WHERE [id] = @id">
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlDataAdapter adpt = new SqlDataAdapter("SELECT [name] FROM [users] WHERE [email] = '" + TextBox1.Text.Trim() + "' AND [password] = '" + TextBox2.Text.Trim() + "'", con);
        //SqlDataAdapter adpt = new SqlDataAdapter("SELECT * FROM [users] WHERE [email] = 'p'", con);
        DataTable dt = new DataTable();
        adpt.Fill(dt);

        if (dt.Rows.Count == 1)
        {
            Session["UsrName"] = TextBox1.Text;
            if (TextBox1.Text == "p" && TextBox2.Text == "7")
            {
                Response.Redirect("~/AdminIndex.aspx");
            }
            else
            Response.Redirect("~/ClientIndex.aspx");
        }

        //SqlCommand cmd = new SqlCommand("SELECT * FROM [users] WHERE [email] = @email AND [password] = @password", con);
        //cmd.Parameters.AddWithValue("@email", TextBox1.Text.Trim());
        //cmd.Parameters.AddWithValue("@password", TextBox2.Text.Trim());

        
        //con.Open();
        //int s = (int)cmd.();
        //if (s == 1)
        //{
               //SqlCommand cmd2 = new SqlCommand("SELECT [name] FROM [users] WHERE [email] = @email AND [password] = @password", con);
        //    Response.Redirect("~/Index.aspx");
        //}
        //else
        //{
        //    Response.Redirect("~/Login.aspx");
        //}
        //con.Close();
    }
}