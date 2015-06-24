<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="MgerSupport.aspx.cs" Inherits="Admin_MgerSupport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content">
        <div class="header">
            <h1 class="page-title">
                <asp:Label ID="Label1" runat="server" Text="Danh sách hỗ trợ" /></h1>
        </div>
        <ul class="breadcrumb">
            <li><a href="Admin.aspx">Trang chủ</a> <span class="divider">>></span></li>
            <li class="active">Hỗ trợ khách hàng<span class="divider"></span></li>
        </ul>
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="content_right">
                    <div class="toolbar">
                        <input type="button" value="Làm mới" class="btnnew" onclick="location.href = 'MgerSupport.aspx'" />
                        <a href="#" class="moreHoTro">Thêm hỗ trợ</a>
                        <asp:Label ID="lbtitle" runat="server" Text="Label" Visible="false" CssClass="red" />
                        <br />
                        <div id="feedback">
                            <div class="well">
                                <p>
                                    Nhập thông tin hỗ trợ cần thêm.
                                </p>
                                <table class="Edit">
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="lbrs" runat="server" Text="" Visible="false" CssClass="red" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">Tên liên hệ (Tiếng việt):
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNhapTenVn" runat="server" CssClass="txt" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">Tên liên hệ (EngLish):
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNhapTenEn" runat="server" CssClass="txt" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">Tên liên hệ (Russia):
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNhapTenRu" runat="server" CssClass="txt" />
                                        </td>
                                    </tr>

                                    <tr>
                                        <td valign="top">SĐT:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSDT" runat="server" CssClass="txt" />
                                            <asp:CompareValidator ID="RangeValidatorSDT" runat="server" ErrorMessage="Chi nhập số"
                                                CssClass="titletb" Operator="DataTypeCheck" ControlToValidate="txtSDT" Type="Integer">&nbsp;(Chỉ nhập số)</asp:CompareValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">Thông tin khác:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNhapMoTa" runat="server" CssClass="txt" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="td"></td>
                                        <td colspan="2">
                                            <asp:Button ID="btnLuu" runat="server" Text="Lưu" CssClass="btnedit" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <hr />
                    </div>
                    <div class="block">
                        <p class="block-heading">
                            Danh sách hỗ trợ khách hàng
                        </p>
                        <table class="list">
                            <thead>
                                <tr>
                                    <th class="cid">
                                        <input type="checkbox" id="chkAll" />
                                    </th>
                                    <th class="title1">ID
                                    </th>
                                    <th class="title150">Tên hỗ trợ (Tiếng Việt)
                                    </th>
                                    <th class="title150">Tên hỗ trợ (EngLish)
                                    </th>
                                    <th class="title150">Tên hỗ trợ (Russia)
                                    </th>

                                    <th class="title100">Số điện thoại
                                    </th>
                                    <th class="title">Cập nhật
                                    </th>
                                </tr>
                            </thead>
                            <asp:Repeater runat="server" ID="repProd">
                                <AlternatingItemTemplate>
                                    <tr class="eventop">
                                        <td>
                                            <input type="checkbox" name='cid' value='<%#Eval("ID") %>' />
                                        </td>
                                        <td class="link">
                                            <%#Eval("ID")%>
                                        </td>
                                        <td class="title150">
                                            <asp:TextBox runat="server" ID="txtfrmTenVn" Text='<%#Eval("Ten_Vn")%>' CssClass="txt100" />
                                            <asp:HiddenField ID="hdnID" runat="server" Value='<%# Eval("ID")%>' />
                                        </td>
                                        <td class="title150">
                                            <asp:TextBox runat="server" ID="txtfrmTenEn" Text='<%#Eval("Ten_En")%>' CssClass="txt100" />
                                        </td>
                                        <td class="title150">
                                            <asp:TextBox runat="server" ID="txtfrmTenRu" Text='<%#Eval("Ten_Ru")%>' CssClass="txt100" />
                                        </td>

                                        <td class="title100">
                                            <asp:TextBox runat="server" ID="txtfrmSDT" Text='<%#Eval("SDT")%>' CssClass="txt100" />
                                        </td>
                                        <td class="title">
                                            <asp:Button Text="Cập nhật" runat="server" ID="btnUpdata" CommandArgument='<%#Eval("ID")%>'
                                                CommandName="Updata" CssClass="linkEditmin" />
                                            <asp:Button Text="Xóa" runat="server" ID="btnDelete" CommandArgument='<%#Eval("ID")%>'
                                                CommandName="Delete" CssClass="linkRemovemin" />
                                        </td>
                                    </tr>
                                </AlternatingItemTemplate>
                                <ItemTemplate>
                                    <tr class="evenbottom">
                                        <td>
                                            <input type="checkbox" name='cid' value='<%#Eval("ID") %>' />
                                        </td>
                                        <td class="link">
                                            <%#Eval("ID")%>
                                        </td>
                                        <td class="title150">
                                            <asp:TextBox runat="server" ID="txtfrmTenVn" Text='<%#Eval("Ten_Vn")%>' CssClass="txt100" />
                                            <asp:HiddenField ID="hdnID" runat="server" Value='<%# Eval("ID")%>' />
                                        </td>
                                        <td class="title150">
                                            <asp:TextBox runat="server" ID="txtfrmTenEn" Text='<%#Eval("Ten_En")%>' CssClass="txt100" />
                                        </td>
                                        <td class="title150">
                                            <asp:TextBox runat="server" ID="txtfrmTenRu" Text='<%#Eval("Ten_Ru")%>' CssClass="txt100" />
                                        </td>

                                        <td class="title100">
                                            <asp:TextBox runat="server" ID="txtfrmSDT" Text='<%#Eval("SDT")%>' CssClass="txt100" />
                                        </td>
                                        <td class="title">
                                            <asp:Button Text="Cập nhật" runat="server" ID="btnUpdata" CommandArgument='<%#Eval("ID")%>'
                                                CommandName="Updata" CssClass="linkEditmin" />
                                            <asp:Button Text="Xóa" runat="server" ID="btnDelete" CommandArgument='<%#Eval("ID")%>'
                                                CommandName="Delete" CssClass="linkRemovemin" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <div class="clearfix">
        </div>
    </div>
</asp:Content>
