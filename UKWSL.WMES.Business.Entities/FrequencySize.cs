using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
   public class FrequencySize :Log
    {
        public int FrequencyId { get; set; }
        public string FrequencyName { get; set; }
        public string FrequencyDesc { get; set; }
        public int FrequencyTypeId { get; set; }
        public string VisitsPerWeek { get; set; }
        public string FrequencyType_Name { get; set; }
    }
}
