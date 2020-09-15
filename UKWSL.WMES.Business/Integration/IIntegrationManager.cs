using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;

namespace UKWSL.WMES.Business.Integration
{
    public interface IIntegrationManager
    {

        APIConfiguration GetAPIKey(APIConfiguration aPIConfiguration);
        APIConfigFunctions GETAPIFunctions(APIConfigFunctions aPIConfigFunctions);
    }
}

