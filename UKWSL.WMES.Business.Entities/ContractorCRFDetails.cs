using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class ContractorCRFDetails:Log
    {
        public int CRF_DocId { get; set; }
        public int ContractorId { get; set; }
        public int CustomerId { get; set; }
        public int Customer_DocumentId { get; set; }
        public string DocDescription { get; set; }
        public int SharepointId { get; set; }
        public string DocFileName { get; set; }
        public string SharepointFileReference { get; set; }
    }   
}
