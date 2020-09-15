using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities.DoC
{
    public class Master_SOS_WasteType : Result
    {
        public int JobId { get; set; }
        public int Customer_SiteId { get; set; }
        public string MaterialType_Name { get; set; }
        public string EWCCode { get; set; }
        public string Transferor_FullName { get; set; }
        public string Transferor_CompanyName { get; set; }
        public string Transferor_StreetAddress1 { get; set; }
        public string Transferor_StreetAddress2 { get; set; }
        public string Transferor_Town { get; set; }
        public string Transferor_County { get; set; }
        public string Transferor_PostCode { get; set; }
        public string Transferor_CompanySICCode { get; set; }
        public string Transferee_FullName { get; set; }
        public string Transferee_CompanyName { get; set; }
        public string Transferee_AddressLine1 { get; set; }
        public string Transferee_AddressLine2 { get; set; }
        public string Transferee_County { get; set; }
        public string Transferee_Town { get; set; }
        public string Transferee_PostCode { get; set; }
        public string FacilityName { get; set; }
        public string Trasnfer_AddressLine1 { get; set; }
        public string Trasnfer_AddressLine2 { get; set; }
        public string Trasnfer_Town { get; set; }
        public string Trasnfer_County { get; set; }
        public string Trasnfer_PostCode { get; set; }
        public string DateofTransfer { get; set; }
        public int CustomerId { get; set; }
        public int AccountId { get; set; }
        public int GroupId { get; set; }
        public bool IncludeUnScheduledService { get; set; }
        public int FYId { get; set; }
        public string SectionA2 { get; set; }
        public string SectionA3 { get; set; }
        public string RegistrationNumber { get; set; }
        public string CarrierorBroker { get; set; }
        public string CompanyName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Postcode { get; set; }
        public string WCL_RegistrationNumber { get; set; }
        public string RegistrationNumber1 { get; set; }
        public string DOCRepresentativeFullName { get; set; }
        public string DOCRepresentativeSignature { get; set; }

    }
}
