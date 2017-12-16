<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CheckIn.aspx.cs" Inherits="BookCheckInCheckOut.Web.CheckIn" %>
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
        <div class="col-md-6 form-group">
            <label for="<%=txtBorrowerName.ClientID %>">Borrower Name:</label>
            <asp:TextBox ID="txtBorrowerName" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div>        
    </div>
    <div class="row">
        <div class="col-md-3 form-group">
            <label for="<%=txtMobileNumber.ClientID %>">Mobile Number:</label>
            <asp:TextBox ID="txtMobileNumber" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div> 
        <div class="col-md-3 form-group">
            <label for="<%=txtReturnDate.ClientID %>">Return Date:</label>
            <asp:TextBox ID="txtReturnDate" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div> 
    </div>
    <div class="row">
        <div class="col-md-3 form-group">
            <label for="<%=txtRequiredReturnDate.ClientID %>">Required Return Date:</label>
            <asp:TextBox ID="txtRequiredReturnDate" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div> 
        <div class="col-md-3 form-group">
            <label for="<%=txtPenalityAmount.ClientID %>">Penality Amount:</label>
            <asp:TextBox ID="txtPenalityAmount" runat="server" CssClass="form-control text-right" Enabled="false"></asp:TextBox>
        </div> 
    </div>
    <div class="row">
        <div class="col-md-12 text-right">
            <asp:Button ID="btnCheckin" runat="server" CssClass="btn btn-success" Text="Checkin" OnClick="btnCheckin_Click" />
        </div>
    </div>
    <%if (this.CheckedInSuccessfully)
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
