<%@ Page Title="View Trends" Language="C#" MasterPageFile="~/MainMasterAdmin.master" AutoEventWireup="true" CodeBehind="Admin-CatTrends.aspx.cs" Inherits="Views.WebForm7" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper" >
            <div id="page-inner">
                <div class="row">
                    <div class="col-md-12">
                     <h4> Categories&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </h4>
                         <form runat="server">
                        <br />

                        <asp:GridView ID="TrendView" runat="server"></asp:GridView>
                        
                       </form>
                    </div>
                </div>
                 <!-- /. ROW  -->
                 <hr />
               
    </div>
             <!-- /. PAGE INNER  -->
            </div>
         <!-- /. PAGE WRAPPER  -->
        </div>
     <!-- /. WRAPPER  -->
</asp:Content>
