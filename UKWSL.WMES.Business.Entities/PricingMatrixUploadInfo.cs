using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class PricingMatrixUploadInfo : Result
    {
        public int MatrixHeaderId { get; set; }
        public string FileLocation { get; set; }
        public int CreatedBy { get; set; }
        public int ReturnId { get; set; }
        public PricingMatrixSetup MatrixSetup { get; set; }
        public List<PricingMatrix_MatrixDetailsUDT> lstMatrixDetailsUDT { get; set; }
        public List<PricingMatrix_MatrixDetails> lstPassedMatrixDetail { get; set; }
        public List<PricingMatrix_MatrixDetails> lstFailedMatrixDetail { get; set; }
    }
}
