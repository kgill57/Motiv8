<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AccountSettingTeamMember.aspx.cs" Inherits="AccountSettingTeamMember" %>
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
    <h1 class="display-4">Account Settings</h1>
    <div class="jumbotron agent-1" style="width:78%; background-color:lightblue; opacity:0.88; border-radius:25px; padding-top:1px;">
        <br />
        <br />
        <div>
            <div class="form-group">
                <table >
                    <tr>
                        <td style="width: 160px">Upload Profile Picture:</td>
                        <td>   
                            <asp:FileUpload ID ="UploadPicture" runat ="server" />
                            <asp:Button ID ="btnUpload" CssClass="btn btn-primary" runat ="server" Text ="Upload" OnClick="btnUpload_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="form-group">
                <asp:TextBox ID="txtCurrentPass" CssClass="form-control" placeholder="Current Password" runat="server" Width="200px" MaxLength="200"></asp:TextBox>
            </div>
            <div class="form-group">
                 <asp:TextBox ID="txtNewPass1" CssClass="form-control" placeholder="New Password" runat="server" Width="200px" MaxLength="200"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:TextBox ID="txtNewPass2" CssClass="form-control" placeholder="Confirm New Password" runat="server" Width="200px" MaxLength="200"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="btnChangePass" CssClass="btn btn-primary" runat="server" OnClick="btnChangePass_Click" Text="Confirm Password Change" Width="200px" />
            </div>
        </div>

        <br />

        <asp:Label ID="lblResult" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>

    </div>
</center>         
           
</asp:Content>
