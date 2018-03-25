<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TeamMemberPage.aspx.cs" Inherits="TeamMemberPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script type="text/javascript">
        $(document).ready(function(){
        // the "href" attribute of .modal-trigger must specify the modal ID that wants to be triggered
        $('.modal-trigger').leanModal();
        });
        $(document).ready(function () {
            $('select').material_select();
    });
</script>
<div style ="position: relative; top: 60px;">


    <div style = "float: left; width: 15%;">
    <ul id="slide-out" class="side-nav fixed" style = "width:15%;">
            <li><div class="user-view">
                <asp:Image ID ="profilePicture" Height ="120px" Width ="120px" CssClass ="circle user" runat ="server"/>
                <h5><asp:Label ID="lblUser" runat="server" Text="" CssClass ="user1"></asp:Label></h5>
                <asp:Label ID="lblBalance" runat="server" ></asp:Label>
            </div></li>
            <li><a href="TeamMemberPage.aspx">Home</a></li>
            <li> <a href="RewardTeamMember.aspx">Reward Team Member</a></li>
            <li> <a href="BuyRewards.aspx">Buy Rewards</a></li>
            <li> <a href="MyRewards.aspx">My Rewards</a></li>
            <li><a href="AccountSettingTeamMember.aspx">Account Settings</a></li>
            <li><a href="CommunityPostFeed.aspx">Community Events</a></li>
            <li><a href="/Default.aspx">Logout</a></li>

    </ul>
    </div>
    
            
    

<div style ="float: right; width: 85%;">
    <div style = "margin-left:auto; margin-right:auto; width:85%;">
    <nav class="feednav" >
        <div class="nav-wrapper">
            <a class="brand-logo nav1 panel">Activity Panel</a>
            <ul id="nav-mobile" class="right hide-on-med-and-down"> 
            <li><a href="" class="nav1 modal-trigger" data-target="modal1">Give Reward</a></li>
            <li>
                    <asp:DropDownList ID="giverAndReceiver" runat="server" OnSelectedIndexChanged="giverAndReceiver_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem>All Transactions</asp:ListItem>
                    <asp:ListItem>Your Transactions</asp:ListItem>
                    <asp:ListItem>Your Rewards Given</asp:ListItem>
                    <asp:ListItem>Your Rewards Received</asp:ListItem>
                    </asp:DropDownList>
            </li>
            <li><a class="dropdown-button nav1" href="#!" data-activates="dropdown1">Notifications </a></li>
            </ul>
        </div>
    </nav>

    <asp:Panel ID ="Panel1" runat="server"></asp:Panel>
    </div>
</div>

<%-- give reward button --%>
    <div id="modal1" class="modal">
    <div class="modal-content">
      <h4>Reward</h4>
      <!-- Drop Down Menu-->


               <div class="row">
                  
                    <div class="row modal-form-row">
                      <div class="input-field col s12">
                        <input id="image_url1" type="text" class="validate">
                        <label for="image_url1">Team Member Being Rewarded</label>
                    </div>
                  </div>            
                
              </div>

<!-- Select money amount to reward-->
      <div class="input-field col s12">
                  <%--<select>
                    <option value="1">$10.00</option>
                    <option value="2">$25.00</option>
                    <option value="3">$50.00</option>
                  </select>--%>
                   <asp:DropDownList ID="ddlRewardValue" runat="server">
                    <asp:ListItem Value="10">$10</asp:ListItem>
                    <asp:ListItem Value="25">$25</asp:ListItem>
                    <asp:ListItem Value="50">$50</asp:ListItem>
                    </asp:DropDownList>
                  <label>Reward Amount</label>
                </div>
                

                <!-- Select what value it's fulfilling -->
   <div class="input-field col s12 m6">
                  <asp:DropDownList ID="ddlCompanyValue" runat="server">
                      <asp:ListItem Value="Health, Well Being and Safety of Team Members">Health, Well Being and Safety of Team Members</asp:ListItem>
                      <asp:ListItem Value="Community Involvement">Community Involvement</asp:ListItem>
                      <asp:ListItem Value="Education">Education</asp:ListItem>
                      <asp:ListItem Value="Customer Service">Customer Service</asp:ListItem>
                      <asp:ListItem Value="Retaining/Attracting New Customers">Retaining/Attracting New Customers</asp:ListItem>
                      <asp:ListItem Value="Process Improvement Initiatives">Process Improvement Initiatives</asp:ListItem>
                      <asp:ListItem Value="Leadership Development">Leadership Development</asp:ListItem>
                      <asp:ListItem Value="Team Building">Team Building</asp:ListItem>
                  </asp:DropDownList>
                  <label>Company Value</label>
                </div>
               
                   <!-- Select for what catagory -->
                <div class="input-field col s12">
                  <select>
                    <option value="" disabled selected> Creative</option>
                    <option value="2">Distinguished</option>
                    <option value="3">Exceptional</option>
                    <option value="4">Fresh Approach</option>
                    <option value="5">Superior</option>
                    <option value="6">Ingenious</option>
                    <option value="7">Incomparable</option>
                    <option value="8">Outstanding</option>
                    <option value="9">Surprising</option>
                    <option value="10">Symbolic</option>
                    <option value="11">Unexpected</option>
                  </select>
                  <label>Category</label>
                </div>
            

               <div class="row">
                  <form class="col s12">
                    <div class="row modal-form-row">
                      <div class="input-field col s12">
                        <input id="image_url" type="text" class="validate">
                        <label for="image_url">Description</label>
                    </div>
                  </div>            
                </form>
              </div>

               <p>
                    <input type="checkbox" id="test5" />
                    <label for="test5">Private Transaction</label>
              </p>
              <div class="modal-footer">
                    <a class=" modal-action modal-close waves-effect waves-green btn-flat">Send Reward!</a>
                  </div>
            </div>
          </div>             
        
      </div>
    
      

   
<%--<center>
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
    <h1 class="display-4" style="color:white; font: bold;">News Feed</h1>
    <div class="jumbotron agent-1" style="width:78%; background-color:lightblue; opacity: 0.83; border-radius:25px; padding-top:1px;">
        <br />
        <br />
        <div>
            <asp:DropDownList ID="giverAndReceiver" runat="server" OnSelectedIndexChanged="giverAndReceiver_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem>All Transactions</asp:ListItem>
                <asp:ListItem>Your Transactions</asp:ListItem>
                <asp:ListItem>Your Rewards Given</asp:ListItem>
                <asp:ListItem>Your Rewards Received</asp:ListItem>
            </asp:DropDownList>
        </div>
        <br />
        <div class="container" style="padding-top: -20px;">
            <asp:Panel ID="Panel1" runat="server"></asp:Panel>
        </div>
    </div>
</center>--%>

</asp:Content>
