<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="MgerArticle.aspx.cs" Inherits="Admin_MgerArticle" %>

<%@ Register Src="Mger_UserControl/UC_PhanTrang.ascx" TagName="UC_PhanTrang" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content">
        <div class="header">
            <h1 class="page-title">
                <asp:Label ID="Label1" runat="server" Text="Không có trạng thái bài viết" /></h1>
        </div>
        <ul class="breadcrumb">
            <li><a href="Admin.aspx">Trang chủ</a> <span class="divider">>></span></li>
            <li class="active">Quản lý bài viết<span class="divider">>></span></li>
            <li class="active">Danh sách bài viết</li>
        </ul>
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="content_right">
                    <div class="toolbar">
                        <div>
                            <asp:DropDownList runat="server" ID="ddlTheLoai" AutoPostBack="true" AppendDataBoundItems="true"
                                OnSelectedIndexChanged="ddlTheLoai_SelectedIndexChanged" CssClass="drl">
                                <asp:ListItem>-- Chọn xem theo thể loại -- </asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <hr />
                    <div class="content_mid">
                        <input type="button" value="Thêm bài viết" class="btnedit" onclick="location.href='EditArticle.aspx'" />
                        <asp:Button Text="Xóa bài đã chọn" runat="server" ID="btnDelete" CssClass="multidelete" />
                        |&nbsp;<asp:TextBox ID="txtTimKiem" runat="server" CssClass="txtsreach" />
                        <asp:Button Text=" Tìm" runat="server" ID="btnTimKiem" CssClass="btnsreach" />
                        <input type="button" value="Làm mới" class="btnedit" onclick="location.href='MgerArticle.aspx?Status=1'" />
                        <div class="block">
                            <p class="block-heading">
                                Danh sách bài viết</p>
                            <table class="list">
                                <thead>
                                    <tr>
                                        <th class="id">
                                            <input type="checkbox" id="chkAll" />
                                        </th>
                                        <th class="img">
                                            Hình Ảnh
                                        </th>
                                        <th class="titlemax">
                                            Tiêu đề(Tiếng việt)
                                        </th>
                                        <th class="smallmax">
                                            Ngày tạo
                                        </th>
                                        <th class="smallmax">
                                            Người tạo
                                        </th>
                                        <th class="id">
                                            ID
                                        </th>
                                        <th class="idmax">
                                            Sửa
                                        </th>
                                    </tr>
                                </thead>
                                <asp:Repeater runat="server" ID="repProd">
                                    <AlternatingItemTemplate>
                                        <tr class="eventop">
                                            <td class="id">
                                                <input type="checkbox" name='cid' value='<%#Eval("ID") %>' />
                                            </td>
                                            <td align="center">
                                                <asp:Image runat="server" ID="img" ImageUrl='<%# DataAccess.Connect.Link.Toimages(Eval("HinhAnh").ToString()) %>'
                                                    Height="80" Width="90" />
                                            </td>
                                            <td class="titlemax" valign="top">
                                                <%#Eval("TieuDe_Vn")%>
                                            </td>
                                            <td class="smallmax">
                                                <%#Eval("NgayTao") %>
                                            </td>
                                            <td class="smallmax">
                                                <%#Eval("NguoiTao") %>
                                            </td>
                                            <td class="id">
                                                <%#Eval("ID")%>
                                            </td>
                                            <td class="idmax">
                                                <a href='<%# DataAccess.Connect.Link.EditArticle(Eval("ID").ToString()) %>' class='lnk'>
                                                    <i class="icon-pencil"></i></a>
                                            </td>
                                        </tr>
                                    </AlternatingItemTemplate>
                                    <ItemTemplate>
                                        <tr class="evenbottom">
                                            <td class="id">
                                                <input type="checkbox" name='cid' value='<%#Eval("ID") %>' />
                                            </td>
                                            <td align="center">
                                                <asp:Image runat="server" ID="img" ImageUrl='<%# DataAccess.Connect.Link.Toimages(Eval("HinhAnh").ToString()) %>'
                                                    Height="80" Width="90" />
                                            </td>
                                            <td class="titlemax" valign="top">
                                                <%#Eval("TieuDe_Vn")%>
                                            </td>
                                            <td class="smallmax">
                                                <%#Eval("NgayTao") %>
                                            </td>
                                            <td class="smallmax">
                                                <%#Eval("NguoiTao") %>
                                            </td>
                                            <td class="id">
                                                <%#Eval("ID")%>
                                            </td>
                                            <td class="idmax">
                                                <a href='<%# DataAccess.Connect.Link.EditArticle(Eval("ID").ToString()) %>' class='lnk'>
                                                    <i class="icon-pencil"></i></a>
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
        </div>
        <div class="clearfix">
        </div>
    </div>
</asp:Content>
