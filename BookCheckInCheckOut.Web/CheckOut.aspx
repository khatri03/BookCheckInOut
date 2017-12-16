<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CheckOut.aspx.cs" Inherits="BookCheckInCheckOut.Web.CheckOut" %>

<%@ Register Src="~/Controls/_CheckOutHistory.ascx" TagPrefix="uc1" TagName="_CheckOutHistory" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-6 form-group">
            <label for="<%=txtBookTitle.ClientID %>">Book Title:</label>
            <asp:TextBox ID="txtBookTitle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div>        
    </div>
    <div class="row">
        <div class="col-md-6 form-group text-left">
            <label for="<%=txtBorrowerName.ClientID %>">Borrower Name:</label>
            <asp:TextBox ID="txtBorrowerName" runat="server" CssClass="form-control" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="Errortext" runat="server" ControlToValidate="txtBorrowerName" ErrorMessage="Borrower name is required."></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3 form-group text-left">
            <label for="<%=txtMobileNumber.ClientID %>">Mobile Number:</label>&nbsp;(xx-xxx xxxx)
            <asp:TextBox ID="txtMobileNumber" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RegularExpressionValidator CssClass="Errortext" ID="ReMobileNumber" runat="server" ErrorMessage="Mobile Number should be 11 digits with format xx-xxx xxxx."
                    ControlToValidate="txtMobileNumber" ValidationExpression="((\d{2}-))?\d{3} \d{4}"></asp:RegularExpressionValidator>
                <br /><asp:RequiredFieldValidator ID="RFDMobile" CssClass="Errortext" runat="server" ControlToValidate="txtMobileNumber" ErrorMessage="Mobile Number is required."></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-3 form-group text-left">
            <label for="<%=txtNationalId.ClientID %>">National ID:</label>
            <asp:TextBox ID="txtNationalId" runat="server" CssClass="form-control" MaxLength="11"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="Errortext" ID="RFDNationalID" runat="server" ControlToValidate="txtNationalId" ErrorMessage="National ID is required."></asp:RequiredFieldValidator>
                <br /><asp:RegularExpressionValidator CssClass="Errortext" Display="Dynamic" ID="RENationalID" runat="server" ErrorMessage="National ID should be numeric with 11 digits."
                    ControlToValidate="txtNationalId" ValidationExpression="\d{11}"></asp:RegularExpressionValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3 form-group">
            <label for="<%=txtCheckoutDate.ClientID %>">Checkout Date:</label>
            <asp:TextBox ID="txtCheckoutDate" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div>
        <div class="col-md-3 form-group">
            <label for="<%=txtCheckinDate.ClientID %>">Checkin Date:</label>
            <asp:TextBox ID="txtCheckinDate" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12 text-right">
            <asp:Button ID="btnCheckOut" runat="server" CssClass="btn btn-success" Text="Checkout" OnClick="btnCheckOut_Click" />
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-12">
            <uc1:_CheckOutHistory runat="server" ID="_CheckOutHistory" />
        </div>
    </div>
    <%if (this.CheckedOutSuccessfully)
        { %>
    <script src="<%=ResolveClientUrl("~/Scripts/jquery-1.12.4.js") %>"></script>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            setTimeout(function () {
                window.location.href = '<%=ResolveClientUrl("~/HomePage.aspx")%>'
            }, 2000);
        })
    </script>
    <%} %>
</asp:Content>
