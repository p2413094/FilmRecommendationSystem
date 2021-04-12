<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="FilmRecommendationSystem.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FILM RECOMMENDER | REGISTER</title>
    <link rel="stylesheet" href="StyleSheet.css" />
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

        <br />
        <br />

        <div class="search">
            <a onclick="hyplnkSearch_Clicked()" class="label">SEARCH</a>
            <div class="textentry-container">
                <input autocomplete="off" class="textentry-field" type="text" id="myInput" onkeyup="filterSearchFunction()" />
            </div>
        </div>

        <div class="mainContent">
            <div class="header">Register for account</div>
            <div class="textSection">
                <p class="page-subheader">What do you get when you register with us?</p>
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
            <br />
            <asp:Panel ID="pnlErrorContainer" CssClass="errorPanelContainer" runat="server">
                <label class="page-subheader italicised">Fix errors before continuing</label>
                <asp:Panel ID="pnlErrors" CssClass="errors" runat="server"></asp:Panel>
            </asp:Panel>

            <div class="loginSection">
                <asp:Label runat="server" AssociatedControlID="txtEmailAddress" CssClass="textentry-label">Email address</asp:Label>
                <div class="textentry-field">
                    <asp:TextBox runat="server" AutoCompleteType="Disabled" placeholder="leatherface@texaschainsaw.com" ID="txtEmailAddress" TextMode="Email"  CssClass="textentry-fieldsize"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmailAddress" ID="RequiredFieldValidator2"  ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                </div>
            </div>
            
            <div class="loginSection">
                <asp:Label ID="lblUsername" runat="server" AssociatedControlID="txtUsername" Text="Username" CssClass="textentry-label"></asp:Label>
                <div class="textentry-field">
                    <asp:TextBox runat="server" AutoCompleteType="Disabled" placeholder="Leatherface1974" ID="txtUsername" CssClass="textentry-fieldsize"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="txtUsername" ID="rqValUsername" runat="server" ErrorMessage="Username must not be blank"></asp:RequiredFieldValidator>
                </div>
            </div>
            
            <div class="loginSection">
                <asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword" Text="Password" CssClass="textentry-label"></asp:Label>
                <div class="textentry-field">
                    <asp:TextBox ID="txtPassword" placeholder="********" TextMode="Password" runat="server" CssClass="textentry-fieldsize"></asp:TextBox>
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
            
            <div class="loginSection">
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
            
            <div class="loginSection">
                <div class="confirmationContainer">
                    <p style="font-style: italic;">By creating an account, you acknowledge our privacy statement.</p>
                    <asp:Button ID="btnRegister" OnClick="btnRegister_Click" runat="server" Text="CREATE ACCOUNT" CssClass="proceedButton" />
                </div>
            </div>
        </div>

        <div class="footer">
            <div class="links">
                <a href="Help.aspx" target="_blank">Help</a> 
            </div>
            <div class="footercopyright">
                © 2020 FILM RECOMMENDER
                <br />
                All rights are reserved
            </div>
        </div>
        
    </form>
    <script>
        function hyplnkSearch_Clicked() {
            var searchText = document.getElementById("myInput").value;

            if (searchText.length == 0) {
                alert("Search text cannot be blank");
            }
            else {
                location.href = "SearchResults.aspx?searchText=" + searchText;
            }
        }

        myInput.addEventListener("keyup", function (event) {
            // Number 13 is the "Enter" key on the keyboard
            if (event.keyCode === 13) {
                // Cancel the default action, if needed
                event.preventDefault();
                // Trigger the button element with a click
                hyplnkSearch_Clicked();
            }
        });
    </script>
</body>
</html>