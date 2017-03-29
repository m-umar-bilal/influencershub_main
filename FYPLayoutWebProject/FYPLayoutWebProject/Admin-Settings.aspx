<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterAdmin.master" AutoEventWireup="true" CodeBehind="Admin-Settings.aspx.cs" Inherits="Views.WebForm10" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        

   
        
          <div class="col-md-8">
            <div class="network">
              <h4>Settings</h4>
             
              
              <!-- Tab Content -->
              <div class="tab-content"> 
                
                <!-- Connections -->
                <div id="connec" class="tab-pane fade in active">
                  <div class="net-work-in"> 
                    
                  
                    
                    <!-- Members -->
                    <div class="main-mem"> 
                      
                 
            
                      
                      <!-- Tittle -->
                      <div class="folow-persons">
                        
                                               
                       
                          








						
                      </div>
<div class="folow-persons">
                        
                                             <table>
                          <caption>Tweets</caption>
                          <tr class="tittle">
                            <th>Parameter</th>
                            <th>Value</th>
                      
                          </tr>
                  <tr>
                      <td>Tweets count:</td>
                             <td><input type="number" name="onee" style="color: black" id="onee" value="<%= tcount %>"></td>
                  </tr>
                        </table>   
                       
                                <table>
                          <caption>Schedule</caption>
                          <tr class="tittle">
                            <th>Parameter</th>
                            <th>Value</th>
                      
                          </tr>
                  <tr >
                            <td>Schedule Time</td>
                            <td ><input type="number" name="88" style="color: black" id="88" value="<%= ttime %>"></td>
                             
                          </tr>
                        </table>         
              <table>
                          <caption>Weightage</caption>
                          <tr class="tittle">
                            <th>Parameter</th>
                            <th>Value</th>
                  
                          </tr>
                          
                             
                          <tr >
                            <td> Favourite:</td>
                             <td><input type="number" name="22" style="color: black" id="22" value="<%= tfavourite %>"></td>
                          </tr>
                          <tr>
                               <td>TotalFavourite:</td>
                             <td><input type="number" name="33" style="color: black" id="33" value="<%= ttotalfavourite %>"></td>
                          </tr>
                          <tr>
                             <td>Friends:<br></td>
                             <td><input type="number" name="44" style="color: black" id="44" value="<%= tfriends %>"></td>
                          </tr>
                          <tr>
                              <td>Statuses:</td>
                             <td><input type="number" name="55" style="color: black" id="55" value="<%= tstatuses %>"></td>
                          </tr>
                          <tr>
                              <td>Followers:</td>
                             <td><input type="number" name="66" style="color: black" id="66" value="<%= tfollowers %>"></td>
                          </tr>
                          <tr>
                              <td>Retweets:</td>
                             <td><input type="number" name="77" style="color: black" id="77" value="<%= tretweets %>"></td>
                          </tr>
                          <tr>
                              <td></td>
                               <td><asp:Button ID="Button1" runat="server" Text="Change" OnClick="Button3_Click" CssClass="btn-primary" /></td>
                          </tr>
                        </table>   

                          

                               
                         
    








						
                      </div>
                    </div>
                  </div>
                </div>
                 <!-- Connection Ends here -->

        

				 <!-- Followers Ends here-->
                
              </div>
            </div>
          </div>
        
        

    </form>
    <script>
        function codeAddress() {
            var textToSave = document.getElementById("11").value;
           
            var fileNameToSaveAs = document.getElementById("inputFileNameToSaveAs").value;

            var downloadLink = document.createElement("a");
            downloadLink.download = fileNameToSaveAs;
            downloadLink.innerHTML = "Download File";
            downloadLink.href = textToSaveAsURL;
            downloadLink.onclick = destroyClickedElement;
            downloadLink.style.display = "none";
            document.body.appendChild(downloadLink);

            downloadLink.click();
        }
    </script>
</asp:Content>
