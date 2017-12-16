<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_PageTitles.ascx.cs" Inherits="BookCheckInCheckOut.Web.Controls._PageTitles" %>
<%@ Register Src="~/Controls/_BreadCrumb.ascx" TagPrefix="uc1" TagName="_BreadCrumb" %>
<!-- ============================================================== -->
<!-- Bread crumb and right sidebar toggle -->
<!-- ============================================================== -->
<style type="text/css">
    
}

</style>
<div class="row page-titles">
    <a href="<%=ResolveClientUrl("~/HomePage.aspx") %>" class="home-page" title="Back to Home"></a>
    <div class="col-md-5 col-8 align-self-center">
        
        <h3 class="text-themecolor m-b-0 m-t-0"><%=this.PageTitle %></h3>
        <%--<ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="javascript:void(0)">Home</a></li>
            <li class="breadcrumb-item active">Dashboard</li>
        </ol>--%>
        <%--<uc1:_BreadCrumb runat="server" ID="_BreadCrumb" />--%>
    </div>
    <%--<div class="col-md-7 col-4 align-self-center">
        <a href="https://wrappixel.com/templates/materialpro/" class="btn waves-effect waves-light btn-danger pull-right hidden-sm-down">Upgrade to Pro</a>
    </div>--%>
</div>
<!-- ============================================================== -->
<!-- End Bread crumb and right sidebar toggle -->
<!-- ============================================================== -->
