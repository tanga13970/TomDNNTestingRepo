<%@ Control Language="C#" Inherits="Uberistic.Modules.UberSidePane.View" AutoEventWireup="false" CodeBehind="View.ascx.cs" %>


<asp:Panel ID="Panel1" runat="server" BorderColor="Black" BorderStyle="Ridge" BorderWidth="3px">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Image ID="ImageLogo" alt="br uberistic" Width="200" Height="188" runat="server" ImageUrl="~/DesktopModules/TextModule3/Images/uberistic_logo.png" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <p style="text-align: left"><strong>Business Slogan</strong></p>
    <div class="smalltext">
        <asp:Literal ID="LiteralSlogan" runat="server" Text=""></asp:Literal>
    </div>
    <p style="text-align: left">
        <strong>
            <asp:Label ID="LabelBusinessName" runat="server" Text=""></asp:Label></strong>
    </p>
    <div class="smalltext">
        <asp:Label ID="LabelAddress" runat="server" Text=""></asp:Label>
    </div>
    <asp:PlaceHolder ID="PlaceHolderPhone" runat="server">
        <p style="text-align: left"><strong>Phone</strong></p>
        <div class="smalltext">
            <asp:Label ID="LabelPhone" runat="server" Text="Label"></asp:Label><br>
        </div>
    </asp:PlaceHolder>
    <p style="text-align: left"><strong>Internet</strong></p>
    <div class="smalltext">
        <asp:PlaceHolder ID="PlaceHolderEmail" runat="server">Email:
                <asp:HyperLink ID="HyperLinkEmail" runat="server"></asp:HyperLink>
        </asp:PlaceHolder>
        Website:
            <asp:HyperLink ID="HyperLinkWebsite" runat="server"></asp:HyperLink>
    </div>
    <p style="text-align: left"><strong>Business Online Presence</strong></p>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
        <div class="smalltext">
            <asp:Image ID="Image2" alt="twitter" Width="16" Height="16" runat="server" ImageUrl="~/desktopmodules/UberSidePane/twitter.png" /><asp:HyperLink ID="HyperLinktwitter" runat="server"> twitter</asp:HyperLink>
        </div>
    </asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder2" runat="server">
        <div class="smalltext">
            <asp:Image ID="Image3" alt="twitter" Width="16" Height="16" runat="server" ImageUrl="~/desktopmodules/UberSidePane/facebook.png" /><asp:HyperLink ID="HyperLinkfacebook" runat="server"> facebook</asp:HyperLink>
        </div>
    </asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder3" runat="server">
        <div class="smalltext">
            <asp:Image ID="Image4" alt="twitter" Width="16" Height="16" runat="server" ImageUrl="~/desktopmodules/UberSidePane/linkedin.png" /><asp:HyperLink ID="HyperLinklinkedin" runat="server"> linkedin</asp:HyperLink>
        </div>
    </asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder4" runat="server">
        <div class="smalltext">
            <asp:Image ID="Image5" alt="twitter" Width="16" Height="16" runat="server" ImageUrl="~/desktopmodules/UberSidePane/stumbleupon.png" /><asp:HyperLink ID="HyperLinkYouToBu" runat="server"> YouTube</asp:HyperLink>
        </div>
    </asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder5" runat="server">
        <div class="smalltext">
            <asp:Image ID="Image6" alt="twitter" Width="16" Height="16" runat="server" ImageUrl="~/desktopmodules/UberSidePane/flickr.png" />
            <asp:HyperLink ID="HyperLinkGoogle" runat="server"> Google+</asp:HyperLink>
        </div>
    </asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder6" runat="server">
        <div class="smalltext">
            <asp:Image ID="Image7" alt="twitter" Width="16" Height="16" runat="server" ImageUrl="~/desktopmodules/UberSidePane/delicious.png" /><asp:HyperLink ID="HyperLinkBlog" runat="server"> Blog</asp:HyperLink>

        </div>
    </asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder7" runat="server">
        <div class="smalltext">
            <asp:Image ID="Image1" alt="twitter" Width="16" Height="16" runat="server" ImageUrl="~/desktopmodules/UberSidePane/delicious.png" /><asp:HyperLink ID="HyperLinkShoppingCart" runat="server"> ShoppingCart</asp:HyperLink>

        </div>
    </asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder8" runat="server">
        <div class="smalltext">
            <asp:Image ID="Image8" alt="twitter" Width="16" Height="16" runat="server" ImageUrl="~/desktopmodules/UberSidePane/delicious.png" /><asp:HyperLink ID="HyperLinkForum" runat="server"> Forum</asp:HyperLink>

        </div>
    </asp:PlaceHolder>
</asp:Panel>
