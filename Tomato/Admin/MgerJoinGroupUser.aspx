<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="MgerJoinGroupUser.aspx.cs" Inherits="Admin_MgerJoinGroupUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content">
        <div class="header">
            <h1 class="page-title">
                <asp:Label ID="Label1" runat="server" Text="Phân nhóm người dùng" /></h1>
        </div>
        <ul class="breadcrumb">
            <li><a href="Admin.aspx">Trang chủ</a> <span class="divider">>></span></li>
            <li class="active">Quản lý người dùng<span class="divider">>></span></li>
            <li class="active">Phân nhóm người dùng</li>
        </ul>
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="content_right">
                    <div class="toolbar">
                        <a href="#" class="morefbpnnd">Phân nhóm người dùng mới</a><asp:Label ID="lbrs" runat="server"
                            Text="" Visible="false" CssClass="red" />
                        <div id="feedback">
                            <div class="block">
                                <p class="block-heading">
                                    Thêm phân quyền người dùng</p>
                                <div class="toolbar">
                                    <p>
                                        Phân quyền cho người dùng.
                                    </p>
                                    <div class="GuiYkien">
                                        <table class="GuiYkien">
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Label ID="lbtitle" runat="server" Text="Label" Visible="false" CssClass="titletb"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Người dùng:
                                                </td>
                                                <td>
                                                    <asp:DropDownList runat="server" ID="ddlChonNguoiDung" AppendDataBoundItems="true"
                                                        CssClass="drl">
                                                        <asp:ListItem>-- Chọn người dùng -- </asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Nhóm quyền:
                                                </td>
                                                <td>
                                                    <asp:DropDownList runat="server" ID="ddlChonNhomQuyen" AppendDataBoundItems="true"
                                                        CssClass="drl">
                                                        <asp:ListItem>-- Chọn nhóm quyền -- </asp:ListItem>
                                                    </asp:DropDownList>
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
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <asp:Button Text="Xóa mục đã chọn" runat="server" ID="btnDelete" CssClass="multidelete" />
                        <input type="button" value="Làm mới" class="btnedit" onclick="location.href='MgerJoinGroupUser.aspx'" />
                        <asp:DropDownList runat="server" ID="ddlNguoiDung" AutoPostBack="true" AppendDataBoundItems="true"
                            OnSelectedIndexChanged="ddlNguoiDung_SelectedIndexChanged" CssClass="drl">
                            <asp:ListItem>-- Lọc theo người dùng -- </asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList runat="server" ID="ddlNhomQuyen" AutoPostBack="true" AppendDataBoundItems="true"
                            OnSelectedIndexChanged="ddlNhomQuyen_SelectedIndexChanged" CssClass="drl">
                            <asp:ListItem>-- Lọc theo nhóm quyền -- </asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="block">
                        <p class="block-heading">
                            Danh sách phân quyền người dùng</p>
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
                                        Tên quyền
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
                                        <td>
                                            <input type="checkbox" name='cid' value='<%#Eval("IDPhanNhom") %>' />
                                        </td>
                                        <td class="id">
                                            <%#Eval("IDPhanNhom")%>
                                        </td>
                                        <td class="title150">
                                            <%#Eval("TenDangNhap")%>
                                        </td>
                                        <td class="title150">
                                            <%#Eval("TenNhom")%>
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
                                        <td>
                                            <input type="checkbox" name='cid' value='<%#Eval("IDPhanNhom") %>' />
                                        </td>
                                        <td class="id">
                                            <%#Eval("IDPhanNhom")%>
                                        </td>
                                        <td class="title150">
                                            <%#Eval("TenDangNhap")%>
                                        </td>
                                        <td class="title150">
                                            <%#Eval("TenNhom")%>
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
        </div>
        <div class="clearfix">
        </div>
    </div>
</asp:Content>
