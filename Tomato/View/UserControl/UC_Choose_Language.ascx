<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_Choose_Language.ascx.cs" Inherits="En_En_Control_UC_Choose_Language" %>

<div class="lang-bar">
    <div class="lang-item">
        <asp:LinkButton ID="btnVn" runat="server" OnClick="btnVn_Click">
            <div class="lang-icon">
                <img src="/Design/vi.png" class="img" />
            </div>
            <div class="lang-name"><span>Việt Nam</span></div>
        </asp:LinkButton>
    </div>
    <div class="lang-item">
        <asp:LinkButton ID="btnEn" runat="server" OnClick="btnEn_Click">
            <div class="lang-icon">
                <img src="/Design/en.png" class="img" />
            </div>
            <div class="lang-name"><span>English</span></div>
        </asp:LinkButton>
    </div>
    <div class="lang-item">
        <asp:LinkButton ID="btnRus" runat="server" OnClick="btnRus_Click">
            <div class="lang-icon">
                <img src="/Design/ru.png" class="img" />
            </div>
            <div class="lang-name"><span>Pусский</span></div>
        </asp:LinkButton>
    </div>

</div>
