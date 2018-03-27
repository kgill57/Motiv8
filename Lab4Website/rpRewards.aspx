<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="rpRewards.aspx.cs" Inherits="rpRewards" EnableEventValidation="false" %>

<asp:Content ID="ContentHeader" ContentPlaceHolderID="ContentPlaceHolderHeader" Runat="Server">
                        
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <html>
        <head>

            <title> MOTIV8 | Home
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

             


            <div class="container rewards">

                        <nav class="feednav">
                          <div class="nav-wrapper">
                            <a href="" class="brand-logo nav1 panel">Your Current Rewards</a>
                            <ul id="nav-mobile" class="right hide-on-med-and-down"> 
                                <li><asp:Button runat="server" ID="btnAddReward" Text="Add Reward" CssClass="nav1 modal-trigger" OnClick="btnAddReward_Click"/></li>
                            </ul>
                          </div>
                        </nav>
                <br />
                <br />
                <div runat="server" id="addReward" visible="false" style="width: 40%; margin-left:auto; margin-right:auto; background-color:white; padding:20px;">
                    <asp:Panel runat="server" Visible="true" ID="RewardPanel">
                        <asp:TextBox runat="server" ID="txtRewardName" placeholder="Reward Name"></asp:TextBox>
                        <asp:TextBox runat="server" ID="txtRewardQuantity" placeholder="Reward Quantity"></asp:TextBox>
                        <asp:TextBox runat="server" ID="txtRewardAmount" placeholder="Reward Amount"></asp:TextBox>
                        <asp:Button runat="server" ID="btnUploadPic" Text="Upload Photo" />
                        <asp:Button ID="btnInsert" runat="server" Text="Add Reward" OnClick="btnInsert_Click" />
                        <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
                    </asp:Panel>
                    
                </div>
                
            </div>
            
            
           
          

          <!-- 25 Gift Card to Billy Jacks-->
          <%-- <div class="row">

                  <div class="col s4">
                        <div class="row">
                          <div class="col">
                            <div class="card">
                              <div class="card-image">
                                <img src="images/billyjacks.jpg">
                                <span class="card-title"> <strong>$25 Gift Card to Billy Jacks</strong></span>
                              </div>
                              <div class="card-content">
                                <p>We're a casual dine-in / carry-out restaurant and bar with a heavy emphasis on craft beer. We serve our take on every-day American favorites in boxes, tortillas, and on buns. There's usually some bacon involved. On weekends we brunch. Did i mention bacon? Whenever we're eating, we're usually drinking. Even some of our drinks are #teambacon. Sound like your kind of place? Find a bj's in your neck of the woods!</p>
                              </div>
                              <div class="card-action">
                                <a href="" class="card-action2">Edit</a>
                                <a href="" class="card-action2 modal-trigger" data-target="modal1">Delete</a>
                              </div>
                            </div>
                          </div>
                        </div>
                  </div>


                  <div class="col s4">
                    <div class="row">
                          <div class="col">
                            <div class="card">
                              <div class="card-image">
                                <img src="images/massanuttengetaway.jpg">
                                <span class="card-title"> <strong> $50 Gift Card to Massanuttens Water Park! </strong></span>
                              </div>
                              <div class="card-content">
                                <p>Massanutten's Outdoor Park is for all of the water and sun lovers out there! True competitors will have to try the Rockingham Racer head-first, downhill water slide. Or maybe the White Caps Wave Pool is more your style? Whether your family enjoys lounging or action-packed fun, the Outdoor WaterPark at Massanutten has got you covered.</p>
                              </div>
                              <div class="card-action">
                                <a href="" class="card-action2">Edit</a>
                                <a href="" class="card-action2 modal-trigger" data-target="modal1">Delete</a>
                              </div>
                            </div>
                          </div>
                        </div>
                  </div>
                  <div class="col s4">
                    <div class="row">
                          <div class="col">
                            <div class="card">
                              <div class="card-image">
                                <img src="images/jackbrowns.jog.jpg">
                                <span class="card-title"> <strong>$15 Gift Card to Jack Browns </strong></span>
                              </div>
                              <div class="card-content">
                                <p>A burger joint with a passion for craft beer. We offer over 100 craft beers and our award winning burger menu. We have beers from around the corner and from around the world. Let our highly trained staff guide you through our extensive menu, and experience the burger people love to talk about.
                                    </p>
                              </div>
                              <div class="card-action">
                                <a href="" class="card-action2">Edit</a>
                                <a href="" class="card-action2 modal-trigger" data-target="modal1">Delete</a>
                              </div>
                            </div>
                          </div>
                        </div>
                    <!-- Promo Content 3 ends here -->
      </div>

    </div> <!-- End 25 Gift Card to Billy Jacks-->

                <div runat="server" visible="false" id="modal2" class="modal">
                        <div class="modal-content">
                          <h4>Add Reward</h4>
                          <!-- Drop Down Menu-->
                     <form action="#">
                        <div class="file-field input-field">
                          <div class="btn">
                            <span>Upload Photo</span>
                            <input type="file">
                          </div>
                          <div class="file-path-wrapper">
                            <input class="file-path validate" type="text">
                          </div>
                        </div>
                      </form>
                                   <div class="row">
                                      <form class="col s12">
                                        <div class="row modal-form-row">
                                          <div class="input-field col s12">
                                            <input id="image_url" type="text" class="validate" value="Rocktown Beer Fest Tickets">
                                            <label for="image_url">Reward Title</label>
                                        </div>
                                      </div>            
                                    </form>
                                  </div>



                                       <div class="input-field col s12">
                                      <select>
                                        <option value=""> $10</option>
                                        <option value="2">$25</option>
                                        <option value="3">$50</option>
                                      </select>
                                      <label>Price</label>
                                    </div>

                                   <div class="row">
                                      <form class="col s12">
                                        <div class="row modal-form-row">
                                          <div class="input-field col s12">
                                            <input id="image_url" type="text" class="validate" value="10">
                                            <label for="image_url">Quantity</label>
                                        </div>
                                      </div>            
                                    </form>
                                  </div>--%>


                                    

                                    
                                

                                   <%--<div class="row">
                                      <form class="col s12">
                                        <div class="row modal-form-row">
                                          <div class="input-field col s12">
                                            <input id="image_url" type="text" class="validate">
                                            <label for="image_url">Description</label>
                                        </div>
                                      </div>            
                                    </form>

                                  </div>
                                  <div class="modal-footer">
                                        <a class=" modal-action modal-close waves-effect waves-green btn-flat">Add</a>
                                      </div>
                                </div>
                              </div>  --%>
                


                

        </body>
    </html>

</asp:Content>

