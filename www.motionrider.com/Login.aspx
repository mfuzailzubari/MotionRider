<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="www.motionrider.com.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Login - Motion Rider Web Portal</title>
    <link rel="stylesheet" href="~/Assets/Css/Login.css" type="text/css" />
</head>
<body>
    <form id="Form1" class="form-signin" runat="server">
        <%--<img src="/Assets/Img/logo.png" width="280" alt="Anajana.com" />--%>
        <h2 class="form-signin-heading">Admin Login</h2>

        <asp:Label ID="lblMsgSuccess" CssClass="alert alert-success" runat="server" EnableTheming="True" ViewStateMode="Enabled"></asp:Label>
        <asp:Label ID="lblMsgError" CssClass="alert alert-error" runat="server" Text=""></asp:Label>

        <!-- email -->
        <div class="login-controls">
            <div class="control-group">
                <div class="controls">
                    <asp:TextBox ID="userEmail" CssClass="inputs" runat="server" placeholder="Email" required="required" AutoCompleteType="Email" CausesValidation="True" type="email" TabIndex="1"></asp:TextBox>
                </div>
            </div>

            <!-- password -->
            <div class="control-group">
                <div class="controls">
                    <asp:TextBox ID="userPassword" CssClass="inputs" runat="server" placeholder="Password" required="required" AutoCompleteType="None" CausesValidation="True" TextMode="Password" TabIndex="2"></asp:TextBox>
                </div>
            </div>
        </div>

        <asp:Button ID="btnSubmit" runat="server" CssClass="btn" Text="Login" TabIndex="3" OnClick="On_btnSubmit_Click" />
        <asp:HyperLink ID="forgetPassword" runat="server" NavigateUrl="~/Forget.aspx" Text="Forget Password" TabIndex="4"></asp:HyperLink>
    </form>
</body>
</html>
