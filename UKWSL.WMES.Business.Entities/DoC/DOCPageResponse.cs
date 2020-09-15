using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities.DoC
{
   public class DOCPageResponse
    {
        public int DOC_PageResponseId { get; set; }
        public int DOCId { get; set; }
        public int DOC_PageId { get; set; }
        public bool IsConfirm { get; set; }
        public string ConfirmName { get; set; }
        public string ResponseIp { get; set; }
        public DateTime ResponseTime { get; set; }
    }
}
