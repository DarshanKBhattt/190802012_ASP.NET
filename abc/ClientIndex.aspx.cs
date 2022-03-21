using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{

    //ConnectionString="<%$ ConnectionStrings:DatabaseConnectionString1 %>" 
    //DeleteCommand="DELETE FROM [hotels] WHERE [ch_id] = @ch_id" 
    //InsertCommand="INSERT INTO [hotels] ([h_id], [h_name], [checkin_date], [checkout_date], [g_num]) VALUES (@h_id, @h_name, @checkin_date, @checkout_date, @g_num)" 
    //ProviderName="<%$ ConnectionStrings:DatabaseConnectionString1.ProviderName %>" 
    //SelectCommand="SELECT [ch_id], [h_id], [h_name], [checkin_date], [checkout_date], [g_num] FROM [hotels]" 
    //UpdateCommand="UPDATE [hotels] SET [h_id] = @h_id, [h_name] = @h_name, [checkin_date] = @checkin_date, [checkout_date] = @checkout_date, [g_num] = @g_num WHERE [ch_id] = @ch_id">


    //ConnectionString="<%$ ConnectionStrings:DatabaseConnectionString1 %>" 
    //DeleteCommand="DELETE FROM [ccars] WHERE [cc_id] = @cc_id" 
    //InsertCommand="INSERT INTO [ccars] ([c_id], [c_name], [pickup_date], [return_date], [options]) VALUES (@c_id, @c_name, @pickup_date, @return_date, @options)" 
    //ProviderName="<%$ ConnectionStrings:DatabaseConnectionString1.ProviderName %>" 
    //SelectCommand="SELECT [cc_id], [c_id], [c_name], [pickup_date], [return_date], [options] FROM [ccars]" 
    //UpdateCommand="UPDATE [ccars] SET [c_id] = @c_id, [c_name] = @c_name, [pickup_date] = @pickup_date, [return_date] = @return_date, [options] = @options WHERE [cc_id] = @cc_id">



    SqlConnection con;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Calendar1.Visible = false;
        }
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString1"].ConnectionString);
        DropDownBind();
    }
    protected void  Button1_Click(object sender, EventArgs e)
    {
            SqlCommand s = new SqlCommand("INSERT INTO [hotels] ([h_id], [h_name], [checkin_date], [checkout_date], [g_num]) VALUES (@h_id, @h_name, @checkin_date, @checkout_date, @g_num)", con);
            s.Parameters.AddWithValue("@hname", DropDownList1.SelectedValue.ToString());
            s.Parameters.AddWithValue("@checkin_date", DropDownList1.SelectedValue.ToString());
            con.Open();
            if (s.ExecuteNonQuery() == 1)
            {
            }
            con.Close();
    }
    public void DropDownBind()
    {
        SqlDataAdapter adpt = new SqlDataAdapter("SELECT [ch_id], [h_id], [h_name], [checkin_date], [checkout_date], [g_num] FROM [hotels]", con);
        SqlDataAdapter adpt2 = new SqlDataAdapter("SELECT [cc_id], [c_id], [c_name], [pickup_date], [return_date], [options] FROM [ccars]", con);
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        adpt.Fill(dt);
        adpt.Fill(dt2);
        DropDownList1.DataTextField = "hnm";
        DropDownList1.DataValueField = "h_id";
        DropDownList1.DataSource = dt;

    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        TextBox1.Text = Calendar1.SelectedDate.ToString("dd/MM/yyyy");
        Calendar1.Visible = false;
    }
    //protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    //{
    //    TextBox2.Text = Calendar2.SelectedDate.ToString("dd/MM/yyyy");
    //}
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.IsOtherMonth)
        {
            e.Day.IsSelectable = false;
            e.Cell.BackColor = System.Drawing.Color.Beige;
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (Calendar1.Visible)
        {
            Calendar1.Visible = false;
        }
        else
        {
            Calendar1.Visible = true;
        }
        Calendar1.Attributes.Add("style", "position:absolute");
    }

}