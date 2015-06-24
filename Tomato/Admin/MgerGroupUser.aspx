<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="MgerGroupUser.aspx.cs" Inherits="Admin_MgerGroupUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content">
        <div class="header">
            <h1 class="page-title">
                <asp:Label ID="Label1" runat="server" Text="Quản lý nhóm người dùng" /></h1>
        </div>
        <ul class="breadcrumb">
            <li><a href="Admin.aspx">Trang chủ</a> <span class="divider">>></span></li>
            <li class="active">Quản lý người dùng<span class="divider">>></span></li>
            <li class="active">Quản lý nhóm người dùng</li>
        </ul>
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="block">
                    <p class="block-heading">
                        Danh sách quyền hạn trong hệ thống</p>
                    <table class="list">
                        <thead>
                            <tr>
                                <th class="small">
                                    Mã nhóm
                                </th>
                                <th class="title150">
                                    Tên nhóm
                                </th>
                                <th class="title100">
                                    Quyền hạn
                                </th>
                                <th class="titlemin">
                                    Ngày tạo
                                </th>
                                <th class="titlemax">
                                    Mô tả
                                </th>
                            </tr>
                        </thead>
                        <asp:Repeater runat="server" ID="repProd">
                            <AlternatingItemTemplate>
                                <tr class="eventop">
                                    <td class="small">
                                        <%#Eval("IDNhom")%>
                                    </td>
                                    <td class="title150">
                                        <%#Eval("TenNhom")%>
                                    </td>
                                    <td class="title100">
                                        <%#Eval("QuyenHan")%>
                                    </td>
                                    <td class="titlemin">
                                        <%#ShowData(Container.DataItem, "NgayTao")%>
                                    </td>
                                    <td class="titlemax">
                                        <%#Eval("MoTa")%>
                                    </td>
                                </tr>
                            </AlternatingItemTemplate>
                            <ItemTemplate>
                                <tr class="evenbottom">
                                    <td class="small">
                                        <%#Eval("IDNhom")%>
                                    </td>
                                    <td class="title150">
                                        <%#Eval("TenNhom")%>
                                    </td>
                                    <td class="title100">
                                        <%#Eval("QuyenHan")%>
                                    </td>
                                    <td class="titlemin">
                                        <%#ShowData(Container.DataItem, "NgayTao")%>
                                    </td>
                                    <td class="titlemax">
                                        <%#Eval("MoTa")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
            </div>
        </div>
        <div class="clearfix">
        </div>
    </div>
</asp:Content>
