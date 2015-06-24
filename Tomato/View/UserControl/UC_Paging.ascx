<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_Paging.ascx.cs" Inherits="Vn_Vn_Control_Paging" %>
<div class="pager">
    Trang
    <asp:Label ID="lblCurrentPage" runat="server" />
    /
    <asp:Label ID="lblHowManyPages" runat="server" />
    |
    <asp:HyperLink ID="lnkPrevious" runat="server" Text="Trở về" CssClass="link"/>
    <asp:Repeater runat="server" ID="repPager">
        <ItemTemplate>
            <asp:HyperLink runat="server" ID="lnk" Text='<%#Eval("Page") %>' CssClass='<%#Eval("Url").ToString()=="" ? "current" : "link" %>'
                NavigateUrl='<%#Eval("Url") %>'/>
        </ItemTemplate>
    </asp:Repeater>
    <asp:HyperLink ID="lnkNext" runat="server" Text="Kế tiếp" CssClass="link"/>
</div>