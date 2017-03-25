<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterAdmin.master" AutoEventWireup="true" CodeBehind="Admin-Dashboard.aspx.cs" Inherits="Views.WebForm10" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        

    <div class="col-md-8" >
            <div class="network" >
                




                 <!--    <42>Dashboard</42>   -->
                        <h5>Welcome</h5>
                       
                           <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                         
                      
                <asp:Button ID="Button1" runat="server" Text="Start Getting Trends" OnClick="Button1_Click" />
                <asp:Label ID="TimeLabel" runat="server" Text="Label"> hours</asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine"></asp:TextBox>
                    
                    </div>
                </div>
        
          <div class="col-md-8">
            <div class="network">
              <h4>Welcome</h4>
             
              
              <!-- Tab Content -->
              <div class="tab-content"> 
                
                <!-- Connections -->
                <div id="connec" class="tab-pane fade in active">
                  <div class="net-work-in"> 
                    
                  
                    
                    <!-- Members -->
                    <div class="main-mem"> 
                      
                 
            
                      
                      <!-- Tittle -->
                      <div class="folow-persons">
                        
                                               
                       
                           <table>
                          <caption>Overview</caption>
                          <tr class="tittle">
                            <th>Parameter</th>
                            <th>Value</th>
                            <th>Change</th>
                          </tr>
                          <tr >
                            <td>Schedule Time</td>
                            <td><%=SchedTime %> hours</td>
                              <td>
                                  <asp:Button ID="Button2" runat="server" Text="Change Time" /></td>
                          </tr>
                          <tr >
                            <td>February</td>
                            <td>$50</td>
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
</asp:Content>
