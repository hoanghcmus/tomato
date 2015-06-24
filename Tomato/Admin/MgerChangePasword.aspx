<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="MgerChangePasword.aspx.cs" Inherits="Admin_MgerChangePasword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content">
        <div class="header">
            <h1 class="page-title">
                <asp:Label ID="Label1" runat="server" Text="Thay đổi mật khẩu" /></h1>
        </div>
        <ul class="breadcrumb">
            <li><a href="Admin.aspx">Trang chủ</a> <span class="divider">>></span></li>
            <li class="active">Đổi mật khẩu</li>
        </ul>
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="block">
                    <p class="block-heading">
                        Đổi mật khẩu</p>
                    <asp:Button Text="Đổi mật khẩu" ID="btnUpdataMatKhau" runat="server" CssClass="btnedit" />
                    <asp:Label ID="lbMaNguoiDung" runat="server" Visible="false" />
                    <hr />
                    <table class="infor">
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lbtbmk" runat="server" Text="Nhập thông tin vào bên dưới" Visible="false"
                                    CssClass="red" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Nhập mật khẩu hiện tại:
                            </td>
                            <td>
                                <asp:TextBox ID="txtMatKhauHienTai" TextMode="Password" runat="server" CssClass="txttitlemin" />
                                <asp:Label ID="Label2" runat="server" Text="*" Visible="false" CssClass="red" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Nhập mật khẩu mới:
                            </td>
                            <td>
                                <asp:TextBox ID="txtMatKhauMoi" TextMode="Password" runat="server" CssClass="txttitlemin" />
                                <asp:Label ID="Label3" runat="server" Text="*" Visible="false" CssClass="red" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Nhập lại mật khẩu mới:
                            </td>
                            <td>
                                <asp:TextBox ID="txtNhapLai" TextMode="Password" runat="server" CssClass="txttitlemin" />
                                <asp:Label ID="Label4" runat="server" Text="*" Visible="false" CssClass="red" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="clearfix">
        </div>
    </div>
</asp:Content>

