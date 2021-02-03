<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="FilmRecommendationSystem.Homepage" %>

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

        <div class="search">
            <div class="label">
                SEARCH
            </div>
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
                <button type="button" id="btnGenre" onclick="btnGenre_Clicked()" class="recommendoption">genre</button>
                <button type="button" id="btnMood" onclick="btnMood_Clicked()" class="recommendoption">mood</button>
                <button type="button" id="btnBoth" onclick="btnBoth_Clicked()" class="recommendoption">both</button>
            </div>
            <br />
            <br />

            <div>
                <asp:DropDownList ID="ddlGenres" runat="server" CssClass="slctGenreMood"></asp:DropDownList>
            </div>


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
        <div class="homepage-mostRecommendedFilms">
            Most recommended films
        </div>
        <br />
        <section class="watchlist">
            <a href="FilmInformation.aspx">
                <img src="Images/Terminator.jpg" class="image" />
            </a>
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="Images/King Kong.jpg" CssClass="image" OnClick="ImageButton1_Click" />
            <img src="Images/TCM.jpg" class="image" />
            <img src="Images/Dunkirk.jpg" class="image" />
            <img src="Images/District 9.jpg" class="image" />
            <img src="Images/Tron Legacy.jpg" class="image" />
            <img src="Images/Ghostbusters.jpg" class="image" />
        </section>

        <br />
        <br />
        <br />
        <div class="homepage-mostRecommendedFilms">
            User favourite films
        </div>

        <section class="watchlist">
            <img src="Images/Endgame.jpg" class="image" />
            <img src="Images/Nosferatu.jpg" class="image" />
            <img src="Images/Bridesmaids.jpg" class="image" />
            <img src="Images/The World's End.jpg" class="image" />
            <img src="Images/Dunkirk.jpg" class="image" />
            <img src="Images/Tron Legacy.jpg" class="image" />
            <img src="Images/Ghostbusters.jpg" class="image" />
        </section>

        <script>

            function onLoad() {
                //document.getElementById("btnGetRecommendations").style.display = "none";
                document.getElementById("secYourRecommendations").style.display = "none";
                document.getElementById("slctGenre").style.display = "none";
                document.getElementById("slctMood").style.display = "none";
                document.getElementById("ddlGenres").style.display = "none";
            }

            function btnGenre_Clicked() {
                document.getElementById("slctGenre").style.display = "inline";
                document.getElementById("btnGetRecommendations").style.display = "inline";

                document.getElementById("lstGenres").style.display = "inline";
            }

            function btnMood_Clicked() {
                document.getElementById("slctMood").style.display = "inline";
                document.getElementById("btnGetRecommendations").style.display = "inline"
            }

            function btnBoth_Clicked() {
                document.getElementById("slctGenre").style.display = "inline";
                document.getElementById("slctMood").style.display = "inline";
                document.getElementById("btnGetRecommendations").style.display = "inline";
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
