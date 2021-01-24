<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Homepage.aspx.cs" Inherits="Homepage" %>

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

        <section class="search">
            <div class="textentry-label">
                SEARCH
            </div>
            <div class="textentry-container">
                <input autocomplete="off" class="textentry-field" type="text" id="myInput" onkeyup="filterSearchFunction()" />
                <div>
                    <div id="mySearchDropdown" class="searchdropdown-content">
                        <a href="FilmInformation2.aspx">Terminator 2: Judgment Day (1991)</a>
                        <a>Little Women (2019)</a>
                    </div>
                </div>
                <br />
                <br />
            </div>
        </section>

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

        <br />
        <br />
        <br />
        <br />

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
                <select id="slctGenre" class="slctGenreMood">
                    <option class="slctGenreMood-options">action</option>
                    <option class="slctGenreMood-options">romance</option>
                    <option class="slctGenreMood-options">sci-fi</option>
                </select>
            </div>
            
            <div>
                <select id="slctMood" class="slctGenreMood">
                    <option class="slctGenreMood-options">incredible</option>
                    <option class="slctGenreMood-options">oscar-worthy</option>
                    <option class="slctGenreMood-options">heart-warming</option>
                </select>
            </div>

            <br />
            <br />
            <br />
            <button id="btnGetRecommendations" onclick="GetRecommendations()" class="getrecommendations-button" 
                type="button">GET RECOMMENDATIONS</button>
        </div>

        <br />
        <br />
        <br />
        <section id="secYourRecommendations" class="watchlist">
            <div class="homepage-subHeader">
                Your recommendations
            </div>
            <a href="FilmInformation.aspx">
                <img src="Images/Terminator.jpg" class="image" />
            </a>
            <img id="recommendImg1" src="Images/Alien.jpg" class="image" />
            <img id="recommendImg2" src="Images/District 9.jpg" class="image" />
            <img id="recommendImg3" src="Images/Ghostbusters.jpg" class="image" />
            <br />
            <br />
            <br />
        </section>

        <br />
        <div class="homepage-mostRecommendedFilms">
            Most recommended films
        </div>
        <br />
        <section class="watchlist">
            <a href="FilmInformation.aspx">
                <img src="Images/Terminator.jpg" class="image" />
            </a>
            <img src="Images/King Kong.jpg" class="image" />
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
                document.getElementById("btnGetRecommendations").style.display = "none";
                document.getElementById("secYourRecommendations").style.display = "none";
                document.getElementById("slctGenre").style.display = "none";
                document.getElementById("slctMood").style.display = "none";
            }

            function btnGenre_Clicked() {
                document.getElementById("slctGenre").style.display = "inline";
                document.getElementById("btnGetRecommendations").style.display = "inline";
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
                var ddlGenre = document.getElementById("slctGenre"),
                    ddlMood = document.getElementById("slctMood"),
                    selectedGenre = ddlGenre.value,
                    selectedMood = ddlMood.value;

                if (selectedGenre == "romance") {
                    document.getElementById("recommendImg1").src = "Images/Bridesmaids.jpg";
                    document.getElementById("recommendImg2").src = "Images/Titanic.jpg";
                    document.getElementById("recommendImg3").src = "Images/LittleWomen.jpg";
                }

                if (selectedGenre == "sci-fi") {
                    document.getElementById("recommendImg1").src = "Images/Dune.jpg";
                    document.getElementById("recommendImg2").src = "Images/BladeRunner2049.jpg";
                    document.getElementById("recommendImg3").src = "Images/Tron%20Legacy.jpg";
                }

                if (selectedMood == "oscar-worthy") {
                    document.getElementById("recommendImg1").src = "Images/King Kong.jpg";
                    document.getElementById("recommendImg2").src = "Images/Parasite.jpg";
                    document.getElementById("recommendImg3").src = "Images/The%20Shawshank%20Redemption.jpg";
                }
                
                if (selectedMood == "heart-warming") {
                    document.getElementById("recommendImg1").src = "Images/WhenHarryMetSally.jpg";
                    document.getElementById("recommendImg2").src = "Images/TheMartian.jpg";
                    document.getElementById("recommendImg3").src = "Images/ThePursuitOfHappyness.jpg";
                }

                if (selectedGenre == "sci-fi" && selectedMood == "oscar-worthy") {
                    document.getElementById("recommendImg1").src = "Images/King Kong.jpg";
                    document.getElementById("recommendImg2").src = "Images/BladeRunner2049.jpg";
                    document.getElementById("recommendImg3").src = "Images/Aliens.jpg";
                }
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
