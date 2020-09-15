using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class ContactsAdditionMappingUDT
    {
        public int ContactMappingId { get; set; }
        public int CustomerId { get; set; }
        public int ContactTypeId { get; set; }
        public string AccountIds { get; set; }
        public string SiteIds { get; set; }
        public string GroupIds { get; set; }
    }
}
