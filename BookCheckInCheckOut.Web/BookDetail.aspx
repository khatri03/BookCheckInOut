<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BookDetail.aspx.cs" Inherits="BookCheckInCheckOut.Web.BookDetail" %>

<%@ Register Src="~/Controls/_CheckOutHistory.ascx" TagPrefix="uc1" TagName="_CheckOutHistory" %>


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
        <div class="col-md-12">
            <%--<div class="table-responsive">
                <table class="table table-striped table-bordered" id="booklist">
                    <thead>
                        <tr>
                            <th class="text-center">Name</th>
                            <th>Check Out Date</th>
                            <th>Returned Date</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:ListView ID="HistoryList" runat="server" ClientIDMode="Static">
                            <ItemTemplate>
                                <tr>
                                    <td class="text"><%# Eval("Name") %></td>
                                    <td class="text-center"><%# Eval("CheckOutDate") %> </td>
                                    <td class="text-center"><%# Eval("ReturnDate") %> </td>
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                    </tbody>
                </table>
                <asp:HiddenField ID="hdnField" runat="server" ClientIDMode="Static" />
            </div>--%>
            <uc1:_CheckOutHistory runat="server" id="_CheckOutHistory" />
        </div>
    </div>
</asp:Content>
