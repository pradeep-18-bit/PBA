<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="frmLogin.aspx.cs"
    Inherits="PBA.frmLogin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="css/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <div class="container mt-5">
            <div class="card col-md-4 offset-md-4">
                <div class="card-header text-center bg-primary text-white">
                    <h4>Login</h4>
                </div>

                <div class="card-body">

                    <div class="form-group">
                        <asp:Label runat="server" Text="Username"></asp:Label>
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" />
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" Text="Password"></asp:Label>
                        <asp:TextBox ID="txtPassword" runat="server"
                            TextMode="Password" CssClass="form-control" />
                    </div>

                    <div class="text-center mt-3">
                        <asp:Button ID="btnLogin" runat="server"
                            Text="Login"
                            CssClass="btn btn-success"
                            OnClick="btnLogin_Click" />

                        <asp:Button ID="btnSignUp" runat="server"
                            Text="Sign Up"
                            CssClass="btn btn-link"
                            OnClick="btnSignUp_Click" />
                    </div>

                </div>
            </div>
        </div>

    </form>
</body>
</html>
