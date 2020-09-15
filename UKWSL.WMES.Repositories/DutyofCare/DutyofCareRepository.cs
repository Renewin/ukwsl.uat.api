using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Business.Entities.DoC;
using UKWSL.WMES.Utility;
using static UKWSL.WMES.Utility.ListtoDataTableConverter;

namespace UKWSL.WMES.Repositories.DutyofCare
{
    public class DutyofCareRepository : IDutyofCareRepository
    {
        private string _connectionString;

        public DutyofCareRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region Master Financial Years
        /// <summary>
        /// Database layer method to Get All Financial Years from Master Table
        /// </summary>
        /// Delivery Point: DP4.5
        public DOCViewModel GetDOCFinancialYearMaster()
        {
            DOCViewModel dOCViewModel = new DOCViewModel();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<FinancialYearMaster> lstFYMaster = new List<FinancialYearMaster>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_DOC_Master_GetDOCFYMaster]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                FinancialYearMaster objEntity = new FinancialYearMaster();
                                objEntity.FYId = string.IsNullOrEmpty(Convert.ToString(reader["FYId"])) ? 0 : Convert.ToInt32(reader["FYId"]);
                                objEntity.FY_Name = Convert.ToString(reader["FY_Name"]);
                                objEntity.FY_StartDate = Convert.ToDateTime(reader["FY_StartDate"]);
                                objEntity.FY_EndDate = Convert.ToDateTime(reader["FY_EndDate"]);
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                lstFYMaster.Add(objEntity);
                            }
                        }
                        dOCViewModel.lstFinancialYearMasters = lstFYMaster;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            dOCViewModel.Status = Status.Success;

            return dOCViewModel;
        }
        /// <summary>
        /// Database layer method to Insert or Update Financial Years in Master Table
        /// </summary>
        /// Delivery Point: DP4.5
        public DOCViewModel InsertOrUpdateFinancialYearMaster(FinancialYearMaster financialYearMaster)
        {
            DOCViewModel dOCViewModel = new DOCViewModel();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_DOC_InsertUpdateFinancialYear]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FYId", financialYearMaster.FYId);
                        cmd.Parameters.AddWithValue("@FY_Name", financialYearMaster.FY_Name);
                        cmd.Parameters.AddWithValue("@FY_StartDate", financialYearMaster.FY_StartDate);
                        cmd.Parameters.AddWithValue("@FY_EndDate", financialYearMaster.FY_EndDate);
                        cmd.Parameters.AddWithValue("@CreatedBy", financialYearMaster.CreatedBy);
                        cmd.Parameters.AddWithValue("@IsActive", financialYearMaster.IsActive);
                        cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        dOCViewModel.financialYearMaster.FYId= Convert.ToInt32(cmd.Parameters["@Result"].Value);
                    }
                    dOCViewModel.Status = Status.Success;
                }
            }
            catch (Exception ex)
            {
                dOCViewModel.Status = Status.Failed;
                dOCViewModel.Message = ex.Message;
                throw ex;
            }
            return dOCViewModel;

        }
        #endregion
        #region Generate New DOC intially
        public DOCViewModel InsertOrUpdateDOCHeaderDetails(DOCViewModel documentDetails)
        {
            DOCViewModel dOCViewModel = new DOCViewModel();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_DoC_InsertDOCDetails]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ActionFlag", documentDetails.dOC_HeaderDetails.ActionFlag);
                        cmd.Parameters.AddWithValue("@DOCId", documentDetails.dOC_HeaderDetails.DOCId);
                        cmd.Parameters.AddWithValue("@CustomerId", documentDetails.dOC_HeaderDetails.CustomerId);
                        cmd.Parameters.AddWithValue("@FYId", documentDetails.dOC_HeaderDetails.FYId);
                        cmd.Parameters.AddWithValue("@CustomerAccountId", documentDetails.dOC_HeaderDetails.Customer_AccountId);
                        cmd.Parameters.AddWithValue("@CustomerGroupId", documentDetails.dOC_HeaderDetails.Customer_GroupId);
                        cmd.Parameters.AddWithValue("@Customer_SICCode", documentDetails.dOC_HeaderDetails.Customer_SICCode);
                        cmd.Parameters.AddWithValue("@DOCContactName", documentDetails.dOC_HeaderDetails.DOCContactName);
                        cmd.Parameters.AddWithValue("@DOCContactEmail", documentDetails.dOC_HeaderDetails.DOCContactEmail);
                        cmd.Parameters.AddWithValue("@EnquiryNumber", documentDetails.dOC_HeaderDetails.EnquiryNumber);
                        cmd.Parameters.AddWithValue("@NoofServices", documentDetails.dOC_HeaderDetails.NoofServices);
                        cmd.Parameters.AddWithValue("@NoofContractors", documentDetails.dOC_HeaderDetails.NoofContractors);
                        cmd.Parameters.AddWithValue("@EmailorPosted", documentDetails.dOC_HeaderDetails.EmailorPosted);
                        cmd.Parameters.AddWithValue("@IsDOCSigned", documentDetails.dOC_HeaderDetails.IsDOCSigned);
                        cmd.Parameters.AddWithValue("@IsIncludedUnscheduledservice", documentDetails.dOC_HeaderDetails.IsIncludedUnscheduledService);
                        cmd.Parameters.AddWithValue("@CreatedBy", documentDetails.dOC_HeaderDetails.CreatedBy);
                        DataTable _DataTable = GenerateDataTable(documentDetails.lstDOC_PageDetails);
                        DataTable _PageRespoanceTable = GeneratePageResponseDataTable(documentDetails.lstDOCPageResponses);
                        cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                        SqlParameter param = new SqlParameter("@DocPageDetails", SqlDbType.Structured)
                        {
                            TypeName = "dbo.UT_DocPageDetails",
                            Value = _DataTable
                        };
                        cmd.Parameters.Add(param);
                        SqlParameter param1 = new SqlParameter("@DocPageResponse", SqlDbType.Structured)
                        {
                            TypeName = "dbo.UDT_DOCPageResponse",
                            Value = _PageRespoanceTable
                        };
                        cmd.Parameters.Add(param1);
                        cmd.ExecuteNonQuery();
                        dOCViewModel.dOC_HeaderDetails.DOCId = Convert.ToInt32(cmd.Parameters["@Result"].Value);
                        if(documentDetails.lstBackingData.Count != 0 && documentDetails.dOC_HeaderDetails.ActionFlag == "Insert")
                        {
                            foreach (var item in documentDetails.lstBackingData)
                            {
                                item.DOCId = dOCViewModel.dOC_HeaderDetails.DOCId;
                                item.CreatedBy = documentDetails.dOC_HeaderDetails.CreatedBy;
                                InsertDOCBackingData(item);
                            }
                        }
                        
                    }
                    dOCViewModel.Status = Status.Success;
                }
            }
            catch (Exception ex)
            {
                dOCViewModel.Status = Status.Failed;
                dOCViewModel.Message = ex.Message;
                throw ex;
            }
            return dOCViewModel;
        }
        /// <summary>
        /// Database layer method to Get Header Details by CustomerId
        /// </summary>
        /// Delivery Point: DP4.5
        public DOCViewModel GetDOCHeaderDetailsByCustomerId(DOC_HeaderDetails headerDetails)
        {
            DOCViewModel dOCViewModel = new DOCViewModel();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<DOC_HeaderDetails> lstDOCHeaderDetails = new List<DOC_HeaderDetails>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_DOC_GetHeaderDetails]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CustomerId", headerDetails.CustomerId);
                        cmd.Parameters.AddWithValue("@AccountId", headerDetails.Customer_AccountId);
                        cmd.Parameters.AddWithValue("@GroupId", headerDetails.Customer_GroupId);
                        cmd.Parameters.AddWithValue("@FYId", headerDetails.FYId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DOC_HeaderDetails objEntity = new DOC_HeaderDetails();
                                objEntity.DOCId = string.IsNullOrEmpty(Convert.ToString(reader["DOCId"])) ? 0 : Convert.ToInt32(reader["DOCId"]);
                                objEntity.CreatedOn = Convert.ToDateTime(reader["CreatedOn"]);
                                objEntity.DOCContactEmail = Convert.ToString(reader["DOCContactEmail"]);
                                objEntity.NoofServices = string.IsNullOrEmpty(Convert.ToString(reader["NoofServices"])) ? 0 : Convert.ToInt32(reader["NoofServices"]);
                                objEntity.NoofContractors = string.IsNullOrEmpty(Convert.ToString(reader["NoofContractors"])) ? 0 : Convert.ToInt32(reader["NoofContractors"]);
                                objEntity.IsDOCSigned = Convert.ToBoolean(reader["IsDOCSigned"]);
                                objEntity.EnquiryNumber = Convert.ToString(reader["EnquiryNumber"]);
                                objEntity.EmailorPosted = Convert.ToString(reader["EmailorPosted"]);
                                lstDOCHeaderDetails.Add(objEntity);
                            }
                        }
                    }
                    dOCViewModel.lstDOC_HeaderDetails = lstDOCHeaderDetails;
                }
                dOCViewModel.Status = Status.Success;
            }
            catch (Exception ex)
            {
                dOCViewModel.Status = Status.Failed;
                dOCViewModel.Message = ex.Message;
            }
            return dOCViewModel;
        }
        #endregion
        #region Email Template Master 
        /// <summary>
        /// Database layer method to Get DOC Email Templates master 
        /// </summary>
        /// Delivery Point: DP4.5
        public DOCViewModel GetDOCEmailTemplates()
        {
            DOCViewModel dOCViewModel = new DOCViewModel();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<EmailTemplatesMaster> lstEmailTemplates = new List<EmailTemplatesMaster>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_DOC_Master_GetDOCEmailTemplateTypes]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                EmailTemplatesMaster objEntity = new EmailTemplatesMaster();
                                objEntity.DOC_TemplateTypeId = string.IsNullOrEmpty(Convert.ToString(reader["DOC_TemplateTypeId"])) ? 0 : Convert.ToInt32(reader["DOC_TemplateTypeId"]);
                                objEntity.DOC_EmailTemplateName = Convert.ToString(reader["DOC_EmailTemplateName"]);
                                objEntity.DOC_EmailSubject = Convert.ToString(reader["DOC_EmailSubject"]);
                                objEntity.DOC_EmailAfterDays = string.IsNullOrEmpty(Convert.ToString(reader["DOC_EmailAfterDays"])) ? 0 : Convert.ToInt32(reader["DOC_EmailAfterDays"]);
                                objEntity.DOC_TemplateURL = Convert.ToString(reader["DOC_TemplateURL"]);
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                lstEmailTemplates.Add(objEntity);
                            }
                        }
                        dOCViewModel.lstEmailTemplatesMaster = lstEmailTemplates;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            dOCViewModel.Status = Status.Success;

            return dOCViewModel;
        }

        /// <summary>
        /// Database layer method to Configure Email Template
        /// </summary>
        /// <param name="financialYearMaster"></param>
        /// Delivery Point: DP4.5
        public DOCViewModel InsertOrUpdateEmailTemplates(EmailTemplatesMaster emailTemplates)
        {
            DOCViewModel dOCViewModel = new DOCViewModel();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_DOC_Config_DOC_EmailTemplates]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TemplateId", emailTemplates.DOC_TemplateTypeId);
                        cmd.Parameters.AddWithValue("@EmailTemplateName", emailTemplates.DOC_EmailTemplateName);
                        cmd.Parameters.AddWithValue("@EmailSubject", emailTemplates.DOC_EmailSubject);
                        cmd.Parameters.AddWithValue("@EmailAfterDays", emailTemplates.DOC_EmailAfterDays);
                        cmd.Parameters.AddWithValue("@TemplateURL", emailTemplates.DOC_TemplateURL);
                        cmd.Parameters.AddWithValue("@CreatedBy", emailTemplates.CreatedBy);
                        cmd.Parameters.AddWithValue("@IsActive", emailTemplates.IsActive);
                        cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        dOCViewModel.financialYearMaster.FYId = Convert.ToInt32(cmd.Parameters["@Result"].Value);
                    }
                    dOCViewModel.Status = Status.Success;
                }
            }
            catch (Exception ex)
            {
                dOCViewModel.Status = Status.Failed;
                dOCViewModel.Message = ex.Message;
                throw ex;
            }
            return dOCViewModel;
        }
        #endregion
        #region WTNDocument
        /// <summary>
        /// Database layer method to Get WTN Details for customer by CustomerId
        /// </summary>
        /// Delivery Point: DP4.5
        public DOCViewModel GetWTNDetailsForCustomer(Master_SOS_WasteType model)
        {
            DOCViewModel dOCViewModel = new DOCViewModel();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<Master_SOS_WasteType> lstEntity = new List<Master_SOS_WasteType>();
                    List<DOC_BackingData> lstbackingdata = new List<DOC_BackingData>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_DOC_GetWTNDetailsForCustomer]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CustomerId", model.CustomerId);
                        cmd.Parameters.AddWithValue("@AccountId", model.AccountId);
                        cmd.Parameters.AddWithValue("@GroupId", model.GroupId);
                        cmd.Parameters.AddWithValue("@IncludeUnScheduledService", model.IncludeUnScheduledService);
                        cmd.Parameters.AddWithValue("@FYId", model.FYId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Master_SOS_WasteType objEntity = new Master_SOS_WasteType();
                                objEntity.JobId = string.IsNullOrEmpty(Convert.ToString(reader["JobId"])) ? 0 : Convert.ToInt32(reader["JobId"]);
                                objEntity.Customer_SiteId = string.IsNullOrEmpty(Convert.ToString(reader["Customer_SiteId"])) ? 0 : Convert.ToInt32(reader["Customer_SiteId"]);
                                objEntity.MaterialType_Name = Convert.ToString(reader["MaterialType_Name"]);
                                objEntity.EWCCode = Convert.ToString(reader["EWCCode"]);
                                objEntity.Transferor_FullName = Convert.ToString(reader["Transferor_FullName"]);
                                objEntity.Transferor_CompanyName = Convert.ToString(reader["Transferor_CompanyName"]);
                                objEntity.Transferor_StreetAddress1 = Convert.ToString(reader["Transferor_StreetAddress1"]);
                                objEntity.Transferor_StreetAddress2 = Convert.ToString(reader["Transferor_StreetAddress2"]);
                                objEntity.Transferor_Town = Convert.ToString(reader["Transferor_Town"]);
                                objEntity.Transferor_County = Convert.ToString(reader["Transferor_County"]);
                                objEntity.Transferor_PostCode = Convert.ToString(reader["Transferor_PostCode"]);
                                objEntity.Transferor_CompanySICCode = Convert.ToString(reader["Transferor_CompanySICCode"]);
                                objEntity.Transferee_CompanyName = Convert.ToString(reader["Transferee_CompanyName"]);
                                objEntity.Transferee_FullName = Convert.ToString(reader["Transferee_FullName"]);
                                objEntity.Transferee_AddressLine1 = Convert.ToString(reader["Transferee_AddressLine1"]);
                                objEntity.Transferee_AddressLine2 = Convert.ToString(reader["Transferee_AddressLine2"]);
                                objEntity.Transferee_Town = Convert.ToString(reader["Transferee_Town"]);
                                objEntity.Transferee_PostCode = Convert.ToString(reader["Transferee_PostCode"]);
                                objEntity.FacilityName = Convert.ToString(reader["FacilityName"]);
                                objEntity.Trasnfer_AddressLine1 = Convert.ToString(reader["Trasnfer_AddressLine1"]);
                                objEntity.Trasnfer_AddressLine2 = Convert.ToString(reader["Trasnfer_AddressLine2"]);
                                objEntity.Trasnfer_Town = Convert.ToString(reader["Trasnfer_Town"]);
                                objEntity.Trasnfer_County = Convert.ToString(reader["Trasnfer_County"]);
                                objEntity.Trasnfer_PostCode = Convert.ToString(reader["Trasnfer_PostCode"]);
                               // objEntity.DateofTransfer = Convert.ToString(reader["DateofTransfer"]);
                                objEntity.SectionA2 = Convert.ToString(reader["SectionA2"]);
                                objEntity.SectionA3 = Convert.ToString(reader["SectionA3"]);
                                objEntity.WCL_RegistrationNumber = Convert.ToString(reader["WCL_RegistrationNumber"]);
                                objEntity.CarrierorBroker = Convert.ToString(reader["CarrierorBroker"]);
                                objEntity.Address1 = Convert.ToString(reader["Address1"]);
                                objEntity.Address2 = Convert.ToString(reader["Address2"]);
                                objEntity.CompanyName = Convert.ToString(reader["CompanyName"]);
                                objEntity.RegistrationNumber1 = Convert.ToString(reader["RegistrationNumber"]);
                                objEntity.DOCRepresentativeFullName = Convert.ToString(reader["DOCRepresentativeFullName"]);
                                objEntity.DOCRepresentativeSignature = Convert.ToString(reader["DOCRepresentativeSignature"]);
                                lstEntity.Add(objEntity);
                            }
                            reader.NextResult();
                            while (reader.Read())
                            {
                                DOC_BackingData backingdata = new DOC_BackingData();
                                backingdata.SiteCode = Convert.ToString(reader["SICCode"]);
                                backingdata.SICCode = Convert.ToString(reader["SICCode"]);
                                backingdata.SiteName = Convert.ToString(reader["SiteName"]);
                                backingdata.AddressLine1 = Convert.ToString(reader["AddressLine1"]);
                                backingdata.AddressLine2 = Convert.ToString(reader["AddressLine2"]);
                                backingdata.Town = Convert.ToString(reader["Town"]);
                                backingdata.County = Convert.ToString(reader["County"]);
                                backingdata.Postcode = Convert.ToString(reader["Postcode"]);
                                backingdata.WasteType = Convert.ToString(reader["WasteType"]);
                                backingdata.MaterialType = Convert.ToString(reader["MaterialType"]);
                                backingdata.EWCCode = Convert.ToString(reader["EWCCode"]);
                                backingdata.ContainerType = Convert.ToString(reader["ContainerType"]);
                                backingdata.ContainerSize = Convert.ToString(reader["ContainerSize"]);
                                backingdata.Quantity = string.IsNullOrEmpty(Convert.ToString(reader["Quantity"])) ? 0 : Convert.ToInt32(reader["Quantity"]);
                                backingdata.Frequencyname = Convert.ToString(reader["Frequencyname"]);
                                backingdata.ContractorName = Convert.ToString(reader["ContractorName"]);
                                backingdata.WasteCarriersLicenceNumber = Convert.ToString(reader["WasteCarriersLicenceNumber"]);
                                backingdata.Notes = Convert.ToString(reader["Notes"]);
                                lstbackingdata.Add(backingdata);
                            }
                        }
                    }
                    dOCViewModel.lstMaster_SOS_WasteTypes = lstEntity;
                    dOCViewModel.lstBackingData  = lstbackingdata;
                }
                dOCViewModel.Status = Status.Success;
            }
            catch (Exception ex)
            {
                dOCViewModel.Status = Status.Failed;
                dOCViewModel.Message = ex.Message;
            }

            return dOCViewModel;
        }

        /// <summary>
        /// method from InsertOrUpdateDOCHeaderDetails insert details to Page Response table 
        /// </summary>
        private DataTable GeneratePageResponseDataTable(List<DOCPageResponse> lstDOCPageResponse)
        {
            DateTime CurrentDateTime = DateTime.Now;
            DataTable dt = new DataTable();
            dt.Columns.Add("DOC_PageId");
            dt.Columns.Add("IsConfirm");
            dt.Columns.Add("ConfirmName");
            dt.Columns.Add("ResponseIp");
            dt.Columns.Add("ResponseTime");
            foreach (var item in lstDOCPageResponse)
            {
                DataRow row = dt.NewRow();
                row["DOC_PageId"] = item.DOC_PageId;
                row["IsConfirm"] = item.IsConfirm;
                row["ConfirmName"] = item.ConfirmName;
                row["ResponseIp"] = LocalIPAddress.GetLocalIPAddress();
                row["ResponseTime"] = CurrentDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff"); ;
                dt.Rows.Add(row);
            }

             return dt;
        }
        /// <summary>
        /// method from InsertOrUpdateDOCHeaderDetails insert details to Page Details table 
        /// </summary>
        private DataTable GenerateDataTable(List<DOC_PageDetails> lstDoC_PageDetails)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("DocPageNo");
            dt.Columns.Add("DocPageContent");

            int counter = 0;
            foreach(var item in lstDoC_PageDetails)
            {
                DataRow row = dt.NewRow();
                row["DocPageNo"] = item.DOCPageNumber;
                row["DocPageContent"] = item.DOC_PageContent;
                dt.Rows.Add(row);
            }
            return dt;
        }
        /// <summary>
        /// Database layer method to get Document Tracker By Financial year
        /// </summary>
        /// <param name="doC_DocumentTracker"></param>
        /// <returns></returns>
        public DOCViewModel GetDOCTrackerByFY(DoC_DocumentTracker model)
        {
            DOCViewModel dOCViewModel = new DOCViewModel();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<DoC_DocumentTracker> lstEntity = new List<DoC_DocumentTracker>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_DOC_GetDOCTrackerByFY]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FYId", model.FYId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DoC_DocumentTracker objEntity = new DoC_DocumentTracker();
                                objEntity.CustomerId = string.IsNullOrEmpty(Convert.ToString(reader["CustomerId"])) ? 0 : Convert.ToInt32(reader["CustomerId"]);
                                objEntity.AccountId = string.IsNullOrEmpty(Convert.ToString(reader["AccountId"])) ? 0 : Convert.ToInt32(reader["AccountId"]);
                                objEntity.DOCId = string.IsNullOrEmpty(Convert.ToString(reader["DOCId"])) ? 0 : Convert.ToInt32(reader["DOCId"]);
                                objEntity.Customer_GroupId = string.IsNullOrEmpty(Convert.ToString(reader["Customer_GroupId"])) ? 0 : Convert.ToInt32(reader["Customer_GroupId"]);
                                objEntity.CustomerName = Convert.ToString(reader["CustomerName"]);
                                objEntity.AccountName = Convert.ToString(reader["AccountName"]);
                                objEntity.ContactEmail = Convert.ToString(reader["ContactEmail"]);
                                objEntity.GroupName = Convert.ToString(reader["GroupName"]);
                                objEntity.CompanySICCode = Convert.ToString(reader["CompanySICCode"]);
                                objEntity.AccountType = Convert.ToString(reader["ManagedAccount"]);
                                objEntity.DOCContact = Convert.ToString(reader["DOCContact"]);
                                objEntity.EmailReceived = Convert.ToString(reader["EmailReceived"]);
                                objEntity.LinkOpened = Convert.ToString(reader["LinkOpened"]);
                                objEntity.EnquiryNumber = Convert.ToString(reader["EnquiryNumber"]);
                                objEntity.NoOfServices = Convert.ToString(reader["NoOfServices"]);
                                objEntity.NoOfContractors = Convert.ToString(reader["NoOfContractors"]);
                                objEntity.NoOfDOCsGenerated = Convert.ToString(reader["NoofDOCgenerated"]);
                                objEntity.SICCodeExist = Convert.ToBoolean(reader["SICCodeExist"]);
                                objEntity.IsGroupSiteMissing = Convert.ToBoolean(reader["IsGroupSiteMissing"]);
                                objEntity.ExpiredWCL = Convert.ToBoolean(reader["ExpiredWCL"]);
                                objEntity.DOCContactExist = Convert.ToBoolean(reader["DOCContactExist"]);
                                objEntity.LastReminderLetter = Convert.ToString(reader["LastReminderLetter"]);
                                objEntity.DOCSigned = Convert.ToString(reader["DOCSigned?"]);
                                objEntity.EmailorPosted = Convert.ToString(reader["EmailorPosted"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    dOCViewModel. lstDoC_DocumentTrackers = lstEntity;
                }
                dOCViewModel.Status = Status.Success;
            }
            catch (Exception ex)
            {
                dOCViewModel.Status = Status.Failed;
                dOCViewModel.Message = ex.Message;
            }

            return dOCViewModel;
        }
        /// <summary>
        /// Database layer method to Get Page Details by FYId
        /// </summary>
        /// Delivery Point: DP4.5
        public DOCViewModel GetPageDetailsByFy(DOC_PageDetails pageDetails)
        {
            DOCViewModel dOCViewModel = new DOCViewModel();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<DOC_PageDetails> lstEntity = new List<DOC_PageDetails>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_DOC_GetPageDetailsByFy]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DocId", pageDetails.DOCId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DOC_PageDetails objEntity = new DOC_PageDetails();
                                objEntity.DOC_PageId = string.IsNullOrEmpty(Convert.ToString(reader["DOC_PageId"])) ? 0 : Convert.ToInt32(reader["DOC_PageId"]);
                                objEntity.DOCId = string.IsNullOrEmpty(Convert.ToString(reader["DOCId"])) ? 0 : Convert.ToInt32(reader["DOCId"]);
                                objEntity.DOCPageNumber = string.IsNullOrEmpty(Convert.ToString(reader["DOCPageNumber"])) ? 0 : Convert.ToInt32(reader["DOCPageNumber"]);
                                objEntity.WasteTypeId = string.IsNullOrEmpty(Convert.ToString(reader["WasteTypeId"])) ? 0 : Convert.ToInt32(reader["WasteTypeId"]);
                                objEntity.MaterialTypeId = string.IsNullOrEmpty(Convert.ToString(reader["MaterialTypeId"])) ? 0 : Convert.ToInt32(reader["MaterialTypeId"]);
                                objEntity.ContainerTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ContainerTypeId"])) ? 0 : Convert.ToInt32(reader["ContainerTypeId"]);
                                objEntity.DOC_PageContent = Convert.ToString(reader["DOC_PageContent"]);
                                objEntity.ContainerSizeid = string.IsNullOrEmpty(Convert.ToString(reader["ContainerSizeid"])) ? 0 : Convert.ToInt32(reader["ContainerSizeid"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    dOCViewModel.lstDOC_PageDetails = lstEntity;
                }
                dOCViewModel.Status = Status.Success;
            }
            catch (Exception ex)
            {
                dOCViewModel.Status = Status.Failed;
                dOCViewModel.Message = ex.Message;
            }

            return dOCViewModel;
        }
        /// <summary>
        /// Database layer method to Get Page Response by DOCId
        /// </summary>
        /// Delivery Point: DP4.5
        public DOCViewModel GetPageResponseByDOCId(DOCPageResponse dOCPageResponse)
        {
            DOCViewModel dOCViewModel = new DOCViewModel();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<DOCPageResponse> lstDOCPageResponses = new List<DOCPageResponse>();
                    using(var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_DOC_GetPageResponseByDOCId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DOCId", dOCPageResponse.DOCId);
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DOCPageResponse obj = new DOCPageResponse();
                                obj.DOCId = string.IsNullOrEmpty(Convert.ToString(reader["DOCId"])) ? 0 : Convert.ToInt32(reader["DOCId"]);
                                obj.DOC_PageId = string.IsNullOrEmpty(Convert.ToString(reader["DOC_PageId"])) ? 0 : Convert.ToInt32(reader["DOC_PageId"]);
                                obj.IsConfirm = Convert.ToBoolean(reader["IsConfirm"]);
                                obj.ResponseIp = Convert.ToString(reader["ResponseIp"]);
                                obj.ConfirmName = Convert.ToString(reader["ConfirmName"]);
                                obj.ResponseTime = Convert.ToDateTime(reader["ResponseTime"]);
                                lstDOCPageResponses.Add(obj);
                            }
                        }
                    }
                    dOCViewModel.lstDOCPageResponses = lstDOCPageResponses;
                }
                dOCViewModel.Status = Status.Success;
            }
            catch(Exception ex)
            {
                dOCViewModel.Status = Status.Failed;
                dOCViewModel.Message = ex.Message;
            }
            return dOCViewModel;
        }
        
        #endregion
        #region Letter Tracker
        /// <summary>
        /// Database layer method to Get Letter Tracker by DOCId
        /// </summary>
        /// Delivery Point: DP4.5
        public DOCViewModel GetLetterTracker(LetterTracker letterTracker)
        {
            DOCViewModel dOCViewModel = new DOCViewModel();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<LetterTracker> lstEntity = new List<LetterTracker>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_DOC_GetLetterTracker]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DOCId", letterTracker.DOCId);
                        cmd.Parameters.AddWithValue("@DOC_TemplateTypeId", letterTracker.DOC_TemplateTypeId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                LetterTracker objEntity = new LetterTracker();
                                objEntity.LetterTrackerId = string.IsNullOrEmpty(Convert.ToString(reader["LetterTrackerId"])) ? 0 : Convert.ToInt32(reader["LetterTrackerId"]);
                                objEntity.DOCId = string.IsNullOrEmpty(Convert.ToString(reader["DOCId"])) ? 0 : Convert.ToInt32(reader["DOCId"]);
                                objEntity.DOC_TemplateTypeId = string.IsNullOrEmpty(Convert.ToString(reader["DOC_TemplateTypeId"])) ? 0 : Convert.ToInt32(reader["DOC_TemplateTypeId"]);
                                objEntity.DOC_EmailLink = Convert.ToString(reader["DOC_EmailLink"]);
                                objEntity.PostStatus = Convert.ToString(reader["PostStatus"]);
                                objEntity.DOC_ContactEmail =Convert.ToString(reader["DOC_ContactEmail"]);
                                objEntity.IsLinkOpened = Convert.ToBoolean(reader["IsLinkOpened"]);
                                objEntity.CreatedOn = Convert.ToDateTime(reader["CreatedOn"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    dOCViewModel.lstletterTrackers = lstEntity;
                }
                dOCViewModel.Status = Status.Success;
            }
            catch (Exception ex)
            {
                dOCViewModel.Status = Status.Failed;
                dOCViewModel.Message = ex.Message;
            }

            return dOCViewModel;
        }
        /// <summary>
        /// Database layer method to Insert Tracker data After Sending Emails
        /// </summary>
        /// Delivery Point: DP4.5
        public DOCViewModel InsertLTEmailDetails(LetterTracker ltemaildetails)
        {
            DOCViewModel emailDetailsInfo = new DOCViewModel();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_DOC_LT_EmailDetails";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@LetterTrackerId", ltemaildetails.LetterTrackerId);
                        cmd.Parameters.AddWithValue("@Sent_to", ltemaildetails.Sent_to);
                        cmd.Parameters.AddWithValue("@Sent_cc", ltemaildetails.Sent_cc);
                        cmd.Parameters.AddWithValue("@EmailSubject", ltemaildetails.EmailSubject);
                        cmd.Parameters.AddWithValue("@EmailBody", ltemaildetails.EmailBody);
                        cmd.Parameters.AddWithValue("@IsEmailSent", ltemaildetails.IsEmailSent);
                        cmd.Parameters.AddWithValue("@SentOn", ltemaildetails.SentOn);
                        cmd.ExecuteNonQuery();

                    }
                }
                emailDetailsInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                emailDetailsInfo.Status = Status.Failed;
                emailDetailsInfo.Message = ex.Message;
                throw ex;
            }
            return emailDetailsInfo;
        }
        /// <summary>
        /// Database layer method to Insert Letter Tracker data
        /// </summary>
        /// Delivery Point: DP4.5
        public DOCViewModel InsertOrUpdateLetterTracker(LetterTracker letterTracker)
        {
            DOCViewModel dOCViewModel = new DOCViewModel();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_DOC_LetterTracker]";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ActionFlag", letterTracker.ActionFlag);
                        cmd.Parameters.AddWithValue("@LetterTrackerId", letterTracker.LetterTrackerId);
                        cmd.Parameters.AddWithValue("@DOCId", letterTracker.DOCId);
                        cmd.Parameters.AddWithValue("@DOC_TemplateTypeId", letterTracker.DOC_TemplateTypeId);
                        cmd.Parameters.AddWithValue("@DOC_EmailLink", letterTracker.DOC_EmailLink);
                        cmd.Parameters.AddWithValue("@PostStatus", letterTracker.PostStatus);
                        cmd.Parameters.AddWithValue("@DOC_ContactEmail", letterTracker.DOC_ContactEmail);
                        cmd.Parameters.AddWithValue("@IsLinkOpened", letterTracker.IsLinkOpened);
                        cmd.Parameters.AddWithValue("@IsActive", letterTracker.IsActive);
                        cmd.Parameters.AddWithValue("@CreatedBy", letterTracker.CreatedBy);
                        cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        dOCViewModel.letterTracker.LetterTrackerId = Convert.ToInt32(cmd.Parameters["@Result"].Value);
                    }
                    dOCViewModel.Status = Status.Success;
                }
            }
            catch (Exception ex)
            {
                dOCViewModel.Status = Status.Failed;
                dOCViewModel.Message = ex.Message;
                throw ex;
            }
            return dOCViewModel;
        }
        #endregion
        #region Offline Upload
        /// <summary>
        /// Database layer method to Insert SP Upload Document details
        /// </summary>
        /// Delivery Point: DP4.5
        public DOCViewModel InsertOrUpdateOfflineUpload(DOC_OfflineUpload DOC_OfflineUpload)
        {
            DOCViewModel objDocumentInfo = new DOCViewModel();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_DOC_UploadDOCDocument";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ActionFlag", DOC_OfflineUpload.ActionFlag);
                        cmd.Parameters.AddWithValue("@DOCId", DOC_OfflineUpload.DOCId);
                        cmd.Parameters.AddWithValue("@DOC_SharepointURL", DOC_OfflineUpload.DOC_SharepointURL);
                        cmd.Parameters.AddWithValue("@CreatedBy", DOC_OfflineUpload.CreatedBy);
                        cmd.Parameters.Add("@ReturnId", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objDocumentInfo.dOC_OfflineUpload.DOCId = Convert.ToInt32(cmd.Parameters["@ReturnId"].Value);
                    }
                }
                objDocumentInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objDocumentInfo.Status = Status.Failed;
                objDocumentInfo.Message = ex.Message;
                throw ex;
            }
            return objDocumentInfo;
        }
        #endregion
        #region Backing Data
        public DOCViewModel InsertDOCBackingData(DOC_BackingData backingData)
        {
            DOCViewModel objDocumentInfo = new DOCViewModel();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                            cmd.CommandText = "SP_DoC_InsertDOCBackingData";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@DOCId", backingData.DOCId);
                            cmd.Parameters.AddWithValue("@SiteCode", backingData.SiteCode);
                            cmd.Parameters.AddWithValue("@SICCode", backingData.SICCode);
                            cmd.Parameters.AddWithValue("@SiteName", backingData.SiteName);
                            cmd.Parameters.AddWithValue("@AddressLine1", backingData.AddressLine1);
                            cmd.Parameters.AddWithValue("@AddressLine2", backingData.AddressLine2);
                            cmd.Parameters.AddWithValue("@Town", backingData.Town);
                            cmd.Parameters.AddWithValue("@County", backingData.County);
                            cmd.Parameters.AddWithValue("@Postcode", backingData.Postcode);
                            cmd.Parameters.AddWithValue("@WasteType", backingData.WasteType);
                            cmd.Parameters.AddWithValue("@EWCCode", backingData.EWCCode);
                            cmd.Parameters.AddWithValue("@MaterialType", backingData.MaterialType);
                            cmd.Parameters.AddWithValue("@ContainerType", backingData.ContainerType);
                            cmd.Parameters.AddWithValue("@ContainerSize", backingData.ContainerSize);
                            cmd.Parameters.AddWithValue("@Quantity", backingData.Quantity);
                            cmd.Parameters.AddWithValue("@FrequencyName", backingData.Frequencyname);
                            cmd.Parameters.AddWithValue("@ContractorName", backingData.ContractorName);
                            cmd.Parameters.AddWithValue("@WasteCarriersLicenceNumber", backingData.WasteCarriersLicenceNumber);
                            cmd.Parameters.AddWithValue("@Notes", backingData.Notes);
                            cmd.Parameters.AddWithValue("@CreatedBy", backingData.CreatedBy);
                            cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                            cmd.ExecuteNonQuery();
                            objDocumentInfo.doc_BackingData.DOCBackingId = Convert.ToInt32(cmd.Parameters["@Result"].Value);
                    }
                }
                objDocumentInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objDocumentInfo.Status = Status.Failed;
                objDocumentInfo.Message = ex.Message;
                throw ex;
            }
            return objDocumentInfo;
        }
        public DOCViewModel GetDOCBackingData(DOC_BackingData backingData)
        {
            DOCViewModel dOCViewModel = new DOCViewModel();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<DOC_BackingData> lstEntity = new List<DOC_BackingData>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_DOC_GetDOCBackingDataByDOCId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DOCId", backingData.DOCId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DOC_BackingData backingdata = new DOC_BackingData();
                                backingdata.DOCBackingId = string.IsNullOrEmpty(Convert.ToString(reader["DOC_BackingDataId"]))?0:Convert.ToInt32(reader["DOC_BackingDataId"]);
                                backingdata.DOCId = string.IsNullOrEmpty(Convert.ToString(reader["DOCId"]))?0:Convert.ToInt32(reader["DOCId"]);
                                backingdata.SiteCode = Convert.ToString(reader["SICCode"]);
                                backingdata.SICCode = Convert.ToString(reader["SICCode"]);
                                backingdata.SiteName = Convert.ToString(reader["SiteName"]);
                                backingdata.AddressLine1 = Convert.ToString(reader["AddressLine1"]);
                                backingdata.AddressLine2 = Convert.ToString(reader["AddressLine2"]);
                                backingdata.Town = Convert.ToString(reader["Town"]);
                                backingdata.County = Convert.ToString(reader["County"]);
                                backingdata.Postcode = Convert.ToString(reader["Postcode"]);
                                backingdata.WasteType = Convert.ToString(reader["WasteType"]);
                                backingdata.MaterialType = Convert.ToString(reader["MaterialType"]);
                                backingdata.EWCCode = Convert.ToString(reader["EWCCode"]);
                                backingdata.ContainerType = Convert.ToString(reader["ContainerType"]);
                                backingdata.ContainerSize = Convert.ToString(reader["ContainerSize"]);
                                backingdata.Quantity = string.IsNullOrEmpty(Convert.ToString(reader["Quantity"])) ? 0 : Convert.ToInt32(reader["Quantity"]);
                                backingdata.Frequencyname = Convert.ToString(reader["Frequencyname"]);
                                backingdata.ContractorName = Convert.ToString(reader["ContractorName"]);
                                backingdata.WasteCarriersLicenceNumber = Convert.ToString(reader["WasteCarriersLicenceNumber"]);
                                backingdata.Notes = Convert.ToString(reader["Notes"]);
                                backingdata.CreatedBy = string.IsNullOrEmpty(Convert.ToString(reader["CreatedBy"])) ? 0 : Convert.ToInt32(reader["CreatedBy"]);
                                lstEntity.Add(backingdata);
                            }
                        }
                    }
                    dOCViewModel.lstBackingData = lstEntity;
                }
                dOCViewModel.Status = Status.Success;
            }
            catch (Exception ex)
            {
                dOCViewModel.Status = Status.Failed;
                dOCViewModel.Message = ex.Message;
            }

            return dOCViewModel;
        }
        #endregion
    }
}
