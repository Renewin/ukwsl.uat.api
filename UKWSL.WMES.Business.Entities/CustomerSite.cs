using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class CustomerSite : Log
    {
        public int Customer_SiteId { get; set; }
        public int CustomerId { get; set; }
        public int AccountId { get; set; }
        public string SiteCode { get; set; }
        public string SiteName { get; set; }
        public string Sites { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public string AccessComments { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string GroupIds { get; set; }
        public string GroupName { get; set; }
        public string SiteIds { get; set; }
        public int ContractorId { get; set; }
        public string Site_SicCode { get; set; }
        public string Region { get; set; }
        public int RegionId { get; set; }
        public string Country { get; set; }
    }
    public class ServiceSite : CustomerSite
    {
        public int GeneralWaste { get; set; }
        public int CapitalWaste { get; set; }
        public int HazardousWaste { get; set; }
        public int RecyclingWaste { get; set; }
        public int WashroomWaste { get; set; }
        public int ActiveServices { get; set; }
        public int TotalServices { get; set; }
        public string Address { get; set; }
        public string AssociatedGeneralWasteMaterialTypes { get; set; }
        public string AssociatedHazardousWasteMaterialTypes { get; set; }
        public string AssociatedRecyclingWasteMaterialTypes { get; set; }
        public string AssociatedCapitalWasteMaterialTypes { get; set; }
        public string AssociatedWashroomWasteMaterialTypes { get; set; }
    }
}
