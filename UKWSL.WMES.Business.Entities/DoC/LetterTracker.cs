using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities.DoC
{
    public class LetterTracker
    {
        public int LetterTrackerId { get; set; }
        public int DOCId { get; set; }
        public int DOC_TemplateTypeId { get; set; }
        public string PostStatus { get; set; }
        public string DOC_EmailLink { get; set; }
        public string DOC_ContactEmail { get; set; }
        public bool IsLinkOpened { get; set; }
        public string Sent_to { get; set; }
        public string Sent_cc { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
        public bool IsEmailSent { get; set; }
        public DateTime SentOn { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Status { get; set; }
        public string ActionFlag { get; set; }

    }
}
