<%@ Page Title="" Language="C#" MasterPageFile="~/RegisterForm.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Views.WebForm2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title> iHUB Register </title>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ButtonContent" Runat="Server">
    <form action="SignIn.aspx">
        <h3><button type="submit" class="btn-link"> Login to iHub </button></h3>
    </form>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="register span6">
                    <form id="form1" runat="server" >
                        <h2>REGISTER TO <span class="red"><strong>&nbsp;iHUB!</strong></span></h2>
                        <asp:Label ID="lblError" runat="server" CssClass="text-error"></asp:Label>
                        <label for="firstname">First Name</label>
                        <input type="text" id="firstname" name="firstname" placeholder="Saint" required title="Saint" pattern="^[A-Z][a-zA-Z]*$"/>
                        <label for="lastname">Last Name</label>
                        <input type="text" id="lastname" name="lastname" placeholder="John" required title="John" pattern="^[A-Z][a-zA-Z]*$"/>

                        <label for="email">Email</label>
                        <input type="email" id="email" name="email" placeholder="user@mail.xyz" required/>
                        <label for="password">Password</label>
                        <input type="password" id="password" name="password"  placeholder="A4cd4234" required title="UpperCase, LowerCase and Number" pattern="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s).*$"/>

                        <asp:Button type="submit" CssClass="btnOwn" runat="server" Text="Register" OnClick="registerbtn" />
                        
                       
                    </form>
                </div>
</asp:Content>


