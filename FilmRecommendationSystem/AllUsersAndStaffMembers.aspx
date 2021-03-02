<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllUsersAndStaffMembers.aspx.cs" Inherits="FilmRecommendationSystem.AllUsersAndStaffMembers" %>

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
                <asp:Label ID="lblAllPerson" runat="server"></asp:Label>
            </p>
            <br />
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

        <asp:Panel ID="pnlAllStaffMembers" runat="server">
            <label class="page-subheader">All staff members</label>
            <asp:ImageButton ID="imgbtnAddNewStaffMember" CssClass="allstaffmembers-add" OnClientClick="imgbtnAddNewStaffMemberProcess_Clicked()" OnClick="imgbtnAddNewStaffMember_Click" ImageUrl="~/Images/Add_plus icon.png" runat="server" />


            <asp:GridView CssClass="table-management" ID="grdAllStaffMembers" runat="server" AutoGenerateColumns="false" 
                OnRowEditing="grdAllStaffMembers_RowEditing" EnableViewState="false" OnRowUpdating="grdAllStaffMembers_RowUpdating" 
                OnRowDeleting="grdAllStaffMembers_RowDeleting">
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
                    <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
                </Columns>
            </asp:GridView>
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
        </asp:Panel>
        </div>
        
        <br />
        <br />
        <br />
        <asp:Panel ID="pnlNewStaffMember" class="account" runat="server">

                <asp:Label ID="lblActionStaffMember" class="page-subheader" runat="server"></asp:Label>

            
            <asp:Panel ID="pnlNewStaffMemberUserId" CssClass="register-section" runat="server">
                    <asp:Label runat="server" AssociatedControlID="ddlUserId" CssClass="textentry-label">UserId</asp:Label>
                    <div class="textentry-field">
                        <asp:DropDownList ID="ddlUserId" runat="server"></asp:DropDownList>
                    </div>
            </asp:Panel>

                <div class="register-section">
                    <asp:Label runat="server" AssociatedControlID="txtNewStaffMemberFirstName" CssClass="textentry-label">First name</asp:Label>
                    <div class="textentry-field">
                        <asp:TextBox runat="server" placeholder="Carl" ID="txtNewStaffMemberFirstName" CssClass="textentry-fieldsize"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtNewStaffMemberFirstName" runat="server" ErrorMessage="Field must not be blank"></asp:RequiredFieldValidator>
                        <asp:CustomValidator runat="server"
                            ValidationGroup="vldgrpNewStaffMember"
                            ValidateEmptyText="true"
                            EnableClientScript="true"
                            ErrorMessage="First name must be between 0-50 characters."
                            ClientValidationFunction="ValidateNewStaffMemberFirstName" 
                            ControlToValidate="txtNewStaffMemberFirstName">
                        </asp:CustomValidator>
                    </div>
                </div>
            <div class="register-section">
                <asp:Label runat="server" AssociatedControlID="txtNewStaffMemberLastName" CssClass="textentry-label">Last name:</asp:Label>
                <div class="textentry-field">
                    <asp:TextBox runat="server" placeholder="Denham" ID="txtNewStaffMemberLastName" CssClass="textentry-fieldsize"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="txtNewStaffMemberLastName" runat="server" ErrorMessage="Field must not be blank"></asp:RequiredFieldValidator>
                    <asp:CustomValidator runat="server"
                        ValidationGroup="vldgrpNewStaffMember"
                        EnableClientScript="true"
                        ErrorMessage="Last name must be between 0-50 characters."
                        ClientValidationFunction="ValidateNewStaffMemberLastName" 
                        ControlToValidate="txtNewStaffMemberLastName">
                    </asp:CustomValidator>
                </div>
            </div>

                <div class="register-section">
                    <asp:Label runat="server" AssociatedControlID="ddlPrivilegelevel" CssClass="textentry-label">Privilege level:</asp:Label>
                    <div class="textentry-field">
                    <asp:DropDownList ID="ddlPrivilegelevel" runat="server">
                        <asp:ListItem Value="1">Standard</asp:ListItem>
                        <asp:ListItem Value="2">Administrator</asp:ListItem>
                    </asp:DropDownList>
                    </div>
                </div>

            <div class="register-section">
                <label class="textentry-label">Suspended</label>
                <asp:CheckBox ID="chkStaffMemberSuspended" runat="server" />
            </div>

            <div class="register-section">
                <div class="textentry-label"></div>
                <div class="textentry-field">
                    <asp:Button ID="btnRegisterStaffMember" ValidationGroup="vldgrpNewStaffMember" 
                        OnClientClick="return btnRegisterStaffMember_Click()" OnClick="btnRegisterStaffMember_Click"
                        runat="server" Text="ADD STAFF MEMBER" CssClass="registerbutton" />
                </div>
            </div>
        </asp:Panel>



        <br />
        <br />
        <br />
        <br />






        <div class="account">
            <label class="page-subheader">All users</label>
            
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
                    <asp:CommandField ShowEditButton="true"  />  
                </Columns>
            </asp:GridView>
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
        </asp:Panel>
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
                //document.getElementById("pnlNewStaffMember").style.display = "none";
            }

            function btnReturnToHomepage_Click() {
                location.href = "Homepage.aspx";
            }

            function btnRegisterStaffMember_Click() {
                if (Page_ClientValidate()) {
                    var confirmMessage = confirm("Add new staff member?");
                    if (confirmMessage == true) {
                        alert("Staff member added!");
                        return true;
                    }
                    else {
                        alert("Staff member was not added");
                        return false;
                    }
                }
                else {
                    alert("Fix page errors before continuing");
                }

            }

            function ValidateNewStaffMemberFirstName(sender, args) {
                var firstName = document.getElementById('txtNewStaffMemberFirstName').value;
                if (firstName.length == 0) {
                    args.IsValid = false;
                }
                if (firstName.length > 50) {
                    args.IsValid = false;
                }
                else {
                    args.IsValid = true;
                }

            }

            function ValidateNewStaffMemberLastName(sender, args) {
                var lastName = document.getElementById('txtNewStaffMemberLastName').value;
                if (lastName.length == 0) {
                    args.IsValid = false;

                }
                if (lastName.length > 50) {
                    args.IsValid = false;
                }
                else {
                    args.IsValid = true;
                }
            }




            function imgbtnAddNewStaffMemberProcess_Clicked() {
                document.getElementById("pnlNewStaffMember").style.display = "inline-block";
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