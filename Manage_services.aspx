<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" enableEventValidation="false" AutoEventWireup="true" CodeFile="Manage_services.aspx.cs" Inherits="_Default" %>

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
                                    <asp:TextBox ID="TextBox1" runat="server"  class="form-control"  placeholder="Enter name"></asp:TextBox>
                                   
                                </div>
                                 <div class="form-group">
                                    <label for="exampleInputEmail1">Description</label>
                                    <asp:TextBox ID="TextBox3" runat="server"  class="form-control"  
                                         placeholder="Enter description" Rows="3" TextMode="MultiLine"></asp:TextBox>
                                   
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
                                        <asp:TemplateField HeaderText="Id">
                                            <ItemTemplate>
                                                <asp:Literal ID="Literal6" runat="server" Text='<%# Eval("id") %>'></asp:Literal>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name">
                                            <ItemTemplate>
                                                <asp:Literal ID="Literal7" runat="server" Text='<%# Eval("name") %>'></asp:Literal>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Description">
                                            <ItemTemplate>
                                                <asp:Literal ID="Literal8" runat="server" Text='<%# Eval("description") %>'></asp:Literal>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Service">
                                            <ItemTemplate>
                                                <asp:Literal ID="Literal9" runat="server" Text='<%# Eval("status") %>'></asp:Literal>
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
                                                <asp:Button ID="Button3" runat="server" CommandArgument='<%# Eval("id") %>' 
                                                    onclick="Button3_Click" Text="Delete" />
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

