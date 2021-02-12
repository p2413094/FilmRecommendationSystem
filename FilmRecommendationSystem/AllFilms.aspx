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
        <br />
        <br />
        <div class="account">
            <p class="page-header">
                All films
            </p>
            <br />
            <br />
            <img src="Images/Add_plus icon.png" class="allstaffmembers-add" onclick="imgAdd_Clicked()" />
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
                <asp:GridView ID="grdAllFilms" AllowPaging="true" OnRowEditing="grdAllFilms_RowEditing" OnRowUpdating="grdAllFilms_RowUpdating" AutoGenerateColumns="false" runat="server">
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
                            <EditItemTemplate>
                                <asp:TextBox ID="txtTitle" Text='<%#Eval("Title")%>' runat="server"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="true" />
                    </Columns>
                </asp:GridView>
            </asp:Panel>

            <br />
            <br />
            <br />
            <br />
            <br />
            <br />

        <div>
            <asp:Panel ID="Panel2" runat="server">
                <asp:Label ID="Label3" runat="server" Text="Title"></asp:Label>
                <asp:TextBox ID="txtNewTitle" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
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

        </div>

        <script>
            var count = 0;

            function onLoad() {
                document.getElementById("rowAdd").style.visibility = "hidden";
            }

            function btnReturnToHomepage_Click() {
                location.href = "Homepage.aspx";
            }
                          
            function imgAdd_Clicked() {
                document.getElementById("rowAdd").style.visibility = "visible";
            }

            function btnEdit_Clicked() {
                if (count == 0) {
                    document.getElementById("txtTitle").className = "textbox-semitransparent";
                    document.getElementById("txtTitle").readOnly = false;

                    document.getElementById("txtYearReleased").className = "textbox-semitransparent";
                    document.getElementById("txtYearReleased").readOnly = false;

                    document.getElementById("txtGenre").className = "textbox-semitransparent";
                    document.getElementById("txtGenre").readOnly = false;

                    document.getElementById("txtIMDB").className = "textbox-semitransparent";
                    document.getElementById("txtIMDB").readOnly = false;

                    document.getElementById("txtTmIMDB").className = "textbox-semitransparent";
                    document.getElementById("txtTmIMDB").readOnly = false;

                    document.getElementById("icnEdit").src = "Images/Green%20tick_save.png";

                    count++;
                }
                else {
                    var confirmMessage = confirm("Are you sure you want to update the record?");
                    if (confirmMessage == true) {
                        alert("Record updated");                     
                    }
                    else {
                        alert("Record was not updated");
                        
                    }
                    document.getElementById("icnEdit").src = "Images/Edit%20icon.png";
                    document.getElementById("txtTitle").className = "textbox-transparent";
                    document.getElementById("txtTitle").readOnly = true;

                    document.getElementById("txtYearReleased").className = "textbox-transparent";
                    document.getElementById("txtYearReleased").readOnly = true;

                    document.getElementById("txtGenre").className = "textbox-transparent";
                    document.getElementById("txtGenre").readOnly = true;

                    document.getElementById("txtIMDB").className = "textbox-transparent";
                    document.getElementById("txtIMDB").readOnly = true;

                    document.getElementById("txtTmIMDB").className = "textbox-transparent";
                    document.getElementById("txtTmIMDB").readOnly = true;

                    count = 0;
                }              
            }
          
            function btnSave_Clicked() {
                var confirmMessage = confirm("Are you sure you want to add a new new film?");
                if (confirmMessage == true) {
                    alert("Film added!");                   
                    document.getElementById("txtAddTitle").className = "textbox-transparent";
                    document.getElementById("txtAddTitle").readOnly = true;

                    document.getElementById("txtAddYearReleased").className = "textbox-transparent";
                    document.getElementById("txtAddYearReleased").readOnly = true;

                    document.getElementById("txtAddGenre").className = "textbox-transparent";
                    document.getElementById("txtAddGenre").readOnly = true;

                    document.getElementById("txtAddImdbId").className = "textbox-transparent";
                    document.getElementById("txtAddImdbId").readOnly = true;

                    document.getElementById("txtAddTmImdbId").className = "textbox-transparent";
                    document.getElementById("txtAddTmImdbId").readOnly = true;                
                }
                else {
                    alert("Film was not added");
                }
            }



            function DeleteFilm() {
                var confirmMessage = confirm("Delete film?");
                if (confirmMessage == true) {
                    alert("Film has been successfully deleted");
                    document.getElementById("rowToyStory").style.display = "none";
                }
                else {
                    alert("Film not deleted")
                }
            }

            function UnsuspendUserAccount() {
                var confirmMessage = confirm("Unsuspend user account?");
                if (confirmMessage == true) {
                    alert("User unsuspended");
                    document.getElementById("btnUnsuspend").innerText = "Suspend user";
                }
                else {
                    alert("User still suspended")
                }
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