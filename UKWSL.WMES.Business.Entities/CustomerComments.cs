using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class CustomerComments:Log
    {
        public int CustomerId { get; set; }
        public int CusCommentId { get; set; }
        public string GeneralComment { get; set; }
        public string InvoicingComment { get; set; }
        public string ServiceComment { get; set; }
    }
    public class CustomerServiceComments : Log
    {
        public int CustomerId { get; set; }
        public int CusServiceCommentId { get; set; }
        public string Comment { get; set; }
        public string CommentedBy { get; set; }
        public DateTime? CommentedOn { get; set; }
        public string ArchivedBy { get; set; }
        public DateTime? ArchivedOn { get; set; }
        public string CusServiceCommentIds { get; set; }
    }
}
