using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
   public class APIConfiguration : Result
    {
        public int AppId { get; set; }
        public string AppName { get; set; }

        public string AppKey { get; set; }

        public string AppEnvironment { get; set; }

        public bool IsActive { get; set; }
    }
}
