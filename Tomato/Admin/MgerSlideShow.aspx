<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="MgerSlideShow.aspx.cs" Inherits="Admin_MgerSlideShow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content">
        <div class="header">
            <h1 class="page-title">
                <asp:Label ID="Label1" runat="server" Text="Không tìm thấy thể loại nào!" /></h1>
        </div>
        <ul class="breadcrumb">
            <li><a href="Admin.aspx">Trang chủ</a> <span class="divider">>></span></li>
            <li class="active">Quản lý hình ảnh hiển thị trang chủ</li>
        </ul>
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="content_right">
                    <div class="toolbar">
                        <div class="titlePhoto">
                            <a href="EditSlideShow.aspx" class="linkAdd">Thêm mới</a></div>
                        <hr />
                        <input type="button" value="Làm mới" class="btnedit" onclick="location.href='MgerSlideShow.aspx'" />
                    </div>
                    <div class="block">
                        <p class="block-heading">
                            Danh sách hình ảnh chuyển động của website</p>
                        <table class="list">
                            <thead>
                                <tr>
                                    <th class="title1">
                                        ID
                                    </th>
                                    <th class="img">
                                        Hình Ảnh
                                    </th>
                                    <th class="titlemax">
                                        Tiêu đề 
                                    </th>
                                    <th class="titlemin">
                                        Hiển thị
                                    </th>
                                    <th class="title3">
                                        Vị trí
                                    </th>
                                    <th class="title3">
                                        Xử lý
                                    </th>
                                </tr>
                            </thead>
                            <asp:Repeater runat="server" ID="repProd">
                                <AlternatingItemTemplate>
                                    <tr class="eventop">
                                        <td class="cid">
                                            <%#Eval("ID")%>
                                        </td>
                                        <td class="img" align="center">
                                            <asp:Image runat="server" ID="img" ImageUrl='<%# DataAccess.Connect.Link.Toimages(Eval("HinhAnh").ToString()) %>'
                                                Height="80" Width="90" />
                                        </td>
                                        <td class="titlemax">
                                            <%#Eval("TieuDe_Vn")%>
                                        </td>
                                        <td class="titlemin">
                                            <%#ShowContact(Container.DataItem, "HienThi")%>
                                        </td>
                                        <td class="title3">
                                            <%#Eval("ViTri")%>
                                        </td>
                                        <td class="title3">
                                            <a href='EditSlideShow.aspx?ID=<%#Eval("ID").ToString()%>' class='lnk'><i class="icon-pencil">
                                            </i></a>
                                            <asp:Button Text="Xóa" runat="server" ID="btnDelete" CommandArgument='<%#Eval("ID")%>'
                                                CommandName="Delete" CssClass="icon-remove" />
                                        </td>
                                    </tr>
                                </AlternatingItemTemplate>
                                <ItemTemplate>
                                    <tr class="evenbottom">
                                        <td class="cid">
                                            <%#Eval("ID")%>
                                        </td>
                                        <td class="img" align="center">
                                            <asp:Image runat="server" ID="img" ImageUrl='<%# DataAccess.Connect.Link.Toimages(Eval("HinhAnh").ToString()) %>'
                                                Height="80" Width="90" />
                                        </td>
                                        <td class="titlemax">
                                            <%#Eval("TieuDe_Vn")%>
                                        </td>
                                        <td class="titlemin">
                                            <%#ShowContact(Container.DataItem, "HienThi")%>
                                        </td>
                                        <td class="title3">
                                            <%#Eval("ViTri")%>
                                        </td>
                                        <td class="title3">
                                            <a href='EditSlideShow.aspx?ID=<%#Eval("ID").ToString()%>' class='lnk'><i class="icon-pencil">
                                            </i></a>
                                            <asp:Button Text="Xóa" runat="server" ID="btnDelete" CommandArgument='<%#Eval("ID")%>'
                                                CommandName="Delete" CssClass="icon-remove" />
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
