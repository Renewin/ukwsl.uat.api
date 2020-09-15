using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;

namespace UKWSL.WMES.Business.Workflow
{
   public interface IWorkflowManager
    {
        WorkflowInstance Intiation(WorkflowHeader workflowHeader);

        WorkflowStatus CheckWorkflow(WorkflowInstance workflowInstance);
    }
}
