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
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString1"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        print();
                                   //DeleteCommand="DELETE FROM [category] WHERE [id] = @id" 
                                   // InsertCommand="INSERT INTO [category] ([category_name], [category_status]) VALUES (@category_name, @category_status)" 
                                   // ProviderName="<%$ ConnectionStrings:DatabaseConnectionString1.ProviderName %>" 
                                   // SelectCommand="SELECT [id], [category_name], [category_status] FROM [category]" 
                                   // UpdateCommand="UPDATE [category] SET [category_name] = @category_name, [category_status] = @category_status WHERE [id] = @id">
                                    
    }
    public void print()
    {

        SqlDataAdapter adpt = new SqlDataAdapter("SELECT [id], [category_name], [category_status] FROM [category]", con);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Button1.Text == "Insert")
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO [category] ([category_name], [category_status]) VALUES (@category_name, @category_status)", con);
            cmd.Parameters.AddWithValue("@category_name", TextBox1.Text);
            cmd.Parameters.AddWithValue("@category_status", RadioButtonList1.SelectedValue);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                Literal5.Text = "Record is inserted";
            }
            else
            {
                Literal5.Text = "Record is not inserted";
            }
            TextBox1.Text = "";
            RadioButtonList1.ClearSelection();
        }
        if (Button1.Text == "Update")
        {
            SqlCommand cmd = new SqlCommand("UPDATE [category] SET [category_name] = @category_name, [category_status] = @category_status WHERE [id] = @id", con);
            cmd.Parameters.AddWithValue("@category_name", TextBox1.Text);

            cmd.Parameters.AddWithValue("@category_status", RadioButtonList1.SelectedValue);
            cmd.Parameters.AddWithValue("@id", ViewState["id"]);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                Literal5.Text = "Record is Updated";
                Button1.Text = "Insert";
            }
            else
            {
                Literal5.Text = "Record is not Updated";
                Button1.Text = "Insert";
            }
           
            TextBox1.Text = "";
            RadioButtonList1.ClearSelection();
        }
        print();
        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        //edit
        Button btn = (Button)sender;
        SqlDataAdapter adpt = new SqlDataAdapter("SELECT [id], [category_name], [category_status] FROM [category] Where [id] = " + btn.CommandArgument, con);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        TextBox1.Text = dt.Rows[0][1].ToString();
    
        RadioButtonList1.SelectedValue = dt.Rows[0][2].ToString();
        ViewState["id"] = btn.CommandArgument;
        Button1.Text = "Update";
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        //delete
        Button btn = (Button)sender;
        SqlCommand cmd = new SqlCommand("DELETE FROM [category] WHERE [id] = @id", con);

        cmd.Parameters.AddWithValue("@id", btn.CommandArgument);
        con.Open();

        int i = cmd.ExecuteNonQuery();
        con.Close();

        if (i > 0)
        {
            Literal5.Text = "User Record Deleted";
        }
        else
        {
            Literal5.Text = "User Record Not Deleted";
        }
        print();
    }
}