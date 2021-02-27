﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgottenResetPassword.aspx.cs" Inherits="FilmRecommendationSystem.ForgottenResetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Film recommender | Forgotten password</title>
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
                Reset password  
            </p>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            
            <p>
                If you've forgotten your password or need to reset it, enter your account email
                and we'll send you a link to change it.     
            </p>
            <br />
            <br />
            <br />
            <div>
                <div class="textentry-label">
                Email address
                </div>
                <div class="textentry-field">
                    <asp:TextBox ID="txtEmailAddress" TextMode="Email" runat="server"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmailAddress" 
                        ErrorMessage="Email field is required"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="btnResetPassword" OnClick="btnResetPassword_Click" runat="server" Text="Reset password" CssClass="okbutton" />
                    <br />
                    <br />
                </div>
                <br />  
                <br />
                <br />
               
                
            </div>
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
        function btnResetPassword_Click() {
            location.href = "ResetPassword.aspx";
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
</body>
</html>