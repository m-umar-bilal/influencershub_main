<%@ Page Title="View Trends" Language="C#" MasterPageFile="~/MainMasterAdmin.master" AutoEventWireup="true" CodeBehind="Admin-CatTrends.aspx.cs" Inherits="Views.WebForm7" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <form runat="server">

        
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
                        
                        <asp:GridView ID="TrendView" runat="server" AutoGenerateColumns="False">
                            
                            <Columns>

                                <asp:TemplateField HeaderText="Trend" HeaderStyle-CssClass="normalText">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTrendName" CssClass="normalText" runat="server" Text='<%#Eval("trend") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Current Category" HeaderStyle-CssClass="normalText">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCurrentCategory" CssClass="normalText" runat="server" Text='<%#Eval("category") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Classified on" HeaderStyle-CssClass="normalText">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTimestamp" CssClass="normalText" runat="server" Text='<%#Eval("timestamp") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Change">
                                    <ItemTemplate >
                                        <asp:DropDownList ID="CatList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="CatList_OnSelectedIndexChanged" trend='<%#Eval("trend") %>' timestamp='<%#Eval("timestamp") %>'>
                                            <asp:ListItem Selected="True" Text="" Value="" disabled="disabled"></asp:ListItem>

                                            <asp:ListItem Text="Politics" Value="Politics"></asp:ListItem>
                                            <asp:ListItem Text="TvMovies" Value="TvMovies"></asp:ListItem>
                                            <asp:ListItem Text="ScienceTechnlogy" Value="ScienceTechnlogy"></asp:ListItem>


                                            <asp:ListItem Text="SportsGaming" Value="SportsGaming"></asp:ListItem>
                                            <asp:ListItem Text="ArtDesign" Value="ArtDesign"></asp:ListItem>
                                            <asp:ListItem Text="Fashion" Value="Fashion"></asp:ListItem>

                                            <asp:ListItem Text="Health" Value="Health"></asp:ListItem>
                                            <asp:ListItem Text="Music" Value="Music"></asp:ListItem>
                                            <asp:ListItem Text="Religion" Value="Religion"></asp:ListItem>
                                        </asp:DropDownList>

                                    </ItemTemplate>
                                </asp:TemplateField>
            </Columns>
                        </asp:GridView>
                        
                          <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

						
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
