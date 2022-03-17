<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Manage_categories.aspx.cs" Inherits="_Default" EnableEventValidation="false" %>

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
                                    <label for="exampleInputEmail1">Name</label>
                                    <asp:TextBox ID="TextBox1" runat="server"  class="form-control"  placeholder="Enter Category Name"></asp:TextBox>
                                   
                                </div>
                            
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Status</label>
                                  <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                                        RepeatDirection="Horizontal">
                                      <asp:ListItem Value="1">Active</asp:ListItem>
                                      <asp:ListItem Value="0">Inactive</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                
                              <asp:Button ID="Button1" class="btn btn-info" runat="server" Text="Insert" onclick="Button1_Click" 
                                    ></asp:Button>
                               
                                <br />
                                <br />
                                <br />
                                <asp:Literal ID="Literal5" runat="server"></asp:Literal>
                                <br />
                                <br />
                              
                                <br />

                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField HeaderText="ID">
                                            <ItemTemplate>
                                                <asp:Literal ID="Literal6" runat="server" Text='<%# Eval("id") %>'></asp:Literal>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Category Name">
                                            <ItemTemplate>
                                                <asp:Literal ID="Literal7" runat="server" Text='<%# Eval("category_name") %>'></asp:Literal>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Category Status">
                                            <ItemTemplate>
                                                <asp:Literal ID="Literal8" runat="server" Text='<%# Eval("category_status") %>'></asp:Literal>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:Button ID="Button2" runat="server" CommandArgument='<%# Eval("id") %>' 
                                                    onclick="Button2_Click" Text="Edit" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="Delete" 
                                                    CommandArgument='<%# Eval("id") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>

                                <br />
                                <br />
                           
                            </div>

                        </div>
                    </section>
                    </div></div>
                    </div></section>
</asp:Content>

