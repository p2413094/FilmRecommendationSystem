<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilmInformation2.aspx.cs" Inherits="FilmInformation2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Film recommender</title>
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
        <br />
        <br />
        <br />
        <br />

        <section class="film">
            <div class="header">Terminator 2: Judgment Day (1991)</div>
            <br />
            <br />
            <br />

            <div class="container">
                <div>
                    <img src="Images/Terminator 2.jpg" alt="Avatar" class="image" />
                    <div class="overlay-left">
                        <img id="imgWatchLater" onclick="imgWatchLaterClick()" class="watchlaterfavouriteicon" src="Images/WatchLater.png" />
                    </div>
                    <div class="overlay-right">
                        <img id="imgFavourite" onclick="imgFavouriteClick()" class="watchlaterfavouriteicon" src="Images/Favourite.png" />
                    </div>    
                </div>
                
                <div>
                    <div class="rating-container">
                        <div class="rating-heading">My rating:</div>
                        <div id="imgRating" class="ratingimage-container" onclick="imgRatingClick()">
                            <img id="star1" src="Images/Favourite.png" class="ratingimage-imagesize" />
                            <img id="star2" src="Images/Favourite.png" class="ratingimage-imagesize" />
                            <img id="star3" src="Images/Favourite.png" class="ratingimage-imagesize" />
                            <img id="star4" src="Images/Favourite.png" class="ratingimage-imagesize" />
                            <img id="star5" src="Images/Favourite.png" class="ratingimage-imagesize" />
                        </div>    
                    </div>
                </div>

                <div>
                    <div class="tag-container">
                        <div class="tag-heading">My tags: </div>
                        <div id="divTags" class="tags">
                            action, 
                            
                        </div>
                        <br />
                        <br />
                        <br />
                        <br />
                        <button onclick="btnAddTagClick()" id="btnAddTag" class="button-addtag" type="button">ADD TAG</button>
                        <div class="tagentrycontainer">
                            <input id="txtTag" class="tagentryfield" type="text" placeholder="Enter new tag here..." />
                        </div>
                    </div>
                </div>
            </div>
            
            <div class="filminformation">
                <div class="information-header">Description</div>
                <br />
                A cyborg, identical to the one who failed to kill Sarah Connor, must now protect her teenage son, John Connor, 
                from a more advanced and powerful cyborg.

                <br />

                <p class="information-header">Genre</p>
                Action, Sci-Fi
                <br />
                <br />

                <p class="information-header">Age rating</p>
                <img src="Images/15.png" class="image-agerating" alt="15" />
                <br />
                <br />
                
                <p class="information-header">Director</p>
                James Cameron
                <br />
                <br />
                
                <p class="information-header">Runtime</p>
                137 mins
                <br />   
            </div>
        </section>

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

        <script type="text/javascript">
            function imgWatchLaterClick() {
                    document.getElementById("imgWatchLater").src = "Images/WatchLaterAdded.png";
            }

            function imgFavouriteClick() {
                    document.getElementById("imgFavourite").src = "Images/FavouriteInList.png";
            }

            function imgRatingClick() {
                    document.getElementById("star1").src = "Images/FavouriteInList.png";
                    document.getElementById("star2").src = "Images/FavouriteInList.png";
                    document.getElementById("star3").src = "Images/FavouriteInList.png";
                    document.getElementById("star4").src = "Images/FavouriteInList.png";
                    document.getElementById("star5").src = "Images/FavouriteInList.png";
            }

            function btnAddTagClick() {
                    var newTag = document.getElementById("txtTag").value;
                    var tags = document.getElementById("divTags");
                    tags.innerHTML += newTag;
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
</form>
</body>
</html>