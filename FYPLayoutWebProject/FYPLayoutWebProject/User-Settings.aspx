<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="User-Settings.aspx.cs" Inherits="FYPLayoutWebProject.User_Settings" Async="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="col-md-8">
            <div class="network">
             
                  <h4>Settings</h4>   
                        <p>Select a category of which you want to view influencers</p>
                <form runat="server">
                    <asp:DropDownList ID="Cat_List" runat="server" ></asp:DropDownList>
                    <asp:Button ID="btn_Select" runat="server" Text="Select" OnClick="btn_Select_Click" />
                    <asp:Label ID="Message" runat="server" Text=""></asp:Label>
                </form>

                    </div>
         </div>
       
</asp:Content>