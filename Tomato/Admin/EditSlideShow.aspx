<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="EditSlideShow.aspx.cs" Inherits="Admin_EditSlideShow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#btnDuyet").click(function () {
                var finder = new CKFinder();
                finder.selectActionFunction = function (fileUrl) {
                    $('#<%=txtHinhAnh.ClientID %>').val(fileUrl);
                };
                finder.popup();
            });
        });
    </script>
    <div class="content">
        <div class="header">
            <h1 class="page-title">
                <asp:Label ID="lbTitle01" runat="server" Text="Thêm hình ảnh hiển thị trang chủ" /></h1>
        </div>
        <ul class="breadcrumb">
            <li><a href="Admin.aspx">Trang chủ</a> <span class="divider">>></span></li>
            <li class="active"><a href="MgerSlideShow.aspx">Quản lý hình ảnh hiển thị trang chủ</a><span
                class="divider">>></span></li>
            <li class="active">
                <asp:Label ID="lbTitle02" runat="server" Text="Thêm hình ảnh hiển thị" /></li>
        </ul>
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="block">
                    <p class="block-heading">
                        <asp:Label ID="lbtitle" runat="server" Text="Thêm thông tin hình ảnh" /></p>
                    <div class="toolbar">
                        <table class="Edit">
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="Label1" runat="server" Text="" CssClass="red" />
                                    <asp:Label ID="label2" runat="server" Visible="false" />
                                    <asp:Label ID="lblId" runat="server" Visible="false" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <h4>
                                        Nhập thông tin Hình ảnh hiển thị trang chủ</h4>
                                </td>
                            </tr>
                            <tr>
                                <td class="title">
                                    Chọn trang hiển thị:
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddlLoadMenu"
                                        SetFocusOnError="true" Display="Static" CssClass="red" InitialValue="0" runat="server">(Chọn trang hiển thị)</asp:RequiredFieldValidator>
                                    <br />
                                    <asp:DropDownList runat="server" ID="ddlLoadMenu" AppendDataBoundItems="true"
                                        CssClass="drl">
                                        <asp:ListItem Value="0">----- Chọn trang hiển thị -----</asp:ListItem>
                                        <asp:ListItem Value="2"> Hiển thị ở trang ngoài </asp:ListItem>
                                        <asp:ListItem Value="1"> Hiển thị ở trang trong </asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="text" valign="top">
                                    <br />
                                    Tiêu đề:
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTieuDeVn"
                                        CssClass="red">(Nhập tiêu đề)</asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="valTieuDeVn" ControlToValidate="txtTieuDeVn" Text="(Tiêu đề < 150 ký tự)"
                                        runat="server" OnServerValidate="valTieuDeVn_ServerValidate" /><br />
                                    <asp:TextBox ID="txtTieuDeVn" runat="server" Text="" CssClass="txtNewMin"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="text" valign="top">
                                    <br />
                                    Mô tả:
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMota"
                                        CssClass="red">(Nhập mô tả)</asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="valMoTa" ControlToValidate="txtMota" Text="(Mô tả < 300 ký tự)"
                                        runat="server" OnServerValidate="valMoTa_ServerValidate" /><br />
                                    <asp:TextBox ID="txtMota" runat="server" Text="" CssClass="txtNewMin"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="text" valign="top">
                                    Vị trí:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtViTri" runat="server" Text="" CssClass="txtsmall"></asp:TextBox>
                                    <asp:CompareValidator ID="RangeValidatorSDT" runat="server" CssClass="titletb" Operator="DataTypeCheck"
                                        ControlToValidate="txtViTri" Type="Integer">&nbsp;(Chỉ nhập số)</asp:CompareValidator>
                                </td>
                            </tr>
                            <tr class="text">
                                <td valign="top">
                                    <br />
                                    Hình ảnh:
                                </td>
                                <td>
                                    <p>
                                        Ảnh hiển thị đẹp nhất ở kích thước: (913x386)
                                    </p>
                                    <asp:TextBox ID="txtHinhAnh" runat="server" Text="" CssClass="txtNewMin"></asp:TextBox>
                                    <input id="btnDuyet" onclick="BrowseServer( 'Mger_Design:/','<%=txtHinhAnh.ClientID%>');"
                                        type="button" value="Duy&#7879;t file" class="btnedit" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="btnLuu" runat="server" Text="Lưu" CssClass="btnedit" />
                                    <input type="button" value="Đóng" class="btnedit" onclick="location.href='MgerSlideShow.aspx'" /><br />
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <div class="clearfix">
        </div>
    </div>
</asp:Content>
