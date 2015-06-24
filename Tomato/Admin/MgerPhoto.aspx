<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="MgerPhoto.aspx.cs" Inherits="Admin_MgerPhoto" %>

<%@ Register Src="Mger_UserControl/UC_PhanTrang.ascx" TagName="UC_PhanTrang" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content">
        <div class="header">
            <h1 class="page-title">
                <asp:Label ID="Label1" runat="server" Text="Danh sách album" /></h1>
        </div>
        <ul class="breadcrumb">
            <li><a href="Admin.aspx">Trang chủ</a> <span class="divider">>></span></li>
            <li class="active">Quản lý album<span class="divider">>></span></li>
        </ul>
        <div class="container-fluid">
            <div class="titlePhoto">
                <a href="EditPhoto.aspx" class="linkAdd">Thêm album</a>
            </div>
            <hr class="hralbum" />
            <div class="row-fluid">
                <div class="content_right">
                    <div class="listalbum">
                        <asp:DataList ID="dlListImg" runat="server" RepeatColumns="3">
                            <ItemTemplate>
                                <div class="itemalbum">
                                    <div class="image_stack">
                                        <%#ShowImg(Container.DataItem,"ImgOrClip") %>
                                    </div>
                                    <div class="titlealbum">
                                        <h5>
                                            <%#Eval("Ten_Vn").ToString() %></h5>
                                    </div>
                                    <div class="linkevent">
                                        <a href="<%# DataAccess.Connect.Link.EditPhoto(Eval("ID").ToString()) %>" class="linkEditAlbum">
                                            Cập nhật</a>
                                        <asp:Button Text="Xóa album" runat="server" ID="btnDelete" CommandArgument='<%#Eval("ID")%>'
                                            CommandName="DeleteAlbum" CssClass="linkRemovealbum" />
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:DataList>
                        <uc1:UC_PhanTrang ID="pagerBottom" runat="server" />
                    </div>
                </div>
            </div>
        </div>
        <div class="clearfix">
        </div>
    </div>
</asp:Content>
