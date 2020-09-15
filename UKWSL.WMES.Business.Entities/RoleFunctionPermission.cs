using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class RoleFunctionPermission : Log
    {
        public int PMappingId { get; set; }
        public int MFunctionId { get; set; }
        public int RoleId { get; set; }
        public string MainModuleName { get; set; }
        public string FunctionName { get; set; }
        public string PageName { get; set; }
        public bool IsGranted { get; set; }

        public int ModuleId { get; set; }
        public string FunctionId { get; set; }
    }
}
