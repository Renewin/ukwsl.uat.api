using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class Modules
    {
        public int ModuleId { get; set; }
        public string MainModuleName { get; set; }
        public string PageName { get; set; }
        public int MFunctionId { get; set; }
    }
}
