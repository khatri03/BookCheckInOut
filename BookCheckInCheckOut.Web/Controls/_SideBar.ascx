<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_SideBar.ascx.cs" Inherits="BookCheckInCheckOut.Web.Controls._SideBar" %>
<%@ Register Src="~/Controls/_SideBarFooter.ascx" TagPrefix="uc1" TagName="_SideBarFooter" %>

<!-- ============================================================== -->
<!-- Left Sidebar - style you can find in sidebar.scss  -->
<!-- ============================================================== -->
<aside class="left-sidebar" style="padding-top: 0px !important;">
    <!-- Sidebar scroll-->
    <div class="scroll-sidebar">
        <!-- Sidebar navigation-->
        <nav class="sidebar-nav">
            <ul id="sidebarnav">
                <li>
                    <a class="waves-effect waves-dark" href="index.html" aria-expanded="false">
                        <i class="mdi mdi-gauge"></i>
                        <span class="hide-menu">Dashboard</span>
                    </a>
                </li>
                <%--<li><a class="waves-effect waves-dark" href="pages-profile.html" aria-expanded="false"><i class="mdi mdi-account-check"></i><span class="hide-menu">Profile</span></a>
                </li>
                <li><a class="waves-effect waves-dark" href="table-basic.html" aria-expanded="false"><i class="mdi mdi-table"></i><span class="hide-menu">Basic Table</span></a>
                </li>
                <li><a class="waves-effect waves-dark" href="icon-material.html" aria-expanded="false"><i class="mdi mdi-emoticon"></i><span class="hide-menu">Icons</span></a>
                </li>
                <li><a class="waves-effect waves-dark" href="map-google.html" aria-expanded="false"><i class="mdi mdi-earth"></i><span class="hide-menu">Google Map</span></a>
                </li>
                <li><a class="waves-effect waves-dark" href="pages-blank.html" aria-expanded="false"><i class="mdi mdi-book-open-variant"></i><span class="hide-menu">Blank Page</span></a>
                </li>
                <li><a class="waves-effect waves-dark" href="pages-error-404.html" aria-expanded="false"><i class="mdi mdi-help-circle"></i><span class="hide-menu">Error 404</span></a>
                </li>--%>
            </ul>
            <%--<div class="text-center m-t-30">
                <a href="https://wrappixel.com/templates/materialpro/" class="btn waves-effect waves-light btn-warning hidden-md-down">Upgrade to Pro</a>
            </div>--%>
        </nav>
        <!-- End Sidebar navigation -->
    </div>
    <!-- End Sidebar scroll-->
    <%--<uc1:_SideBarFooter runat="server" id="_SideBarFooter" />--%>
</aside>
<!-- ============================================================== -->
<!-- End Left Sidebar - style you can find in sidebar.scss  -->
<!-- ============================================================== -->
