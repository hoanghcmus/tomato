<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterNoneCuisineBlock.master" AutoEventWireup="true" CodeFile="ArticleByCatgory.aspx.cs" Inherits="En_ArticleByCatgory" %>

<%@ Import Namespace="DataAccess.Help" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadExtender" runat="Server">
    <link href="/Styles/CSS/Desktop.Module.css" rel="stylesheet" />
    <link href="/Styles/CSS/SmartPhone.Module.css" rel="stylesheet" />
    <link href="/Styles/CSS/Tablet.Module.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

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
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>

                <asp:ListView ID="rptArticleList" runat="server" ItemPlaceholderID="ItemPlaceholderIDArticleList" OnDataBound="rptArticleList_DataBound">
                    <LayoutTemplate>

                        <asp:PlaceHolder runat="server" ID="ItemPlaceholderIDArticleList"></asp:PlaceHolder>
                    </LayoutTemplate>
                    <ItemTemplate>

                        <div class="item_videos">
                            <div class="url_videos">
                                <a href='<%#ShowArticleCat(Container.DataItem, "ArticleCatDuongDan") %>'>
                                    <img src='<%#Eval("HinhAnh") %>' alt="Hình ảnh" />
                                    </i></a>
                            </div>
                            <div class="name_videos">
                                <a href='<%#ShowArticleCat(Container.DataItem, "ArticleCatDuongDan") %>'>
                                    <%#ShowArticleCat(Container.DataItem, "ArticleCatTieuDe") %></a>
                                </h4>
                                <p class="meta">

                                    <strong><%=Resources.Resource.description %>:</strong>
                                    <%#ShowArticleCat(Container.DataItem, "laytomtat") %>
                                </p>

                            </div>
                        </div>


                    </ItemTemplate>
                </asp:ListView>

                <asp:DataPager ID="ListPager" PagedControlID="rptArticleList" runat="server" PageSize="1" OnPreRender="ListPager_PreRender" class="control-pager">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false" ShowPreviousPageButton="true"
                            ShowNextPageButton="false" />
                        <asp:NumericPagerField ButtonType="Link" />
                        <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="false" ShowPreviousPageButton="false" />
                        <asp:TemplatePagerField></asp:TemplatePagerField>
                    </Fields>
                </asp:DataPager>

            </ContentTemplate>

            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ListPager" />
            </Triggers>
        </asp:UpdatePanel>

    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootExtender" runat="Server">
</asp:Content>

