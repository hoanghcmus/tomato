<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_PhotoShow.ascx.cs"
    Inherits="Vn_Vn_Control_UC_PhotoShow" %>
<div class="showlistimg">
    <div class="imgprevious">
        <a id="demo5-backward">
            <img src="../Design/previous.png" /></a>
    </div>
    <div class="imglist">
        <div id="demo5" class="scroll-img">
            <ul>
                <asp:Repeater ID="dlNewsHot" runat="server">
                    <ItemTemplate>
                        <li><a class="highslide" onclick="return hs.expand(this)" href="<%#Eval("HinhAnh")%>">
                            <img alt="" src='<%#Eval("HinhAnh")%>' />
                        </a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
    <div class="imgnext">
        <a id="demo5-forward">
            <img src="../Design/next.png" /></a>
    </div>
</div>
