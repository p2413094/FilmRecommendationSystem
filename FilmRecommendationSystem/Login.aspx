<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FilmRecommendationSystem.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Film recommender | Login</title>
    <link rel="stylesheet" href="StyleSheet.css" />
</head>
<body class="body">
    <form runat="server">
        <p class="logo textlink">
            <a href="Homepage.aspx">FILM RECOMMENDER</a>
            <ul>
                <br />
                <br />
                <br />
                <li><a href="Register.aspx">REGISTER</a></li>
                <li><a href="Login.aspx">SIGN IN</a></li>
            </ul>
        </p>

        <br />
        <br />

        <section class="search">
            <div class="textentry-label">
                SEARCH
            </div>
            <div class="textentry-container">
                <input autocomplete="off" class="textentry-field" type="text" oninput="myFunction()" id="myInput" onkeyup="filterFunction()" />
                <div>
                    <div id="myDropdown" class="dropdown-content">
                        <a href="FilmInformation.aspx">The Terminator (1984)</a>
                        <a>Little Women (2019)</a>
                    </div>
                </div>
                <br />
                <br />
            </div>
        </section>

        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <div class="account">
            <p class="page-header">
                Login
            </p>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />

            <div class="register-section">
                <asp:Label runat="server" AssociatedControlID="txtUsername" CssClass="textentry-label">Username</asp:Label>
                <div class="textentry-field">
                    <asp:TextBox runat="server" ID="txtUsername"  CssClass="textentry-fieldsize"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUsername" ID="RequiredFieldValidator2"  ErrorMessage="Username is required"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="register-section">
                <asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword" Text="Password" CssClass="textentry-label"></asp:Label>
                <div class="textentry-field">
                    <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="textentry-fieldsize"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ControlToValidate="txtPassword" ID="rqValPassword" runat="server" ErrorMessage="Password is required."></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="register-section">
                <asp:Label runat="server" CssClass="textentry-label" AssociatedControlID="RememberMe">Remember me?</asp:Label>
                <div class="textentry-field">
                    <asp:CheckBox runat="server" ID="RememberMe" />
                </div>
            </div>

            <div class="register-section">
                <asp:Label ID="Label1" runat="server" CssClass="textentry-label"></asp:Label>
                <div class="textentry-field">
                    <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Log in" CssClass="okbutton" />
                    <br />
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </div>
            </div>

            <div>
                <div class="textentry-field">
                    <br />
                    <br />
                    <br />
                    <br />
                    <button type="button" class="okbutton" onclick="btnLoginStaffMember_Click()" id="btnLoginStaffMember">Staff member login</button>
                    <br />
                    <button type="button" class="okbutton" onclick="btnLoginAdmin_Click()">Administrator log in</button>
                    <br />
                    <a href="ResetPassword.aspx">Forgot/ need to reset password?</a>
                </div>
            </div>
            <br />
        </div>

        <div class="footer">
            <div class="links">
                Help
            </div>
            <div class="footercopyright">
                © 2020 FILM RECOMMENDER
                <br />
                All rights are reserved
                <br />
                Site NOT for rollout
            </div>
        </div>

    </form>
        <script type="text/javascript">     
            function btnLogin_Click() {
                location.href = "MyAccount.aspx";
            }
            
            function btnLoginStaffMember_Click() {
                location.href = "MyAccountStaffMember.aspx";
            }
            
            function btnLoginAdmin_Click() {
                location.href = "MyAccountAdministrator.aspx";
            }

            /* When the user clicks on the button,
            toggle between hiding and showing the dropdown content */
            function myFunction() {
            document.getElementById("myDropdown").classList.toggle("show");
            }

            function filterFunction() {
            var input, filter, ul, li, a, i;
            input = document.getElementById("myInput");
            filter = input.value.toUpperCase();
            div = document.getElementById("myDropdown");
            a = div.getElementsByTagName("a");
            for (i = 0; i < a.length; i++) {
                txtValue = a[i].textContent || a[i].innerText;
                if (txtValue.toUpperCase().indexOf(filter) > -1) {
                a[i].style.display = "";
                } else {
                a[i].style.display = "none";
                }
            }
        }
        </script>
</body>
</html>