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
        
        <br />
            <br />
            <br />

        <asp:Panel ID="pnlFilmInformation" CssClass="filmInformation" runat="server">
            <div class="headerContainer">
                <asp:Label ID="lblTitle" CssClass="headerText" runat="server"></asp:Label>
            </div>
            <div class="imageContainer">
                <asp:Image ID="imgFilmPoster" ImageUrl="~/Images/King Kong.jpg" runat="server" CssClass="image" />
                <div class="overlayContainer">
                    <div class="leftItem">
                        <asp:ImageButton ID="imgbtnFavourite" ImageUrl="~/Images/Favourite.png" CssClass="image" OnClick="imgbtnFavourite_Click" runat="server" />
                    </div>
                    <div class="rightItem">
                        <asp:ImageButton ID="imgbtnWatchLater" ImageUrl="~/Images/WatchLater.png" CssClass="image" OnClick="imgbtnWatchLater_Click" runat="server" />
                    </div>
                </div>
                <asp:Panel ID="Panel11" CssClass="ratingContainer" runat="server">
                    <asp:Image ID="Image3" CssClass="image" runat="server" />
                    <asp:Image ID="Image4" runat="server" />
                    <asp:Image ID="Image5" runat="server" /><asp:Image ID="Image6" runat="server" />
                    <asp:Image ID="Image7" runat="server" />
                </asp:Panel>


            </div>
            <asp:Panel ID="pnlContentContainer" CssClass="contentContainer" runat="server">
                <label class="headerText">Description</label>
                <br />
                <br />
                <asp:Label ID="lblPlot" runat="server"></asp:Label>
                <br />
                <br />
                <label class="headerText">Genre</label>
                <br />
                <br />
                <asp:Label ID="lblGenre" runat="server"></asp:Label>
                <br />
                <br />
                <label class="headerText">Age rating</label>
                <br />
                <br />
                <asp:Label ID="lblAgeRating" runat="server"></asp:Label>
                <br />
                <br />
                <label class="headerText">Director</label>
                <br />
                <br />
                <asp:Label ID="lblDirector" runat="server"></asp:Label>
                <br />
                <br />
                <label class="headerText">Released</label>
                <br />
                <br />
                <asp:Label ID="lblReleased" runat="server"></asp:Label>
                <br />
                <br />
                <label class="headerText">Runtime</label>
                <br />
                <br />
                <asp:Label ID="lblRuntime" runat="server"></asp:Label>
                <br />
                <br />
                <asp:Panel ID="pnlMyTags" runat="server">
                    <label class="headerText">My tags</label>
                    <br />
                </asp:Panel>
                <br />
                <br />
            </asp:Panel>

        </asp:Panel>
            <div class="film">
                <div class="container">
                    <div class="container-image">
                        <div class="overlay-left">
                            <img id="imgWatchLater" onclick="imgWatchLaterClick()" class="watchlaterfavouriteicon" src="Images/WatchLater.png" />
                        </div>
                        <div class="overlay-right">
                            <img id="imgFavourite" onclick="imgFavouriteClick()" class="watchlaterfavouriteicon" src="Images/Favourite.png" />
                        </div>    
                    </div>
                    <br />
                </div>
            </div>

        <br />
        <br />

        <asp:Panel ID="Panel3" runat="server">
            <asp:DropDownList ID="ddlFilmMoods" runat="server"></asp:DropDownList>
            <asp:Button ID="btnAssignTag" OnClientClick="return btnAssignTag_Clicked()" OnClick="btnAssignTag_Click" runat="server" Text="Add tag to film" />
        </asp:Panel>

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

            function btnAssignTag_Clicked() {
                var confirmMessage = confirm("Add tag to film?");
                if (confirmMessage == true) {
                    alert("Tag added!");
                    return true;
                }
                else {
                    alert("Tag not added")
                    return false;
                }
            }

            function btnRemoveTag_Clicked() {
                var confirmMessage = confirm("Remove tag from film?");
                if (confirmMessage == true) {
                    alert("Tag removed!");
                    return true;
                }
                else {
                    alert("No changes made")
                    return false;
                }
            }


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
