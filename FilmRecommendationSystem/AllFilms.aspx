<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllFilms.aspx.cs" Inherits="FilmRecommendationSystem.AllFilms" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Film recommender | All films</title>
    <link rel="stylesheet" href="StyleSheet.css" />
</head>

<body class="body" onload="onLoad()">
    
    <form runat="server">
        <p class="logo textlink">
            <a href="Homepage.aspx">FILM RECOMMENDER</a>
        </p>

        <br />
        <br />
        <br />
        <div class="navbar">
            <div class="dropdown">
                <button class="dropbtn">MY ACCOUNT 
                    <i class="fa fa-caret-down"></i>
                </button>
                <div class="dropdown-content">

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
                <input autocomplete="off" class="textentry-field" type="text" oninput="myFunction()" id="myInput" onkeyup="filterFunction()" />
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
        §<br />
        <br />
        <div class="account">
            <p class="page-header">
                All films
            </p>
            <br />
            <br />
            <asp:ImageButton ID="imgbtnAdd" OnClick="imgbtnAdd_Click" ImageUrl="~/Images/Add_plus icon.png" CausesValidation="false"
                class="allstaffmembers-add"
                runat="server" />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Panel ID="Panel1" runat="server"></asp:Panel>
            <br />
            <br />
            <br />
            <br />

        <div>
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
        </div>


            <br />
            <br />
            <br />
            <br />


            <asp:Panel ID="pnlAllFilms" runat="server">
                <asp:TextBox ID="txtFilmSearch" OnTextChanged="txtFilmSearch_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>
                <asp:GridView ID="grdAllFilms" AllowPaging="true" PageSize="20" OnRowEditing="grdAllFilms_RowEditing" OnRowUpdating="grdAllFilms_RowUpdating"
                    AutoGenerateColumns="false" runat="server">
                    <Columns>
                        <asp:TemplateField HeaderText="FilmId">
                            <ItemTemplate>
                                <asp:Label ID="lblFilmId" Text='<%#Eval("FilmId")%>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Title">
                            <ItemTemplate>
                                <asp:Label ID="lblTitle" Text='<%#Eval("Title")%>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="true"/>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />



        <asp:Panel ID="pnlActionFilm" CssClass="account" runat="server">

                <asp:Label ID="lblActionFilm" class="page-subheader" runat="server">Add new film</asp:Label>
            
                <div class="register-section">
                    <asp:Label runat="server" AssociatedControlID="txtFilmTitle" CssClass="textentry-label">Title</asp:Label>
                    <div class="textentry-field">
                        <asp:TextBox runat="server" placeholder="Ghostbusters (1984)" ID="txtFilmTitle" CssClass="textentry-fieldsize"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtFilmTitle" runat="server" ErrorMessage="Field must not be blank"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="register-section">
                    <asp:Label runat="server" AssociatedControlID="ddlYear" CssClass="textentry-label">Year released: </asp:Label>
                    <div class="textentry-field">
                        <asp:DropDownList ID="ddlYear" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ControlToValidate="ddlYear" runat="server" ErrorMessage="Field must not be blank"></asp:RequiredFieldValidator>
                    </div>
                </div>


            <div class="register-section">
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
                            <asp:RequiredFieldValidator ControlToValidate="ddlYear" runat="server" ErrorMessage="Field must not be blank"></asp:RequiredFieldValidator>
                        </div>
                </asp:Panel>
            </div>

            <div class="register-section">
                <asp:Label runat="server" AssociatedControlID="txtImdbId" CssClass="textentry-label">IMDBId:</asp:Label>
                <div class="textentry-field">
                    <asp:TextBox runat="server" placeholder="087332" ID="txtImdbId" CssClass="textentry-fieldsize"></asp:TextBox>
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

            <div class="register-section">
                <div class="textentry-label"></div>
                <div class="textentry-field">
                    <asp:Button ID="btnActionFilm" OnClick="btnActionFilm_Click" 
                        Text="ADD NEW FILM"
                        ValidationGroup="vldgrpNewStaffMember" 
                        runat="server" CssClass="registerbutton" />
                    <asp:Button ID="btnActionFilmCancel" OnClick="btnActionFilmCancel_Click"
                        CssClass="registerbutton"
                        Text="CANCEL CHANGES" CausesValidation="false"
                        runat="server" />
                </div>
            </div>
            <asp:Panel ID="pnlActionFilmError" runat="server">
                <div class="register-section">
                </div>
            </asp:Panel>

        </asp:Panel>
            <asp:Panel ID="Panel2" runat="server">

            </asp:Panel>

    </div>
            
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />

            <div>
                <table>
                    <tr>
                        <th>Title</th>
                        <th>Year released</th>
                        <th>Genre(s)</th>
                        <th>IMDB id</th>
                        <th>TMIMDB id</th>
                        <th id="Actions">Actions</th>
                    </tr>

                    <tr id="rowToyStory">
                        <td>
                            <input type="text" class="textbox-transparent" value="Toy Story" readonly="true" id="txtTitle" />
                        </td>
                        <td>
                            <input type="text" class="textbox-transparent" value="1995" readonly="true" id="txtYearReleased" />
                        </td>
                        <td>
                            <input type="text" class="textbox-transparent" value="Adventure, animation" readonly="true" id="txtGenre" />
                        </td>
                        <td>
                            <input type="text" class="textbox-transparent" value="0114709" readonly="true" id="txtIMDB" />
                        </td>
                        <td>
                            <input type="text" class="textbox-transparent" value="01111" readonly="true" id="txtTmIMDB" />                         
                        </td>
                        
                        <td class="tablecell-actions" id="cellTableActions">
                            <img src="Images/Edit%20icon.png" class="action_icon" onclick="btnEdit_Clicked()" id="icnEdit" />
                            <img src="Images/TrashCan.png" class="action_icon" onclick="DeleteFilm()" />
                        </td>
                        
                    </tr>

                    <tr>
                        <td>The Incredibles</td>
                        <td>2004</td>
                        <td>Adventure, animation, Disney</td>
                        <td>0317705</td>
                        <td>9806</td>
                    </tr>

                    <tr>
                        <td>Cars</td>
                        <td>2006</td>
                        <td>Animation, Comedy, Disney</td>
                        <td>tt0317219</td>
                        <td>9806</td>
                      
                    </tr>

                    <tr id="rowAdd">
                        <td>
                            <input type="text" class="textbox-semitransparent" id="txtAddTitle"/>
                        </td>
                        <td>
                            <input type="text" class="textbox-semitransparent" id="txtAddYearReleased"/>
                        </td>
                        <td>
                            <input type="text" class="textbox-semitransparent" id="txtAddGenre"/>
                        </td>
                        <td>
                            <input type="text" class="textbox-semitransparent" id="txtAddImdbId"/>
                        </td>
                        <td>
                            <input type="text" class="textbox-semitransparent" id="txtAddTmImdbId"/>
                        </td>

                        <td class="tablecell-actions" id="cellTableActions">
                            <img src="Images/Green tick_save.png" class="action_icon" onclick="btnSave_Clicked()" />
                        </td>
                    </tr>
                </table>
            </div>
            
            <div>
                
            </div>
            <br />
            <br />

        <script>
            function onLoad() {

            }

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
                var confirmMessage = confirm("Delete film?");
                if (confirmMessage == true) {
                    alert("Film has been successfully deleted");
                    return true;
                }
                else {
                    alert("Film not deleted");
                    return false;
                }
            }


        </script>
        
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
</body>
</html>