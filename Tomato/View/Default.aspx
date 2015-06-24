<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterHasSlide.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Vn_Default" %>

<%@ Import Namespace="DataAccess.Help" %>
<asp:Content ID="Header" ContentPlaceHolderID="HeadExtender" runat="Server">
</asp:Content>
<asp:Content ID="RightMainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="galery-title-bar">
        <div class="gallery-title">
            <div class="galery-title-bar-icon">
                <img src="/Design/cachua.png" alt="pic" class="img" />
            </div>
            <h1>
                <asp:Literal ID="ltrCtTitle" runat="server"></asp:Literal></h1>
        </div>
    </div>
    <div class="body-right-content">

        <asp:Repeater ID="rptListCuisine" runat="server">
            <ItemTemplate>
                <div class="block30">
                    <a href='<%#ShowCuisine(Container.DataItem, "CuisineDuongDan") %>' class="link">
                        <div class="block30-figure">
                            <img src="<%#Eval("HinhAnh") %>" class="img" />
                        </div>
                        <div class="block30-title">
                            <h1><%#ShowCuisine(Container.DataItem, "CuisineTieuDe") %></h1>
                        </div>
                        <div class="block30-content">
                            <p>
                                <%#ShowCuisine(Container.DataItem, "CuisineTomtat") %>
                            </p>
                        </div>
                        <div class="read-more">
                            <span class="link"><%=Resources.Resource.more %>
                            </span>
                        </div>
                    </a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        

        <%-- Hình anh hoặc thể loại món ăn --%>
        
    </div>

</asp:Content>
<asp:Content ID="Footer" ContentPlaceHolderID="FootExtender" runat="Server">
</asp:Content>

