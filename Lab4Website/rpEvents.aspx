<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="rpEvents.aspx.cs" Inherits="rpEvents" %>

<asp:Content ID="ContentHeader" ContentPlaceHolderID="ContentPlaceHolderHeader" Runat="Server">
                        
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<html>
    <head><title> MOTIV8 | Home
        </title>
          <!--Import Google fonts-->
          <link href="https://fonts.googleapis.com/css?family=Oxygen:700" rel="stylesheet">
          <!--Import Google Icon Font-->
          <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
          <!--Import materialize.css-->
          <link type="text/css" rel="stylesheet" href="css/materialize.css"  media="screen,projection"/>

          <!--Let browser know website is optimized for mobile-->
          <meta name="viewport" content="width=device-width, initial-scale=1.0"/>

          <!--modal style-->
          <style type="text/css">
            .modal {
                  max-height: 90%;
                }

                .modal-form-row {
                  margin-bottom: 0px;
                }
          </style>
        
    </head>
    <body>
        
            <!-- side nav bar for profile-->
   
        <div style = "float: left; width: 15%;">
         <ul id="slide-out" class="side-nav fixed" style = "width:15%;">
            <li><div class="user-view">
                <asp:Image ID ="profilePicture" Height ="120px" Width ="120px" CssClass ="circle user" runat ="server"/>
                <h5><asp:Label ID="lblUser" runat="server" Text="" CssClass ="user1"></asp:Label></h5>
                <asp:Label ID="lblBalance" runat="server" ></asp:Label>
            </div></li>
          <li> <a href="rpRewards.aspx">Rewards</a></li>
          <li> <a href="Calendar.aspx">Calendar</a></li>
          <li> <a href="rpSettings.aspx">Settings</a></li>
          <li><a class="waves-effect" href="Default.aspx">Logout</a></li>
          <li><a><i class="material-icons nav1 modal-trigger" data-target="modal4"> help</i></a>
          </ul>
            </div>
          <a href="#" data-activates="slide-out" class="button-collapse"><i class="material-icons">menu</i></a>

        <!-- End Side Nav-->

        <!--Content -->

        <div class="container rewards">

                        <nav class="feednav">
                          <div class="nav-wrapper">
                            <a href="" class="brand-logo nav1 panel">Calendar</a>
                            <ul id="nav-mobile" class="right hide-on-med-and-down"> 
                                <li><a href="" class="nav1 modal-trigger" data-target="modal3">Add Event</a></li>
                                <!-- <li><a href="" class="nav1 modal-trigger" data-target="modal3">Add Event</a></li> -->
                            </ul>
                          </div>
                        </nav>
          

          <!-- Enter Google API Calendar-->

                                  <!-- enter calendar picture -->



    </body>
</html>
</asp:Content>
