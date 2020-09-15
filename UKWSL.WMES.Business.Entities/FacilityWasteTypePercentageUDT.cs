using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class FacilityWasteTypePercentageUDT
    {
        public int FacilityId { get; set; }
        public int WasteTypeId { get; set; }
        public decimal LandfillPercentage { get; set; }
        public decimal RecoveredPercentage { get; set; }
        public decimal RecycledPercentage { get; set; }
        public decimal TotalPercentage { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }

}
