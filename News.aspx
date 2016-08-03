<%@ Page Title="News" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="News" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel-group" id="feed" runat="server" style="max-width: 700px; margin: 0 auto">
      
        <asp:Repeater ID="Repeater1" runat="server" >
            
            <ItemTemplate>
                <div class="panel panel-primary">
                    <div class="panel-heading">
                       <%# Eval("title")%>
                    </div>
                    <div class="panel-body">
                        <%# Eval("news") %>
                    </div>
                    <div class="panel-footer">
                        <%# Eval("datetime")  %> &emsp; PostedBy:- <%# Eval("author") %>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>
</asp:Content>

