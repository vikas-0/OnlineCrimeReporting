<%@ Page Title="Admin" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <ul id="myTab" class="nav nav-tabs">
        <li>
            <a href="#news" data-toggle="tab">News
      </a>
        </li>

        <li class="active"><a href="#reports" data-toggle="tab">Reports</a></li>


    </ul>

    <div id="myTabContent" class="tab-content">

        <div class="tab-pane fade" id="news">
            <div class="form-group">
                <asp:TextBox ID="TitleTextBox" runat="server" CssClass="form-control" placeholder="Title"></asp:TextBox>
                <asp:TextBox ID="NewsTextBox" runat="server" CssClass="form-control" TextMode="MultiLine" Height="200" placeholder="News"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" CssClass="btn btn-primary" Text="Post" />
            </div>
        </div>

        <div class="tab-pane fade  in active" id="reports">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <ItemTemplate>

                    <div class="panel panel-info">
                        <div class="panel-body">
                            <p id="id" runat="server"><strong>ID:  <%#Eval("idReports") %></strong></p>
                            <p><strong>Name: <%#Eval("Name") %></strong></p>
                            <p><strong>Email: <%#Eval("Email") %></strong></p>
                            <p><strong>Contact Number: <%#Eval("Mobile") %></strong></p>
                            <p><strong>Address: <%#Eval("Address") %></strong></p>
                            <p><strong>Complaint Description:<%#Eval("Description") %></strong> </p>
                            <p><strong>Status:<%#Eval("StatusMessage") %></strong> </p>
                        </div>
                        <div class="panel-footer">
                            <%#Eval("DateTime") %> &emsp;
                            <button type="button" class="btn btn-info" onclick="$('#TextBox2').val('<%#Eval("idReports") %>');  $('#DownloadButton').click();">Download File</button>
                            &emsp;
                    <button type="button" class="btn btn-success" data-toggle="modal" data-target="#myModal" onclick="$('#TextBox2').val('<%#Eval("idReports") %>')">Respond</button>
                        </div>
                    </div>
                </ItemTemplate>

            </asp:Repeater>


        </div>

    </div>


    <!-- Modal -->
    <div id="myModal" class="modal fade" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Enter Message</h4>
                </div>
                <div class="modal-body">
                    <asp:TextBox ID="TextBox2" CssClass="hidden" ClientIDMode="Static" runat="server"></asp:TextBox>
                    <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="modal-footer">
                    <button type="button" id="ResponseSubmit" runat="server" onserverclick="ResponseSubmit_ServerClick" class="btn btn-default">Submit</button>
                </div>
            </div>

        </div>
    </div>
    <asp:Button ID="DownloadButton" ClientIDMode="Static" OnClick="DownloadButton_Click" runat="server" Text="Button" CssClass="hidden" />

    <div runat="server" id="alert">
    </div>
</asp:Content>

