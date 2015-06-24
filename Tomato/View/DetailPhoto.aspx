<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterNoneCuisineBlock.master" AutoEventWireup="true"
    CodeFile="DetailPhoto.aspx.cs" Inherits="Vn_DetailPhoto" %>

<asp:Content ID="ContentHeader" runat="server" ContentPlaceHolderID="HeadExtender">
    <%-- Fancybox --%>
    <link href="/Styles/FancyBox-2.1.5/source/helpers/jquery.fancybox-buttons.css" rel="stylesheet" />
    <link href="/Styles/FancyBox-2.1.5/source/helpers/jquery.fancybox-thumbs.css" rel="stylesheet" />
    <link href="/Styles/FancyBox-2.1.5/source/jquery.fancybox.css" rel="stylesheet" />

    <link href="/Styles/highslide/highslide.css" rel="stylesheet" />
</asp:Content>
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


        <div class="gallery">
            <asp:Repeater ID="dlListimages" runat="server">
                <ItemTemplate>
                    <a class="highslide imgshow" rel="gallery" href="<%#Eval("HinhAnh")%>">
                        <img src="<%#Eval("HinhAnh") %>" alt="Picture" />
                    </a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="FootExtender">
    <%-- FancyBox library --%>
    <script src="/Styles/FancyBox-2.1.5/lib/jquery.mousewheel-3.0.6.pack.js" type="text/javascript"></script>
    <script src="/Styles/FancyBox-2.1.5/source/jquery.fancybox.pack.js" type="text/javascript"></script>
    <script src="/Styles/FancyBox-2.1.5/source/jquery.fancybox.js" type="text/javascript"></script>
    <script src="/Styles/FancyBox-2.1.5/source/helpers/jquery.fancybox-buttons.js" type="text/javascript"></script>
    <script src="/Styles/FancyBox-2.1.5/source/helpers/jquery.fancybox-media.js" type="text/javascript"></script>
    <script src="/Styles/FancyBox-2.1.5/source/helpers/jquery.fancybox-thumbs.js" type="text/javascript"></script>

    <%-- Show anh dùng fancybox --%>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".imgshow").fancybox({
                openEffect: 'none',
                closeEffect: 'none',
                closeBtn: false,
                helpers:
                {
                    title: { type: 'inside' },
                    buttons: {},
                    thumbs: {
                        width: 50,
                        height: 50
                    }
                }

            });
        });
    </script>

    <%-- Highslide library --%>
    <script src="/Styles/highslide/highslide-full.js"></script>
    <script src="/Styles/highslide/highslide-with-gallery.js"></script>

    <script type="text/javascript">
        hs.graphicsDir = '/Styles/highslide/graphics/';
        hs.align = 'center';
        hs.transitions = ['expand', 'crossfade'];
        hs.fadeInOut = true;
        hs.dimmingOpacity = 0.8;
        hs.outlineType = 'rounded-white';
        hs.captionEval = 'this.thumb.alt';
        hs.marginBottom = 105;
        hs.numberPosition = 'caption';
        // Add the slideshow providing the controlbar and the thumbstrip
        hs.addSlideshow({
            //slideshowGroup: 'group1',
            interval: 5000,
            repeat: false,
            useControls: true,
            overlayOptions: {
                className: 'text-controls',
                position: 'bottom center',
                relativeTo: 'viewport',
                offsetY: -60
            },
            thumbstrip: {
                position: 'bottom center',
                mode: 'horizontal',
                relativeTo: 'viewport'
            }
        });
    </script>


</asp:Content>
