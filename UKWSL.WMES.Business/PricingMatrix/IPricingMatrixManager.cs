using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;

namespace UKWSL.WMES.Business.PricingMatrix
{
    public interface IPricingMatrixManager
    {
        PricingMatrixInfo GetPostCodeListByContractorId(ContractorBasicInfo contractor);
        PricingMatrixInfo InsertandUpdateAreaofCoverage(Contractor_Config_AreaofCoverage areaofCoverage);
        PricingMatrixInfo CheckAreaofCoverageExists(Contractor_Config_AreaofCoverage areaofCoverage);
        Contractor_Config_AreaofCoverage DeleteAreaofCoverage(Contractor_Config_AreaofCoverage areaofCoverage);
        ContractorAdminSetting UpdateIsNationalSupplier(ContractorAdminSetting contractorAdminSetting);

        PricingMatrixInfo GetPotentialServiceListByContractorId(ContractorBasicInfo contractor);
        PricingMatrixInfo GetPotentialServiceInfo(Contractor_Config_PotentialService potentialService);
        PricingMatrixInfo InsertandUpdatePotentialService(Contractor_Config_PotentialService potentialService);
        PricingMatrixInfo CheckPotentialServiceExists(Contractor_Config_PotentialService potentialService);
        Contractor_Config_PotentialService DeletePotentialService(Contractor_Config_PotentialService potentialService);

        PricingMatrixInfo GetWasteTypeByPotentialService(Contractor_Config_PotentialService potentialService);
        PricingMatrixInfo GetMaterialTypeByPotentialService(Contractor_Config_PotentialService potentialService);
        PricingMatrixInfo GetContainerTypeByPotentialService(Contractor_Config_PotentialService potentialService);

        PricingMatrixInfo GetCustomerList();
        PricingMatrixInfo GetContractorList();
        PricingMatrixInfo GetPostCodesByAreaofCoverage(Contractor_Config_PotentialService potentialService);
        PricingMatrixInfo InsertandUpdatePricingMatrixSetup(PricingMatrixSetup pricingMatrixSetup);
        PricingMatrixInfo InsertandUpdatePricingMatrixDetail(PricingMatrixDetail pricingMatrixDetail);
        PricingMatrixInfo GetPricingMatrixByMatrixId(PricingMatrixSetup pricingMatrixSetup);
        PricingMatrixInfo GetPricingMatrixDetailsByMatrixId(PricingMatrixSetup pricingMatrixSetup);
        PricingMatrixInfo GetPricingMatrixDetailInfoByPMId(PricingMatrixDetail pricingMatrixDetail);
        PricingMatrixSetup DeletePricingMatrixByMatrixId(PricingMatrixSetup pricingMatrix);
        PricingMatrixDetail DeleteMatrixDetailsByPMId(PricingMatrixDetail pricingMatrixDetail);

        CustomerPriceUpdateRestrictionInfo GetCustomerPriceUpdateRestrictionList();
        CustomerPriceUpdateRestrictionInfo GetCustomerPriceUpdateRestrictionHistoryList(CustomerBasicInfo customerBasicInfo);
        CustomerPriceUpdateRestrictionInfo GetCustomerPriceUpdateRestrictionById(CustomerPriceUpdateRestriction customerPriceUpdateRestriction);
        CustomerPriceUpdateRestrictionInfo InsertandUpdateCustomerPriceUpdateRestriction(CustomerPriceUpdateRestriction customerPriceUpdateRestriction);
        CustomerPriceUpdateRestrictionInfo DeleteCustomerPriceUpdateRestriction(CustomerPriceUpdateRestriction customerPriceUpdateRestriction);

        PricingMatrixUploadInfo UploadPricingMatrixDetail(PricingMatrixUploadInfo matrixUploadInfo);
        PricingMatrixUploadInfo PricingMatrixUploadCreateMatrix(PricingMatrixUploadInfo matrixUploadInfo);
        PricingMatrixUploadInfo PricingMatrixUploadCancelUploadProcess(PricingMatrixUploadInfo matrixUploadInfo);
        PricingMatrix_MatrixDetails GetMatrixDetailByMDid(PricingMatrix_MatrixDetails pricingMatrix_MatrixDetails);
        PricingMatrix_MatrixDetails UpdateImportedMatrixPricesById(PricingMatrix_MatrixDetails pricingMatrix_MatrixDetails);
        PricingMatrixUploadInfo ProcessDataPricingMatrixDetail(PricingMatrixUploadInfo matrixUploadInfo);
        PricingMatrixInfo MatrixDetailsExistsornot(PricingMatrixDetail pricingMatrixDetail);
        PricingMatrixSetup UpdateEndDatePricingMatrix(PricingMatrixSetup pricingMatrixSetup);
        PriceUpdateUploadInfo PricingUpdateUploadInsertRawData(PriceUpdateUploadInfo pricingUpdateUploadInfo);
        PriceUpdateUploadInfo PricingUpdateUploadUpdatePrices(PriceUpdateUploadInfo pricingUpdateUploadInfo);
        PriceUpdateUploadInfo PricingUpdateUploadCancelUploadProcess(PriceUpdateUploadInfo pricingUpdateUploadInfo);
        PriceUpdateUploadInfo GetAllPriceUpdateAction();
        PriceUpdateUploadDetails GetUploadedDataByUdid(PriceUpdateUploadDetails priceUpdateUploadDetails);
        PriceUpdateUploadDetails UpdateImportedPriceUpdateById(PriceUpdateUploadDetails priceUpdateUploadDetails);
        PriceUpdateUploadInfo PricingUpdateProcessData(PriceUpdateUploadInfo pricingUpdateUploadInfo);
        PricingMatrixSetup UpdatePrice(PricingMatrixSetup pricingMatrixSetup);
        PricingMatrixSetup CheckMatrixHeaderForPriceUpdate(PricingMatrixSetup pricingMatrixSetup);
        PricingMatrixInfo GetPriceUpdate_UpdateReport(PricingMatrixSetup pricingMatrixSetup);
        PricingMatrixInfo GetPriceUpdate_ExceptionReport(PricingMatrixSetup pricingMatrixSetup);
        PricingMatrixInfo GetBoth_UpdateReportAndExceptionReport(PricingMatrixSetup pricingMatrixSetup);

        PricingMatrixSetup ValidateContractorPriceExist(PricingMatrixSetup matrixSetup);
        PricingMatrixSetup ValidateCustomerPriceExist(PricingMatrixSetup matrixSetup);

    }
}
