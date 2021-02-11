<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CloseAccount.aspx.cs" Inherits="CloseAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Film recommender | Close account</title>
    <link rel="stylesheet" href="StyleSheet.css" />
</head>

<body class="body">
    <form runat="server">
        <p class="logo textlink">
            <a href="Homepage.aspx">FILM RECOMMENDER</a>
        </p>

        <br />
        <br />
        <br />
        <<div class="navbar">
            <div class="dropdown">
                <button class="dropbtn">
                    <a href="MyAccount.aspx" class="menutext">MY ACCOUNT</a>
                </button>
                <div class="dropdown-content">

                    <div class="imagecontainer">
                        <img class="imagedimensions" src="Images/RecommendedFilms.png" />
                    </div>
                    <a href="RecommendedFilms.aspx">RECOMMENDATIONS</a>
                    <br />
                    <br />
                    <br />

                    <div class="imagecontainer">
                        <img class="imagedimensions" src="Images/WatchLater.png" />
                    </div>
                    <a href="WatchList.aspx">WATCHLIST</a>
                    <br />
                    <br />
                    <br />

                    <div class="imagecontainer">
                        <img class="imagedimensions" src="Images/FavouriteInList.png" />
                    </div>
                    <a href="FavouriteFilms.aspx">FAVOURITES</a>
                    <br />
                    <br />
                    <br />

                    <div class="imagecontainer">
                        <img class="imagedimensions" src="Images/Log out.png" />
                    </div>
                    <a href="Homepage.aspx">LOG OUT</a>
                </div>
              </div> 
            </div>

        <br />
        <br />
        <br />
        <br />
        <br />

        <section class="search">
            <div class="textentry-label">
                SEARCH
            </div>
            <div class="textentry-container">
                <input autocomplete="off" class="textentry-field" type="text" oninput="myFunction()" 
                    id="myInput" onkeyup="filterFunction()" />
                <div>
                    <div id="myDropdown" class="searchdropdown-content">
                        <a href="FilmInformation2.aspx">The Terminator (1984)</a>
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
        <div class="account">
            <p class="page-header">
                Close account
            </p>
        </div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />

        <div class="account">            
            <p class="page-subheader">
                Are you sure you want to delete your account?  
            </p>
            <div>
                You'll lose access to your:
                <br />
                <br />
                &#9989; personalised film recommendations
                <br />
                &#9989; personal favourite film manager 
                <br />
                &#9989; personal watch list
                <br />
                and more!
                <br />
            </div>
            <div>
                
            </div>
            <br />
            <br />
            <asp:Button ID="btnDeleteAccount" OnClick="btnDeleteAccount_Click" class="deleteaccountbutton" runat="server" Text="DELETE MY ACCOUNT" />
            
            <button type="button" onclick="KeepMyAccount()" class="keepmyaccountbutton">KEEP MY ACCOUNT</button>
        </div>

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
            function btnLogin_Click() {
                document.getElementById("btnLogin").onclick = function () {
                    location.href = "Homepage.aspx";
            };
            }

            function QuestionDeleteAccount() {
                var confirmMessage = confirm("Are you sure you want to delete your account?");
                if (confirmMessage == true) {
                    alert("Your account has been successfully deleted")
                    location.href="Homepage.aspx";
                }
                else {
                    alert("Your account was not deleted");
                    location.href = "MyAccount.aspx";

                }
            }

            function KeepMyAccount() {
                alert("Your account was not deleted");
                location.href="Homepage.aspx";
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
            }
            }
        </script>
    </form>
</body>
</html>