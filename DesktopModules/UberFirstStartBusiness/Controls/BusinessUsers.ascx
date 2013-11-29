<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BusinessUsers.ascx.cs" Inherits="DotNetNuke.Modules.UberFirstStartBusiness.Controls.BusinessUsers" %>

<asp:Label ID="LabelUBP" runat="server" Text="Label"></asp:Label>
<asp:Panel ID="Panel1" runat="server">
    <asp:DropDownList ID="DropDownListPrivilegeStatus" runat="server" Width="200px" />
    <asp:DropDownList ID="DropDownListSecondaryLocation" runat="server" Width="200px" />
</asp:Panel>
<asp:Panel ID="Panel2" runat="server">
    <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click" BorderStyle="Outset" />
</asp:Panel>
