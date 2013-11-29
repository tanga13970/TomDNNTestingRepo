using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke.Entities.Users;
using DotNetNuke.Modules.UberFirstStartBusiness.Model;
using DotNetNuke.Modules.UberTestBusinessProfile;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Communications;

namespace DotNetNuke.Modules.UberFirstStartBusiness.Controls
{
    public partial class BusinessUsers : UberFirstStartBusinessModuleBase
    {
        DA newBL = new DA();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                DropDownListPrivilegeStatus.DataSource = newBL.GetPrivilegeStatus();
                DropDownListPrivilegeStatus.DataTextField = "PrivilegeStatus";
                DropDownListPrivilegeStatus.DataValueField = "PrivilegeStatusID";
                DropDownListPrivilegeStatus.DataBind();

                

            }
            else
            {
                DropDownListSecondaryLocation.DataSource = newBL.GetSecondaryLocations();
                DropDownListSecondaryLocation.DataTextField = "BusinessSecondaryLocationName";
                DropDownListSecondaryLocation.DataValueField = "UberBusinessSecondaryLocationID";
                DropDownListSecondaryLocation.DataBind();
            }
        }

        public void assignUBPID(UBP ubpId)
        {
            if (ubpId.UBPId != 0)
            {
                LabelUBP.Text = Convert.ToString(ubpId.UBPId);
            }

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            int userid = UserInfo.UserID;
            int privilegeId = Convert.ToInt32(DropDownListPrivilegeStatus.SelectedValue);
            int secondaryLocationId = Convert.ToInt32(DropDownListSecondaryLocation.SelectedValue);

            try
            {
                newBL.AddBusinessUser(Convert.ToInt32(LabelUBP.Text), userid, secondaryLocationId);
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
                
            }
            
        }
    }
}