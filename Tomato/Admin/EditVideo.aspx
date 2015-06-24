<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="EditVideo.aspx.cs" Inherits="Admin_EditVideo" %>

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
            $("#btnanhdaidien").click(function () {
                var finder = new CKFinder();
                finder.selectActionFunction = function (fileUrl) {
                    $('#<%=txtAnhDaiDien.ClientID %>').val(fileUrl);
                };
                finder.popup();
            });
        });
    </script>
    <div class="content">
        <div class="header">
            <h1 class="page-title">
                <asp:Label ID="lbTitle01" runat="server" Text="Thêm Video-Clips mới" /></h1>
        </div>
        <ul class="breadcrumb">
            <li><a href="Admin.aspx">Trang chủ</a> <span class="divider">>></span></li>
            <li class="active"><a href="MgerVideo.aspx">Quản lý Video-Clips</a><span class="divider">>></span></li>
            <li class="active">
                <asp:Label ID="lbTitle02" runat="server" Text="Thêm video-clips mới" /></li>
        </ul>
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="block">
                    <p class="block-heading">
                        <asp:Label ID="lbtitle" runat="server" Text="Thêm Video-Clips" /></p>
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
                                        Nhập thông tin video</h4>
                                </td>
                            </tr>
                            <tr>
                                <td class="text" valign="top">
                                    <br />
                                    Tên Video-Clips (Tiếng việt):
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTenVn"
                                        CssClass="red">(Nhập tên 'Tiếng việt')</asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="CustomValidator1" ControlToValidate="txtTenVn" Text="(Tên 'Tiếng việt'< 100 ký tự)"
                                        runat="server" OnServerValidate="valTenVn_ServerValidate" /><br />
                                    <asp:TextBox ID="txtTenVn" runat="server" Text="" TextMode="MultiLine" CssClass="txtNewMin"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="text" valign="top">
                                    <br />
                                    Tên Video-Clips (EngLish):
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtTenEn"
                                        CssClass="red">(Nhập tên 'EngLish')</asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="valTenEn" ControlToValidate="txtTenEn" Text="(Tên 'EngLish' < 100 ký tự)"
                                        runat="server" OnServerValidate="valTenEn_ServerValidate" /><br />
                                    <asp:TextBox ID="txtTenEn" runat="server" Text="" TextMode="MultiLine" CssClass="txtNewMin"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="text" valign="top">
                                    <br />
                                    Tên Video-Clips (Russia):
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtTenRu"
                                        CssClass="red">(Nhập tên 'Russia')</asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="valTenRu" ControlToValidate="txtTenRu" Text="(Tên 'Russia' < 100 ký tự)"
                                        runat="server" OnServerValidate="valTenRu_ServerValidate" /><br />
                                    <asp:TextBox ID="txtTenRu" runat="server" Text="" TextMode="MultiLine" CssClass="txtNewMin"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="text" valign="top">
                                    Mô tả (Tiếng việt):
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtmoTaVn"
                                        CssClass="red">(Nhập tên 'Tiếng việt')</asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="valmotaVn" ControlToValidate="txtmoTaVn" Text="(Mô tả 'Tiếng việt' < 150 ký tự)"
                                        runat="server" OnServerValidate="valmotaVn_ServerValidate" /><br />
                                    <asp:TextBox ID="txtmoTaVn" runat="server" Text="" TextMode="MultiLine" CssClass="txtNewMin"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="text" valign="top">
                                    Mô tả (EngLish):
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtmoTaEn"
                                        CssClass="red">(Nhập mô tả 'EngLish')</asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="valmotaEn" ControlToValidate="txtmoTaEn" Text="(Mô tả 'EngLish'< 150 ký tự)"
                                        runat="server" OnServerValidate="valmotaEn_ServerValidate" /><br />
                                    <asp:TextBox ID="txtmoTaEn" runat="server" Text="" TextMode="MultiLine" CssClass="txtNewMin"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="text" valign="top">
                                    Mô tả (Russia):
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtmoTaRu"
                                        CssClass="red">(Nhập mô tả 'Russia')</asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="valmotaRu" ControlToValidate="txtmoTaRu" Text="(Mô tả 'Russia'< 150 ký tự)"
                                        runat="server" OnServerValidate="valmotaRu_ServerValidate" /><br />
                                    <asp:TextBox ID="txtmoTaRu" runat="server" Text="" TextMode="MultiLine" CssClass="txtNewMin"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="text">
                                <td valign="top">
                                    Ảnh đại diện:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAnhDaiDien" runat="server" Text="" CssClass="txtNewMin"></asp:TextBox>
                                    <input id="btnanhdaidien" onclick="BrowseServer( 'Mger_Design:/','<%=txtAnhDaiDien.ClientID%>');"
                                        type="button" value="Duy&#7879;t file" class="btnedit" /><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAnhDaiDien"
                                        ErrorMessage="->Nhập tiêu đề" CssClass="red">(Chọn ảnh đại diện)</asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtHinhAnh"
                                        ErrorMessage="->Nhập tiêu đề" CssClass="red">(Chọn link videos-clips)</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr class="text">
                                <td valign="top">
                                    Link Video-Clips:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtHinhAnh" runat="server" Text="" CssClass="txtNewMin"></asp:TextBox>
                                    <input id="btnDuyet" onclick="BrowseServer( 'Mger_Design:/','<%=txtHinhAnh.ClientID%>');"
                                        type="button" value="Duy&#7879;t file" class="btnedit" /><br />
                                    <asp:Label ID="lblinkandvideo" runat="server" Text="(Vui lòng chọn file .flv hoặc chuột phải vào file -> chọn rename file thành .flv)" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="btnLuu" runat="server" Text="Lưu Video" CssClass="btnedit" />
                                    <input type="button" value="Đóng" class="btnedit" onclick="location.href='MgerVideo.aspx'" /><br />
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
