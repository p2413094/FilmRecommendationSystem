<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FilmInformation.aspx.cs" Inherits="FilmRecommendationSystem.FilmInformation" %>

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
        <asp:Panel ID="pnlError" runat="server">
                <label class="page-subheader">Error</label>
                <br />
                <br />
                There was an error fulfilling your request; please try again later.
                <br />
                <br />
                <br />
                <button type="button" id="btnReturnToHomepage" onclick="btnReturnToHomepage_Click()" class="registerbutton">Ok</button>
        </asp:Panel>


        <asp:Panel ID="pnlFilmInformation" runat="server">
        <div class="film">
            <div class="header">
                <asp:Label ID="lblTitle" runat="server"></asp:Label>
            </div>
            <br />
            <br />
            <br />

            <div class="container">
                <div class="container-image">
                    <asp:Image ID="imgFilmPoster" runat="server" CssClass="image" />

                    <div class="overlay-left">
                        <img id="imgWatchLater" onclick="imgWatchLaterClick()" class="watchlaterfavouriteicon" src="Images/WatchLater.png" />
                    </div>
                    <div class="overlay-right">
                        <img id="imgFavourite" onclick="imgFavouriteClick()" class="watchlaterfavouriteicon" src="Images/Favourite.png" />
                    </div>    
                </div>
                <br />

                <div class="tag-container">
                    <div class="tag-heading">My tags: </div>
                    <br />
                    <div id="divTags" class="tags" >
                        <label id="lblTag" onclick="lblTag_Clicked()">action1</label>
                        sci-fi, 
                    </div>
                    <br />
                    <button onclick="btnAddTagClick()" id="btnAddTag" class="button-addtag" type="button">ADD TAG</button>
                    <div class="tagentrycontainer">
                        <input id="txtTag" class="tagentryfield" type="text" placeholder="Enter new tag here..." />
                    </div>
                </div>
                <br />
                <br />
                <br />

                <div class="tag-container">
                    <div class="tag-heading">Assigned mood: </div>
                    <div id="divMoods" class="tags">
                        <label id="lblMood" onclick="lblMood_Clicked()">heart-warming</label>
                        oscar-worthy, 
                    </div>
                    <br />
                    <br />
                    <br />
                    <button onclick="btnAddMoodClick()" class="button-addtag" type="button">ADD MOOD</button>
                    <div class="tagentrycontainer">
                        <input id="txtMood" class="tagentryfield" type="text" placeholder="Enter new mood here..." />
                    </div>
                </div>
            </div>
            
            <div class="filminformation">
                <div class="information-header">Description</div>
                <asp:Label ID="lblPlot" runat="server"></asp:Label>
                <br />
                <br />

                <div class="information-header">Genre</div>
                <asp:Label ID="lblGenre" runat="server"></asp:Label>
                <br />
                <br />

                <div class="information-header">Age rating</div>
                <asp:Label ID="lblAgeRating" runat="server"></asp:Label>
                <br />
                <br />
               
                <div class="information-header">Director</div>
                <asp:Label ID="lblDirector" runat="server"></asp:Label>
                <br />
                <br />

                <div class="information-header">Released</div>
                <asp:Label ID="lblReleased" runat="server"></asp:Label>
                <br />
                <br />

                <div class="information-header">Runtime</div>
                <asp:Label ID="lblRuntime" runat="server"></asp:Label>
                <br />   
                <asp:Panel ID="Panel1" runat="server"></asp:Panel>
            </div>
        </div>

        </asp:Panel>

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

        <script type="text/javascript">
            function btnReturnToHomepage_Click() {
                location.href = "Homepage.aspx";
            }
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
                var newTag = document.getElementById("txtTag").value,
                    tags = document.getElementById("divTags");
                tags.innerHTML += newTag;
            }

            function btnAddMoodClick() {
                var newMood = document.getElementById("txtMood").value,
                    mood = document.getElementById("divMoods");
                mood.innerHTML += newMood;
            }

            function lblTag_Clicked() {
                var confirmMessage = confirm("Delete tag?");
                if (confirmMessage == true) {
                    alert("Tag deleted");
                    document.getElementById("lblTag").style.display = "none";
                }
                else {
                    alert("Tag not deleted")
                }
            }

            function lblMood_Clicked() {
                var confirmMessage = confirm("Delete mood?");
                if (confirmMessage == true) {
                    alert("Mood deleted");
                    document.getElementById("lblMood").style.display = "none";
                }
                else {
                    alert("Mood not deleted")
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
</form>
</body>
</html>
