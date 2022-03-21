using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

//                                    ConnectionString="<%$ ConnectionStrings:DatabaseConnectionString1 %>" 
//                                    DeleteCommand="DELETE FROM [hotel] WHERE [h_id] = @h_id" 
//                                    InsertCommand="INSERT INTO [hotel] ([hnm]) VALUES (@hnm)" 
//                                    ProviderName="<%$ ConnectionStrings:DatabaseConnectionString1.ProviderName %>" 
//                                    SelectCommand="SELECT [h_id], [hnm] FROM [hotel]" 
//                                    UpdateCommand="UPDATE [hotel] SET [hnm] = @hnm WHERE [h_id] = @h_id"


public partial class _Default : System.Web.UI.Page
{
    SqlConnection c;
    protected void Page_Load(object sender, EventArgs e)
    {
        c = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString1"].ConnectionString);
        Print();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Button1.Text == "Update")
        {
            SqlCommand s = new SqlCommand("UPDATE [hotel] SET [hnm] = @hnm WHERE [h_id] = @h_id", c);
            s.Parameters.AddWithValue("@hnm", TextBox1.Text);
            s.Parameters.AddWithValue("@h_id", ViewState["id"]);
            c.Open();
            if (s.ExecuteNonQuery() == 1)
            {
                Literal1.Text = "Data Updated Successfully";
                Print();
            }
            else
            {
                Literal1.Text = "Error";
            }
            c.Close();
            Clear();
            Button1.Text = "Submit";
        }
        else
        {
            SqlCommand s = new SqlCommand("INSERT INTO [hotel] ([hnm]) VALUES (@hnm)", c);
            s.Parameters.AddWithValue("@hnm", TextBox1.Text);
            c.Open();
            if (s.ExecuteNonQuery() == 1)
            {
                Literal1.Text = "Data  Inserted Successfully";
                Print();
            }
            else
            {
                Literal1.Text = "Error";
            }
            c.Close();
            Clear();
        }
        Button1.Text = "Submit";
    }
    public void Clear()
    {
        TextBox1.Text = "";
    }
    public void Print()
    {
        SqlDataAdapter a = new SqlDataAdapter("SELECT * FROM [hotel]", c);
        DataTable dt = new DataTable();
        a.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Button b = (Button)sender;
        SqlCommand s = new SqlCommand("DELETE FROM [hotel] WHERE [h_id] = @h_id", c);
        s.Parameters.AddWithValue("@h_id", b.CommandArgument);
        c.Open();
        if (s.ExecuteNonQuery() == 1)
        {
            Literal1.Text = "Data Deleted Successfully";
            Print();
        }
        else
        {
            Literal1.Text = "Error";
        }
        c.Close();
        Clear();
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        Button b = (Button)sender;
        SqlDataAdapter a = new SqlDataAdapter("SELECT * FROM hotel WHERE [h_id] = " + b.CommandArgument, c);
        DataTable dt = new DataTable();
        a.Fill(dt);
        TextBox1.Text = dt.Rows[0][1].ToString();
        ViewState["id"] = b.CommandArgument;
        Button1.Text = "Update";
    }

}
