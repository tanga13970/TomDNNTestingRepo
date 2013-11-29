using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DotNetNuke.Modules.UberFirstStartBusiness.Data;
using DotNetNuke.Modules.UberFirstStartBusiness.UberBusinessProfileDataSetTableAdapters;

namespace DotNetNuke.Modules.UberFirstStartBusiness.Model
{
    public class DA
    {
        SqlDataProvider newDataProvider = new SqlDataProvider();

        #region BusinessProfileEntry

        public int addNewBusinessProfile(int userid,string businessName, string shortDescription, string businessMission,
            string businessSlogan, string description, string businessLogo, string vision, string goals, string emailAddress, string phone,
            string fax, string address1, string address2, string city, string region, string subRegion, string countryState, string countryID, string postalCode,
            decimal latitude, decimal longitude, string website, string facebook, string linkedIn, string twitter,
            string youTube, string google, string blog, string shoppingCart, string forum, int rank, bool featured,
            bool isPublic, int portalId, int businessAccountLimit)
        {

            return newDataProvider.addNewBusinessProfile(userid,businessName, shortDescription,
                    businessMission, businessSlogan, description, businessLogo, vision, goals, emailAddress, phone, fax, address1,
                    address2, city, region, subRegion, countryState, countryID, postalCode, latitude, longitude, website, facebook, linkedIn,
                    twitter, youTube, google, blog, shoppingCart, forum, rank, featured, isPublic, portalId, businessAccountLimit);
        }

        public int addAdditionalBusinessProfile(string businessName, string shortDescription, string businessMission,
            string businessSlogan, string description, string businessLogo, string vision, string goals, string emailAddress, string phone,
            string fax, string address1, string address2, string city, string region, string subRegion, string countryState, string countryID, string postalCode,
            decimal latitude, decimal longitude, string website, string facebook, string linkedIn, string twitter,
            string youTube, string google, string blog, string shoppingCart, string forum, int rank, bool featured,
            bool isPublic, int portalId, int businessAccountLimit)
        {

            return newDataProvider.addAdditionalBusinessProfile(businessName, shortDescription,
                    businessMission, businessSlogan, description, businessLogo, vision, goals, emailAddress, phone, fax, address1,
                    address2, city, region, subRegion, countryState, countryID, postalCode, latitude, longitude, website, facebook, linkedIn,
                    twitter, youTube, google, blog, shoppingCart, forum, rank, featured, isPublic, portalId, businessAccountLimit);
        }

        public int getLatestUBPID()
        {
            return newDataProvider.getLatestUBPID();
        }

        public DataTable Uber_GetBusinessesProfileForUserByUserID(int userId)
        {
            UberBusinessProfileTableAdapter newAP = new UberBusinessProfileTableAdapter();
            DataTable newTable = newAP.Uber_GetBusinessProfileByUserID(userId);
            return newTable;
        }

        #endregion

        #region businessIndustry

        public DataTable GetAllSectors()
        {
            DataTable newTable = new DataTable("Sectors");

            NAICSSectorTableAdapter adapter = new NAICSSectorTableAdapter();
            newTable = adapter.GetData();

            return newTable;

        }

        public DataTable GetAllSubSectorsBySectorId(int SectorId)
        {

            DataTable newTable = new DataTable("SubSectors");

            IDataReader newReader = newDataProvider.GetAllSubSectorsBySectorId(SectorId);
            newTable.Load(newReader);
            return newTable;



        }

        public DataTable GetIndustryGroupBySubSectorId(int SubSectorId)
        {


            DataTable newTable = new DataTable("IndustryGroup");
            IDataReader newReader = newDataProvider.GetIndustryGroupBySubSectorId(SubSectorId);
            newTable.Load(newReader);
            return newTable;


        }

        public DataTable GetIndustryByIndustryGroupId(int IndustryGroupId)
        {

            try
            {
                DataTable newTable = new DataTable("Industry");
                IDataReader newReader = newDataProvider.GetIndustryByIndustryGroupId(IndustryGroupId);
                newTable.Load(newReader);
                return newTable;

            }
            catch (Exception e)
            {
                throw;
            }

        }

        public DataTable GetNationalIndustryByIndustryId(int IndustryId)
        {

            try
            {
                DataTable newTable = new DataTable("NationalIndustry");
                IDataReader newReader = newDataProvider.GetNationalIndustryByIndustryId(IndustryId);
                newTable.Load(newReader);
                return newTable;

            }
            catch (Exception e)
            {
                throw;
            }

        }

        #endregion

        #region BusinessUserLookUp

        public DataTable GetPrivilegeStatus()
        {

            DataTable newTable = new DataTable("PrivilegeStatus");
            UberBusinessUserLookUpTableAdapter adapter = new UberBusinessUserLookUpTableAdapter();
            newTable = adapter.GetData();
            return newTable;

        }

        #endregion

        #region BusinessSecondaryLocation

        public DataTable GetSecondaryLocations()
        {

            DataTable newTable = new DataTable("SecondaryLocation");
            UberBusinessSecondaryLocationTableAdapter adapter = new UberBusinessSecondaryLocationTableAdapter();
            newTable = adapter.GetData();
            return newTable;

        }


        public int AddBusinessSecondaryLocation(int UBPID, string secondaryLocationName, string address1,
            string address2, string city, string region, string country, string postcode)
        {


            UberBusinessSecondaryLocationTableAdapter adapter = new UberBusinessSecondaryLocationTableAdapter();
            int isSuccessful =
                Convert.ToInt16(adapter.InsertBusinessSecondaryLocation(UBPID, secondaryLocationName, address1, address2,
                    city, region, country, postcode));
            return isSuccessful;
        }

        #endregion

        #region businessUsers

        public int AddBusinessUser(int ubpId, int userId, int secondaryLocationId)
        {
            UberBusinessUsersTableAdapter adapter = new UberBusinessUsersTableAdapter();
            int ifSuccessful =
                Convert.ToInt16(adapter.InsertBusinessUser(ubpId, userId, secondaryLocationId));
            return ifSuccessful;

        }

        public DataTable GetManagersByUBPID(int UBPID)
        {
            DataTable newTable = new DataTable();
            IDataReader newReader = newDataProvider.GetManagersByUBPID(UBPID);
            newTable.Load(newReader);
            return newTable;
        }

        public DataTable GetManagersByUserID(int userId)
        {
            DataTable newTable = new DataTable();
            IDataReader newReader = newDataProvider.GetManagersByUserID(userId);
            newTable.Load(newReader);
            return newTable;
        }

        #endregion

        #region NAICSNationalIndustry

        public DataTable GetNationalIndustryByIndex(int index)
        {

            DataTable newTable = new DataTable("NAICNationalIndustry");
            IDataReader newReader = newDataProvider.GetNationalIndustryByIndex(index);
            newTable.Load(newReader);
            return newTable;

        }

        #endregion

        #region BusinessByIndustry

        public int AddBusinessByIndustry(int UBPID, int NAICID, int numberOfNAICSToOneId)
        {

            UberBusinessProfilesByIndustryTableAdapter adapter = new UberBusinessProfilesByIndustryTableAdapter();
            int isSuccessful = Convert.ToInt32(adapter.InsertBusinessByIndustry(UBPID, NAICID, numberOfNAICSToOneId));
            return isSuccessful;
        }

        #endregion

        #region About

        public DataTable GetBusinessProfile(int UBPID)
        {
            UberBusinessProfileTableAdapter adapter = new UberBusinessProfileTableAdapter();
            DataTable newTable = adapter.Uber_GetBusinessProfileByUBPID(UBPID);
            return newTable;
        }

        public DataTable GetMainBusinessProfileByUserID(int userId)
        {
            UberBusinessProfileTableAdapter adapter = new UberBusinessProfileTableAdapter();
            DataTable newTable = adapter.Uber_GetMainBusinessProfileByUserID(userId);
            return newTable;
        }

        #endregion

        #region Region

        public DataTable GetRegion()
        {
            Geo_RegionsTableAdapter adapter = new Geo_RegionsTableAdapter();
            DataTable newTable = adapter.GetData();
            return newTable;
        }

        #endregion

        #region SubRegion

        public DataTable GetSubRegionByRegionCode(int regionCode)
        {
            Geo_SubregionsTableAdapter adapter = new Geo_SubregionsTableAdapter();
            DataTable newTable = adapter.Uber_GetSubRegionByRegionCode(regionCode);
            return newTable;
        }

        #endregion

        #region Country

        public DataTable GetCountry(int subRegionCode)
        {
            Geo_CountriesTableAdapter adapter = new Geo_CountriesTableAdapter();
            DataTable newTable = adapter.Uber_GetCountriesBySubRegionCode(subRegionCode);
            return newTable;
        }

        public DataTable GetAllCountry()
        {
            Geo_CountriesTableAdapter adapter = new Geo_CountriesTableAdapter();
            DataTable newTable = adapter.Uber_GetAllCountries();
            return newTable;
        }

        public DataTable GetCountriesByCountryCode(string CountryCode)
        {
            Geo_CountriesTableAdapter adapter = new Geo_CountriesTableAdapter();
            DataTable newTable = adapter.Uber_GetCountriesByCountryCode(CountryCode);
            return newTable;
        }

        public DataTable GetDistrictsForCityByCityName(string cityName, string countryName)
        {

            DataTable newTable = new DataTable("Geo");
            IDataReader newReader = newDataProvider.GetDistrictsForCityByCityName(cityName, countryName);
            newTable.Load(newReader);
            return newTable;

        }

        public DataTable GetDetailInforForCityDistrictByCityName(string postalLocationName)
        {

            DataTable newTable = new DataTable("GeoDetail");
            IDataReader newReader = newDataProvider.GetDetailInforForCityDistrictByCityName(postalLocationName);
            newTable.Load(newReader);
            return newTable;

        }

        #endregion

        #region State

        public DataTable GetStateByCountryCode(string countryCode)
        {
            Geo_Country_StatesTableAdapter adapter = new Geo_Country_StatesTableAdapter();
            DataTable newTable = adapter.Uber_GetStateByCountryCode(countryCode);
            return newTable;
        }

        #endregion

        #region Cities

        public DataTable GetCitiesByStateCode(string StateCode, string countryName)
        {
            DataTable newTable = new DataTable();
            IDataReader newReader = newDataProvider.GetCitiesByStateCode(StateCode, countryName);
            newTable.Load(newReader);
            return newTable;
        }

        #endregion

        #region JobPosts

        public DataTable GetJobPostsForBusinessByuserID(int userid)
        {
            UberJobPostingTableAdapter adapter = new UberJobPostingTableAdapter();
            DataTable newTable = adapter.Uber_GetJobPostsForBusinessByUserID(userid);
            return newTable;
        }

        public DataTable GetJobPostsForBusinessByUBPID(int UBPid)
        {
            UberJobPostingTableAdapter adapter = new UberJobPostingTableAdapter();
            DataTable newTable = adapter.Uber_GetJobPostsForBusinessByUBPID(UBPid);
            return newTable;
        }

        #endregion

        #region BusinessManagement

        public void UpdateBusinessProfilToMaineByUBPID(int UBPID, int userID)
        {
            UberBusinessProfileTableAdapter adapter = new UberBusinessProfileTableAdapter();
            adapter.Uber_UpdateBusinessProfileToMainByUBPID(UBPID, userID);

        }

        public void DeleteBusinessProfileByUBPID(int UBPID)
        {
            UberBusinessProfileTableAdapter adapter = new UberBusinessProfileTableAdapter();
            adapter.Uber_DeleteBusinessProfileByUBPID(UBPID);

        }

        public int UpdateBusinessProfileByUBPID(int UBPID, string businessName, string shortDescription, string businessMission,
            string businessSlogan, string description, string businessLogo, string vision, string goals, string emailAddress, string phone,
            string fax, string address1, string address2, string city, string region, string subRegion, string countryState, string countryID, string postalCode,
            decimal latitude, decimal longitude, string website, string facebook, string linkedIn, string twitter,
            string youTube, string google, string blog, string shoppingCart, string forum, int rank, bool featured,
            bool isPublic, int portalId, int businessAccountLimit)
        {

            UberBusinessProfileTableAdapter adapter = new UberBusinessProfileTableAdapter();

            return Convert.ToInt16(adapter.Uber_U_UpdateBusinessProfile(UBPID, businessName, shortDescription,
                    businessMission, businessSlogan, description, businessLogo, vision, goals, emailAddress, phone, fax, address1,
                    address2, city, region, subRegion, countryID, countryState, postalCode, latitude, longitude, website, facebook, linkedIn,
                    twitter, youTube, google, blog, shoppingCart, forum, rank, featured, isPublic, portalId, businessAccountLimit));
        }

        #endregion

        #region User Roles

        public int GetUserRoleByUserID(int userID)
        {

            int userRoleID = newDataProvider.GetUserRoleByUserID(userID);

            return userRoleID;

        }

        #endregion
    }
}