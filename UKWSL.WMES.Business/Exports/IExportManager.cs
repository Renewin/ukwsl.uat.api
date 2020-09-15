using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;

namespace UKWSL.WMES.Business.Exports
{
    public interface IExportManager
    {
        ExportInfo GetSOSExportDetails(ExportInfo exportInfo);
    }
}
