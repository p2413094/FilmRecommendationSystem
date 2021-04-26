<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchResults.aspx.cs" Inherits="FilmRecommendationSystem.SearchResults" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FILM RECOMMENDER | SEARCH RESULTS</title>
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
                <input autocomplete="off" class="textentry-field" type="text" id="myInput" />
            </div>
        </div>
        <br />
        <br />
        <asp:Panel ID="pnlAllSearchResults" CssClass="mainContent" runat="server">
            <div class="searchHeader">Search results</div>
                <asp:DropDownList AutoPostBack="true" CssClass="slctGenre" ID="ddlMoods" OnSelectedIndexChanged="ddlMood_SelectedIndexChanged" runat="server"></asp:DropDownList>
                <asp:DropDownList AutoPostBack="true" CssClass="slctGenre" ID="ddlGenre" OnSelectedIndexChanged="ddlGenre_SelectedIndexChanged" runat="server">
                    <asp:ListItem Text="genre" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="1">Action</asp:ListItem>
                    <asp:ListItem Value="2">Adventure</asp:ListItem>
                    <asp:ListItem Value="3">Animation</asp:ListItem>
                    <asp:ListItem Value="4">Children</asp:ListItem>
                    <asp:ListItem Value="5">Comedy</asp:ListItem>
                    <asp:ListItem Value="12">Crime</asp:ListItem>
                    <asp:ListItem Value="18">Documentary</asp:ListItem>
                    <asp:ListItem Value="13">Drama</asp:ListItem>
                    <asp:ListItem Value="6">Fantasy</asp:ListItem>
                    <asp:ListItem Value="16">Film-Noir</asp:ListItem>
                    <asp:ListItem Value="14">Horror</asp:ListItem>
                    <asp:ListItem Value="7">IMAX</asp:ListItem>
                    <asp:ListItem Value="19">Musical</asp:ListItem>
                    <asp:ListItem Value="11">Mystery</asp:ListItem>
                    <asp:ListItem Value="8">Romance</asp:ListItem>
                    <asp:ListItem Value="9">Sci-Fi</asp:ListItem>
                    <asp:ListItem Value="15">Thriller</asp:ListItem>
                    <asp:ListItem Value="17">War</asp:ListItem>
                    <asp:ListItem Value="10">Western</asp:ListItem>
                </asp:DropDownList>
            <asp:Panel runat="server" ID="pnlActualSearchResults"></asp:Panel>
        </asp:Panel>

        <asp:Panel ID="pnlError" CssClass="mainContent" runat="server">
            <div class="header">Error</div>
            <div class="textSection">
                There was an error fulfilling your request; please try again later.
                <br />
                <br />
                <button type="button" id="btnReturnToHomepage" onclick="btnReturnToHomepage_Click()" class="proceedButton">Ok</button>
            </div>
        </asp:Panel>       

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

            myInput.addEventListener("keyup", function (event) {
                // Number 13 is the "Enter" key on the keyboard
                if (event.keyCode === 13) {
                    // Cancel the default action, if needed
                    event.preventDefault();
                    // Trigger the button element with a click
                    hyplnkSearch_Clicked();
                }
            });

            function btnReturnToHomepage_Click() {
                location.href = "Homepage.aspx";
            }
        </script>
    </form>
</body>
</html>