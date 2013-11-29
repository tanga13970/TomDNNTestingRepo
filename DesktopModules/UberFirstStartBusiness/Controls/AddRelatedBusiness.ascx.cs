using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke.Modules.UberFirstStartBusiness.Model;
using DotNetNuke.Services.Exceptions;

namespace DotNetNuke.Modules.UberFirstStartBusiness.Controls
{
    public partial class AddRelatedBusiness : UberFirstStartBusinessModuleBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int ubpid = 0;
                ubpid = Convert.ToInt32(Request.QueryString["ubp"]);
            }
            if (Session["FileUploadLogo"] == null && FileUploadBusinessLogo.HasFile)
            {
                Session["FileUploadLogo"] = FileUploadBusinessLogo;
            }
            else if (Session["FileUploadLogo"] != null && (!FileUploadBusinessLogo.HasFile))
            {
                FileUploadBusinessLogo = (FileUpload)Session["FileUpload1"];
            }
            else if (FileUploadBusinessLogo.HasFile)
            {
                Session["FileUploadLogo"] = FileUploadBusinessLogo;
            }
        }

        public static readonly string[] ImageMimeTypes = new[] { "image/png" };

        protected void ButtonSubmit_Click1(object sender, EventArgs e)
        {
            int errorMessage = 0;
            try
            {

                DA newblclass = new DA();
                string businessName = TextBoxBusinessName.Text.Trim();
                string shortDescription = TextBoxShortDescription.Text.Trim();
                string mission = TextBoxBusinessMission.Text.Trim();
                string slogan = TextBoxBusinessSlogan.Text.Trim();
                string description = TextBoxDescription.Text.Trim();
                string vision = TextBoxVision.Text.Trim();
                string goals = TextBoxGoals.Text.Trim();
                string emaillAddress = TextBoxEmailAddress.Text.Trim();
                string phone = TextBoxPhone.Text.Trim();
                string fax = TextBoxFax.Text.Trim();
                string address1 = TextBoxAddress1.Text.Trim();
                string address2 = TextBoxAddress2.Text.Trim();
                string country = DropDownListCountry.SelectedItem.Text;
                string city = DropDownListCity.SelectedValue;
                string region = Convert.ToString(ViewState["UN_Region_Name"]);
                string subRegion = Convert.ToString(ViewState["UN_Sub_Region_Name"]);
                string countryState = DropDownListState.SelectedItem.Text;
                string postalCode = TextBoxPostalCode.Text.Trim();
                decimal latitude = Convert.ToDecimal(ViewState["Latitude"]);
                decimal longitude = Convert.ToDecimal(ViewState["Longitude"]);
                string website = TextBoxWebsite.Text.Trim();
                string facebook = TextBoxFacebook.Text.Trim();
                string linkedIn = TextBoxLinkedIn.Text.Trim();
                string twitter = TextBoxTwitter.Text.Trim();
                string youTube = TextBoxYouTube.Text.Trim();
                string google = TextBoxGoogle.Text.Trim();
                string blog = TextBoxBlog.Text.Trim();
                string shoppingCart = TextBoxShoppingCart.Text.Trim();
                string forum = TextBoxForum.Text.Trim();
                bool isPublic = Convert.ToBoolean(RadioButtonListIsPublic.SelectedValue);
                int businessAccountLimit = 1;

                if (FileUploadBusinessLogo.HasFile)
                {
                    if (ImageMimeTypes.Contains(FileUploadBusinessLogo.PostedFile.ContentType))
                    {

                        FileUploadBusinessLogo.SaveAs(Server.MapPath("~/Portals/0/logos/" + FileUploadBusinessLogo.PostedFile.FileName));

                        string logoName = FileUploadBusinessLogo.PostedFile.FileName;

                        if (!ButtonSubmit.Text.Equals("Update", StringComparison.Ordinal))
                        {
                            errorMessage = newblclass.addAdditionalBusinessProfile(businessName, shortDescription, mission, slogan, description, logoName, vision, goals, emaillAddress, phone, fax, address1, address2, city, region, subRegion, countryState, country, postalCode, latitude, longitude,
                            website, facebook, linkedIn, twitter, youTube, google, blog, shoppingCart, forum, 0, true, isPublic, 0, businessAccountLimit);
                        }


                    }
                    else
                    {
                        Label errorLabel = new Label();
                        errorLabel.Text = "You didn't upload logo image or image type isn't png";
                        PlaceHolderError.Controls.Add(errorLabel);
                    }

                }
                else
                {
                    if (!ButtonSubmit.Text.Equals("Update", StringComparison.Ordinal))
                    {
                        errorMessage = newblclass.addAdditionalBusinessProfile(businessName, shortDescription, mission, slogan, description, null, vision, goals, emaillAddress, phone, fax, address1, address2, city, region, subRegion, countryState, country, postalCode, latitude, longitude,
                            website, facebook, linkedIn, twitter, youTube, google, blog, shoppingCart, forum, 0, true, isPublic, 0, businessAccountLimit);
                    }


                }


            }
            catch (Exception exc)
            {

                Exceptions.ProcessModuleLoadException(this, exc);
            }
            finally
            {
                DA newblclass = new DA();
                if (errorMessage == 0)
                {
                    if (Convert.ToInt32(ViewState["UBPID"]) != 0)
                    {
                        Label errorLabel = new Label();
                        errorLabel.Text = "You updated Successuflly";
                        errorLabel.ForeColor = Color.Green;
                        PlaceHolderError.Controls.Add(errorLabel);
                    }
                    else
                    {
                        Label errorLabel = new Label();
                        errorLabel.Text = "You created Successuflly";
                        errorLabel.ForeColor = Color.Green;
                        PlaceHolderError.Controls.Add(errorLabel);

                    }

                    UBP reUBPID = new UBP(newblclass.getLatestUBPID());


                }
                else
                {

                    if (Convert.ToInt32(ViewState["UBPID"]) != 0)
                    {
                        Label errorLabel = new Label();
                        errorLabel.Text = "Your update was faild";
                        errorLabel.ForeColor = Color.Red;
                        PlaceHolderError.Controls.Add(errorLabel);
                    }
                    else
                    {
                        Label errorLabel = new Label();
                        errorLabel.Text = "The business name already existed";
                        errorLabel.ForeColor = Color.Red;
                        PlaceHolderError.Controls.Add(errorLabel);
                    }

                }

            }


        }

        protected void DropDownListCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            DA newblclass = new DA();
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
            DropDownDistrict.Items.Clear();
        }

        protected void DropDownListState_SelectedIndexChanged(object sender, EventArgs e)
        {
            DA newblclass = new DA();
            DataTable newTable = new DataTable();
            string countryName = Convert.ToString(ViewState["Country"]);
            newTable = newblclass.GetCitiesByStateCode(DropDownListState.SelectedValue, countryName);

            DropDownListCity.DataSource = newTable;
            DropDownListCity.DataTextField = "City Name";
            DropDownListCity.DataValueField = "City Name";
            DropDownListCity.DataBind();
            DropDownListCity.Items.Insert(0, new ListItem("Select one ..."));

            DropDownDistrict.Items.Clear();
        }

        protected void DropDownListCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            DA newblclass = new DA();
            DataTable newTable = new DataTable();
            string countryName = Convert.ToString(ViewState["Country"]);
            newTable = newblclass.GetDistrictsForCityByCityName(DropDownListCity.SelectedValue, countryName);
            if (ViewState["Latitude"] != null) ViewState["Latitude"] = newTable.Rows[0]["Latitude"];
            if (ViewState["Longitude"] != null) ViewState["Longitude"] = newTable.Rows[0]["Longitude"];
            DropDownDistrict.DataSource = newTable;
            DropDownDistrict.DataTextField = "PostalCode";
            DropDownDistrict.DataValueField = "PostalLocationName";
            DropDownDistrict.DataBind();
            DropDownDistrict.Items.Insert(0, new ListItem("Select one ..."));
        }

        protected void DropDownDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            DA newblclass = new DA();
            DataTable newTable = new DataTable();
            string countryName = Convert.ToString(ViewState["Country"]);
            newTable = newblclass.GetDetailInforForCityDistrictByCityName(DropDownDistrict.SelectedValue);

            TextBoxPostalCode.Text = Convert.ToString(newTable.Rows[0]["PostalCode"]);
            ViewState["Latitude"] = newTable.Rows[0]["Latitude"];
            ViewState["Longitude"] = newTable.Rows[0]["Longitude"];
        }
    }
}