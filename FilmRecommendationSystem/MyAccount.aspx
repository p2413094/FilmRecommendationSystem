<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyAccount.aspx.cs" Inherits="FilmRecommendationSystem.MyAccount" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Film recommender | My account</title>
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
        <div class="navbar">
            <div class="dropdown">
                <button class="dropbtn">MY ACCOUNT 
                    <i class="fa fa-caret-down"></i>
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
                    <br />
                    <br />
                    <br />
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


        <asp:Panel ID="pnlMyAccount" CssClass="mainContent" runat="server">
            <asp:Panel ID="Panel2" CssClass="header" runat="server">Account details</asp:Panel>



            <div class="myAccount">
                <div class="section-container">
                        Email address:<asp:Label ID="lblEmailAddress" runat="server"></asp:Label>
                </div>
                <div class="section-container-password">
                    Password: *************
                </div>
                <div class="changepasswordcontainer">
                    <img class="changepasswordicon" id="imgChangePassword" onclick="imgChangePassword_Click()" 
                     src="Images/Edit icon.png" />
                </div>
                <div class="section-container">
                    Last login: <asp:Label ID="lblLastLogin" runat="server"></asp:Label>
                </div>
            <button type="button" id="btnCloseAccount" onclick="btnCloseAccount_Click()"  class="proceedButton">CLOSE ACCOUNT</button>

            </div>
        </asp:Panel>

        <asp:Panel ID="pnlStaffAdmin" CssClass="mainContent" runat="server">
            <asp:Panel ID="Panel1" CssClass="header" runat="server">
                <asp:Label ID="lblStaffAdminHeader" runat="server"></asp:Label>
            </asp:Panel>
            <asp:Button ID="btnViewUsers" OnClick="btnViewUsers_Click" runat="server" CssClass="proceedButton" Text="VIEW USERS" />
            <button onclick="btnViewFilms_Clicked" class="proceedButton">VIEW ALL FILMS</button>
            <asp:Button ID="btnViewStaffMembers" OnClick="btnViewStaffMembers_Click" CssClass="proceedButton" runat="server" Text="VIEW ALL STAFF MEMBERS" />
            <asp:Button ID="btnViewPreviousStaffMembers" OnClick="btnViewPreviousStaffMembers_Click" runat="server" CssClass="proceedButton" Text="VIEW ALL PREVIOUS STAFF MEMBERS" />
        </asp:Panel>


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

            function btnReturnToHomepage_Click() {
                location.href = "Homepage.aspx";
            }

            function imgChangePassword_Click() {
                    location.href = "ResetPassword.aspx";
            }

            function btnCloseAccount_Click() {
                    location.href = "CloseAccount.aspx"
            }

            function btnViewUsers_Clicked() {
                location.href = "AllUsers.aspx";
            }

            function btnViewFilms_Clicked() {
                location.href = "AllFilms.aspx";
            }
        </script>
    </form>
</body>
</html>