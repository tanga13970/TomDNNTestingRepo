<%@ Control Language="C#" Inherits="DotNetNuke.Modules.UberFirstStartBusiness.View" AutoEventWireup="false" CodeBehind="View.ascx.cs" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>

<style>
    div.Cell
    {
        width: 100%;
        float: left;
    }

    .One
    {
        vertical-align: central;
        float: left;
        width: 300px;
        padding-left: 3px;
    }

    .Two
    {
        vertical-align: central;
        text-align: center;
        float: right;
    }
</style>
<%--<dnn:DnnJsInclude runat="server" FilePath="jquery/jquery-1.9.1.js" PathNameAlias="SharedScripts" />
<dnn:DnnJsInclude runat="server" FilePath="jquery/jquery-ui.js" PathNameAlias="SharedScripts" />
<dnn:DnnCssInclude  runat="server" FilePath="stylesheets/jquery-ui.css" PathNameAlias="SharedScripts" />--%>
<%--<a id="top5opener" href="javascript:showTop5();">Show Top 5</a>
<div id="top5" style="display: none">
    <a href="javascript:hideTop5();">Hide Top 5</a>
    <div class="yourElements">
        <ol>
            <li>First item</li>
            <li>Second item</li>
            <li>Third item</li>
            <li>Fourth item</li>
            <li>Fifth item</li>
        </ol>
    </div>
</div>--%>
<asp:Panel ID="Panel1" runat="server" BorderColor="Black" BorderWidth="5px" Height="235px" Width="100%">
    <h2>Create Business Profile</h2>
    <div style="width: 100%" class="Cell">

        <div style="width: 49%" class="One">
            <asp:Label ID="Label1" runat="server" Text="Enter Company Name "></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxBusinessName" ErrorMessage="*"></asp:RequiredFieldValidator>
        </div>
        <div style="width: 50%" class="Two">
            <asp:TextBox ID="TextBoxBusinessName" runat="server" Width="95%"></asp:TextBox>
        </div>
    </div>
    <div style="width: 100%" class="Cell">
        <div style="width: 49%" class="One">
            <asp:Label ID="Label2" runat="server" Text="User: "></asp:Label>
        </div>
        <div style="width: 50%; text-align: center" class="Two">
            <asp:Label ID="LabelUserName" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <div style="width: 100%" class="Cell">
        <div style="width: 49%" class="One">
            <asp:Label ID="LabelError" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
        <div style="width: 50%; text-align: center" class="Two">
            <asp:Button ID="ButtonCreateBP" Width="95%" runat="server" Text="Create Business Profile" OnClick="ButtonCreateBP_Click" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Smaller" Font-Strikeout="False" Height="30px" />
        </div>
    </div>
    <div style="width: 100%" class="Cell">
        <div style="width: 44%" class="One">
            <asp:Label ID="Label3" runat="server" Text="Total Users Purchased"></asp:Label>
        </div>
        <div style="width: 5%" class="One">
            <asp:Label ID="LabelTotal" runat="server" Text=""></asp:Label>
        </div>
        <div style="width: 45%" class="Two"></div>
        <div style="width: 5%" class="One">
            <asp:Label ID="LabelVailible" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <div style="width: 100%" class="Cell">
        <div style="width: 44%" class="One">
            <asp:Label ID="Label4" runat="server" Text="Business Location's"></asp:Label>
        </div>
        <div style="width: 5%" class="One">
            <asp:Label ID="LabelLocation" runat="server" Text=""></asp:Label>
        </div>
        <div style="width: 50%; text-align: right" class="One">
            <asp:Button ID="ButtonAddLocation" Width="80%" runat="server" Text="Add Business Location" OnClick="ButtonAddLocation_Click" Font-Bold="True" Font-Size="Smaller" Height="30px" Enabled="False" />
        </div>
    </div>
    <div style="width: 100%" class="Cell">
        <div style="width: 44%" class="One">
            <asp:Label ID="Label5" runat="server" Text="Related Business's"></asp:Label>
        </div>
        <div style="width: 5%" class="One">
            <asp:Label ID="LabelRelatedBusiness" runat="server" Text=""></asp:Label>
        </div>
        <div style="width: 50%; text-align: right" class="One">
            <asp:Button ID="ButtonRelatedBusiness" Width="80%" runat="server" Text="Add Related Business" Font-Bold="True" Font-Size="Smaller" Height="30px" OnClick="ButtonRelatedBusiness_Click" Enabled="False" />
        </div>
    </div>
</asp:Panel>
<br />
<a id="Profile" href="javascript:showProfile();" style="display:none">Show Top 5</a>
<div id="ProfileContent" style="display: none">
    <a href="javascript:hideProfile();" style="display:none">Hide Top 5</a>
    <div class="yourElements">
        <asp:Panel ID="Panel3" runat="server" BorderColor="Black" BorderWidth="5px" Height="565px" Width="100%">
            <h2>Business Profile Quickstart</h2>
            <div style="width: 100%" class="Cell">

                <div style="width: 45%" class="One">
                    <asp:Label ID="Label10" runat="server" Text="Company Name "></asp:Label>
                </div>
                <div style="width: 50%" class="One">
                    <asp:DropDownList ID="DropDownListBusinessName" Width="95%" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div style="width: 100%" class="Cell">
                <div style="width: 45%" class="One">
                    <asp:Label ID="Label11" runat="server" Text="Primary Phone# "></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxBusinessName" ErrorMessage="*"></asp:RequiredFieldValidator>
                </div>
                <div style="width: 50%" class="One">
                    <asp:TextBox ID="TextBoxPhone" runat="server" Width="95%"></asp:TextBox>
                </div>
            </div>
            <div style="width: 100%" class="Cell">
                <div style="width: 45%" class="One">
                    <asp:Label ID="Label12" runat="server" Text="Unit "></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxBusinessName" ErrorMessage="*"></asp:RequiredFieldValidator>
                </div>
                <div style="width: 50%" class="One">
                    <asp:TextBox ID="TextBoxUnit" runat="server" Width="95%"></asp:TextBox>
                </div>
            </div>
            <div style="width: 100%" class="Cell">
                <div style="width: 45%" class="One">
                    <asp:Label ID="Label15" runat="server" Text="Street "></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxBusinessName" ErrorMessage="*"></asp:RequiredFieldValidator>
                </div>
                <div style="width: 50%" class="One">
                    <asp:TextBox ID="TextBoxStreet" runat="server" Width="95%"></asp:TextBox>
                </div>
            </div>
            <div style="width: 100%" class="Cell">
                <div style="width: 45%" class="One">
                    <asp:Label ID="Label16" runat="server" Text="Country "></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxBusinessName" ErrorMessage="*"></asp:RequiredFieldValidator>
                </div>
                <div style="width: 50%" class="One">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="DropDownListCountry" runat="server" Width="95%" AutoPostBack="True" OnSelectedIndexChanged="DropDownListCountry_SelectedIndexChanged"></asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div style="width: 100%" class="Cell">
                <div style="width: 45%" class="One">
                    <asp:Label ID="Label19" runat="server" Text="Province / State "></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxBusinessName" ErrorMessage="*"></asp:RequiredFieldValidator>
                </div>
                <div style="width: 50%" class="One">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="DropDownListState" runat="server" Width="95%" AutoPostBack="True" OnSelectedIndexChanged="DropDownListState_SelectedIndexChanged"></asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div style="width: 100%" class="Cell">
                <div style="width: 45%" class="One">
                    <asp:Label ID="Label20" runat="server" Text="City "></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBoxBusinessName" ErrorMessage="*"></asp:RequiredFieldValidator>
                </div>
                <div style="width: 50%" class="One">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="DropDownListCity" runat="server" Width="95%" AutoPostBack="True"></asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div style="width: 100%" class="Cell">
                <div style="width: 45%" class="One">
                    <asp:Label ID="Label21" runat="server" Text="Postal Code "></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBoxBusinessName" ErrorMessage="*"></asp:RequiredFieldValidator>
                </div>
                <div style="width: 50%" class="One">
                    <asp:TextBox ID="TextBoxPostalCode" runat="server" Width="95%"></asp:TextBox>
                </div>
            </div>
            <div style="width: 100%" class="Cell">
                <div style="width: 45%" class="One">
                    <asp:Label ID="Label22" runat="server" Text="Industry Sector "></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBoxBusinessName" ErrorMessage="*"></asp:RequiredFieldValidator>
                </div>
                <div style="width: 50%" class="One">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="DropDownListSector" runat="server" Width="95%" OnSelectedIndexChanged="DropDownListSector_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div style="width: 100%" class="Cell">
                <div style="width: 45%" class="One">
                    <asp:Label ID="Label23" runat="server" Text="Industry Subsector "></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBoxBusinessName" ErrorMessage="*"></asp:RequiredFieldValidator>
                </div>
                <div style="width: 50%" class="One">
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="DropDownListSubsector" runat="server" Width="95%" OnSelectedIndexChanged="DropDownListSubsector_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div style="width: 100%" class="Cell">
                <div style="width: 45%" class="One">
                    <asp:Label ID="Label24" runat="server" Text="Industry Group "></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TextBoxBusinessName" ErrorMessage="*"></asp:RequiredFieldValidator>
                </div>
                <div style="width: 50%" class="One">
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="DropDownListGroup" runat="server" Width="95%" OnSelectedIndexChanged="DropDownListGroup_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div style="width: 100%" class="Cell">
                <div style="width: 45%" class="One">
                    <asp:Label ID="Label25" runat="server" Text="Industry "></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TextBoxBusinessName" ErrorMessage="*"></asp:RequiredFieldValidator>
                </div>
                <div style="width: 50%" class="One">
                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="DropDownListIndustry" runat="server" Width="95%" OnSelectedIndexChanged="DropDownListIndustry_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div style="width: 100%" class="Cell">
                <div style="width: 45%" class="One">
                    <asp:Label ID="Label26" runat="server" Text="Sepecific Industry "></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="TextBoxBusinessName" ErrorMessage="*"></asp:RequiredFieldValidator>
                </div>
                <div style="width: 50%" class="One">
                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="DropDownListSepecificIndustry" runat="server" Width="95%" AutoPostBack="True"></asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div style="width: 100%" class="Cell">
                <div style="width: 45%" class="One">
                    <asp:Label ID="Label27" runat="server" Text="Website "></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="TextBoxBusinessName" ErrorMessage="*"></asp:RequiredFieldValidator>
                </div>
                <div style="width: 50%" class="One">
                    <asp:TextBox ID="TextBoxWebsite" runat="server" Width="95%"></asp:TextBox>
                </div>
            </div>
            <div style="width: 100%" class="Cell">
                <div style="width: 45%" class="One">
                    <asp:Label ID="Label28" runat="server" Text="Make Public "></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="TextBoxBusinessName" ErrorMessage="*"></asp:RequiredFieldValidator>
                </div>
                <div style="width: 50%; text-align: right" class="One">
                    <asp:RadioButtonList ID="RadioButtonListPublic" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1">Yes</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div style="width: 100%" class="Cell">
                <div style="width: 45%" class="One">
                </div>
                <div style="width: 50%; text-align: center" class="Two">
                    <asp:Button ID="ButtonSave" runat="server" Text="Save Business Profile" Font-Bold="True" Font-Size="Smaller" Height="30px" />
                </div>
            </div>
        </asp:Panel>

        <br />
        <asp:Panel ID="Panel2" runat="server" BorderColor="Black" BorderWidth="5px" Height="190px" Width="100%">
            <h2>Create Manage Business Users</h2>
            <div style="width: 100%" class="Cell">
                <div style="width: 49%" class="One">
                    <asp:Label ID="Label6" runat="server" Text="Company Name "></asp:Label>
                </div>
                <div style="width: 50%" class="Two">
                    <asp:DropDownList ID="DropDownListBusinesses" Width="95%" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div style="width: 100%" class="Cell">
                <div style="width: 49%" class="One">
                    <asp:Label ID="Label7" runat="server" Text="User: "></asp:Label>
                </div>
                <div style="width: 50%; text-align: center" class="Two">
                    <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div style="width: 100%" class="Cell">
                <div style="width: 44%" class="One">
                    <asp:Label ID="Label9" runat="server" Text="Total Users Purchased"></asp:Label>
                </div>
                <div style="width: 5%" class="One">
                    <asp:Label ID="Label17" runat="server" Text=""></asp:Label>
                </div>
                <div style="width: 45%" class="Two"></div>
                <div style="width: 5%" class="One">
                    <asp:Label ID="Label18" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div style="width: 100%" class="Cell">
                <div style="width: 44%" class="One">
                    <asp:Label ID="Label13" runat="server" Text="Created Business Users"></asp:Label>
                </div>
                <div style="width: 5%">
                    <asp:Label ID="Label14" runat="server" Text="" ForeColor="Red"></asp:Label>
                </div>
                <div style="width: 50%" class="Two">
                    <asp:Button ID="ButtonAddBusinessUser" Width="80%" runat="server" Text="Add Business User" Font-Bold="True" Font-Size="Smaller" Height="30px" />
                </div>
            </div>
            <div style="width: 100%" class="Cell">
                <div style="width: 44%" class="One"></div>
                <div style="width: 5%"></div>
                <div style="width: 50%" class="Two">
                    <asp:Button ID="ButtonamagerBusinessUser" Width="80%" runat="server" Text="Manage Business Usres" Font-Bold="True" Font-Size="Smaller" Height="30px" />
                </div>
            </div>
        </asp:Panel>
    </div>
</div>
<dnn:DnnJsInclude runat="server" FilePath="~/desktopmodules/UberFirstStartBusiness/Components/UberJava.js" />
