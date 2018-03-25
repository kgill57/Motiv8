<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserOptions.aspx.cs" Inherits="UserOptions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <link href="Style/desktop.css" rel="stylesheet" />
    <link href="Style/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/Sidebar.js"></script>
     <div id ="sidebar">
        <div class="toggle-btn" onclick="toggleSidebar();">
            <span></span>
            <span></span>
            <span></span>
        </div>
        <ul>
            <li><asp:Image ID ="profilePicture" Height ="120px" Width ="120px" runat ="server"/></li>
            <li> <asp:Label ID="lblUser" runat="server" Text=""></asp:Label></li>
            <li><asp:Label ID="lblBalance" runat="server" ></asp:Label></li>
            <li><a href="AdminPage.aspx">Home</a></li>
            <li> <a href ="/UserOptions.aspx">User Options</a></li>
            <li> <a href="/ViewRewards.aspx">View Rewards</a></li>
            <li> <a href ="/AddRewardProviders.aspx">View Reward Providers</a></li>
            <li><a href="AnalyticsPage.aspx">View Analytics</a></li>
            <li><a href="/ManageCommunityPost.aspx">Community Events</a></li>
            <li><a href="/Default.aspx">Logout</a></li>
        </ul>
    </div>
    
<center>
    <h1 class="display-4">User Options</h1>
    <div class="jumbotron agent-1" style="width:78%; background-color:lightblue; opacity:0.88; border-radius:25px; padding-top:1px;">
        <asp:Label ID="lblError" runat="server" Text="" style="color:red; font:bold"></asp:Label>
        <br />
        <br />
        <div style="width:50%">
            <div class="form-group">
            <asp:TextBox ID="txtFName" class="form-control" runat="server" placeholder="First Name" MaxLength="30"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqFName" ControlToValidate="txtFName" Display="Dynamic" Text="(Required)" Font-Bold="true" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <asp:TextBox ID="txtMI" CssClass="form-control" runat="server" placeholder="Middle Initial" MaxLength="1"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:TextBox ID="txtLName" placeholder="Last Name" CssClass="form-control" runat="server" MaxLength="30"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqLName" ControlToValidate="txtLName" Display="Dynamic" Text="(Required)" Font-Bold="true" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <asp:TextBox ID="txtEmail" placeholder="Email" CssClass="form-control" runat="server" TextMode="Email" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqEmail" ControlToValidate="txtEmail" Display="Dynamic" Text="(Required)" Font-Bold="true" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <asp:TextBox ID="txtUsername" placeholder="Username" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqUsername" ControlToValidate="txtUsername" Display="Dynamic" Text="(Required)" Font-Bold="true" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
            </div>
            <div style="float:left;">
                <asp:DropDownList ID="ddlAccountType" placeholder="Account Type" runat="server">
                    <asp:ListItem Value="0">User</asp:ListItem>
                    <asp:ListItem Value="1">Admin</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div style="float:left;">
                <asp:DropDownList ID="CompanyDropdown" runat="server" DataSourceID="SqlDataSource1" DataTextField="CompanyName" DataValueField="CompanyName">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:lab4ConnectionString %>" SelectCommand="SELECT [CompanyName] FROM [Employer]"></asp:SqlDataSource>
            </div>
            <br />
            <br />
            <div style="float: left;">
                <asp:Button ID="btnInsertUser" runat="server" CssClass="btn btn-primary" OnClick="btnInsertUser_Click" Text="Insert User" />
                <asp:Button ID="btnAutoFillUser" CssClass="btn btn-secondary" runat="server" OnClick="btnAutoFillUser_Click" Text="AutoFill User" CausesValidation="False" />
                <br />
                
            </div>
        </div>
        <br />
        <br />
        <br />
        <div>
            <asp:GridView ID="grdUsers" ValidationGroup="validNewEmp" runat="server" AutoGenerateColumns="False" DataKeyNames="UserID" OnRowCancelingEdit="grdUsers_RowCancelingEdit" OnRowDeleting="grdUsers_RowDeleting" OnRowEditing="grdUsers_RowEditing" OnRowUpdating="grdUsers_RowUpdating">
            <Columns>
                <asp:CommandField ShowEditButton="true" CausesValidation="true" ValidationGroup="validNewEmp"/>
                <asp:TemplateField HeaderText="First Name">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtgvFName" runat="server" MaxLength="30" Text='<%# Eval("FName") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqgvFName" ControlToValidate="txtgvFName" Text="(Required)" Display="Dynamic" Runat="server" Font-Bold="True" ForeColor="Red" ValidationGroup="validNewEmp"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblFName" runat="server" Text='<%# Eval("FName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Last Name">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtgvLName" runat="server" MaxLength="30" Text='<%# Eval("LName") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqgvLName" ControlToValidate="txtgvLName" Text="(Required)" Display="Dynamic" Runat="server" Font-Bold="True" ForeColor="Red" ValidationGroup="validNewEmp"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblLName" runat="server" Text='<%# Eval("LName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MI">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtgvMI" runat="server" MaxLength="1" Text='<%# Eval("MI") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblMI" runat="server" Text='<%# Eval("MI") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtgvEmail" runat="server" MaxLength="50" Text='<%# Eval("Email") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqgvEmail" ControlToValidate="txtgvEmail" Text="(Required)" Display="Dynamic" Runat="server" Font-Bold="True" ForeColor="Red" ValidationGroup="validNewEmp"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Username">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtgvUsername" runat="server" MaxLength="50" Text='<%# Eval("NickName") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqgvUsername" ControlToValidate="txtgvUsername" Text="(Required)" Display="Dynamic" Runat="server" Font-Bold="True" ForeColor="Red" ValidationGroup="validNewEmp"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblUsername" runat="server" Text='<%# Eval("NickName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Admin">
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlgvAdmin" runat="server" SelectedValue='<%# Bind("Admin") %>'>
                            <asp:ListItem Value="0">User</asp:ListItem>
                            <asp:ListItem Value="1">Admin</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="reqgvAdmin" ControlToValidate="ddlgvAdmin" Text="(Required)" Display="Dynamic" Runat="server" Font-Bold="True" ForeColor="Red" ValidationGroup="validNewEmp"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblAdmin" runat="server" Text='<%# Eval("Admin") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Employed Status">
                    <EditItemTemplate>
                        <asp:DropDownList ID="drpStatus" runat="server" SelectedValue='<%# Bind("EmployedStatus") %>'>
                            <asp:ListItem value="1">Employed</asp:ListItem>
                            <asp:ListItem Value="0">Not Employed</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("EmployedStatus") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Account Balance">
                    <EditItemTemplate>
                        <asp:Label ID="lblAcctBal" runat="server" Text='<%# Eval("AccountBalance", "{0:c}") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblAcctBal" runat="server" Text='<%# Eval("AccountBalance", "{0:c}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <asp:Label ID="lblEmptly" runat="server" Text="No Records Available"></asp:Label>
            </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
        

        
</center>
    
        
                
                    
                

               

                

            
            

    
    
</asp:Content>

