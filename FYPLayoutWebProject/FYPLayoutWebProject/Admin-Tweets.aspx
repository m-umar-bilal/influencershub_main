<%@ Page Title="View Tweets" Language="C#" MasterPageFile="~/MainMasterAdmin.master" AutoEventWireup="true" CodeBehind="Admin-Tweets.aspx.cs" Inherits="Views.WebForm8" Async="true"%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-8">
            <div class="network">
                     <h4> Get tweets of trends</h4>  
                         <form runat="server"> 
                        <h5>Select a trend to get tweets&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="TrendList" AutoPostBack="true" runat="server" OnSelectedIndexChanged="TrendList_SelectedIndexChanged" >
                   
                        </asp:DropDownList>

                        </h5>
                        <br />
                          
                             <asp:GridView ID="TweetView" runat="server"></asp:GridView>


                        </form>
                       
                    </div>
                </div>
             
</asp:Content>
