<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="BookCheckInCheckOut.Web.TestPage" %>

<%@ Register Src="~/Controls/_PreLoader.ascx" TagPrefix="uc1" TagName="_PreLoader" %>
<%@ Register Src="~/Controls/_TopBar.ascx" TagPrefix="uc1" TagName="_TopBar" %>
<%@ Register Src="~/Controls/_SideBar.ascx" TagPrefix="uc1" TagName="_SideBar" %>
<%@ Register Src="~/Controls/_PageTitles.ascx" TagPrefix="uc1" TagName="_PageTitles" %>
<%@ Register Src="~/Controls/_Footer.ascx" TagPrefix="uc1" TagName="_Footer" %>


<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <!-- Tell the browser to be responsive to screen width -->
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <!-- Favicon icon -->
    <link rel="icon" type="image/png" sizes="16x16" href="<%=ResolveClientUrl("~/Contents/material-lite/assets/images/favicon.png")%>">
    <title>Material Pro Admin Template - The Most Complete & Trusted Bootstrap 4 Admin Template</title>
    <!-- Bootstrap Core CSS -->
    <link href="<%=ResolveClientUrl("~/Contents/material-lite/assets/plugins/bootstrap/css/bootstrap.min.css") %>" rel="stylesheet">
    <!-- Custom CSS -->
    <link href="<%=ResolveClientUrl("~/Contents/material-lite/css/style.css")%>" rel="stylesheet">
    <!-- You can change the theme colors from here -->
    <link href="<%=ResolveClientUrl("~/Contents/material-lite/css/colors/blue.css")%>" id="theme" rel="stylesheet">
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
    <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
<![endif]-->
</head>

<body class="fix-header fix-sidebar card-no-border">
    <uc1:_PreLoader runat="server" ID="_PreLoader" />
    <!-- ============================================================== -->
    <!-- Main wrapper - style you can find in pages.scss -->
    <!-- ============================================================== -->
    <div id="main-wrapper">
        <uc1:_TopBar runat="server" ID="_TopBar" />
        <uc1:_SideBar runat="server" ID="_SideBar" />
        <!-- ============================================================== -->
        <!-- Page wrapper  -->
        <!-- ============================================================== -->
        <div class="page-wrapper">
            <!-- ============================================================== -->
            <!-- Container fluid  -->
            <!-- ============================================================== -->
            <div class="container-fluid">
                <uc1:_PageTitles runat="server" ID="_PageTitles" />
                <!-- ============================================================== -->
                <!-- Start Page Content -->
                <!-- ============================================================== -->
                <div class="row">
                    <div class="col-12">
                        <div class="card">
                            <div class="card-block">
                                This is some text within a card block.
                            </div>
                        </div>
                    </div>
                </div>
                <!-- ============================================================== -->
                <!-- End PAge Content -->
                <!-- ============================================================== -->
            </div>
            <!-- ============================================================== -->
            <!-- End Container fluid  -->
            <!-- ============================================================== -->
            <!-- ============================================================== -->
            <uc1:_Footer runat="server" ID="_Footer" />
        </div>
        <!-- ============================================================== -->
        <!-- End Page wrapper  -->
        <!-- ============================================================== -->
    </div>
    <!-- ============================================================== -->
    <!-- End Wrapper -->
    <!-- ============================================================== -->
    <!-- ============================================================== -->
    <!-- All Jquery -->
    <!-- ============================================================== -->
    <script src="<%=ResolveClientUrl("~/Contents/material-lite/assets/plugins/jquery/jquery.min.js") %>"></script>
    <!-- Bootstrap tether Core JavaScript -->
    <script src="<%=ResolveClientUrl("~/Contents/material-lite/assets/plugins/bootstrap/js/tether.min.js") %>"></script>
    <script src="<%=ResolveClientUrl("~/Contents/material-lite/assets/plugins/bootstrap/js/bootstrap.min.js") %>"></script>
    <!-- slimscrollbar scrollbar JavaScript -->
    <script src="<%=ResolveClientUrl("~/Scripts/material-lite/js/jquery.slimscroll.js") %>"></script>
    <!--Wave Effects -->
    <script src="<%=ResolveClientUrl("~/Scripts/material-lite/js/waves.js") %>"></script>
    <!--Menu sidebar -->
    <script src="<%=ResolveClientUrl("~/Scripts/material-lite/js/sidebarmenu.js") %>"></script>
    <!--stickey kit -->
    <script src="<%=ResolveClientUrl("~/Contents/material-lite/assets/plugins/sticky-kit-master/dist/sticky-kit.min.js") %>"></script>
    <!--Custom JavaScript -->
    <script src="<%=ResolveClientUrl("~/Scripts/material-lite/js/custom.min.js") %>"></script>
</body>

</html>
