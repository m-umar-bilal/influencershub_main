<%@ Page Title="View Tweets" Language="C#" MasterPageFile="~/MainMasterAdmin.master" AutoEventWireup="true" CodeBehind="Admin-Tweets.aspx.cs" Inherits="Views.WebForm8" Async="true"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper" >
            <div id="page-inner">
                <div class="row">
                    <div class="col-md-12">
                     <h2> Get tweets of trends</h2>   
                        <h5>Select a trend to get tweets&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="TrendList" runat="server" OnSelectedIndexChanged="TrendList_SelectedIndexChanged"></asp:DropDownList>

                        </h5>
                        <br />

                        <asp:GridView ID="TweetView" runat="server"></asp:GridView>
                        
                       
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
