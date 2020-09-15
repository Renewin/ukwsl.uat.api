using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class Result : ResultBase
    {
        public bool IsSuccess { get { return Status == Status.Success; } }
    }

    public abstract class ResultBase
    {
        public Status Status { get; set; }
        public string Message { get; set; }
    }
}
