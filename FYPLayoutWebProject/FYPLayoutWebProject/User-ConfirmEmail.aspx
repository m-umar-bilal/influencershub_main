<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="User-ConfirmEmail.aspx.cs" Inherits="Views.WebForm6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="col-md-8">
            
             
                     <h4>Step 3 of 3 : Confirm Your Email</h4>   
                        <p>Email Is sent on your Email ID. kindly Enter the code to verfiy your email address. </p>
                        
                         <div class="form-group has-success">
                             <div style="width:30%" >
                      <label id="EnterCode" runat="server" class="control-label" for="Enter Code">Enter Code </label>
                    &nbsp;<input type="search" placeholder="Enter Code Here" runat="server" name="ConfirmCode" id="ConfirmCode">

                            &nbsp;&nbsp; 
                             </div>
                             <form runat="server">
                                        &nbsp;<asp:Button ID="Button1" runat="server" Text="Enter" OnClick="Button1_Click" />
                             <asp:Label ID="ConfirmMessage" runat="server" Text=""></asp:Label>
                                 </form>
                             </div>
                       
                    </div>
               
                 <!-- /. ROW  -->
                 <hr />
               
                <!-- /. PAGE INNER  -->
           
         <!-- /. PAGE WRAPPER  -->
      
     <!-- /. WRAPPER  -->
</asp:Content>
