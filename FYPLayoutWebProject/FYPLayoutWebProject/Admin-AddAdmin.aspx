<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterAdmin.master" AutoEventWireup="true" CodeBehind="Admin-AddAdmin.aspx.cs" Inherits="Views.WebForm9" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="col-md-8">
            <div class="network">
                     <h4>Administrators</h4>   
                       
               
                    <form runat="server">
                     
                    
                        <h3>Add new Admin</h3>
                        
                         <div class="col-md-12" style="width:50%">
                        <asp:Label ID="lblError" runat="server" CssClass="text-error"></asp:Label><br/>
                        <label for="firstname">First Name</label>
                        <input type="text" id="firstname" name="firstname" placeholder="Saint" required title="Saint" pattern="^[A-Z][a-zA-Z]*$"/>
                        <label for="lastname">Last Name</label>
                        <input type="text" id="lastname" name="lastname" placeholder="John" required title="John" pattern="^[A-Z][a-zA-Z]*$"/>

                        <label for="email">Email</label>
                        <input type="email" id="email" name="email" placeholder="user@mail.xyz" required/>
                        <label for="password">Password</label>
                        <input type="password" id="password" name="password"  placeholder="A4cd4234" required title="UpperCase, LowerCase and Number" pattern="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s).*$"/>

                         <br />

                        <asp:Button type="submit" CssClass="btnOwn" runat="server" Text="Register" OnClick="registerbtn" Height="38px" Width="219px" />
                     
                        </div>
                       
                        
                      

                    <div class="col-md-12" style="width:50%">
                        <h2><br/></h2>

                          <h3>&nbsp;</h3>
                       

                        <asp:GridView ID="AdminView" runat="server"></asp:GridView>
                    </div>
                           
                      </form>
              
          </div>

         </div>
                
              
     <!-- /. WRAPPER  -->

      <!-- Javascript -->
        <script src="assets/js/jquery-1.8.2.min.js"></script>
        <script src="assets/bootstrap/js/bootstrap.min.js"></script>
        <script src="assets/js/jquery.backstretch.min.js"></script>
        <script src="assets/js/scripts.js"></script>
</asp:Content>
