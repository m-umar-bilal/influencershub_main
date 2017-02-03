<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="UserDashboard.aspx.cs" Inherits="FYPLayoutWebProject.UserDashboard1"  Async="true" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="network">
              <h4 >Influencers</h4>
              
              <!-- Nav Tabs -->
              <ul class="nav nav-tabs">
                <li class="active"><a data-toggle="tab" href="#connec">Connections (202)</a></li>
                <li><a data-toggle="tab" href="#flow">Followers (23)</a></li>
                <li><a data-toggle="tab" href="#flowing">Following (100)</a></li>
              </ul>
              
              <!-- Tab Content -->
              <div class="tab-content"> 
                
                <!-- Connections -->
                <div id="connec" class="tab-pane fade in active">
                  <div class="net-work-in"> 
                    
                    <!-- Filter -->
                    <div class="filter-flower">
                      <div class="row">
                        <div class="col-sm-7">
                          <ul>
                            <li><a href="#." class="active">Show All</a></li>
                            <li><a href="#."><i class="fa fa-user"></i> Professionals</a></li>
                            <li><a href="#."><i class="fa fa-building-o"></i> Companies</a></li>
                          </ul>
                        </div>
                        
                        <!-- Short -->
                        <div class="col-sm-5">
                          <select>
                            <option>Sort</option>
                            <option>Sort</option>
                            <option>Sort</option>
                            <option>Sort</option>
                          </select>
                        </div>
                      </div>
                    </div>
                    
                    <!-- Members -->
                    <div class="main-mem"> 
                      
                      <!-- Head -->
                      <div class="head">
                        <div class="row">
                          <div class="col-sm-8">
                            <button disabled><i class="fa fa-user-plus"></i>Follow</button>
                            <button disabled><i class="fa fa-trash"></i>Delete</button>
                          </div>
                          <div class="col-sm-4">
                            <form>
                              <input type="search" placeholder="Search">
                              <button type="submit"><i class="fa fa-search"></i></button>
                            </form>
                          </div>
                        </div>
                      </div>
                      
                      <!-- Tittle -->
                      <div class="tittle">
                        <ul class="row">
                          <li class="col-xs-4"> <span>Title</span> </li>
                          <li class="col-xs-3"> <span>Location</span> </li>
                          <li class="col-xs-3"> <span>Network</span> </li>
                          <li class="col-xs-2 n-p-r n-p-l"> <span>Connections</span> </li>
                        </ul>
                      </div>
                      
                      <!-- Tittle -->
                      <div class="folow-persons">
                        <ul>
                          <% foreach (var item in InfluencerViewModels) { %>
                          <!-- MEMBER -->
                          <li>
                            <div class="row">
                              <div class="col-xs-4"> 
                                <!-- Check Box -->
                                <div class="checkbox">
                                  <input id="checkbox1" class="styled" type="checkbox">
                                  <label for="checkbox1"></label>
                                </div>
                                <!-- Name -->
                                <div class="fol-name">
                                  <div class="avatar"> <img src="<%= item.ProfileImageUrl %>" alt=""> </div>
                                  <h6><%= item.Name %></h6>
                                  <span>Web Developer</span> </div>
                              </div>
                              <!-- Location -->
                              <div class="col-xs-3 n-p-r n-p-l"> <span><%= item.Location %></span> </div>
                              <!-- Network -->
                              <div class="col-xs-3 n-p-r"> <span>21 Followers</span> <span>10 Following</span> </div>
                              <!-- Connections -->
                              <div class="col-xs-2 n-p-r n-p-l"> <span>31 Connections</span> </div>
                            </div>
                          </li>
                              <% } %> 
                          
                       
                        </ul>
                      </div>
                    </div>
                  </div>
                </div>
                
                <!-- Followers -->
                <div id="flow" class="tab-pane fade">
                  <div class="net-work-in"> 
                    
                    <!-- Filter -->
                    <div class="filter-flower">
                      <div class="row">
                        <div class="col-sm-7">
                          <ul>
                            <li><a href="#." class="active">Show All</a></li>
                            <li><a href="#."><i class="fa fa-user"></i> Professionals</a></li>
                            <li><a href="#."><i class="fa fa-building-o"></i> Companies</a></li>
                          </ul>
                        </div>
                        
                        <!-- Short -->
                        <div class="col-sm-5">
                          <select>
                            <option>Sort</option>
                            <option>Sort</option>
                            <option>Sort</option>
                            <option>Sort</option>
                          </select>
                        </div>
                      </div>
                    </div>
                    
                    <!-- Members -->
                    <div class="main-mem"> 
                      
                      <!-- Head -->
                      <div class="head">
                        <div class="row">
                          <div class="col-sm-8">
                            <button disabled><i class="fa fa-user-plus"></i>Follow</button>
                            <button disabled><i class="fa fa-trash"></i>Delete</button>
                          </div>
                          <div class="col-sm-4">
                            <form>
                              <input type="search" placeholder="Search">
                              <button type="submit"><i class="fa fa-search"></i></button>
                            </form>
                          </div>
                        </div>
                      </div>
                      
                      <!-- Tittle -->
                      <div class="tittle">
                        <ul class="row">
                          <li class="col-xs-4"> <span>Title</span> </li>
                          <li class="col-xs-3"> <span>Location</span> </li>
                          <li class="col-xs-3"> <span>Network</span> </li>
                          <li class="col-xs-2 n-p-r n-p-l"> <span>Connections</span> </li>
                        </ul>
                      </div>
                      
                      <!-- Tittle -->
                      <div class="folow-persons">
                        <ul>
                          
                          <!-- MEMBER -->
                          <li>
                            <div class="row">
                              <div class="col-xs-4"> 
                                <!-- Check Box -->
                                <div class="checkbox">
                                  <input id="checkbox1-1" class="styled" type="checkbox">
                                  <label for="checkbox1-1"></label>
                                </div>
                                <!-- Name -->
                                <div class="fol-name">
                                  <div class="avatar"> <img src="assets/user/images/sm-avatar.jpg" alt=""> </div>
                                  <h6>Collin Weiland</h6>
                                  <span>Web Developer</span> </div>
                              </div>
                              <!-- Location -->
                              <div class="col-xs-3 n-p-r n-p-l"> <span>San Francisco, USA</span> </div>
                              <!-- Network -->
                              <div class="col-xs-3 n-p-r"> <span>21 Followers</span> <span>10 Following</span> </div>
                              <!-- Connections -->
                              <div class="col-xs-2 n-p-r n-p-l"> <span>31 Connections</span> </div>
                            </div>
                          </li>
                          
                          <!-- MEMBER -->
                          <li>
                            <div class="row"> 
                              <!-- Title -->
                              <div class="col-xs-4"> 
                                <!-- Check Box -->
                                <div class="checkbox">
                                  <input id="checkbox1-2" class="styled" type="checkbox">
                                  <label for="checkbox1-2"></label>
                                </div>
                                <!-- Name -->
                                <div class="fol-name">
                                  <div class="avatar"> <img src="assets/user/images/sm-avatar.jpg" alt=""> </div>
                                  <h6>Collin Weiland</h6>
                                  <span>Web Developer</span> </div>
                              </div>
                              <!-- Location -->
                              <div class="col-xs-3 n-p-r n-p-l"> <span>San Francisco, USA</span> </div>
                              <!-- Network -->
                              <div class="col-xs-3 n-p-r"> <span>21 Followers</span> <span>10 Following</span> </div>
                              <!-- Connections -->
                              <div class="col-xs-2 n-p-r n-p-l"> <span>31 Connections</span> </div>
                            </div>
                          </li>
                          
                          <!-- MEMBER -->
                          <li>
                            <div class="row"> 
                              <!-- Title -->
                              <div class="col-xs-4"> 
                                <!-- Check Box -->
                                <div class="checkbox">
                                  <input id="checkbox1-3" class="styled" type="checkbox">
                                  <label for="checkbox1-3"></label>
                                </div>
                                <!-- Name -->
                                <div class="fol-name">
                                  <div class="avatar"> <img src="assets/user/images/sm-avatar.jpg" alt=""> </div>
                                  <h6>Collin Weiland</h6>
                                  <span>Web Developer</span> </div>
                              </div>
                              <!-- Location -->
                              <div class="col-xs-3 n-p-r n-p-l"> <span>San Francisco, USA</span> </div>
                              <!-- Network -->
                              <div class="col-xs-3 n-p-r"> <span>21 Followers</span> <span>10 Following</span> </div>
                              <!-- Connections -->
                              <div class="col-xs-2 n-p-r n-p-l"> <span>31 Connections</span> </div>
                            </div>
                          </li>
                          
                          <!-- MEMBER -->
                          <li>
                            <div class="row"> 
                              <!-- Title -->
                              <div class="col-xs-4"> 
                                <!-- Check Box -->
                                <div class="checkbox">
                                  <input id="checkbox1-4" class="styled" type="checkbox">
                                  <label for="checkbox1-4"></label>
                                </div>
                                <!-- Name -->
                                <div class="fol-name">
                                  <div class="avatar"> <img src="assets/user/images/sm-avatar.jpg" alt=""> </div>
                                  <h6>Collin Weiland</h6>
                                  <span>Web Developer</span> </div>
                              </div>
                              <!-- Location -->
                              <div class="col-xs-3 n-p-r n-p-l"> <span>San Francisco, USA</span> </div>
                              <!-- Network -->
                              <div class="col-xs-3 n-p-r"> <span>21 Followers</span> <span>10 Following</span> </div>
                              <!-- Connections -->
                              <div class="col-xs-2 n-p-r n-p-l"> <span>31 Connections</span> </div>
                            </div>
                          </li>
                          
                          <!-- MEMBER -->
                          <li>
                            <div class="row"> 
                              <!-- Title -->
                              <div class="col-xs-4"> 
                                <!-- Check Box -->
                                <div class="checkbox">
                                  <input id="checkbox1-5" class="styled" type="checkbox">
                                  <label for="checkbox1-5"></label>
                                </div>
                                <!-- Name -->
                                <div class="fol-name">
                                  <div class="avatar"> <img src="assets/user/images/sm-avatar.jpg" alt=""> </div>
                                  <h6>Collin Weiland</h6>
                                  <span>Web Developer</span> </div>
                              </div>
                              <!-- Location -->
                              <div class="col-xs-3 n-p-r n-p-l"> <span>San Francisco, USA</span> </div>
                              <!-- Network -->
                              <div class="col-xs-3 n-p-r"> <span>21 Followers</span> <span>10 Following</span> </div>
                              <!-- Connections -->
                              <div class="col-xs-2 n-p-r n-p-l"> <span>31 Connections</span> </div>
                            </div>
                          </li>
                          
                          <!-- MEMBER -->
                          <li>
                            <div class="row"> 
                              <!-- Title -->
                              <div class="col-xs-4"> 
                                <!-- Check Box -->
                                <div class="checkbox">
                                  <input id="checkbox1-6" class="styled" type="checkbox">
                                  <label for="checkbox1-6"></label>
                                </div>
                                <!-- Name -->
                                <div class="fol-name">
                                  <div class="avatar"> <img src="assets/user/images/sm-avatar.jpg" alt=""> </div>
                                  <h6>Collin Weiland</h6>
                                  <span>Web Developer</span> </div>
                              </div>
                              <!-- Location -->
                              <div class="col-xs-3 n-p-r n-p-l"> <span>San Francisco, USA</span> </div>
                              <!-- Network -->
                              <div class="col-xs-3 n-p-r"> <span>21 Followers</span> <span>10 Following</span> </div>
                              <!-- Connections -->
                              <div class="col-xs-2 n-p-r n-p-l"> <span>31 Connections</span> </div>
                            </div>
                          </li>
                          
                          <!-- MEMBER -->
                          <li>
                            <div class="row"> 
                              <!-- Title -->
                              <div class="col-xs-4"> 
                                <!-- Check Box -->
                                <div class="checkbox">
                                  <input id="checkbox1-7" class="styled" type="checkbox">
                                  <label for="checkbox1-7"></label>
                                </div>
                                <!-- Name -->
                                <div class="fol-name">
                                  <div class="avatar"> <img src="assets/user/images/sm-avatar.jpg" alt=""> </div>
                                  <h6>Collin Weiland</h6>
                                  <span>Web Developer</span> </div>
                              </div>
                              <!-- Location -->
                              <div class="col-xs-3 n-p-r n-p-l"> <span>San Francisco, USA</span> </div>
                              <!-- Network -->
                              <div class="col-xs-3 n-p-r"> <span>21 Followers</span> <span>10 Following</span> </div>
                              <!-- Connections -->
                              <div class="col-xs-2 n-p-r n-p-l"> <span>31 Connections</span> </div>
                            </div>
                          </li>
                        </ul>
                      </div>
                    </div>
                  </div>
                </div>
                
                <!-- Following -->
                <div id="flowing" class="tab-pane fade">
                  <div class="net-work-in"> 
                    
                    <!-- Filter -->
                    <div class="filter-flower">
                      <div class="row">
                        <div class="col-sm-7">
                          <ul>
                            <li><a href="#." class="active">Show All</a></li>
                            <li><a href="#."><i class="fa fa-user"></i> Professionals</a></li>
                            <li><a href="#."><i class="fa fa-building-o"></i> Companies</a></li>
                          </ul>
                        </div>
                        
                        <!-- Short -->
                        <div class="col-sm-5">
                          <select>
                            <option>Sort</option>
                            <option>Sort</option>
                            <option>Sort</option>
                            <option>Sort</option>
                          </select>
                        </div>
                      </div>
                    </div>
                    
                    <!-- Members -->
                    <div class="main-mem"> 
                      
                      <!-- Head -->
                      <div class="head">
                        <div class="row">
                          <div class="col-sm-8">
                            <button disabled><i class="fa fa-user-plus"></i>Follow</button>
                            <button disabled><i class="fa fa-trash"></i>Delete</button>
                          </div>
                          <div class="col-sm-4">
                            <form>
                              <input type="search" placeholder="Search">
                              <button type="submit"><i class="fa fa-search"></i></button>
                            </form>
                          </div>
                        </div>
                      </div>
                      
                      <!-- Tittle -->
                      <div class="tittle">
                        <ul class="row">
                          <li class="col-xs-4"> <span>Title</span> </li>
                          <li class="col-xs-3"> <span>Location</span> </li>
                          <li class="col-xs-3"> <span>Network</span> </li>
                          <li class="col-xs-2 n-p-r n-p-l"> <span>Connections</span> </li>
                        </ul>
                      </div>
                      
                      <!-- Tittle -->
                      <div class="folow-persons">
                        <ul>
                          
                          <!-- MEMBER -->
                          <li>
                            <div class="row">
                              <div class="col-xs-4"> 
                                <!-- Check Box -->
                                <div class="checkbox">
                                  <input id="checkbox2-1" class="styled" type="checkbox">
                                  <label for="checkbox2-1"></label>
                                </div>
                                <!-- Name -->
                                <div class="fol-name">
                                  <div class="avatar"> <img src="assets/user/images/sm-avatar.jpg" alt=""> </div>
                                  <h6>Collin Weiland</h6>
                                  <span>Web Developer</span> </div>
                              </div>
                              <!-- Location -->
                              <div class="col-xs-3 n-p-r n-p-l"> <span>San Francisco, USA</span> </div>
                              <!-- Network -->
                              <div class="col-xs-3 n-p-r"> <span>21 Followers</span> <span>10 Following</span> </div>
                              <!-- Connections -->
                              <div class="col-xs-2 n-p-r n-p-l"> <span>31 Connections</span> </div>
                            </div>
                          </li>
                          
                          <!-- MEMBER -->
                          <li>
                            <div class="row"> 
                              <!-- Title -->
                              <div class="col-xs-4"> 
                                <!-- Check Box -->
                                <div class="checkbox">
                                  <input id="checkbox2-2" class="styled" type="checkbox">
                                  <label for="checkbox2-2"></label>
                                </div>
                                <!-- Name -->
                                <div class="fol-name">
                                  <div class="avatar"> <img src="assets/user/images/sm-avatar.jpg" alt=""> </div>
                                  <h6>Collin Weiland</h6>
                                  <span>Web Developer</span> </div>
                              </div>
                              <!-- Location -->
                              <div class="col-xs-3 n-p-r n-p-l"> <span>San Francisco, USA</span> </div>
                              <!-- Network -->
                              <div class="col-xs-3 n-p-r"> <span>21 Followers</span> <span>10 Following</span> </div>
                              <!-- Connections -->
                              <div class="col-xs-2 n-p-r n-p-l"> <span>31 Connections</span> </div>
                            </div>
                          </li>
                          
                          <!-- MEMBER -->
                          <li>
                            <div class="row"> 
                              <!-- Title -->
                              <div class="col-xs-4"> 
                                <!-- Check Box -->
                                <div class="checkbox">
                                  <input id="checkbox2-3" class="styled" type="checkbox">
                                  <label for="checkbox2-3"></label>
                                </div>
                                <!-- Name -->
                                <div class="fol-name">
                                  <div class="avatar"> <img src="assets/user/images/sm-avatar.jpg" alt=""> </div>
                                  <h6>Collin Weiland</h6>
                                  <span>Web Developer</span> </div>
                              </div>
                              <!-- Location -->
                              <div class="col-xs-3 n-p-r n-p-l"> <span>San Francisco, USA</span> </div>
                              <!-- Network -->
                              <div class="col-xs-3 n-p-r"> <span>21 Followers</span> <span>10 Following</span> </div>
                              <!-- Connections -->
                              <div class="col-xs-2 n-p-r n-p-l"> <span>31 Connections</span> </div>
                            </div>
                          </li>
                          
                          <!-- MEMBER -->
                          <li>
                            <div class="row"> 
                              <!-- Title -->
                              <div class="col-xs-4"> 
                                <!-- Check Box -->
                                <div class="checkbox">
                                  <input id="checkbox2-4" class="styled" type="checkbox">
                                  <label for="checkbox2-4"></label>
                                </div>
                                <!-- Name -->
                                <div class="fol-name">
                                  <div class="avatar"> <img src="assets/user/images/sm-avatar.jpg" alt=""> </div>
                                  <h6>Collin Weiland</h6>
                                  <span>Web Developer</span> </div>
                              </div>
                              <!-- Location -->
                              <div class="col-xs-3 n-p-r n-p-l"> <span>San Francisco, USA</span> </div>
                              <!-- Network -->
                              <div class="col-xs-3 n-p-r"> <span>21 Followers</span> <span>10 Following</span> </div>
                              <!-- Connections -->
                              <div class="col-xs-2 n-p-r n-p-l"> <span>31 Connections</span> </div>
                            </div>
                          </li>
                          
                          <!-- MEMBER -->
                          <li>
                            <div class="row"> 
                              <!-- Title -->
                              <div class="col-xs-4"> 
                                <!-- Check Box -->
                                <div class="checkbox">
                                  <input id="checkbox2-5" class="styled" type="checkbox">
                                  <label for="checkbox2-5"></label>
                                </div>
                                <!-- Name -->
                                <div class="fol-name">
                                  <div class="avatar"> <img src="assets/user/images/sm-avatar.jpg" alt=""> </div>
                                  <h6>Collin Weiland</h6>
                                  <span>Web Developer</span> </div>
                              </div>
                              <!-- Location -->
                              <div class="col-xs-3 n-p-r n-p-l"> <span>San Francisco, USA</span> </div>
                              <!-- Network -->
                              <div class="col-xs-3 n-p-r"> <span>21 Followers</span> <span>10 Following</span> </div>
                              <!-- Connections -->
                              <div class="col-xs-2 n-p-r n-p-l"> <span>31 Connections</span> </div>
                            </div>
                          </li>
                          
                          <!-- MEMBER -->
                          <li>
                            <div class="row"> 
                              <!-- Title -->
                              <div class="col-xs-4"> 
                                <!-- Check Box -->
                                <div class="checkbox">
                                  <input id="checkbox2-6" class="styled" type="checkbox">
                                  <label for="checkbox2-6"></label>
                                </div>
                                <!-- Name -->
                                <div class="fol-name">
                                  <div class="avatar"> <img src="assets/user/images/sm-avatar.jpg" alt=""> </div>
                                  <h6>Collin Weiland</h6>
                                  <span>Web Developer</span> </div>
                              </div>
                              <!-- Location -->
                              <div class="col-xs-3 n-p-r n-p-l"> <span>San Francisco, USA</span> </div>
                              <!-- Network -->
                              <div class="col-xs-3 n-p-r"> <span>21 Followers</span> <span>10 Following</span> </div>
                              <!-- Connections -->
                              <div class="col-xs-2 n-p-r n-p-l"> <span>31 Connections</span> </div>
                            </div>
                          </li>
                          
                          <!-- MEMBER -->
                          <li>
                            <div class="row"> 
                              <!-- Title -->
                              <div class="col-xs-4"> 
                                <!-- Check Box -->
                                <div class="checkbox">
                                  <input id="checkbox2-7" class="styled" type="checkbox">
                                  <label for="checkbox2-7"></label>
                                </div>
                                <!-- Name -->
                                <div class="fol-name">
                                  <div class="avatar"> <img src="assets/user/images/sm-avatar.jpg" alt=""> </div>
                                  <h6>Collin Weiland</h6>
                                  <span>Web Developer</span> </div>
                              </div>
                              <!-- Location -->
                              <div class="col-xs-3 n-p-r n-p-l"> <span>San Francisco, USA</span> </div>
                              <!-- Network -->
                              <div class="col-xs-3 n-p-r"> <span>21 Followers</span> <span>10 Following</span> </div>
                              <!-- Connections -->
                              <div class="col-xs-2 n-p-r n-p-l"> <span>31 Connections</span> </div>
                            </div>
                          </li>
                        </ul>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
</asp:Content>
