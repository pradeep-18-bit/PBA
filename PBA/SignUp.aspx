<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="PBA.SignUp1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign Up</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div>
                <label>User Name</label><br />
                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
            </div>

            <div>
                <label>Password</label><br />
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>

            <div>
                <label>Confirm Password</label><br />
                <asp:TextBox ID="txtCpassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>

            <div>
                <label>Phone Number</label><br />
                <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
            </div>

            <div>
                <label>Email</label><br />
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </div>

            <div>
                <label>Select Role</label><br />
                <asp:DropDownList ID="ddlRole" runat="server">
                    <asp:ListItem Text="--Select--" Value="0" />
                    <asp:ListItem Text="Admin" Value="1" />
                    <asp:ListItem Text="User" Value="2" />
                    <asp:ListItem Text="Viewer" Value="3" />
                </asp:DropDownList>
            </div>

            <br />

            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            <asp:Button ID="btnClose" runat="server" Text="Close" OnClick="btnClose_Click" />

        </div>
    </form>
</body>
</html>
