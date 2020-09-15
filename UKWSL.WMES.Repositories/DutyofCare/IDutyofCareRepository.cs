using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities.DoC;

namespace UKWSL.WMES.Repositories.DutyofCare
{
    public interface IDutyofCareRepository
    {
        DOCViewModel GetDOCFinancialYearMaster();
        DOCViewModel InsertOrUpdateFinancialYearMaster(FinancialYearMaster financialYearMaster);
        DOCViewModel GetDOCEmailTemplates();
        DOCViewModel InsertOrUpdateEmailTemplates(EmailTemplatesMaster financialYearMaster);
        DOCViewModel GetWTNDetailsForCustomer(Master_SOS_WasteType model);
        //DOCViewModel InsertOrUpdateWTNDocument(DOCViewModel dOCViewModel);
        DOCViewModel GetDOCTrackerByFY(DoC_DocumentTracker doC_DocumentTracker);
        DOCViewModel GetPageDetailsByFy(DOC_PageDetails doc_pageDetails);
        DOCViewModel GetPageResponseByDOCId(DOCPageResponse doc_pageResponse);
        DOCViewModel GetLetterTracker(LetterTracker letterTracker);
        DOCViewModel InsertOrUpdateOfflineUpload(DOC_OfflineUpload doc_OfflineUpload);
        DOCViewModel InsertOrUpdateLetterTracker(LetterTracker letterTracker);
        DOCViewModel InsertLTEmailDetails(LetterTracker letterTracker);
        DOCViewModel GetDOCHeaderDetailsByCustomerId(DOC_HeaderDetails headerDetails);
        DOCViewModel InsertOrUpdateDOCHeaderDetails(DOCViewModel dOCViewModel);
        DOCViewModel InsertDOCBackingData(DOC_BackingData backingData);
        DOCViewModel GetDOCBackingData(DOC_BackingData backingData);
    }
}
