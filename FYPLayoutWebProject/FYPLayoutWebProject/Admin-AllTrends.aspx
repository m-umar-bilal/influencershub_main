<%@ Page Title="View Trends" Language="C#" MasterPageFile="~/MainMasterAdmin.master" AutoEventWireup="true" CodeBehind="Admin-AllTrends.aspx.cs" Inherits="Views.WebForm5" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <div class="col-md-8">
            <div class="network">
                     
                     <h4>View all collected trends</h4>   
                        <form runat="server">

                        <asp:GridView ID="TrendView" runat="server"></asp:GridView>
                        </form>
                       
                    </div>
                </div>
                 <!-- /. ROW  -->
           
</asp:Content>
