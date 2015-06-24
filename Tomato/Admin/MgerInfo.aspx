<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="MgerInfo.aspx.cs" Inherits="Admin_MgerInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content">
        <div class="header">
            <h1 class="page-title">
                <asp:Label ID="Label1" runat="server" Text="Trang cá nhân" /></h1>
        </div>
        <ul class="breadcrumb">
            <li><a href="Admin.aspx">Trang chủ</a> <span class="divider">>></span></li>
            <li class="active">Thông tin cá nhân</li>
        </ul>
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="block">
                    <p class="block-heading">
                        Thông tin cá nhân</p>
                    <div class="content_mid">
                        <asp:Button Text="Chỉnh sửa" ID="btnEdit" runat="server" CssClass="btnedit" />
                        <asp:Button Text="Cập nhật thông tin" ID="btnUpdate" runat="server" Visible="false"
                            CssClass="btnedit" />
                        <asp:Button Text="Hủy thao tác" ID="btnCancel" runat="server" Visible="false" CssClass="btnedit" />
                        <asp:Label ID="lbred" runat="server" Visible="false" CssClass="red" />
                        <asp:Label ID="lbMaNguoiDung" runat="server" Visible="false" /><br />
                        <hr />
                        <table class="infor">
                            <tr>
                                <td>
                                    Họ tên:
                                </td>
                                <td>
                                    <asp:TextBox ID="lbHoTen" runat="server" Enabled="false" CssClass="txttitle" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Chức vụ:
                                </td>
                                <td>
                                    <asp:TextBox ID="lbChucVu" runat="server" Enabled="false" CssClass="txttitle" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Địa chỉ:
                                </td>
                                <td>
                                    <asp:TextBox ID="lbDiaChi" runat="server" Enabled="false" CssClass="txttitle" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Ngày sinh:
                                </td>
                                <td>
                                    <asp:TextBox ID="lbNgaySinh" runat="server" Enabled="false" CssClass="txttitle" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Số điện thoại:
                                </td>
                                <td>
                                    <asp:TextBox ID="lbSDT" runat="server" Enabled="false" CssClass="txttitle" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Ngày cập nhật thông tin:
                                </td>
                                <td>
                                    <asp:TextBox ID="lbNgayCapNhat" runat="server" Enabled="false" CssClass="txttitle" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <div class="clearfix">
        </div>
    </div>
</asp:Content>
