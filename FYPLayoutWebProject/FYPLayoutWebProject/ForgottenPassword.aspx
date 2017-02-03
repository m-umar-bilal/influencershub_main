<%@ Page Title="Forgotten Password" Language="C#" MasterPageFile="~/RegisterForm.Master" AutoEventWireup="true" CodeBehind="ForgottenPassword.aspx.cs" Inherits="Views.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ButtonContent" runat="server">
     <form action="SignUp.aspx">
        <h3><button type="submit" class="btn-link"> Register to iHub </button></h3>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="register span6">
                    <form method="post" runat="server">
                        <h2><span class="red">Forgotten Password?</span></h2>
                         <asp:Label ID="lblError" runat="server" CssClass="text-error"></asp:Label>
                        <label >Password will be send on the Email ID If your email is registered in iHub.</label>
                        <input type="email" id="email" name="email"/>
                       
                        <h3><asp:Button runat="server" text="Send Password" CssClass="btn-small" OnClick="Unnamed1_Click" /> </h3>
                        <h3><asp:Button runat="server" text="Back To Login" CssClass="btn-mini" type="submit" OnClick="Unnamed2_Click" /> </h3>
                    </form>
                </div>
</asp:Content>
