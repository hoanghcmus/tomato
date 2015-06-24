<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_PhanTrang.ascx.cs" Inherits="Admin_Mger_UserControl_UC_PhanTrang" %>
<div class="pagination">
    <ul>
        <li><a>Trang
            <asp:Label ID="lblCurrentPage" runat="server" />/
            <asp:Label ID="lblHowManyPages" runat="server" />
        </a></li>
        <li>
            <asp:HyperLink ID="lnkPrevious" runat="server" Text="Trở về" CssClass="link" />
        </li>
        <asp:Repeater runat="server" ID="repPager">
            <ItemTemplate>
                <li>
                    <asp:HyperLink runat="server" ID="lnk" Text='<%#Eval("Page") %>' CssClass='<%#Eval("Url").ToString()=="" ? "current" : "link" %>'
                        NavigateUrl='<%#Eval("Url") %>' />
                </li>
            </ItemTemplate>
        </asp:Repeater>
        <li>
            <asp:HyperLink ID="lnkNext" runat="server" Text="Kế tiếp" CssClass="link" />
        </li>
    </ul>
</div>