<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FilmRecommendationSystem.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FILM RECOMMENDER | LOGIN</title>
    <link rel="stylesheet" href="StyleSheet.css" />
</head>
<body class="body" onload="onLoad()">
    <form runat="server">
        <p class="logo"><a href="Homepage.aspx">FILM RECOMMENDER</a></p>
        <br />
        <br />
        <asp:Panel ID="pnlNavBar" runat="server">
            <ul>
                <li><a href="Register.aspx">REGISTER</a></li>
                <li><a href="Login.aspx">SIGN IN</a></li>
            </ul>
        </asp:Panel>

        <div class="search">
                <a onclick="hyplnkSearch_Clicked()" class="label">SEARCH</a>
            <div class="textentry-container">
                <input autocomplete="off" class="textentry-field" type="text" id="myInput" onkeyup="filterSearchFunction()" />
            </div>
        </div>

        <div class="mainContent">
            <div class="header">Login</div>
            <asp:Panel ID="pnlLoginError" CssClass="loginSectionError" runat="server">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </asp:Panel>
            <div class="loginSection">
                <asp:Label runat="server" AssociatedControlID="txtUsername" CssClass="textentry-label">Username</asp:Label>
                <div class="textentry-field">
                    <asp:TextBox runat="server" ID="txtUsername" placeholder="EllenRipley57"  CssClass="textentry-fieldsize"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUsername" ID="RequiredFieldValidator2"  ErrorMessage="Username is required"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="loginSection">
                <asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword" Text="Password" CssClass="textentry-label"></asp:Label>
                <div class="textentry-field">
                    <asp:TextBox ID="txtPassword" placeholder="********" TextMode="Password" runat="server" CssClass="textentry-fieldsize"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ControlToValidate="txtPassword" ID="rqValPassword" runat="server" ErrorMessage="Password is required."></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="loginSection">
                <asp:Label runat="server" CssClass="textentry-label" AssociatedControlID="RememberMe">Remember me?</asp:Label>
                <div class="textentry-field">
                    <asp:CheckBox runat="server" ID="RememberMe" />
                </div>
            </div>
            <div class="loginSection">
                <div class="confirmationContainer">
                    <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Log in" CssClass="proceedButton" />
                    <br />
                    <a href="ForgottenResetPassword.aspx">Forgot/ need to reset password?</a>
                </div>
            </div>
        </div>

        <div class="footer">
            <div class="links">
                <a href="Help.aspx" target="_blank">Help</a> 
            </div>
            <div class="footercopyright">
                © 2020 FILM RECOMMENDER
                <br />
                All rights are reserved
            </div>
        </div>

    </form>
        <script>
            function onLoad() {
                document.getElementById("pnlLoginError").style.display = "none";
            }

            function hyplnkSearch_Clicked() {
                var searchText = document.getElementById("myInput").value;

                if (searchText.length == 0) {
                    alert("Search text cannot be blank");
                }
                else {
                    location.href = "SearchResults.aspx?searchText=" + searchText;
                }
            }

            myInput.addEventListener("keyup", function (event) {
                // Number 13 is the "Enter" key on the keyboard
                if (event.keyCode === 13) {
                    // Cancel the default action, if needed
                    event.preventDefault();
                    // Trigger the button element with a click
                    hyplnkSearch_Clicked();
                }
            });
        </script>
</body>
</html>