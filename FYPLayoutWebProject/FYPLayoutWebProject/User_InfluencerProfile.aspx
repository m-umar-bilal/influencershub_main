<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_InfluencerProfile.aspx.cs" Inherits="FYPLayoutWebProject.User_InfluencerProfile" Async="true" %>

<!doctype html>
<html lang="en">


<head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<title></title>

<!-- Fonts Online -->
<link href='https://fonts.googleapis.com/css?family=Open+Sans:400,600,700,800,300' rel='stylesheet' type='text/css'>
<link href='https://fonts.googleapis.com/css?family=Montserrat:400,700' rel='stylesheet' type='text/css'>

<!-- Style Sheet -->
<link rel="stylesheet" href="assets/user/css/owl.carousel.css">
<link rel="stylesheet" href="assets/user/css/main-style.css">
<link rel="stylesheet" href="assets/user/css/style.css">

<!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
<!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
<!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
    <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
<![endif]-->
</head>
<body>
<form runat="server">
 
<div id="main-wrapper"> 
  
  <!-- Top Toolbar -->
  
  <!--Dash Board Starts -->
  

  
  <div class="compny-profile"> 
    <!-- SUB Banner -->
    <div class="profile-bnr user-profile-bnr">
      <div class="container">
        <div class="pull-left">
          <h2>dc<%=influencer.Name %></h2>
          <h5><%=influencer.ScreenName %></h5>
        </div>
        
        <!-- Top Riht Button -->
        <div class="right-top-bnr">
          <div class="connect"> <a href="#." data-toggle="modal" data-target="#myModal"><i class="fa fa-user-plus"></i> Connect</a> 
              <a href="#."><i class="fa fa-share-alt"></i> Share</a>
                <asp:Button ID="Button1" runat="server"  Text="Message" OnClick="BtnSend_Click" />
            <div class="bt-ns"> <a href="#."><i class="fa fa-bookmark-o"></i>

                       </a> <a href="#."><i class="fa fa-envelope-o"></i> </a> <a href="#.">
                           
                           <i class="fa fa-exclamation"></i> </a> </div>
          </div>
        </div>
      </div>
      
      <!-- Modal POPUP -->
     <div class="modal fade" id="myModal" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
          <div class="modal-content">
            <div class="container">
              <h6><a class="close" href="#." data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></a> Send Message</h6>
              
              <!-- Forms -->
              <form action="#">
                <ul class="row">
                  <li class="col-xs-6">
                    <input type="text" placeholder="First Name ">
                  </li>
                  <li class="col-xs-6">
                    <input type="text" placeholder="Last Name">
                  </li>
                  <li class="col-xs-6">
                    <input type="text" placeholder="Country">
                  </li>
                  <li class="col-xs-6">
                    <input type="text" placeholder="Email">
                  </li>
                  <li class="col-xs-12">
                    <textarea placeholder="Your Message"></textarea>
                  </li>
                  <li class="col-xs-12">
                    <button class="btn btn-primary">Send message</button>
                  </li>
                </ul>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
    
    <!-- Profile Company Content -->
    <div class="profile-company-content user-profile main-user" data-bg-color="f5f5f5">
      <div class="container">
        <div class="row"> 
          
          <!-- Nav Tabs -->
         
          
          <!-- Tab Content -->
          <div class="col-md-12">
            <div class="tab-content"> 
              
              <!-- PROFILE -->
              <div id="profile" class="tab-pane fade in active">
                <div class="row">
                  <div class="col-md-12">
                    <div class="profile-main">
                      <h3>About</h3>
                      <div class="profile-in">
                        <div class="media-left">
                          <div class="img-profile"> <img class="media-object" src="<%=influencer.ImageUrl %>"" width="200" height="200"> </div>
                        <!-- Pic K Samne wala -->
					    </div>
                        <div class="media-body">
                            <h6> Name: <%=influencer.Name %></h6>
                          <h6> Location : <%=influencer.Location %></h6>
                            <h6> Score : <%=influencer.Score %></h6>
                            <h6> Category : <%=influencer.Category %></h6>
                        </div>
                      </div>
                    </div>
                  </div>
                  <div class="col-md-8"> 
                    
                    <!-- Skills -->
                    <div class="sidebar">
                      <h5 class="main-title">Scores</h5>
                      <div class="job-skills"> 
                        
                       
                            <h6><i class="fa fa-plus"></i> Favourites : <% =influencer.result.favourites %></h6>
                          <br/>

                         
                       
                         
                            <h6><i class="fa fa-plus"></i> Total Favourites : <% =influencer.result.totalFav %></h6>
                         <br/>
                         

                            <h6><i class="fa fa-plus"></i>Followers : <% =influencer.result.followers %></h6>
                          <br/>
                         
                       
                        
                       
                      
                            <h6><i class="fa fa-plus"></i> Followings : <% =influencer.result.friends %></h6>
                       <br/>
                          
                       
                        
                     
                         
                            <h6><i class="fa fa-plus"></i> Retweets : <% =influencer.result.retweets %></h6>
                         <br/>
                         
                      
                           
                          
                            <h6><i class="fa fa-plus"></i> Statuses : <% =influencer.result.statuses %></h6>
                          <br/>
                         
                        </ul>
                      </div>
                    </div> 
                    
                    <!-- Professional Details -->
        
              </div>
          
		   <!-- Profile Ends Here -->
		  
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</div>

<!-- Footer -->
<div class="uou-block-4e">
  <div class="container">
    <div class="row">
      
    </div>
  </div>
</div>
<!-- end .uou-block-4e -->

<div class="uou-block-4a secondary dark">
  <div class="container">
    <ul class="links">
      <li><a href="#">Privacy Policy</a></li>
      <li><a href="#">Terms &amp; Conditions</a></li>
    </ul>
    <p>Copyright Influencers' Hub! &copy; 2017. All Rights reserved.</p>
  </div>
</div>
<!-- end .uou-block-4a --> 


    </form>
</body>
</html>
