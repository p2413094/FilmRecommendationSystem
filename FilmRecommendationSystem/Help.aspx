<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Help.aspx.cs" Inherits="FilmRecommendationSystem.Help" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FILM RECOMMENDER | HELP</title>
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
                <input autocomplete="off" class="textentry-field" type="text" id="myInput" onkeyup="filterSearchFunction()"  />
            </div>
        </div>

        <div class="mainContent">
            <div class="header">Help</div>
            <div class="helpContainer">
                <div class="helpQuestionHeader">What is FILM RECOMMENDER?</div>
                FILM RECOMMENDER is a website that allows you to get film recommendations based on what genre of film you want or what kind 
                of mood you’re in. It takes a lot of the tedious work out of finding a film to watch.

                <div class="helpQuestionHeader">How does it recommend films?</div>
                We look at how films have been previously rated and make a prediction on how likely you’re going to like another film of the same genre or mood. 
                Then, we give you the best recommendations.

                <div class="helpQuestionHeader">Can I save my recommended films?</div>
                Yes, all you have to do is create an account with us. When you have an account, you can also save your favourite films, add films to watch later, 
                and give as many films as you like a rating, as well as tagging a mood to a film.

                <div class="helpQuestionHeader">Is my account data secure?</div>
                Yes. We only store what we need to, e.g. your username, email address, and password. Your actual password (e.g. Password123 - please don’t use this!) 
                when you sign up for an account is turned into random characters that we cant actually decrypt to get the actual thing. So, if anyone does manage to 
                hack our systems, they can’t get the actual password, just a bunch of random characters.

                <div class="helpQuestionHeader">Can I close my account?</div>
                Yes, but we hope you won’t.

                <div class="helpQuestionHeader">What happens when I close my account?</div>
                We'll confirm that you really want to delete your account and if you do, we’ll delete every bit of data that we have on you in our system. 
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
                <br />
                Site NOT for rollout
            </div>
        </div>


        <script>
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
