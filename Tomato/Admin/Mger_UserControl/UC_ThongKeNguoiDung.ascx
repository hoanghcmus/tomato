<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_ThongKeNguoiDung.ascx.cs"
    Inherits="Admin_Mger_UserControl_UC_ThongKeNguoiDung" %>
<div class="block span6">
    <a href="#page-cart" class="block-heading" data-toggle="collapse">THỐNG KÊ NGƯỜI DÙNG</a>
    <div id="page-cart" class="block-body collapse in">
        <table class="list">
            <thead>
                <tr>
                    <th class="titlemax">
                        Nội dung
                    </th>
                    <th class="small">
                        Số lượng
                    </th>
                </tr>
            </thead>
            <tr class="eventop">
                <td class="titlemax">
                    Tổng số người dùng trong hệ thống
                </td>
                <td class="link">
                    <asp:Label ID="lbSoNguoiDung" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr class="evenbottom">
                <td class="titlemax">
                    Tổng người dùng thuộc quyền 'Quản Trị Hệ Thống'
                </td>
                <td class="link">
                    <asp:Label ID="lbQuanTri" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr class="eventop">
                <td class="titlemax">
                    Tổng người dùng thuộc quyền 'Quản Lý Thành Phần'
                </td>
                <td class="link">
                    <asp:Label ID="lbThanhPhan" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr class="evenbottom">
                <td class="titlemax">
                    Tổng người dùng thuộc quyền 'Quản Lý Người Dùng'
                </td>
                <td class="link">
                    <asp:Label ID="lbNguoiDung" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr class="eventop">
                <td class="titlemax">
                    Tổng người dùng thuộc quyền 'Quản Lý Thông Tin'
                </td>
                <td class="link">
                    <asp:Label ID="lbThongTin" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</div>
