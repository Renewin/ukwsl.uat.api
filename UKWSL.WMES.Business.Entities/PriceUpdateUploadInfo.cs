using System.Collections.Generic;

namespace UKWSL.WMES.Business.Entities
{
    public class PriceUpdateUploadInfo : Result
    {       
        public int UploadHeaderId { get; set; }
        public string FileLocation { get; set; }
        public int CreatedBy { get; set; }
        public int ReturnId { get; set; }
        public int ActionHeaderId { get; set; }
        public List<PriceUpdateUploadDetailsUDT> lstPricingUpdatesUDT { get; set; }
        public PriceUpdateUploadDetails PricingUpdateDetail { get; set; }
        public List<PriceUpdateUploadDetails> lstPassedPricingUpdateDetail { get; set; }
        public List<PriceUpdateUploadDetails> lstFailedPricingUpdateDetail { get; set; }
        public List<PriceUpdate_ActionHeader> lstPriceUpdate_Action { get; set; }
    }
}
