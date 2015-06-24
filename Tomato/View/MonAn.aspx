<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterNoneCuisineBlock.master" AutoEventWireup="true" CodeFile="MonAn.aspx.cs" Inherits="View_MonAn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadExtender" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">

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
        <div class="menu-wrap">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>

                    <asp:ListView ID="rptArticleList" runat="server" ItemPlaceholderID="ItemPlaceholderIDArticleList" OnDataBound="rptArticleList_DataBound">
                        <LayoutTemplate>

                            <asp:PlaceHolder runat="server" ID="ItemPlaceholderIDArticleList"></asp:PlaceHolder>
                        </LayoutTemplate>
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
                    </asp:ListView>
                    <div class="pager">
                        <asp:DataPager ID="ListPager" PagedControlID="rptArticleList" runat="server" PageSize="9" OnPreRender="ListPager_PreRender" class="control-pager">
                            <Fields>

                                <asp:NumericPagerField ButtonType="Link" />

                                <asp:TemplatePagerField></asp:TemplatePagerField>
                            </Fields>
                        </asp:DataPager>
                </ContentTemplate>

                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ListPager" />
                </Triggers>
            </asp:UpdatePanel>

        </div>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FootExtender" runat="Server">
    <script src="/Styles/FancyBox-2.1.5/lib/jquery.mousewheel-3.0.6.pack.js" type="text/javascript"></script>
    <script src="/Styles/FancyBox-2.1.5/source/jquery.fancybox.pack.js" type="text/javascript"></script>
    <script src="/Styles/FancyBox-2.1.5/source/jquery.fancybox.js" type="text/javascript"></script>
    <script src="/Styles/FancyBox-2.1.5/source/helpers/jquery.fancybox-buttons.js" type="text/javascript"></script>
    <script src="/Styles/FancyBox-2.1.5/source/helpers/jquery.fancybox-media.js" type="text/javascript"></script>
    <script src="/Styles/FancyBox-2.1.5/source/helpers/jquery.fancybox-thumbs.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $(".fancy-box").fancybox({
                maxWidth: 1349,
                maxHeight: 630,
                fitToView: false,
                width: '819px',
                height: '630px',
                autoSize: false,
                closeClick: false,
                openEffect: 'none',
                closeEffect: 'none'
            });
        });

    </script>
</asp:Content>

