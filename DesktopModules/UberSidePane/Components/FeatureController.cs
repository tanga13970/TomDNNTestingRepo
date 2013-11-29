/*
' Copyright (c) 2010 Uberistic Inc.
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System.Collections.Generic;
//using System.Xml;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace Uberistic.Modules.UberSidePane.Components
{

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The Controller class for UberSidePane
    /// </summary>
    /// -----------------------------------------------------------------------------
    public class FeatureController : IPortable, ISearchable, IUpgradeable
    {

        #region Public Methods



        #endregion

        #region Optional Interfaces

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// ExportModule implements the IPortable ExportModule Interface
        /// </summary>
        /// <param name="ModuleID">The Id of the module to be exported</param>
        /// -----------------------------------------------------------------------------
        public string ExportModule(int ModuleID)
        {
            //string strXML = "";

            //List<UberSidePaneInfo> colUberSidePanes = GetUberSidePanes(ModuleID);
            //if (colUberSidePanes.Count != 0)
            //{
            //    strXML += "<UberSidePane>";

            //    foreach (UberSidePaneInfo objUberSidePane in colUberSidePanes)
            //    {
            //        strXML += "<UberSidePane>";
            //        strXML += "<content>" + DotNetNuke.Common.Utilities.XmlUtils.XMLEncode(objUberSidePane.Content) + "</content>";
            //        strXML += "</UberSidePane>";
            //    }
            //    strXML += "</UberSidePane>";
            //}

            //return strXML;

            throw new System.NotImplementedException("The method or operation is not implemented.");
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// ImportModule implements the IPortable ImportModule Interface
        /// </summary>
        /// <param name="ModuleID">The Id of the module to be imported</param>
        /// <param name="Content">The content to be imported</param>
        /// <param name="Version">The version of the module to be imported</param>
        /// <param name="UserId">The Id of the user performing the import</param>
        /// -----------------------------------------------------------------------------
        public void ImportModule(int ModuleID, string Content, string Version, int UserID)
        {
            //XmlNode xmlUberSidePanes = DotNetNuke.Common.Globals.GetContent(Content, "UberSidePane");
            //foreach (XmlNode xmlUberSidePane in xmlUberSidePanes.SelectNodes("UberSidePane"))
            //{
            //    UberSidePaneInfo objUberSidePane = new UberSidePaneInfo();
            //    objUberSidePane.ModuleId = ModuleID;
            //    objUberSidePane.Content = xmlUberSidePane.SelectSingleNode("content").InnerText;
            //    objUberSidePane.CreatedByUser = UserID;
            //    AddUberSidePane(objUberSidePane);
            //}

            throw new System.NotImplementedException("The method or operation is not implemented.");
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// GetSearchItems implements the ISearchable Interface
        /// </summary>
        /// <param name="ModInfo">The ModuleInfo for the module to be Indexed</param>
        /// -----------------------------------------------------------------------------
        public DotNetNuke.Services.Search.SearchItemInfoCollection GetSearchItems(DotNetNuke.Entities.Modules.ModuleInfo ModInfo)
        {
            //SearchItemInfoCollection SearchItemCollection = new SearchItemInfoCollection();

            //List<UberSidePaneInfo> colUberSidePanes = GetUberSidePanes(ModInfo.ModuleID);

            //foreach (UberSidePaneInfo objUberSidePane in colUberSidePanes)
            //{
            //    SearchItemInfo SearchItem = new SearchItemInfo(ModInfo.ModuleTitle, objUberSidePane.Content, objUberSidePane.CreatedByUser, objUberSidePane.CreatedDate, ModInfo.ModuleID, objUberSidePane.ItemId.ToString(), objUberSidePane.Content, "ItemId=" + objUberSidePane.ItemId.ToString());
            //    SearchItemCollection.Add(SearchItem);
            //}

            //return SearchItemCollection;

            throw new System.NotImplementedException("The method or operation is not implemented.");
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// UpgradeModule implements the IUpgradeable Interface
        /// </summary>
        /// <param name="Version">The current version of the module</param>
        /// -----------------------------------------------------------------------------
        public string UpgradeModule(string Version)
        {
            throw new System.NotImplementedException("The method or operation is not implemented.");
        }

        #endregion

    }

}
