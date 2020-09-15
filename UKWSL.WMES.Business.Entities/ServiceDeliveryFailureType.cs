using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class ServiceDeliveryFailureType:Log
    {
        public int DeliveryFailureTypeId { get; set; }
        public string DeliveryFailureType_Name { get; set; }
        public string DeliveryFailureType_Desc { get; set; }
    }
}
