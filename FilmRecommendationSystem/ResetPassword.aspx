<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="FilmRecommendationSystem.ResetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FILM RECOMMENDER | RESET PASSWORD</title>
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

        <div class="search">
            <a onclick="hyplnkSearch_Clicked()" class="label">SEARCH</a>
            <div class="textentry-container">
                <input autocomplete="off" class="textentry-field" type="text" id="myInput" onkeyup="filterSearchFunction()" />
            </div>
        </div>

        <div class="mainContent">
            <div class="header">Reset password</div>

            <asp:Panel ID="pnlError" runat="server">
                <div class="page-subheader">Alert</div>
            </asp:Panel>

            <div class="loginSection">
                <asp:Label runat="server" AssociatedControlID="txtEmailAddress" CssClass="textentry-label">Email address</asp:Label>
                <div class="textentry-field">
                    <asp:TextBox runat="server"  placeholder="ellenripley86@sulaco.com" AutoCompleteType="Disabled" ID="txtEmailAddress" TextMode="Email"  CssClass="textentry-fieldsize"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmailAddress"  ErrorMessage="Field cannot be blank"></asp:RequiredFieldValidator>
                </div>
            </div>
            
            <div class="loginSection">
                <asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword" Text="Password" CssClass="textentry-label"></asp:Label>
                <div class="textentry-field">
                    <asp:TextBox ID="txtPassword" TextMode="Password" placeholder="***********" runat="server" CssClass="textentry-fieldsize"></asp:TextBox>
                    <br />
                    <asp:Panel ID="pnlPasswordErrors" runat="server">
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
                    </asp:Panel>
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
                    <asp:Button ID="btnResetPassword" OnClick="btnResetPassword_Click" runat="server" Text="Reset password" CssClass="proceedButton" />
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

            function btnLogin_Click() {
                location.href = "ResetPasswordConfirmation.aspx";
            }

            function SavePassword() {
                alert("Your new password has been saved");
                location.href="Login.aspx";        
            }
        </script>
    </form>
</body>
</html>