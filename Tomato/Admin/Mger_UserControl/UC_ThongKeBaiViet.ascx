<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_ThongKeBaiViet.ascx.cs" Inherits="Admin_Mger_UserControl_UC_ThongKeBaiViet" %>
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
            Tổng số bài viết trong website
        </td>
        <td class="link">
            <asp:Label ID="lbTongBaiViet" runat="server" Text="0"></asp:Label>
        </td>
    </tr>
    <tr class="evenbottom">
        <td class="titlemax">
            Tổng số sản phẩm trong hệ thống
        </td>
        <td class="link">
            <asp:Label ID="lbnotice" runat="server" Text="0"></asp:Label>
        </td>
    </tr>
    <tr class="eventop">
        <td class="titlemax">
            Tổng số album ảnh trong website
        </td>
        <td class="link">
            <asp:Label ID="lbalbum" runat="server" Text="0"></asp:Label>
        </td>
    </tr>
        <tr class="evenbottom">
        <td class="titlemax">
            Tổng liên hệ trong website
        </td>
        <td class="link">
            <asp:Label ID="lbletter" runat="server" Text="0"></asp:Label>
        </td>
    </tr>
</table>