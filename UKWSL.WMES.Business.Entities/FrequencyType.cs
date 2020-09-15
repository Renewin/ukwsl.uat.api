using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class FrequencyType : Log
    {
        public int FrequencyTypeId { get; set; }
        public string FrequencyTypeName { get; set; }
        public string FrequencyTypeDesc { get; set; }
    }
}
