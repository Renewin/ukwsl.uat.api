using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;

namespace UKWSL.WMES.Repositories.Workflow
{
  public class WorkflowRepository :IWorkflowRepository
    {

        private string _connectionString;
        public WorkflowRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public WorkflowInstance Intiation(WorkflowHeader workflowHeader)
        {
            WorkflowInstance workflowInstance = new WorkflowInstance();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[rwf_WorkflowInitiation]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@RequestID", workflowHeader.RequestId);
                        cmd.Parameters.AddWithValue("@RequestNo", workflowHeader.RequestNo);
                        cmd.Parameters.AddWithValue("@WorkflowCode", workflowHeader.WorkflowCode);
                        cmd.Parameters.AddWithValue("@WorkflowDCode", workflowHeader.WorkflowDetailCode);
                        cmd.Parameters.AddWithValue("@CreatedBy", workflowHeader.CreatedBy);
                        cmd.ExecuteNonQuery();
                        
                    }
                }
                workflowInstance.Status = Status.Success;
            }
            catch (Exception ex)
            {
                workflowInstance.Status = Status.Failed;
                workflowInstance.Message = ex.Message;
            }
            return workflowInstance;
        }


        public WorkflowStatus CheckWorkflow(WorkflowInstance workflowInstance)
        {
            WorkflowStatus workflowStatus = new WorkflowStatus();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[rwf_CheckWorkflow]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@RequestID", workflowInstance.RequestId);
                        cmd.Parameters.AddWithValue("@RequestNo", workflowInstance.RequestNo);
                        cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        workflowStatus.IsSOSExist = Convert.ToInt32(cmd.Parameters["@Result"].Value);
                    }
                }
                workflowStatus.Status = Status.Success;
            }
            catch (Exception ex)
            {
                workflowStatus.Status = Status.Failed;
                workflowStatus.Message = ex.Message;
            }
            return workflowStatus;
        }
    }
}
