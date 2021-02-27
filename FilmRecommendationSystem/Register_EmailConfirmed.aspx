<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register_EmailConfirmed.aspx.cs" Inherits="FilmRecommendationSystem.Register_EmailConfirmed" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Film recommender | Confirm email address</title>
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
                <input autocomplete="off" class="textentry-field" type="text" oninput="myFunction()" id="myInput" onkeyup="filterFunction()" />
                <div>
                    <div id="myDropdown" class="dropdown-content">
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
        <br />
        <br />
        <br />
        <div class="account">
            <p class="page-header">
                Email address confirmed 
            </p>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
                Thanks for verifying, you're now free to use the service!
            <br />
            <br />
            <div>
                <button type="button" onclick="btnOk_Click()" id="btnOk" class="okbutton">Ok</button>
            </div>
            <br />
            <br />
            </div>

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
            function btnOk_Click() {
                location.href = "Homepage.aspx";
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