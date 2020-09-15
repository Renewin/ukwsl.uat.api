using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Repositories.Exports;

namespace UKWSL.WMES.Business.Exports
{
   public class ExportManager :IExportManager
    {

        private IExportRepository _exportRepository;

        public ExportManager(IExportRepository  exportRepository)
        {
            _exportRepository = exportRepository;
        }

        public ExportInfo GetSOSExportDetails(ExportInfo exportInfo)
        {
            return _exportRepository.GetSOSExportDetails(exportInfo);
        }
    }
}
