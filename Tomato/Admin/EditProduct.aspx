<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="EditProduct.aspx.cs" Inherits="Admin_EditProduct" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#btnDuyetAnhNho").click(function () {
                var finder = new CKFinder();
                finder.selectActionFunction = function (fileUrl) {
                    $('#<%=txtHinhNho.ClientID %>').val(fileUrl);
                };
                finder.popup();
            });

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
                <asp:Label ID="lbTitle01" runat="server" Text="Thêm món ăn mới" /></h1>
        </div>
        <ul class="breadcrumb">
            <li><a href="Admin.aspx">Trang chủ</a> <span class="divider">>></span></li>
            <li class="active"><a href="MgerProduct.aspx">Quản lý món ăn</a><span class="divider">>></span></li>
            <li class="active">
                <asp:Label ID="lbTitle02" runat="server" Text="Thêm món ăn mới" /></li>
        </ul>
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="block">
                    <p class="block-heading">
                        Thông tin món ăn
                    </p>
                    <div class="toolbar">
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <table class="Edit">
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="Label1" runat="server" Text="" CssClass="red" />
                                    <asp:Label ID="label2" runat="server" Visible="false" />
                                    <asp:Label ID="lblId" runat="server" Visible="false" />
                                    <asp:Label ID="lbNhapMoTa" runat="server" Text=" Chưa nhập chi tiết món ăn!" Visible="false"
                                        CssClass="red" />
                                </td>
                            </tr>
                            <tr>
                                <td class="text" valign="top">Thể loại món ăn:
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ID="ddlLoaiMenu" AppendDataBoundItems="true" CssClass="drl">
                                        <asp:ListItem Value="0">---  Chọn thể loại món ăn  ---</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="->Chọn thể loại món ăn"
                                        ControlToValidate="ddlLoaiMenu" SetFocusOnError="true" Display="Static" CssClass="red"
                                        InitialValue="0" runat="server">( Chọn thể loại món ăn cần thêm )</asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>
                                <td class="text">Tên món ăn (tiếng việt):
                                </td>
                                <td>
                                    <asp:CustomValidator ID="valTieuDeVn" ControlToValidate="txtTieuDe_Vi" Text="(Tiêu đề 'Tiếng việt' < 150 ký tự)"
                                        runat="server" OnServerValidate="valTieuDeVn_ServerValidate" /><br />
                                    <asp:TextBox ID="txtTieuDe_Vi" runat="server" Text="" TextMode="MultiLine" CssClass="txtNew"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTieuDe_Vi"
                                        CssClass="red">( * )</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="text" valign="top">Tên món ăn (EngLish):
                                </td>
                                <td>
                                    <asp:CustomValidator ID="valTieuDeEn" ControlToValidate="txtTieuDe_En" Text="(Tiêu đề 'EngLish' < 150 ký tự)"
                                        runat="server" OnServerValidate="valTieuDeEn_ServerValidate" /><br />
                                    <asp:TextBox ID="txtTieuDe_En" runat="server" Text="" TextMode="MultiLine" CssClass="txtNew"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtTieuDe_En"
                                        CssClass="red">( * )</asp:RequiredFieldValidator><br />
                                </td>
                            </tr>
                            <tr>
                                <td class="text" valign="top">Tên món ăn (Russia):
                                </td>
                                <td>
                                    <asp:CustomValidator ID="valTieuDeRu" ControlToValidate="txtTieuDe_Ru" Text="(Tiêu đề 'Russia' < 150 ký tự)"
                                        runat="server" OnServerValidate="valTieuDeRu_ServerValidate" /><br />
                                    <asp:TextBox ID="txtTieuDe_Ru" runat="server" Text="" TextMode="MultiLine" CssClass="txtNew"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTieuDe_Ru"
                                        CssClass="red">( * )</asp:RequiredFieldValidator><br />
                                </td>
                            </tr>
                            <tr>
                                <td class="text" valign="top">Mô tả món ăn (Tiếng việt):
                                </td>
                                <td>
                                    <asp:CustomValidator ID="valTomTatVn" ControlToValidate="txtTomTatVn" Text="(Mô tả 'Tiếng việt' < 300 ký tự)"
                                        runat="server" OnServerValidate="valTomTatVn_ServerValidate" /><br />
                                    <asp:TextBox ID="txtTomTatVn" runat="server" Text="" TextMode="MultiLine" CssClass="txtNewContent"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="text" valign="top">Mô tả món ăn (EngLish):
                                </td>
                                <td>
                                    <asp:CustomValidator ID="valTomTatEn" ControlToValidate="txtTomTatEn" Text="(Tóm tắc 'English' < 300 ký tự)"
                                        runat="server" OnServerValidate="valTomTatEn_ServerValidate" /><br />
                                    <asp:TextBox ID="txtTomTatEn" runat="server" Text="" TextMode="MultiLine" CssClass="txtNewContent"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="text" valign="top">Mô tả món ăn (Russia):
                                </td>
                                <td>
                                    <asp:CustomValidator ID="valTomTatRu" ControlToValidate="txtTomTatRu" Text="(Tóm tắc 'Russia' < 300 ký tự)"
                                        runat="server" OnServerValidate="valTomTatRu_ServerValidate" /><br />
                                    <asp:TextBox ID="txtTomTatRu" runat="server" Text="" TextMode="MultiLine" CssClass="txtNewContent"></asp:TextBox>
                                </td>
                            </tr>



                            <tr class="text">
                                <td>Ảnh đại diện:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtHinhNho" runat="server" Text="" CssClass="txtNewMin"></asp:TextBox>
                                    <input id="btnDuyetAnhNho" onclick="BrowseServer( 'Mger_Design:/','<%=txtHinhNho.ClientID%>    ');"
                                        type="button" value="Duy&#7879;t file" class="btnedit" /><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtHinhNho" CssClass="red">*</asp:RequiredFieldValidator><br />
                                </td>
                            </tr>
                            <tr class="text">
                                <td>Đơn giá(VNĐ):
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDonGia" runat="server" Text="" CssClass="txtsmall" />&nbsp;VNĐ<asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtDonGia" CssClass="red">*</asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="validator" runat="server" ControlToValidate="txtDonGia" Operator="DataTypeCheck" Type="Double" ErrorMessage="Vui lòng chỉ nhập số" />
                                </td>
                            </tr>

                            <tr class="text" valign="top">
                                <td>Thêm ảnh cho món ăn:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtHinhAnh" runat="server" Text="" CssClass="txtNewMin"></asp:TextBox>
                                    <input id="btnDuyet" onclick="BrowseServer( 'images:/','<%=txtHinhAnh.ClientID%>    ');"
                                        type="button" value="Duy&#7879;t file" class="btnedit" /><br />
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnaddimg" runat="server" Text="Thêm vào danh sách" CssClass="linkAddimg" /><asp:Label
                                                ID="lbhinhanh" runat="server" Text="Vui lòng duyệt để chọn ảnh" Visible="false"
                                                CssClass="red" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <h4>Danh sách ảnh cho món ăn</h4>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:DataList ID="dlListImg" runat="server" RepeatColumns="4">
                                                <ItemTemplate>
                                                    <div class="itemimg">
                                                        <img src='<%# DataAccess.Connect.Link.Toimages(Eval("HinhAnh").ToString()) %>'>
                                                        <asp:Button Text=" " runat="server" ID="btnDelete" CommandArgument='<%#Eval("ID")%>'
                                                            CommandName="Deleteimg" CssClass="linkRemoveimg" />
                                                    </div>
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">Chi tiết món ăn (tiếng việt):<br />
                                    <CKEditor:CKEditorControl ID="txtChiTietVn" Height="300" runat="server">
                                    </CKEditor:CKEditorControl>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">Chi tiết món ăn (EngLish):<br />
                                    <CKEditor:CKEditorControl ID="txtChiTietEn" Height="300" runat="server">
                                    </CKEditor:CKEditorControl>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">Chi tiết món ăn (Russia):<br />
                                    <CKEditor:CKEditorControl ID="txtChiTietRu" Height="300" runat="server">
                                    </CKEditor:CKEditorControl>
                                </td>
                            </tr>
                            <tr class="text">
                                <td colspan="2">
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="btnLuu" runat="server" Text="Lưu" CssClass="btnedit" />
                                    <input type="button" value="Đóng" class="btnedit" onclick="location.href='MgerProduct.aspx'" />
                                    <br />
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
