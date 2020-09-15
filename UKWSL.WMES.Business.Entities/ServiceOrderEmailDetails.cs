using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class ServiceOrderEmailDetails:Result
    {
        public int EmailDetailsId { get; set; }
        public string ActionFlag { get; set; }
        public int OrderId { get; set; }
        public string EmailSubject { get; set; }
        public string Sentto { get; set; }
        public string EmailBody { get; set; }
        public bool EmailStatus { get; set; }
        public int CreatedBy { get; set; }
        public int JobId { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<ServiceOrderEmailDetails> lstEmaildetails { get; set; }

        public ServiceOrderEmailDetails()
        {
            lstEmaildetails = new List<ServiceOrderEmailDetails>();
        }

    }
}
