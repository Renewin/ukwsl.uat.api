using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
   public class ContainerType :Log
    {

        public int ContainerTypeId { get; set; }
        public string ContainerTypeName { get; set; }
        public string ContainerTypeDesc { get; set; }
    }
}
