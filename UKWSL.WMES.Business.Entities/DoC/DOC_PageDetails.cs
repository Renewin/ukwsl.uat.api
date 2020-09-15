using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities.DoC
{
    public class DOC_PageDetails
    {
        public int DOC_PageId { get; set; }
        public int DOCId { get; set; }
        public int JobId { get; set; }

        public int CustomerId { get; set; }

        public int FYId { get; set; }
        public int DOCPageNumber { get; set; }
        public int WasteTypeId { get; set; }
        public int MaterialTypeId { get; set; }
        public int ContainerTypeId { get; set; }
        public string DOC_PageContent { get; set; }
        public int ContainerSizeid { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }

    }
}
