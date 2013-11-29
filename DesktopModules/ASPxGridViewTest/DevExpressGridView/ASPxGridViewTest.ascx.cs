using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxGridView;
using DotNetNuke;
using DotNetNuke.Common;
using DotNetNuke.Security.Roles;
using DotNetNuke.Security.Membership;
using DotNetNuke.Security;
using DotNetNuke.Data;
using DotNetNuke.Entities.Users;
using DotNetNuke.Entities;
using DotNetNuke.Services.Exceptions;

public partial class _ASPxGridViewTest : DotNetNuke.Entities.Modules.PortalModuleBase
{
    protected int rowNumber = 0;
    int groupedRowNum = 0;
	
	protected override void OnInit(EventArgs e)
    {
        ASPxGridView1.DataSource = SqlDataSource1;
        ASPxGridView1.DataBind();
    }
	
    protected void Page_Load(object sender, EventArgs e)
    {
		
    }
    protected void ASPxGridView_DataBound(object sender, EventArgs e)
    {
        ASPxGridView thisGrid = sender as ASPxGridView;
        thisGrid.KeyFieldName = "Employee_ID";

        if (thisGrid.Columns["row_number"] == null)
        {
            rowNumber = 0;
            GridViewDataTextColumn rowNumCol = new GridViewDataTextColumn();
            rowNumCol.Caption = "No.";
            rowNumCol.Name = "row_number";
			rowNumCol.FieldName = "row_number";
            rowNumCol.CellStyle.HorizontalAlign = HorizontalAlign.Center;
            rowNumCol.HeaderStyle.BackColor = Color.FromArgb(0xCC, 0x66, 0x00);
            rowNumCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            rowNumCol.Width = 50;
            rowNumCol.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            rowNumCol.EditFormSettings.Visible = DevExpress.Utils.DefaultBoolean.False;
			rowNumCol.Settings.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            thisGrid.Columns.Add(rowNumCol);
            rowNumCol.VisibleIndex = 0;
        }
        if (ASPxGridView1.Columns["row_command"] == null)
        {
            GridViewCommandColumn commandColumn = new GridViewCommandColumn();
            commandColumn.EditButton.Visible = true;
            commandColumn.DeleteButton.Visible = true;
            commandColumn.NewButton.Visible = true;
            commandColumn.Name = "row_command";
            thisGrid.Columns.Add(commandColumn);
            commandColumn.VisibleIndex = 0;
        }
    }
    protected void ASPxGridView_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
    {
        // if (e.Value != null)
        // {
            // string cellValue = e.Value.ToString();
        // }

        // if (e.Column.Name == "row_number")
        // {
            // groupedRowNum += 1;
            // e.DisplayText = groupedRowNum.ToString();
        // }
    }
	
	protected void ASPxGridView1_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
    {
        if (e.DataColumn.FieldName == "row_number")
        {
            e.Cell.Text = rowNumber.ToString();
            rowNumber++;
        }
    }
	
    protected void ASPxGridView1_DetailRowExpandedChanged(object sender, ASPxGridViewDetailRowEventArgs e)
    {
        if (e.Expanded)
        {
            SqlDataSource2.SelectParameters["Reports_To"].DefaultValue = ASPxGridView1.GetRowValues(e.VisibleIndex, "Employee_ID").ToString();
        }
    }
	
    protected void ASPxGridView1_DetailsChanged(object sender, EventArgs e)
    {
        rowNumber = 0;
    }
	
	protected void ASPxGridView_CustomUnboundColumnData(object sender, ASPxGridViewColumnDataEventArgs e)
    {
        e.Value = e.ListSourceRowIndex;
    }
}