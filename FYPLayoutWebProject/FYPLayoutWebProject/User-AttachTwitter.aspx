<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" Async="true" AutoEventWireup="true" CodeBehind="User-AttachTwitter.aspx.cs" Inherits="FYPLayoutWebProject.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="col-md-8">
            <div class="network">
             
                     <h4>Step 2 of 3 : Attach Twitter Account</h4>   
                        <p>Click the button below to attach your twitter account  </p>
                <form runat="server">
                  <asp:Button ID="Button1" runat="server" CssClass="twitter" Text="Sign in with Twitter" OnClick="Button1_Click"/>
                </form>
                    </div>
         </div>
</asp:Content>
