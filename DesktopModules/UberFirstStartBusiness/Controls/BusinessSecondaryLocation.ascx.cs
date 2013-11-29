using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke.Modules.UberTestBusinessProfile;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Communications;
using DotNetNuke.Modules.UberFirstStartBusiness.Model;

namespace DotNetNuke.Modules.UberFirstStartBusiness.Controls
{
    public partial class BusinessSecondaryLocation : UberFirstStartBusinessModuleBase
    {
        DA newBL = new DA();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
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
            string secondaryLocation = TextBoxSecondaryLocation.Text.Trim();
            string address1 = TextBoxAddress1.Text.Trim();
            string address2 = TextBoxAddress2.Text.Trim();
            string city =TextBoxCity.Text.Trim();
            string region =TextBoxRegion.Text.Trim();
            string country =TextBoxCountry.Text.Trim();
            string postCode =TextBoxPostcode.Text.Trim();

            try
            {
                newBL.AddBusinessSecondaryLocation(Convert.ToInt32(LabelUBP.Text), secondaryLocation, address1, address2, city, region, country,
                    postCode);
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this,ex);
                
            }

        }
    }
}