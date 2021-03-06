﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CloseAccount.aspx.cs" Inherits="FilmRecommendationSystem.CloseAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FILM RECOMMENDER | CLOSE ACCOUNT</title>
    <link rel="stylesheet" href="StyleSheet.css" />
</head>

<body class="body">
    <form runat="server">
        <p class="logo"><a href="Homepage.aspx">FILM RECOMMENDER</a></p>
        <br />
        <br />
        <br />
        <div class="navbar">
            <div class="dropdown">
                <button class="dropbtn">
                    <a href="MyAccount.aspx" class="menutext">MY ACCOUNT</a>
                </button>
                <div class="dropdown-content">
                    <a href="RecommendedFilms.aspx">RECOMMENDATIONS</a>
                    <a href="WatchList.aspx">WATCHLIST</a>
                    <a href="FavouriteFilms.aspx">FAVOURITES</a>
                    <asp:LinkButton ID="lnkbtnLogOut" OnClick="lnkbtnLogOut_Click" runat="server">LOG OUT</asp:LinkButton>
                </div>
            </div> 
        </div>


        <div class="search">
                <a onclick="hyplnkSearch_Clicked()" class="label">SEARCH</a>
            <div class="textentry-container">
                <input autocomplete="off" class="textentry-field" type="text" id="myInput" onkeyup="filterSearchFunction()" />
            </div>
        </div>
        
        <asp:Panel ID="pnlError" CssClass="mainContent" runat="server">
            <div class="header">Error</div>
            <div class="textSection">
                There was an error fulfilling your request; please try again later.
                <br />
                <br />
                <button type="button" id="btnReturnToHomepage" onclick="btnReturnToHomepage_Click()" class="proceedButton">Ok</button>
            </div>
        </asp:Panel>       

        <div class="mainContent">
            <div class="header">Are you sure you want to delete your account?</div>
            <div class="closeAccount-Container">
                You'll lose access to your:
                <br />
                <br />
                &#9989; recommendations
                <br />
                &#9989; watch list 
                <br />
                &#9989; favourite film 
                <br />
                and more!
                <br />
                <div class="closeAccountButtonContainer">
                    <button type="button" onclick="KeepMyAccount()" class="button">KEEP MY ACCOUNT</button>
                    <asp:Button ID="btnDeleteAccount" OnClientClick="return QuestionDeleteAccount()" OnClick="btnDeleteAccount_Click" class="button" runat="server" Text="DELETE MY ACCOUNT" />
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