<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="FilmRecommendationSystem.ResetPassword" %>

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
                        <a href="FilmInformation2.aspx">The Terminator (1984)</a>
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
            <p class="page-header">Reset password</p>

            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="lblError" runat="server"></asp:Label>
            <br />
            <br />
            <br />
            <br />

            
            <div class="register-section">
                <asp:Label runat="server" AssociatedControlID="txtEmailAddress" CssClass="textentry-label">Email address</asp:Label>
                <div class="textentry-field">
                    <asp:TextBox runat="server" placeholder="ellenripley86@sulaco.com" ID="txtEmailAddress" TextMode="Email"  CssClass="textentry-fieldsize"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmailAddress" ID="RequiredFieldValidator2"  ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                </div>
            </div>
            
            <div class="register-section-password">
                <asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword" Text="Password" CssClass="textentry-label"></asp:Label>
                <div class="textentry-field">
                    <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="textentry-fieldsize"></asp:TextBox>
                    <br />
                    <div class="italiscised">
                        Password must:
                        <br />
                        &#8226; be a minimum of 8 characters
                        <br />
                        &#8226; have uppercase letters
                        <br />
                        &#8226; have lowercase letters
                        <br />
                        &#8226; contain numbers
                        <br />
                        <br />
                    </div>
                    <asp:RequiredFieldValidator ControlToValidate="txtPassword" ID="rqValPassword" runat="server" ErrorMessage="Password does not comply with above."></asp:RequiredFieldValidator>
                </div>
            </div>
            
            <div class="register-section">
                <asp:Label ID="lblConfirmPassword" runat="server" AssociatedControlID="txtPasswordConfirmation" Text="Confirm password" CssClass="textentry-label"></asp:Label>
                <div class="textentry-field">
                    <asp:TextBox ID="txtPasswordConfirmation" TextMode="Password" runat="server" CssClass="textentry-fieldsize"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="txtPasswordConfirmation" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Password must match the previous"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <asp:CompareValidator runat="server" ControlToCompare="txtPassword" ControlToValidate="txtPasswordConfirmation" Display="Dynamic" 
                        ErrorMessage="The two passwords do not match!"></asp:CompareValidator>
                </div>
            </div>
            
            <div class="register-section">
                <div class="textentry-label"></div>
                <div class="textentry-field">
                    <p style="font-style: italic;">By creating an account, you acknowledge our privacy statement.</p>
                    <asp:Button ID="btnResetPassword" OnClick="btnResetPassword_Click" runat="server" Text="Reset password" CssClass="registerbutton" />
                </div>
            </div>

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

        <script type="text/javascript">
            function btnLogin_Click() {
                location.href = "ResetPasswordConfirmation.aspx";
            }

            function SavePassword() {
                alert("Your new password has been saved");
                location.href="Login.aspx";        
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
                    a[i].style.display = "none";}
                }
                }
        </script>
    </form>
</body>
</html>