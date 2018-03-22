<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminPage.aspx.cs" Inherits="AdminPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
    <link href="Style/desktop.css" rel="stylesheet" />
    <link href="Style/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
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
    <h1 class="display-4" style="color:white; font: bold;">News Feed</h1>
    <div class="jumbotron agent-1" style="width:78%; background-color:lightblue; opacity:0.88; border-radius:25px; padding-top:20px;">
        <div class="container">
            <asp:Panel ID="Panel1" runat="server" ></asp:Panel>
        </div>
    </div>
</center>
</asp:Content>


