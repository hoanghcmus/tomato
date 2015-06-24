<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="MgerUser.aspx.cs" Inherits="Admin_MgerUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content">
        <div class="header">
            <h1 class="page-title">
                <asp:Label ID="Label1" runat="server" Text="Quản lý người dùng" /></h1>
        </div>
        <ul class="breadcrumb">
            <li><a href="Admin.aspx">Trang chủ</a> <span class="divider">>></span></li>
            <li class="active">Quản lý người dùng<span class="divider">>></span></li>
            <li class="active">Quản lý người dùng</li>
        </ul>
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="content_right">
                    <a href="#" class="morefbnd">Thêm người dùng mới</a>
                    <asp:Label ID="lbrs" runat="server" Text="" Visible="false" CssClass="red" />
                    <br />
                    <div id="feedback">
                        <div class="block">
                            <p class="block-heading">
                                Thông tin thêm người dùng
                            </p>
                            <div class="toolbar">
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <table class="list">
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Label ID="lbThongBao" runat="server" Text="Label" Visible="false" CssClass="titletb"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Black">*Nhập vào thông tin đăng nhập:</asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Label ID="lbtitle" runat="server" Text="Label" Visible="false" CssClass="titletb"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Tên đăng nhập:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNhapTenDangNhap" runat="server" CssClass="txtsmall" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Mật khẩu:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNhapMatKhau" runat="server" TextMode="Password" CssClass="txtsmall" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Nhập lại mật khẩu:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNhapLaiMatKhau" runat="server" TextMode="Password" CssClass="txtsmall"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="Black">*Nhập thông tin về người dùng vào bên dưới:</asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Label ID="lbtitle2" runat="server" Text="Label" Visible="false" CssClass="titletb"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Họ và tên:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtHoTen" runat="server" CssClass="txtsmall" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Chức vụ:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtChucVu" runat="server" CssClass="txtsmall" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Ngày sinh:
                                                </td>
                                                <td>
                                                    <asp:DropDownList runat="server" ID="ddlNgay" AppendDataBoundItems="true" CssClass="drlDate">
                                                        <asp:ListItem>-Chọn ngày-</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:DropDownList runat="server" ID="ddlThang" AppendDataBoundItems="true" CssClass="drlDate">
                                                        <asp:ListItem>-Chọn tháng-</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:DropDownList runat="server" ID="ddlNam" AppendDataBoundItems="true" CssClass="drlDate">
                                                        <asp:ListItem>-Chọn năm-</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Địa chỉ:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtDiaChi" runat="server" CssClass="txtsmall" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Số điện thoại:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtSDT" runat="server" CssClass="txtsmall" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="td">
                                                </td>
                                                <td colspan="2">
                                                    <asp:Button ID="btnLuu" runat="server" Text="Lưu" CssClass="btnedit" />
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                    <asp:Button Text="Xóa mục đã chọn" runat="server" ID="btnDelete" CssClass="multidelete" />
                    <input type="button" value="Làm mới" class="btnedit" onclick="location.href='MgerUser.aspx'" />
                    <div class="block">
                        <p class="block-heading">
                            Danh sách người dùng
                        </p>
                        <table class="list">
                            <thead>
                                <tr>
                                    <th class="cid">
                                        <input type="checkbox" id="chkAll" />
                                    </th>
                                    <th class="id">
                                        ID
                                    </th>
                                    <th class="title150">
                                        Tên đăng nhập
                                    </th>
                                    <th class="title150">
                                        Chức vụ
                                    </th>
                                    <th class="titlemax">
                                        Địa chỉ
                                    </th>
                                    <th class="title100">
                                        Ngày sinh
                                    </th>
                                    <th class="title100">
                                        SĐT
                                    </th>
                                </tr>
                            </thead>
                            <asp:Repeater runat="server" ID="repProd">
                                <AlternatingItemTemplate>
                                    <tr class="eventop">
                                        <td>
                                            <input type="checkbox" name='cid' value='<%#Eval("IDNguoiDung") %>' />
                                        </td>
                                        <td class="id">
                                            <%#Eval("IDNguoiDung")%>
                                        </td>
                                        <td class="title150">
                                            <%#Eval("TenDangNhap")%>
                                        </td>
                                        <td class="title150">
                                            <%#Eval("ChucVu")%>
                                        </td>
                                        <td class="titlemax">
                                            <%#Eval("DiaChi")%>
                                        </td>
                                        <td class="title100">
                                            <%#Eval("NgaySinh")%>
                                        </td>
                                        <td class="title100">
                                            <%#Eval("SoDT")%>
                                        </td>
                                    </tr>
                                </AlternatingItemTemplate>
                                <ItemTemplate>
                                    <tr class="evenbottom">
                                        <td>
                                            <input type="checkbox" name='cid' value='<%#Eval("IDNguoiDung") %>' />
                                        </td>
                                        <td class="id">
                                            <%#Eval("IDNguoiDung")%>
                                        </td>
                                        <td class="title150">
                                            <%#Eval("TenDangNhap")%>
                                        </td>
                                        <td class="title150">
                                            <%#Eval("ChucVu")%>
                                        </td>
                                        <td class="titlemax">
                                            <%#Eval("DiaChi")%>
                                        </td>
                                        <td class="title100">
                                            <%#Eval("NgaySinh")%>
                                        </td>
                                        <td class="title100">
                                            <%#Eval("SoDT")%>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <div class="clearfix">
        </div>
    </div>
</asp:Content>
