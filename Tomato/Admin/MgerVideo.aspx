<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="MgerVideo.aspx.cs" Inherits="Admin_MgerVideo" %>

<%@ Register Src="Mger_UserControl/UC_PhanTrang.ascx" TagName="UC_PhanTrang" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content">
        <div class="header">
            <h1 class="page-title">
                <asp:Label ID="Label1" runat="server" Text="Danh sách video-clips" /></h1>
        </div>
        <ul class="breadcrumb">
            <li><a href="Admin.aspx">Trang chủ</a> <span class="divider">>></span></li>
            <li class="active">Quản lý video-clips<span class="divider">>></span></li>
        </ul>
        <div class="container-fluid">
            <div class="titlePhoto">
                <a href="EditVideo.aspx" class="linkAdd">Thêm Video</a>
            </div>
            <hr class="hrvideo" />
            <div class="row-fluid">
                <div class="content_right">
                    <asp:DataList ID="dlListVideo" runat="server">
                        <ItemTemplate>
                            <div class="itemvideo">
                                <div class="left">
                                    <div class="videos_url">
                                        <a href="#" title="<%#Eval("HinhAnh")%>">
                                            <img src='<%# DataAccess.Connect.Link.ToFiles(Eval("HinhAnh").ToString()) %>' />
                                            <i class="playvideo"></i></a>
                                    </div>
                                </div>
                                <div class="right">
                                    <div class="textvideo">
                                        <p>
                                            Ngày tạo:
                                            <%#Eval("NgayTao") %></p>
                                        <p>
                                            <h5>
                                                <strong>Tên video: </strong>'<%#Eval("Ten_Vn")%>'</h5>
                                        </p>
                                        <strong>Mô tả về video: </strong>
                                        <asp:TextBox ID="TextBox1" Enabled="false" Text='<%#Eval("MoTa_Vn")%>' CssClass="txtmin"
                                            runat="server" />
                                        <strong>Đường dẫn video: </strong>
                                        <asp:TextBox ID="txtfrmduongdan" Enabled="false" Text='<%#Eval("ImgOrClip")%>' CssClass="txtmin"
                                            runat="server" />
                                    </div>
                                    <div class="videos_event">
                                        <a href="<%# DataAccess.Connect.Link.EditVideo(Eval("ID").ToString()) %>" class="linkEditleft0">
                                            Cập nhật</a>
                                        <asp:Button Text="Xóa video này" runat="server" ID="btnDelete" CommandArgument='<%#Eval("ID")%>'
                                            CommandName="DeleteVideo" CssClass="linkRemovevideo" />
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                    <uc1:UC_PhanTrang ID="pagerBottom" runat="server" />
                </div>
            </div>
        </div>
        <div class="clearfix">
        </div>
    </div>
</asp:Content>
