<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeBehind="BlankMaster.aspx.cs" Inherits="FYPLayoutWebProject.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="page-wrapper" >
            <div id="page-inner">
                <div class="row">
                    <div class="col-md-12">
                     <h2>Trends</h2>   
                        <h5>Welcome Jhon Deo , Love to see you back. </h5>
                       
                    </div>
                </div>
                <asp:GridView ID="GridView1" runat="server" ></asp:GridView>
                 <!-- /. ROW  -->
                 <hr />
               
             </div>
             <!-- /. PAGE INNER  -->
            </div>
</asp:Content>
