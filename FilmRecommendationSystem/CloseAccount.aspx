<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CloseAccount.aspx.cs" Inherits="FilmRecommendationSystem.CloseAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Film recommender | Close account</title>
    <link rel="stylesheet" href="StyleSheet.css" />
</head>

<body class="body">
    <form runat="server">
        <p class="logo textlink">
            <a href="Homepage.aspx">FILM RECOMMENDER</a>
        </p>

        <br />
        <br />
        <br />
        <<div class="navbar">
            <div class="dropdown">
                <button class="dropbtn">
                    <a href="MyAccount.aspx" class="menutext">MY ACCOUNT</a>
                </button>
                <div class="dropdown-content">

                    <div class="imagecontainer">
                        <img class="imagedimensions" src="Images/RecommendedFilms.png" />
                    </div>
                    <a href="RecommendedFilms.aspx">RECOMMENDATIONS</a>
                    <br />
                    <br />
                    <br />

                    <div class="imagecontainer">
                        <img class="imagedimensions" src="Images/WatchLater.png" />
                    </div>
                    <a href="WatchList.aspx">WATCHLIST</a>
                    <br />
                    <br />
                    <br />

                    <div class="imagecontainer">
                        <img class="imagedimensions" src="Images/FavouriteInList.png" />
                    </div>
                    <a href="FavouriteFilms.aspx">FAVOURITES</a>
                    <br />
                    <br />
                    <br />

                    <div class="imagecontainer">
                        <img class="imagedimensions" src="Images/Log out.png" />
                    </div>
                    <a href="Homepage.aspx">LOG OUT</a>
                </div>
              </div> 
            </div>

        <br />
        <br />
        <br />
        <br />
        <br />

        <div class="search">
                <a onclick="hyplnkSearch_Clicked()" class="label">SEARCH</a>
            <div class="textentry-container">
                <input autocomplete="off" class="textentry-field" type="text" id="myInput" onkeyup="filterSearchFunction()" />
            </div>
        </div>
        
        <asp:Panel ID="pnlError" CssClass="mainContent" runat="server">
            <div class="header">Error</div>
            There was an error fulfilling your request; please try again later.
            <br />
            <br />
                <br />
                <button type="button" id="btnReturnToHomepage" onclick="btnReturnToHomepage_Click()" class="proceedButton">Ok</button>
        </asp:Panel>

        <div class="mainContent">
            <div class="header">Are you sure you want to delete your account?</div>
                You'll lose access to your:
                <br />
                <br />
                &#9989; personalised film recommendations
                <br />
                &#9989; personal favourite film manager 
                <br />
                &#9989; personal watch list
                <br />
                and more!
                <br />
            <div class="closeAccountButtonContainer">
                <button type="button" onclick="KeepMyAccount()" class="button">KEEP MY ACCOUNT</button>
                <asp:Button ID="btnDeleteAccount" OnClientClick="return QuestionDeleteAccount()" OnClick="btnDeleteAccount_Click" class="rightButton" runat="server" Text="DELETE MY ACCOUNT" />

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

            function QuestionDeleteAccount() {
                var confirmMessage = confirm("Are you sure you want to delete your account?");
                if (confirmMessage == true) {
                    alert("Your account has been successfully deleted");
                    return true;
                }
                else {
                    alert("Your account was not deleted");
                    location.href = "Homepage.aspx";

                    return false;
                }
            }

            function KeepMyAccount() {
                alert("Your account was not deleted");
                location.href="Homepage.aspx";
            }

        </script>
    </form>
</body>
</html>