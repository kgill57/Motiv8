﻿<%@ Page Title="Buy Rewards" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BuyRewards.aspx.cs" Inherits="BuyRewards" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
    <h1 class="display-4">Purchase Rewards</h1>
    <div class="jumbotron agent-1" style="width:78%; background-color:lightblue; opacity:0.88; border-radius:25px; padding-top:1px;">
        <br />
        <asp:Button ID="btnBuy" CssClass="btn btn-primary" runat="server" Text="Buy Items" OnClick="btnBuy_Click" />
        <br />
        <br />
        <asp:Label ID="lblResult" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
        <div class="container">
            <asp:Panel ID="Panel1" runat="server"></asp:Panel>
        </div>
    </div>
</center>
    

    

    

    <br />
    <br />

    
</asp:Content>

