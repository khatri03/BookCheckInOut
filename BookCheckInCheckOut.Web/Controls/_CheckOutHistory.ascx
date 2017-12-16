<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_CheckOutHistory.ascx.cs" Inherits="BookCheckInCheckOut.Web.Controls._CheckOutHistory" %>
<div class="table-responsive">
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
</div>
