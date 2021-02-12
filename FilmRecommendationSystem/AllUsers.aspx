﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllUsers.aspx.cs" Inherits="FilmRecommendationSystem.AllUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Film recommender | All users</title>
    <link rel="stylesheet" href="StyleSheet.css" />
</head>

<body class="body">
    <form runat="server">
        <p class="logo textlink">
            <a href="Homepage.aspx">FILM RECOMMENDER</a>
        </p>

        <br />
        <br />
        <br />
        <div class="navbar">
            <div class="dropdown">
                <button class="dropbtn">
                    <a href="MyAccount.aspx" class="menutext">MY ACCOUNT</a>
                </button>
                <div class="dropdown-content">

                    <div class="imagecontainer">
                        <img class="imagedimensions" src="Images/RecommendedFilms.png" />
                    </div>
                    <a href="RecommendedFilms.aspx">RECOMMENDATIONS</a>
                    <br />
                    <br />
                    <br />

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

        <div class="account">
            <p class="page-header">
                All users 
            </p>
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
        </div>

        <br />
        <br />
        <br />
        <br />
        <br />

        <asp:Panel ID="pnlAllUsers" runat="server">
            <asp:GridView ID="grdAllUsers" OnRowEditing="grdAllUsers_RowEditing" OnRowUpdating="grdAllUsers_RowUpdating" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:TemplateField HeaderText="UserId">
                        <ItemTemplate>
                            <asp:Label ID="lblUserId" Text='<%#Eval("UserId")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Username">
                        <ItemTemplate>
                            <asp:Label ID="lblUsername" Text='<%#Eval("UserName")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email address">
                        <ItemTemplate>
                            <asp:Label ID="lblEmail" Text='<%#Eval("Email")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email confirmed?">
                        <ItemTemplate>
                            <asp:Label ID="lblEmailConfirmed" Text='<%#Eval("EmailConfirmed")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Phone number">
                        <ItemTemplate>
                            <asp:Label ID="lblPhoneNumber" Text='<%#Eval("PhoneNumber")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Phone confirmed?">
                        <ItemTemplate>
                            <asp:Label ID="lblPhoneConfirmed" Text='<%#Eval("PhoneConfirmed")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Last login">
                        <ItemTemplate>
                            <asp:Label ID="lblLastLogin" Text='<%#Eval("LastLogin")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Suspended?">
                        <ItemTemplate>
                            <asp:Label ID="lblSuspended" runat="server" Text='<%#Eval("LockoutEnabled")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:CheckBox ID="chkSuspended" runat="server" Text='<%#Eval("LockoutEnabled")%>' />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Suspended end date">
                        <ItemTemplate>
                            <asp:Label ID="lblSuspendedEndDate" Text='<%#Eval("LockoutEndDateUtc")%>' runat="server"></asp:Label>
                        </ItemTemplate>
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

                        <table>
                    <tr>
                        <th id="Username">Username</th>
                        <th id="Email">Email</th>
                        <th id="PhoneNumber">Phone number</th>
                        <th id="EmailPhoneConfirmed">Email/ phone confirmed?</th>
                        <th id="LastLogin">Last login</th>
                        <th id="Suspended">Susp?</th>
                        <th id="Actions">Actions</th>
                        
                    </tr>

                    <tr>
                        <td>GreatestEver98</td>
                        <td>greatestever98@icloud.com</td>
                        <td>01902714537</td>
                        <td>Y/ N</td>
                        <td>19:10, 20/10/20</td>
                        <td>
                            <label id="lblSuspended">N</label>
                        </td>
                        <td class="tablecell-actions" id="cellTableActions">
                            <img src="Images/NoIcon.png" id="iconSuspendUser" class="action_icon" onclick="SuspendUserAccount()" />
                        </td>
                    </tr>

                    <tr>
                        <td>SecondGreatestEver99</td>
                        <td>secondever99@icloud.com</td>
                        <td>0121765432</td>
                        <td>Y/ Y</td>
                        <td>17:34, 28/10/20</td>
                        <td>N</td>
                        <td></td>
                    </tr>
                
                </table>


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
         function SuspendUserAccount() {
                var confirmMessage = confirm("Suspend user account?");
                if (confirmMessage == true) {
                    alert("User suspended");
                    document.getElementById("lblSuspended").innerText = "Y";
                }
                else {
                    alert("User not suspended")
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
    </form>
</body>
</html>