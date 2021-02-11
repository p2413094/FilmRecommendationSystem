<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="FilmRecommendationSystem.Register" %>

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

            <div class="register-section">
                <asp:Label runat="server" AssociatedControlID="txtEmailAddress" CssClass="textentry-label">Email address</asp:Label>
                <div class="textentry-field">
                    <asp:TextBox runat="server" placeholder="ellenripley86@sulaco.com" ID="txtEmailAddress" TextMode="Email"  CssClass="textentry-fieldsize"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmailAddress" ID="RequiredFieldValidator2"  ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                </div>
            </div>
            
            <div class="register-section">
                <asp:Label ID="lblUsername" runat="server" AssociatedControlID="txtUsername" Text="Username" CssClass="textentry-label"></asp:Label>
                <div class="textentry-field">
                    <asp:TextBox runat="server" placeholder="EllenRipley57" ID="txtUsername" CssClass="textentry-fieldsize"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="txtUsername" ID="rqValUsername" runat="server" ErrorMessage="Username must not be blank"></asp:RequiredFieldValidator>
                </div>
            </div>
            
            <div class="register-section-password">
                <asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword" Text="Password" CssClass="textentry-label"></asp:Label>
                <div class="textentry-field">
                    <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="textentry-fieldsize"></asp:TextBox>
                    <br />
                    <div class="italiscised">
                        Password must:
                        <br />
                        &#8226; be a minimum of 8 characters
                        <br />
                        &#8226; have uppercase letters
                        <br />
                        &#8226; have lowercase letters
                        <br />
                        &#8226; contain numbers
                        <br />
                        <br />
                    </div>
                    <asp:RequiredFieldValidator ControlToValidate="txtPassword" ID="rqValPassword" runat="server" ErrorMessage="Password does not comply with above."></asp:RequiredFieldValidator>
                </div>
            </div>
            
            <div class="register-section">
                <asp:Label ID="lblConfirmPassword" runat="server" AssociatedControlID="txtPasswordConfirmation" Text="Confirm password" CssClass="textentry-label"></asp:Label>
                <div class="textentry-field">
                    <asp:TextBox ID="txtPasswordConfirmation" TextMode="Password" runat="server" CssClass="textentry-fieldsize"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="txtPasswordConfirmation" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Password must match the previous"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <asp:CompareValidator runat="server" ControlToCompare="txtPassword" ControlToValidate="txtPasswordConfirmation" Display="Dynamic" 
                        ErrorMessage="The two passwords do not match!"></asp:CompareValidator>
                </div>
            </div>
            
            <div class="register-section">
                <div class="textentry-label"></div>
                <div class="textentry-field">
                    <p style="font-style: italic;">By creating an account, you acknowledge our privacy statement.</p>
                    <asp:Button ID="btnRegister" OnClick="btnRegister_Click" runat="server" Text="CREATE ACCOUNT" CssClass="registerbutton" />
                </div>
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