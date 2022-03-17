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
       // DeleteCommand="DELETE FROM [service] WHERE [id] = @id" 
         //                           InsertCommand="INSERT INTO [service] ([name], [description], [status]) VALUES (@name, @description, @status)" 
           //                         ProviderName="<%$ ConnectionStrings:DatabaseConnectionString1.ProviderName %>" 
             //                       SelectCommand="SELECT [id], [name], [description], [status] FROM [service]" 
               //                     UpdateCommand="UPDATE [service] SET [name] = @name, [description] = @description, [status] = @status WHERE [id] = @id">
    }
}
