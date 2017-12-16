<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BookDetail.aspx.cs" Inherits="BookCheckInCheckOut.Web.BookDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-6 form-group">
            <label for="<%=txtBookTitle.ClientID %>">Bool Title:</label>
            <asp:TextBox ID="txtBookTitle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div>
        <div class="col-md-6 form-group">
            <label for="<%=txtISBN.ClientID %>">ISBN:</label>
            <asp:TextBox ID="txtISBN" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3 form-group">
            <label for="<%=txtPublishYear.ClientID %>">Publish Year:</label>
            <asp:TextBox ID="txtPublishYear" runat="server" CssClass="form-control text-right" Enabled="false"></asp:TextBox>
        </div>
        <div class="col-md-3 form-group">
            <label for="<%=txtCoverPrice.ClientID %>">Cover Price:</label>
            <asp:TextBox ID="txtCoverPrice" runat="server" CssClass="form-control text-right" Enabled="false"></asp:TextBox>
        </div>
        <div class="col-md-6 form-group">
            <label for="<%=txtStatus.ClientID %>">Status:</label>
            <asp:TextBox ID="txtStatus" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        
    </div>
</asp:Content>
