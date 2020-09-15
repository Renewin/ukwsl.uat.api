using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class CountyInfo:Log
    {
        public int CountyidId { get; set; }
        public string CountyName { get; set; }
        public string CountyDesc { get; set; }
    }
}
