using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities.DoC
{
    public class FinancialYearMaster
    {
        public int FYId { get; set; }
        public string FY_Name { get; set; }
        public DateTime FY_StartDate { get; set; }
        public DateTime FY_EndDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
