<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="MgerContact.aspx.cs" Inherits="Admin_MgerContact" %>

<%@ Register Src="Mger_UserControl/UC_PhanTrang.ascx" TagName="UC_PhanTrang" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content">
        <div class="header">
            <h1 class="page-title">
                <asp:Label ID="Label1" runat="server" Text="Không có thư nào!" /></h1>
        </div>
        <ul class="breadcrumb">
            <li><a href="Admin.aspx">Trang chủ</a> <span class="divider">>></span></li>
            <li class="active">Quản lý thư liên hệ<span class="divider">>></span></li>
        </ul>
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="content_right">
                    <div class="toolbar">
                        <asp:DropDownList runat="server" ID="ddlCategory" AutoPostBack="true" AppendDataBoundItems="true"
                            OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" CssClass="drl">
                            <asp:ListItem>--Chọn xem quản lý hợp thư-- </asp:ListItem>
                            <asp:ListItem Value="0">Danh sách thư đợi duyệt</asp:ListItem>
                            <asp:ListItem Value="1">Danh sách thư đã duyệt</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button Text="Xóa thư đã chọn" runat="server" ID="btnDelete" CssClass="multidelete" />
                        <asp:Button Text="Duyệt thư đã chọn" runat="server" ID="btnDang" CssClass="execuChek"
                            Visible="False" />
                    </div>
                    <div class="block">
                        <p class="block-heading">
                            Danh sách liên hệ từ người dùng</p>
                        <div class="helpDatHang">
                            Chú ý: <span class="red">Chữ đỏ: Liên hệ chưa được duyệt </span><span>Chữ thường: Liên
                                hệ đã được duyệt</span></div>
                        <table class="list">
                            <thead>
                                <tr>
                                    <th class="cid">
                                        <input type="checkbox" id="chkAll" />
                                    </th>
                                    <th class="titlemin">
                                        Họ tên
                                    </th>
                                    <th class="titlemax">
                                        Email
                                    </th>
                                    <th class="titlemin">
                                        Ngày gửi
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
                                            <input type="checkbox" name='cid' value='<%#Eval("ID") %>' />
                                        </td>
                                        <td class="titlemin">
                                            <%#ShowContact(Container.DataItem, "HoTen")%>
                                        </td>
                                        <td class="titlemax">
                                            <%#ShowContact(Container.DataItem, "Email")%>
                                        </td>
                                        <td class="titlemin">
                                            <%#ShowContact(Container.DataItem, "NgayGui")%>
                                        </td>
                                        <td class="id">
                                            <%#ShowContact(Container.DataItem, "ID")%>
                                        </td>
                                    </tr>
                                    <tr class="eventop">
                                        <td colspan="5">
                                            <strong>Địa chỉ</strong> &nbsp;&nbsp;&nbsp;:&nbsp;
                                            <%#Eval("DiaChi")%><br />
                                            <strong>Tiêu đề :&nbsp;</strong>
                                            <%#Eval("TieuDe")%><br />
                                            <strong>Nội dung :&nbsp;</strong>
                                            <%#Eval("NoiDung")%>
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
                                            <input type="checkbox" name='cid' value='<%#Eval("ID") %>' />
                                        </td>
                                        <td class="titlemin">
                                            <%#ShowContact(Container.DataItem, "HoTen")%>
                                        </td>
                                        <td class="titlemax">
                                            <%#ShowContact(Container.DataItem, "Email")%>
                                        </td>
                                        <td class="titlemin">
                                            <%#ShowContact(Container.DataItem, "NgayGui")%>
                                        </td>
                                        <td class="id">
                                            <%#ShowContact(Container.DataItem, "ID")%>
                                        </td>
                                    </tr>
                                    <tr class="evenbottom">
                                        <td colspan="5">
                                            <strong>Địa chỉ</strong> &nbsp;&nbsp;&nbsp;:&nbsp;
                                            <%#Eval("DiaChi")%><br />
                                            <strong>Tiêu đề :&nbsp;</strong>
                                            <%#Eval("TieuDe")%><br />
                                            <strong>Nội dung :&nbsp;</strong>
                                            <%#Eval("NoiDung")%>
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
