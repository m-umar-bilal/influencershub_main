<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterUser.Master" AutoEventWireup="true" CodeBehind="User-ConfirmEmail.aspx.cs" Inherits="Views.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div id="page-wrapper" >
            <div id="page-inner">
                <div class="row">
                    <div class="col-md-12">
                     <h2>Confirm Your Email</h2>   
                        <h5>Email Is sent on your Email ID. kindly Enter the code to verfiy your email address. </h5>
                        
                         <div class="form-group has-success">
                             <div style="width:30%" >
                      <label id="EnterCode" runat="server" class="control-label" for="Enter Code">Enter Code </label>
                    &nbsp;<input type="text" class="form-control" runat="server" name="ConfirmCode" id="ConfirmCode">

                            &nbsp;&nbsp; 
                             </div>
                                        &nbsp;<asp:Button ID="Button1" runat="server" Text="Enter" OnClick="Button1_Click" />
                             <asp:Label ID="ConfirmMessage" runat="server" Text=""></asp:Label>
                             </div>
                       
                    </div>
                </div>
                 <!-- /. ROW  -->
                 <hr />
               
    </div>
             <!-- /. PAGE INNER  -->
            </div>
         <!-- /. PAGE WRAPPER  -->
        </div>
     <!-- /. WRAPPER  -->
</asp:Content>
