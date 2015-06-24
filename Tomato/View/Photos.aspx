<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterNoneCuisineBlock.master" AutoEventWireup="true"
    CodeFile="Photos.aspx.cs" Inherits="Vn_Photos" %>

<%@ Register Src="~/View/UserControl/UC_Paging.ascx" TagName="UC_Paging" TagPrefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">


    <div class="galery-title-bar">
        <div class="gallery-title">
            <div class="galery-title-bar-icon">
                <img src="/Design/cachua.png" alt="pic" class="img" />
            </div>
            <h1>
                <asp:Literal ID="ltrCtTitle" runat="server" Text="<%$Resources:Resource,picture %>"></asp:Literal>
            </h1>
        </div>
    </div>
    <div class="body-right-content">


        <div class="menu-wrap">
            <asp:Repeater ID="dlListImg" runat="server">
                <ItemTemplate>

                    <div class="menu-item">
                        <a href="<%#ShowImg(Container.DataItem,"ImageDuongDan") %>" class="link">
                            <div class="menu-figure">
                                <%#ShowImg(Container.DataItem,"ImgOrClip") %>
                            </div>
                            <%--<div class="menu-price"><span>150.000 VNĐ</span></div>--%>
                            <div class="menu-title">
                                <h1><%#ShowImg(Container.DataItem,"ImageTieuDe") %></h1>
                            </div>
                        </a>
                    </div>

                </ItemTemplate>
            </asp:Repeater>
            <uc1:UC_Paging ID="pagerBottom" runat="server" />
        </div>

    </div>



</asp:Content>
