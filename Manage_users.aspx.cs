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
        // ConnectionString="<%$ ConnectionStrings:DatabaseConnectionString1 %>" 
                                    //DeleteCommand="DELETE FROM [users] WHERE [id] = @id" 
                                    //InsertCommand="INSERT INTO [users] ([name], [email], [password]) VALUES (@name, @email, @password)" 
                                    //ProviderName="<%$ ConnectionStrings:DatabaseConnectionString1.ProviderName %>" 
                                    //SelectCommand="SELECT [id], [name], [email], [password] FROM [users]" 
                                    //UpdateCommand="UPDATE [users] SET [name] = @name, [email] = @email, [password] = @password WHERE [id] = @id">
                                    //<DeleteParameters>
        print();

    }
    public void print()
    {
        SqlDataAdapter adpt = new SqlDataAdapter("SELECT [id], [name], [email], [password] FROM [users]",con);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Button btn = (Button) sender;
        SqlCommand cmd = new SqlCommand("DELETE FROM [users] WHERE [id] = @id", con);

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
    protected void Button3_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        SqlDataAdapter adpt = new SqlDataAdapter("SELECT [id], [name], [email], [password] FROM [users] Where [id] = "+btn.CommandArgument, con);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        TextBox1.Text = dt.Rows[0][2].ToString();
        TextBox3.Text = dt.Rows[0][1].ToString();
        TextBox2.Text = dt.Rows[0][3].ToString();
        ViewState["id"] = btn.CommandArgument;
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("UPDATE [users] SET [name] = @name, [email] = @email, [password] = @password WHERE [id] = @id", con);
        cmd.Parameters.AddWithValue("@name",TextBox3.Text);
        cmd.Parameters.AddWithValue("@email",TextBox1.Text);
        cmd.Parameters.AddWithValue("@password",TextBox2.Text);
        cmd.Parameters.AddWithValue("@id",ViewState["id"]);
        con.Open();
        int i = cmd.ExecuteNonQuery();
        con.Close();
        if (i > 0)
        {
            Literal5.Text = "Record is Updated";
        }
        else {
            Literal5.Text = "Record is not Updated";
        }
        TextBox3.Text = "";
        TextBox1.Text = "";
        TextBox2.Text = "";
        print();
    }
}