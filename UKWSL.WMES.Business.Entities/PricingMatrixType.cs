using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class PricingMatrixType : Log
    {
        public int MatrixTypeId { get; set; }
        public string MatrixTypeName { get; set; }
    }
}
