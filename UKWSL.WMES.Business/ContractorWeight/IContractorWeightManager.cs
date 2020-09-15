using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;

namespace UKWSL.WMES.Business.ContractorWeight
{
    public interface IContractorWeightManager
    {
        ContractorWeightInfo GetAllServiceWeightsbyContractorId(ServiceJobDetails serviceJobDetails);
        ContractorWeightInfo GetAllCustomersbyContractorId(CustomerBasicInfo customerBasicInfo);
        ContractorWeightInfo GetAllServiceSitesbyContractorId(ServiceSite serviceSite);
        ContractorWeightInfo GetActualWeightDetailsByJobId(ServiceBasicInfo serviceBasicInfo);
        ServiceJobDetails CreateUpdateServiceActualWeight(ServiceJobDetails serviceJobDetails);
        ContractorWeightInfo UploadImportActualWeightCSVRawData(ContractorWeightInfo contractorWeightInfo);
        ContractorWeightInfo GetAllImportActualWeights(ImportActualWeight importActualWeight);
        ContractorWeightInfo InsertUploadedImportActualWeightData(ContractorWeightInfo contractorWeightInfo);
        ContractorWeightInfo CancelInsertUploadedImportActualWeightData(ContractorWeightInfo contractorWeightInfo);
        ContractorWeightInfo GetAllServicePendingReport(ImportActualWeight importActualWeight);
        ContractorWeightInfo GetAllServiceAffectedFromImport(ImportActualWeight importActualWeight);
        ImportActualWeight GetImportedWeightById(ImportActualWeight importActualWeight);
        ImportActualWeight PendingServiceConfirmed(ImportActualWeight importActualWeight);
        ContractorWeightInfo GetContractorOfficeContact(ContractorContact contractor);
        ImportActualWeight UpdateImportedWeightById(ImportActualWeight importActualWeight);
        ContractorWeightInfo ProcessImportActualWeight(ContractorWeightInfo contractorWeightInfo);

    }
}
