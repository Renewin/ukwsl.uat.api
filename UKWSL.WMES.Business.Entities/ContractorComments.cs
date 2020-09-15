using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class ContractorComments: Log
    {
        public int ContractorId { get; set; }
        public int ConCommentId { get; set; }
        public string GeneralComments { get; set; }
        public string InvoicingComments { get; set; }
    }
}
