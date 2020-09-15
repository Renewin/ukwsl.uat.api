using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities.DoC;
using UKWSL.WMES.Repositories.DutyofCare;
using UKWSL.WMES.Utility;

namespace UKWSL.WMES.Business.DutyOfCare
{
    public class DutyOfCareManager : IDutyOfCareManager
    {
        private IDutyofCareRepository _dutyofCareRepository;

        public DutyOfCareManager(IDutyofCareRepository dutyofCareRepository)
        {
            _dutyofCareRepository = dutyofCareRepository;
        }

        public DOCViewModel GetDOCFinancialYearMaster()
        {
            return _dutyofCareRepository.GetDOCFinancialYearMaster();
        }

        public DOCViewModel InsertOrUpdateFinancialYearMaster(FinancialYearMaster financialYearMaster)
        {
            return _dutyofCareRepository.InsertOrUpdateFinancialYearMaster(financialYearMaster);
        }
        public DOCViewModel GetDOCEmailTemplates()
        {
            return _dutyofCareRepository.GetDOCEmailTemplates();
        }
        public DOCViewModel InsertOrUpdateEmailTemplates(EmailTemplatesMaster emailTemplates)
        {
            return _dutyofCareRepository.InsertOrUpdateEmailTemplates(emailTemplates);

        }

        public DOCViewModel GetWTNDetailsForCustomer(Master_SOS_WasteType model)
        {
            return _dutyofCareRepository.GetWTNDetailsForCustomer(model);
        }

        //public DOCViewModel InsertOrUpdateWTNDocument(DOCViewModel documentDetails)
        //{
            
        //    return _dutyofCareRepository.InsertOrUpdateWTNDocument(documentDetails);
        //}

        public DOCViewModel GetDOCTrackerByFY(DoC_DocumentTracker model)
        {
            return _dutyofCareRepository.GetDOCTrackerByFY(model);

        }
        public DOCViewModel GetPageDetailsByFy(DOC_PageDetails pageDetails)
        {
            return _dutyofCareRepository.GetPageDetailsByFy(pageDetails);
        }
        public DOCViewModel GetPageResponseByDOCId(DOCPageResponse pageResponse)
        {
            return _dutyofCareRepository.GetPageResponseByDOCId(pageResponse);
        }
        public DOCViewModel GetLetterTracker(LetterTracker letterTracker)
        {
            return _dutyofCareRepository.GetLetterTracker(letterTracker);
        }

        public DOCViewModel InsertOrUpdateOfflineUpload(DOC_OfflineUpload upload)
        {
            return _dutyofCareRepository.InsertOrUpdateOfflineUpload(upload);
        }
        public DOCViewModel InsertOrUpdateLetterTracker(LetterTracker letterTracker)
        {
            return _dutyofCareRepository.InsertOrUpdateLetterTracker(letterTracker);
        }

        public DOCViewModel InsertLTEmailDetails(LetterTracker letterTracker)
        {
            return _dutyofCareRepository.InsertLTEmailDetails(letterTracker);
        }
        public DOCViewModel InsertOrUpdateDOCHeaderDetails(DOCViewModel dOCViewModel)
        {
            return _dutyofCareRepository.InsertOrUpdateDOCHeaderDetails(dOCViewModel);
        }
        public DOCViewModel GetDOCHeaderDetailsByCustomerId(DOC_HeaderDetails headerDetails)
        {
            return _dutyofCareRepository.GetDOCHeaderDetailsByCustomerId(headerDetails);
        }
        public DOCViewModel InsertDOCBackingData(DOC_BackingData backingData)
        {
            return _dutyofCareRepository.InsertDOCBackingData(backingData);
        }
        public DOCViewModel GetDOCBackingData(DOC_BackingData backingData)
        {
            return _dutyofCareRepository.GetDOCBackingData(backingData);
        }
    }
}
