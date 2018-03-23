<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AnalyticsPage.aspx.cs" Inherits="AnalyticsPage" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="ContentHeader" ContentPlaceHolderID="ContentPlaceHolderHeader" Runat="Server">
                        <ul class="right hide-on-med-and-down">
                    
                        <li><a href="rewards.html" class="nav2">Current Rewards</a></li>
                        <li><a href="values.html" class="nav2">Company Values</a></li>

                        <li>
                          <form>
                            <div class="input-field search1">
                              <input id="search" type="search" required class="search1">
                              <label class="label-icon" for="search"><i class="material-icons icon-blue">search</i></label>
                            </div>
                          </form>
                        </li>
                      </ul>
                    </asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <html>
        <head>

            <title> MOTIV8 | Analytics
            </title>
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
            <div class="navbar-fixed">
                <nav>
                    <div class="nav-wrapper">
                      
                      <a href="#" data-activates="mobile-demo" class="button-collapse"><i class="material-icons">menu</i></a>
                      
                    
                        

                      <ul class="side-nav" id="mobile-demo">
                        <li><a href="rewards.html">Current Rewards</a></li>
                        <li><a href="values.html">Company Values</a></li>
                      </ul>
                    </div>
                </nav>
            </div> <!--End NAV -->

            <!-- side nav bar for profile-->
            <ul id="slide-out" class="side-nav fixed">
                  <li><div class="user-view">
                   <img class="circle user" src="images/boss.jpg">
                    <h4 class="user1">Jane Doe<h4>
                    <h5 class="user1"> Amin</h5>
                    <h6 class="user1"> $4,500<h6>
                  </div></li>
                  <li><a href="admin.html">Admin</a></li>
                   <li><a href="analytics.html">Analytics</a></li>
                  <li><a href="calendar.html">Calendar</a></li>
                  <li><a class="waves-effect" href="index.html">Logout</a></li>
                  <li><a><i class="material-icons nav1 modal-trigger" data-target="modal4"> help</i></a>
          </ul>
          <a href="#" data-activates="slide-out" class="button-collapse"><i class="material-icons">menu</i></a>

          <!-- featured person-->

          <div class="container featured" style="width:100%">

              <div class='tableauPlaceholder' id='viz1521823532881' style='position: relative; margin-left: 150px; width: 100%'><noscript><a href='#'><img alt='Admin Dashboard ' src='https:&#47;&#47;public.tableau.com&#47;static&#47;images&#47;Ad&#47;AdminAnalytics&#47;AdminDashboard&#47;1_rss.png' style='border: none' /></a></noscript><object class='tableauViz'  style='display:none;'><param name='host_url' value='https%3A%2F%2Fpublic.tableau.com%2F' /> <param name='embed_code_version' value='3' /> <param name='site_root' value='' /><param name='name' value='AdminAnalytics&#47;AdminDashboard' /><param name='tabs' value='no' /><param name='toolbar' value='yes' /><param name='static_image' value='https:&#47;&#47;public.tableau.com&#47;static&#47;images&#47;Ad&#47;AdminAnalytics&#47;AdminDashboard&#47;1.png' /> <param name='animate_transition' value='yes' /><param name='display_static_image' value='yes' /><param name='display_spinner' value='yes' /><param name='display_overlay' value='yes' /><param name='display_count' value='yes' /></object></div>                <script type='text/javascript'>                    var divElement = document.getElementById('viz1521823532881'); var vizElement = divElement.getElementsByTagName('object')[0]; vizElement.style.width = '1000px'; vizElement.style.height = '827px'; var scriptElement = document.createElement('script'); scriptElement.src = 'https://public.tableau.com/javascripts/api/viz_v1.js'; vizElement.parentNode.insertBefore(scriptElement, vizElement);                </script>

          <%--<div class="row">
            <div class="col s12">
              <ul class="tabs">
                <li class="tab col s3"><a href="#test1" class="active tabs">Top Rewards Recieved</a></li>
                <li class="tab col s3 "><a href="#test2" class="tabs">Top Rewards Given</a></li>
                <li class="tab col s3"><a href="#test3" class="tabs" >Top Reward Sales</a></li>
                <li class="tab col s3"><a href="#test4" class="tabs">Top Rewards By Month</a></li>
              </ul>
            </div>
            <div id="test1" class="col s12"><img src="images/TopRec.png" width="99%"></div>
            <div id="test2" class="col s12"><img src="images/given.png" width="99%"></div>
            <div id="test3" class="col s12"><img src="images/sales.png" width="99%"></div>
            <div id="test4" class="col s12"><img src="images/month.png" width="99%"></div>
          </div>--%>


          </div> <!-- Container end.-->

          <%--<div class="container settings2">
              <div class="table">
                <div class="row">
                  <div class="col s12 valueshead">
                    <H1 class="valuesadmin"> <strong> Company Values Fulfilled </strong></H1> 
                  </div> <!-- end col -->
                </div>

              <div class="row">

                    <div class="col s6 valuescol">
                            <img class="iconforvalue" src="icons/grouphealth.png">
                            <h4 class="headervalue"> Health </h4>
                            <h5 class="headervalue"> 100</h5>
                        
                    </div>

                    <div class="col s6 valuescol">
                          <img class="iconforvalue" src="icons/communityinv.png">
                          <h4 class="headervalue"> Community Involvement</h4>
                          <h5 class="headervalue"> 30</h5>
                      
                    </div>
                     </div><!-- End of row-->
                <div class="row">

                    <div class="col s6 valuescol">
                        <img class="iconforvalue" src="icons/customerservice.png">
                        <h4 class="headervalue"> Customer Service</h4>
                        <h5 class="headervalue"> 56</h5>
                   
                    </div>

                     <div class="col s6 valuescol">
                        <img class="iconforvalue" src="icons/addcustomer.png">
                        <h4 class="headervalue"> Attracting New Customers </h4>
                         <h5 class="headervalue"> 67</h5>
                     
                    </div>
                     </div><!-- End of row-->
              <div class="row">
                    <div class="col s6 valuescol">
                        <img class="iconforvalue" src="icons/leadership.png">
                        <h4 class="headervalue"> Leadership </h4>
                         <h5 class="headervalue"> 32</h5>
                      
                    </div>
                    <div class="col s6 valuescol">
                        <img class="iconforvalue" src="icons/process.png">
                        <h4 class="headervalue"> Process Improvement Initiatives</h4>
                        <h5 class="headervalue"> 35</h5>
                 
                    </div>
                     </div><!-- End of row-->
                <div class="row">
                    <div class="col s6 valuescol">
                        <img class="iconforvalue" src="icons/volunteer.png">
                         <h4 class="headervalue"> Community Service</h4>
                         <h5 class="headervalue"> 15</h5>
                      
                    </div>
                    <div class="col s6 valuescol">
                        <img class="iconforvalue" src="icons/teambuilding.png">
                        <h4 class="headervalue"> Team Building</h4>
                        <h5 class="headervalue"> 25</h5>
                    </div>
                  </div><!-- End of row-->

          </div> <!-- End of table-->
        </div>--%>

            <!--Import jQuery before materialize.js-->
      <script type="text/javascript" src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
      <script type="text/javascript" src="js/materialize.min.js"></script>
      <script type="text/javascript">
          $(document).ready(function () {
              // the "href" attribute of .modal-trigger must specify the modal ID that wants to be triggered
              $('.modal-trigger').leanModal();
          });
      </script>
      <script type="text/javascript" src="https://code.jquery.com/jquery-2.1.1.min.js"></script>
      <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.5/js/materialize.min.js"></script>

      <script type="text/javascript">
          $(document).ready(function () {
              $('select').material_select();
          });

      </script>
    </body>
 </html>

</asp:Content>