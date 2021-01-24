<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TheTerminator.aspx.cs" Inherits="TheTerminator" %>

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
                <input autocomplete="off" class="textentry-field" type="text" oninput="myFunction()" id="myInput" onkeyup="filterFunction()">
                <div>
                    <div id="myDropdown" class="searchdropdown-content">
                        <a href="TheTerminator.aspx">The Terminator (1984)</a>
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
            <div class="header">The Terminator (1984)</div>
            <br />
            <br />
            </div>
            <br />

            <div class="container">
                <img src="Images/Terminator.jpg" alt="Avatar" class="image">   
                <div class="overlay-left">
                    <img class="watchlaterfavouriteicon" src="Images/WatchLater.png">
                </div>
                <div class="overlay-right">
                    <img id="imgFavourite" onclick="imgFavouriteClick()" class="watchlaterfavouriteicon" src="Images/Favourite.png">
                </div>
            </div>

            <div class="filminformation">
                <div class="information-header">Description</div>
                <br />
                A human soldier is sent from 2029 to 1984 to stop an almost indestructible cyborg killing machine, sent from the same year,
                which has been programmed to execute a young woman whose unborn son is the key to humanity's future salvation.   
                <br />

                <p class="information-header">Genre</p>
                Action, Sci-Fi
                <br />
                <br />

                <p class="information-header">Age rating</p>
                <img src="Images/18.png" class="image-agerating" alt="15">
                <br />
                <br />
                
                <p class="information-header">Director</p>
                James Cameron
                <br />
                <br />
                
                <p class="information-header">Runtime</p>
                107 min
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
            function imgFavouriteClick() {
                document.getElementById("imgFavourite").src = "Images/FavouriteInList.png";
            }

            /* When the user clicks on the button,
            toggle between hiding and showing the dropdown content */
            function myFunction() {
            document.getElementById("myDropdown").classList.toggle("show");
            }

            function filterFunction() {
            var input, filter, ul, li, a, i;
            input = document.getElementById("myInput");
            filter = input.value.toUpperCase();
            div = document.getElementById("myDropdown");
            a = div.getElementsByTagName("a");
            for (i = 0; i < a.length; i++) {
                txtValue = a[i].textContent || a[i].innerText;
                if (txtValue.toUpperCase().indexOf(filter) > -1) {
                a[i].style.display = "";
                } else {
                a[i].style.display = "none";
                }
            }}
        </script>
</form>
</body>
</html>
