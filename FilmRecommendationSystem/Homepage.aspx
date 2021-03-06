<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="FilmRecommendationSystem.Homepage" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ccl" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FILM RECOMMENDER</title>
    <link rel="stylesheet" href="StyleSheet.css" />
</head>

<body class="body" onload="onLoad()">
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

        <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>

        <asp:Panel ID="Panel2" runat="server"></asp:Panel>

        <div class="search">
                <a onclick="hyplnkSearch_Clicked()" class="label">SEARCH</a>
            <div class="textentry-container">
                <input autocomplete="off" class="textentry-field" type="text" id="myInput" onkeyup="filterSearchFunction()" />
                    <div id="mySearchDropdown" class="searchdropdown-content">
                        <a href="FilmInformation2.aspx">Terminator 2: Judgment Day (1991)</a>
                        <a>Little Women (2019)</a>
                    </div>
            </div>
        </div>

        <br />
        <br />
        <br />
        <br />
        <br />

        <div>
            <p class="main-paragraph">
                Not sure what to watch? Don't worry!
            </p>
            <p class="main-paragraph__explanation">
                The problem with trying to find a new film to where to begin?! Here, 
                all you have to do below is enter in films that you know you like, hit the button and bam. Personalised recommendations just for you!
            </p>
        </div>

        <div class="film">
            <p class="homepage-subHeader">
               What genre/ mood of movie do you want?
            </p>

            <div>
                <asp:Button ID="btnGenre" ToolTip="Gets you recommendations based on genre" OnClick="btnGenre_Click"
                    CssClass="recommendoption" runat="server" Text="genre" />
                <asp:Button ID="btnMood" ToolTip="Gets you recommendations based on mood" OnClick="btnMood_Click"
                    CssClass="recommendoption" runat="server" Text="mood" />
            </div>
            <br />
            <br />



            <asp:Panel ID="pnlSearchBy" runat="server">
                <asp:DropDownList ID="ddlGenres" CssClass="slctGenreMood" runat="server"></asp:DropDownList>
                <asp:DropDownList AutoPostBack="true" ID="ddlMoods" CssClass="slctGenreMood" runat="server"></asp:DropDownList>
            </asp:Panel>



            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="btnGetRecommendations" runat="server" Text="GET RECOMMENDATIONS" class="getrecommendations-button" OnClick="btnGetRecommendations_Click" />
            
            
            <asp:Panel ID="Panel1" CssClass="watchlist" runat="server"></asp:Panel>

        </div>

        <br />
        <br />
        <br />
        <asp:Panel ID="pnlRecommendations" runat="server" CssClass="watchlist">
            <div class="homepage-subHeader">Your recommendations</div>
            <br />
            <br />
        </asp:Panel>

        <br />
        <asp:Panel ID="pnlMostRecommendedFilms" CssClass="watchlist" runat="server">
            <div class="homepage-subHeader">Most recommended films</div>

        </asp:Panel>
        <br />
        <br />
        <br />
        <asp:Panel ID="pnlUserFavouriteFilms" runat="server" CssClass="watchlist">
            <div class="homepage-subHeader">User favourite films</div>
        </asp:Panel>




        <script>
            function onLoad() {
                //document.getElementById("secYourRecommendations").style.display = "none";
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

            function btnGenre_Clicked() {
                document.getElementById("ddlGenres").style.display = "inline";
            }

            function btnMood_Clicked() {
                document.getElementById("ddlMoods").style.display = "inline-block";
            }



            function GetRecommendations() {
                document.getElementById("secYourRecommendations").style.display = "block";
            }

            function AddGhostbustersToLabel() {
                document.getElementById("lblFilmsAdded").innerText += ", Ghostbusters (1984)";
                document.getElementById("filmSearchDropdown").style.visibility = "hidden";
                document.getElementById("filmName").value = "";
            }

            //search bar for adding films to recommended 
            function filterFunction() {
                document.getElementById("filmSearchDropdown").style.visibility = "visible";
                document.getElementById("filmSearchDropdown").classList.toggle("filmSearch-show");
                var input, filter, ul, li, a, i;
                input = document.getElementById("filmName");
                filter = input.value.toUpperCase();
                div = document.getElementById("filmSearchDropdown");
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

            //Search bar at top of screen
            function filterSearchFunction() {
                document.getElementById("mySearchDropdown").classList.toggle("show");
                var input, filter, ul, li, a, i;
                input = document.getElementById("myInput");
                filter = input.value.toUpperCase();
                div = document.getElementById("mySearchDropdown");
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
</body>
</html>
