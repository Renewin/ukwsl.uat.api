using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Repositories.PricingMatrix;
using UKWSL.WMES.Utility;

namespace UKWSL.WMES.Business.PricingMatrix
{
    public class PricingMatrixManager : IPricingMatrixManager
    {
        private IPricingMatrixRepository _pricingMatrixRepository;

        public PricingMatrixManager(IPricingMatrixRepository pricingMatrixRepository)
        {
            _pricingMatrixRepository = pricingMatrixRepository;
        }

        #region Area of Coverage
        public PricingMatrixInfo GetPostCodeListByContractorId(ContractorBasicInfo contractor)
        {
            return _pricingMatrixRepository.GetPostCodeListByContractorId(contractor);
        }

        public PricingMatrixInfo InsertandUpdateAreaofCoverage(Contractor_Config_AreaofCoverage areaofCoverage)
        {
            return _pricingMatrixRepository.InsertandUpdateAreaofCoverage(areaofCoverage);
        }

        public PricingMatrixInfo CheckAreaofCoverageExists(Contractor_Config_AreaofCoverage areaofCoverage)
        {
            return _pricingMatrixRepository.CheckAreaofCoverageExists(areaofCoverage);
        }

        public Contractor_Config_AreaofCoverage DeleteAreaofCoverage(Contractor_Config_AreaofCoverage areaofCoverage)
        {
            return _pricingMatrixRepository.DeleteAreaofCoverage(areaofCoverage);
        }

        public ContractorAdminSetting UpdateIsNationalSupplier(ContractorAdminSetting contractorAdminSetting)
        {
            return _pricingMatrixRepository.UpdateIsNationalSupplier(contractorAdminSetting);
        }

        #endregion

        #region Potential Service
        public PricingMatrixInfo GetPotentialServiceListByContractorId(ContractorBasicInfo contractor)
        {
            return _pricingMatrixRepository.GetPotentialServiceListByContractorId(contractor);
        }

        public PricingMatrixInfo GetPotentialServiceInfo(Contractor_Config_PotentialService potentialService)
        {
            return _pricingMatrixRepository.GetPotentialServiceInfo(potentialService);
        }
        
        public PricingMatrixInfo InsertandUpdatePotentialService(Contractor_Config_PotentialService potentialService)
        {
            return _pricingMatrixRepository.InsertandUpdatePotentialService(potentialService);
        }

        public PricingMatrixInfo CheckPotentialServiceExists(Contractor_Config_PotentialService potentialService)
        {
            return _pricingMatrixRepository.CheckPotentialServiceExists(potentialService);
        }

        public Contractor_Config_PotentialService DeletePotentialService(Contractor_Config_PotentialService potentialService)
        {
            return _pricingMatrixRepository.DeletePotentialService(potentialService);
        }

        public PricingMatrixInfo GetWasteTypeByPotentialService(Contractor_Config_PotentialService potentialService)
        {
            return _pricingMatrixRepository.GetWasteTypeByPotentialService(potentialService);
        }

        public PricingMatrixInfo GetMaterialTypeByPotentialService(Contractor_Config_PotentialService potentialService)
        {
            return _pricingMatrixRepository.GetMaterialTypeByPotentialService(potentialService);
        }

        public PricingMatrixInfo GetContainerTypeByPotentialService(Contractor_Config_PotentialService potentialService)
        {
            return _pricingMatrixRepository.GetContainerTypeByPotentialService(potentialService);
        }

        #endregion

        #region Pricing Matrix Contractor / Customer
        public PricingMatrixInfo GetCustomerList()
        {
            return _pricingMatrixRepository.GetCustomerList();
        }

        public PricingMatrixInfo GetContractorList()
        {
            return _pricingMatrixRepository.GetContractorList();
        }

        public PricingMatrixInfo GetPostCodesByAreaofCoverage(Contractor_Config_PotentialService potentialService)
        {
            return _pricingMatrixRepository.GetPostCodesByAreaofCoverage(potentialService);
        }

        public PricingMatrixInfo InsertandUpdatePricingMatrixSetup(PricingMatrixSetup pricingMatrixSetup)
        {
            return _pricingMatrixRepository.InsertandUpdatePricingMatrixSetup(pricingMatrixSetup);
        }

        public PricingMatrixInfo InsertandUpdatePricingMatrixDetail(PricingMatrixDetail pricingMatrixDetail)
        {
            return _pricingMatrixRepository.InsertandUpdatePricingMatrixDetail(pricingMatrixDetail);
        }

        public PricingMatrixInfo GetPricingMatrixByMatrixId(PricingMatrixSetup pricingMatrixSetup)
        {
            return _pricingMatrixRepository.GetPricingMatrixByMatrixId(pricingMatrixSetup);
        }

        public PricingMatrixInfo GetPricingMatrixDetailsByMatrixId(PricingMatrixSetup pricingMatrixSetup)
        {
            return _pricingMatrixRepository.GetPricingMatrixDetailsByMatrixId(pricingMatrixSetup);
        }

        public PricingMatrixInfo GetPricingMatrixDetailInfoByPMId(PricingMatrixDetail pricingMatrixDetail)
        {
            return _pricingMatrixRepository.GetPricingMatrixDetailInfoByPMId(pricingMatrixDetail);
        }

        public PricingMatrixSetup DeletePricingMatrixByMatrixId(PricingMatrixSetup pricingMatrix)
        {
            return _pricingMatrixRepository.DeletePricingMatrixByMatrixId(pricingMatrix);
        }

        public PricingMatrixDetail DeleteMatrixDetailsByPMId(PricingMatrixDetail pricingMatrixDetail)
        {
            return _pricingMatrixRepository.DeleteMatrixDetailsByPMId(pricingMatrixDetail);
        }

        public PricingMatrixSetup ValidateContractorPriceExist(PricingMatrixSetup matrixSetup)
        {
            return _pricingMatrixRepository.ValidateContractorPriceExist(matrixSetup);
        }

        public PricingMatrixSetup ValidateCustomerPriceExist(PricingMatrixSetup matrixSetup)
        {
            return _pricingMatrixRepository.ValidateCustomerPriceExist(matrixSetup);
        }

        public PricingMatrixInfo MatrixDetailsExistsornot(PricingMatrixDetail pricingMatrixDetail)
        {
            return _pricingMatrixRepository.MatrixDetailsExistsornot(pricingMatrixDetail);
        }
        public PricingMatrixSetup UpdateEndDatePricingMatrix(PricingMatrixSetup pricingMatrixSetup)
        {
            return _pricingMatrixRepository.UpdateEndDatePricingMatrix(pricingMatrixSetup);
        }

        #endregion

        #region Customer Price Update Restriction

        public CustomerPriceUpdateRestrictionInfo GetCustomerPriceUpdateRestrictionList()
        {
            return _pricingMatrixRepository.GetCustomerPriceUpdateRestrictionList();
        }

        public CustomerPriceUpdateRestrictionInfo GetCustomerPriceUpdateRestrictionHistoryList(CustomerBasicInfo customerBasicInfo)
        {
            return _pricingMatrixRepository.GetCustomerPriceUpdateRestrictionHistoryList(customerBasicInfo);
        }

        public CustomerPriceUpdateRestrictionInfo GetCustomerPriceUpdateRestrictionById(CustomerPriceUpdateRestriction customerPriceUpdateRestriction)
        {
            return _pricingMatrixRepository.GetCustomerPriceUpdateRestrictionById(customerPriceUpdateRestriction);
        }

        public CustomerPriceUpdateRestrictionInfo InsertandUpdateCustomerPriceUpdateRestriction(CustomerPriceUpdateRestriction customerPriceUpdateRestriction)
        {
            return _pricingMatrixRepository.InsertandUpdateCustomerPriceUpdateRestriction(customerPriceUpdateRestriction);
        }

        public CustomerPriceUpdateRestrictionInfo DeleteCustomerPriceUpdateRestriction(CustomerPriceUpdateRestriction customerPriceUpdateRestriction)
        {
            return _pricingMatrixRepository.DeleteCustomerPriceUpdateRestriction(customerPriceUpdateRestriction);
        }

        #endregion

        #region Pricing Matrix Upload
        public PricingMatrixUploadInfo UploadPricingMatrixDetail(PricingMatrixUploadInfo matrixUploadInfo)
        {
            DataTable _dtPMD = new DataTable();
            _dtPMD = ListtoDataTableConverter.ToDataTable(matrixUploadInfo.lstMatrixDetailsUDT);
            return _pricingMatrixRepository.UploadPricingMatrixDetailRawData(matrixUploadInfo, _dtPMD);
        }

        public PricingMatrixUploadInfo PricingMatrixUploadCreateMatrix(PricingMatrixUploadInfo matrixUploadInfo)
        {
            return _pricingMatrixRepository.PricingMatrixUploadCreateMatrix(matrixUploadInfo);
        }

        public PricingMatrixUploadInfo PricingMatrixUploadCancelUploadProcess(PricingMatrixUploadInfo matrixUploadInfo)
        {
            return _pricingMatrixRepository.PricingMatrixUploadCancelUploadProcess(matrixUploadInfo);
        }

        public PricingMatrix_MatrixDetails GetMatrixDetailByMDid(PricingMatrix_MatrixDetails pricingMatrix_MatrixDetails)
        {
            return _pricingMatrixRepository.GetMatrixDetailByMDid(pricingMatrix_MatrixDetails);
        }

        public PricingMatrix_MatrixDetails UpdateImportedMatrixPricesById(PricingMatrix_MatrixDetails pricingMatrix_MatrixDetails)
        {
            return _pricingMatrixRepository.UpdateImportedMatrixPricesById(pricingMatrix_MatrixDetails);
        }

        public PricingMatrixUploadInfo ProcessDataPricingMatrixDetail(PricingMatrixUploadInfo matrixUploadInfo)
        {
            return _pricingMatrixRepository.ProcessDataPricingMatrixDetail(matrixUploadInfo);
        }
        #endregion

        #region Pricing Update Upload
        public PriceUpdateUploadInfo PricingUpdateUploadInsertRawData(PriceUpdateUploadInfo pricingUpdateUploadInfo)
        {
            DataTable _dtPUD = new DataTable();
            _dtPUD = ListtoDataTableConverter.ToDataTable(pricingUpdateUploadInfo.lstPricingUpdatesUDT);
            return _pricingMatrixRepository.PricingUpdateUploadInsertRawData(pricingUpdateUploadInfo, _dtPUD);
        }

        public PriceUpdateUploadInfo PricingUpdateUploadUpdatePrices(PriceUpdateUploadInfo pricingUpdateUploadInfo)
        {
            return _pricingMatrixRepository.PricingUpdateUploadUpdatePrices(pricingUpdateUploadInfo);
        }

        public PriceUpdateUploadInfo PricingUpdateUploadCancelUploadProcess(PriceUpdateUploadInfo pricingUpdateUploadInfo)
        {
            return _pricingMatrixRepository.PricingUpdateUploadCancelUploadProcess(pricingUpdateUploadInfo);
        }

        public PriceUpdateUploadInfo GetAllPriceUpdateAction()
        {
            return _pricingMatrixRepository.GetAllPriceUpdateAction();
        }

        public PriceUpdateUploadDetails GetUploadedDataByUdid(PriceUpdateUploadDetails priceUpdateUploadDetails)
        {
            return _pricingMatrixRepository.GetUploadedDataByUdid(priceUpdateUploadDetails);
        }

        public PriceUpdateUploadDetails UpdateImportedPriceUpdateById(PriceUpdateUploadDetails priceUpdateUploadDetails)
        {
            return _pricingMatrixRepository.UpdateImportedPriceUpdateById(priceUpdateUploadDetails);
        }

        public PriceUpdateUploadInfo PricingUpdateProcessData(PriceUpdateUploadInfo pricingUpdateUploadInfo)
        {
            return _pricingMatrixRepository.PricingUpdateProcessData(pricingUpdateUploadInfo);
        }
        #endregion

        #region Update Price Contractor/Customer 
        public PricingMatrixSetup UpdatePrice(PricingMatrixSetup pricingMatrixSetup)
        {
            return _pricingMatrixRepository.UpdatePrice(pricingMatrixSetup);
        }
        public PricingMatrixSetup CheckMatrixHeaderForPriceUpdate(PricingMatrixSetup pricingMatrixSetup)
        {
            return _pricingMatrixRepository.CheckMatrixHeaderForPriceUpdate(pricingMatrixSetup);
        }
        public PricingMatrixInfo GetPriceUpdate_UpdateReport(PricingMatrixSetup pricingMatrixSetup)
        {
            return _pricingMatrixRepository.GetPriceUpdate_UpdateReport(pricingMatrixSetup);
        }
        public PricingMatrixInfo GetPriceUpdate_ExceptionReport(PricingMatrixSetup pricingMatrixSetup)
        {
            return _pricingMatrixRepository.GetPriceUpdate_ExceptionReport(pricingMatrixSetup);
        }
        public PricingMatrixInfo GetBoth_UpdateReportAndExceptionReport(PricingMatrixSetup pricingMatrixSetup)
        {
            PricingMatrixInfo objpricingMatrixInfo = new PricingMatrixInfo();
            objpricingMatrixInfo.lstpriceUpdateReports= _pricingMatrixRepository.GetPriceUpdate_UpdateReport(pricingMatrixSetup).lstpriceUpdateReports;
            objpricingMatrixInfo.lstPriceUpdateExceptionReport = _pricingMatrixRepository.GetPriceUpdate_ExceptionReport(pricingMatrixSetup).lstPriceUpdateExceptionReport;
            return objpricingMatrixInfo;
        }

        #endregion
    }
}
