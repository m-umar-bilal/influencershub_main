<%@ Page Title="Admin Login" Language="C#" MasterPageFile="~/RegisterForm.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Views.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ButtonContent" runat="server">

      
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="register span6">
                    <form method="post" runat="server">
                        <h2>LOGIN For<span class="red"><strong>&nbsp;Admin</strong></span></h2>
                         <asp:Label ID="lblError" runat="server" CssClass="text-error"></asp:Label>
                         <label for="email">Email</label>
                        <input type="email" id="email" name="email" required/>
                        <label for="password">Password</label>
                        <input type="password" id="password" name="password" required/>
                      
                      
                        <h3><asp:Button runat="server" text="Login" CssClass="btn-toolbar" type="submit" onClick="loginbtn"/> </h3>
                    </form>
                </div>
</asp:Content>
