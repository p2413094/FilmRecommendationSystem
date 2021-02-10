<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllStaffMembers.aspx.cs" Inherits="FilmRecommendationSystem.AllStaffMembers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Film recommender | All staff members</title>
    <link rel="stylesheet" href="StyleSheet.css" />
</head>

<body class="body" onload="onLoad()" >
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

        <br />
        <br />
        <br />
        <br />
        <br />
        <div class="account">
            <p class="page-header">
                All staff members
            </p>
            <br />
            <br />
            <img src="Images/Add_plus icon.png" class="allstaffmembers-add" onclick="imgAdd_Clicked()" />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />

        <div>
            <asp:GridView ID="grdAllStaffMembers" runat="server" AutoGenerateColumns="false" OnRowEditing="grdAllStaffMembers_RowEditing" OnRowUpdating="grdAllStaffMembers_RowUpdating" OnRowDeleting="grdAllStaffMembers_RowDeleting">
                <Columns>
                    <asp:TemplateField HeaderText="StaffMemberId">
                        <ItemTemplate>
                            <asp:Label ID="lblStaffMemberId" Text='<%#Eval("StaffMemberId")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="UserId">
                        <ItemTemplate>
                            <asp:Label ID="lblUserId" runat="server" Text='<%# Eval("UserId") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Confirmed">
                        <ItemTemplate>
                            <asp:Label ID="lblConfirmed" Text='<%# Eval("Confirmed") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PrivilegeLevelId">
                        <ItemTemplate>
                            <asp:Label ID="lblPrivilegeLevelId" Text='<%# Eval("PrivilegeLevelId") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPrivilegeLevelId" Text='<%# Eval("PrivilegeLevelId") %>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="FirstName">
                        <ItemTemplate>
                            <asp:Label ID="lblFirstName" Text='<%# Eval("FirstName") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtFirstName" Text='<%# Eval("FirstName") %>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="LastName">
                        <ItemTemplate>
                            <asp:Label ID="lblLastName" Text='<%# Eval("LastName") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtLastName" Text='<%# Eval("LastName") %>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Suspended">
                        <ItemTemplate>
                            <asp:Label ID="lblAllowed" Text='<%# Eval("Allowed") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:CheckBox ID="chkAllowed" Text='<%# Eval("Allowed") %>' runat="server" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="true"/>
                    <asp:CommandField ShowDeleteButton="true" />
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <br />
        <br />
        <br />

        <div>
            <asp:Panel ID="Panel1" runat="server">
                <asp:Label ID="Label4" runat="server" Text="UserId"></asp:Label>
                <asp:TextBox ID="txtNewUserId" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label1" runat="server" Text="FirstName"></asp:Label>
                <asp:TextBox ID="txtNewFirstName" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label2" runat="server" Text="LastName"></asp:Label>
                <asp:TextBox ID="txtNewLastName" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label3" runat="server" Text="PrivilegeLevel"></asp:Label>
                <asp:TextBox ID="txtNewPrivilegeLevel" runat="server"></asp:TextBox>
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

            <div>
                <table>
                    <tr>
                        <th id="UserId">UserId</th>
                        <th id="firstName">First name</th>
                        <th id="lastName">Last name</th>
                        <th id="PrivilegeLevel">Privilege level</th>
                        <th id="Confirmed">Confirmed?</th>                 
                        <th id="Suspended">Suspended?</th>
                        <th id="Actions">Actions</th>
                    </tr>

                    <tr id="rowHouse">
                        <td>#1</td>
                        <td>
                            <input class="textbox-transparent" value="Greg" readonly="true" id="txtFirstName" type="text"/>
                        </td>
                        <td>
                            <input class="textbox-transparent" value="House" readonly="true" id="txtLastName" type="text"/>
                        </td>
                        <td>
                            <select disabled="disabled" id="slctPrivilege">
                                <option>Standard</option>
                                <option>Administrator</option>
                            </select>
                        </td>
                        <td>
                            <input class="textbox-transparent" value="Y" readonly="true" id="txtConfirmed" type="text"/>
                        </td>
                        <td>
                            <input class="textbox-transparent" value="N" readonly="true" id="txtSuspended" type="text"/>
                        </td>
                        <td class="tablecell-actions" id="cellTableActions">
                            <img src="Images/Edit%20icon.png" class="action_icon" onclick="btnEdit_Clicked()" id="icnEdit" />
                            <img src="Images/NoIcon.png" id="iconSuspendUser" class="action_icon" onclick="btnSuspend_Clicked()"/>
                            <img src="Images/TrashCanRed.png" class="action_icon" onclick="imgDelete_Clicked()"/>
                        </td>
                    </tr>

                    <tr>
                        <td>#13</td>
                        <td>Remy</td>
                        <td>Hadley</td>
                        <td>
                            <select disabled="disabled">
                                <option>Standard</option>
                                <option>Administrator</option>
                            </select>
                        </td>
                        <td>Y</td>
                        <td>Y</td>
                        <td></td>
                    </tr>

                    <tr id="rowAdd">
                        <td>#14</td>
                        <td>
                            <input type="text" class="textbox-semitransparent" id="txtAddFirstName"/>
                        </td>
                        <td>
                            <input type="text" class="textbox-semitransparent" id="txtAddLastName"/>
                        </td>
                        <td>
                            <select id="slctAddPrivilegeLevel">
                                <option>Standard</option>
                                <option>Administrator</option>
                            </select>
                        </td>
                        <td>N</td>
                        <td>N</td>
                        <td class="tablecell-actions" id="cellTableActions">
                            <img src="Images/Green tick_save.png" class="action_icon" onclick="btnSave_Clicked()" />
                        </td>
                    </tr>
                
                </table>
            </div>
         
            <br />
            <br />
        </div>

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
            var count = 0,
                suspended = false;

            function onLoad() {
                document.getElementById("rowAdd").style.visibility = "hidden";
            }

            function imgAdd_Clicked() {
                document.getElementById("rowAdd").style.visibility = "visible";
            }

            function btnSave_Clicked() {
                var confirmMessage = confirm("Are you sure you want to add a new staff member?");
                if (confirmMessage == true) {
                    alert("Staff member added!");
                    document.getElementById("txtAddFirstName").className = "textbox-transparent";
                    document.getElementById("txtAddFirstName").readOnly = true;

                    document.getElementById("txtAddLastName").className = "textbox-transparent";   
                    document.getElementById("txtAddLastName").readOnly = true;

                    document.getElementById("slctAddPrivilegeLevel").disabled = true;
                }
                else {
                    alert("Staff member was not added");
                }
            }

            function btnEdit_Clicked() {
                //location.href = "EditUser.aspx";
                document.getElementById("txtFirstName").readOnly = false;
                document.getElementById("txtLastName").readOnly = false;
                document.getElementById("txtConfirmed").readOnly = false;
                document.getElementById("txtSuspended").readOnly = false;
                document.getElementById("slctPrivilege").disabled = false;

                document.getElementById("icnEdit").src = "Images/Green%20tick_save.png";

                if (count != 0) {
                var confirmMessage = confirm("Are you sure you want to update the record?");
                if (confirmMessage == true) {
                    alert("Record updated");
                    document.getElementById("icnEdit").src = "Images/Edit%20icon.png";
                    document.getElementById("txtFirstName").readOnly = true;
                    document.getElementById("txtLastName").readOnly = true;
                    document.getElementById("txtConfirmed").readOnly = true;
                    document.getElementById("txtSuspended").readOnly = true;
                }
                else {
                    alert("Record was not updated");
                    document.getElementById("txtFirstName").value = "Greg";
                    document.getElementById("txtLastName").value = "House";
                    document.getElementById("txtConfirmed").value = "Y";
                    document.getElementById("txtSuspended").value = "N";
                    document.getElementById("slctPrivilege").value = "Standard";

                    document.getElementById("txtFirstName").readOnly = true;
                    document.getElementById("txtLastName").readOnly = true;
                    document.getElementById("txtConfirmed").readOnly = true;
                    document.getElementById("txtSuspended").readOnly = true;
                    document.getElementById("slctPrivilege").disabled = true;
                }
                }
                count++;
            }           

            function btnSuspend_Clicked() {
                if (suspended == true) {
                    var confirmMessage = confirm("Un-suspend staff member?");
                    if (confirmMessage == true) {
                        document.getElementById("txtSuspended").value = "N";
                        alert("Staff member un-suspended");
                        suspended = false;
                    }
                    else {
                        alert("Staff member is still suspended");
                    }
                }
                else {
                    var confirmMessage = confirm("Suspend staff member?");
                    if (confirmMessage == true) {
                        document.getElementById("txtSuspended").value = "Y";
                        alert("Staff member suspended");
                        suspended = true;
                    }
                    else {
                        alert("Staff member was not suspended");
                    }
                }
            }

            function imgDelete_Clicked() {
                document.getElementById("rowHouse").style.display = "none";
                var confirmMessage = confirm("Delete staff member?");
                if (confirmMessage == true) {
                    alert("Staff member deleted");
                }
                else {
                    alert("Staff member was not deleted");
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