using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Repositories.ContractorWeight;
using UKWSL.WMES.Utility;

namespace UKWSL.WMES.Business.ContractorWeight
{
    public class ContractorWeightManager:IContractorWeightManager
    {
        private IContractorWeightRepository _contractorWeightRepository;

        public ContractorWeightManager(IContractorWeightRepository contractorWeightRepository)
        {
            _contractorWeightRepository = contractorWeightRepository;
        }

        /// <summary>
        /// business method to get all Service Weights by ContractorId
        /// </summary>
        /// Delivery Point: Dp4.9
        public ContractorWeightInfo GetAllServiceWeightsbyContractorId(ServiceJobDetails serviceJobDetails)
        {
            return _contractorWeightRepository.GetAllServiceWeightsbyContractorId(serviceJobDetails);
        }

        /// <summary>
        /// business method to get all Customers by ContractorId
        /// </summary>
        /// Delivery Point: Dp4.9
        public ContractorWeightInfo GetAllCustomersbyContractorId(CustomerBasicInfo customerBasicInfo)
        {
            return _contractorWeightRepository.GetAllCustomersbyContractorId(customerBasicInfo);
        }

        /// <summary>
        /// business method to get all Service sites by ContractorId
        /// </summary>
        /// Delivery Point: Dp4.9
        public ContractorWeightInfo GetAllServiceSitesbyContractorId(ServiceSite serviceSite)
        {
            return _contractorWeightRepository.GetAllServiceSitesbyContractorId(serviceSite);
        }

        /// <summary>
        /// business method to get actual weight Details by JobId
        /// </summary>
        /// Delivery Point: Dp4.9
        public ContractorWeightInfo GetActualWeightDetailsByJobId(ServiceBasicInfo serviceBasicInfo)
        {
            return _contractorWeightRepository.GetActualWeightDetailsByJobId(serviceBasicInfo);
        }

        /// <summary>
        /// business method to Create update Service Actual weights
        /// </summary>
        /// Delivery Point: Dp4.9
        public ServiceJobDetails CreateUpdateServiceActualWeight(ServiceJobDetails  serviceJobDetails)
        {
            return _contractorWeightRepository.CreateUpdateServiceActualWeight(serviceJobDetails);
        }

        /// <summary>
        /// business method to upload import Actual weight CSV Raw data
        /// </summary>
        /// Delivery Point: Dp4.9
        public ContractorWeightInfo UploadImportActualWeightCSVRawData(ContractorWeightInfo contractorWeightInfo)
        {

            DataTable _dtAPS = new DataTable();
            _dtAPS = ListtoDataTableConverter.ToDataTable(contractorWeightInfo.lstImportActualWeightUDT);
            return _contractorWeightRepository.UploadImportActualWeightCSVRawData(contractorWeightInfo, _dtAPS);

        }

        /// <summary>
        /// business method to get all import actual weights list
        /// </summary>
        /// Delivery Point: Dp4.9
        public ContractorWeightInfo GetAllImportActualWeights(ImportActualWeight importActualWeight)
        {
            return _contractorWeightRepository.GetAllImportActualWeights(importActualWeight);
        }

        /// <summary>
        /// business method to Insert Upload Import Actual weight Data
        /// </summary>
        /// Delivery Point: Dp4.9
        public ContractorWeightInfo InsertUploadedImportActualWeightData(ContractorWeightInfo contractorWeightInfo)
        {
            return _contractorWeightRepository.InsertUploadedImportActualWeightData(contractorWeightInfo);
        }

        /// <summary>
        /// business method to Cancel Insert Upload Import Actual weight
        /// </summary>
        /// Delivery Point: Dp4.9
        public ContractorWeightInfo CancelInsertUploadedImportActualWeightData(ContractorWeightInfo contractorWeightInfo)
        {
            return _contractorWeightRepository.CancelInsertUploadedImportActualWeightData(contractorWeightInfo);
        }

        /// <summary>
        /// business method to get all Service Pending Report
        /// </summary>
        /// Delivery Point: Dp4.9
        public ContractorWeightInfo GetAllServicePendingReport(ImportActualWeight importActualWeight)
        {
            return _contractorWeightRepository.GetAllServicePendingReport(importActualWeight);
        }

        /// <summary>
        /// business method to get all Services Affected  from Import
        /// </summary>
        /// Delivery Point: Dp4.9
        public ContractorWeightInfo GetAllServiceAffectedFromImport(ImportActualWeight importActualWeight)
        {
            return _contractorWeightRepository.GetAllServiceAffectedFromImport(importActualWeight);
        }

        /// <summary>
        /// business method to get import actual weight by ID
        /// </summary>
        /// Delivery Point: Dp4.9
        public ImportActualWeight GetImportedWeightById(ImportActualWeight importActualWeight)
        {
            return _contractorWeightRepository.GetImportedWeightById(importActualWeight);
        }

        /// <summary>
        /// business method to Update Import weight by Id
        /// </summary>
        /// Delivery Point: Dp4.9
        public ImportActualWeight UpdateImportedWeightById(ImportActualWeight importActualWeight)
        {
            return _contractorWeightRepository.UpdateImportedWeightById(importActualWeight);
        }

        /// <summary>
        /// business method to Process Import Actual weight
        /// </summary>
        /// Delivery Point: Dp4.9
        public ContractorWeightInfo ProcessImportActualWeight(ContractorWeightInfo contractorWeightInfo)
        {
            return _contractorWeightRepository.ProcessImportActualWeight(contractorWeightInfo);
        }

        /// <summary>
        /// business method to Confirm Pending Services
        /// </summary>
        /// Delivery Point: Dp4.9
        public ImportActualWeight PendingServiceConfirmed(ImportActualWeight importActualWeight)
        {
            return _contractorWeightRepository.PendingServiceConfirmed(importActualWeight);
        }

        /// <summary>
        /// business method to get Contractor Office Contact
        /// </summary>
        /// Delivery Point: Dp4.9
        public ContractorWeightInfo GetContractorOfficeContact(ContractorContact contractor)
        {
            return _contractorWeightRepository.GetContractorOfficeContact(contractor);
        }
    }
}
