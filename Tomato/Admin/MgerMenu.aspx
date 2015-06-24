<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="MgerMenu.aspx.cs" Inherits="Admin_MgerMenu" %>

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
            <li class="active">Quản lý menu<span class="divider">>></span></li>
        </ul>
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="content_right">
                    <div class="toolbar">
                        <div class="titlePhoto">
                            <a href="EditMenu.aspx" class="linkAdd">Thêm menu</a>
                        </div>
                        <hr />
                        <asp:DropDownList runat="server" ID="ddlLoadLoaimodule" AutoPostBack="true" AppendDataBoundItems="true"
                            OnSelectedIndexChanged="ddlLoadLoaimodule_SelectedIndexChanged" CssClass="drl">
                            <asp:ListItem>-- Chọn loại module -- </asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList runat="server" ID="ddlLoadLoaiMenu" AutoPostBack="true" AppendDataBoundItems="true"
                            OnSelectedIndexChanged="ddlLoadLoaiMenu_SelectedIndexChanged" CssClass="drl">
                            <asp:ListItem>-- Chọn loại menu -- </asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button Text="Xóa thể loại đã chọn" runat="server" ID="btnDelete" CssClass="multidelete" />
                        <input type="button" value="Làm mới" class="btnedit" onclick="location.href='MgerMenu.aspx'" />
                    </div>
                    <div class="block">
                        <p class="block-heading">
                            Danh sách thể loại của website</p>
                        <table class="list">
                            <thead>
                                <tr>
                                    <th class="cid">
                                        <input type="checkbox" id="chkAll" />
                                    </th>
                                    <th class="id">
                                        ID
                                    </th>
                                    <th class="titlemin">
                                        Tiêu đề
                                    </th>
                                    <th class="titlemin">
                                        Loại menu
                                    </th>
                                    <th class="titlemin">
                                        Loại Module
                                    </th>
                                    <th class="titlemin">
                                        Hiển thị Footer
                                    </th>
                                    <th class="title3">
                                        Vị trí
                                    </th>
                                    <th class="small">
                                        Sửa
                                    </th>
                                </tr>
                            </thead>
                            <asp:Repeater runat="server" ID="repProd">
                                <AlternatingItemTemplate>
                                    <tr class="eventop">
                                        <td>
                                            <%#ShowCategory(Container.DataItem,"ID") %>
                                        </td>
                                        <td class="id">
                                            <%#Eval("ID")%>
                                        </td>
                                        <td class="titlemin">
                                            <asp:TextBox runat="server" Enabled="false" ID="txtfrmTieuDe" Text='<%#Eval("TieuDe_Vn")%>'
                                                CssClass="txtsmall" />
                                            <asp:HiddenField ID="hdnTieuDe" runat="server" Value='<%# Eval("ID")%>' />
                                        </td>
                                        <td class="titlemin">
                                            <%#Eval("TenLoaiMenu")%>
                                        </td>
                                        <td class="titlemin">
                                            <%#Eval("TenLoaiModule")%>
                                        </td>
                                        <td class="titlemin">
                                            <asp:LinkButton ID="lnkFooter" runat="server" CommandArgument='<%#Eval("ID")+"_"+Eval("Footer") %>'
                                                Text='<%#Eval("Footer")%>' CommandName="UpdateFooter" class='lnk'></asp:LinkButton>
                                        </td>
                                        <td class="title3">
                                            <asp:TextBox runat="server" Enabled="false" ID="txtfrmViTri" Text='<%#Eval("ViTri")%>'
                                                CssClass="txtnumbermin" />
                                        </td>
                                        <td class="small">
                                            <a href='EditMenu.aspx?ID=<%#Eval("ID").ToString()%>' class='lnk'><i class="icon-pencil">
                                            </i></a>
                                        </td>
                                    </tr>
                                </AlternatingItemTemplate>
                                <ItemTemplate>
                                    <tr class="evenbottom">
                                        <td>
                                            <%#ShowCategory(Container.DataItem,"ID") %>
                                        </td>
                                        <td class="id">
                                            <%#Eval("ID")%>
                                        </td>
                                        <td class="titlemin">
                                            <asp:TextBox runat="server" Enabled="false" ID="txtfrmTieuDe" Text='<%#Eval("TieuDe_Vn")%>'
                                                CssClass="txtsmall" />
                                            <asp:HiddenField ID="hdnTieuDe" runat="server" Value='<%# Eval("ID")%>' />
                                        </td>
                                        <td class="titlemin">
                                            <%#Eval("TenLoaiMenu")%>
                                        </td>
                                        <td class="titlemin">
                                            <%#Eval("TenLoaiModule")%>
                                        </td>
                                        <td class="titlemin">
                                            <asp:LinkButton ID="lnkFooter" runat="server" CommandArgument='<%#Eval("ID")+"_"+Eval("Footer") %>'
                                                Text='<%#Eval("Footer")%>' CommandName="UpdateFooter" class='lnk'></asp:LinkButton>
                                        </td>
                                        <td class="title3">
                                            <asp:TextBox runat="server" Enabled="false" ID="txtfrmViTri" Text='<%#Eval("ViTri")%>'
                                                CssClass="txtnumbermin" />
                                        </td>
                                        <td class="small">
                                            <a href='EditMenu.aspx?ID=<%#Eval("ID").ToString()%>' class='lnk'><i class="icon-pencil">
                                            </i></a>
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
