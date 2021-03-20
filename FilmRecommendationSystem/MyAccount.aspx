<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyAccount.aspx.cs" Inherits="FilmRecommendationSystem.MyAccount" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FILM RECOMMENDER | MY ACCOUNT</title>
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

        <asp:Panel ID="pnlMyAccount" CssClass="mainContent" runat="server">
            <div class="header">Account details</div>
            <div class="myAccount">
                <div class="section-container">
                        Email address:<asp:Label ID="lblEmailAddress" runat="server"></asp:Label>
                </div>

                <div class="section-container-password">
                    <div class="password">
                        Password: *************
                    </div>
                    <div class="changepasswordContainer">
                        <img class="changepasswordIcon" id="imgChangePassword" onclick="imgChangePassword_Click()" 
                             src="Images/Edit_icon.png" />
                    </div>
                </div>

                <div class="section-container">
                    Last login: <asp:Label ID="lblLastLogin" runat="server"></asp:Label>
                </div>
                <div class="closeAccount-Container">
                    <button type="button" id="btnCloseAccount" onclick="btnCloseAccount_Click()"  class="proceedButton">CLOSE ACCOUNT</button>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="pnlStaffAdmin" CssClass="mainContent" runat="server">
            <label class="header">Management functions</label>
            <br /><br /><br /><br /><br /><br />
            <asp:Button ID="btnViewUsers" OnClick="btnViewUsers_Click" runat="server" CssClass="proceedButton" Text="VIEW ALL USERS" />
            <asp:Button ID="btnViewFilms" OnClick="btnViewFilms_Click" CssClass="proceedButton" runat="server" Text="VIEW ALL FILMS" />
            <asp:Button ID="btnViewStaffMembers" OnClick="btnViewUsers_Click" CssClass="proceedButton" runat="server" Text="VIEW ALL STAFF MEMBERS" />
            <asp:Button ID="btnViewPreviousStaffMembers" OnClick="btnViewPreviousStaffMembers_Click" runat="server" CssClass="proceedButton" Text="VIEW ALL PREVIOUS STAFF MEMBERS" />
        </asp:Panel>

        <asp:Panel ID="pnlError" CssClass="mainContent" runat="server">
            <div class="header">Error</div>
            <div class="textSection">
                There was an error fulfilling your request; please try again later.
                <br />
                <br />
                <button type="button" id="btnReturnToHomepage" onclick="btnReturnToHomepage_Click()" class="proceedButton">Ok</button>
            </div>
        </asp:Panel>      
        
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

            function btnReturnToHomepage_Click() {
                location.href = "Homepage.aspx";
            }

            function imgChangePassword_Click() {
                    location.href = "ResetPassword.aspx";
            }

            function btnCloseAccount_Click() {
                    location.href = "CloseAccount.aspx"
            }

            function btnViewFilms_Clicked() {
                location.href = "AllFilms.aspx";
            }
        </script>
    </form>
</body>
</html>