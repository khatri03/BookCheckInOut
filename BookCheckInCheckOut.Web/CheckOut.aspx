<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CheckOut.aspx.cs" Inherits="BookCheckInCheckOut.Web.CheckOut" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-6 form-group">
            <label for="<%=txtBookTitle.ClientID %>"></label>
            <asp:TextBox ID="txtBookTitle" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
</asp:Content>
