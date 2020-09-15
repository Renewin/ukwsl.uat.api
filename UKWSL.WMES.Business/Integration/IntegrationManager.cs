using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Repositories.Integration;

namespace UKWSL.WMES.Business.Integration
{
   public class IntegrationManager :IIntegrationManager
    {

        private IIntegrationRepository _integrationRepository;
        public IntegrationManager(IIntegrationRepository integrationRepository)
        {
            _integrationRepository = integrationRepository;
        }
        public  APIConfiguration GetAPIKey(APIConfiguration aPIConfiguration)
        {
            return _integrationRepository.GetAPIKey(aPIConfiguration);
        }
        public APIConfigFunctions GETAPIFunctions(APIConfigFunctions aPIConfigFunctions)
        {
            return _integrationRepository.GETAPIFunctions(aPIConfigFunctions);
        }

    }
}
