using System;
using System.Web.Http;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Business.ScheduleOfService;
using UKWSL.WMES.Resources;
using UKWSL.WMES.WEBAPP.Validations;
using System.Web;
using System.Net.Http;
using System.Net;
using UKWSL.WMES.Business.Workflow;

namespace UKWSL.WMES.WEBAPP.Controllers.Api
{
    public class WorkflowController : ApiController
    {

        private IWorkflowManager workflowManager;
        public WorkflowController(IWorkflowManager manager)
        {
            workflowManager = manager;
        }

        [HttpPost]
        [ActionName("SOSIntiation")]
        public IHttpActionResult SOSIntiation(WorkflowHeader workflowHeader)
        {

            if (workflowHeader != null)
            {
                if (string.IsNullOrEmpty(workflowHeader.WorkflowCode) ||
                    string.IsNullOrEmpty(workflowHeader.WorkflowDetailCode) ||
                    FieldValidator.NumberValidatorWithoutZero(Convert.ToString(workflowHeader.RequestId)) || 
                    FieldValidator.NumberValidatorWithoutZero(Convert.ToString(workflowHeader.RequestNo)))
                {
                    return Ok(new WorkflowInstance
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = workflowManager.Intiation(workflowHeader);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new WorkflowInstance
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }


        [HttpPost]
        [ActionName("CheckWorkflow")]
        public IHttpActionResult CheckWorkflow(WorkflowInstance workflowInstance)
        {

            if (workflowInstance != null)
            {
                if (string.IsNullOrEmpty(workflowInstance.RequestNo) ||
                    FieldValidator.NumberValidatorWithoutZero(Convert.ToString(workflowInstance.RequestId)))
                {
                    return Ok(new WorkflowStatus
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = workflowManager.CheckWorkflow(workflowInstance);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new WorkflowStatus
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
    }
}
