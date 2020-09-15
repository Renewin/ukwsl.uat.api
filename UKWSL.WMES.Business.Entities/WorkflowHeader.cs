using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
  public  class WorkflowHeader
    {
        public int RequestId { get; set; }
        public string RequestNo { get; set; }

        public string WorkflowDetailCode { get; set; }
        public string WorkflowCode { get; set; }

        public string CreatedBy { get; set; }
    }
}
