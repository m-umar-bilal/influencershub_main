<%@ Page Title="" Language="C#" MasterPageFile="~/RegisterForm.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="Views.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title> iHUB Home </title>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ButtonContent" Runat="Server">
    <form action="SignUp.aspx">
        <h3><button type="submit" class="btn-link"> Register to iHub </button></h3>
    </form>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="register span6">
                    <form method="post" runat="server">
                        <h2>LOGIN TO<span class="red"><strong>&nbsp;iHUB!</strong></span></h2>
                         <asp:Label ID="lblError" runat="server" CssClass="text-error"></asp:Label>
                        <label for="email">Email</label>
                        <input type="email" id="email" name="email" required/>
                        <label for="password">Password</label>
                        <input type="password" id="password" name="password" required/>
                       
                         <div class="hyper">
                        <asp:HyperLink  ID="HyperLink1" runat="server"  NavigateUrl="~/ForgottenPassword.aspx" CssClass="links">Forgotten Password?</asp:HyperLink>
                      
                         
                        </div>
                        <h3><asp:Button runat="server" text="Login" CssClass="btn-toolbar" type="submit" onClick="loginbtn"/> </h3>
                    </form>
                </div>
</asp:Content>

