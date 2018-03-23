<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RewardTeamMember.aspx.cs" Inherits="RewardTeamMember" %>

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
            <li><a href="TeamMemberPage.aspx">Home</a></li>
            <li> <a href="RewardTeamMember.aspx">Reward Team Member</a></li>
            <li> <a href="BuyRewards.aspx">Buy Rewards</a></li>
            <li> <a href="MyRewards.aspx">My Rewards</a></li>
            <li><a href="AccountSettingTeamMember.aspx">Account Settings</a></li>
            <li><a href="CommunityPostFeed.aspx">Community Events</a></li>
            <li><a href="/Default.aspx">Logout</a></li>
        </ul>
    </div>

<center>
    <h1 class="display-4">Reward A Team Member</h1>
    <div class="jumbotron agent-1" style="width:78%; background-color:lightblue; opacity:0.88; border-radius:25px; padding-top:1px;">
        <asp:Label ID="lblResult" runat="server" Text="" style="color:green; font:bold"></asp:Label>
        <br />
        <br />
        <div style="width:50%; text-align:left; padding-left:70px;">
            <div class="form-group">
                <asp:Label ID="lblReceiver" runat="server" Text="Team Member Being Rewarded: " style="font-weight: 700"></asp:Label>      
                <asp:DropDownList ID="drpUsernames" runat="server">
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label ID="lblRewardValue" runat="server" Text="Reward Value: " style="font-weight: 700"></asp:Label>      
                <asp:DropDownList ID="ddlRewardValue" runat="server" AutoPostBack="true">
                    <asp:ListItem Value="10">$10</asp:ListItem>
                    <asp:ListItem Value="25">$25</asp:ListItem>
                    <asp:ListItem Value="50">$50</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="reqRewardValue" ControlToValidate="ddlRewardValue" Text="(Required)" Display="Dynamic" runat ="server" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <asp:Label ID="lblCompanyValue" runat="server" style="font-weight: 700" Text="Company Value: "></asp:Label>
                <asp:DropDownList ID="ddlCompanyValue" runat="server" AutoPostBack="true">
                    <asp:ListItem Value="Health, Well Being and Safety of Team Members">Health, Well Being and Safety of Team Members</asp:ListItem>
                    <asp:ListItem>Community Involvement</asp:ListItem>
                    <asp:ListItem>Customer Service and Retention/Attracting New Customers</asp:ListItem>
                    <asp:ListItem>Process Improvement Initiatives</asp:ListItem>
                    <asp:ListItem>Leadership Development/Mentoring/Team Building/Education</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="reqCompanyValue" ControlToValidate="ddlCompanyValue" Text="(Required)" Display="Dynamic" runat ="server" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <asp:Label ID="lblCategory" runat="server" style="font-weight: 700" Text="Category: "></asp:Label>
                <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="true">
                    <asp:ListItem>Creative</asp:ListItem>
                    <asp:ListItem>Distinguished</asp:ListItem>
                    <asp:ListItem>Exceptional</asp:ListItem>
                    <asp:ListItem>Fresh Approach</asp:ListItem>
                    <asp:ListItem>Superior</asp:ListItem>
                    <asp:ListItem>Ingenious</asp:ListItem>
                    <asp:ListItem>Incomparable</asp:ListItem>
                    <asp:ListItem>Outstanding</asp:ListItem>
                    <asp:ListItem>Surprising</asp:ListItem>
                    <asp:ListItem>Symbolic</asp:ListItem>
                    <asp:ListItem>Unexpected</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="reqCategory" ControlToValidate="ddlCategory" Text="(Required)" Display="Dynamic" runat ="server" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <asp:TextBox ID="txtDescription" style="height:200px; width:400px;" textmode="MultiLine" placeholder="Description" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqDesc" ControlToValidate="txtDescription" runat="server" Text="(Required)" Display="Dynamic" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <asp:CheckBox ID="chkPrivate" runat="server" AutoPostBack="True" style="font-weight: 700" Text="Should Transaction Be Private?" />
            </div>
            <asp:Button ID="btnSubmit" CssClass="btn btn-primary" runat="server" Text="Submit Reward" OnClick="btnSubmit_Click" />
            <asp:Button ID="AutoFillRewardSendID" CssClass="btn btn-secondary" runat="server" OnClick="AutoFillRewardSendID_Click" CausesValidation="false" Text="AutoFillRewardSend" />
        </div>
        
    </div>
</center>
    
</asp:Content>

