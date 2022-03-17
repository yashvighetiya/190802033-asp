<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Manage_products.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="wrapper">
	<div class="form-w3layouts">
 <div class="row">
            <div class="col-lg-12">
 <section class="panel">
                        <header class="panel-heading">
                            Basic Forms
                        </header>
                        <div class="panel-body">
                            <div class="position-center">
                           
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Name : </label>
                                    <asp:TextBox ID="TextBox1" runat="server"  class="form-control"  placeholder="Enter email"></asp:TextBox>
                                   
                                </div>
                                 <div class="form-group">
                                    <label for="exampleInputEmail1">Description :</label>
                                    <asp:TextBox ID="TextBox2" runat="server"  class="form-control"  placeholder="Enter description" TextMode="MultiLine"></asp:TextBox>
                                   
                                     <br />
                                   
                                </div>
                                 <div class="form-group">
                                    <label for="exampleInputEmail1">Category :</label>
                                     <asp:DropDownList ID="DropDownList1" runat="server">
                                     </asp:DropDownList>
                                   
                                     <br />
                                   
                                </div>
                                 <div class="form-group">
                                    <label for="exampleInputEmail1">Image Upload:</label>
                                    <asp:FileUpload ID="FileUpload1" runat="server"></asp:FileUpload>
                                     <br />
                                   
                                </div>
                                  <div class="form-group">
                                    <label for="exampleInputPassword1">Status</label>
                                  <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                                        RepeatDirection="Horizontal">
                                      <asp:ListItem Value="1">Active</asp:ListItem>
                                      <asp:ListItem Value="0">Inactive</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Price : </label>
                                    <asp:TextBox ID="TextBox3" runat="server" class="form-control" placeholder="Enter Price"></asp:TextBox>
                                   
                                </div>
                                
                              <asp:Button ID="Button1" class="btn btn-info" runat="server" Text="Insert" onclick="Button1_Click" 
                                   ></asp:Button>
                               
                                <br />
                                <br />
                                <br />
                                <asp:Literal ID="Literal5" runat="server"></asp:Literal>
                                <br />
                                <br />
                           
                            </div>

                        </div>
                    </section>
                    </div></div>
                    </div></section>
</asp:Content>

