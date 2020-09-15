using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;

namespace UKWSL.WMES.Repositories.Integration
{
   public interface IIntegrationRepository
    {
        APIConfiguration GetAPIKey(APIConfiguration aPIConfiguration);
        APIConfigFunctions GETAPIFunctions(APIConfigFunctions aPIConfigFunctions);


    }
}
