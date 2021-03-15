<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FilmInformation.aspx.cs" Inherits="FilmRecommendationSystem.FilmInformation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Film recommender</title>
    <link rel="stylesheet" href="StyleSheet.css" />
    <script src="Scripts/jquery-3.5.1.js" type="text/javascript"></script>
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
                <input autocomplete="off" class="textentry-field" type="text" id="myInput" onkeyup="filterSearchFunction()" />
            </div>
        </div>

        <asp:Panel ID="pnlError" runat="server">
                <label class="page-subheader">Error</label>
                <br />
                <br />
                There was an error fulfilling your request; please try again later.
                <br />
                <br />
                <br />
                <button type="button" id="btnReturnToHomepage" onclick="btnReturnToHomepage_Click()" class="registerbutton">Ok</button>
                            <br />
                <br />
                <br />

        </asp:Panel>


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
                        <asp:ImageButton ID="imgbtnWatchLater" ImageUrl="~/Images/WatchLater.png" CssClass="image" OnClick="imgbtnWatchLater_Click" runat="server" style="margin-bottom: 0px" />
                    </div>
                </div>
                <div class="myRatingContainer">
                    <div class="textContainer">
                        <label class="headerText">My rating</label>
                        <asp:DropDownList ID="ddlRating" runat="server">
                            <asp:ListItem Value="0.5">0.5</asp:ListItem>
                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                            <asp:ListItem Text="1.5" Value="1.5"></asp:ListItem>
                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                            <asp:ListItem Text="2.5" Value="2.5"></asp:ListItem>
                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                            <asp:ListItem Text="3.5" Value="3.5"></asp:ListItem>
                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                            <asp:ListItem Text="4.5" Value="4.5"></asp:ListItem>
                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="btnAddEditRating" OnClick="btnAddEditRating_Click" runat="server"/>
                    </div>
                    <br />
                    <asp:Panel ID="Panel3" runat="server">
                            <asp:TextBox ID="txtNew" ToolTip="Enter Text Here" runat="server"></asp:TextBox>
                            <asp:DropDownList ID="ddlFilmMoods" runat="server"></asp:DropDownList>
                            <asp:Button ID="btnAssignTag" OnClientClick="return btnAssignTag_Clicked()" OnClick="btnAssignTag_Click" runat="server" Text="Add tag to film" />
                        </asp:Panel>
                </div>

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
                <label class="headerText">Want more information</label>
                <br />
                <br />
                <asp:HyperLink ID="hyplnkMoreInformation" runat="server">HyperLink</asp:HyperLink>
                <asp:Panel ID="pnlMyTags" runat="server">
                    <br />
                    <br />
                    <label class="headerText">My tags</label>
                </asp:Panel>
                <br />
                <br />
            </asp:Panel>

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
            $(function () {
                var $txt = $('input[id$=txtNew]');
                var $ddl = $('select[id$=ddlFilmMoods]');
                var $items = $('select[id$=ddlFilmMoods] option');

                $txt.keyup(function () {
                    searchDdl($txt.val());
                });

                function searchDdl(item) {
                    $ddl.empty();
                    var exp = new RegExp(item, "i");
                    var arr = $.grep($items,
                        function (n) {
                            return exp.test($(n).text());
                        });

                    if (arr.length > 0) {
                        countItemsFound(arr.length);
                        $.each(arr, function () {
                            $ddl.append(this);
                            $ddl.get(0).selectedIndex = 0;
                        }
                        );
                    }
                    else {
                        countItemsFound(arr.length);
                        $ddl.append("<option>No Items Found</option>");
                    }
                }

                function countItemsFound(num) {
                    $("#para").empty();
                    if ($txt.val().length) {
                        $("#para").html(num + " items found");
                    }

                }
            });


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
