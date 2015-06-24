<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterNoneCuisineBlock.master" AutoEventWireup="true"
    CodeFile="Contact.aspx.cs" Inherits="Vn_Contact" %>

<%@ Register Src="~/View/UserControl/UC_Paging.ascx" TagName="UC_Paging" TagPrefix="uc1" %>
<asp:Content ID="ContentHeader" runat="server" ContentPlaceHolderID="HeadExtender">
    <link href="/Styles/CSS/Desktop.Contact.css" rel="stylesheet" />

    <link href="/Styles/FancyBox-2.1.5/source/helpers/jquery.fancybox-buttons.css" rel="stylesheet" />
    <link href="/Styles/FancyBox-2.1.5/source/helpers/jquery.fancybox-thumbs.css" rel="stylesheet" />
    <link href="/Styles/FancyBox-2.1.5/source/jquery.fancybox.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="Server">


    <div class="galery-title-bar">
        <div class="gallery-title">
            <div class="galery-title-bar-icon">
                <img src="/Design/cachua.png" alt="pic" class="img" />
            </div>
            <h1>
                <asp:Literal ID="ltrCtTitle" runat="server" Text="<%$Resources:Resource,contact %>"></asp:Literal>
            </h1>
        </div>
    </div>
    <div class="body-right-content">
        <p>
            <%=Resources.Resource.contact_message %>
        </p>

        <div class="contact">
            <%-- View maps --%>
            <a class="map-direction" data-fancybox-type="iframe" href="/<%=Session["lang"].ToString() %>/map.html"><%=Resources.Resource.view_map %></a>
            <asp:UpdatePanel ID="UpdatePanelContact" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="succesfull" runat="server" Text="Label" Visible="false" CssClass="succesfull" />
                                <asp:Label ID="lbtitle" runat="server" Text="Label" Visible="false" CssClass="titletb" />
                            </td>
                        </tr>
                        <tr>
                            <td><%=Resources.Resource.fullname %> :
                            </td>
                            <td>
                                <asp:TextBox ID="txtHoTen" runat="server" CssClass="txt"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtHoTen"
                                    ValidationGroup="contact" ErrorMessage="->Vui lòng nhập họ tên!" CssClass="titletb">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td><%=Resources.Resource.email %> :
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="txt" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                                    ValidationGroup="contact" ErrorMessage="Email Không đúng!" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    CssClass="titletb">*</asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail"
                                    ValidationGroup="contact" ErrorMessage="->Vui lòng nhập email!" CssClass="titletb">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td><%=Resources.Resource.address %> :
                            </td>
                            <td>
                                <asp:TextBox ID="txtDiaChi" runat="server" CssClass="txt" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDiaChi"
                                    ValidationGroup="contact" ErrorMessage="->Vui lòng nhập địa chỉ!" CssClass="titletb">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td><%=Resources.Resource.title %> :
                            </td>
                            <td>
                                <asp:TextBox ID="txtTieuDe" runat="server" CssClass="txt" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTieuDe"
                                    ValidationGroup="contact" ErrorMessage="->Vui lòng nhập tiêu đề!" CssClass="titletb">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top"><%=Resources.Resource.content %>:
                            </td>
                            <td valign="top">
                                <asp:TextBox ID="txtNoiDung" runat="server" TextMode="MultiLine" CssClass="txtnd"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNoiDung"
                                    ValidationGroup="contact" ErrorMessage="->Vui lòng nhập nội dung!" CssClass="titletb">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Label ID="lbcapcha" runat="server" Text="Label" Visible="false" CssClass="titletb" />
                            </td>
                        </tr>
                        <tr>
                            <td valign="bottom"><%=Resources.Resource.confirm_code %>:
                            </td>
                            <td style="position: relative;">
                                <asp:TextBox ID="txtInputString" runat="server" CssClass="txtmin"></asp:TextBox>
                                <asp:Image ID="captchaImage" runat="server" CssClass="capcha" />
                                <asp:Button ID="btnRedefine" runat="server" Text="" CssClass="btnrefresh" OnClick="btnRedefine_Click" />

                            </td>
                        </tr>
                        <tr>
                            <td class="td"></td>
                            <td colspan="2">
                                <asp:Button ID="btnGui" runat="server" Text="<%$Resources:Resource,submit %>" CssClass="btn" OnClick="btnbtnGui_Click" ValidationGroup="contact" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <%-- <div class="qa-title">
            <p>Danh sách ý kiến khách hàng</p>
        </div>

        <div class="qa">
            <asp:Repeater ID="rptHoiDap" runat="server">
                <ItemTemplate>
                    <div class="question bot5">
                        <img src="/Design/mail.png" alt="Question Icon" />
                        <a href="javascript:void();">
                            <%#Eval("TieuDe") %> (<i style="font-size: 12px;"> <%#Eval("HoTen") %> gửi ngày <%#Showinfo(Container.DataItem,"ngaygui") %></i> )
                        </a>

                    </div>

                    <div class="answer bot10">
                        <%#Eval("NoiDung") %>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <uc1:UC_Paging ID="pagerBottom" runat="server" />

        </div>--%>
    </div>

</asp:Content>

<asp:Content ID="ContentFooter" runat="server" ContentPlaceHolderID="FootExtender">
    <script src="/Styles/FancyBox-2.1.5/lib/jquery.mousewheel-3.0.6.pack.js" type="text/javascript"></script>
    <script src="/Styles/FancyBox-2.1.5/source/jquery.fancybox.pack.js" type="text/javascript"></script>
    <script src="/Styles/FancyBox-2.1.5/source/jquery.fancybox.js" type="text/javascript"></script>
    <script src="/Styles/FancyBox-2.1.5/source/helpers/jquery.fancybox-buttons.js" type="text/javascript"></script>
    <script src="/Styles/FancyBox-2.1.5/source/helpers/jquery.fancybox-media.js" type="text/javascript"></script>
    <script src="/Styles/FancyBox-2.1.5/source/helpers/jquery.fancybox-thumbs.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $(".map-direction").fancybox({
                maxWidth: 1349,
                maxHeight: 630,
                fitToView: false,
                width: '818px',
                height: '519px',
                autoSize: false,
                closeClick: false,
                openEffect: 'none',
                closeEffect: 'none'
            });
        });

    </script>

</asp:Content>
