<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllFilms.aspx.cs" Inherits="FilmRecommendationSystem.AllFilms" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FILM RECOMMENDER | ALL FILMS</title>
    <link rel="stylesheet" href="StyleSheet.css" />
</head>

<body class="body" onload="onLoad()">
    <form runat="server">
        <p class="logo"><a href="Homepage.aspx">FILM RECOMMENDER</a></p>
        <br />
        <br />
        <br />
        <div class="navbar">
            <div class="dropdown">
                <button class="dropbtn">
                    <a href="MyAccount.aspx" class="menutext">MY ACCOUNT</a>
                </button>
                <div class="dropdown-content">
                    <a href="RecommendedFilms.aspx">RECOMMENDATIONS</a>
                    <a href="WatchList.aspx">WATCHLIST</a>
                    <a href="FavouriteFilms.aspx">FAVOURITES</a>
                    <asp:LinkButton ID="lnkbtnLogOut" OnClick="lnkbtnLogOut_Click" runat="server">LOG OUT</asp:LinkButton>
                </div>
            </div> 
        </div>

        <div class="search">
            <a onclick="hyplnkSearch_Clicked()" class="label">SEARCH</a>
            <div class="textentry-container">
                <input autocomplete="off" class="textentry-field" type="text" id="myInput" onkeyup="filterSearchFunction()" />
            </div>
        </div>

        <asp:Panel ID="pnlAllFilms" CssClass="mainContent" runat="server">
            <div class="header">All films</div>
            <asp:ImageButton ID="imgbtnAdd" OnClick="imgbtnAdd_Click" ImageUrl="~/Images/Add_plus icon.png" CausesValidation="false" class="addIcon"
                runat="server" />   
            <asp:Panel ID="Panel1" runat="server">
                <asp:TextBox ID="txtFilmSearch" placeholder="search..." AutoCompleteType="Disabled" OnTextChanged="txtFilmSearch_TextChanged" CssClass="gridviewSearch" AutoPostBack="true" runat="server"></asp:TextBox>
                <asp:GridView EmptyDataText="No films to show" PagerSettings-Mode="NumericFirstLast" PagerSettings-LastPageText="last" OnPageIndexChanging="grdAllFilms_PageIndexChanging" ID="grdAllFilms"
                    AllowPaging="true" PageSize="20" OnRowEditing="grdAllFilms_RowEditing" OnRowUpdating="grdAllFilms_RowUpdating" OnRowDeleting="grdAllFilms_RowDeleting" AutoGenerateColumns="false" 
                    CssClass="AllUsersFilmsTable" runat="server">
                        <Columns>
                            <asp:TemplateField HeaderText="FilmId" HeaderStyle-CssClass="columnHeader" ItemStyle-CssClass="columnContent">
                                <ItemTemplate>
                                    <asp:Label ID="lblFilmId" Text='<%#Eval("FilmId")%>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Title" HeaderStyle-CssClass="columnHeader" ItemStyle-CssClass="columnContent">
                                <ItemTemplate>
                                    <asp:Label ID="lblTitle" Text='<%#Eval("Title")%>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-CssClass="tablecell-actions" HeaderStyle-CssClass="tablecell-actions">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgbtnEdit" ImageUrl="~/Images/Edit_icon.png" CssClass="action_icon" commandname="Edit" ToolTip="Edit this record" runat="server" />
                                    <asp:ImageButton ID="imgbtnDelete" ImageUrl="~/Images/TrashCan.png" OnClientClick="return DeleteFilm()" CssClass="action_icon" commandname="Delete" ToolTip="Delete this record" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>

            </asp:Panel>

        <asp:Panel ID="pnlActionFilm" CssClass="mainContent" runat="server">
            <asp:Label ID="lblActionFilm" class="header" runat="server">Add new film</asp:Label>
            
            <asp:Panel ID="pnlActionFilmError" runat="server">
                <div class="textSectionError"><p class="page-subheader">Fix errors before continuing</p>
                    <asp:Panel ID="pnlActionFilmErrorBody" runat="server"></asp:Panel>
                </div>
            </asp:Panel>

                <div class="loginSection">
                    <asp:Label runat="server" AssociatedControlID="txtFilmTitle" CssClass="textentry-label">Title</asp:Label>
                    <div class="textentry-field">
                        <asp:TextBox runat="server" AutoCompleteType="Disabled" placeholder="Ghostbusters (1984)" ID="txtFilmTitle" CssClass="textentry-fieldsize"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtFilmTitle" runat="server" ErrorMessage="Field must not be blank"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="loginSection">
                    <asp:Label runat="server" AssociatedControlID="ddlYear" CssClass="textentry-label">Year released: </asp:Label>
                    <div class="textentry-field">
                        <asp:DropDownList ID="ddlYear" CssClass="userPrivilegeDropdown" runat="server"></asp:DropDownList>
                        <br />
                        <asp:RequiredFieldValidator ControlToValidate="ddlYear" runat="server" ErrorMessage="Field must not be blank"></asp:RequiredFieldValidator>
                    </div>
                </div>
            <div class="loginSection">
                <asp:Panel ID="pnlGenres" runat="server">
                        <asp:Label runat="server" CssClass="textentry-label">Genre(s): </asp:Label>
                        <div class="textentry-field">
                            <asp:CheckBoxList ID="chkbxlstGenres" RepeatDirection="Vertical" RepeatColumns="3" runat="server">
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
                            </asp:CheckBoxList>
                        </div>
                </asp:Panel>
            </div>

            <div class="loginSection">
                <asp:Label runat="server" AssociatedControlID="txtImdbId" CssClass="textentry-label">IMDBId:</asp:Label>
                <div class="textentry-field">
                    <asp:TextBox runat="server" AutoCompleteType="Disabled" placeholder="087332" ID="txtImdbId" CssClass="textentry-fieldsize"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="txtImdbId" runat="server" ErrorMessage="Field must not be blank"></asp:RequiredFieldValidator>
                    <asp:CustomValidator runat="server"
                        ValidationGroup="vldgrpFilm"
                        EnableClientScript="true"
                        ErrorMessage="IMDBId must be between 0-50 characters."
                        ClientValidationFunction="ValidateNewStaffMemberLastName" 
                        ControlToValidate="txtImdbId">
                    </asp:CustomValidator>
                </div>
            </div>
            <div class="loginSection">
                <div class="textentry-label"></div>
                <div class="textentry-field">
                    <asp:Button ID="btnActionFilm" OnClick="btnActionFilm_Click" 
                        Text="ADD NEW FILM"
                        ValidationGroup="vldgrpNewStaffMember" 
                        runat="server" CssClass="proceedButton" />
                    <asp:Button ID="btnActionFilmCancel" OnClientClick="btnActionFilmCancel_Clicked()" OnClick="btnActionFilmCancel_Click"
                        CssClass="proceedButton"
                        Text="CANCEL CHANGES" CausesValidation="false"
                        runat="server" />
                </div>
            </div>
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
        
            
        <script>
            function onLoad() {

            }

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
                          
            function imgAdd_Clicked() {
                document.getElementById("rowAdd").style.visibility = "visible";
            }

            function btnActionFilm_Click() {
                var confirmMessage = confirm("Are you sure you want to add a new new film?");
                if (confirmMessage == true) {
                    alert("Film added!");
                    return true;
                }
                else {
                    alert("Film was not added");
                    return false;
                }
            }

            function btnEdit_Clicked() {
                    var confirmMessage = confirm("Are you sure you want to update the record?");
                    if (confirmMessage == true) {
                        alert("Record updated");                     
                    }
                    else {
                        alert("Record was not updated");
                    }              
            }

            function DeleteFilm() {
                var confirmMessage = confirm("Are you sure you want to delete this film?");
                if (confirmMessage == true) {
                    alert("Film has been successfully deleted");
                    return true;
                }
                else {
                    alert("Film not deleted");
                    return false;
                }
            }

            function btnActionFilmCancel_Clicked() {
                alert("No changes have been made.");
            }

        </script>
        
        <br />
        <br />
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
</body>
</html>