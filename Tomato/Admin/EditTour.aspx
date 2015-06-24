<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="EditTour.aspx.cs" Inherits="Admin_EditTour" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
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
                <asp:Label ID="lbTitle01" runat="server" Text="Thêm Tour mới" /></h1>
        </div>
        <ul class="breadcrumb">
            <li><a href="Admin.aspx">Trang chủ</a> <span class="divider">>></span></li>
            <li class="active"><a href="MgerTour.aspx">Quản lý tour</a><span class="divider">>></span></li>
            <li class="active">
                <asp:Label ID="lbTitle02" runat="server" Text="Thêm tour mới" /></li>
        </ul>
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="block">
                    <p class="block-heading">
                        Thông tin tour
                    </p>
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
                                <td class="text" valign="top">Thể loại bài viết:
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ID="ddlTour" AppendDataBoundItems="true" CssClass="drl">
                                        <asp:ListItem Value="0">-- Chọn loại tour -- </asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="->Chọn thể loại bài viết"
                                        ControlToValidate="ddlTour" SetFocusOnError="true" Display="Static" CssClass="red"
                                        InitialValue="0" runat="server">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="text" valign="top">Tên Tour (Tiếng Việt):
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTieuDe" runat="server" Text="" TextMode="MultiLine" CssClass="txtNew"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTieuDe"
                                        CssClass="red">*</asp:RequiredFieldValidator><br />
                                    <asp:CustomValidator ID="valComments" ControlToValidate="txtTieuDe" Text="(Tên Tour < 60 ký tự)"
                                        runat="server" OnServerValidate="valComments_ServerValidate" />
                                </td>
                            </tr>

                            <tr>
                                <td class="text" valign="top">Tên Tour (Tiếng anh):
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTieuDe_En" runat="server" Text="" TextMode="MultiLine" CssClass="txtNew"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtTieuDe_En"
                                        CssClass="red">*</asp:RequiredFieldValidator><br />
                                    <asp:CustomValidator ID="CustomValidator1" ControlToValidate="txtTieuDe_En" Text="(Tên Tour < 60 ký tự)"
                                        runat="server" OnServerValidate="valComments_ServerValidate" />
                                </td>
                            </tr>

                            <tr>
                                <td class="text" valign="top">Tên Tour (Tiếng Nga):
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTieuDe_Ru" runat="server" Text="" TextMode="MultiLine" CssClass="txtNew"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtTieuDe_Ru"
                                        CssClass="red">*</asp:RequiredFieldValidator><br />
                                    <asp:CustomValidator ID="CustomValidator2" ControlToValidate="txtTieuDe_Ru" Text="(Tên Tour < 60 ký tự)"
                                        runat="server" OnServerValidate="valComments_ServerValidate" />
                                </td>
                            </tr>


                            <tr>
                                <td class="text" valign="top">Lịch trình (Tiếng Việt):
                                </td>
                                <td>
                                    <asp:TextBox ID="txtlichtrinh" runat="server" Text="" TextMode="MultiLine" CssClass="txtNew"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtlichtrinh"
                                        CssClass="red">*</asp:RequiredFieldValidator><br />
                                    <asp:CustomValidator ID="vallichtrinh" ControlToValidate="txtlichtrinh" Text="(Lịch trình < 100 ký tự)"
                                        runat="server" OnServerValidate="vallichtrinh_ServerValidate" />
                                </td>
                            </tr>

                            <tr>
                                <td class="text" valign="top">Lịch trình (Tiếng Anh):
                                </td>
                                <td>
                                    <asp:TextBox ID="txtlichtrinh_En" runat="server" Text="" TextMode="MultiLine" CssClass="txtNew"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtlichtrinh_En"
                                        CssClass="red">*</asp:RequiredFieldValidator><br />
                                    <asp:CustomValidator ID="CustomValidator3" ControlToValidate="txtlichtrinh_En" Text="(Lịch trình < 100 ký tự)"
                                        runat="server" OnServerValidate="vallichtrinh_ServerValidate" />
                                </td>
                            </tr>

                            <tr>
                                <td class="text" valign="top">Lịch trình (Tiếng Nga):
                                </td>
                                <td>
                                    <asp:TextBox ID="txtlichtrinh_Ru" runat="server" Text="" TextMode="MultiLine" CssClass="txtNew"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtlichtrinh_Ru"
                                        CssClass="red">*</asp:RequiredFieldValidator><br />
                                    <asp:CustomValidator ID="CustomValidator4" ControlToValidate="txtlichtrinh_Ru" Text="(Lịch trình < 100 ký tự)"
                                        runat="server" OnServerValidate="vallichtrinh_ServerValidate" />
                                </td>
                            </tr>


                            <tr>
                                <td class="text" valign="top">Ngày khởi hành:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtngaykhoihanh" runat="server" Text="" CssClass="txtNewMin"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtngaykhoihanh"
                                        CssClass="red">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="text" valign="top">Thời gian:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtThoiGian" runat="server" Text="" CssClass="txtNewMin"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtThoiGian"
                                        CssClass="red">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="text" valign="top">Khách sạn (Tiếng Việt):
                                </td>
                                <td>
                                    <asp:TextBox ID="txtKhachSan" runat="server" Text="" CssClass="txtNewMin"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtKhachSan"
                                        CssClass="red">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>
                                <td class="text" valign="top">Khách sạn (Tiếng Anh):
                                </td>
                                <td>
                                    <asp:TextBox ID="txtKhachSan_En" runat="server" Text="" CssClass="txtNewMin"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtKhachSan_En"
                                        CssClass="red">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>
                                <td class="text" valign="top">Khách sạn (Tiếng Nga):
                                </td>
                                <td>
                                    <asp:TextBox ID="txtKhachSan_Ru" runat="server" Text="" CssClass="txtNewMin"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtKhachSan_Ru"
                                        CssClass="red">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="text" valign="top">Phương tiện (Tiếng Việt):
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPhuongTien" runat="server" Text="" CssClass="txtNewMin"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPhuongTien"
                                        CssClass="red">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>
                                <td class="text" valign="top">Phương tiện (Tiếng Anh):
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPhuongTien_En" runat="server" Text="" CssClass="txtNewMin"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtPhuongTien_En"
                                        CssClass="red">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>
                                <td class="text" valign="top">Phương tiện (Tiếng Nga):
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPhuongTien_Ru" runat="server" Text="" CssClass="txtNewMin"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtPhuongTien_Ru"
                                        CssClass="red">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>
                                <td class="text" valign="top">Khuyễn mãi (Tiếng Việt):
                                </td>
                                <td>
                                    <asp:TextBox ID="txtKhuyenMai" runat="server" Text="" CssClass="txtNewMin"></asp:TextBox>

                                </td>
                            </tr>

                            <tr>
                                <td class="text" valign="top">Khuyễn mãi (Tiếng Anh):
                                </td>
                                <td>
                                    <asp:TextBox ID="txtKhuyenMai_En" runat="server" Text="" CssClass="txtNewMin"></asp:TextBox>

                                </td>
                            </tr>

                            <tr>
                                <td class="text" valign="top">Khuyễn mãi (Tiếng Nga):
                                </td>
                                <td>
                                    <asp:TextBox ID="txtKhuyenMai_Ru" runat="server" Text="" CssClass="txtNewMin"></asp:TextBox>

                                </td>
                            </tr>


                            <tr>
                                <td class="text" valign="top">Giá Tour:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtGiaTour" runat="server" Text="" CssClass="txtNewMin"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtGiaTour"
                                        CssClass="red">*</asp:RequiredFieldValidator><br />
                                    <asp:CompareValidator ID="RangeValidatorSDT" runat="server" CssClass="titletb" Operator="DataTypeCheck"
                                        ControlToValidate="txtGiaTour" Text="Giá: chỉ được nhập số" Type="Integer" />
                                </td>
                            </tr>
                            <tr class="text">
                                <td>Hình ảnh:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtHinhAnh" runat="server" Text="" CssClass="txtNewMin"></asp:TextBox>
                                    <input id="btnDuyet" onclick="BrowseServer( 'Mger_Design:/','<%=txtHinhAnh.ClientID%>    ');"
                                        type="button" value="Duy&#7879;t file" class="btnedit" /><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtHinhAnh" CssClass="red">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <%-- Ẩn đi những trường không đung đến --%>
                            <tr class="text" style="display: none;">
                                <td>Hiển thị trang chủ:
                                </td>
                                <td>
                                    <asp:CheckBox ID="ckbTrangChu" runat="server" Text="Có" />
                                </td>
                            </tr>
                            <tr class="text" style="display: none;">
                                <td>Hiển thị khuyến mãi:
                                </td>
                                <td>
                                    <asp:CheckBox ID="ckbKhuyenMai" runat="server" Text="Có" />
                                </td>
                            </tr>
                            <%-- Ẩn đi những trường không đung đến End--%>

                            <tr class="text">
                                <td colspan="2">
                                    <hr />
                                </td>
                            </tr>
                            <tr class="text">
                                <td colspan="2">Nội dung (Tiếng Việt)<br />
                                    <CKEditor:CKEditorControl ID="txtckeditor" runat="server">
                                    </CKEditor:CKEditorControl>
                                    <br />
                                </td>
                            </tr>

                            <tr class="text">
                                <td colspan="2">Nội dung (Tiếng Anh)<br />
                                    <CKEditor:CKEditorControl ID="txtckeditor_En" runat="server">
                                    </CKEditor:CKEditorControl>
                                    <br />
                                </td>
                            </tr>

                            <tr class="text">
                                <td colspan="2">Nội dung (Tiếng Nga<br />
                                    <CKEditor:CKEditorControl ID="txtckeditor_Ru" runat="server">
                                    </CKEditor:CKEditorControl>
                                    <br />
                                </td>
                            </tr>


                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="btnLuu" runat="server" Text="Lưu" CssClass="btnedit" />
                                    <input type="button" value="Đóng" class="btnedit" onclick="location.href='MgerTour.aspx?TrangThai=0'" /><br />
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
