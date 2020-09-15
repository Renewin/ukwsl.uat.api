using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
  public class APIConfigFunctions : Result
    {

        public int FunctionId { get; set; }
        public int AppId { get; set; }
        public string FunctionName { get; set; }
        public string FunctionURL { get; set; }

        public bool IsActive { get; set; }
    }
}
