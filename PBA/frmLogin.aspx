<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="PBA.frmLogin" %>

<link href="css/Bootstrap1.css" rel="stylesheet" type="text/css" />
<link href="css/Mainmaster.css" rel="stylesheet" type="text/css" />
<link href="css/Control.css" rel="stylesheet" type="text/css" />
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table align="center">
            <tr>
                <th colspan="2">
                    <h4>
                        Login</h4>
                </th>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblUsername" runat="server" Text="Username"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblDnthvact" runat="server" Text="Don't Have an Account?"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="btnSignUp" runat="server" Text="SignUp" OnClick="btnSignUp_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
