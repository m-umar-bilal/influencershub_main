<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" async="true" AutoEventWireup="true" CodeBehind="User-SelectCategory.aspx.cs" Inherits="FYPLayoutWebProject.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-8">
            <div class="network">
             
                     <h4>Step 1 of 3 : Select Category</h4>   
                        <p>Select a category of which you want to view influencers.</p>
                <form runat="server">
                    <asp:DropDownList ID="Cat_List" runat="server" ></asp:DropDownList>
                    <asp:Button ID="btn_Select" runat="server" Text="Select" OnClick="btn_Select_Click" />
                </form>
                    </div>
         </div>
</asp:Content>
