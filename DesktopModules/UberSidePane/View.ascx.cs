/*
' Copyright (c) 2010  Uberistic Inc.
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
using DotNetNuke.Entities.Modules.Communications;
using System.Data;
using System.IO;
using System.Web;
using Uberistic.Modules.UberSidePane.Data;
using Uberistic.Modules.UberSidePane.Data.DataSetTableAdapters;


namespace Uberistic.Modules.UberSidePane
{

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The ViewTextModule3 class displays the content
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class View : UberSidePaneModuleBase, IActionable, IModuleListener
    {

        #region Event Handlers

        public void OnModuleCommunication(object s, ModuleCommunicationEventArgs e)
        {
            if (e.Target == "LeftPanel")
            {

                if (e.Value != null)
                {
                    ImageLogo.ImageUrl = "ImageHandler.ashx?UBPId=" + Convert.ToInt32(e.Value);
                    if (ImageLogo.ImageUrl == null)
                    {
                        ImageLogo.Visible = false;
                    }
                    DataTable newTb = GetBusinessProfileByUBPID((int)e.Value);
                    LiteralSlogan.Text = (string)newTb.Rows[0]["BusinessSlogan"];
                    LabelBusinessName.Text = (string)newTb.Rows[0]["BusinessName"];
                    LabelAddress.Text = ((string)newTb.Rows[0]["Address1"]) + "," + ((string)newTb.Rows[0]["City"]) + "<br/>" + "CountryID" + "," + ((string)newTb.Rows[0]["PostalCode"]);
                    LabelPhone.Text = (string)newTb.Rows[0]["Phone"];
                    HyperLinkEmail.Text = (string)newTb.Rows[0]["EmailAddress"];
                    HyperLinkWebsite.Text = (string)newTb.Rows[0]["Website"];
                    HyperLinkWebsite.NavigateUrl = (string)newTb.Rows[0]["Website"];
                    HyperLinktwitter.NavigateUrl = "http://" + (string)newTb.Rows[0]["Twitter"];
                    HyperLinkfacebook.NavigateUrl = (string)newTb.Rows[0]["Facebook"];
                    HyperLinklinkedin.NavigateUrl = (string)newTb.Rows[0]["LinkedIn"];
                    HyperLinkYouToBu.NavigateUrl = (string)newTb.Rows[0]["YouTube"];
                    HyperLinkGoogle.NavigateUrl = (string)newTb.Rows[0]["Google+"];
                    HyperLinkBlog.NavigateUrl = (string)newTb.Rows[0]["Blog"];
                    HyperLinkShoppingCart.NavigateUrl = (string)newTb.Rows[0]["ShoppingCart"];
                    HyperLinkForum.NavigateUrl = (string)newTb.Rows[0]["Forum"];
                }
            }
        }

        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }

        private void InitializeComponent()
        {
            this.Load += new System.EventHandler(this.Page_Load);
        }


        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Page_Load runs when the control is loaded
        /// </summary>
        /// -----------------------------------------------------------------------------
        private void Page_Load(object sender, System.EventArgs e)
        {
            try
            {
                
                PlaceHolderPhone.Controls.Clear();
                PlaceHolderEmail.Controls.Clear();
                DataTable newTb = new DataTable();
                int ubpid = 0;
                ubpid = Convert.ToInt32(Request.QueryString["UBPID"]);
                if (ubpid != 0)
                {
                    newTb = GetBusinessProfileByUBPID(ubpid);
                    populateSideBar(newTb);
                }
                else
                {
                    
                    if (!Page.IsPostBack)
                    {
                        int userRoleID = GetUserRoleByUserID(UserInfo.UserID);
                        if (userRoleID == 1)
                        {
                            newTb = GetBusinessProfileByUserID(UserInfo.UserID);
                            if (newTb.Rows.Count > 0)
                            {
                                populateSideBar(newTb);
                            }

                        }
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(HyperLinktwitter.NavigateUrl)) { PlaceHolder1.Controls.Clear(); }
                        if (String.IsNullOrEmpty(HyperLinkfacebook.NavigateUrl)) PlaceHolder2.Controls.Clear();
                        if (String.IsNullOrEmpty(HyperLinklinkedin.NavigateUrl)) PlaceHolder3.Controls.Clear();
                        if (String.IsNullOrEmpty(HyperLinkYouToBu.NavigateUrl)) PlaceHolder4.Controls.Clear();
                        if (String.IsNullOrEmpty(HyperLinkGoogle.NavigateUrl)) PlaceHolder5.Controls.Clear();
                        if (String.IsNullOrEmpty(HyperLinkBlog.NavigateUrl)) PlaceHolder6.Controls.Clear();
                        if (String.IsNullOrEmpty(HyperLinkShoppingCart.NavigateUrl)) PlaceHolder7.Controls.Clear();
                        if (String.IsNullOrEmpty(HyperLinkForum.NavigateUrl)) PlaceHolder8.Controls.Clear();
                    }
                }

                


            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        private DataTable GetBusinessProfileByUBPID(int UBPID)
        {

            DataTable newTb = new DataTable();
            UberBusinessProfileTableAdapter newAdapt = new UberBusinessProfileTableAdapter();

            newTb = newAdapt.Uber_GetBusinessProfileByUBPID(UBPID);

            return newTb;
        }

        private DataTable GetBusinessProfileByUserID(int UserID)
        {
            DataTable newTb = new DataTable();
            UberBusinessProfileTableAdapter newAdapt = new UberBusinessProfileTableAdapter();

            newTb = newAdapt.GetMainBusinessProfileByUserID(UserID);

            return newTb;
        }

        public int GetUserRoleByUserID(int userID)
        {
            SqlDataProvider newDataProvider = new SqlDataProvider();
            int userRoleID = newDataProvider.GetUserRoleByUserID(userID);

            return userRoleID;

        }

        protected void populateSideBar(DataTable newTb)
        {
            if (newTb.Rows[0]["BusinessSlogan"] != null) LiteralSlogan.Text = HttpUtility.HtmlDecode(Convert.ToString(newTb.Rows[0]["BusinessSlogan"]));
            LabelBusinessName.Text = (string)newTb.Rows[0]["BusinessName"];
            if (newTb.Rows[0]["Address1"] != null || newTb.Rows[0]["City"] != null || newTb.Rows[0]["PostalCode"] != null) LabelAddress.Text = ((string)newTb.Rows[0]["Address1"]) + "," + ((string)newTb.Rows[0]["City"]) + "<br/>" + ((string)newTb.Rows[0]["CountryID"]) + "," + ((string)newTb.Rows[0]["PostalCode"]);
            if (newTb.Rows[0]["Phone"] != null) LabelPhone.Text = (string)newTb.Rows[0]["Phone"];
            if (newTb.Rows[0]["EmailAddress"] != null) HyperLinkEmail.Text = (string)newTb.Rows[0]["EmailAddress"];
            if (!DBNull.Value.Equals(newTb.Rows[0]["Website"] ))
            {
                HyperLinkWebsite.Text = (string)newTb.Rows[0]["Website"];
                string Website = (string)newTb.Rows[0]["Website"];
                if (!Website.Contains("http://"))
                {
                    HyperLinkWebsite.NavigateUrl = "http://" + (string)newTb.Rows[0]["Website"];
                }
                else
                {
                    HyperLinkWebsite.NavigateUrl = (string)newTb.Rows[0]["Website"];
                }
            }
            if (!DBNull.Value.Equals(newTb.Rows[0]["Twitter"]))
            {

                string Twitter = (string)newTb.Rows[0]["Twitter"];
                if (!Twitter.Contains("http://"))
                {
                    HyperLinktwitter.NavigateUrl = "http://" + (string)newTb.Rows[0]["Twitter"];
                }
                else
                {
                    HyperLinktwitter.NavigateUrl = (string)newTb.Rows[0]["Twitter"];
                }

            }
            if (String.IsNullOrEmpty(HyperLinktwitter.NavigateUrl)) { PlaceHolder1.Controls.Clear(); }
            if (!DBNull.Value.Equals(newTb.Rows[0]["Facebook"] ))
            {
                string facebook = (string)newTb.Rows[0]["Facebook"];
                if (!facebook.Contains("http://"))
                {
                    HyperLinkfacebook.NavigateUrl = "http://" + (string)newTb.Rows[0]["Facebook"];
                }
                else
                {
                    HyperLinkfacebook.NavigateUrl = (string)newTb.Rows[0]["Facebook"];
                }

            }
            if (String.IsNullOrEmpty(Convert.ToString(newTb.Rows[0]["Facebook"]))) PlaceHolder2.Controls.Clear();
            if (!DBNull.Value.Equals(newTb.Rows[0]["LinkedIn"]))
            {
                string linkedIn = (string)newTb.Rows[0]["LinkedIn"];
                if (!linkedIn.Contains("http://"))
                {
                    HyperLinklinkedin.NavigateUrl = "http://" + (string)newTb.Rows[0]["LinkedIn"];
                }
                else
                {
                    HyperLinklinkedin.NavigateUrl = (string)newTb.Rows[0]["LinkedIn"];
                }
            }
            if (String.IsNullOrEmpty(Convert.ToString(newTb.Rows[0]["LinkedIn"]))) PlaceHolder3.Controls.Clear();
            if (!DBNull.Value.Equals(newTb.Rows[0]["YouTube"]))
            {
                string youTube = (string)newTb.Rows[0]["YouTube"];
                if (!youTube.Contains("http://"))
                {
                    HyperLinkYouToBu.NavigateUrl = "http://" + (string)newTb.Rows[0]["YouTube"];
                }
                else
                {
                    HyperLinkYouToBu.NavigateUrl = (string)newTb.Rows[0]["YouTube"];
                }
            }
            if (String.IsNullOrEmpty(Convert.ToString(newTb.Rows[0]["YouTube"]))) PlaceHolder4.Controls.Clear();
            if (!DBNull.Value.Equals(newTb.Rows[0]["Google+"]))
            {
                string google = (string)newTb.Rows[0]["Google+"];
                if (!google.Contains("http://"))
                {
                    HyperLinkGoogle.NavigateUrl = "http://" + (string)newTb.Rows[0]["Google+"];
                }
                else
                {
                    HyperLinkGoogle.NavigateUrl = (string)newTb.Rows[0]["Google+"];
                }
            }
            if (String.IsNullOrEmpty(Convert.ToString(newTb.Rows[0]["Google+"]))) PlaceHolder5.Controls.Clear();
            if (!DBNull.Value.Equals(newTb.Rows[0]["Blog"]))
            {
                string blog = (string)newTb.Rows[0]["Blog"];
                if (!blog.Contains("http://"))
                {
                    HyperLinkBlog.NavigateUrl = "http://" + (string)newTb.Rows[0]["Blog"];
                }
                else
                {
                    HyperLinkBlog.NavigateUrl = (string)newTb.Rows[0]["Blog"];
                }
            }
            if (String.IsNullOrEmpty(Convert.ToString(newTb.Rows[0]["Blog"]))) PlaceHolder6.Controls.Clear();
            if (!DBNull.Value.Equals(newTb.Rows[0]["ShoppingCart"]))
            {
                string ShoppingCart = (string)newTb.Rows[0]["ShoppingCart"];
                if (!ShoppingCart.Contains("http://"))
                {
                    HyperLinkShoppingCart.NavigateUrl = "http://" + (string)newTb.Rows[0]["ShoppingCart"];
                }
                else
                {
                    HyperLinkShoppingCart.NavigateUrl = (string)newTb.Rows[0]["ShoppingCart"];
                }
            }
            if (String.IsNullOrEmpty(Convert.ToString(newTb.Rows[0]["ShoppingCart"]))) PlaceHolder7.Controls.Clear();
            if (!DBNull.Value.Equals(newTb.Rows[0]["Forum"]))
            {
                string Forum = (string)newTb.Rows[0]["Forum"];
                if (!Forum.Contains("http://"))
                {
                    HyperLinkForum.NavigateUrl = "http://" + (string)newTb.Rows[0]["Forum"];
                }
                else
                {
                    HyperLinkForum.NavigateUrl = (string)newTb.Rows[0]["Forum"];
                }
            }
            if (String.IsNullOrEmpty(Convert.ToString(newTb.Rows[0]["Forum"]))) PlaceHolder8.Controls.Clear();

            ImageLogo.ImageUrl = "~/Portals/0/logos/" + Convert.ToString(newTb.Rows[0]["BusinessLogo"]);

            if (String.IsNullOrEmpty(Convert.ToString(newTb.Rows[0]["BusinessLogo"])))
            {

                ImageLogo.Visible = false;
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

    }

}
