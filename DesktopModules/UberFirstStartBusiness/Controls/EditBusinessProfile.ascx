<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditBusinessProfile.ascx.cs" Inherits="DotNetNuke.Modules.UberFirstStartBusiness.Controls.EditBusinessProfile" %>
<%@ Register Assembly="WatchersNET.CKEditor" Namespace="WatchersNET.CKEditor.Web" TagPrefix="cc1" %>
<%--<%@ Register Src="BusinessProfileByIndustry.ascx" TagPrefix="ebp" TagName="BusinessProfileByIndustry" %>--%>
<%@ Register Src="BusinessSecondaryLocation.ascx" TagPrefix="ebp" TagName="BusinessSecondaryLocation" %>
<%@ Register Src="BusinessUsers.ascx" TagPrefix="ebp" TagName="BusinessUsers" %>
<%@ Register Src="~/desktopmodules/UberTestBusinessProfile/Controls/OwnedBusinesses.ascx" TagPrefix="ebp" TagName="OwnedBusinesses" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx" %>



<style>
    tr
    {
        height: auto;
    }

    .auto-style1
    {
        width: 5%;
    }
</style>

<asp:MultiView ID="MultiViewCre" runat="server">
    <asp:View ID="ViewCre" runat="server">
        <asp:Panel ID="PanelError" runat="server">
            <asp:PlaceHolder ID="PlaceHolderError" runat="server"></asp:PlaceHolder>
        </asp:Panel>
        <asp:Panel ID="PanelBusinessEntry" runat="server">
            <table>
                <tr>                  
                    <td class="auto-style1">
                        <asp:Label ID="LabelBusinessName" runat="server" Text="Business Name: "></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBoxBusinessName">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="TextBoxBusinessName" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="LabelIsPublic" runat="server" Text="IsPublic: "></asp:Label></td>
                    <td class="auto-style2">
                        <asp:RadioButtonList ID="RadioButtonListIsPublic" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="true">Yes</asp:ListItem>
                            <asp:ListItem Selected="True" Value="false">No</asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>

                <tr id="TROne">
                    <td style="vertical-align: top" class="auto-style1">
                        <asp:Label ID="LabelShortDescription" runat="server" Text="Short Description: "></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBoxBusinessName">*</asp:RequiredFieldValidator>
                    </td>
                    <td style="">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <dnn:TextEditor runat="server" ID="TextBoxShortDescription" runat="server" width="100%" height="330px"></dnn:TextEditor>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="LabelBusinessMission" runat="server" Text="Business Mission: "></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBoxBusinessName">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <dnn:TextEditor runat="server" ID="TextBoxBusinessMission" runat="server" width="100%" height="330px"></dnn:TextEditor>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="LabelBusinessSlogan" runat="server" Text="Business Slogan: "></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBoxBusinessName">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <dnn:TextEditor runat="server" ID="TextBoxBusinessSlogan" runat="server" width="100%" height="330px"></dnn:TextEditor>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="LabelDescription" runat="server" Text="Description: "></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBoxBusinessName">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <dnn:TextEditor runat="server" ID="TextBoxDescription" runat="server" width="100%" height="330px"></dnn:TextEditor>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </td>

                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="LabelVision" runat="server" Text="Vision: "></asp:Label><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBoxBusinessName">*</asp:RequiredFieldValidator></td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <dnn:TextEditor runat="server" ID="TextBoxVision" runat="server" width="100%" height="330px"></dnn:TextEditor>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="LabelGoals" runat="server" Text="Goals: "></asp:Label><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBoxBusinessName">*</asp:RequiredFieldValidator></td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                                <dnn:TextEditor runat="server" ID="TextBoxGoals" runat="server" width="100%" height="330px"></dnn:TextEditor>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="LabelBusinessLogo" runat="server" Text="Business Logo: "></asp:Label></td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanelLogo" runat="server">
                            <ContentTemplate>
                                <asp:FileUpload ID="FileUploadBusinessLogo" runat="server" Width="399px" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="LabelEmailAddress" runat="server" Text="Email Address: "></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBoxBusinessName">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="TextBoxEmailAddress" runat="server" Width="300px"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="LabelPhone" runat="server" Text="Phone: "></asp:Label><asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBoxBusinessName">*</asp:RequiredFieldValidator></td>
                    <td>
                        <asp:TextBox ID="TextBoxPhone" runat="server" Width="300px"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="LabelFax" runat="server" Text="Fax: "></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBoxBusinessName">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxFax" runat="server" Width="300px"></asp:TextBox>

                    </td>
                </tr>

                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label14" runat="server" Text="Country: "></asp:Label><asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="DropDownListCountry">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanelCountry" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="DropDownListCountry" runat="server" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="DropDownListCountry_SelectedIndexChanged"></asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label2" runat="server" Text="State: "></asp:Label><asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="DropDownListState">*</asp:RequiredFieldValidator></td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanelState" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="DropDownListState" runat="server" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="DropDownListState_SelectedIndexChanged"></asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="LabelCity" runat="server" Text="City: "></asp:Label><asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="DropDownListCity">*</asp:RequiredFieldValidator></td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanelCity" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="DropDownListCity" runat="server" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="DropDownListCity_SelectedIndexChanged"></asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="LabelDistrict" runat="server" Text="District: ">
                        </asp:Label><asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="DropDownDistrict">*</asp:RequiredFieldValidator></td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="DropDownDistrict" runat="server" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="DropDownDistrict_SelectedIndexChanged"></asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="LabelPostalCode" runat="server" Text="PostalCode: "></asp:Label><asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBoxBusinessName">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxPostalCode" ErrorMessage="*" ValidationExpression="(^\d{5}(-\d{4})?$)|(^[ABCEGHJKLMNPRSTVXY]{1}\d{1}[A-Z]{1} *\d{1}[A-Z]{1}\d{1}$)"></asp:RegularExpressionValidator></td>
                    <td>
                        <asp:TextBox ID="TextBoxPostalCode" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="LabelAddress1" runat="server" Text="Address1: "></asp:Label><asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBoxBusinessName">*</asp:RequiredFieldValidator></td>
                    <td>
                        <asp:TextBox ID="TextBoxAddress1" runat="server" Width="300px"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="LabelAddress2" runat="server" Text="Address2: "></asp:Label></td>
                    <td class="auto-style2">
                        <asp:TextBox ID="TextBoxAddress2" runat="server" Width="300px"></asp:TextBox><br />
                    </td>
                </tr>

                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="LabelWebsite" runat="server" Text="Website: "></asp:Label><asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBoxBusinessName">*</asp:RequiredFieldValidator></td>
                    <td>
                        <asp:TextBox ID="TextBoxWebsite" runat="server" Width="300px"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="LabelFacebook" runat="server" Text="Facebook: "></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBoxFacebook" runat="server" Width="300px"></asp:TextBox><br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="LabelLinkedIn" runat="server" Text="LinkedIn: "></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBoxLinkedIn" runat="server" Width="300px"></asp:TextBox><br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="LabelTwitter" runat="server" Text="Twitter: "></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBoxTwitter" runat="server" Width="300px"></asp:TextBox><br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="LabelYouTube" runat="server" Text="YouTube: "></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBoxYouTube" runat="server" Width="300px"></asp:TextBox><br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="LabelGoogle" runat="server" Text="Google+: "></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBoxGoogle" runat="server" Width="300px"></asp:TextBox><br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="LabelBlog" runat="server" Text="Blog: "></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBoxBlog" runat="server" Width="300px"></asp:TextBox><br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="LabelShoppingCart" runat="server" Text="Shopping Cart: "></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBoxShoppingCart" runat="server" Width="300px"></asp:TextBox><br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="LabelForum" runat="server" Text="Forum: "></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBoxForum" runat="server" Width="300px"></asp:TextBox><br />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="PanelSubmit" runat="server">
            <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click1" />
        </asp:Panel>
    </asp:View>
    <asp:View ID="ViewRev" runat="server">
        <asp:Panel ID="PanelR" runat="server">           
            <asp:DataList ID="DataListContact" runat="server" DataKeyField="jobID" OnItemDataBound="DataListRreview_ItemDataBound">
                <HeaderTemplate>
                    Business Review
                </HeaderTemplate>
                <ItemTemplate>
                    Business Name:<p><%# Eval("BusinessName") %></p>
                    Public:<p><%# Eval("IsPublic") %></p><br />
                    Short Description:<p><%# Eval("ShortDescription") %></p>
                    Business Mission:<p><%# Eval("BusinessMissionStatement") %></p>
                    Slogan:<p><%# Eval("BusinessSlogan") %></p>
                    Description:<p><%# Eval("Description") %></p>
                    Vision:<p><%# Eval("Vision") %></p>
                    Goals:<p><%# Eval("Goals") %></p>
                    <asp:Image ID="ImageLogo" runat="server" ImageUrl=<%#String.Format("~/Portals/0/logos/{0}",Eval("BusinessLogo"))%>/>
                    Email Address:<p><%# Eval("EmailAddress") %></p>
                    Phone:<p><%# Eval("Phone") %></p>
                    Fax:<p><%# Eval("Fax") %></p>
                    Country:<p><%# Eval("CountryID") %></p>
                    Province/State:<p><%# Eval("CountryState") %></p>
                    City:<p><%# Eval("City") %></p>
                    PostalCode/Zip Code:<p><%# Eval("PostalCode") %></p>
                    Address1:<p><%# Eval("Address1") %></p>
                    Address2:<p><%# Eval("Address2") %></p>
                    Website:<p><%# Eval("Website") %></p>
                    Facebook:<p><%# Eval("Facebook") %></p>
                    LinkedIn:<p><%# Eval("LinkedIn") %></p>
                    Twitter:<p><%# Eval("Twitter") %></p>
                    YouTube:<p><%# Eval("YouTube") %></p>
                    Google+:<p><%# Eval("Google+") %></p>
                    Blog:<p><%# Eval("Blog") %></p>
                    Shoopping Cart:<p><%# Eval("ShoppingCart") %></p>
                    Forum:<p><%# Eval("Forum") %></p>
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:DataList>
        </asp:Panel>
    </asp:View>
</asp:MultiView>







