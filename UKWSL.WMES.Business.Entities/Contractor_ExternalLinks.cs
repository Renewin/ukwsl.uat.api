using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class Contractor_ExternalLinks : Log
    {
        public int ExtLinkId { get; set; }
        public int ContractorId { get; set; }
        public string ExternalLink { get; set; }
        public string ExternalComments { get; set; }
        public string UKWSLComments { get; set; }
        public DateTime LinkSentOn { get; set; }
        public DateTime LinkExpiresOn { get; set; }
        public bool IsLinkOpened { get; set; }
        public bool IsAuthenticated { get; set; }
        public bool IsSubmitted { get; set; }
        public bool IsApproved { get; set; }
        public bool IsArchived { get; set; }
        public string ActionFlag { get; set; }
    }
}
