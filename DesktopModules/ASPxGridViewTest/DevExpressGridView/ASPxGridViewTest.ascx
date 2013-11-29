<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ASPxGridViewTest.ascx.cs" Inherits="_ASPxGridViewTest" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v11.2, Version=11.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTreeList.Export" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.ASPxTreeList.v11.2, Version=11.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v11.2, Version=11.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.ASPxGridView.v11.2, Version=11.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>


    
        <div>
            <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="True" OnDataBound="ASPxGridView_DataBound" OnCustomColumnDisplayText="ASPxGridView_CustomColumnDisplayText" OnCustomUnboundColumnData="ASPxGridView_CustomUnboundColumnData" OnDetailRowExpandedChanged="ASPxGridView1_DetailRowExpandedChanged" OnDetailsChanged="ASPxGridView1_DetailsChanged" OnHtmlDataCellPrepared="ASPxGridView1_HtmlDataCellPrepared">
                <Settings ShowGroupPanel="True" />
                <SettingsDetail ShowDetailButtons="true" ShowDetailRow="true" AllowOnlyOneMasterRowExpanded="true"/>
                <Templates>
                    <DetailRow>
                        <dx:ASPxGridView ID="ASPxGridView2" runat="server" DataSourceID="SqlDataSource2" OnDataBound="ASPxGridView_DataBound"></dx:ASPxGridView>
                    </DetailRow>
                </Templates>
				<SettingsPager pagesize="2"/>
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SiteSqlServer %>" ProviderName="<%$ ConnectionStrings:SiteSqlServer.ProviderName %>" SelectCommand="SELECT [EmployeeID] AS Employee_ID, [FirstName] AS First_Name, [Title], [LastName] AS Last_Name, [BirthDate] AS Birth_Date, [City], [Region], [Country], [ReportsTo] AS Reports_To FROM [Employees]" DeleteCommand="DELETE FROM [Employees] WHERE [EmployeeID] = @Employee_ID" InsertCommand="INSERT INTO [Employees] ([FirstName], [Title], [LastName], [BirthDate], [City], [Region], [Country], [ReportsTo]) VALUES (@First_Name, @Title, @Last_Name, @Birth_Date, @City, @Region, @Country, @Reports_To)" UpdateCommand="UPDATE [Employees] SET [FirstName] = @First_Name, [Title] = @Title, [LastName] = @Last_Name, [BirthDate] = @Birth_Date, [City] = @City, [Region] = @Region, [Country] = @Country, [ReportsTo] = @Reports_To WHERE [EmployeeID] = @Employee_ID">
                <DeleteParameters>
                    <asp:Parameter Name="Employee_ID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="First_Name" Type="String" />
                    <asp:Parameter Name="Title" Type="String" />
                    <asp:Parameter Name="Last_Name" Type="String" />
                    <asp:Parameter Name="Birth_Date" Type="DateTime" />
                    <asp:Parameter Name="City" Type="String" />
                    <asp:Parameter Name="Region" Type="String" />
                    <asp:Parameter Name="Country" Type="String" />
                    <asp:Parameter Name="Reports_To" Type="Int32" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="First_Name" Type="String" />
                    <asp:Parameter Name="Title" Type="String" />
                    <asp:Parameter Name="Last_Name" Type="String" />
                    <asp:Parameter Name="Birth_Date" Type="DateTime" />
                    <asp:Parameter Name="City" Type="String" />
                    <asp:Parameter Name="Region" Type="String" />
                    <asp:Parameter Name="Country" Type="String" />
                    <asp:Parameter Name="Reports_To" Type="Int32" />
                    <asp:Parameter Name="Employee_ID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SiteSqlServer %>" ProviderName="<%$ ConnectionStrings:SiteSqlServer.ProviderName %>" SelectCommand="SELECT [EmployeeID] AS Employee_ID, [LastName] AS Last_Name, [FirstName] AS First_Name, [Title] FROM [Employees] WHERE ([ReportsTo] = @Reports_To)">
                <SelectParameters>
                    <asp:Parameter DefaultValue="" Name="Reports_To" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>

