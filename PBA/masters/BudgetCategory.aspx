<%@ Page Title="" Language="C#" MasterPageFile="~/PBA.Master" AutoEventWireup="true" CodeBehind="BudgetCategory.aspx.cs" Inherits="PBA.masters.BudgetCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="../Css/Mainmaster.css" rel="stylesheet" />
    <link href="../Css/Controll.css" rel="stylesheet" />
    <link href="../Css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</asp:Content>

<asp:Content ID="content3" ContentPlaceHolderID="contentplaceholder1" runat="server">
    <link href="../css/mainmaster.css" rel="stylesheet" />
    <link href="../css/controll.css" rel="stylesheet" />
    <link href="../css/bootstrap.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
                        <form>
                            <table align="center">
                                <tr>
                                    <td colspan="2" align="center"></td>

                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblCategory_Id" runat="server" class="col-sm-4 col-form-label" Text="Category_Id"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCategory_Id"  runat="server"  AutoPostBack="True" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblCategory_Name" runat="server" class="col-sm-4 col-form-label" Text="Category_Name"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCategory_Name"   runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblCategory_Type" runat="server" class="col-sm-4 col-form-label" Text="Category_Type"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlCategory_Type" runat="server" 
                                            onselectedindexchanged="ddlCategory_Type_SelectedIndexChanged" >
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                               
                               
                                
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="btnNew" runat="server" Text="New" CssClass="btn btn-primary m-1" OnClick="btnNew_click" />
                                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary m-1" OnClick="btnSave_click" />
                                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary m-1" OnClick="btnUpdate_click" />
                                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-primary m-1" OnClick="btnDelete_click" />
                                        <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn btn-primary m-1" OnClick="btnClose_click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:GridView ID="GvBudgetCategory" runat="server" CellPadding="4" 
                                            ForeColor="#333333" GridLines="None" 
                                            onselectedindexchanged="GvUserDetails_SelectedIndexChanged1">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="select" 
                                                    ShowHeader="True" Text="select" />
                                            </Columns>
                                            <EditRowStyle BackColor="#2461BF" />
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#EFF3FB" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                        </asp:GridView>

                                    </td>
                                </tr>
                            </table>
                        </form>
                    
</asp:Content>
