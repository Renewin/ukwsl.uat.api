using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class CustomerContactType : Log
    {
        public int ContactTypeId { get; set; }
        public string ContactTypeName { get; set; }
    }
}
