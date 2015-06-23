<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OAS.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Css/Style.css" rel="stylesheet" />
</head>
<body>
    <form id="LoginForm" runat="server">
        <div class="logincontainer">
            <div class="loginDiv">
                <table>
                    <tr>
                        <td>Login</td>
                        <td>
                            <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Wachtwoord</td>
                        <td><asp:TextBox ID="txtPassword" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td> <asp:Button ID="btnLogin" runat="server" Text="Inloggen" OnClick="btnLogin_Click" /></td>
                    </tr>
                </table>
            </div>

        </div>

    </form>
</body>
</html>
