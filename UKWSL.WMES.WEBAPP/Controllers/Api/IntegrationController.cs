using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UKWSL.WMES.Business.Integration;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Resources;

namespace UKWSL.WMES.WEBAPP.Controllers.Api
{
    public class IntegrationController : ApiController
    {
        private IIntegrationManager integrationManager;

        public IntegrationController(IIntegrationManager manager)
        {
            integrationManager = manager;
        }

        [HttpPost]
        [ActionName("GetAPIKey")]
        public IHttpActionResult GetAPIKey(APIConfiguration aPIConfiguration)
        {
            if (aPIConfiguration != null)
            {
                if (string.IsNullOrEmpty(aPIConfiguration.AppName))
                {
                    return Ok(new APIConfiguration
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = integrationManager.GetAPIKey(aPIConfiguration);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new APIConfiguration
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }

        }

        [HttpPost]
        [ActionName("GETAPIFunctions")]
        public IHttpActionResult GETAPIFunctions(APIConfigFunctions aPIConfigFunctions)
        {
            if (aPIConfigFunctions != null)
            {
                if (string.IsNullOrEmpty(aPIConfigFunctions.FunctionName))
                {
                    return Ok(new APIConfigFunctions
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = integrationManager.GETAPIFunctions(aPIConfigFunctions);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new APIConfigFunctions
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }

        }




    }
}
