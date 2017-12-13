<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="BookCheckInCheckOut.Web.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="table-responsive">
        <table class="table table-striped">
            <thead>
                <tr>
                    <th></th>
                    <th>Select </th>
                    <th>Title </th>
                    <th>ISBN  </th>
                    <th>PublishYear </th>
                    <th>CoverPrice </th>
                    <th>Status </th>
                </tr>
            </thead>
            <tbody>
                <asp:ListView ID="BooksList" runat="server" ClientIDMode="Static">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:HiddenField runat="server" ID="hd" ClientIDMode="AutoID" Value='<%# Eval("BookID") %>' />
                            </td>
                            <td>
                                <asp:RadioButton runat="server" ID="rd" ClientIDMode="AutoID" onclick="bookSelected(this)" data-book-id='<%#Eval("BookID")%>' data-book-status='<%#Eval("CheckOutStatusDescription")%>' />
                            </td>
                            <td class="text"><%# Eval("Title") %></td>
                            <td class="text"><%# Eval("ISBN") %> </td>
                            <td class="text"><%# Eval("PublishYear") %> </td>
                            <td class="text"><%# Eval("CoverPrice") %> </td>
                            <td class="text"><%# Eval("CheckOutStatusDescription") %> </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </tbody>
        </table>
        <asp:HiddenField ID="hdnField" runat="server" ClientIDMode="Static" />
    </div>
</asp:Content>
