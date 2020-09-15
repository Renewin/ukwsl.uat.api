using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class JobType : Log
    {
        public int JobTypeId { get; set; }
        public string JobTypeName { get; set; }
        public string JobType_Desc { get; set; }
    }
}
