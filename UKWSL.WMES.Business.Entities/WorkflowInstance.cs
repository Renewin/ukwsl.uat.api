using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
   public class WorkflowInstance :Result
    {
        public int  WFInstanceId { get; set; }
        public int RequestId { get; set; }
        public string RequestNo { get; set; }
        public  string Comments { get; set; }
        public string CreatedBy { get; set; }
        public string ActionCode { get; set; }
        public int ProcessId { get; set; }
        public int StateId { get; set; }
        public string WFCode { get; set; }
    }
}
