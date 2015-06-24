<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="MgerDatPhong.aspx.cs" Inherits="Admin_MgerDatPhong" %>

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
            <li class="active">Quản lý phòng<span class="divider">>></span></li>
            <li class="active">Đặt phòng trực tuyến<span class="divider">>></span></li>
        </ul>
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="content_right">
                    <div class="toolbar">
                        Hiển thị tất cả các đặt phòng giới hạn theo ngày:<asp:Label ID="lblStatus" runat="server"
                            CssClass="red" /><br />
                        <asp:TextBox runat="server" ID="txtStartDate" CssClass="txtsmall" />
                        đến
                        <asp:TextBox runat="server" ID="txtEndDate" CssClass="txtsmall" />
                        <asp:Button Text="Hiển thị" runat="server" ID="btnGetByDate" CssClass="btnsmall" />
                        <asp:RangeValidator ID="rangeStartDate" ErrorMessage="Ngày bắt đầu không hợp lệ"
                            ControlToValidate="txtStartDate" Display="None" MinimumValue="1/1/2014" MaximumValue="1/1/2020"
                            runat="server" Type="Date" />
                        <asp:RangeValidator ID="rangeEndDate" ErrorMessage="Ngày kết thúc không hợp lệ" ControlToValidate="txtEndDate"
                            Display="None" MinimumValue="1/1/2014" MaximumValue="1/1/2020" runat="server"
                            Type="Date" />
                        <asp:CompareValidator ID="cmpDate" ErrorMessage="Ngày bắt đầu phải nhỏ hơn ngày kết thúc!"
                            Display="None" ControlToValidate="txtStartDate" ControlToCompare="txtEndDate"
                            Operator="LessThan" Type="Date" runat="server" />
                        <asp:ValidationSummary ID="validationSummary" ShowMessageBox="true" ShowSummary="false"
                            runat="server" HeaderText="Lỗi! ngày không hợp lệ:" CssClass="red" />
                        <hr />
                        <asp:DropDownList runat="server" ID="ddlCategory" AutoPostBack="true" AppendDataBoundItems="true"
                            OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" CssClass="drl">
                            <asp:ListItem>Chọn xem quản lý đặt phòng</asp:ListItem>
                            <asp:ListItem Value="0">Đặt phòng đợi duyệt</asp:ListItem>
                            <asp:ListItem Value="1">Đặt phòng đã duyệt</asp:ListItem>
                            <asp:ListItem Value="2">Đặt phòng đã hủy</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button Text="Xóa đặt phòng đã chọn" runat="server" ID="btnDelete" CssClass="multidelete" />
                        <input type="button" value="Làm mới" class="btnedit" onclick="location.href = 'MgerDatPhong.aspx'" />
                    </div>
                    <div class="block">
                        <p class="block-heading">
                            Danh sách đặt phòng khách hàng
                        </p>
                        <div class="helpDatHang">
                            Chú ý: <span class="red">Chữ đỏ: Đặt phòng chưa duyệt </span><span>Chữ thường: Đặt phòng
                                đã duyệt</span><span class="textoverline">Chữ gạch: Đặt phòng đã hủy</span>
                        </div>
                        <table class="list">
                            <thead>
                                <tr>
                                    <th class="cid">
                                        <input type="checkbox" id="chkAll" />
                                    </th>
                                    <th class="small">ID
                                    </th>
                                    <th class="title300">Họ tên khách hàng
                                    </th>
                                    <th class="title300">Tên phòng
                                    </th>
                                    <th class="title300">Ngày đến
                                    </th>
                                    <th class="title300">Ngày đi
                                    </th>
                                    <th class="smallmax">SĐT
                                    </th>
                                    <th class="smallmax">Giá phòng
                                    </th>
                                    <th class="smallmax">Ngày gửi
                                    </th>
                                    <th class="smallmax">Duyệt
                                    </th>
                                </tr>
                            </thead>
                            <asp:Repeater runat="server" ID="repProd">
                                <AlternatingItemTemplate>
                                    <tr class="eventop">
                                        <td>
                                            <input type="checkbox" name='cid' value='<%#Eval("ID") %>' />
                                        </td>
                                        <td class="small">
                                            <%#Eval("ID")%>
                                        </td>
                                        <td class="title300">
                                            <%#ShowDatTour(Container.DataItem, "HoTen")%>
                                        </td>
                                        <td class="title300">
                                            <%#ShowDatTour(Container.DataItem, "TenTour")%>
                                        </td>

                                        <td class="title300">
                                            <%#ShowDatTour(Container.DataItem, "NgayDen")%>
                                        </td>
                                        <td class="title300">
                                            <%#ShowDatTour(Container.DataItem, "NgayDi")%>
                                        </td>

                                        <td class="smallmax">
                                            <%#Eval("SDT") %>
                                        </td>
                                        <td class="smallmax">
                                            <%#Eval("Price")%>
                                        </td>
                                        <td class="smallmax">
                                            <%#ShowDatTour(Container.DataItem, "NgayGui")%>
                                        </td>
                                        <td class="smallmax" style="text-align: center;">
                                            <a href="javascript:void(0)" target="_blank" class="btnlinkaddlist" onclick='window.open("MgerXuLyDatTour.aspx?id=<%#Eval("ID") %>","Upload","height=630,width=640,");return false;'>
                                                <i class="icon-pencil"></i></a>
                                        </td>
                                    </tr>
                                </AlternatingItemTemplate>
                                <ItemTemplate>
                                    <tr class="evenbottom">
                                        <td>
                                            <input type="checkbox" name='cid' value='<%#Eval("ID") %>' />
                                        </td>
                                        <td class="small">
                                            <%#Eval("ID")%>
                                        </td>
                                        <td class="title300">
                                            <%#ShowDatTour(Container.DataItem, "HoTen")%>
                                        </td>
                                        <td class="title300">
                                            <%#ShowDatTour(Container.DataItem, "TenTour")%>
                                        </td>

                                        <td class="title300">
                                            <%#ShowDatTour(Container.DataItem, "NgayDen")%>
                                        </td>
                                        <td class="title300">
                                            <%#ShowDatTour(Container.DataItem, "NgayDi")%>
                                        </td>

                                        <td class="smallmax">
                                            <%#Eval("SDT") %>
                                        </td>
                                        <td class="smallmax">
                                            <%#Eval("Price")%>
                                        </td>
                                        <td class="smallmax">
                                            <%#ShowDatTour(Container.DataItem, "NgayGui")%>
                                        </td>
                                        <td class="smallmax" style="text-align: center;">
                                            <a href="javascript:void(0)" target="_blank" class="btnlinkaddlist" onclick='window.open("MgerXuLyDatTour.aspx?id=<%#Eval("ID") %>","Upload","height=630,width=640,");return false;'>
                                                <i class="icon-pencil"></i></a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                    <uc1:uc_phantrang id="PagerBottom" runat="server" />
                    <br />
                </div>
            </div>
        </div>
        <div class="clearfix">
        </div>
    </div>
</asp:Content>

