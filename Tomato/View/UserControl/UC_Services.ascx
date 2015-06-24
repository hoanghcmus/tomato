<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_Services.ascx.cs" Inherits="Vn_Vn_Control_UC_Services" %>
<div class="title_ServicPromo">
    <h1>
        Dịch vụ 
    </h1>
</div>
<div class="content_ServicPromo">
    <asp:Repeater ID="dlProdList" runat="server">
        <ItemTemplate>
            <div class="list_services">
                <div class="img_services">
                    <a href='<%#DataAccess.Connect.Link.DetailServices(Eval("TieuDe_Vn").ToString(),Eval("ID").ToString()) %>'
                        class="image">
                        <img src='<%#Eval("HinhAnh") %>' alt='<%#HttpUtility.HtmlEncode(Eval("TieuDe_Vn").ToString()) %>' />
                    </a>
                </div>
                <div class="des_services">
                    <h4>
                        <a href='<%#DataAccess.Connect.Link.DetailServices(Eval("TieuDe_Vn").ToString(),Eval("ID").ToString()) %>'>
                            <%#HttpUtility.HtmlEncode(Eval("TieuDe_Vn").ToString())%></a>
                    </h4>
                    <p class="text">
                        <%#Eval("TomTat_Vn")%></p>
                </div>
            </div>
            <hr class="sv" />
        </ItemTemplate>
        <AlternatingItemTemplate>
            <div class="list_services">
                <div class="img_services">
                    <a href='<%#DataAccess.Connect.Link.DetailServices(Eval("TieuDe_Vn").ToString(),Eval("ID").ToString()) %>'
                        class="image">
                        <img src='<%#Eval("HinhAnh") %>' alt='<%#HttpUtility.HtmlEncode(Eval("TieuDe_Vn").ToString()) %>' />
                    </a>
                </div>
                <div class="des_services">
                    <h4>
                        <a href='<%#DataAccess.Connect.Link.DetailServices(Eval("TieuDe_Vn").ToString(),Eval("ID").ToString()) %>'>
                            <%#HttpUtility.HtmlEncode(Eval("TieuDe_Vn").ToString())%></a>
                    </h4>
                    <p class="text">
                        <%#Eval("TomTat_Vn")%></p>
                </div>
            </div>
        </AlternatingItemTemplate>
    </asp:Repeater>
</div>
