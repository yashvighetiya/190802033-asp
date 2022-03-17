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
                                    //DeleteCommand="DELETE FROM [service] WHERE [id] = @id" 
                                    //InsertCommand="INSERT INTO [service] ([name], [description], [status]) VALUES (@name, @description, @status)" 
                                    //ProviderName="<%$ ConnectionStrings:DatabaseConnectionString1.ProviderName %>" 
                                    //SelectCommand="SELECT [id], [name], [description], [status] FROM [service]" 
                                    //UpdateCommand="UPDATE [service] SET [name] = @name, [description] = @description, [status] = @status WHERE [id] = @id">
    }
    public void print()
    {
        SqlDataAdapter adpt = new SqlDataAdapter("SELECT [id], [name], [description], [status] FROM [service]", con);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        SqlDataAdapter adpt = new SqlDataAdapter("SELECT [id], [name], [description], [status] FROM [service] Where [id] = " + btn.CommandArgument, con);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        TextBox1.Text = dt.Rows[0][1].ToString();
        TextBox3.Text = dt.Rows[0][2].ToString();
        RadioButtonList1.SelectedValue = dt.Rows[0][3].ToString();
        ViewState["id"] = btn.CommandArgument;
        Button1.Text = "Update";
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        SqlCommand cmd = new SqlCommand("DELETE FROM [service] WHERE [id] = @id", con);

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
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Button1.Text == "Insert")
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO [service] ([name], [description], [status]) VALUES (@name, @description, @status)", con);
            cmd.Parameters.AddWithValue("@name", TextBox1.Text);
            cmd.Parameters.AddWithValue("@description", TextBox3.Text);
            cmd.Parameters.AddWithValue("@status", RadioButtonList1.SelectedValue);

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
            TextBox3.Text = "";
            TextBox1.Text = "";
            RadioButtonList1.ClearSelection();
            print();
        }
        if(Button1.Text == "Update")
        {

            SqlCommand cmd = new SqlCommand("UPDATE [service] SET [name] = @name, [description] = @description, [status] = @status WHERE [id] = @id", con);
            cmd.Parameters.AddWithValue("@name", TextBox1.Text);
            cmd.Parameters.AddWithValue("@description", TextBox3.Text);
            cmd.Parameters.AddWithValue("@status", RadioButtonList1.SelectedValue);
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
            TextBox3.Text = "";
            TextBox1.Text = "";
            RadioButtonList1.ClearSelection();
            print();
        }
      
    }
}