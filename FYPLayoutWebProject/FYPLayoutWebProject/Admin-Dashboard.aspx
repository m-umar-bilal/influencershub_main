<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterAdmin.master" AutoEventWireup="true" CodeBehind="Admin-Dashboard.aspx.cs" Inherits="Views.WebForm10" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
    <div class="col-md-8" >
            <div class="network" >
                




                 <!--    <42>Dashboard</42>   -->
                        <h5>Welcome</h5>
                       
                           <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                         
                      
                <asp:Button ID="Button1" runat="server" Text="Start Getting Trends" OnClick="Button1_Click" />
                <asp:Label ID="TimeLabel" runat="server" Text="Label"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine"></asp:TextBox>
                    
                    </div>
                </div>
    </form>
</asp:Content>
