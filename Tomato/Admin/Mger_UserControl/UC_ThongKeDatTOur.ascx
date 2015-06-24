<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_ThongKeDatTOur.ascx.cs" Inherits="Admin_Mger_UserControl_UC_ThongKeDatTOur" %>
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
    <tr class="evenbottom">
        <td class="titlemax">
            Tổng số đặt tour đang đợi xử lý
        </td>
        <td class="link">
            <asp:Label ID="lbOrder1" runat="server" Text="0"></asp:Label>
        </td>
    </tr>
    <tr class="evenbottom">
        <td class="titlemax">
            Tổng số đặt tour đã được duyệt
        </td>
        <td class="link">
            <asp:Label ID="lbOrder2" runat="server" Text="0"></asp:Label>
        </td>
    </tr>
        <tr class="eventop">
        <td class="titlemax">
            Tổng số đặt tour trên website
        </td>
        <td class="link">
            <asp:Label ID="lbOrder" runat="server" Text="0"></asp:Label>
        </td>
    </tr>
</table>