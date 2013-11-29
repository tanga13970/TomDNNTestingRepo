/*
' Copyright (c) 2012 DotNetNuke Corporation
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
using System.Data;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Framework.Providers;
using Microsoft.ApplicationBlocks.Data;

namespace DotNetNuke.Modules.UberFirstStartBusiness.Data
{

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// SQL Server implementation of the abstract DataProvider class
    /// 
    /// This concreted data provider class provides the implementation of the abstract methods 
    /// from data dataprovider.cs
    /// 
    /// In most cases you will only modify the Public methods region below.
    /// </summary>
    /// -----------------------------------------------------------------------------
    public class SqlDataProvider : DataProvider
    {

        #region Private Members

        private const string ProviderType = "data";
        private const string ModuleQualifier = "UberFirstStartBusiness_";

        private readonly ProviderConfiguration _providerConfiguration = ProviderConfiguration.GetProviderConfiguration(ProviderType);
        private readonly string _connectionString;
        private readonly string _providerPath;
        private readonly string _objectQualifier;
        private readonly string _databaseOwner;

        #endregion

        #region Constructors

        public SqlDataProvider()
        {

            // Read the configuration specific information for this provider
            Provider objProvider = (Provider)(_providerConfiguration.Providers[_providerConfiguration.DefaultProvider]);

            // Read the attributes for this provider

            //Get Connection string from web.config
            _connectionString = Config.GetConnectionString();

            if (string.IsNullOrEmpty(_connectionString))
            {
                // Use connection string specified in provider
                _connectionString = objProvider.Attributes["connectionString"];
            }

            _providerPath = objProvider.Attributes["providerPath"];

            _objectQualifier = objProvider.Attributes["objectQualifier"];
            if (!string.IsNullOrEmpty(_objectQualifier) && _objectQualifier.EndsWith("_", StringComparison.Ordinal) == false)
            {
                _objectQualifier += "_";
            }

            _databaseOwner = objProvider.Attributes["databaseOwner"];
            if (!string.IsNullOrEmpty(_databaseOwner) && _databaseOwner.EndsWith(".", StringComparison.Ordinal) == false)
            {
                _databaseOwner += ".";
            }

        }

        #endregion

        #region Properties

        public string ConnectionString
        {
            get
            {
                return _connectionString;
            }
        }

        public string ProviderPath
        {
            get
            {
                return _providerPath;
            }
        }

        public string ObjectQualifier
        {
            get
            {
                return _objectQualifier;
            }
        }

        public string DatabaseOwner
        {
            get
            {
                return _databaseOwner;
            }
        }

        private string NamePrefix
        {
            get { return DatabaseOwner + ObjectQualifier + ModuleQualifier; }
        }

        #endregion

        #region Private Methods

        private static object GetNull(object Field)
        {
            return DotNetNuke.Common.Utilities.Null.GetNull(Field, DBNull.Value);
        }

        #endregion

        #region Public Methods

        //public override IDataReader GetItem(int itemId)
        //{
        //    return SqlHelper.ExecuteReader(ConnectionString, NamePrefix + "spGetItem", itemId);
        //}

        //public override IDataReader GetItems(int userId, int portalId)
        //{
        //    return SqlHelper.ExecuteReader(ConnectionString, NamePrefix + "spGetItemsForUser", userId, portalId);
        //}


        #region BusinessProfileEntry

        public int addNewBusinessProfile(int userid,string businessName, string shortDescription, string businessMission,
            string businessSlogan, string description, string businessLogo, string vision, string goals, string emailAddress, string phone,
            string fax, string address1, string address2, string city, string region, string subRegion, string countryState, string countryID, string postalCode,
            decimal latitude, decimal longitude, string website, string facebook, string linkedIn, string twitter,
            string youTube, string google, string blog, string shoppingCart, string forum, int rank, bool featured,
            bool isPublic, int portalId, int businessAccountLimit)
        {


            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString, "Uber_AddBusinessProfile",userid, businessName, shortDescription,
                    businessMission, businessSlogan, description, businessLogo, vision, goals, emailAddress, phone, fax, address1,
                    address2, city, region, subRegion, countryID, countryState, postalCode, latitude, longitude, website, facebook, linkedIn,
                    twitter, youTube, google, blog, shoppingCart, forum, rank, featured, isPublic, portalId, businessAccountLimit));
        }

        public int addAdditionalBusinessProfile(string businessName, string shortDescription, string businessMission,
            string businessSlogan, string description, string businessLogo, string vision, string goals, string emailAddress, string phone,
            string fax, string address1, string address2, string city, string region, string subRegion, string countryState, string countryID, string postalCode,
            decimal latitude, decimal longitude, string website, string facebook, string linkedIn, string twitter,
            string youTube, string google, string blog, string shoppingCart, string forum, int rank, bool featured,
            bool isPublic, int portalId, int businessAccountLimit)
        {


            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString, "Uber_AddAdditionalBusinessProfile", businessName, shortDescription,
                    businessMission, businessSlogan, description, businessLogo, vision, goals, emailAddress, phone, fax, address1,
                    address2, city, region, subRegion, countryID, countryState, postalCode, latitude, longitude, website, facebook, linkedIn,
                    twitter, youTube, google, blog, shoppingCart, forum, rank, featured, isPublic, portalId, businessAccountLimit));
        }

        public int getLatestUBPID()
        {
            return Convert.ToInt16(SqlHelper.ExecuteScalar(ConnectionString, "SelectLatestUBPIDFromBusinessProfile"));
        }

        #endregion

        #region businessIndustry

        public IDataReader GetAllSubSectorsBySectorId(int SectorId)
        {

            return SqlHelper.ExecuteReader(ConnectionString, "Uber_GetSubSectorBySectorId", SectorId);

        }

        public IDataReader GetIndustryGroupBySubSectorId(int SubSectorId)
        {

            return SqlHelper.ExecuteReader(ConnectionString, "Uber_getIndustryGroupBySubSectorId", SubSectorId);

        }

        public IDataReader GetIndustryByIndustryGroupId(int IndustryGroupId)
        {


            return SqlHelper.ExecuteReader(ConnectionString, "Uber_GetIndustryByIndestryGroupId", IndustryGroupId); ;

        }

        public IDataReader GetNationalIndustryByIndustryId(int IndustryId)
        {

            return SqlHelper.ExecuteReader(ConnectionString, "Uber_GetNationalIndustryByIndustryId", IndustryId); ;

        }

        #endregion

        #region BusinessUserLookUp


        #endregion

        #region BusinessSecondaryLocation




        #endregion

        #region businessUsers

        public IDataReader GetManagersByUBPID(int UBPID)
        {
            return SqlHelper.ExecuteReader(ConnectionString, "Uber_GetManagersByUBPID", UBPID);
        }

        public IDataReader GetManagersByUserID(int UserID)
        {
            return SqlHelper.ExecuteReader(ConnectionString, "Uber_GetManagersByUserID", UserID);
        }

        #endregion

        #region NAICSNationalIndustry

        public IDataReader GetNationalIndustryByIndex(int index)
        {


            return SqlHelper.ExecuteReader(ConnectionString, "Uber_GetNAICSNationalIndustryByIndex", index);

        }

        #endregion

        #region BusinessByIndustry

        #endregion

        #region Country

        public IDataReader GetCitiesByStateCode(string StateCode, string countryName)
        {

            return SqlHelper.ExecuteReader(ConnectionString, "Uber_GetCitiesByStateCode", countryName, StateCode);

        }

        public IDataReader GetDistrictsForCityByCityName(string cityName, string countryName)
        {

            return SqlHelper.ExecuteReader(ConnectionString, "Uber_GetDistrictsForCityByCityName", cityName, countryName);

        }

        public IDataReader GetDetailInforForCityDistrictByCityName(string postalLocationName)
        {

            return SqlHelper.ExecuteReader(ConnectionString, "Uber_GetDetailInforForCityDistrictByCityName", postalLocationName);

        }

        #endregion

        #region User Role

        public int GetUserRoleByUserID(int userID)
        {
            int userid = 3;
            if (!DBNull.Value.Equals(SqlHelper.ExecuteScalar(ConnectionString, "Uber_GetRoleTypeByUserID", userID)))
            {
                userid = Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString, "Uber_GetRoleTypeByUserID", userID));
            }
            return userid;

        }

        #endregion

        #endregion

    }

}