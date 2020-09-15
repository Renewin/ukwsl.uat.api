using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities.DoC
{
    public class DOCViewModel : Result
    {
        public List<FinancialYearMaster> lstFinancialYearMasters { get; set; }
        public List<EmailTemplatesMaster> lstEmailTemplatesMaster { get; set; }
        public FinancialYearMaster financialYearMaster { get; set; }
        public EmailTemplatesMaster emailTemplatesMaster { get; set; }
        public List<Master_SOS_WasteType> lstMaster_SOS_WasteTypes { get; set; }
        public List<DOC_BackingData> lstBackingData { get; set; }
        public DOC_HeaderDetails dOC_HeaderDetails { get; set; }
        public DOC_BackingData doc_BackingData { get; set; }
        public List<DOC_HeaderDetails> lstDOC_HeaderDetails { get; set; }
        public List<DOC_PageDetails> lstDOC_PageDetails { get; set; }
        public DOC_PageDetails dOC_PageDetails { get; set; }
        public List<DoC_DocumentTracker> lstDoC_DocumentTrackers { get; set; }
        public DOC_OfflineUpload dOC_OfflineUpload { get; set; }
        public LetterTracker letterTracker { get; set; }
        public List<LetterTracker> lstletterTrackers { get; set; }
        public List<DOCPageResponse> lstDOCPageResponses { get; set; }

        public DOCViewModel()
        {
            lstFinancialYearMasters = new List<FinancialYearMaster>();
            financialYearMaster = new FinancialYearMaster();
            lstEmailTemplatesMaster = new List<EmailTemplatesMaster>();
            emailTemplatesMaster = new EmailTemplatesMaster();
            lstMaster_SOS_WasteTypes = new List<Master_SOS_WasteType>();
            lstBackingData = new List<DOC_BackingData>();
            dOC_HeaderDetails = new DOC_HeaderDetails();
            lstDOC_HeaderDetails = new List<DOC_HeaderDetails>();
            lstDOC_PageDetails = new List<DOC_PageDetails>();
            dOC_PageDetails = new DOC_PageDetails();
            lstDoC_DocumentTrackers = new List<DoC_DocumentTracker>();
            dOC_OfflineUpload = new DOC_OfflineUpload();
            letterTracker = new LetterTracker();
            lstletterTrackers = new List<LetterTracker>();
            lstDOCPageResponses = new List<DOCPageResponse>();
            doc_BackingData = new DOC_BackingData();
        }
    }
}
