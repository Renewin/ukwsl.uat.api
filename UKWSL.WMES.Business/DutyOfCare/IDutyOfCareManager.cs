using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities.DoC;
using UKWSL.WMES.Repositories.DutyofCare;

namespace UKWSL.WMES.Business.DutyOfCare
{
    public interface IDutyOfCareManager
    {
        DOCViewModel GetDOCFinancialYearMaster();
        DOCViewModel InsertOrUpdateFinancialYearMaster(FinancialYearMaster financialYearMaster);
        DOCViewModel GetDOCEmailTemplates();
        DOCViewModel InsertOrUpdateEmailTemplates(EmailTemplatesMaster financialYearMaster);
        DOCViewModel GetWTNDetailsForCustomer(Master_SOS_WasteType model);
        //DOCViewModel InsertOrUpdateWTNDocument(DOCViewModel documentDetails);
        DOCViewModel GetDOCTrackerByFY(DoC_DocumentTracker model);
        DOCViewModel GetPageDetailsByFy(DOC_PageDetails pageDetails);
        DOCViewModel GetPageResponseByDOCId(DOCPageResponse pageResponse);
        DOCViewModel GetLetterTracker(LetterTracker letterTracker);
        DOCViewModel InsertOrUpdateOfflineUpload(DOC_OfflineUpload dOC_OfflineUpload);
        DOCViewModel GetDOCHeaderDetailsByCustomerId(DOC_HeaderDetails headerDetails);
        DOCViewModel InsertOrUpdateLetterTracker(LetterTracker letterTracker);
        DOCViewModel InsertLTEmailDetails(LetterTracker letterTracker);
        DOCViewModel InsertOrUpdateDOCHeaderDetails(DOCViewModel dOCViewModel);
        DOCViewModel InsertDOCBackingData(DOC_BackingData backingData);
        DOCViewModel GetDOCBackingData(DOC_BackingData backingData);
    }
}
