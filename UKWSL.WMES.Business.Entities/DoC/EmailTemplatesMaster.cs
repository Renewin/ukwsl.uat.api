using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities.DoC
{
    public class EmailTemplatesMaster
    {
        public int DOC_TemplateTypeId { get; set; }
        public string DOC_EmailTemplateName { get; set; }
        public string DOC_EmailSubject { get; set; }
        public int DOC_EmailAfterDays { get; set; }
        public string DOC_TemplateURL { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }

    }
}
