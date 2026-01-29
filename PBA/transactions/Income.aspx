<%@ Page Title="" Language="C#" MasterPageFile="~/PBA.Master" AutoEventWireup="true"
    CodeBehind="Income.aspx.cs" Inherits="PBA.Income" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/mainmaster.css" rel="stylesheet" />
    <link href="../css/controll.css" rel="stylesheet" />
    <link href="../css/bootstrap.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <table align="center">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align="center">
        <tr>
            <td colspan="2" align="center">
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblIncome_Id" runat="server" class="col-sm-4 col-form-label" Text="Income_Id"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtIncome_Id" runat="server" CssClass="text-primary" AutoPostBack="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblUser_Id" runat="server" class="col-sm-4 col-form-label" Text="User_Id"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtUser_Id" runat="server" CssClass="text-primary" AutoPostBack="True"
                    OnTextChanged="txtUser_Id_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <asp:Panel ID="pnlUserDetails" runat="server">
            <tr>
                <td>
                    <asp:Label ID="lblUserName" runat="server" class="col-form-label" Text="User Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblContactNumber" runat="server" class="col-form-label" Text="Phone Number"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPhoneNumber" TextMode="Number" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEmail" runat="server" class="col-form-label" Text="Email"></asp:Label>S
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" TextMode="Email" runat="server"></asp:TextBox>
                </td>
            </tr>
        </asp:Panel>
        <tr>
            <td>
                <asp:Label ID="lblIncome_Source" runat="server" class="col-sm-4 col-form-label" Text="Income_Source"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtIncome_Source" CssClass="text-primary" runat="server" Text=""></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCategory" runat="server" class="col-sm-4 col-form-label" Text="Category"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlCategory" runat="server">
                    <asp:ListItem Text="--Select"></asp:ListItem>
                    <asp:ListItem Text="Category_Id"></asp:ListItem>
                    <asp:ListItem Text="Category_Name"></asp:ListItem>
                    <asp:ListItem Text="Category_Type"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblAmount" runat="server" class="col-sm-4 col-form-label" Text="Amount"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAmount" CssClass="text-primary" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblDescription" runat="server" class="col-sm-4 col-form-label" Text="Description"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDescription" CssClass="text-primary" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblIncome_Date" runat="server" class="col-sm-4 col-form-label" Text="Income_Date"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtIncome_Date" CssClass="text-primary" TextMode="Date" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnNew" runat="server" Text="New" CssClass="btn btn-primary m-1"
                    OnClick="btnNew_click" />
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary m-1"
                    OnClick="btnSave_click" />
                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary m-1"
                    OnClick="btnUpdate_click" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-primary m-1"
                    OnClick="btnDelete_click" />
                <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn btn-primary m-1"
                    OnClick="btnClose_click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GvUserDetails" runat="server" CellPadding="4" ForeColor="#333333"
                    GridLines="None" OnSelectedIndexChanged="GvUserDetails_SelectedIndexChanged1">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="select" ShowHeader="True"
                            Text="select" />
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
</asp:Content>
