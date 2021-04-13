<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllUsersAndStaffMembers.aspx.cs" Inherits="FilmRecommendationSystem.AllUsersAndStaffMembers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FILM RECOMMENDER | MANAGEMENT</title>
    <link rel="stylesheet" href="StyleSheet.css" />
</head>

<body class="body" onload="onLoad()" >
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
                    <a href="Homepage.aspx">LOG OUT</a>
                </div>
            </div> 
        </div>

        <div class="search">
            <a onclick="hyplnkSearch_Clicked()" class="label">SEARCH</a>
            <div class="textentry-container">
                <input autocomplete="off" class="textentry-field" type="text" id="myInput" onkeyup="filterSearchFunction()" />
            </div>
            <a onclick="hyplnkSearch_Clicked()" class="label">SEARCH</a>
        </div>
        
        <asp:Panel ID="pnlError" CssClass="mainContent" runat="server">
            <div class="header">Error</div>
            <div class="textSection">
                There was an error fulfilling your request; please try again later.
                <br />
                <br />
                <button type="button" id="btnReturnToHomepage" onclick="btnReturnToHomepage_Click()" class="proceedButton">Ok</button>
            </div>
        </asp:Panel>       

        <asp:Panel ID="pnlAllStaffMembers" CssClass="mainContent" runat="server">
            <label class="header">All staff members</label>
            <asp:ImageButton ID="imgbtnAddNewStaffMember" CssClass="addIcon" OnClick="imgbtnAddNewStaffMember_Click" ImageUrl="~/Images/Add_plus icon.png" runat="server" />
                <asp:GridView ID="grdAllStaffMembers" CssClass="AllUsersFilmsTable" runat="server" AutoGenerateColumns="false" 
                    OnRowEditing="grdAllStaffMembers_RowEditing" OnRowUpdating="grdAllStaffMembers_RowUpdating" 
                    OnRowDeleting="grdAllStaffMembers_RowDeleting">
                    <Columns>
                        <asp:TemplateField HeaderText="Id" HeaderStyle-CssClass="columnHeader" ItemStyle-CssClass="columnContent">
                            <ItemTemplate>
                                <asp:Label ID="lblStaffMemberId" Text='<%#Eval("StaffMemberId")%>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="UserId" HeaderStyle-CssClass="columnHeader" ItemStyle-CssClass="columnContent">
                            <ItemTemplate>
                                <asp:Label ID="lblUserId" runat="server" Text='<%# Eval("UserId") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PrivilegeLevelId" HeaderStyle-CssClass="columnHeader" ItemStyle-CssClass="columnContent">
                            <ItemTemplate>
                                <asp:Label ID="lblPrivilegeLevelId" Text='<%# Eval("PrivilegeLevelId") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPrivilegeLevelId" Text='<%# Eval("PrivilegeLevelId") %>' runat="server"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="FirstName" HeaderStyle-CssClass="columnHeader" ItemStyle-CssClass="columnContent">
                            <ItemTemplate>
                                <asp:Label ID="lblFirstName" Text='<%# Eval("FirstName") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtFirstName" Text='<%# Eval("FirstName") %>' runat="server"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="LastName" HeaderStyle-CssClass="columnHeader" ItemStyle-CssClass="columnContent">
                            <ItemTemplate>
                                <asp:Label ID="lblLastName" Text='<%# Eval("LastName") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtLastName" Text='<%# Eval("LastName") %>' runat="server"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Suspended" HeaderStyle-CssClass="columnHeader" ItemStyle-CssClass="columnContent">
                            <ItemTemplate>
                                <asp:Label ID="lblAllowed" Text='<%# Eval("Allowed") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:CheckBox ID="chkAllowed" EnableViewState="false" Text='<%# Eval("Allowed") %>' runat="server" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Actions" HeaderStyle-Font-Italic="true" ItemStyle-CssClass="tablecell-actions">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgbtnEdit" ImageUrl="~/Images/Edit_icon.png" CssClass="action_icon" commandname="Edit" ToolTip="Edit this record" runat="server" />
                                <asp:ImageButton ID="imgbtnDelete" ImageUrl="~/Images/TrashCan.png" OnClientClick="return DeleteFilm()" CssClass="action_icon" commandname="Delete" ToolTip="Delete this record" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
        </asp:Panel>        

        <asp:Panel ID="pnlNewStaffMember" CssClass="mainContent" runat="server">
                <asp:Label ID="lblActionStaffMember" CssClass="header" runat="server">Add new staff member</asp:Label>
            
            <asp:Panel ID="pnlNewStaffMemberUserId" CssClass="loginSection" runat="server">
                    <asp:Label runat="server" AssociatedControlID="ddlUserId" CssClass="textentry-label">UserId</asp:Label>
                    <div class="textentry-field">
                        <asp:DropDownList ID="ddlUserId" CssClass="userPrivilegeDropdown" runat="server"></asp:DropDownList>
                    </div>
            </asp:Panel>

                <div class="loginSection">
                    <asp:Label runat="server" AssociatedControlID="txtNewStaffMemberFirstName" CssClass="textentry-label">First name</asp:Label>
                    <div class="textentry-field">
                        <asp:TextBox runat="server" AutoCompleteType="Disabled" placeholder="Carl" ID="txtNewStaffMemberFirstName" CssClass="textentry-fieldsize"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="test" ControlToValidate="txtNewStaffMemberFirstName" runat="server" ErrorMessage="Field must not be blank"></asp:RequiredFieldValidator>
                        <br />
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
            <div class="loginSection">
                <asp:Label runat="server" AssociatedControlID="txtNewStaffMemberLastName" CssClass="textentry-label">Last name:</asp:Label>
                <div class="textentry-field">
                    <asp:TextBox runat="server" placeholder="Denham" AutoCompleteType="Disabled" ID="txtNewStaffMemberLastName" CssClass="textentry-fieldsize"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="txtNewStaffMemberLastName" runat="server" ErrorMessage="Field must not be blank"></asp:RequiredFieldValidator>
                    <br />
                    <asp:CustomValidator runat="server"
                        ValidationGroup="vldgrpNewStaffMember"
                        EnableClientScript="true"
                        ValidateEmptyText="true"
                        ErrorMessage="Last name must be between 0-50 characters."
                        ClientValidationFunction="ValidateNewStaffMemberLastName" 
                        ControlToValidate="txtNewStaffMemberLastName">
                    </asp:CustomValidator>
                </div>
            </div>
                <div class="loginSection">
                    <asp:Label runat="server" AssociatedControlID="ddlPrivilegelevel" CssClass="textentry-label">Privilege level:</asp:Label>
                    <div class="textentry-field">
                    <asp:DropDownList ID="ddlPrivilegelevel" CssClass="userPrivilegeDropdown" runat="server">
                        <asp:ListItem Value="1">Standard</asp:ListItem>
                        <asp:ListItem Value="2">Administrator</asp:ListItem>
                    </asp:DropDownList>
                    </div>
                </div>
            <div class="loginSection">
                <label class="textentry-label">Suspended</label>
                <div class="textentry-field">
                    <asp:CheckBox ID="chkStaffMemberSuspended" runat="server" />
                </div>
            </div>
            <div class="loginSection">
                <div class="actionStaffMemberContainer">
                <div class="textentry-field">
                    <asp:Button ID="btnRegisterStaffMember" ValidationGroup="vldgrpNewStaffMember" 
                         OnClick="btnRegisterStaffMember_Click"
                        runat="server" Text="ADD STAFF MEMBER" CssClass="proceedButton" />
                </div>
                </div>
            </div>
        </asp:Panel>

            <asp:Panel ID="pnlAllUsers" CssClass="mainContent" runat="server">
                <label class="header">All users</label>
                <asp:Panel ID="Panel2" CssClass="AllUsersFilmsContainer" runat="server">
                    <asp:GridView ID="grdAllUsers" CssClass="AllUsersFilmsTable" OnRowEditing="grdAllUsers_RowEditing" OnRowUpdating="grdAllUsers_RowUpdating"
                        OnRowCancelingEdit="grdAllUsers_RowCancelingEdit" AutoGenerateColumns="false" runat="server">
                        <Columns>
                            <asp:TemplateField HeaderText="UserId" HeaderStyle-CssClass="columnHeader" ItemStyle-CssClass="columnContent">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserId" Text='<%#Eval("UserId")%>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Username" HeaderStyle-CssClass="columnHeader" ItemStyle-CssClass="columnContent">
                                <ItemTemplate>
                                    <asp:Label ID="lblUsername" Text='<%#Eval("UserName")%>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email address" HeaderStyle-CssClass="columnHeader" ItemStyle-CssClass="columnContent">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmail" Text='<%#Eval("Email")%>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email confirmed?" HeaderStyle-CssClass="columnHeader" ItemStyle-CssClass="columnContent">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmailConfirmed" Text='<%#Eval("EmailConfirmed")%>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Last login" HeaderStyle-CssClass="columnHeader" ItemStyle-CssClass="columnContent">
                                <ItemTemplate>
                                    <asp:Label ID="lblLastLogin" Text='<%#Eval("LastLogin")%>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Suspended?" HeaderStyle-CssClass="columnHeader" ItemStyle-CssClass="columnContent">
                                <ItemTemplate>
                                    <asp:Label ID="lblSuspended" runat="server" Text='<%#Eval("LockoutEnabled")%>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:CheckBox ID="chkSuspended" runat="server" Text='<%#Eval("LockoutEnabled")%>' />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Suspended end date" HeaderStyle-CssClass="columnHeader" ItemStyle-CssClass="columnContent">
                                <ItemTemplate>
                                    <asp:Label ID="lblSuspendedEndDate" Text='<%#Eval("LockoutEndDateUtc")%>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Actions" HeaderStyle-Font-Italic="true" ItemStyle-CssClass="tablecell-actions">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgbtnEdit" ImageUrl="~/Images/Edit_icon.png" CssClass="action_icon" commandname="Edit" ToolTip="Edit this record" runat="server" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:ImageButton ID="imgbtnSaveChanges" ImageUrl="~/Images/Green tick_save.png" CssClass="action_icon" CommandName="Update" ToolTip="Save changes" runat="server" />
                                    <asp:ImageButton ID="imgbtUndoChanges" ImageUrl="~/Images/WatchLater.png" CssClass="action_icon" OnClick="imgbtUndoChanges_Click" ToolTip="Undo changes" runat="server" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
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
            function onLoad() {
                //document.getElementById("pnlNewStaffMember").style.display = "none";
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
            })

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
                var firstName = document.getElementById("txtNewStaffMemberFirstName").value;
                if (firstName.length == 0) {
                    return args.IsValid = false;
                }
                if (firstName.length > 50) {
                    return args.IsValid = false;
                }
                else {
                    return args.IsValid = true;
                }
            }

            function ValidateNewStaffMemberLastName(sender, args) {
                var lastName = document.getElementById("txtNewStaffMemberLastName").value;
                if (lastName.length == 0) {
                    return args.IsValid = false;
                }
                if (lastName.length > 50) {
                    return args.IsValid = false;
                }
                else {
                    return args.IsValid = true;
                }
            }

            function imgbtnSuspendUser_Clicked() {
                var confirmMessage = confirm("Suspend user?");
                if (confirmMessage == true) {
                    alert("User suspended");
                }
                else {
                    alert("No changes made");
                    return false;
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
            
        </script>
    </form>
</body>
</html>