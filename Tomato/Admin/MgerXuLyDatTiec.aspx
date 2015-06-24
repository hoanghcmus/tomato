<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MgerXuLyDatTiec.aspx.cs" Inherits="Admin_MgerXuLyDatTour1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
        <%= System.Configuration.ConfigurationManager.AppSettings["Keywords"] %></title>
    <link href="stylesheets/tour_add.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function select() {
            close();
        }
    </script>
</head>
<body>
    <form id="frmDatTour" runat="server">
        <div class="container">
            <div id="feedback">

                <table class="GuiYkien">
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="title" runat="server" Text="Thông tin khách hàng đặt tour" CssClass="title" />
                            <asp:Label ID="succesfull" runat="server" Text="Label" Visible="false" CssClass="succesfull" />
                            <asp:Label ID="lbtitle" runat="server" Text="Label" Visible="false" CssClass="titletb" />
                            <asp:Label ID="lbID" runat="server" Text="ID" Visible="false" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td class="txt">
                            <strong>Họ tên :</strong>
                        </td>
                        <td class="tdtxt">
                            <asp:Label ID="lbhoten" runat="server" Text="" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Email :</strong>
                        </td>
                        <td>
                            <asp:Label ID="lbemail" runat="server" Text="" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Địa chỉ :</strong>
                        </td>
                        <td>
                            <asp:Label ID="lbdiachi" runat="server" Text="" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Số điện thoại :</strong>
                        </td>
                        <td>
                            <asp:Label ID="lbsdt" runat="server" Text="" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Số người :</strong>
                        </td>
                        <td>
                            <asp:Label ID="lbnguoi" runat="server" Text="" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Ngày đặt bàn :</strong>
                        </td>
                        <td>
                            <asp:Label ID="lbngaydat" runat="server" Text="" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <strong>Vào lúc:</strong>
                        </td>
                        <td valign="top">
                            <asp:Label ID="lbgio" runat="server" Text="" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <strong>Ngày gửi:</strong>
                        </td>
                        <td valign="top">
                            <asp:Label ID="lbngaygui" runat="server" Text="" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <strong>Trạng thái:</strong>
                        </td>
                        <td valign="top">
                            <asp:Label ID="lbtrangthai" runat="server" Text="" />
                            <asp:Label ID="titletrangthai" runat="server" Visible="false" Text="" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button Text="Đánh dấu đợi" runat="server" ID="btnMarkPending" CssClass="btndoi" />
                            <asp:Button Text="Đánh dấu duyệt" runat="server" ID="btnMarkCompleted" CssClass="btnduyet" />
                            <asp:Button Text="Đánh dấu hủy" runat="server" ID="btnMarkCanceled" CssClass="btnhuy" />
                            <a href="javascript:void(0)" onclick="select()" class="btndong">Đóng</a>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
