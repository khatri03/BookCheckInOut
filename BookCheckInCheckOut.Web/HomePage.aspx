<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="BookCheckInCheckOut.Web.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="table-responsive">
                <table class="table table-striped table-bordered" id="booklist">
                    <thead>
                        <tr>
                            <th class="text-center">Select </th>
                            <th>Book Title </th>
                            <th>ISBN  </th>
                            <th>Publish Year </th>
                            <th>Cover Price </th>
                            <th>Status </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:ListView ID="BooksList" runat="server" ClientIDMode="Static">
                            <ItemTemplate>
                                <tr>
                                    <td class="text-center">
                                        <asp:HiddenField runat="server" ID="hd" ClientIDMode="AutoID" Value='<%# Eval("BookID") %>' />
                                        <asp:RadioButton runat="server" ID="rd" ClientIDMode="AutoID" onclick="bookSelected(this)" data-book-id='<%#Eval("BookID")%>' data-book-status='<%#Eval("CheckOutStatusDescription")%>' />
                                    </td>
                                    <td class="text"><%# Eval("Title") %></td>
                                    <td class="text"><%# Eval("ISBN") %> </td>
                                    <td class="text-center"><%# Eval("PublishYear") %> </td>
                                    <td class="text-right"><%# string.Format("{0:C}", Eval("CoverPrice"))  %> </td>
                                    <td class="text-center"><%# Eval("CheckOutStatusDescription") %> </td>
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                    </tbody>
                </table>
                <asp:HiddenField ID="hdnField" runat="server" ClientIDMode="Static" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12 text-right">
            <asp:Button ID="btnCheckIn" CssClass="button btn-success action-button" ClientIDMode="Static" runat="server" Text="Check In" OnClick="btnCheckIn_Click" />
            <asp:Button ID="btnCheckOut" CssClass="button btn-success action-button" ClientIDMode="Static" runat="server" Text="Check Out" OnClick="btnCheckOut_Click" />            
            <asp:Button ID="btnBookDetail" CssClass="button btn-success action-button" ClientIDMode="Static" runat="server" Text="Details" OnClick="btnBookDetail_Click" />
        </div>
    </div>
    <script src="<%=ResolveClientUrl("~/Scripts/jquery-1.12.4.js") %>"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            disableActionButtons();
        })
        function disableActionButtons() {
            $('.action-button').each(function (index, val) {
                $(val).attr('disabled', 'disabled');
            })
        }
        function bookSelected(rb) {
            if (rb != null && rb != 'undefined' && rb != undefined) {
                $('#booklist').find(':radio').not(rb).each(function (index, val) {
                    $(val).prop('checked', false);
                })
                enableActionButtons(rb);
            }
        }
        function enableActionButtons(rb) {
            if (rb != null && rb != 'undefined' && rb != undefined && $(rb).length > 0) {
                $('#<%=btnBookDetail.ClientID%>').removeAttr('disabled');
                switch ($(rb).parents('span:first').data('book-status').toLowerCase()) {
                    case 'checked-in':
                        $('#<%=btnCheckIn.ClientID%>').attr('disabled', 'disabled');
                        $('#<%=btnCheckOut.ClientID%>').removeAttr('disabled');
                        break;

                    case 'checked-out':
                        $('#<%=btnCheckOut.ClientID%>').attr('disabled', 'disabled');
                        $('#<%=btnCheckIn.ClientID%>').removeAttr('disabled');
                        break;
                }
            }
        }
        $('.action-button').each(function (index, val) {
            $(this).click(function () {
                var bookId = $('#booklist').find(':radio:checked').parents('span:first').data('book-id');
                $('#<%=hdnField.ClientID%>').val(bookId);
            })
        })
    </script>
</asp:Content>
