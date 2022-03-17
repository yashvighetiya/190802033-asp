using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString1"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
    //    DeleteCommand="DELETE FROM [product] WHERE [id] = @id" 
    //                                InsertCommand="INSERT INTO [product] ([id], [product_category_id], [product_name], [product_price], [product_description], [product_image], [product_status]) VALUES (@id, @product_category_id, @product_name, @product_price, @product_description, @product_image, @product_status)" 
    //                                ProviderName="<%$ ConnectionStrings:DatabaseConnectionString1.ProviderName %>" 
    //                                SelectCommand="SELECT [id], [product_category_id], [product_name], [product_price], [product_description], [product_image], [product_status] FROM [product]" 
    //                                UpdateCommand="UPDATE [product] SET [product_category_id] = @product_category_id, [product_name] = @product_name, [product_price] = @product_price, [product_description] = @product_description, [product_image] = @product_image, [product_status] = @product_status WHERE [id] = @id">

        if (!IsPostBack)
        {
            DropDownBind();   
        }                  
    }
    public void clear()
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        RadioButtonList1.ClearSelection();
        DropDownList1.ClearSelection();
    }
    public void DropDownBind()
    {
        SqlDataAdapter adpt = new SqlDataAdapter("SELECT [id], [category_name], [category_status] FROM [category]", con);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        DropDownList1.DataSource = dt;
        DropDownList1.DataTextField = "category_name";
        DropDownList1.DataValueField = "id";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("Select Category",""));
        DropDownList1.Items[0].Selected = true;
        DropDownList1.Items[0].Attributes["disabled"] = "disabled";

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if(FileUpload1.HasFile)
        {
            FileUpload1.SaveAs(Server.MapPath("~/uploads/" + FileUpload1.FileName));
            SqlCommand cmd = new SqlCommand("INSERT INTO [product] ( [product_category_id], [product_name], [product_price], [product_description], [product_image], [product_status]) VALUES (@product_category_id, @product_name, @product_price, @product_description, @product_image, @product_status)", con);
            cmd.Parameters.AddWithValue("@product_name", TextBox1.Text);
            cmd.Parameters.AddWithValue("@product_description", TextBox2.Text);
            cmd.Parameters.AddWithValue("@product_price", Convert.ToInt32(TextBox3.Text));
            cmd.Parameters.AddWithValue("@product_status", RadioButtonList1.SelectedValue);
            cmd.Parameters.AddWithValue("@product_image", FileUpload1.FileName);
            cmd.Parameters.AddWithValue("@product_category_id", DropDownList1.SelectedItem.Value);
            con.Open();
            int s = cmd.ExecuteNonQuery();
            con.Close();
            if (s == 1)
            {
                Literal5.Text = "Product Inserted Successfully!";

                clear();
            }
            else
            {
                Literal5.Text = "Please fill all details!";
            }
        }
    }
}