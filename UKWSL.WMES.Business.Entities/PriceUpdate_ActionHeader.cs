using System;

namespace UKWSL.WMES.Business.Entities
{
    public class PriceUpdate_ActionHeader : Result
    {
        public int ActionHeaderId { get; set; }
        public int PriceUpdateActionId { get; set; }
        public string ProcessedBy { get; set; }
        public DateTime ProcessedOn { get; set; }
        public string PriceUpdateAction { get; set; }
        public bool IsActive { get; set; }
    }
}
