using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Repositories.Workflow;

namespace UKWSL.WMES.Business.Workflow
{
  public  class WorkflowManager :IWorkflowManager
    {

        private IWorkflowRepository _iWorkflowRepository;
        public WorkflowManager(IWorkflowRepository iWorkflowRepository)
        {
            _iWorkflowRepository = iWorkflowRepository;
        }

        public WorkflowInstance Intiation(WorkflowHeader workflowHeader)
        {
            return _iWorkflowRepository.Intiation(workflowHeader);
        }

       public WorkflowStatus CheckWorkflow(WorkflowInstance workflowInstance)
        {
            return _iWorkflowRepository.CheckWorkflow(workflowInstance);
        }
    }
}
