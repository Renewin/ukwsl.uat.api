using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class PricingMatrixInfo : Result
    {
        public List<Contractor_Config_AreaofCoverage> lstareaofCoverages { get; set; }
        public Contractor_Config_AreaofCoverage areaofCoverage { get; set; }

        public List<Contractor_Config_PotentialService> lstpotentialServices { get; set; }
        public Contractor_Config_PotentialService potentialService { get; set; }

        public List<WasteType> lstWasteTypes { get; set; }
        public List<MaterialType> lstMaterialTypes { get; set; }
        public List<ContainerType> lstContainerTypes { get; set; }

        public List<CustomerBasicInfo> lstCustomers { get; set; }
        public List<Contractor_Config_AreaofCoverage> lstPostCodes { get; set; }

        public PricingMatrixSetup PricingMatrixSetup { get; set; }
        public PricingMatrixDetail PricingMatrixDetail { get; set; }
        public List<PricingMatrixDetail> lstPricingMatrixDetails { get; set; }

        public List<ContractorBasicInfo> lstContractors { get; set; }

        public ContractorAdminSetting ContractorAdminSetting { get; set; }
        public List<PriceUpdate_UpdateReport> lstpriceUpdateReports { get; set; }
        public List<PriceUpdate_ExceptionReport> lstPriceUpdateExceptionReport { get; set; }
        //public SettingUp SettingUp { get; set; }

        public PricingMatrixInfo()
        {
            lstareaofCoverages = new List<Contractor_Config_AreaofCoverage>();
            areaofCoverage = new Contractor_Config_AreaofCoverage();

            lstpotentialServices = new List<Contractor_Config_PotentialService>();
            potentialService = new Contractor_Config_PotentialService();

            lstWasteTypes = new List<WasteType>();
            lstMaterialTypes = new List<MaterialType>();
            lstContainerTypes = new List<ContainerType>();

            PricingMatrixSetup = new PricingMatrixSetup();
            PricingMatrixDetail = new PricingMatrixDetail();

            lstContractors = new List<ContractorBasicInfo>();

            ContractorAdminSetting = new ContractorAdminSetting();
            lstpriceUpdateReports = new List<PriceUpdate_UpdateReport>();
            lstPriceUpdateExceptionReport = new List<PriceUpdate_ExceptionReport>();
            //SettingUp = new SettingUp();
        }
    }
}
