/*
' Copyright (c) 2012  DotNetNuke Corporation
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Localization;
using DotNetNuke.Security;
using DotNetNuke.Modules.UberFirstStartBusiness.Model;
using System.Data;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.UI;


namespace DotNetNuke.Modules.UberFirstStartBusiness
{

    public partial class View : UberFirstStartBusinessModuleBase, IActionable
    {

        #region Event Handlers

        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }

        private void InitializeComponent()
        {
            this.Load += new System.EventHandler(this.Page_Load);
        }

        DA newblclass = new DA();

        private void Page_Load(object sender, System.EventArgs e)
        {
            try
            {
                DataTable newTable = new DataTable();
                Page page= new Page();
                newTable = newblclass.GetMainBusinessProfileByUserID(UserInfo.UserID);

                string sucessful = Convert.ToString(Request.QueryString["Sucessful"]);
                if (sucessful == "Created")
                {
                    InitialPageControl(newTable);
                }
                if (!Page.IsPostBack)
                {
                    if (newTable.Rows.Count>0)
                    {
                        InitialPageControl(newTable);
                    }

                    string name = UserInfo.FullName.ToString();
                    LabelUserName.Text = name;
                    LabelError.Text = "Create business before adding <br/>locations or related business's.";

                    
                    newTable = newblclass.GetAllCountry();

                    DropDownListCountry.DataSource = newTable;
                    DropDownListCountry.DataTextField = "Country_Name";
                    DropDownListCountry.DataValueField = "ISO_Country_Code";
                    DropDownListCountry.DataBind();
                    DropDownListCountry.Items.Insert(0, new ListItem("Select one ..."));

                    newTable = newblclass.GetAllSectors();
                    DropDownListSector.DataSource = newTable;
                    DropDownListSector.DataTextField = "SectorName";
                    DropDownListSector.DataValueField = "SectorID";
                    DropDownListSector.DataBind();
                    DropDownListSector.Items.Insert(0, new ListItem("Select one ..."));

                }
            }
            catch (Exception exc) 
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        #endregion

        #region Optional Interfaces

        public ModuleActionCollection ModuleActions
        {
            get
            {
                ModuleActionCollection Actions = new ModuleActionCollection();
                Actions.Add(GetNextActionID(), Localization.GetString("EditModule", this.LocalResourceFile), "", "", "", EditUrl(), false, SecurityAccessLevel.Edit, true, false);
                return Actions;
            }
        }

        #endregion

        protected void InitialPageControl(DataTable newTabe)
        {
            ButtonAddLocation.Enabled = true;
            ButtonRelatedBusiness.Enabled = true;
            ScriptManager.RegisterStartupScript(this, typeof(string), "ShowTop5", String.Format("showProfile();"), true);

            DropDownListBusinessName.DataTextField = "BusinessName";
            DropDownListBusinessName.DataValueField = "UBPID";

            DropDownListBusinessName.DataSource = newTabe;
            DropDownListBusinessName.DataBind();

            DropDownListBusinesses.DataTextField = "BusinessName";
            DropDownListBusinesses.DataValueField = "UBPID";

            DropDownListBusinesses.DataSource = newTabe;
            DropDownListBusinesses.DataBind();
            
        }

        protected void ButtonCreateBP_Click(object sender, EventArgs e)
        {
            string BusinessName = TextBoxBusinessName.Text.Trim();
            Response.Redirect(EditUrl("BusinessName", BusinessName, "EditBusinessProfile"));
        }

        protected void ButtonAddLocation_Click(object sender, EventArgs e)
        {

            Response.Redirect(EditUrl("BusinessSecondaryLocation"));
        }

        protected void ButtonRelatedBusiness_Click(object sender, EventArgs e)
        {
            Response.Redirect(EditUrl("AddRelatedBusiness"));
        }

        protected void DropDownListSector_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataTable newTable = newblclass.GetAllSubSectorsBySectorId(Convert.ToInt32(DropDownListSector.SelectedValue));

            DropDownListSubsector.DataSource = newTable;
            DropDownListSubsector.DataTextField = "SubSectorName";
            DropDownListSubsector.DataValueField = "SubSectorID";
            DropDownListSubsector.DataBind();
            DropDownListSubsector.Items.Insert(0, new ListItem("Select One ..."));

            DropDownListGroup.Items.Clear();
            DropDownListIndustry.Items.Clear();
            DropDownListSepecificIndustry.Items.Clear();
        }

        protected void DropDownListSubsector_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable newTable =
                newblclass.GetIndustryGroupBySubSectorId(Convert.ToInt32(DropDownListSubsector.SelectedValue));

            DropDownListGroup.DataSource = newTable;
            DropDownListGroup.DataTextField = "IndustryGroupName";
            DropDownListGroup.DataValueField = "IndustryGroupID";
            DropDownListGroup.DataBind();
            DropDownListGroup.Items.Insert(0, new ListItem("Select one ..."));

            DropDownListIndustry.Items.Clear();
            DropDownListSepecificIndustry.Items.Clear();
        }

        protected void DropDownListGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable newTable =
                newblclass.GetIndustryByIndustryGroupId(Convert.ToInt32(DropDownListGroup.SelectedValue));

            DropDownListIndustry.DataSource = newTable;
            DropDownListIndustry.DataTextField = "IndustryName";
            DropDownListIndustry.DataValueField = "IndustryID";
            DropDownListIndustry.DataBind();
            DropDownListIndustry.Items.Insert(0, new ListItem("Select one ..."));

            DropDownListSepecificIndustry.Items.Clear();
        }

        protected void DropDownListIndustry_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable newTable =
                newblclass.GetNationalIndustryByIndustryId(Convert.ToInt32(DropDownListIndustry.SelectedValue));
            DropDownListSepecificIndustry.DataSource = newTable;
            DropDownListSepecificIndustry.DataTextField = "NAICSName";
            DropDownListSepecificIndustry.DataValueField = "Index";
            DropDownListSepecificIndustry.DataBind();
            DropDownListSepecificIndustry.Items.Insert(0, new ListItem("Select one ..."));
        }

        protected void DropDownListCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable newTable = new DataTable();
            string countryCode = DropDownListCountry.SelectedValue;
            ViewState["Country"] = Convert.ToString(DropDownListCountry.SelectedItem.Text);
            newTable = newblclass.GetCountriesByCountryCode(countryCode);

            ViewState["UN_Region_Name"] = newTable.Rows[0]["UN_Region_Name"];
            ViewState["UN_Sub_Region_Name"] = newTable.Rows[0]["UN_Sub_Region_Name"];

            newTable = newblclass.GetStateByCountryCode(countryCode);

            DropDownListState.DataSource = newTable;
            DropDownListState.DataTextField = "ProvinceState";
            DropDownListState.DataValueField = "CountryStateCode";
            DropDownListState.DataBind();
            DropDownListState.Items.Insert(0, new ListItem("Select one ..."));

            DropDownListCity.Items.Clear();
        }

        protected void DropDownListState_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable newTable = new DataTable();
            string countryName = Convert.ToString(ViewState["Country"]);
            newTable = newblclass.GetCitiesByStateCode(DropDownListState.SelectedValue, countryName);

            DropDownListCity.DataSource = newTable;
            DropDownListCity.DataTextField = "City Name";
            DropDownListCity.DataValueField = "City Name";
            DropDownListCity.DataBind();
            DropDownListCity.Items.Insert(0, new ListItem("Select one ..."));

        }


    }

}
