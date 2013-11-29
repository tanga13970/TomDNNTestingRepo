<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BusinessSecondaryLocation.ascx.cs" Inherits="DotNetNuke.Modules.UberFirstStartBusiness.Controls.BusinessSecondaryLocation" %>

<asp:Panel ID="PanelBusinessSecondaryLocation" runat="server">
    <asp:Label ID="LabelUBP" runat="server" Text="Label"></asp:Label>
    <table>
        <tr>
            <td style="text-align: right">
                <asp:Label ID="Label1" runat="server" Text="Business Secondary Location Name: "></asp:Label></td>
            <td>
                <asp:TextBox ID="TextBoxSecondaryLocation" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align: right"><asp:Label ID="Label2" runat="server" Text="Address1: "></asp:Label></td>
            <td><asp:TextBox ID="TextBoxAddress1" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align: right"><asp:Label ID="Label3" runat="server" Text="Address2: "></asp:Label></td>
            <td><asp:TextBox ID="TextBoxAddress2" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align: right"><asp:Label ID="Label4" runat="server" Text="City: "></asp:Label></td>
            <td><asp:TextBox ID="TextBoxCity" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align: right"><asp:Label ID="Label5" runat="server" Text="Region: "></asp:Label></td>
            <td><asp:TextBox ID="TextBoxRegion" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align: right"><asp:Label ID="Label6" runat="server" Text="Country: "></asp:Label></td>
            <td><asp:TextBox ID="TextBoxCountry" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align: right"><asp:Label ID="Label7" runat="server" Text="Post Code: "></asp:Label></td>
            <td><asp:TextBox ID="TextBoxPostcode" runat="server"></asp:TextBox></td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="PanelSubmit" runat="server">
    <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click" />
</asp:Panel>
