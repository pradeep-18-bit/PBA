<%@ Page Title="" Language="C#" MasterPageFile="~/PBA.Master" AutoEventWireup="true" CodeBehind="Roles.aspx.cs" Inherits="PBA.masters.Roles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Css/Bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../Css/Controll.css" rel="stylesheet" type="text/css" />
    <link href="../Css/Mainmaster.css" rel="stylesheet" type="text/css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<link href="../Css/Bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../Css/Controll.css" rel="stylesheet" type="text/css" />
    <link href="../Css/Mainmaster.css" rel="stylesheet" type="text/css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
<table align="center">
<tr>
<td colspan="2" align="center">
<asp:Label ID="lblRoleDetails" runat="server" Text="RoleDetails"></asp:Label></td></tr>
<tr>
<td><asp:Label ID="lblRoleId" runat="server" Text="RoleId"></asp:Label></td>
<td><asp:TextBox ID="txtRoleId"  runat="server" Text="" AutoPostBack="true"
        ontextchanged="txtRoleId_TextChanged"></asp:TextBox>
</td>
</tr>
<tr>
<td><asp:Label ID="lblRoleName" runat="server" Text="RoleName"></asp:Label></td>
<td><asp:TextBox ID="txtRoleName" runat="server" Text=""></asp:TextBox></td>
</tr>
<tr>
            <td colspan ="2">
                <asp:Button ID="btnNew" runat ="server" Text="New" CssClass ="btn-primary" 
                    onclick="btnNew_Click" />
                <asp:Button ID="btnSave" runat ="server" Text="Save" CssClass ="btn-primary" 
                    onclick="btnSave_Click" />
                <asp:Button ID="btnUpdate" runat ="server" Text="Update" 
                    CssClass ="btn-primary" onclick="btnUpdate_Click"/>
                <asp:Button ID="btnDelete" runat ="server" Text="Delete" 
                    CssClass ="btn-primary" onclick="btnDelete_Click"/>
                 <asp:Button ID="btnClose" runat ="server" Text="Close" CssClass ="btn-primary" 
                    onclick="btnClose_Click" />
             </td>
        </tr>
         <tr>
        <td colspan="2">
        <asp:GridView ID="Gvtbl_RoleDetails" runat="server" CellPadding="4" 
                ForeColor="#333333" GridLines="None" 
                onselectedindexchanged="Gvtbl_RoleDetails_SelectedIndexChanged">
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
</td></tr>
</table>
</asp:Content>
