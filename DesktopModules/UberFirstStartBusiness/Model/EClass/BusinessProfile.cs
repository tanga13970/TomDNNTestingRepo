using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetNuke.Modules.UberFirstStartBusiness.Model.EClass
{
    
    public class BusinessProfile
    {
        public int UBPID { get; set; }
        public string BusinessName { get; set; }
        public string ShortDescription { get; set; }
        public string BusinessMissionStatement { get; set; }
        public string BusinessSlogan { get; set; }
        public string Description { get; set; }
        public string BusinessLogo { get; set; }
        public string Vision { get; set; }
        public string Goals { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Region { get; set; }
        public string SubRegion { get; set; }
        public string CountryID { get; set; }
        public string CountryState { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        
        public string Website { get; set; }
        public string Facebook { get; set; }
        public string LinkedIn { get; set; }
        public string Twitter { get; set; }
        public string YouTube { get; set; }

    }
}