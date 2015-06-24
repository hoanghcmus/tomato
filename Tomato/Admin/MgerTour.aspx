<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="MgerTour.aspx.cs" Inherits="Admin_MgerTour" %>

<%@ Register Src="Mger_UserControl/UC_PhanTrang.ascx" TagName="UC_PhanTrang" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content">
        <div class="header">
            <h1 class="page-title">
                <asp:Label ID="Label1" runat="server" Text="Danh sách tour" /></h1>
        </div>
        <ul class="breadcrumb">
            <li><a href="Admin.aspx">Trang chủ</a> <span class="divider">>></span></li>
            <li class="active">Quản lý Tour<span class="divider">>></span></li>
            <li class="active">Danh sách tour</li>
        </ul>
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="content_right">
                    <div class="toolbar">
                        <div>
                            <div class="titles">
                                <strong>Lọc theo thể loại menu :</strong></div>
                            <asp:DropDownList runat="server" ID="ddlTheLoai" AutoPostBack="true" AppendDataBoundItems="true"
                                OnSelectedIndexChanged="ddlTheLoai_SelectedIndexChanged" CssClass="drl">
                                <asp:ListItem>-- Chọn xem theo thể loại -- </asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <hr />
                    <div class="content_mid">
                        <input type="button" value="Thêm tour mới" class="btnedit" onclick="location.href='EditTour.aspx'" />
                        <asp:Button Text="Xóa tour đã chọn" runat="server" ID="btnDelete" CssClass="multidelete" />
                        |&nbsp;<asp:TextBox ID="txtTimKiem" runat="server" CssClass="txtsreach" />
                        <asp:Button Text=" Tìm" runat="server" ID="btnTimKiem" CssClass="btnsreach" />
                        <input type="button" value="Làm mới" class="btnedit" onclick="location.href='MgerTour.aspx'" />
                        <div class="block">
                            <p class="block-heading">
                                Danh sách tour</p>
                            <table class="list">
                                <thead>
                                    <tr>
                                        <th class="cid">
                                            <input type="checkbox" id="chkAll" />
                                        </th>
                                        <th class="img">
                                            Hình Ảnh
                                        </th>
                                        <th class="title">
                                            Tên Tour
                                        </th>
                                        <th class="title">
                                            Lịch trình
                                        </th>
                                        <th class="small">
                                            Giá tour
                                        </th>
                                        <th class="small">
                                            Trang chủ
                                        </th>
                                        <th class="id">
                                            ID
                                        </th>
                                        <th class="small" style="text-align:center;">
                                            Sửa
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
                                                <asp:Image runat="server" ID="img" ImageUrl='<%# DataAccess.Connect.Link.Toimages(Eval("HinhAnh").ToString()) %>'
                                                    Height="80" Width="90" />
                                            </td>
                                            <td class="link">
                                                <%#Eval("TenTour")%>
                                            </td>
                                            <td class="link">
                                                <%#Eval("LichTrinh")%>
                                            </td>
                                            <td class="small">
                                                <%#ShowPrice(Container.DataItem, "GiaTour")%>
                                            </td>
                                            <td class="small">
                                                <asp:LinkButton ID="lnkTrangChu" runat="server" CommandArgument='<%#Eval("ID")+"_"+Eval("TrangChu") %>'
                                                    Text='<%#Eval("TrangChu")%>' CommandName="UpdateTrangChu" class='lnk'></asp:LinkButton>
                                            </td>
                                            <td class="id">
                                                <%#Eval("ID")%>
                                            </td>
                                            <td class="small" style="text-align:center;">
                                                <a href='<%# DataAccess.Connect.Link.EditTour(Eval("ID").ToString()) %>' class='lnk'>
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
                                                <asp:Image runat="server" ID="img" ImageUrl='<%# DataAccess.Connect.Link.Toimages(Eval("HinhAnh").ToString()) %>'
                                                    Height="80" Width="90" />
                                            </td>
                                            <td class="link">
                                                <%#Eval("TenTour")%>
                                            </td>
                                            <td class="link">
                                                <%#Eval("LichTrinh")%>
                                            </td>
                                            <td class="small">
                                                <%#ShowPrice(Container.DataItem, "GiaTour")%>
                                            </td>
                                            <td class="small">
                                                <asp:LinkButton ID="lnkTrangChu" runat="server" CommandArgument='<%#Eval("ID")+"_"+Eval("TrangChu") %>'
                                                    Text='<%#Eval("TrangChu")%>' CommandName="UpdateTrangChu" class='lnk'></asp:LinkButton>
                                            </td>
                                            <td class="id">
                                                <%#Eval("ID")%>
                                            </td>
                                            <td class="small" style="text-align:center;">
                                                <a href='<%# DataAccess.Connect.Link.EditTour(Eval("ID").ToString()) %>' class='lnk'>
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
