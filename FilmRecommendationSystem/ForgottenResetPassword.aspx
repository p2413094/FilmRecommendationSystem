<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgottenResetPassword.aspx.cs" Inherits="FilmRecommendationSystem.ForgottenResetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FILM RECOMMENDER | FORGOTTEN PASSWORD</title>
    <link rel="stylesheet" href="StyleSheet.css" />
</head>

<body class="body">
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
            <div class="header">Reset password</div>
            <div class="textSection">
                If you've forgotten your password or need to reset it, enter your account email
                and we'll send you a link to change it.     
            </div>
            <div class="loginSection">
                <asp:Label runat="server" AssociatedControlID="txtEmailAddress" CssClass="textentry-label">Email address</asp:Label>
                <div class="textentry-field">
                    <asp:TextBox ID="txtEmailAddress" TextMode="Email" CssClass="textentry-fieldsize" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmailAddress" ErrorMessage="Email address is required"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="btnResetPassword" OnClick="btnResetPassword_Click" runat="server" Text="Reset password" CssClass="proceedButton" />
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
        
    </form>
    <script type="text/javascript">
        function btnResetPassword_Click() {
            location.href = "ResetPassword.aspx";
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