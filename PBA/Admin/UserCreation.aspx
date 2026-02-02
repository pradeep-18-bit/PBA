<%@ Page Title="User Creation"
    Language="C#"
    MasterPageFile="~/PBA.Master"
    AutoEventWireup="true"
    CodeBehind="UserCreation.aspx.cs"
    Inherits="PBA.Admin.UserCreation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/mainmaster.css" rel="stylesheet" />
    <link href="../css/controll.css" rel="stylesheet" />
    <link href="../css/bootstrap.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container mt-4">
    <div class="card">
        <div class="card-header bg-primary text-white text-center">
            <h4>User Creation</h4>
        </div>

        <div class="card-body">

            <table class="table table-borderless">

                <tr>
                    <td>User Name</td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" />
                        <asp:RequiredFieldValidator
                            ID="rfvUserName"
                            runat="server"
                            ControlToValidate="txtUserName"
                            ErrorMessage="User Name is required"
                            ForeColor="Red" />
                    </td>
                </tr>

                <tr>
                    <td>Password</td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server"
                            TextMode="Password" CssClass="form-control" />
                    </td>
                </tr>

                <tr>
                    <td>Confirm Password</td>
                    <td>
                        <asp:TextBox ID="txtCpassword" runat="server"
                            TextMode="Password" CssClass="form-control" />
                    </td>
                </tr>

                <tr>
                    <td>Phone Number</td>
                    <td>
                        <asp:TextBox ID="txtPhoneNumber" runat="server"
                            CssClass="form-control" />
                    </td>
                </tr>

                <tr>
                    <td>Email</td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server"
                            CssClass="form-control" />
                    </td>
                </tr>

                <tr>
                    <td>Role</td>
                    <td>
                        <asp:DropDownList ID="ddlRole" runat="server"
                            CssClass="form-control">
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td colspan="2" class="text-center">
                        <asp:Button ID="btnNew" runat="server"
                            Text="New"
                            CssClass="btn btn-secondary"
                            OnClick="btnNew_click" />

                        <asp:Button ID="btnSave" runat="server"
                            Text="Save"
                            CssClass="btn btn-success"
                            OnClick="btnSave_click" />

                        <asp:Button ID="btnUpdate" runat="server"
                            Text="Update"
                            CssClass="btn btn-primary"
                            OnClick="btnUpdate_click" />

                        <asp:Button ID="btnDelete" runat="server"
                            Text="Delete"
                            CssClass="btn btn-danger"
                            OnClick="btnDelete_click" />
                    </td>
                </tr>

            </table>

            <asp:GridView
                ID="GvUserDetails"
                runat="server"
                AutoGenerateColumns="False"
                CssClass="table table-striped table-bordered"
                DataKeyNames="User_Id"
                OnSelectedIndexChanged="GvUserDetails_SelectedIndexChanged">

                <Columns>
                    <asp:CommandField ShowSelectButton="True" />

                    <asp:BoundField DataField="User_Id" HeaderText="User Id" />
                    <asp:BoundField DataField="UserName" HeaderText="User Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Role" HeaderText="Role" />
                </Columns>
            </asp:GridView>

        </div>
    </div>
</div>

</asp:Content>
