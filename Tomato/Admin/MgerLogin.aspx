<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="MgerLogin.aspx.cs" Inherits="Admin_MgerLogin" %>

<%@ Register Src="Mger_UserControl/UC_PhanTrang.ascx" TagName="UC_PhanTrang" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content">
        <div class="header">
            <h1 class="page-title">
                <asp:Label ID="Label1" runat="server" Text="Quản lý đăng nhập" /></h1>
        </div>
        <ul class="breadcrumb">
            <li><a href="Admin.aspx">Trang chủ</a> <span class="divider">>></span></li>
            <li class="active">Quản lý người dùng<span class="divider">>></span></li>
            <li class="active">Quản lý đăng nhập</li>
        </ul>
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="content_right">
                    <div class="toolbar">
                        <asp:DropDownList runat="server" ID="ddlCategory" AutoPostBack="true" AppendDataBoundItems="true"
                            OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" CssClass="drl">
                            <asp:ListItem>--Chọn xem theo người dùng-- </asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button Text="Xóa đăng nhập" runat="server" ID="btnDelete" CssClass="multidelete" />
                        <input type="button" value="Làm mới danh sách" class="btnedit" onclick="location.href='MgerLogin.aspx'" />
                    </div>
                    <div class="block">
                        <p class="block-heading">
                            Danh sách hành động đăng nhập trong hệ thống</p>
                        <table class="list">
                            <thead>
                                <tr>
                                    <th class="cid">
                                        <input type="checkbox" id="chkAll" />
                                    </th>
                                    <th class="titlemax">
                                        Người dùng
                                    </th>
                                    <th class="titlemin">
                                        Thời gian đăng nhập
                                    </th>
                                    <th class="titlemin">
                                        Địa chỉIP đăng nhập
                                    </th>
                                    <th class="id">
                                        ID
                                    </th>
                                </tr>
                            </thead>
                            <asp:Repeater runat="server" ID="repProd">
                                <AlternatingItemTemplate>
                                    <tr class="eventop">
                                        <td>
                                            <input type="checkbox" name='cid' value='<%#Eval("IDDangNhap") %>' />
                                        </td>
                                        <td class="titlemax">
                                            <%#Eval("TenDangNhap")%>
                                        </td>
                                        <td class="titlemin">
                                            <%#ShowData(Container.DataItem, "ThoiGian")%>
                                        </td>
                                        <td class="titlemin">
                                            <%#Eval("DiaChiIP")%>
                                        </td>
                                        <td class="id">
                                            <%#Eval("IDDangNhap")%>
                                        </td>
                                    </tr>
                                    <tr class="eventop">
                                        <td colspan="5">
                                            <%#Eval("HanhDong")%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5">
                                        </td>
                                    </tr>
                                </AlternatingItemTemplate>
                                <ItemTemplate>
                                    <tr class="evenbottom">
                                        <td>
                                            <input type="checkbox" name='cid' value='<%#Eval("IDDangNhap") %>' />
                                        </td>
                                        <td class="titlemax">
                                            <%#Eval("TenDangNhap")%>
                                        </td>
                                        <td class="titlemin">
                                            <%#ShowData(Container.DataItem, "ThoiGian")%>
                                        </td>
                                        <td class="titlemin">
                                            <%#Eval("DiaChiIP")%>
                                        </td>
                                        <td class="id">
                                            <%#Eval("IDDangNhap")%>
                                        </td>
                                    </tr>
                                    <tr class="evenbottom">
                                        <td colspan="5">
                                            <%#Eval("HanhDong")%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5">
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                    <uc1:UC_PhanTrang ID="PagerBottom" runat="server" />
                </div>
            </div>
        </div>
        <div class="clearfix">
        </div>
    </div>
</asp:Content>

