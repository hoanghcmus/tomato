<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_Hotline.ascx.cs" Inherits="UserControl_UC_Hotline" %>
<div class="hotline">
    <asp:Repeater ID="dlhotro" runat="server">
        <ItemTemplate>
            <span>HOTLINE: <%#(Eval("SDT").ToString())%></span>
        </ItemTemplate>
    </asp:Repeater>
</div>

