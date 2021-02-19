<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchResults.aspx.cs" Inherits="FilmRecommendationSystem.SearchResults" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Film recommender | My WatchList</title>
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
        <br />
        <br />
        <br />

        <div class="search">
            <div class="label">
                SEARCH
            </div>
            <div class="textentry-container">
                <input autocomplete="off" class="textentry-field" type="text" id="myInput" onkeyup="filterSearchFunction()" />
                    <div id="mySearchDropdown" class="searchdropdown-content">
                        <a href="FilmInformation2.aspx">Terminator 2: Judgment Day (1991)</a>
                        <a>Little Women (2019)</a>
                    </div>
            </div>
        </div>
       
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <div class="page-header">
            Search results  
        </div>  
       
        
        <br />
        <br />
        <br />
        <br />

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

        <asp:Panel ID="pnlAllSearchResults" runat="server"></asp:Panel>
        

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
            function btnReturnToHomepage_Click() {
                location.href = "Homepage.aspx";
            }
        </script>
    </form>
</body>
</html>