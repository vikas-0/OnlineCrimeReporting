<%@ Page Title="Welcome" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script>
        $(document).ready(function () {
            $('#HomeLink').addClass('active');
        });
    </script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div class="jumbotron">
       <h2>Welcome to Online Crime Reporting Portal</h2>
       <hr />
       <h4>Register complains about any mishap, online easily</h4>
       <div  class="row">
           <div class="col-sm-4">
               <i class="fa fa-eye  fa-5x"></i>
               <p>Witness Crime</p>
           </div>
           <div class="col-sm-4">
               <i class="fa fa-pencil fa-5x"></i>
               <p>Report About It</p>
           </div>
           <div class="col-sm-4">
               <i class="fa fa-sign-language fa-5x"></i>
               <p>And we will take action</p>
           </div>
       </div>

   </div>
       <h3 style="text-align:center">Help us to help you</h3>
</asp:Content>