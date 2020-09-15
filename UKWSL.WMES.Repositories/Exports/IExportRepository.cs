using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;

namespace UKWSL.WMES.Repositories.Exports
{
   public interface IExportRepository
    {

        ExportInfo GetSOSExportDetails(ExportInfo exportInfo);
       

    }
}
