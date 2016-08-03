<%@ Page Title="Complain" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="complain.aspx.cs" Inherits="complain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .form-group input, textarea {
            margin-bottom: 0.3em;
        }

        hr{
            border:none;
            height:3px;
            background-color:ActiveCaption;
        }
    </style>
    <script>
        $(document).ready(function () {
            $('#complainmenu').addClass('active');
            $('#registercomp').addClass('active');
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div role="form" runat="server" id="form" class="form-horizontal">
        <fieldset style="max-width: 500px; margin: 10px auto">
            <legend>Enter Details</legend>
            <div class="form-group">
                <asp:TextBox ID="NameTextBox" runat="server" CssClass="form-control" placeholder="Name"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Name" ControlToValidate="NameTextBox" Display="Dynamic" ValidationGroup="RegisterComplain" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name is Required" Display="Dynamic" ControlToValidate="NameTextBox" ValidationGroup="RegisterComplain"></asp:RequiredFieldValidator>
                <asp:TextBox ID="EmailTextBox" runat="server" placeholder="Email" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Email Address is Required" Display="Dynamic" ControlToValidate="EmailTextBox" ValidationGroup="RegisterComplain"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid Email" Display="Dynamic" ControlToValidate="EmailTextBox" ValidationGroup="RegisterComplain" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <asp:TextBox ID="MobileNumberTextBox" runat="server" placeholder="Mobile Number" type="number" CssClass="form-control"></asp:TextBox>
                <asp:RegularExpressionValidator ValidationGroup="RegisterComplain" Display="Dynamic" ControlToValidate="MobileNumberTextBox" ID="RegularExpressionValidator3" runat="server" ErrorMessage="Please Enter 10 Digit Mobile Number" ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ValidationGroup="RegisterComplain" Display="Dynamic" ControlToValidate="MobileNumberTextBox" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Mobile Number is Required"></asp:RequiredFieldValidator>
                <asp:TextBox ID="AddressTextBox" placeholder="Address" TextMode="MultiLine" Height="100px" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Address is Required" Display="Dynamic" ValidationGroup="RegisterComplain" ControlToValidate="AddressTextBox"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Invalid character used in Address. Please remove it first." Display="Dynamic" ControlToValidate="AddressTextBox" ValidationGroup="RegisterComplain" ValidationExpression="^[^<>%$;{}]*$"></asp:RegularExpressionValidator>
                <asp:TextBox ID="DetailedComplainTextBox" runat="server" CssClass="form-control" TextMode="MultiLine" Height="200px" placeholder="Enter Detailed Complain" Font-Bold="True"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Description is Required" Display="Dynamic" ValidationGroup="RegisterComplain" ControlToValidate="DetailedComplainTextBox"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Invalid character used in description. Please remove it first." Display="Dynamic" ControlToValidate="DetailedComplainTextBox" ValidationGroup="RegisterComplain" ValidationExpression="^[^<>%$;{}]*$"></asp:RegularExpressionValidator>
                    <asp:FileUpload ID="file" ClientIDMode="Static"  runat="server" CssClass="sr-only" ToolTip="Upload Any Relevant D0cument or Images" />                
                <div class="input-group">

         <input id="pretty-input" class="form-control" type="text" onclick="$('#file').click();"/>
            <span class="input-group-addon" onclick="$('#file').click();">Browse</span>
        </div>
                <script type="text/javascript">
$('#file').change(function() {
  $('#pretty-input').val($(this).val().replace("C:\\fakepath\\", ""));
});
</script>
                <div class="input-group">
                    <span class="input-group-addon">
                        <asp:Image ID="CaptchaImage" runat="server" />
                        <button id="CaptchaRefresh" runat="server" onserverclick="CaptchaRefresh_ServerClick"><i class="fa fa-refresh"></i></button>
                    </span>
                    <asp:TextBox ID="CaptchaTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Captcha is Required" Display="Dynamic" ValidationGroup="RegisterComplain" ControlToValidate="CaptchaTextBox"></asp:RequiredFieldValidator>
                <asp:Label ID="CaptchaWarningLabel" runat="server" Visible="false" Text="Invalid Captcha Code, Please Re-enter"></asp:Label>
                <asp:Button ID="SubmitComplain" runat="server" Text="Submit" CssClass="btn btn-default" Style="float: right" CausesValidation="true" ValidationGroup="RegisterComplain" OnClick="SubmitComplain_Click" />
            </div>
        </fieldset>
    </div>

    <div id="reply" runat="server" visible="false">
        <div style="max-width:500px; margin:auto;">
            <asp:Button ID="PrintButton" runat="server" Text="Print" CssClass="btn btn-info hidden-print" style="float:right" OnClientClick="window.print()" />
            <label>Report ID/SL No. :&nbsp;</label><asp:Label ID="SlNoLabel" runat="server" Text="SlNoLabel"></asp:Label><hr />
            <label>Date/Time :&nbsp;</label><asp:Label ID="DateTimeLabel" runat="server" Text="DateLabel"></asp:Label><br /><br />
            <label>Name :&nbsp;</label><asp:Label ID="NameLabel" runat="server" Text="NameLabel"></asp:Label><br />
            <label>Email :&nbsp;</label><asp:Label ID="EmailLabel" runat="server" Text="EmailLabel"></asp:Label><br />
            <label>Mobile Number :&nbsp;</label><asp:Label ID="MobileLabel" runat="server" Text="Mobile"></asp:Label>
            <hr />
            <label>Address :&nbsp;</label><asp:Label ID="AddressLabel" runat="server" Text="AddressLabel"></asp:Label>
            <hr />
            <label>Complain Description :&nbsp;</label><asp:Label ID="DescriptionLabel" runat="server" Text="DescriptionLabel"></asp:Label><hr />
            
            <label>Status :&nbsp;</label><asp:Label ID="StatusLabel" runat="server" Text="Status"></asp:Label>
        </div>
    </div>
</asp:Content>

