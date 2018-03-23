<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AnalyticsPage.aspx.cs" Inherits="AnalyticsPage" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>


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
    <h1 class="display-4" style="color:white; font: bold;">News Feed</h1>
    <div class="jumbotron agent-1" style="width:78%; background-color:lightblue; opacity:0.88; border-radius:25px; padding-top:1px;">
        <br />
        <br />
        <div>
            <asp:DropDownList ID="giverAndReceiver" runat="server" OnSelectedIndexChanged="giverAndReceiver_SelectedIndexChanged" AutoPostBack="True" Width="476px">
                <asp:ListItem>Top Rewards Received</asp:ListItem>
                <asp:ListItem>Top Rewards Given</asp:ListItem>
                <asp:ListItem>Top Reward Sales</asp:ListItem>
                <asp:ListItem>Total Rewards by Month</asp:ListItem>
            </asp:DropDownList>
        </div>
        <br />
        <div class="container" style="padding-top: -20px;">
            <asp:Chart ID="rewardsReceived" runat="server" DataSourceID="lab4ConnectionString" Height="489px" Width="1020px"> 
                <Series>
                    <asp:Series Name="Series1" XValueMember="UserName" YValueMembers="RewardsReceived"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
            <asp:SqlDataSource ID="lab4connectionstring" runat="server" ConnectionString="<%$ ConnectionStrings:lab4ConnectionString %>" SelectCommand="SELECT [User].UserName, COUNT([Transaction].ReceiverID) AS RewardsReceived FROM [User] LEFT OUTER JOIN [Transaction] ON [User].UserID = [Transaction].ReceiverID GROUP BY [User].UserName"></asp:SqlDataSource>
            
            <asp:Chart ID="rewardsGiven" runat="server" DataSourceID="SqlDataSource2" Height="489px" Width="1020px">
                <Series>
                    <asp:Series Name="Series1" XValueMember="UserName" YValueMembers="RewardsGiven">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Lab4ConnectionString2 %>" SelectCommand="SELECT [User].UserName, COUNT([Transaction].GiverID) AS RewardsGiven FROM [User] LEFT OUTER JOIN [Transaction] ON [User].UserID = [Transaction].GiverID GROUP BY [User].UserName"></asp:SqlDataSource>
           
            
            <asp:Chart ID="topSales" runat="server" DataSourceID="SqlDataSource3" Height="489px" Width="1020px">
                <Series>
                    <asp:Series Name="Series1" XValueMember="RewardName" YValueMembers="Sales">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Lab4ConnectionString3 %>" SelectCommand="SELECT [Reward].[RewardName], COUNT([RewardEarned].[RewardID]) AS Sales
FROM [Reward]
LEFT OUTER JOIN [RewardEarned] ON [Reward].[RewardID] = [RewardEarned].[RewardID]
GROUP BY [Reward].[RewardName]"></asp:SqlDataSource>
            <asp:Chart ID="RewardsPerMonth" runat="server" DataSourceID="SqlDataSource4" Height="489px" Width="1020px">
                <Series>
                    <asp:Series Name="Series1" XValueMember="Month" YValueMembers="Value">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:Lab4ConnectionString4 %>" SelectCommand="SELECT Month(TransactionDate) AS Month, SUM(RewardValue) AS [Value]
  FROM [Transaction]
  GROUP BY MONTH(TransactionDate)"></asp:SqlDataSource>
            <br />
           
            
        </div>
    </div>
</center>

</asp:Content>