<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Film recommender | Login</title>
    <link rel="stylesheet" href="StyleSheet.css" />
</head>

<body class="body">
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
            <br />
            <br />
            <br />

            <div>
                <div class="textentry-label">
                    Email address
                </div>
                <div class="textentry-field">
                    <input id="txtEmailAddress" type="text" class="textentry-fieldsize" />
                </div>
                <br />
                <br />
                <br />
                <div class="textentry-label">
                    Password
                </div>
                <div class="textentry-field">
                    <input id="txtPassword" type="password" class="textentry-fieldsize" />
                    <br />
                    <br />
                    <br />
                    <button type="button" class="okbutton" onclick="btnLogin_Click()" id="btnLogin">Log in</button>
                    <br />
                    <button type="button" class="okbutton" onclick="btnLoginStaffMember_Click()" id="btnLoginStaffMember">Staff member login</button>
                    <br />
                    <button type="button" class="okbutton" onclick="btnLoginAdmin_Click()">Administrator log in</button>
                    <br />
                    <a href="ForgottenResetPassword.aspx">Forgot/ need to reset password?</a>

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