<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgottenResetPassword_EmailSent.aspx.cs" Inherits="FilmRecommendationSystem.ForgottenResetPassword_EmailSent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Film recommender | Confirm email address</title>
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

        <div class="search">
                <a onclick="hyplnkSearch_Clicked()" class="label">SEARCH</a>
            <div class="textentry-container">
                <input autocomplete="off" class="textentry-field" type="text" id="myInput" onkeyup="filterSearchFunction()" />
            </div>
        </div>

        <div class="mainContent">
            <div class="header">Check your email address</div>
            <div class="textSection">
                An email with a link to reset your password has been sent to your email address. 
            </div>
            <div class="textSection">
                <button type="button" onclick="btnOk_Click()" id="btnOk" class="proceedButton">Ok</button>
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

        <script>
            function btnOk_Click() {
                location.href = "Homepage.aspx";
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
    </form>
</body>
</html>