using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
   public class WorkflowStatus :Result
    {
        public string WFState { get; set; }
        public int IsSOSExist { get; set; }

    }
}
