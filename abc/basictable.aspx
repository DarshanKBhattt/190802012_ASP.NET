<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="basictable.aspx.cs" Inherits="_Default" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section id="main-content">
	<section class="wrapper">
	<div class="form-w3layouts">
        <!-- page start-->
        <!-- page start-->
        <div class="row">
            <div class="col-lg-12">
                    <section class="panel">
                        <header class="panel-heading">
                            Basic Forms
                        </header>
                        <div class="panel-body">
                            <div class="position-center">
                                <form role="form">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Enter Name Of Hotel</label>
                                    <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="Enter email"></asp:TextBox>
                                </div>
                                <asp:Button ID="Button1" runat="server" type="submit" class="btn btn-info" 
                                    Text="Submit" onclick="Button1_Click"></asp:Button>
                                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                            </form>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                    BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" 
                                    CellPadding="3" CellSpacing="2">
                                    <Columns>
                                        <asp:TemplateField HeaderText="id">
                                            <ItemTemplate>
                                                <asp:Literal ID="Literal2" runat="server" Text='<%# Eval("h_id") %>'></asp:Literal>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Hotel Name">
                                            <ItemTemplate>
                                                <asp:Literal ID="Literal3" runat="server" Text='<%# Eval("hnm") %>'></asp:Literal>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:Button ID="Button4" runat="server" CommandArgument='<%# Eval("h_id") %>' 
                                                    onclick="Button4_Click" Text="Delete" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Update">
                                            <ItemTemplate>
                                                <asp:Button ID="Button5" runat="server" CommandArgument='<%# Eval("h_id") %>' 
                                                    onclick="Button5_Click" Text="Edit" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                                    <SortedDescendingHeaderStyle BackColor="#93451F" />
                                </asp:GridView>
                            </div>

                        </div>
                    </section>

            </div>
        <!-- page end-->
        </div>
    </section>
    <script src="ClientSrc/js/bootstrap.js"></script>
    <script src="ClientSrc/js/jquery.dcjqaccordion.2.7.js"></script>
    <script src="ClientSrc/js/scripts.js"></script>
    <script src="ClientSrc/js/jquery.slimscroll.js"></script>
    <script src="ClientSrc/js/jquery.nicescroll.js"></script>
    <script src="ClientSrc/js/jquery.scrollTo.js"></script>
    </div>
</asp:Content>
