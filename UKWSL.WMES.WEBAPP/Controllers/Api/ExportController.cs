using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Business.Exports;
using UKWSL.WMES.Resources;
using UKWSL.WMES.WEBAPP.Validations;

namespace UKWSL.WMES.WEBAPP.Controllers.Api
{
    public class ExportController : ApiController
    {
        private IExportManager exportManager;
        public ExportController(IExportManager manager)
        {
            exportManager = manager;
        }

        [HttpPost]
        [ActionName("GetSOSExportDetails")]
        public IHttpActionResult GetSOSExportDetails(ExportInfo exportInfo)
        {

            if (exportInfo != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(exportInfo.DealId)) || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(exportInfo.SOSHeaderId)))
                {
                    return Ok(new ExportInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = exportManager.GetSOSExportDetails(exportInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ExportInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }


    }
}
