<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" Async="true" CodeBehind="User-Message.aspx.cs" Inherits="FYPLayoutWebProject.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="col-md-8">
            <div class="network">
               
                <form runat="server">
           <input type="search" runat="server"  name="txtMessage" id="txtMessage" placeholder="Write Your Message Here">
                <asp:Button ID="BtnSend" runat="server" Text="Send" OnClick="BtnSend_Click" />
                    </form>
               
               
    </div>
        </div>
</asp:Content>
