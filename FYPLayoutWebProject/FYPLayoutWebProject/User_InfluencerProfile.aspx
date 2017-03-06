<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_InfluencerProfile.aspx.cs" Inherits="FYPLayoutWebProject.User_InfluencerProfile" %>

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
<div id="main-wrapper"> 
  
  <!-- Top Toolbar -->
  
  <!--Dash Board Starts -->
  

  
  <div class="compny-profile"> 
    <!-- SUB Banner -->
    <div class="profile-bnr user-profile-bnr">
      <div class="container">
        <div class="pull-left">
          <h2>Michael Peterson</h2>
          <h5>Front-End Developer</h5>
        </div>
        
        <!-- Top Riht Button -->
        <div class="right-top-bnr">
          <div class="connect"> <a href="#." data-toggle="modal" data-target="#myModal"><i class="fa fa-user-plus"></i> Connect</a> <a href="#."><i class="fa fa-share-alt"></i> Share</a>
            <div class="bt-ns"> <a href="#."><i class="fa fa-bookmark-o"></i> </a> <a href="#."><i class="fa fa-envelope-o"></i> </a> <a href="#."><i class="fa fa-exclamation"></i> </a> </div>
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
                          <div class="img-profile"> <img class="media-object" src="images/avatar-1.jpg" alt=""> </div>
                        <!-- Pic K Samne wala -->
					    </div>
                        <div class="media-body">
                          <p> Include DEtails here</p>
                        </div>
                      </div>
                    </div>
                  </div>
                  <div class="col-md-8"> 
                    
                    <!-- Skills -->
                    <div class="sidebar">
                      <h5 class="main-title">Skills</h5>
                      <div class="job-skills"> 
                        
                        <!-- Logo Design -->
                        <ul class="row">
                          <li class="col-sm-3">
                            <h6><i class="fa fa-plus"></i> HTML5 and Css3</h6>
                          </li>
                          <li class="col-sm-9">
                            <div class="progress">
                              <div class="progress-bar" role="progressbar" aria-valuenow="60" aria-valuemin="0" aria-valuemax="100" style="width: 60%;"> </div>
                            </div>
                          </li>
                        </ul>
                        
                        <!-- Logo Design -->
                        <ul class="row">
                          <li class="col-sm-3">
                            <h6><i class="fa fa-plus"></i> Logo Design</h6>
                          </li>
                          <li class="col-sm-9">
                            <div class="progress">
                              <div class="progress-bar" role="progressbar" aria-valuenow="60" aria-valuemin="0" aria-valuemax="100" style="width: 60%;"> </div>
                            </div>
                          </li>
                        </ul>
                        
                        <!-- Logo Design -->
                        <ul class="row">
                          <li class="col-sm-3">
                            <h6><i class="fa fa-plus"></i> Web Design</h6>
                          </li>
                          <li class="col-sm-9">
                            <div class="progress">
                              <div class="progress-bar" role="progressbar" aria-valuenow="60" aria-valuemin="0" aria-valuemax="100" style="width: 90%;"> </div>
                            </div>
                          </li>
                        </ul>
                        
                        <!-- UI / UX -->
                        <ul class="row">
                          <li class="col-sm-3">
                            <h6><i class="fa fa-plus"></i> UI/UX</h6>
                          </li>
                          <li class="col-sm-9">
                            <div class="progress">
                              <div class="progress-bar" role="progressbar" aria-valuenow="60" aria-valuemin="0" aria-valuemax="100" style="width: 80%;"> </div>
                            </div>
                            <p>Preferred languages are Arabic, French & Italian. Proin nibh augue, suscipit asce lerisque sed, lacinia in, mi.</p>
                          </li>
                        </ul>
                      </div>
                    </div> 
                    
                    <!-- Professional Details -->
                    <div class="sidebar">
                      <h5 class="main-title">Similar Professionals</h5>
                      
                      <!-- Similar -->
                      <div class="similar">
                        <div class="media">
                          <div class="media-left">
                            <div class="inn-simi"> <img class="media-object" src="images/med-avatar.jpg" alt=""> <a href="#">Profile </a> </div>
                          </div>
                          <div class="media-body">
                            <h5>Media heading</h5>
                            <p>SEO Specialist - New York, USA</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Suscipit, maxime, excepturi, mollitia, 
                              voluptatibus similique aliquid a dolores autem laudantium sapiente ad enim ipsa modi laborum 
                              accusantium deleniti neque architecto vitae.</p>
                            
                            <!-- Share -->
                            <div class="share-w"><a href="#."><i class="fa fa-bookmark-o"></i></a> <a href="#."><i class="fa fa-envelope-o"></i></a> <a href="#."><i class="fa fa-eye"></i></a></div>
                          </div>
                        </div>
                        
                        <!-- Similar -->
                        <div class="media">
                          <div class="media-left">
                            <div class="inn-simi"> <img class="media-object" src="images/med-avatar.jpg" alt=""> <a href="#">Profile </a> </div>
                          </div>
                          <div class="media-body">
                            <h5>Denise Walsh</h5>
                            <p>SEO Specialist - New York, USA</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Suscipit, maxime, excepturi, mollitia, 
                              voluptatibus similique aliquid a dolores autem laudantium sapiente ad enim ipsa modi laborum 
                              accusantium deleniti neque architecto vitae.</p>
                            
                            <!-- Share -->
                            <div class="share-w"><a href="#."><i class="fa fa-bookmark-o"></i></a> <a href="#."><i class="fa fa-envelope-o"></i></a> <a href="#."><i class="fa fa-eye"></i></a></div>
                          </div>
                        </div>
                        
                        <!-- Similar -->
                        <div class="media">
                          <div class="media-left">
                            <div class="inn-simi"> <img class="media-object" src="images/med-avatar.jpg" alt=""> <a href="#">Profile </a> </div>
                          </div>
                          <div class="media-body">
                            <h5>Denise Walsh</h5>
                            <p>SEO Specialist - New York, USA</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Suscipit, maxime, excepturi, mollitia, 
                              voluptatibus similique aliquid a dolores autem laudantium sapiente ad enim ipsa modi laborum 
                              accusantium deleniti neque architecto vitae.</p>
                            
                            <!-- Share -->
                            <div class="share-w"><a href="#."><i class="fa fa-bookmark-o"></i></a> <a href="#."><i class="fa fa-envelope-o"></i></a> <a href="#."><i class="fa fa-eye"></i></a></div>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                  
                  <!-- Col -->
                  <div class="col-md-4"> 
                    
                    <!-- Professional Details -->
                    <div class="sidebar">
                      <h5 class="main-title">Professional Details</h5>
                      <div class="sidebar-information">
                        <ul class="single-category">
                          <li class="row">
                            <h6 class="title col-xs-6">Name</h6>
                            <span class="subtitle col-xs-6">Abu Antar</span></li>
                          <li class="row">
                            <h6 class="title col-xs-6">Age</h6>
                            <span class="subtitle col-xs-6">38 Years Old</span></li>
                          <li class="row">
                            <h6 class="title col-xs-6">Location</h6>
                            <span class="subtitle col-xs-6">Jordan Amman</span></li>
                          <li class="row">
                            <h6 class="title col-xs-6">Experiance</h6>
                            <span class="subtitle col-xs-6">15 Years</span></li>
                          <li class="row">
                            <h6 class="title col-xs-6">Dgree</h6>
                            <span class="subtitle col-xs-6">MBA</span></li>
                          <li class="row">
                            <h6 class="title col-xs-6">Career Lavel</h6>
                            <span class="subtitle col-xs-6">Mid-Level</span></li>
                          <li class="row">
                            <h6 class="title col-xs-6">Phone</h6>
                            <span class="subtitle col-xs-6">(800) 123-4567</span></li>
                          <li class="row">
                            <h6 class="title col-xs-6">Fax </h6>
                            <span class="subtitle col-xs-6">(800) 123-4568</span></li>
                          <li class="row">
                            <h6 class="title col-xs-6">E-mail</h6>
                            <span class="subtitle col-xs-6"><a href="#.">example@example.com</a></span></li>
                          <li class="row">
                            <h6 class="title col-xs-6">Website</h6>
                            <span class="subtitle col-xs-6"><a href="#.">example.com </a></span></li>
                        </ul>
                      </div>
                    </div>
                    
                    <!-- Rating -->
                    <div class="sidebar">
                      <h5 class="main-title">Rating</h5>
                      <div class="sidebar-information">
                        <ul class="single-category com-rate">
                          <li class="row">
                            <h6 class="title col-xs-6">Expertise:</h6>
                            <span class="col-xs-6"><i class="fa fa-star"></i> <i class="fa fa-star"></i> <i class="fa fa-star"></i> <i class="fa fa-star-o"></i> <i class="fa fa-star-o"></i></span> </li>
                          <li class="row">
                            <h6 class="title col-xs-6">Knowledge:</h6>
                            <span class="col-xs-6"><i class="fa fa-star"></i> <i class="fa fa-star"></i> <i class="fa fa-star"></i> <i class="fa fa-star-half-o"></i> <i class="fa fa-star-o"></i></span> </li>
                          <li class="row">
                            <h6 class="title col-xs-6">Quality::</h6>
                            <span class="col-xs-6"><i class="fa fa-star"></i> <i class="fa fa-star"></i> <i class="fa fa-star"></i> <i class="fa fa-star"></i> <i class="fa fa-star-o"></i></span> </li>
                          <li class="row">
                            <h6 class="title col-xs-6">Price:</h6>
                            <span class="col-xs-6"><i class="fa fa-star"></i> <i class="fa fa-star"></i> <i class="fa fa-star-o"></i> <i class="fa fa-star-o"></i> <i class="fa fa-star-o"></i></span> </li>
                          <li class="row">
                            <h6 class="title col-xs-6">Services:</h6>
                            <span class="col-xs-6"><i class="fa fa-star"></i> <i class="fa fa-star"></i> <i class="fa fa-star"></i> <i class="fa fa-star"></i> <i class="fa fa-star-o"></i></span> </li>
                        </ul>
                      </div>
                    </div>
                    
                    <!-- Social Profiles -->
                    <div class="sidebar">
                      <h5 class="main-title">Social Profiles</h5>
                      <ul class="socil">
                        <li><a href="#."><i class="fa fa-facebook"></i></a></li>
                        <li><a href="#."><i class="fa fa-google-plus"></i></a></li>
                        <li><a href="#."><i class="fa fa-linkedin"></i></a></li>
                        <li><a href="#."><i class="fa fa-twitter"></i></a></li>
                      </ul>
                    </div>
                  </div>
                </div>
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



</body>
</html>
