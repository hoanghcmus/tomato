<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterNoneCuisineBlock.master" AutoEventWireup="true" CodeFile="ChiTietMonAn.aspx.cs" Inherits="View_ChiTietMonAn" %>

<asp:Content ID="Header" ContentPlaceHolderID="HeadExtender" runat="Server">
    <link href="/Styles/Magiczoom/magiczoom.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Left" ContentPlaceHolderID="LeftBlockContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="galery-title-bar">
        <div class="gallery-title">
            <div class="galery-title-bar-icon">
                <img src="/Design/cachua.png" alt="pic" class="img" />
            </div>
            <h1>
                <asp:Literal ID="ltrCtTitle" runat="server" Text="<%$Resources:Resource,list_article %>"></asp:Literal>
            </h1>
        </div>
    </div>
    <div class="body-right-content">
        <div class="product-detail">
            <div class="product-detail-wrapper">

                <div class="figure">
                    <div class="figure-wrapper">

                        <a href="/img/r6-mix-1000.jpg" class="MagicZoom link" id="figureLarge" rel="zoom-width:400px; zoom-height:400px; zoom-distance:40" runat="server">
                            <img src="/img/r6-mix-290.jpg" id="figureThumb" class="" runat="server" /></a>
                    </div>

                    <div class="thumms">
                        <asp:Repeater ID="rptListImg" runat="server">
                            <ItemTemplate>
                                <div class="thumb <%#Container.ItemIndex == 0 ? "thumb-active" : "" %>">
                                    <a href="<%#Eval("HinhAnh") %>" rel="zoom-id:<%=figureLarge.ClientID %>" rev="<%#ToThumb(Eval("HinhAnh").ToString()) %>" class="link tlink">
                                        <img src="<%#ToThumb(Eval("HinhAnh").ToString()) %>" class="img" />
                                    </a>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>

                <div class="product-infos">
                    <div class="line-fix-parent-width">
                        <div class="product-label"><%=Resources.Resource.cuisine_name %>:</div>
                        <div class="product-info">
                            <asp:Literal ID="ltrTenSanPham" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="line-fix-parent-width">
                        <div class="product-label"><%=Resources.Resource.price %>:</div>
                        <div class="product-info">
                            <asp:Literal ID="ltrPrice" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="line-fix-parent-width">
                        <div class="product-label"><%=Resources.Resource.description %>:</div>
                        <div class="product-info">
                            <asp:Literal ID="ltrMoTa" runat="server"></asp:Literal>
                        </div>
                    </div>

                </div>
                <div class="detail-info">
                    <div class="detail-title">
                        <h1><%=Resources.Resource.cuisine_detail %></h1>
                    </div>
                    <div class="detail-info-wraper">
                        <asp:Literal ID="ltrChiTietSanPham" runat="server">
                        </asp:Literal>
                    </div>
                </div>

                <div class="related-product">
                    <div class="detail-title" style="border-top: 1px dotted #C0C0C0;">
                        <h1 style="text-transform: uppercase;"><%=Resources.Resource.related_cuisine %></h1>
                    </div>
                    <div class="related-product-wraper">
                        <asp:Repeater ID="rptRelatedProduct" runat="server">
                            <ItemTemplate>
                                <div class="menu-item">
                                    <a href="<%#ShowArticleCat(Container.DataItem,"ArticleCatDuongDan") %>" class="link">
                                        <div class="menu-figure">
                                            <img src="<%#Eval("AnhDaiDien") %>" alt="<%#ShowArticleCat(Container.DataItem,"ArticleCatTenMon") %>" class="img" />
                                        </div>
                                        <div class="menu-price"><span><%#showMoney(Convert.ToDecimal(Eval("Gia"))) %> VNĐ</span></div>
                                        <div class="menu-title">
                                            <h1><%#ShowArticleCat(Container.DataItem,"ArticleCatTenMon") %></h1>
                                        </div>
                                    </a>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
<asp:Content ID="Footer" ContentPlaceHolderID="FootExtender" runat="Server">
    <script src="/Styles/Magiczoom/magiczoomplus.js"></script>
    <%-- Load page content when click item on the right --%>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".tlink").click(function () {
                $(".thumb-active").removeClass("thumb-active");
                $(this).parent().addClass("thumb-active");
            });
        });
    </script>
</asp:Content>

