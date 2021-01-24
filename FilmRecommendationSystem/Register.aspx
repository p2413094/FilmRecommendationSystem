<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Film recommender | Register</title>
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
                Register for account  
            </p>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <div class="text">
                <p class="page-subheader">
                    What do you get when you register with us?
                </p>
                <div>
                    &#9989; save personalised recommendations
                    <br />
                    &#9989; save favourite films for better recommendations
                    <br />
                    &#9989; get a personalised watch list
                    <br />
                    &#9989; add personalised tag to film, making search and recommendations even better
                </div>
            </div>
            <br />
            <br />
            <br />
            <br />

            <div class="textentry-label">
                Email address
            </div>
            <div class="textentry-field">
                <input type="text" class="textentry-fieldsize" placeholder="e.g. ellenripley@sulaco.com">
            </div>
            
            <div id="lblEmailErrorMessage" class="emailerrormessage">
            </div>

            <br />
            <br />
            <br />

            <div class="textentry-label">
                Username
            </div>
            <div class="textentry-field">
                <input type="text" class="textentry-fieldsize" placeholder="EllenRipley57">
            </div>
            <br />
            <br />
            <br />

            <div class="textentry-label">
                Password
            </div>
            <div class="textentry-field">
                <input type="password" class="textentry-fieldsize">
            </div>
            <br />
            <br />
            <br />

            <div class="textentry-label">
                Confirm password
            </div>
            <div class="textentry-field">
                <input type="password" class="textentry-fieldsize" />
                <br />
                <br />
                <p style="font-style: italic;">By creating an account, you acknowledge our privacy statement.</p>
                <button type="button" onclick="btnRegister_Click()" id="btnRegister" class="registerbutton">CREATE ACCOUNT</button>

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
        </div>
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
        
    </form>
    <script type="text/javascript">
        function btnRegister_Click() {
                location.href = "Register_ConfirmEmail.aspx";
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
</body>
</html>