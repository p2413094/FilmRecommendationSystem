<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="FilmRecommendationSystem.Homepage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FILM RECOMMENDER</title>
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

            <p class="main-paragraph">Not sure what to watch? Don't worry!</p>
            <p class="main-paragraph__explanation">
                The problem with trying to find a new film to where to begin?! Here, 
                all you have to do below is enter in films that you know you like, hit the button and bam. Personalised recommendations just for you!
            </p>

        <asp:Panel ID="Panel1" CssClass="homepage" runat="server">
            <asp:Panel ID="pnlFilmSection" CssClass="recommenderSelectionGenreMoodContainer" runat="server">
                <p class="homepage-subHeader">First, search by genre, or mood?</p>
                <div class="GenreMoodFirstSelector">
                    <asp:Button ID="btnGenre" ToolTip="Gets you recommendations based on genre" OnClick="btnGenre_Click"
                        CssClass="recommendoption" runat="server" Text="genre" />
                    <asp:Button ID="btnMood" ToolTip="Gets you recommendations based on mood" OnClick="btnMood_Click"
                        CssClass="recommendoption" runat="server" Text="mood" />
                </div>
                <asp:Panel ID="pnlSearchBy" CssClass="GenreMoodSecondSelector" runat="server">
                    <asp:DropDownList ID="ddlGenres" AutoPostBack="true" CssClass="slctGenreMood" runat="server" OnSelectedIndexChanged="ddlGenres_SelectedIndexChanged"></asp:DropDownList>
                    <asp:DropDownList ID="ddlMoods" AutoPostBack="true" CssClass="slctGenreMood" runat="server" OnSelectedIndexChanged="ddlGenres_SelectedIndexChanged"></asp:DropDownList>
                </asp:Panel>
            </asp:Panel>

           <asp:Panel ID="pnlRecommendations"  runat="server" CssClass="recommenderSelectionGenreMoodContainer">
                <div class="homepage-subHeader">Your recommendations</div>
            </asp:Panel>
            
            <asp:Panel ID="pnlMostRecommendedFilms" runat="server" CssClass="recommenderSelectionGenreMoodContainer">
                <div class="homepage-subHeader">Most recommended films</div>
            </asp:Panel>

            <asp:Panel ID="pnlUserFavouriteFilms" runat="server" CssClass="recommenderSelectionGenreMoodContainer">
                <div class="homepage-subHeader">User favourite films</div>
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
    </asp:Panel>

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
</body>
</html>
