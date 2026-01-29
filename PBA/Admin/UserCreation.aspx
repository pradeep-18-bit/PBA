<%@ Page Title="" Language="C#" MasterPageFile="~/PBA.Master" AutoEventWireup="true" CodeBehind="UserCreation.aspx.cs" Inherits="PBA.Admin.UserCreation" %>
<asp:Content ID="content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/mainmaster.css" rel="stylesheet" />
    <link href="../css/controll.css" rel="stylesheet" />
    <link href="../css/bootstrap.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <style> 
        body {
            background: url('https://www.example.com/background-image.jpg') no-repeat center center fixed;
            background-size: cover;
        }
        .container {
            background: rgba(255, 255, 255, 0.8);
            padding: 20px;
            border-radius: 10px;
        }
        .card {
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            border-radius: 8px;
            overflow: hidden;
            background: url('https://www.example.com/card-background.jpg') no-repeat center center;
            background-size: cover;
        }
        .card-header {
            font-size: 1.5rem;
            font-weight: bold;
            background: rgba(0, 123, 255, 0.85);
        }
        .form-control {
            border-radius: 4px;
            margin-bottom: 10px;
        }
        .btn {
            margin-right: 5px;
        }
        .table {
            width: 100%;
            margin-top: 20px;
        }
        .table th, .table td {
            text-align: center;
        }
    </style>
</asp:Content>

<asp:Content ID="content2" ContentPlaceHolderID="contentplaceholder1" runat="server">
    <div class="container mt-5" align="center">
        <div class="row justify-content-center" align="center">
            <div class="col-md-8" align="center">
                <div class="card" align="center">
                    <div class="card-header text-center text-white" align="center">
                        <asp:Label ID="lblheading" runat="server" Text="User Creation"></asp:Label>
                    </div>
                    <div class="card-body">
                        <form>
                            <table class="table table-borderless" align="center">
                             <tr>
                                    <td>
                                        <asp:Label ID="User_Id" runat="server" class="col-form-label" Text="User_Id"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtUser_Id"  runat="server"  AutoPostBack="True" 
                                            ontextchanged="txtUser_Id_TextChanged" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblUserName" runat="server" class="col-form-label" Text="User Name"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtUserName"  runat="server"  AutoPostBack="True" ></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ControlToValidate="txtUsername" ErrorMessage="Required">
                                         </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblPassword" runat="server" class="col-form-label" Text="Password"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPassword" TextMode="Password"  runat="server"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server" ControlToValidate="txtPassword" ErrorMessage="Required">
                                         </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblCpassword" runat="server" class="col-form-label" Text="Confirm Password"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCpassword" TextMode="Password"  runat="server"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" runat="server" ControlToValidate="txtCpassword" ErrorMessage="Required">
                                         </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblContactNumber" runat="server" class="col-form-label" Text="Phone Number"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPhoneNumber" EnableViewState="false"  TextMode="Number" runat="server"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" runat="server" ControlToValidate="txtPhoneNumber" ErrorMessage="Required">
                                         </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblEmail" runat="server" class="col-form-label" Text="Email"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEmail" TextMode="Email"  runat="server"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red" runat="server" ControlToValidate="txtEmail" ErrorMessage="Required">
                                         </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblRole" runat="server" class="col-form-label" Text="Select Role"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlRole" runat="server" >
                                          <asp:ListItem Text="--Select" Value="0"></asp:ListItem>
                                           <asp:ListItem Text="Admin" Value="1"></asp:ListItem>
                                           <asp:ListItem Text="User" Value="2"></asp:ListItem>
                                          <asp:ListItem Text="Viewer" Value="3"></asp:ListItem>
                                        </asp:DropDownList>
                                        </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="text-center">
                                        <asp:Button ID="btnNew" runat="server" Text="New"  OnClick="btnNew_click" />
                                        <asp:Button ID="btnSave" runat="server" Text="Save"  OnClick="btnSave_click" />
                                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass ="btn-primary"  OnClick="btnUpdate_click" />
                                        <asp:Button ID="btnDelete" runat="server" Text="Delete"  OnClick="btnDelete_click" />
                                        <asp:Button ID="btnClose" runat="server" Text="Close"  OnClick="btnClose_click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:GridView ID="GvUserDetails" runat="server" CssClass="table table-striped table-hover" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GvUserDetails_SelectedIndexChanged">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:CommandField ShowSelectButton="True" />
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
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>