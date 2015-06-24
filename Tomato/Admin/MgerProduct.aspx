<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="MgerProduct.aspx.cs" Inherits="Admin_MgerProduct" %>

<%@ Register Src="Mger_UserControl/UC_PhanTrang.ascx" TagName="UC_PhanTrang" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content">
        <div class="header">
            <h1 class="page-title">
                <asp:Label ID="Label1" runat="server" Text="Không có trạng thái món ăn" /></h1>
        </div>
        <ul class="breadcrumb">
            <li><a href="Admin.aspx">Trang chủ</a> <span class="divider">>></span></li>
            <li class="active">Quản lý món ăn<span class="divider">>></span></li>
            <li class="active">Danh sách món ăn</li>
        </ul>
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="content_right">
                    <div class="toolbar">
                        <strong>Lọc theo thể loại menu :</strong><br />
                        <asp:DropDownList runat="server" ID="ddlTheLoai" AutoPostBack="true" AppendDataBoundItems="true"
                            OnSelectedIndexChanged="ddlTheLoai_SelectedIndexChanged" CssClass="drl">
                            <asp:ListItem>-- Chọn xem theo thể loại -- </asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <hr />
                    <div class="content_mid">
                        <input type="button" value="Thêm món ăn" class="btnedit" onclick="location.href = 'EditProduct.aspx'" />
                        <asp:Button Text="Xóa món ăn" runat="server" ID="btnDelete" CssClass="multidelete" />
                        |
                        <asp:TextBox ID="txtTimKiem" runat="server" CssClass="txtsreach" />
                        <asp:Button Text="   Tìm" runat="server" ID="btnTimKiem" CssClass="btnsreach" />
                        <input type="button" value="Làm mới" class="btnedit" onclick="location.href = 'MgerProduct.aspx'" />
                        <div class="block">
                            <p class="block-heading">
                                Danh sách món ăn
                            </p>
                            <table class="list">
                                <thead>
                                    <tr>
                                        <th class="cid">
                                            <input type="checkbox" id="chkAll" />
                                        </th>
                                        <th class="img">Ảnh
                                        </th>
                                        <th class="title300">Tên món ăn (Tiếng việt)
                                        </th>
                                        <th class="title300">Tên món ăn (EngLish)
                                        </th>
                                        <th class="title300">Tên món ăn (Russia)
                                        </th>
                                        <th class="smallmax">Giá
                                        </th>
                                        <th class="idmax">ID
                                        </th>
                                        <th class="idmax">Sửa
                                        </th>
                                    </tr>
                                </thead>
                                <asp:Repeater runat="server" ID="repProd">
                                    <AlternatingItemTemplate>
                                        <tr class="eventop">
                                            <td>
                                                <input type="checkbox" name='cid' value='<%#Eval("ID") %>' />
                                            </td>
                                            <td align="center">
                                                <asp:Image ID="Image1" runat="server" Height="80px" Width="90px" ImageUrl='<%#Eval("AnhDaiDien") %>' />
                                            </td>
                                            <td class="title300">
                                                <%#Eval("TenMon_Vn")%>
                                            </td>
                                            <td class="title300">
                                                <%#Eval("TenMon_En")%>
                                            </td>
                                            <td class="title300">
                                                <%#Eval("TenMon_Ru")%>
                                            </td>
                                            <td class="smallmax">
                                                <%#Eval("Gia", "{0:0,0}")%>
                                            </td>
                                            <td class="idmax">
                                                <%#Eval("ID")%>
                                            </td>
                                            <td class="idmax">
                                                <a href='<%# DataAccess.Connect.Link.EditProduct(Eval("ID").ToString()) %>' class='lnk'>
                                                    <i class="icon-pencil"></i></a>
                                            </td>
                                        </tr>
                                    </AlternatingItemTemplate>
                                    <ItemTemplate>
                                        <tr class="evenbottom">
                                            <td>
                                                <input type="checkbox" name='cid' value='<%#Eval("ID") %>' />
                                            </td>
                                            <td align="center">
                                                <asp:Image ID="Image1" runat="server" Height="80px" Width="90px" ImageUrl='<%#Eval("AnhDaiDien") %>' />
                                            </td>
                                            <td class="title300">
                                                <%#Eval("TenMon_Vn")%>
                                            </td>
                                            <td class="title300">
                                                <%#Eval("TenMon_En")%>
                                            </td>
                                            <td class="title300">
                                                <%#Eval("TenMon_Ru")%>
                                            </td>
                                            <td class="smallmax">
                                                <%#Eval("Gia", "{0:0,0}")%>
                                            </td>
                                            <td class="idmax">
                                                <%#Eval("ID")%>
                                            </td>
                                            <td class="idmax">
                                                <a href='<%# DataAccess.Connect.Link.EditProduct(Eval("ID").ToString()) %>' class='lnk'>
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
