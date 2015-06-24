<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterNoneCuisineBlock.master" AutoEventWireup="true"
    CodeFile="DetailArticle.aspx.cs" Inherits="Vn_DetailArticle" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="galery-title-bar">
        <div class="gallery-title">
            <div class="galery-title-bar-icon">
                <img src="/Design/cachua.png" alt="pic" class="img" />
            </div>
            <h1>
                <asp:literal id="ltrCtTitle" runat="server"></asp:literal>
            </h1>
        </div>
    </div>
    <div class="body-right-content">


        <div class="content-detail">
            <h4>
                <asp:label id="lblTitle" runat="server" />
            </h4>
            <p class="meta">
                <%--<asp:Label ID="lblCreatedDate" runat="server" />--%>
                <asp:label id="lbLuotXem" runat="server" />
            </p>
            <div class="text">
                <asp:label id="lblFullText" runat="server" />
            </div>
            <%--<p class="meta">
                <asp:Label ID="lblModifiedDate" runat="server" />
            </p>--%>
        </div>


        <div class="articlerang">
            <h4 id="RealtiveArticle" runat="server"><%=Resources.Resource.related_article %></h4>
            <asp:repeater id="dlarticlerang" runat="server">
                <ItemTemplate>
                    <div class="item">
                        <div class="Description">
                            <img src="/Design/cachua.png" alt="article" />
                            <a href='<%#ShowRelatedArticle(Container.DataItem, "RelatedArticleDuongDan") %>'>
                                <%#ShowRelatedArticle(Container.DataItem, "RelatedArticleTieuDe") %>
                            </a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:repeater>
        </div>


    </div>

</asp:Content>
