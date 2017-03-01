﻿<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="UserDashboard.aspx.cs" Inherits="FYPLayoutWebProject.UserDashboard1"  Async="true" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <!-- Tab Content -->
          <div class="col-md-8">
            <div class="network">
              <h4>Influencers' List</h4>
              
              <!-- Nav Tabs -->
             <ul class="nav nav-tabs">
                <li class="active"><a data-toggle="tab" href="#connec">Recommended</a></li>
                <li><a data-toggle="tab" href="#flow">Influences' Categories</a></li>
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
                            <option>Ascending</option>
                            <option>Descending</option>
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
                                               
                          <!-- MEMBER Starts here-->

                             <% foreach (var item in InfluencerViewModels) { %>
                          <!-- MEMBER -->
                          <li>
                            <div class="row"> 
                              <!-- Title -->
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
						 <!-- MEMBER Ends here -->










						
                      </div>
                    </div>
                  </div>
                </div>
                 <!-- Connection Ends here -->

                   <!-- Followers -->
                <div id="flow" class="tab-pane fade">
                  <div class="net-work-in"> 
                    
                      <h4> Select A Category </h4>
                  </div>
                    </div>

				 <!-- Followers Ends here-->
                
              </div>
            </div>
          </div>
		  
		  <!-- Tab ends here -->
</asp:Content>
