using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using UKWSL.WMES.Business.Entities;

namespace UKWSL.WMES.Repositories.Service
{
    public class ServiceRepository : IServiceRepository
    {
        private string _connectionString;
        public ServiceRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ServiceInfo GetAllCustomerListForServiceDashboard(CompanyInfo companyInfo)
        {
            ServiceInfo serviceInfo = new ServiceInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ServiceInfo> lstEntity = new List<ServiceInfo>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Service_GetAllCustomerList]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FromDate", companyInfo.FromDate);
                        cmd.Parameters.AddWithValue("@ToDate", companyInfo.ToDate);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ServiceInfo objEntity = new ServiceInfo();
                                objEntity.CustomerId = string.IsNullOrEmpty(Convert.ToString(reader["CustomerId"])) ? 0 : Convert.ToInt32(reader["CustomerId"]);
                                objEntity.CompanyName = Convert.ToString(reader["CompanyName"]);
                                objEntity.CustomerStatusName = Convert.ToString(reader["CustomerStatusName"]);
                                objEntity.ActiveServices = string.IsNullOrEmpty(Convert.ToString(reader["ActiveServices"])) ? 0 : Convert.ToInt32(reader["ActiveServices"]);
                                objEntity.TotalContractors = string.IsNullOrEmpty(Convert.ToString(reader["No.ofContrators"])) ? 0 : Convert.ToInt32(reader["No.ofContrators"]);
                                objEntity.UnconfirmedJobs = string.IsNullOrEmpty(Convert.ToString(reader["UnconfirmedJobs"])) ? 0 : Convert.ToInt32(reader["UnconfirmedJobs"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    serviceInfo.lstCustomerServiceInfo = lstEntity;
                }
                serviceInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                serviceInfo.Status = Status.Failed;
                serviceInfo.Message = ex.Message;
            }
            return serviceInfo;
        }

        public ServiceInfo GetServiceDashboardOverView(CompanyInfo companyInfo)
        {
            ServiceInfo serviceInfo = new ServiceInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ServiceInfo> lstEntity = new List<ServiceInfo>();
                    List<ServiceInfo> lstEntity1 = new List<ServiceInfo>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Service_Dashboard_GetOverviewInfo]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FromDate", companyInfo.FromDate);
                        cmd.Parameters.AddWithValue("@ToDate", companyInfo.ToDate);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                serviceInfo.ActiveServices = string.IsNullOrEmpty(Convert.ToString(reader["ActiveServices"])) ? 0 : Convert.ToInt32(reader["ActiveServices"]);
                                serviceInfo.UnconfirmedJobs = string.IsNullOrEmpty(Convert.ToString(reader["UnconfirmedJobs"])) ? 0 : Convert.ToInt32(reader["UnconfirmedJobs"]);
                            }
                            reader.NextResult();
                            while (reader.Read())
                            {
                                ServiceInfo objEntity = new ServiceInfo();
                                objEntity.ServiceTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ServiceTypeId"])) ? 0 : Convert.ToInt32(reader["ServiceTypeId"]);
                                objEntity.ServiceTypeName = Convert.ToString(reader["ServiceTypeName"]);
                                objEntity.ServiceStatusId = string.IsNullOrEmpty(Convert.ToString(reader["ServiceStatusId"])) ? 0 : Convert.ToInt32(reader["ServiceStatusId"]);
                                objEntity.ServiceStatusName = Convert.ToString(reader["ServiceStatusName"]);
                                objEntity.TotalServices = string.IsNullOrEmpty(Convert.ToString(reader["TotalServices"])) ? 0 : Convert.ToInt32(reader["TotalServices"]);
                                lstEntity.Add(objEntity);
                            }
                            reader.NextResult();
                            while (reader.Read())
                            {
                                ServiceInfo objEntity = new ServiceInfo();
                                objEntity.ServiceTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ServiceTypeId"])) ? 0 : Convert.ToInt32(reader["ServiceTypeId"]);
                                objEntity.ServiceTypeName = Convert.ToString(reader["ServiceTypeName"]);
                                //objEntity.JobStatusId = string.IsNullOrEmpty(Convert.ToString(reader["JobStatusId"])) ? 0 : Convert.ToInt32(reader["JobStatusId"]);
                                //objEntity.JobStatusName = Convert.ToString(reader["JobStatusName"]);
                                objEntity.TotalServices = string.IsNullOrEmpty(Convert.ToString(reader["TotalServices"])) ? 0 : Convert.ToInt32(reader["TotalServices"]);
                                lstEntity1.Add(objEntity);
                            }
                        }
                    }
                    serviceInfo.lstActiveServicesInfo = lstEntity;
                    serviceInfo.lstUnconfirmedJobsInfo = lstEntity1;
                }
                serviceInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                serviceInfo.Status = Status.Failed;
                serviceInfo.Message = ex.Message;
            }
            return serviceInfo;
        }

        public ServiceInfo GetAllServicebySite(CustomerSite customerSite)
        {
            ServiceInfo serviceInfo = new ServiceInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ServiceBasicInfo> lstEntity = new List<ServiceBasicInfo>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Service_GetAllServicebySite]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SiteId", customerSite.Customer_SiteId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ServiceBasicInfo objEntity = new ServiceBasicInfo();
                                objEntity.JobId = string.IsNullOrEmpty(Convert.ToString(reader["JobId"])) ? 0 : Convert.ToInt32(reader["JobId"]);
                                objEntity.Customer_SiteId = string.IsNullOrEmpty(Convert.ToString(reader["Customer_SiteId"])) ? 0 : Convert.ToInt32(reader["Customer_SiteId"]);
                                objEntity.ServiceId = string.IsNullOrEmpty(Convert.ToString(reader["ServiceId"])) ? 0 : Convert.ToInt32(reader["ServiceId"]);
                                objEntity.ServiceTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ServiceTypeId"])) ? 0 : Convert.ToInt32(reader["ServiceTypeId"]);
                                objEntity.ServiceTypeName = Convert.ToString(reader["ServiceTypeName"]);
                                objEntity.ServiceStatusId = string.IsNullOrEmpty(Convert.ToString(reader["ServiceStatusId"])) ? 0 : Convert.ToInt32(reader["ServiceStatusId"]);
                                objEntity.ServiceStatusName = Convert.ToString(reader["ServiceStatusName"]);
                                objEntity.WasteTypeId = string.IsNullOrEmpty(Convert.ToString(reader["WasteTypeId"])) ? 0 : Convert.ToInt32(reader["WasteTypeId"]);
                                objEntity.WasteType_Name = Convert.ToString(reader["WasteType_Name"]);
                                objEntity.MaterialType_Name = Convert.ToString(reader["MaterialType_Name"]);
                                objEntity.ContainerType_Name = Convert.ToString(reader["ContainerType_Name"]);
                                objEntity.ContainerSize_Name = Convert.ToString(reader["ContainerSize_Name"]);
                                objEntity.Quantity = string.IsNullOrEmpty(Convert.ToString(reader["Quantity"])) ? 0 : Convert.ToInt32(reader["Quantity"]);
                                objEntity.VisitsPerWeek = Convert.ToString(reader["VisitsPerWeek"]);
                                objEntity.DeliveryDate = string.IsNullOrEmpty(Convert.ToString(reader["DeliveryDate"])) ? (DateTime?)null : Convert.ToDateTime(reader["DeliveryDate"]);
                                objEntity.CollectionDate = string.IsNullOrEmpty(Convert.ToString(reader["CollectionDate"])) ? (DateTime?)null : Convert.ToDateTime(reader["CollectionDate"]);
                                objEntity.CollectionDays = Convert.ToString(reader["CollectionDays"]);
                                objEntity.ContractorName = Convert.ToString(reader["ContractorName"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    serviceInfo.lstServiceBasicInfo = lstEntity;
                }
                serviceInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                serviceInfo.Status = Status.Failed;
                serviceInfo.Message = ex.Message;
            }
            return serviceInfo;
        }

        public ServiceJobDetails GetServiceDetailsByJobId(ServiceBasicInfo serviceBasicInfo)
        {
            ServiceJobDetails objServiceJob = new ServiceJobDetails();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Service_GetServiceDetailsByJobId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@JobId", serviceBasicInfo.JobId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                objServiceJob.JobId = string.IsNullOrEmpty(Convert.ToString(reader["JobId"])) ? 0 : Convert.ToInt32(reader["JobId"]);
                                objServiceJob.ServiceId = string.IsNullOrEmpty(Convert.ToString(reader["ServiceId"])) ? 0 : Convert.ToInt32(reader["ServiceId"]);
                                objServiceJob.JobTypeId = string.IsNullOrEmpty(Convert.ToString(reader["JobTypeId"])) ? 0 : Convert.ToInt32(reader["JobTypeId"]);
                                objServiceJob.JobTypeName = Convert.ToString(reader["JobTypeName"]);
                                objServiceJob.JobStatusId = string.IsNullOrEmpty(Convert.ToString(reader["JobStatusId"])) ? 0 : Convert.ToInt32(reader["JobStatusId"]);
                                objServiceJob.JobStatusName = Convert.ToString(reader["JobStatusName"]);
                                objServiceJob.ServiceTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ServiceTypeId"])) ? 0 : Convert.ToInt32(reader["ServiceTypeId"]);
                                objServiceJob.ServiceTypeName = Convert.ToString(reader["ServiceTypeName"]);
                                objServiceJob.ServiceStatusId = string.IsNullOrEmpty(Convert.ToString(reader["ServiceStatusId"])) ? 0 : Convert.ToInt32(reader["ServiceStatusId"]);
                                objServiceJob.ServiceStatusName = Convert.ToString(reader["ServiceStatusName"]);
                                objServiceJob.ContractorPOnumber = Convert.ToString(reader["ContractorPOnumber"]);
                                objServiceJob.SalesContactId = string.IsNullOrEmpty(Convert.ToString(reader["SalesContactId"])) ? 0 : Convert.ToInt32(reader["SalesContactId"]);
                                objServiceJob.ServiceComments = Convert.ToString(reader["ServiceComments"]);
                                objServiceJob.InternalComments = Convert.ToString(reader["InternalComments"]);
                                objServiceJob.Customer_SiteId = string.IsNullOrEmpty(Convert.ToString(reader["Customer_SiteId"])) ? 0 : Convert.ToInt32(reader["Customer_SiteId"]);
                                objServiceJob.WasteTypeId = string.IsNullOrEmpty(Convert.ToString(reader["WasteTypeId"])) ? 0 : Convert.ToInt32(reader["WasteTypeId"]);
                                objServiceJob.MaterialTypeId = string.IsNullOrEmpty(Convert.ToString(reader["MaterialTypeId"])) ? 0 : Convert.ToInt32(reader["MaterialTypeId"]);
                                objServiceJob.ContainerTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ContainerTypeId"])) ? 0 : Convert.ToInt32(reader["ContainerTypeId"]);
                                objServiceJob.ContainerSizeId = string.IsNullOrEmpty(Convert.ToString(reader["ContainerSizeId"])) ? 0 : Convert.ToInt32(reader["ContainerSizeId"]);
                                objServiceJob.FrequencyId = string.IsNullOrEmpty(Convert.ToString(reader["FrequencyId"])) ? 0 : Convert.ToInt32(reader["FrequencyId"]);
                                objServiceJob.MaterialType_Name = Convert.ToString(reader["MaterialType_Name"]);
                                objServiceJob.EWCCode = Convert.ToString(reader["EWCCode"]);
                                objServiceJob.ContainerType_Name = Convert.ToString(reader["ContainerType_Name"]);
                                objServiceJob.ContainerSize_Name = Convert.ToString(reader["ContainerSize_Name"]);
                                objServiceJob.AssumedContainerWeight = string.IsNullOrEmpty(Convert.ToString(reader["AssumedContainerWeight"])) ? 0 : Convert.ToDecimal(reader["AssumedContainerWeight"]);
                                objServiceJob.BagTypeId = string.IsNullOrEmpty(Convert.ToString(reader["BagTypeId"])) ? 0 : Convert.ToInt32(reader["BagTypeId"]);
                                objServiceJob.Quantity = string.IsNullOrEmpty(Convert.ToString(reader["Quantity"])) ? (int?)null : Convert.ToInt32(reader["Quantity"]);
                                objServiceJob.VisitsPerWeek = Convert.ToString(reader["VisitsPerWeek"]);
                                objServiceJob.WeightType = Convert.ToString(reader["WeightType"]);
                                objServiceJob.WeightUsage = Convert.ToString(reader["WeightUsage"]);
                                objServiceJob.Extra_CustomerPONumber = Convert.ToString(reader["Extra_CustomerPONumber"]);
                                objServiceJob.Extra_TicketNo = Convert.ToString(reader["Extra_TicketNo"]);
                                objServiceJob.Extra_Monday = string.IsNullOrEmpty(Convert.ToString(reader["Extra_Monday"])) ? false : Convert.ToBoolean(reader["Extra_Monday"]);
                                objServiceJob.Extra_Tuesday = string.IsNullOrEmpty(Convert.ToString(reader["Extra_Tuesday"])) ? false : Convert.ToBoolean(reader["Extra_Tuesday"]);
                                objServiceJob.Extra_Wednesday = string.IsNullOrEmpty(Convert.ToString(reader["Extra_Wednesday"])) ? false : Convert.ToBoolean(reader["Extra_Wednesday"]);
                                objServiceJob.Extra_Thursday = string.IsNullOrEmpty(Convert.ToString(reader["Extra_Thursday"])) ? false : Convert.ToBoolean(reader["Extra_Thursday"]);
                                objServiceJob.Extra_Friday = string.IsNullOrEmpty(Convert.ToString(reader["Extra_Friday"])) ? false : Convert.ToBoolean(reader["Extra_Friday"]);
                                objServiceJob.Extra_Saturday = string.IsNullOrEmpty(Convert.ToString(reader["Extra_Saturday"])) ? false : Convert.ToBoolean(reader["Extra_Saturday"]);
                                objServiceJob.Extra_Sunday = string.IsNullOrEmpty(Convert.ToString(reader["Extra_Sunday"])) ? false : Convert.ToBoolean(reader["Extra_Sunday"]);
                                objServiceJob.Extra_CustomField1 = Convert.ToString(reader["Extra_CustomField1"]);
                                objServiceJob.Extra_CustomField2 = Convert.ToString(reader["Extra_CustomField2"]);
                                objServiceJob.Extra_CustomField3 = Convert.ToString(reader["Extra_CustomField3"]);
                                objServiceJob.Extra_CustomField4 = Convert.ToString(reader["Extra_CustomField4"]);
                                objServiceJob.Extra_CustomField5 = Convert.ToString(reader["Extra_CustomField5"]);

                                objServiceJob.CustPrice_price_per_lift = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_price_per_lift"])) ? (decimal?)null : Convert.ToDecimal(reader["CustPrice_price_per_lift"]);
                                objServiceJob.CustPrice_additional_charge = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_additional_charge"])) ? (decimal?)null : Convert.ToDecimal(reader["CustPrice_additional_charge"]);
                                objServiceJob.CustPrice_additional_charge_frequency = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_additional_charge_frequency"])) ? (decimal?)null : Convert.ToDecimal(reader["CustPrice_additional_charge_frequency"]);
                                objServiceJob.CustPrice_reason_for_additional_charge = Convert.ToString(reader["CustPrice_reason_for_additional_charge"]);
                                objServiceJob.CustPrice_transport = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_transport"])) ? (decimal?)null : Convert.ToDecimal(reader["CustPrice_transport"]);
                                objServiceJob.CustPrice_transport_per_quantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_transport_per_quantity"])) ? (decimal?)null : Convert.ToDecimal(reader["CustPrice_transport_per_quantity"]);
                                objServiceJob.CustPrice_minimum_transport_charge = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_minimum_transport_charge"])) ? (decimal?)null : Convert.ToDecimal(reader["CustPrice_minimum_transport_charge"]);
                                objServiceJob.CustPrice_price_per_quantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_price_per_quantity"])) ? (decimal?)null : Convert.ToDecimal(reader["CustPrice_price_per_quantity"]);
                                objServiceJob.CustPrice_QtyTypeId = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_QtyTypeId"])) ? (int?)null : Convert.ToInt32(reader["CustPrice_QtyTypeId"]);
                                objServiceJob.CustPrice_minimum_quantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_minimum_quantity"])) ? (decimal?)null : Convert.ToDecimal(reader["CustPrice_minimum_quantity"]);
                                objServiceJob.CustPrice_max_quantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_max_quantity"])) ? (decimal?)null : Convert.ToDecimal(reader["CustPrice_max_quantity"]);
                                objServiceJob.CustPrice_excess_weight_charge = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_excess_weight_charge"])) ? (decimal?)null : Convert.ToDecimal(reader["CustPrice_excess_weight_charge"]);
                                objServiceJob.CustPrice_rental_day_per_container = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_rental_day_per_container"])) ? (decimal?)null : Convert.ToDecimal(reader["CustPrice_rental_day_per_container"]);
                                objServiceJob.CustPrice_demurrage_charge_per_hour = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_demurrage_charge_per_hour"])) ? (decimal?)null : Convert.ToDecimal(reader["CustPrice_demurrage_charge_per_hour"]);
                                objServiceJob.CustPrice_actual_demurrage = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_actual_demurrage"])) ? (decimal?)null : Convert.ToDecimal(reader["CustPrice_actual_demurrage"]);
                                objServiceJob.CustPrice_consignment_note_Charge_vist = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_consignment_note_Charge_vist"])) ? (decimal?)null : Convert.ToDecimal(reader["CustPrice_consignment_note_Charge_vist"]);

                                objServiceJob.ContractorName = Convert.ToString(reader["ContractorName"]);
                                objServiceJob.ContractorId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorId"])) ? 0 : Convert.ToInt32(reader["ContractorId"]);
                                objServiceJob.ContractorContact = Convert.ToString(reader["ContractorContact"]);
                                objServiceJob.DepotId = string.IsNullOrEmpty(Convert.ToString(reader["DepotId"])) ? (int?)null : Convert.ToInt32(reader["DepotId"]);
                                objServiceJob.FacilityTypeId = string.IsNullOrEmpty(Convert.ToString(reader["FacilityTypeId"])) ? (int?)null : Convert.ToInt32(reader["FacilityTypeId"]);
                                objServiceJob.FacilityId = string.IsNullOrEmpty(Convert.ToString(reader["FacilityId"])) ? (int?)null : Convert.ToInt32(reader["FacilityId"]);
                                objServiceJob.EndDestinationTypeId = string.IsNullOrEmpty(Convert.ToString(reader["EndDestinationTypeId"])) ? 0 : Convert.ToInt32(reader["EndDestinationTypeId"]);
                                objServiceJob.EndDestination = Convert.ToString(reader["EndDestination"]);
                                objServiceJob.ContrPrice_Cost_per_lift = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_Cost_per_lift"])) ? (decimal?)null : Convert.ToDecimal(reader["ContrPrice_Cost_per_lift"]);
                                objServiceJob.ContrPrice_additional_charge = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_additional_charge"])) ? (decimal?)null : Convert.ToDecimal(reader["ContrPrice_additional_charge"]); ;
                                objServiceJob.ContrPrice_additional_charge_frequency = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_additional_charge_frequency"])) ? (decimal?)null : Convert.ToDecimal(reader["ContrPrice_additional_charge_frequency"]);
                                objServiceJob.ContrPrice_reason_for_additional_charge = Convert.ToString(reader["ContrPrice_reason_for_additional_charge"]);
                                objServiceJob.ContrPrice_transportcost = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_transportcost"])) ? (decimal?)null : Convert.ToDecimal(reader["ContrPrice_transportcost"]);
                                objServiceJob.ContrPrice_transport_per_quantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_transport_per_quantity"])) ? (decimal?)null : Convert.ToDecimal(reader["ContrPrice_transport_per_quantity"]);
                                objServiceJob.ContrPrice_minimum_transport_charge = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_minimum_transport_charge"])) ? (decimal?)null : Convert.ToDecimal(reader["ContrPrice_minimum_transport_charge"]);
                                objServiceJob.ContrPrice_Cost_per_quantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_Cost_per_quantity"])) ? (decimal?)null : Convert.ToDecimal(reader["ContrPrice_Cost_per_quantity"]);
                                objServiceJob.ContrPrice_QtyTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_QtyTypeId"])) ? (int?)null : Convert.ToInt32(reader["ContrPrice_QtyTypeId"]);
                                objServiceJob.ContrPrice_minimum_quantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_minimum_quantity"])) ? (decimal?)null : Convert.ToDecimal(reader["ContrPrice_minimum_quantity"]);
                                objServiceJob.ContrPrice_max_quantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_max_quantity"])) ? (decimal?)null : Convert.ToDecimal(reader["ContrPrice_max_quantity"]);
                                objServiceJob.ContrPrice_excess_weight_charge = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_excess_weight_charge"])) ? (decimal?)null : Convert.ToDecimal(reader["ContrPrice_excess_weight_charge"]);
                                objServiceJob.ContrPrice_rental_day_per_container = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_rental_day_per_container"])) ? (decimal?)null : Convert.ToDecimal(reader["ContrPrice_rental_day_per_container"]);
                                objServiceJob.ContrPrice_demurrage_charge_per_hour = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_demurrage_charge_per_hour"])) ? (decimal?)null : Convert.ToDecimal(reader["ContrPrice_demurrage_charge_per_hour"]);
                                objServiceJob.ContrPrice_actual_demurrage = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_actual_demurrage"])) ? (decimal?)null : Convert.ToDecimal(reader["ContrPrice_actual_demurrage"]);
                                objServiceJob.ContrPrice_consignment_note_visit = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_consignment_note_visit"])) ? (decimal?)null : Convert.ToDecimal(reader["ContrPrice_consignment_note_visit"]);

                                objServiceJob.Confirmation_PlannedDeliveryDate = string.IsNullOrEmpty(Convert.ToString(reader["Confirmation_PlannedDeliveryDate"])) ? (DateTime?)null : Convert.ToDateTime(reader["Confirmation_PlannedDeliveryDate"]);
                                objServiceJob.Confirmation_PeriodofDelivery = Convert.ToString(reader["Confirmation_PeriodofDelivery"]);
                                objServiceJob.Confirmation_ActualDateofDelivery = string.IsNullOrEmpty(Convert.ToString(reader["Confirmation_ActualDateofDelivery"])) ? (DateTime?)null : Convert.ToDateTime(reader["Confirmation_ActualDateofDelivery"]);
                                objServiceJob.Confirmation_DeliveryFailureReason = string.IsNullOrEmpty(Convert.ToString(reader["Confirmation_DeliveryFailureReason"])) ? 0 : Convert.ToInt32(reader["Confirmation_DeliveryFailureReason"]);
                                objServiceJob.Confirmation_PlannedCollectionDate = string.IsNullOrEmpty(Convert.ToString(reader["Confirmation_PlannedCollectionDate"])) ? (DateTime?)null : Convert.ToDateTime(reader["Confirmation_PlannedCollectionDate"]);
                                objServiceJob.Confirmation_PeriodofCollection = Convert.ToString(reader["Confirmation_PeriodofCollection"]);
                                objServiceJob.Confirmation_ActualCollectionDate = string.IsNullOrEmpty(Convert.ToString(reader["Confirmation_ActualCollectionDate"])) ? (DateTime?)null : Convert.ToDateTime(reader["Confirmation_ActualCollectionDate"]);
                            }
                        }
                    }
                }
                objServiceJob.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objServiceJob.Status = Status.Failed;
                objServiceJob.Message = ex.Message;
            }
            return objServiceJob;
        }

        public ServiceJobDetails GetServiceHistoryByServiceId(ServiceBasicInfo serviceBasicInfo)
        {
            ServiceJobDetails serviceJobDetails = new ServiceJobDetails();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ServiceJobDetails> lstEntity = new List<ServiceJobDetails>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Service_GetServiceHistoryByServiceId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ServiceId", serviceBasicInfo.ServiceId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ServiceJobDetails objEntity = new ServiceJobDetails();
                                objEntity.JobId = string.IsNullOrEmpty(Convert.ToString(reader["JobId"])) ? 0 : Convert.ToInt32(reader["JobId"]);
                                objEntity.ServiceId = string.IsNullOrEmpty(Convert.ToString(reader["ServiceId"])) ? 0 : Convert.ToInt32(reader["ServiceId"]);
                                objEntity.ServiceStatusId = string.IsNullOrEmpty(Convert.ToString(reader["ServiceStatusId"])) ? 0 : Convert.ToInt32(reader["ServiceStatusId"]);
                                objEntity.ServiceStatusName = Convert.ToString(reader["ServiceStatusName"]);
                                //objEntity.JobStatusId = string.IsNullOrEmpty(Convert.ToString(reader["JobStatusId"])) ? 0 : Convert.ToInt32(reader["JobStatusId"]);
                                //objEntity.JobStatusName = Convert.ToString(reader["JobStatusName"]);
                                objEntity.JobConfirmedBy = Convert.ToString(reader["JobConfirmedBy"]);
                                objEntity.JobTypeId = string.IsNullOrEmpty(Convert.ToString(reader["JobTypeId"])) ? 0 : Convert.ToInt32(reader["JobTypeId"]);
                                objEntity.JobTypeName = Convert.ToString(reader["JobTypeName"]);
                                objEntity.ServiceTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ServiceTypeId"])) ? 0 : Convert.ToInt32(reader["ServiceTypeId"]);
                                objEntity.ServiceTypeName = Convert.ToString(reader["ServiceTypeName"]);
                                objEntity.ContractorPOnumber = Convert.ToString(reader["ContractorPONumber"]);
                                objEntity.WasteTypeId = string.IsNullOrEmpty(Convert.ToString(reader["WasteTypeId"])) ? 0 : Convert.ToInt32(reader["WasteTypeId"]);
                                objEntity.WasteType_Name = Convert.ToString(reader["WasteType_Name"]);
                                objEntity.MaterialType_Name = Convert.ToString(reader["MaterialType_Name"]);
                                objEntity.ContainerType_Name = Convert.ToString(reader["ContainerType_Name"]);
                                objEntity.ContainerSize_Name = Convert.ToString(reader["ContainerSize_Name"]);
                                objEntity.CreatedByName = Convert.ToString(reader["CreatedBy"]);
                                objEntity.CreatedOn = string.IsNullOrEmpty(Convert.ToString(reader["CreatedOn"])) ? new DateTime() : Convert.ToDateTime(reader["CreatedOn"]);
                                objEntity.ContractorName = Convert.ToString(reader["CompanyName"]);
                                objEntity.Quantity = string.IsNullOrEmpty(Convert.ToString(reader["Quantity"])) ? (int?)null : Convert.ToInt32(reader["Quantity"]);
                                objEntity.Confirmation_ActualDateofDelivery = string.IsNullOrEmpty(Convert.ToString(reader["Confirmation_ActualDateOfDelivery"])) ? (DateTime?)null : Convert.ToDateTime(reader["Confirmation_ActualDateOfDelivery"]);
                                objEntity.Confirmation_ActualCollectionDate = string.IsNullOrEmpty(Convert.ToString(reader["Confirmation_ActualCollectionDate"])) ? (DateTime?)null : Convert.ToDateTime(reader["Confirmation_ActualCollectionDate"]);

                                lstEntity.Add(objEntity);
                            }
                            reader.NextResult();
                            while (reader.Read())
                            {
                                serviceJobDetails.JobId = string.IsNullOrEmpty(Convert.ToString(reader["JobId"])) ? 0 : Convert.ToInt32(reader["JobId"]);
                                serviceJobDetails.ServiceId = string.IsNullOrEmpty(Convert.ToString(reader["ServiceId"])) ? 0 : Convert.ToInt32(reader["ServiceId"]);
                            }
                        }
                    }
                    serviceJobDetails.lstServiceHistory = lstEntity;
                }
                serviceJobDetails.Status = Status.Success;
            }
            catch (Exception ex)
            {
                serviceJobDetails.Status = Status.Failed;
                serviceJobDetails.Message = ex.Message;
            }
            return serviceJobDetails;
        }

        public ServiceJobDetails AddNewService(ServiceJobDetails serviceJobDetails)
        {
            ServiceJobDetails objServiceJobDetails = new ServiceJobDetails();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Service_AddNewService";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CustomerId", serviceJobDetails.CustomerId);
                        cmd.Parameters.AddWithValue("@Customer_SiteId", serviceJobDetails.Customer_SiteId);
                        cmd.Parameters.AddWithValue("@JobTypeId", serviceJobDetails.JobTypeId);
                        cmd.Parameters.AddWithValue("@ServiceTypeId", serviceJobDetails.ServiceTypeId);
                        cmd.Parameters.AddWithValue("@ServiceStatusId", serviceJobDetails.ServiceStatusId);
                        cmd.Parameters.AddWithValue("@WasteTypeId", serviceJobDetails.WasteTypeId);
                        cmd.Parameters.AddWithValue("@MaterialTypeId", serviceJobDetails.MaterialTypeId);
                        cmd.Parameters.AddWithValue("@EWCCode", serviceJobDetails.EWCCode);
                        cmd.Parameters.AddWithValue("@ContainerTypeId", serviceJobDetails.ContainerTypeId);
                        cmd.Parameters.AddWithValue("@ContainerSizeId", serviceJobDetails.ContainerSizeId);
                        cmd.Parameters.AddWithValue("@BagTypeId", serviceJobDetails.BagTypeId);
                        cmd.Parameters.AddWithValue("@AssumedContainerWeight", serviceJobDetails.AssumedContainerWeight);
                        cmd.Parameters.AddWithValue("@Quantity", serviceJobDetails.Quantity);
                        cmd.Parameters.AddWithValue("@FrequencyTypeId", serviceJobDetails.FrequencyTypeId);
                        cmd.Parameters.AddWithValue("@FrequencyId", serviceJobDetails.FrequencyId);
                        cmd.Parameters.AddWithValue("@VisitsPerWeek", serviceJobDetails.VisitsPerWeek);
                        cmd.Parameters.AddWithValue("@ContractorPOnumber", serviceJobDetails.ContractorPOnumber);
                        cmd.Parameters.AddWithValue("@SalesContactId", serviceJobDetails.SalesContactId);
                        cmd.Parameters.AddWithValue("@ServiceComments", serviceJobDetails.ServiceComments);
                        cmd.Parameters.AddWithValue("@InternalComments", serviceJobDetails.InternalComments);
                        cmd.Parameters.AddWithValue("@IncludeCommentInInvoice", serviceJobDetails.IncludeCommentInInvoice);
                        cmd.Parameters.AddWithValue("@WeightType", serviceJobDetails.WeightType);
                        cmd.Parameters.AddWithValue("@WeightUsage", serviceJobDetails.WeightUsage);
                        cmd.Parameters.AddWithValue("@CustomerPONumber", serviceJobDetails.Extra_CustomerPONumber);
                        cmd.Parameters.AddWithValue("@TicketNo", serviceJobDetails.Extra_TicketNo);
                        cmd.Parameters.AddWithValue("@Monday", serviceJobDetails.Extra_Monday);
                        cmd.Parameters.AddWithValue("@Tuesday", serviceJobDetails.Extra_Tuesday);
                        cmd.Parameters.AddWithValue("@Wednesday", serviceJobDetails.Extra_Wednesday);
                        cmd.Parameters.AddWithValue("@Thursday", serviceJobDetails.Extra_Thursday);
                        cmd.Parameters.AddWithValue("@Friday", serviceJobDetails.Extra_Friday);
                        cmd.Parameters.AddWithValue("@Saturday", serviceJobDetails.Extra_Saturday);
                        cmd.Parameters.AddWithValue("@Sunday", serviceJobDetails.Extra_Sunday);
                        cmd.Parameters.AddWithValue("@CustomField1", serviceJobDetails.Extra_CustomField1);
                        cmd.Parameters.AddWithValue("@CustomField2", serviceJobDetails.Extra_CustomField2);
                        cmd.Parameters.AddWithValue("@CustomField3", serviceJobDetails.Extra_CustomField3);
                        cmd.Parameters.AddWithValue("@CustomField4", serviceJobDetails.Extra_CustomField4);
                        cmd.Parameters.AddWithValue("@CustomField5", serviceJobDetails.Extra_CustomField5);
                        cmd.Parameters.AddWithValue("@Confirmation_PlannedDeliveryDate", serviceJobDetails.Confirmation_PlannedDeliveryDate);
                        cmd.Parameters.AddWithValue("@Confirmation_PeriodofDelivery", serviceJobDetails.Confirmation_PeriodofDelivery);
                        cmd.Parameters.AddWithValue("@Confirmation_ActualDateofDelivery", serviceJobDetails.Confirmation_ActualDateofDelivery);
                        cmd.Parameters.AddWithValue("@Confirmation_DeliveryFailureReason", serviceJobDetails.Confirmation_DeliveryFailureReason);
                        cmd.Parameters.AddWithValue("@Confirmation_PlannedCollectionDate", serviceJobDetails.Confirmation_PlannedCollectionDate);
                        cmd.Parameters.AddWithValue("@Confirmation_PeriodofCollection", serviceJobDetails.Confirmation_PeriodofCollection);
                        cmd.Parameters.AddWithValue("@Confirmation_ActualCollectionDate", serviceJobDetails.Confirmation_ActualCollectionDate);
                        cmd.Parameters.AddWithValue("@CustPrice_price_per_lift", serviceJobDetails.CustPrice_price_per_lift);
                        cmd.Parameters.AddWithValue("@CustPrice_additional_charge ", serviceJobDetails.CustPrice_additional_charge);
                        cmd.Parameters.AddWithValue("@CustPrice_additional_charge_frequency", serviceJobDetails.CustPrice_additional_charge_frequency);
                        cmd.Parameters.AddWithValue("@CustPrice_reason_for_additional_charge", serviceJobDetails.CustPrice_reason_for_additional_charge);
                        cmd.Parameters.AddWithValue("@CustPrice_transport", serviceJobDetails.CustPrice_transport);
                        cmd.Parameters.AddWithValue("@CustPrice_transport_per_quantity", serviceJobDetails.CustPrice_transport_per_quantity);
                        cmd.Parameters.AddWithValue("@CustPrice_minimum_transport_charge", serviceJobDetails.CustPrice_minimum_transport_charge);
                        cmd.Parameters.AddWithValue("@CustPrice_price_per_quantity", serviceJobDetails.CustPrice_price_per_quantity);
                        cmd.Parameters.AddWithValue("@CustPrice_QtyTypeId", serviceJobDetails.CustPrice_QtyTypeId);
                        cmd.Parameters.AddWithValue("@CustPrice_minimum_quantity", serviceJobDetails.CustPrice_minimum_quantity);
                        cmd.Parameters.AddWithValue("@CustPrice_max_quantity", serviceJobDetails.CustPrice_max_quantity);
                        cmd.Parameters.AddWithValue("@CustPrice_excess_weight_charge", serviceJobDetails.CustPrice_excess_weight_charge);
                        cmd.Parameters.AddWithValue("@CustPrice_rental_day_per_container", serviceJobDetails.CustPrice_rental_day_per_container);
                        cmd.Parameters.AddWithValue("@CustPrice_demurrage_charge_per_hour", serviceJobDetails.CustPrice_demurrage_charge_per_hour);
                        cmd.Parameters.AddWithValue("@CustPrice_actual_demurrage", serviceJobDetails.CustPrice_actual_demurrage);
                        cmd.Parameters.AddWithValue("@CustPrice_consignment_note_Charge_vist", serviceJobDetails.CustPrice_consignment_note_Charge_vist);
                        cmd.Parameters.AddWithValue("@ContractorName", serviceJobDetails.ContractorName);
                        cmd.Parameters.AddWithValue("@ContractorId", serviceJobDetails.ContractorId);
                        cmd.Parameters.AddWithValue("@ContractorContact", serviceJobDetails.ContractorContact);
                        cmd.Parameters.AddWithValue("@DepotId", serviceJobDetails.DepotId);
                        cmd.Parameters.AddWithValue("@FacilityTypeId", serviceJobDetails.FacilityTypeId);
                        cmd.Parameters.AddWithValue("@FacilityId", serviceJobDetails.FacilityId);
                        cmd.Parameters.AddWithValue("@EndDestinationTypeId", serviceJobDetails.EndDestinationTypeId);
                        cmd.Parameters.AddWithValue("@EndDestination", serviceJobDetails.EndDestination);
                        cmd.Parameters.AddWithValue("@ContrPrice_Cost_per_lift", serviceJobDetails.ContrPrice_Cost_per_lift);
                        cmd.Parameters.AddWithValue("@ContrPrice_additional_charge", serviceJobDetails.ContrPrice_additional_charge);
                        cmd.Parameters.AddWithValue("@ContrPrice_additional_charge_frequency", serviceJobDetails.ContrPrice_additional_charge_frequency);
                        cmd.Parameters.AddWithValue("@ContrPrice_reason_for_additional_charge", serviceJobDetails.ContrPrice_reason_for_additional_charge);
                        cmd.Parameters.AddWithValue("@ContrPrice_transportcost", serviceJobDetails.ContrPrice_transportcost);
                        cmd.Parameters.AddWithValue("@ContrPrice_transport_per_quantity", serviceJobDetails.ContrPrice_transport_per_quantity);
                        cmd.Parameters.AddWithValue("@ContrPrice_minimum_transport_charge", serviceJobDetails.ContrPrice_minimum_transport_charge);
                        cmd.Parameters.AddWithValue("@ContrPrice_Cost_per_quantity", serviceJobDetails.ContrPrice_Cost_per_quantity);
                        cmd.Parameters.AddWithValue("@ContrPrice_QtyTypeId", serviceJobDetails.ContrPrice_QtyTypeId);
                        cmd.Parameters.AddWithValue("@ContrPrice_minimum_quantity", serviceJobDetails.ContrPrice_minimum_quantity);
                        cmd.Parameters.AddWithValue("@ContrPrice_max_quantity", serviceJobDetails.ContrPrice_max_quantity);
                        cmd.Parameters.AddWithValue("@ContrPrice_excess_weight_charge", serviceJobDetails.ContrPrice_excess_weight_charge);
                        cmd.Parameters.AddWithValue("@ContrPrice_rental_day_per_container", serviceJobDetails.ContrPrice_rental_day_per_container);
                        cmd.Parameters.AddWithValue("@ContrPrice_demurrage_charge_per_hour", serviceJobDetails.ContrPrice_demurrage_charge_per_hour);
                        cmd.Parameters.AddWithValue("@ContrPrice_actual_demurrage", serviceJobDetails.ContrPrice_actual_demurrage);
                        cmd.Parameters.AddWithValue("@ContrPrice_consignment_note_visit", serviceJobDetails.ContrPrice_consignment_note_visit);
                        cmd.Parameters.AddWithValue("@RemovalDategivenbyIncumbentContractor", serviceJobDetails.RemovalDategivenbyIncumbentContractor);
                        cmd.Parameters.AddWithValue("@ActualRemovalDategivenbyContractor", serviceJobDetails.ActualRemovalDategivenbyContractor);
                        cmd.Parameters.AddWithValue("@IncumbentContractorName", serviceJobDetails.IncumbentContractorName);
                        cmd.Parameters.AddWithValue("@IncumbentContactName", serviceJobDetails.IncumbentContactName);
                        cmd.Parameters.AddWithValue("@IncumbentTelephoneNumber", serviceJobDetails.IncumbentTelephoneNumber);
                        cmd.Parameters.AddWithValue("@MobilisationComments", serviceJobDetails.MobilisationComments);
                        cmd.Parameters.AddWithValue("@ExpectedAnnualTurnover", serviceJobDetails.ExpectedAnnualTurnover);
                        cmd.Parameters.AddWithValue("@ExpectedAnnualCoS", serviceJobDetails.ExpectedAnnualCoS);
                        cmd.Parameters.AddWithValue("@ExpectedAnnualMargin", serviceJobDetails.ExpectedAnnualMargin);
                        cmd.Parameters.AddWithValue("@Post_MobilisationAnnualTurnover", serviceJobDetails.Post_MobilisationAnnualTurnover);
                        cmd.Parameters.AddWithValue("@Post_MobilisationAnnualCoS", serviceJobDetails.Post_MobilisationAnnualCoS);
                        cmd.Parameters.AddWithValue("@Post_MobilisationAnnualMargin", serviceJobDetails.Post_MobilisationAnnualMargin);
                        cmd.Parameters.AddWithValue("@AnnualTurnoverDifference", serviceJobDetails.AnnualTurnoverDifference);
                        cmd.Parameters.AddWithValue("@AnnualCoSDifference", serviceJobDetails.AnnualCoSDifference);
                        cmd.Parameters.AddWithValue("@AnnualMarginDifference", serviceJobDetails.AnnualMarginDifference);
                        cmd.Parameters.AddWithValue("@CreatedBy", serviceJobDetails.CreatedBy);
                        //cmd.ExecuteNonQuery();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                objServiceJobDetails.JobId = string.IsNullOrEmpty(Convert.ToString(reader["JobId"])) ? 0 : Convert.ToInt32(reader["JobId"]);
                                objServiceJobDetails.ContractorId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorId"])) ? 0 : Convert.ToInt32(reader["ContractorId"]);
                            }
                        }
                    }
                }
                objServiceJobDetails.CustomerId = serviceJobDetails.CustomerId;
                objServiceJobDetails.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objServiceJobDetails.Status = Status.Failed;
                objServiceJobDetails.Message = ex.Message;
                throw ex;
            }
            return objServiceJobDetails;
        }
        public ServiceJobDetails UpdateService(ServiceJobDetails serviceJobDetails)
        {
            ServiceJobDetails objServiceJobDetails = new ServiceJobDetails();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Service_UpdateService";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ServiceId", serviceJobDetails.ServiceId);
                        cmd.Parameters.AddWithValue("@JobId", serviceJobDetails.JobId);
                        cmd.Parameters.AddWithValue("@CustomerId", serviceJobDetails.CustomerId);
                        cmd.Parameters.AddWithValue("@Customer_SiteId", serviceJobDetails.Customer_SiteId);
                        cmd.Parameters.AddWithValue("@JobTypeId", serviceJobDetails.JobTypeId);
                        cmd.Parameters.AddWithValue("@ServiceTypeId", serviceJobDetails.ServiceTypeId);
                        cmd.Parameters.AddWithValue("@ServiceStatusId", serviceJobDetails.ServiceStatusId);
                        cmd.Parameters.AddWithValue("@WasteTypeId", serviceJobDetails.WasteTypeId);
                        cmd.Parameters.AddWithValue("@MaterialTypeId", serviceJobDetails.MaterialTypeId);
                        cmd.Parameters.AddWithValue("@EWCCode", serviceJobDetails.EWCCode);
                        cmd.Parameters.AddWithValue("@ContainerTypeId", serviceJobDetails.ContainerTypeId);
                        cmd.Parameters.AddWithValue("@ContainerSizeId", serviceJobDetails.ContainerSizeId);
                        cmd.Parameters.AddWithValue("@BagTypeId", serviceJobDetails.BagTypeId);
                        cmd.Parameters.AddWithValue("@AssumedContainerWeight", serviceJobDetails.AssumedContainerWeight);
                        cmd.Parameters.AddWithValue("@Quantity", serviceJobDetails.Quantity);
                        cmd.Parameters.AddWithValue("@FrequencyTypeId", serviceJobDetails.FrequencyTypeId);
                        cmd.Parameters.AddWithValue("@FrequencyId", serviceJobDetails.FrequencyId);
                        cmd.Parameters.AddWithValue("@VisitsPerWeek", serviceJobDetails.VisitsPerWeek);
                        cmd.Parameters.AddWithValue("@ContractorPOnumber", serviceJobDetails.ContractorPOnumber);
                        cmd.Parameters.AddWithValue("@SalesContactId", serviceJobDetails.SalesContactId);
                        cmd.Parameters.AddWithValue("@ServiceComments", serviceJobDetails.ServiceComments);
                        cmd.Parameters.AddWithValue("@InternalComments", serviceJobDetails.InternalComments);
                        cmd.Parameters.AddWithValue("@IncludeCommentInInvoice", serviceJobDetails.IncludeCommentInInvoice);
                        cmd.Parameters.AddWithValue("@WeightType", serviceJobDetails.WeightType);
                        cmd.Parameters.AddWithValue("@WeightUsage", serviceJobDetails.WeightUsage);
                        cmd.Parameters.AddWithValue("@CustomerPONumber", serviceJobDetails.Extra_CustomerPONumber);
                        cmd.Parameters.AddWithValue("@TicketNo", serviceJobDetails.Extra_TicketNo);
                        cmd.Parameters.AddWithValue("@Monday", serviceJobDetails.Extra_Monday);
                        cmd.Parameters.AddWithValue("@Tuesday", serviceJobDetails.Extra_Tuesday);
                        cmd.Parameters.AddWithValue("@Wednesday", serviceJobDetails.Extra_Wednesday);
                        cmd.Parameters.AddWithValue("@Thursday", serviceJobDetails.Extra_Thursday);
                        cmd.Parameters.AddWithValue("@Friday", serviceJobDetails.Extra_Friday);
                        cmd.Parameters.AddWithValue("@Saturday", serviceJobDetails.Extra_Saturday);
                        cmd.Parameters.AddWithValue("@Sunday", serviceJobDetails.Extra_Sunday);
                        cmd.Parameters.AddWithValue("@CustomField1", serviceJobDetails.Extra_CustomField1);
                        cmd.Parameters.AddWithValue("@CustomField2", serviceJobDetails.Extra_CustomField2);
                        cmd.Parameters.AddWithValue("@CustomField3", serviceJobDetails.Extra_CustomField3);
                        cmd.Parameters.AddWithValue("@CustomField4", serviceJobDetails.Extra_CustomField4);
                        cmd.Parameters.AddWithValue("@CustomField5", serviceJobDetails.Extra_CustomField5);
                        cmd.Parameters.AddWithValue("@Confirmation_PlannedDeliveryDate", serviceJobDetails.Confirmation_PlannedDeliveryDate);
                        cmd.Parameters.AddWithValue("@Confirmation_PeriodofDelivery", serviceJobDetails.Confirmation_PeriodofDelivery);
                        cmd.Parameters.AddWithValue("@Confirmation_ActualDateofDelivery", serviceJobDetails.Confirmation_ActualDateofDelivery);
                        cmd.Parameters.AddWithValue("@Confirmation_DeliveryFailureReason", serviceJobDetails.Confirmation_DeliveryFailureReason);
                        cmd.Parameters.AddWithValue("@Confirmation_PlannedCollectionDate", serviceJobDetails.Confirmation_PlannedCollectionDate);
                        cmd.Parameters.AddWithValue("@Confirmation_PeriodofCollection", serviceJobDetails.Confirmation_PeriodofCollection);
                        cmd.Parameters.AddWithValue("@Confirmation_ActualCollectionDate", serviceJobDetails.Confirmation_ActualCollectionDate);
                        cmd.Parameters.AddWithValue("@CustPrice_price_per_lift", serviceJobDetails.CustPrice_price_per_lift);
                        cmd.Parameters.AddWithValue("@CustPrice_additional_charge ", serviceJobDetails.CustPrice_additional_charge);
                        cmd.Parameters.AddWithValue("@CustPrice_additional_charge_frequency", serviceJobDetails.CustPrice_additional_charge_frequency);
                        cmd.Parameters.AddWithValue("@CustPrice_reason_for_additional_charge", serviceJobDetails.CustPrice_reason_for_additional_charge);
                        cmd.Parameters.AddWithValue("@CustPrice_transport", serviceJobDetails.CustPrice_transport);
                        cmd.Parameters.AddWithValue("@CustPrice_transport_per_quantity", serviceJobDetails.CustPrice_transport_per_quantity);
                        cmd.Parameters.AddWithValue("@CustPrice_minimum_transport_charge", serviceJobDetails.CustPrice_minimum_transport_charge);
                        cmd.Parameters.AddWithValue("@CustPrice_price_per_quantity", serviceJobDetails.CustPrice_price_per_quantity);
                        cmd.Parameters.AddWithValue("@CustPrice_QtyTypeId", serviceJobDetails.CustPrice_QtyTypeId);
                        cmd.Parameters.AddWithValue("@CustPrice_minimum_quantity", serviceJobDetails.CustPrice_minimum_quantity);
                        cmd.Parameters.AddWithValue("@CustPrice_max_quantity", serviceJobDetails.CustPrice_max_quantity);
                        cmd.Parameters.AddWithValue("@CustPrice_excess_weight_charge", serviceJobDetails.CustPrice_excess_weight_charge);
                        cmd.Parameters.AddWithValue("@CustPrice_rental_day_per_container", serviceJobDetails.CustPrice_rental_day_per_container);
                        cmd.Parameters.AddWithValue("@CustPrice_demurrage_charge_per_hour", serviceJobDetails.CustPrice_demurrage_charge_per_hour);
                        cmd.Parameters.AddWithValue("@CustPrice_actual_demurrage", serviceJobDetails.CustPrice_actual_demurrage);
                        cmd.Parameters.AddWithValue("@CustPrice_consignment_note_Charge_vist", serviceJobDetails.CustPrice_consignment_note_Charge_vist);
                        cmd.Parameters.AddWithValue("@ContractorName", serviceJobDetails.ContractorName);
                        cmd.Parameters.AddWithValue("@ContractorId", serviceJobDetails.ContractorId);
                        cmd.Parameters.AddWithValue("@ContractorContact", serviceJobDetails.ContractorContact);
                        cmd.Parameters.AddWithValue("@DepotId", serviceJobDetails.DepotId);
                        cmd.Parameters.AddWithValue("@FacilityTypeId", serviceJobDetails.FacilityTypeId);
                        cmd.Parameters.AddWithValue("@FacilityId", serviceJobDetails.FacilityId);
                        cmd.Parameters.AddWithValue("@EndDestinationTypeId", serviceJobDetails.EndDestinationTypeId);
                        cmd.Parameters.AddWithValue("@EndDestination", serviceJobDetails.EndDestination);
                        cmd.Parameters.AddWithValue("@ContrPrice_Cost_per_lift", serviceJobDetails.ContrPrice_Cost_per_lift);
                        cmd.Parameters.AddWithValue("@ContrPrice_additional_charge", serviceJobDetails.ContrPrice_additional_charge);
                        cmd.Parameters.AddWithValue("@ContrPrice_additional_charge_frequency", serviceJobDetails.ContrPrice_additional_charge_frequency);
                        cmd.Parameters.AddWithValue("@ContrPrice_reason_for_additional_charge", serviceJobDetails.ContrPrice_reason_for_additional_charge);
                        cmd.Parameters.AddWithValue("@ContrPrice_transportcost", serviceJobDetails.ContrPrice_transportcost);
                        cmd.Parameters.AddWithValue("@ContrPrice_transport_per_quantity", serviceJobDetails.ContrPrice_transport_per_quantity);
                        cmd.Parameters.AddWithValue("@ContrPrice_minimum_transport_charge", serviceJobDetails.ContrPrice_minimum_transport_charge);
                        cmd.Parameters.AddWithValue("@ContrPrice_Cost_per_quantity", serviceJobDetails.ContrPrice_Cost_per_quantity);
                        cmd.Parameters.AddWithValue("@ContrPrice_QtyTypeId", serviceJobDetails.ContrPrice_QtyTypeId);
                        cmd.Parameters.AddWithValue("@ContrPrice_minimum_quantity", serviceJobDetails.ContrPrice_minimum_quantity);
                        cmd.Parameters.AddWithValue("@ContrPrice_max_quantity", serviceJobDetails.ContrPrice_max_quantity);
                        cmd.Parameters.AddWithValue("@ContrPrice_excess_weight_charge", serviceJobDetails.ContrPrice_excess_weight_charge);
                        cmd.Parameters.AddWithValue("@ContrPrice_rental_day_per_container", serviceJobDetails.ContrPrice_rental_day_per_container);
                        cmd.Parameters.AddWithValue("@ContrPrice_demurrage_charge_per_hour", serviceJobDetails.ContrPrice_demurrage_charge_per_hour);
                        cmd.Parameters.AddWithValue("@ContrPrice_actual_demurrage", serviceJobDetails.ContrPrice_actual_demurrage);
                        cmd.Parameters.AddWithValue("@ContrPrice_consignment_note_visit", serviceJobDetails.ContrPrice_consignment_note_visit);
                        cmd.Parameters.AddWithValue("@RemovalDategivenbyIncumbentContractor", serviceJobDetails.RemovalDategivenbyIncumbentContractor);
                        cmd.Parameters.AddWithValue("@ActualRemovalDategivenbyContractor", serviceJobDetails.ActualRemovalDategivenbyContractor);
                        cmd.Parameters.AddWithValue("@IncumbentContractorName", serviceJobDetails.IncumbentContractorName);
                        cmd.Parameters.AddWithValue("@IncumbentContactName", serviceJobDetails.IncumbentContactName);
                        cmd.Parameters.AddWithValue("@IncumbentTelephoneNumber", serviceJobDetails.IncumbentTelephoneNumber);
                        cmd.Parameters.AddWithValue("@MobilisationComments", serviceJobDetails.MobilisationComments);
                        cmd.Parameters.AddWithValue("@ExpectedAnnualTurnover", serviceJobDetails.ExpectedAnnualTurnover);
                        cmd.Parameters.AddWithValue("@ExpectedAnnualCoS", serviceJobDetails.ExpectedAnnualCoS);
                        cmd.Parameters.AddWithValue("@ExpectedAnnualMargin", serviceJobDetails.ExpectedAnnualMargin);
                        cmd.Parameters.AddWithValue("@Post_MobilisationAnnualTurnover", serviceJobDetails.Post_MobilisationAnnualTurnover);
                        cmd.Parameters.AddWithValue("@Post_MobilisationAnnualCoS", serviceJobDetails.Post_MobilisationAnnualCoS);
                        cmd.Parameters.AddWithValue("@Post_MobilisationAnnualMargin", serviceJobDetails.Post_MobilisationAnnualMargin);
                        cmd.Parameters.AddWithValue("@AnnualTurnoverDifference", serviceJobDetails.AnnualTurnoverDifference);
                        cmd.Parameters.AddWithValue("@AnnualCoSDifference", serviceJobDetails.AnnualCoSDifference);
                        cmd.Parameters.AddWithValue("@AnnualMarginDifference", serviceJobDetails.AnnualMarginDifference);
                        cmd.Parameters.AddWithValue("@CreatedBy", serviceJobDetails.CreatedBy);
                        //cmd.ExecuteNonQuery();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                objServiceJobDetails.JobId = string.IsNullOrEmpty(Convert.ToString(reader["JobId"])) ? 0 : Convert.ToInt32(reader["JobId"]);
                                objServiceJobDetails.ContractorId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorId"])) ? 0 : Convert.ToInt32(reader["ContractorId"]);
                            }
                        }
                    }
                }
                objServiceJobDetails.CustomerId = serviceJobDetails.CustomerId;
                objServiceJobDetails.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objServiceJobDetails.Status = Status.Failed;
                objServiceJobDetails.Message = ex.Message;
                throw ex;
            }
            return objServiceJobDetails;
        }
        public ServiceJobDetails AddNewJob(ServiceJobDetails serviceJobDetails)
        {
            ServiceJobDetails objServiceJobDetails = new ServiceJobDetails();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Service_AddNewJob";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CustomerId", serviceJobDetails.CustomerId);
                        cmd.Parameters.AddWithValue("@ServiceId", serviceJobDetails.ServiceId);
                        cmd.Parameters.AddWithValue("@Customer_SiteId", serviceJobDetails.Customer_SiteId);
                        cmd.Parameters.AddWithValue("@ServiceTypeId", serviceJobDetails.ServiceTypeId);
                        cmd.Parameters.AddWithValue("@ServiceStatusId", serviceJobDetails.ServiceStatusId);
                        cmd.Parameters.AddWithValue("@JobTypeId", serviceJobDetails.JobTypeId);
                        cmd.Parameters.AddWithValue("@WasteTypeId", serviceJobDetails.WasteTypeId);
                        cmd.Parameters.AddWithValue("@MaterialTypeId", serviceJobDetails.MaterialTypeId);
                        cmd.Parameters.AddWithValue("@EWCCode", serviceJobDetails.EWCCode);
                        cmd.Parameters.AddWithValue("@ContainerTypeId", serviceJobDetails.ContainerTypeId);
                        cmd.Parameters.AddWithValue("@ContainerSizeId", serviceJobDetails.ContainerSizeId);
                        cmd.Parameters.AddWithValue("@BagTypeId", serviceJobDetails.BagTypeId);
                        cmd.Parameters.AddWithValue("@AssumedContainerWeight", serviceJobDetails.AssumedContainerWeight);
                        cmd.Parameters.AddWithValue("@Quantity", serviceJobDetails.Quantity);
                        cmd.Parameters.AddWithValue("@FrequencyTypeId", serviceJobDetails.FrequencyTypeId);
                        cmd.Parameters.AddWithValue("@FrequencyId", serviceJobDetails.FrequencyId);
                        cmd.Parameters.AddWithValue("@VisitsPerWeek", serviceJobDetails.VisitsPerWeek);
                        cmd.Parameters.AddWithValue("@ContractorPOnumber", serviceJobDetails.ContractorPOnumber);
                        cmd.Parameters.AddWithValue("@SalesContactId", serviceJobDetails.SalesContactId);
                        cmd.Parameters.AddWithValue("@ServiceComments", serviceJobDetails.ServiceComments);
                        cmd.Parameters.AddWithValue("@InternalComments", serviceJobDetails.InternalComments);
                        cmd.Parameters.AddWithValue("@IncludeCommentInInvoice", serviceJobDetails.IncludeCommentInInvoice);
                        cmd.Parameters.AddWithValue("@WeightType", serviceJobDetails.WeightType);
                        cmd.Parameters.AddWithValue("@WeightUsage", serviceJobDetails.WeightUsage);
                        cmd.Parameters.AddWithValue("@CustomerPONumber", serviceJobDetails.Extra_CustomerPONumber);
                        cmd.Parameters.AddWithValue("@TicketNo", serviceJobDetails.Extra_TicketNo);
                        cmd.Parameters.AddWithValue("@Monday", serviceJobDetails.Extra_Monday);
                        cmd.Parameters.AddWithValue("@Tuesday", serviceJobDetails.Extra_Tuesday);
                        cmd.Parameters.AddWithValue("@Wednesday", serviceJobDetails.Extra_Wednesday);
                        cmd.Parameters.AddWithValue("@Thursday", serviceJobDetails.Extra_Thursday);
                        cmd.Parameters.AddWithValue("@Friday", serviceJobDetails.Extra_Friday);
                        cmd.Parameters.AddWithValue("@Saturday", serviceJobDetails.Extra_Saturday);
                        cmd.Parameters.AddWithValue("@Sunday", serviceJobDetails.Extra_Sunday);
                        cmd.Parameters.AddWithValue("@CustomField1", serviceJobDetails.Extra_CustomField1);
                        cmd.Parameters.AddWithValue("@CustomField2", serviceJobDetails.Extra_CustomField2);
                        cmd.Parameters.AddWithValue("@CustomField3", serviceJobDetails.Extra_CustomField3);
                        cmd.Parameters.AddWithValue("@CustomField4", serviceJobDetails.Extra_CustomField4);
                        cmd.Parameters.AddWithValue("@CustomField5", serviceJobDetails.Extra_CustomField5);
                        cmd.Parameters.AddWithValue("@Confirmation_PlannedDeliveryDate", serviceJobDetails.Confirmation_PlannedDeliveryDate);
                        cmd.Parameters.AddWithValue("@Confirmation_PeriodofDelivery", serviceJobDetails.Confirmation_PeriodofDelivery);
                        cmd.Parameters.AddWithValue("@Confirmation_ActualDateofDelivery", serviceJobDetails.Confirmation_ActualDateofDelivery);
                        cmd.Parameters.AddWithValue("@Confirmation_DeliveryFailureReason", serviceJobDetails.Confirmation_DeliveryFailureReason);
                        cmd.Parameters.AddWithValue("@Confirmation_PlannedCollectionDate", serviceJobDetails.Confirmation_PlannedCollectionDate);
                        cmd.Parameters.AddWithValue("@Confirmation_PeriodofCollection", serviceJobDetails.Confirmation_PeriodofCollection);
                        cmd.Parameters.AddWithValue("@Confirmation_ActualCollectionDate", serviceJobDetails.Confirmation_ActualCollectionDate);
                        cmd.Parameters.AddWithValue("@CustPrice_price_per_lift", serviceJobDetails.CustPrice_price_per_lift);
                        cmd.Parameters.AddWithValue("@CustPrice_additional_charge ", serviceJobDetails.CustPrice_additional_charge);
                        cmd.Parameters.AddWithValue("@CustPrice_additional_charge_frequency", serviceJobDetails.CustPrice_additional_charge_frequency);
                        cmd.Parameters.AddWithValue("@CustPrice_reason_for_additional_charge", serviceJobDetails.CustPrice_reason_for_additional_charge);
                        cmd.Parameters.AddWithValue("@CustPrice_transport", serviceJobDetails.CustPrice_transport);
                        cmd.Parameters.AddWithValue("@CustPrice_transport_per_quantity", serviceJobDetails.CustPrice_transport_per_quantity);
                        cmd.Parameters.AddWithValue("@CustPrice_minimum_transport_charge", serviceJobDetails.CustPrice_minimum_transport_charge);
                        cmd.Parameters.AddWithValue("@CustPrice_price_per_quantity", serviceJobDetails.CustPrice_price_per_quantity);
                        cmd.Parameters.AddWithValue("@CustPrice_QtyTypeId", serviceJobDetails.CustPrice_QtyTypeId);
                        cmd.Parameters.AddWithValue("@CustPrice_minimum_quantity", serviceJobDetails.CustPrice_minimum_quantity);
                        cmd.Parameters.AddWithValue("@CustPrice_max_quantity", serviceJobDetails.CustPrice_max_quantity);
                        cmd.Parameters.AddWithValue("@CustPrice_excess_weight_charge", serviceJobDetails.CustPrice_excess_weight_charge);
                        cmd.Parameters.AddWithValue("@CustPrice_rental_day_per_container", serviceJobDetails.CustPrice_rental_day_per_container);
                        cmd.Parameters.AddWithValue("@CustPrice_demurrage_charge_per_hour", serviceJobDetails.CustPrice_demurrage_charge_per_hour);
                        cmd.Parameters.AddWithValue("@CustPrice_actual_demurrage", serviceJobDetails.CustPrice_actual_demurrage);
                        cmd.Parameters.AddWithValue("@CustPrice_consignment_note_Charge_vist", serviceJobDetails.CustPrice_consignment_note_Charge_vist);
                        cmd.Parameters.AddWithValue("@ContractorName", serviceJobDetails.ContractorName);
                        cmd.Parameters.AddWithValue("@ContractorId", serviceJobDetails.ContractorId);
                        cmd.Parameters.AddWithValue("@ContractorContact", serviceJobDetails.ContractorContact);
                        cmd.Parameters.AddWithValue("@DepotId", serviceJobDetails.DepotId);
                        cmd.Parameters.AddWithValue("@FacilityTypeId", serviceJobDetails.FacilityTypeId);
                        cmd.Parameters.AddWithValue("@FacilityId", serviceJobDetails.FacilityId);
                        cmd.Parameters.AddWithValue("@EndDestinationTypeId", serviceJobDetails.EndDestinationTypeId);
                        cmd.Parameters.AddWithValue("@EndDestination", serviceJobDetails.EndDestination);
                        cmd.Parameters.AddWithValue("@ContrPrice_Cost_per_lift", serviceJobDetails.ContrPrice_Cost_per_lift);
                        cmd.Parameters.AddWithValue("@ContrPrice_additional_charge", serviceJobDetails.ContrPrice_additional_charge);
                        cmd.Parameters.AddWithValue("@ContrPrice_additional_charge_frequency", serviceJobDetails.ContrPrice_additional_charge_frequency);
                        cmd.Parameters.AddWithValue("@ContrPrice_reason_for_additional_charge", serviceJobDetails.ContrPrice_reason_for_additional_charge);
                        cmd.Parameters.AddWithValue("@ContrPrice_transportcost", serviceJobDetails.ContrPrice_transportcost);
                        cmd.Parameters.AddWithValue("@ContrPrice_transport_per_quantity", serviceJobDetails.ContrPrice_transport_per_quantity);
                        cmd.Parameters.AddWithValue("@ContrPrice_minimum_transport_charge", serviceJobDetails.ContrPrice_minimum_transport_charge);
                        cmd.Parameters.AddWithValue("@ContrPrice_Cost_per_quantity", serviceJobDetails.ContrPrice_Cost_per_quantity);
                        cmd.Parameters.AddWithValue("@ContrPrice_QtyTypeId", serviceJobDetails.ContrPrice_QtyTypeId);
                        cmd.Parameters.AddWithValue("@ContrPrice_minimum_quantity", serviceJobDetails.ContrPrice_minimum_quantity);
                        cmd.Parameters.AddWithValue("@ContrPrice_max_quantity", serviceJobDetails.ContrPrice_max_quantity);
                        cmd.Parameters.AddWithValue("@ContrPrice_excess_weight_charge", serviceJobDetails.ContrPrice_excess_weight_charge);
                        cmd.Parameters.AddWithValue("@ContrPrice_rental_day_per_container", serviceJobDetails.ContrPrice_rental_day_per_container);
                        cmd.Parameters.AddWithValue("@ContrPrice_demurrage_charge_per_hour", serviceJobDetails.ContrPrice_demurrage_charge_per_hour);
                        cmd.Parameters.AddWithValue("@ContrPrice_actual_demurrage", serviceJobDetails.ContrPrice_actual_demurrage);
                        cmd.Parameters.AddWithValue("@ContrPrice_consignment_note_visit", serviceJobDetails.ContrPrice_consignment_note_visit);
                        cmd.Parameters.AddWithValue("@CreatedBy", serviceJobDetails.CreatedBy);
                        //cmd.ExecuteNonQuery();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                objServiceJobDetails.JobId = string.IsNullOrEmpty(Convert.ToString(reader["JobId"])) ? 0 : Convert.ToInt32(reader["JobId"]);
                                objServiceJobDetails.ContractorId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorId"])) ? 0 : Convert.ToInt32(reader["ContractorId"]);
                            }
                        }
                    }
                }
                objServiceJobDetails.CustomerId = serviceJobDetails.CustomerId;
                objServiceJobDetails.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objServiceJobDetails.Status = Status.Failed;
                objServiceJobDetails.Message = ex.Message;
                throw ex;
            }
            return objServiceJobDetails;
        }
        public ServiceJobDetails UpdateJobConfirmation(ServiceJobDetails serviceJobDetails)
        {
            ServiceJobDetails objServiceJobDetails = new ServiceJobDetails();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Service_UpdateJobConfirmation";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@JobId", serviceJobDetails.JobId);
                        cmd.Parameters.AddWithValue("@Confirmation_PlannedDeliveryDate", serviceJobDetails.Confirmation_PlannedDeliveryDate);
                        cmd.Parameters.AddWithValue("@Confirmation_PeriodofDelivery", serviceJobDetails.Confirmation_PeriodofDelivery);
                        cmd.Parameters.AddWithValue("@Confirmation_ActualDateofDelivery", serviceJobDetails.Confirmation_ActualDateofDelivery);
                        cmd.Parameters.AddWithValue("@Confirmation_DeliveryFailureReason", serviceJobDetails.Confirmation_DeliveryFailureReason);
                        cmd.Parameters.AddWithValue("@Confirmation_PlannedCollectionDate", serviceJobDetails.Confirmation_PlannedCollectionDate);
                        cmd.Parameters.AddWithValue("@Confirmation_PeriodofCollection", serviceJobDetails.Confirmation_PeriodofCollection);
                        cmd.Parameters.AddWithValue("@Confirmation_ActualCollectionDate", serviceJobDetails.Confirmation_ActualCollectionDate);
                        cmd.Parameters.AddWithValue("@IsConfirmed", serviceJobDetails.IsConfirmed);
                        cmd.Parameters.AddWithValue("@IsCancelled", serviceJobDetails.IsCancelled);
                        cmd.Parameters.AddWithValue("@JobConfirmedBy", serviceJobDetails.JobConfirmedBy);
                        cmd.Parameters.AddWithValue("@CreatedBy", serviceJobDetails.CreatedBy);

                        cmd.ExecuteNonQuery();
                    }
                }
                objServiceJobDetails.JobId = serviceJobDetails.JobId;
                objServiceJobDetails.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objServiceJobDetails.Status = Status.Failed;
                objServiceJobDetails.Message = ex.Message;
                throw ex;
            }
            return objServiceJobDetails;
        }
        public ServiceInfo GetAllServiceSitesByCustomer(CustomerBasicInfo customerBasicInfo)
        {
            ServiceInfo serviceInfo = new ServiceInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ServiceSite> lstEntity = new List<ServiceSite>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Service_GetAllSitesByCustomer]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CustomerId", customerBasicInfo.CustomerId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ServiceSite objEntity = new ServiceSite();
                                objEntity.Customer_SiteId = string.IsNullOrEmpty(Convert.ToString(reader["Customer_SiteId"])) ? 0 : Convert.ToInt32(reader["Customer_SiteId"]);
                                objEntity.SiteCode = Convert.ToString(reader["SiteCode"]);
                                objEntity.SiteName = Convert.ToString(reader["SiteName"]);
                                objEntity.Postcode = Convert.ToString(reader["Postcode"]);
                                objEntity.Address = Convert.ToString(reader["Address"]);
                                objEntity.GeneralWaste = string.IsNullOrEmpty(Convert.ToString(reader["GeneralWaste"])) ? 0 : Convert.ToInt32(reader["GeneralWaste"]);
                                objEntity.CapitalWaste = string.IsNullOrEmpty(Convert.ToString(reader["CapitalWaste"])) ? 0 : Convert.ToInt32(reader["CapitalWaste"]);
                                objEntity.HazardousWaste = string.IsNullOrEmpty(Convert.ToString(reader["HazardousWaste"])) ? 0 : Convert.ToInt32(reader["HazardousWaste"]);
                                objEntity.RecyclingWaste = string.IsNullOrEmpty(Convert.ToString(reader["RecyclingWaste"])) ? 0 : Convert.ToInt32(reader["RecyclingWaste"]);
                                objEntity.WashroomWaste = string.IsNullOrEmpty(Convert.ToString(reader["WashroomWaste"])) ? 0 : Convert.ToInt32(reader["WashroomWaste"]);
                                objEntity.ActiveServices = string.IsNullOrEmpty(Convert.ToString(reader["ActiveServices"])) ? 0 : Convert.ToInt32(reader["ActiveServices"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    serviceInfo.lstServiceSites = lstEntity;
                }
                serviceInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                serviceInfo.Status = Status.Failed;
                serviceInfo.Message = ex.Message;
            }
            return serviceInfo;
        }

        public ServiceInfo GetServiceSitesByAccountId(AccountInfo accountInfo)
        {
            ServiceInfo serviceInfo = new ServiceInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ServiceSite> lstEntity = new List<ServiceSite>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Service_GetSitesByAccountId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AccountId", accountInfo.AccountId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ServiceSite objEntity = new ServiceSite();
                                objEntity.Customer_SiteId = string.IsNullOrEmpty(Convert.ToString(reader["Customer_SiteId"])) ? 0 : Convert.ToInt32(reader["Customer_SiteId"]);
                                objEntity.SiteCode = Convert.ToString(reader["SiteCode"]);
                                objEntity.SiteName = Convert.ToString(reader["SiteName"]);
                                objEntity.Postcode = Convert.ToString(reader["Postcode"]);
                                objEntity.Address = Convert.ToString(reader["Address"]);
                                objEntity.GeneralWaste = string.IsNullOrEmpty(Convert.ToString(reader["GeneralWaste"])) ? 0 : Convert.ToInt32(reader["GeneralWaste"]);
                                objEntity.CapitalWaste = string.IsNullOrEmpty(Convert.ToString(reader["CapitalWaste"])) ? 0 : Convert.ToInt32(reader["CapitalWaste"]);
                                objEntity.HazardousWaste = string.IsNullOrEmpty(Convert.ToString(reader["HazardousWaste"])) ? 0 : Convert.ToInt32(reader["HazardousWaste"]);
                                objEntity.RecyclingWaste = string.IsNullOrEmpty(Convert.ToString(reader["RecyclingWaste"])) ? 0 : Convert.ToInt32(reader["RecyclingWaste"]);
                                objEntity.WashroomWaste = string.IsNullOrEmpty(Convert.ToString(reader["WashroomWaste"])) ? 0 : Convert.ToInt32(reader["WashroomWaste"]);
                                objEntity.ActiveServices = string.IsNullOrEmpty(Convert.ToString(reader["ActiveServices"])) ? 0 : Convert.ToInt32(reader["ActiveServices"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    serviceInfo.lstServiceSites = lstEntity;
                }
                serviceInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                serviceInfo.Status = Status.Failed;
                serviceInfo.Message = ex.Message;
            }
            return serviceInfo;
        }
        public ServiceJobDetails GetServiceReportServiceTracker()
        {
            ServiceJobDetails serviceJobDetails = new ServiceJobDetails();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ServiceJobDetails> lstEntity = new List<ServiceJobDetails>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Service_Report_ServiceTracker]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ServiceJobDetails objEntity = new ServiceJobDetails();
                                objEntity.JobId = string.IsNullOrEmpty(Convert.ToString(reader["JobId"])) ? 0 : Convert.ToInt32(reader["JobId"]);
                                objEntity.ServiceId = string.IsNullOrEmpty(Convert.ToString(reader["ServiceId"])) ? 0 : Convert.ToInt32(reader["ServiceId"]);
                                objEntity.ServiceStatusId = string.IsNullOrEmpty(Convert.ToString(reader["ServiceStatusId"])) ? 0 : Convert.ToInt32(reader["ServiceStatusId"]);
                                objEntity.ServiceStatusName = Convert.ToString(reader["ServiceStatusName"]);
                                objEntity.ContractorId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorId"])) ? 0 : Convert.ToInt32(reader["ContractorId"]);
                                //objEntity.JobTypeName = Convert.ToString(reader["JobTypeName"]);
                                objEntity.ServiceTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ServiceTypeId"])) ? 0 : Convert.ToInt32(reader["ServiceTypeId"]);
                                objEntity.ServiceTypeName = Convert.ToString(reader["ServiceTypeName"]);
                                objEntity.CustomerName = Convert.ToString(reader["CustomerName"]);
                                objEntity.AccountName = Convert.ToString(reader["AccountName"]);
                                objEntity.AccountNumber = Convert.ToString(reader["AccountNumber"]);
                                objEntity.SiteCode = Convert.ToString(reader["SiteCode"]);
                                objEntity.SiteName = Convert.ToString(reader["SiteName"]);
                                objEntity.ContractorName = Convert.ToString(reader["ContractorName"]);
                                objEntity.Address = Convert.ToString(reader["Address"]);
                                objEntity.Postcode = Convert.ToString(reader["Postcode"]);
                                objEntity.WasteTypeId = string.IsNullOrEmpty(Convert.ToString(reader["WasteTypeId"])) ? 0 : Convert.ToInt32(reader["WasteTypeId"]);
                                objEntity.WasteType_Name = Convert.ToString(reader["WasteType_Name"]);
                                objEntity.MaterialType_Name = Convert.ToString(reader["MaterialType_Name"]);
                                objEntity.ContainerType_Name = Convert.ToString(reader["ContainerType_Name"]);
                                objEntity.ContainerSize_Name = Convert.ToString(reader["ContainerSize_Name"]);
                                objEntity.VisitsPerWeek = Convert.ToString(reader["VisitsPerWeek"]);
                                objEntity.ContractorName = Convert.ToString(reader["ContractorName"]);
                                objEntity.Confirmation_ActualDateofDelivery = string.IsNullOrEmpty(Convert.ToString(reader["DeliveryDate"])) ? (DateTime?)null : Convert.ToDateTime(reader["DeliveryDate"]);
                                objEntity.Confirmation_ActualCollectionDate = string.IsNullOrEmpty(Convert.ToString(reader["CollectionDate"])) ? (DateTime?)null : Convert.ToDateTime(reader["CollectionDate"]);
                                objEntity.MaterialTypeId = string.IsNullOrEmpty(Convert.ToString(reader["MaterialTypeId"])) ? 0 : Convert.ToInt32(reader["MaterialTypeId"]);
                                objEntity.ContainerTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ContainerTypeId"])) ? 0 : Convert.ToInt32(reader["ContainerTypeId"]);
                                objEntity.ContainerSizeId = string.IsNullOrEmpty(Convert.ToString(reader["ContainerSizeId"])) ? 0 : Convert.ToInt32(reader["ContainerSizeId"]);
                                objEntity.Customer_SiteId = string.IsNullOrEmpty(Convert.ToString(reader["Customer_SiteId"])) ? 0 : Convert.ToInt32(reader["Customer_SiteId"]);
                                objEntity.WeightType = Convert.ToString(reader["WeightType"]);
                                objEntity.AccountId = string.IsNullOrEmpty(Convert.ToString(reader["AccountId"])) ? 0 : Convert.ToInt32(reader["AccountId"]);
                                objEntity.Confirmation_DeliveryFailureReason = string.IsNullOrEmpty(Convert.ToString(reader["Confirmation_DeliveryFailureReason"])) ? 0 : Convert.ToInt32(reader["Confirmation_DeliveryFailureReason"]);
                                objEntity.CustomerId = string.IsNullOrEmpty(Convert.ToString(reader["CustomerId"])) ? 0 : Convert.ToInt32(reader["CustomerId"]);
                                objEntity.ContractorPOnumber = Convert.ToString(reader["ContractorPOnumber"]);
                                objEntity.JobTypeName = Convert.ToString(reader["JobTypeName"]);
                                objEntity.EWCCode = Convert.ToString(reader["EWCCode"]);
                                objEntity.Quantity = string.IsNullOrEmpty(Convert.ToString(reader["Quantity"])) ? (int?)null : Convert.ToInt32(reader["Quantity"]);
                                objEntity.ActualWeight = string.IsNullOrEmpty(Convert.ToString(reader["ActualWeight"])) ? (decimal?)null : Convert.ToDecimal(reader["ActualWeight"]);
                                objEntity.AssumedContainerWeight = string.IsNullOrEmpty(Convert.ToString(reader["AssumedContainerWeight"])) ? (decimal?)null : Convert.ToDecimal(reader["AssumedContainerWeight"]);


                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    serviceJobDetails.lstServiceReportServiceTracker = lstEntity;
                }
                serviceJobDetails.Status = Status.Success;
            }
            catch (Exception ex)
            {
                serviceJobDetails.Status = Status.Failed;
                serviceJobDetails.Message = ex.Message;
            }
            return serviceJobDetails;
        }

        public SettingUp GetProcessAccountDetails(ApprovedPricingSolution approvedPricingSolution)
        {
            SettingUp settingUp = new SettingUp();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("[dbo].[SP_ServiceSetup_ProcessAccountDetails]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ApprovedPricingId", approvedPricingSolution.Id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                settingUp.ReturnId = Convert.ToInt32(reader["ReturnId"]);
                                settingUp.ReturnMsg = Convert.ToString(reader["ReturnMsg"]);

                            }
                        }

                    };
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return settingUp;
        }

        public SettingUp GetProcessSiteDetails(ApprovedPricingSolution approvedPricingSolution)
        {
            SettingUp settingUp = new SettingUp();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("[dbo].[SP_ServiceSetup_ProcessSiteDetails]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ApprovedPricingId", approvedPricingSolution.Id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                settingUp.ReturnId = Convert.ToInt32(reader["ReturnId"]);
                                settingUp.ReturnMsg = Convert.ToString(reader["ReturnMsg"]);

                            }
                        }

                    };
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return settingUp;
        }

        public SettingUp GetProcessContactDetails(ApprovedPricingSolution approvedPricingSolution)
        {
            SettingUp settingUp = new SettingUp();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("[dbo].[SP_ServiceSetup_ProcessContactDetails]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ApprovedPricingId", approvedPricingSolution.Id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                settingUp.ReturnId = Convert.ToInt32(reader["ReturnId"]);
                                settingUp.ReturnMsg = Convert.ToString(reader["ReturnMsg"]);

                            }
                        }

                    };
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return settingUp;

        }

        public SettingUp GetProcessServiceDetails(ApprovedPricingSolution approvedPricingSolution)
        {
            SettingUp settingUp = new SettingUp();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("[dbo].[SP_ServiceSetup_ProcessServiceDetails]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ApprovedPricingId", approvedPricingSolution.Id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                settingUp.ReturnId = Convert.ToInt32(reader["ReturnId"]);
                                settingUp.ReturnMsg = Convert.ToString(reader["ReturnMsg"]);

                            }
                        }

                    };
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return settingUp;

        }

        public SettingUp GetCreateServices(ApprovedPricingSolution approvedPricingSolution)
        {
            SettingUp settingUp = new SettingUp();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("[dbo].[SP_ServiceSetup_CreateService]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ApprovedPricingId", approvedPricingSolution.Id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                settingUp.ReturnId = Convert.ToInt32(reader["ReturnId"]);
                                settingUp.ReturnMsg = Convert.ToString(reader["ReturnMsg"]);
                            }
                        }
                    };
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return settingUp;
        }

        public ServiceInfo GetOrderEmailTemplate()
        {
            ServiceInfo serviceInfo = new ServiceInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<OrderEmailTemplate> lstEntity = new List<OrderEmailTemplate>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Service_GetOrderEmailTemplate]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                OrderEmailTemplate objEntity = new OrderEmailTemplate();
                                objEntity.Id = string.IsNullOrEmpty(Convert.ToString(reader["Id"])) ? 0 : Convert.ToInt32(reader["Id"]);
                                objEntity.Key = Convert.ToString(reader["Key"]);
                                objEntity.Value = Convert.ToString(reader["Value"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    serviceInfo.lstOrderEmailTemplates = lstEntity;
                }
                serviceInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                serviceInfo.Status = Status.Failed;
                serviceInfo.Message = ex.Message;
            }
            return serviceInfo;
        }
        public ServiceOrderDetails CreateNewOrder(ServiceOrderDetails serviceOrderDetails)
        {
            ServiceOrderDetails objServiceOrderDetails = new ServiceOrderDetails();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Service_CreateNewOrder";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@JobId", serviceOrderDetails.JobId);
                        cmd.Parameters.AddWithValue("@ContractorId", serviceOrderDetails.ContractorId);
                        cmd.Parameters.AddWithValue("@SiteId", serviceOrderDetails.SiteId);
                        cmd.Parameters.AddWithValue("@CreatedBy", serviceOrderDetails.CreatedBy);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                objServiceOrderDetails.OrderId = string.IsNullOrEmpty(Convert.ToString(reader["OrderId"])) ? 0 : Convert.ToInt32(reader["OrderId"]);
                                objServiceOrderDetails.OrderTypeId = string.IsNullOrEmpty(Convert.ToString(reader["OrderTypeId"])) ? 0 : Convert.ToInt32(reader["OrderTypeId"]);
                            }
                        }
                    }
                }
                objServiceOrderDetails.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objServiceOrderDetails.Status = Status.Failed;
                objServiceOrderDetails.Message = ex.Message;
                throw ex;
            }
            return objServiceOrderDetails;
        }
        public ServiceOrderDetails GetDetailsforSingleOrder(ServiceOrderDetails serviceOrderDetails)
        {
            ServiceOrderDetails objServiceOrderDetails = new ServiceOrderDetails();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Order_GetDetailsforSingleOrder";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@OrderId", serviceOrderDetails.OrderId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                objServiceOrderDetails.OrderType = Convert.ToString(reader["OrderType"]);
                                objServiceOrderDetails.TodayDate = string.IsNullOrEmpty(Convert.ToString(reader["TodayDate"])) ? new DateTime() : Convert.ToDateTime(reader["TodayDate"]);
                                objServiceOrderDetails.CompanyName = Convert.ToString(reader["CompanyName"]);
                                objServiceOrderDetails.JobTypeName = Convert.ToString(reader["JobTypeName"]);
                                objServiceOrderDetails.AttentionOf = Convert.ToString(reader["AttentionOf"]);
                                objServiceOrderDetails.CompanyEmail = Convert.ToString(reader["CompanyEmail"]);
                                objServiceOrderDetails.CompanyPhoneNumber = Convert.ToString(reader["CompanyPhoneNumber"]);
                                objServiceOrderDetails.ContractorId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorId"])) ? 0 : Convert.ToInt32(reader["ContractorId"]);

                            }
                            reader.NextResult();
                            while (reader.Read())
                            {
                                objServiceOrderDetails.ContractorPONumber = Convert.ToString(reader["ContractorPONumber"]);
                                objServiceOrderDetails.BusinessName = Convert.ToString(reader["BusinessName"]);
                                objServiceOrderDetails.CompanySICCode = Convert.ToString(reader["CompanySICCode"]);
                                objServiceOrderDetails.SiteName = Convert.ToString(reader["SiteName"]);
                                objServiceOrderDetails.AddressLine1 = Convert.ToString(reader["AddressLine1"]);
                                objServiceOrderDetails.AddressLine2 = Convert.ToString(reader["AddressLine2"]);
                                objServiceOrderDetails.Town = Convert.ToString(reader["Town"]);
                                objServiceOrderDetails.County = Convert.ToString(reader["County"]);
                                objServiceOrderDetails.Postcode = Convert.ToString(reader["Postcode"]);
                                objServiceOrderDetails.SiteContactName = Convert.ToString(reader["SiteContactName"]);
                                objServiceOrderDetails.SiteContactTelephone = Convert.ToString(reader["SiteContactTelephone"]);
                                objServiceOrderDetails.AccessComments = Convert.ToString(reader["AccessComments"]);
                                objServiceOrderDetails.ActionDate = string.IsNullOrEmpty(Convert.ToString(reader["ActionDate"])) ? new DateTime() : Convert.ToDateTime(reader["ActionDate"]);
                                objServiceOrderDetails.MaterialType_Name = Convert.ToString(reader["MaterialType_Name"]);
                                objServiceOrderDetails.EWCCode = Convert.ToString(reader["EWCCode"]);
                                objServiceOrderDetails.ContainerType_Name = Convert.ToString(reader["ContainerType_Name"]);
                                objServiceOrderDetails.ContainerSize_Name = Convert.ToString(reader["ContainerSize_Name"]);
                                objServiceOrderDetails.Quantity = string.IsNullOrEmpty(Convert.ToString(reader["Quantity"])) ? 0 : Convert.ToInt32(reader["Quantity"]);
                                objServiceOrderDetails.Frequency_Name = Convert.ToString(reader["Frequency_Name"]);
                                objServiceOrderDetails.PricePerlift = string.IsNullOrEmpty(Convert.ToString(reader["PricePerlift"])) ? 0 : Convert.ToDecimal(reader["PricePerlift"]);
                                objServiceOrderDetails.Transport = string.IsNullOrEmpty(Convert.ToString(reader["Transport"])) ? 0 : Convert.ToDecimal(reader["Transport"]);
                                objServiceOrderDetails.QuantityType = Convert.ToString(reader["QuantityType"]);
                                objServiceOrderDetails.PricePerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["PricePerQuantity"])) ? 0 : Convert.ToDecimal(reader["PricePerQuantity"]);
                                objServiceOrderDetails.RentalPerDay = string.IsNullOrEmpty(Convert.ToString(reader["RentalPerDay"])) ? 0 : Convert.ToDecimal(reader["RentalPerDay"]);
                            }
                        }
                    }
                }
                objServiceOrderDetails.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objServiceOrderDetails.Status = Status.Failed;
                objServiceOrderDetails.Message = ex.Message;
                throw ex;
            }
            return objServiceOrderDetails;
        }

        public ServiceOrderDetails GetDetailsforAmendmentOrder(ServiceOrderDetails serviceOrderDetails)
        {
            ServiceOrderDetails objServiceOrderDetails = new ServiceOrderDetails();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Order_GetDetailsforAmendmentOrder";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@OrderId", serviceOrderDetails.OrderId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                objServiceOrderDetails.OrderType = Convert.ToString(reader["OrderType"]);
                                objServiceOrderDetails.TodayDate = string.IsNullOrEmpty(Convert.ToString(reader["TodayDate"])) ? new DateTime() : Convert.ToDateTime(reader["TodayDate"]);
                                objServiceOrderDetails.CompanyName = Convert.ToString(reader["CompanyName"]);
                                objServiceOrderDetails.JobTypeName = Convert.ToString(reader["JobTypeName"]);
                                objServiceOrderDetails.AttentionOf = Convert.ToString(reader["AttentionOf"]);
                                objServiceOrderDetails.CompanyEmail = Convert.ToString(reader["CompanyEmail"]);
                                objServiceOrderDetails.CompanyPhoneNumber = Convert.ToString(reader["CompanyPhoneNumber"]);
                                objServiceOrderDetails.ContractorId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorId"])) ? 0 : Convert.ToInt32(reader["ContractorId"]);
                            }
                            reader.NextResult();
                            while (reader.Read())
                            {
                                objServiceOrderDetails.ContractorPONumber = Convert.ToString(reader["ContractorPONumber"]);
                                objServiceOrderDetails.BusinessName = Convert.ToString(reader["BusinessName"]);
                                objServiceOrderDetails.CompanySICCode = Convert.ToString(reader["CompanySICCode"]);
                                objServiceOrderDetails.SiteName = Convert.ToString(reader["SiteName"]);
                                objServiceOrderDetails.AddressLine1 = Convert.ToString(reader["AddressLine1"]);
                                objServiceOrderDetails.AddressLine2 = Convert.ToString(reader["AddressLine2"]);
                                objServiceOrderDetails.Town = Convert.ToString(reader["Town"]);
                                objServiceOrderDetails.County = Convert.ToString(reader["County"]);
                                objServiceOrderDetails.Postcode = Convert.ToString(reader["Postcode"]);
                                objServiceOrderDetails.SiteContactName = Convert.ToString(reader["SiteContactName"]);
                                objServiceOrderDetails.SiteContactTelephone = Convert.ToString(reader["SiteContactTelephone"]);
                                objServiceOrderDetails.AccessComments = Convert.ToString(reader["AccessComments"]);
                            }
                            objServiceOrderDetails.CurrentServiceDetails = new ServiceDetails();
                            reader.NextResult();
                            while (reader.Read())
                            {
                                objServiceOrderDetails.CurrentServiceDetails.MaterialType = Convert.ToString(reader["MaterialType"]);
                                objServiceOrderDetails.CurrentServiceDetails.EWCCode = Convert.ToString(reader["EWCCode"]);
                                objServiceOrderDetails.CurrentServiceDetails.ContainerType = Convert.ToString(reader["ContainerType"]);
                                objServiceOrderDetails.CurrentServiceDetails.ContainerSize = Convert.ToString(reader["ContainerSize"]);
                                objServiceOrderDetails.CurrentServiceDetails.Quantity = string.IsNullOrEmpty(Convert.ToString(reader["Quantity"])) ? 0 : Convert.ToInt32(reader["Quantity"]);
                                objServiceOrderDetails.CurrentServiceDetails.PricePerLift = string.IsNullOrEmpty(Convert.ToString(reader["PricePerlift"])) ? 0 : Convert.ToDecimal(reader["PricePerlift"]);
                                objServiceOrderDetails.CurrentServiceDetails.VisitsperWeek = Convert.ToString(reader["VisitsperWeek"]);
                            }
                            objServiceOrderDetails.NewServiceDetails = new ServiceDetails();
                            reader.NextResult();
                            while (reader.Read())
                            {
                                objServiceOrderDetails.NewServiceDetails.MaterialType = Convert.ToString(reader["MaterialType"]);
                                objServiceOrderDetails.NewServiceDetails.EWCCode = Convert.ToString(reader["EWCCode"]);
                                objServiceOrderDetails.NewServiceDetails.ContainerType = Convert.ToString(reader["ContainerType"]);
                                objServiceOrderDetails.NewServiceDetails.ContainerSize = Convert.ToString(reader["ContainerSize"]);
                                objServiceOrderDetails.NewServiceDetails.Quantity = string.IsNullOrEmpty(Convert.ToString(reader["Quantity"])) ? 0 : Convert.ToInt32(reader["Quantity"]);
                                objServiceOrderDetails.NewServiceDetails.PricePerLift = string.IsNullOrEmpty(Convert.ToString(reader["PricePerlift"])) ? 0 : Convert.ToDecimal(reader["PricePerlift"]);
                                objServiceOrderDetails.NewServiceDetails.VisitsperWeek = Convert.ToString(reader["VisitsperWeek"]);
                            }
                        }
                    }
                }
                objServiceOrderDetails.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objServiceOrderDetails.Status = Status.Failed;
                objServiceOrderDetails.Message = ex.Message;
                throw ex;
            }
            return objServiceOrderDetails;
        }

        public ServiceOrderDetails GetDetailsforMultipleOrder(ServiceOrderDetails serviceOrderDetails)
        {
            ServiceOrderDetails objServiceOrderDetails = new ServiceOrderDetails();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Order_GetDetailsforMultipleOrder";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", serviceOrderDetails.ContractorId);
                        cmd.Parameters.AddWithValue("@CreatedBy", serviceOrderDetails.CreatedBy);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                objServiceOrderDetails.OrderType = Convert.ToString(reader["OrderType"]);
                                objServiceOrderDetails.TodayDate = string.IsNullOrEmpty(Convert.ToString(reader["TodayDate"])) ? new DateTime() : Convert.ToDateTime(reader["TodayDate"]);
                                objServiceOrderDetails.CompanyName = Convert.ToString(reader["CompanyName"]);
                                objServiceOrderDetails.AttentionOf = Convert.ToString(reader["AttentionOf"]);
                                objServiceOrderDetails.CompanyEmail = Convert.ToString(reader["CompanyEmail"]);
                                objServiceOrderDetails.CompanyPhoneNumber = Convert.ToString(reader["CompanyPhoneNumber"]);
                            }
                            reader.NextResult();
                            while (reader.Read())
                            {
                                objServiceOrderDetails.ContractorPONumber = Convert.ToString(reader["ContractorPONumber"]);
                                objServiceOrderDetails.BusinessName = Convert.ToString(reader["BusinessName"]);
                                objServiceOrderDetails.CompanySICCode = Convert.ToString(reader["CompanySICCode"]);
                                objServiceOrderDetails.SiteName = Convert.ToString(reader["SiteName"]);
                                objServiceOrderDetails.AddressLine1 = Convert.ToString(reader["AddressLine1"]);
                                objServiceOrderDetails.AddressLine2 = Convert.ToString(reader["AddressLine2"]);
                                objServiceOrderDetails.Town = Convert.ToString(reader["Town"]);
                                objServiceOrderDetails.County = Convert.ToString(reader["County"]);
                                objServiceOrderDetails.Postcode = Convert.ToString(reader["Postcode"]);
                                objServiceOrderDetails.SiteContactName = Convert.ToString(reader["SiteContactName"]);
                                objServiceOrderDetails.SiteContactTelephone = Convert.ToString(reader["SiteContactTelephone"]);
                                objServiceOrderDetails.AccessComments = Convert.ToString(reader["AccessComments"]);
                            }
                            objServiceOrderDetails.lstServiceOrderDetails = new List<ServiceOrderDetails>();
                            reader.NextResult();
                            while (reader.Read())
                            {
                                ServiceOrderDetails entity = new ServiceOrderDetails();
                                entity.OrderId = string.IsNullOrEmpty(Convert.ToString(reader["OrderId"])) ? 0 : Convert.ToInt32(reader["OrderId"]);
                                entity.ActionDate = string.IsNullOrEmpty(Convert.ToString(reader["ActionDate"])) ? new DateTime() : Convert.ToDateTime(reader["ActionDate"]);
                                entity.MaterialType_Name = Convert.ToString(reader["MaterialType_Name"]);
                                entity.EWCCode = Convert.ToString(reader["EWCCode"]);
                                entity.ContainerType_Name = Convert.ToString(reader["ContainerType_Name"]);
                                entity.ContainerSize_Name = Convert.ToString(reader["ContainerSize_Name"]);
                                entity.Quantity = string.IsNullOrEmpty(Convert.ToString(reader["Quantity"])) ? 0 : Convert.ToInt32(reader["Quantity"]);
                                entity.VisitsPerWeek = Convert.ToString(reader["VisitsPerWeek"]);
                                entity.PricePerlift = string.IsNullOrEmpty(Convert.ToString(reader["PricePerlift"])) ? 0 : Convert.ToDecimal(reader["PricePerlift"]);
                                entity.AdditionalCharge = string.IsNullOrEmpty(Convert.ToString(reader["AdditionalCharge"])) ? 0 : Convert.ToDecimal(reader["AdditionalCharge"]);
                                entity.ChargeReason = Convert.ToString(reader["ChargeReason"]);
                                objServiceOrderDetails.lstServiceOrderDetails.Add(entity);
                            }
                        }
                    }
                }
                objServiceOrderDetails.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objServiceOrderDetails.Status = Status.Failed;
                objServiceOrderDetails.Message = ex.Message;
                throw ex;
            }
            return objServiceOrderDetails;
        }
        public ServiceOrderDetails ClearMultipleOrder(ServiceOrderDetails serviceOrderDetails)
        {
            ServiceOrderDetails objServiceOrderDetails = new ServiceOrderDetails();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Order_ClearMultipleOrder";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", serviceOrderDetails.ContractorId);
                        cmd.Parameters.AddWithValue("@CreatedBy", serviceOrderDetails.CreatedBy);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                objServiceOrderDetails.ReturnId = string.IsNullOrEmpty(Convert.ToString(reader["ReturnId"])) ? 0 : Convert.ToInt32(reader["ReturnId"]);
                                objServiceOrderDetails.Message = Convert.ToString(reader["ReturnMsg"]);
                            }
                        }
                    }
                }
                objServiceOrderDetails.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objServiceOrderDetails.Status = Status.Failed;
                objServiceOrderDetails.Message = ex.Message;
                throw ex;
            }
            return objServiceOrderDetails;
        }

        public ServiceOrderDetails CreateMultipleOrder(ServiceOrderDetails serviceOrderDetails)
        {
            ServiceOrderDetails objServiceOrderDetails = new ServiceOrderDetails();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Service_CreateMultipleOrder";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", serviceOrderDetails.ContractorId);
                        cmd.Parameters.AddWithValue("@JobId", serviceOrderDetails.JobId);
                        cmd.Parameters.AddWithValue("@SiteId", serviceOrderDetails.SiteId);
                        cmd.Parameters.AddWithValue("@CreatedBy", serviceOrderDetails.CreatedBy);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                objServiceOrderDetails.ReturnId = string.IsNullOrEmpty(Convert.ToString(reader["ReturnId"])) ? 0 : Convert.ToInt32(reader["ReturnId"]);
                                objServiceOrderDetails.Message = Convert.ToString(reader["ReturnMsg"]);
                            }
                        }
                    }
                }
                objServiceOrderDetails.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objServiceOrderDetails.Status = Status.Failed;
                objServiceOrderDetails.Message = ex.Message;
                throw ex;
            }
            return objServiceOrderDetails;
        }
        public ServiceOrderDetails GetMyOrderDetails(ServiceOrderDetails serviceOrderDetails)
        {
            ServiceOrderDetails objServiceOrderDetails = new ServiceOrderDetails();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Order_GetMyOrderDetails";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CreatedBy", serviceOrderDetails.CreatedBy);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                objServiceOrderDetails.ContractorName = Convert.ToString(reader["ContractorName"]);
                                objServiceOrderDetails.ContractorId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorId"])) ? 0 : Convert.ToInt32(reader["ContractorId"]);
                            }
                            objServiceOrderDetails.lstServiceOrderDetails = new List<ServiceOrderDetails>();
                            reader.NextResult();
                            while (reader.Read())
                            {
                                ServiceOrderDetails entity = new ServiceOrderDetails();
                                entity.OrderId = string.IsNullOrEmpty(Convert.ToString(reader["OrderId"])) ? 0 : Convert.ToInt32(reader["OrderId"]);
                                entity.JobId = string.IsNullOrEmpty(Convert.ToString(reader["JobId"])) ? 0 : Convert.ToInt32(reader["JobId"]);
                                entity.ServiceStatusId = string.IsNullOrEmpty(Convert.ToString(reader["ServiceStatusId"])) ? 0 : Convert.ToInt32(reader["ServiceStatusId"]);
                                entity.ServiceStatusName = Convert.ToString(reader["ServiceStatusName"]);
                                entity.JobTypeName = Convert.ToString(reader["JobTypeName"]);
                                entity.ContractorPONumber = Convert.ToString(reader["ContractorPONumber"]);
                                entity.ServiceTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ServiceTypeId"])) ? 0 : Convert.ToInt32(reader["ServiceTypeId"]);
                                entity.ServiceTypeName = Convert.ToString(reader["ServiceTypeName"]);
                                entity.WasteTypeId = string.IsNullOrEmpty(Convert.ToString(reader["WasteTypeId"])) ? 0 : Convert.ToInt32(reader["WasteTypeId"]);
                                entity.WasteType_Name = Convert.ToString(reader["WasteType_Name"]);
                                entity.MaterialType_Name = Convert.ToString(reader["MaterialType_Name"]);
                                entity.ContainerType_Name = Convert.ToString(reader["ContainerType_Name"]);
                                entity.ContainerSize_Name = Convert.ToString(reader["ContainerSize_Name"]);
                                entity.Quantity = string.IsNullOrEmpty(Convert.ToString(reader["Quantity"])) ? 0 : Convert.ToInt32(reader["Quantity"]);
                                entity.VisitsPerWeek = Convert.ToString(reader["VisitsPerWeek"]);
                                entity.Confirmation_ActualDateOfDelivery = string.IsNullOrEmpty(Convert.ToString(reader["Confirmation_ActualDateOfDelivery"])) ? (DateTime?)null : Convert.ToDateTime(reader["Confirmation_ActualDateOfDelivery"]);
                                entity.Confirmation_ActualCollectionDate = string.IsNullOrEmpty(Convert.ToString(reader["Confirmation_ActualCollectionDate"])) ? (DateTime?)null : Convert.ToDateTime(reader["Confirmation_ActualCollectionDate"]);
                                objServiceOrderDetails.lstServiceOrderDetails.Add(entity);
                            }
                        }
                    }
                }
                objServiceOrderDetails.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objServiceOrderDetails.Status = Status.Failed;
                objServiceOrderDetails.Message = ex.Message;
                throw ex;
            }
            return objServiceOrderDetails;
        }
        public ServiceJobDetails GetCustomFieldsByCustomer(ServiceJobDetails serviceJobDetails)
        {
            ServiceJobDetails objServiceJobDetails = new ServiceJobDetails();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("SP_Service_GetCustomFieldsByCustomer", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CustomerId", serviceJobDetails.CustomerId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                objServiceJobDetails.IsExist = Convert.ToInt32(reader["IsExist"]);
                            }
                            reader.NextResult();
                            if (objServiceJobDetails.IsExist == 1)
                            {
                                while (reader.Read())
                                {
                                    objServiceJobDetails.Extra_CustomField1 = Convert.ToString(reader["CustomField1"]);
                                    objServiceJobDetails.Extra_CustomField2 = Convert.ToString(reader["CustomField2"]);
                                    objServiceJobDetails.Extra_CustomField3 = Convert.ToString(reader["CustomField3"]);
                                    objServiceJobDetails.Extra_CustomField4 = Convert.ToString(reader["CustomField4"]);
                                    objServiceJobDetails.Extra_CustomField5 = Convert.ToString(reader["CustomField5"]);
                                }
                            }
                        }
                    };
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return objServiceJobDetails;
        }
        public ServiceInfo BulkConfirmDeliveryDate(ServiceInfo serviceInfo)
        {
            ServiceInfo objServiceInfo = new ServiceInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Service_BulkConfirmDeliveryDate";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@JobIds", serviceInfo.JobIds);
                        cmd.Parameters.AddWithValue("@Confirmation_ActualDateofDelivery", serviceInfo.Confirmation_ActualDateofDelivery);
                        cmd.Parameters.AddWithValue("@CreatedBy", serviceInfo.CreatedBy);
                        cmd.ExecuteNonQuery();
                    }
                }
                objServiceInfo.JobIds = serviceInfo.JobIds;
                objServiceInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objServiceInfo.Status = Status.Failed;
                objServiceInfo.Message = ex.Message;
                throw ex;
            }
            return objServiceInfo;
        }

        public ServiceOrderEmailDetails InsertOrderEmailDetails(ServiceOrderEmailDetails serviceOrderEmailDetails)
        {
            ServiceOrderEmailDetails objServiceEmailDetails = new ServiceOrderEmailDetails();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Service_Order_EmailDetails";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@OrderId", serviceOrderEmailDetails.OrderId);
                        cmd.Parameters.AddWithValue("@Sent_to", serviceOrderEmailDetails.Sentto);
                        cmd.Parameters.AddWithValue("@EmailSubject", serviceOrderEmailDetails.EmailSubject);
                        cmd.Parameters.AddWithValue("@EmailBody", serviceOrderEmailDetails.EmailBody);
                        cmd.Parameters.AddWithValue("@EmailStatus", serviceOrderEmailDetails.EmailStatus);
                        cmd.Parameters.AddWithValue("@CreatedBy", serviceOrderEmailDetails.CreatedBy);
                        cmd.Parameters.Add("@ReturnId", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objServiceEmailDetails.EmailDetailsId = Convert.ToInt32(cmd.Parameters["@ReturnId"].Value);
                    }
                }
                objServiceEmailDetails.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objServiceEmailDetails.Status = Status.Failed;
                objServiceEmailDetails.Message = ex.Message;
                throw ex;
            }
            return objServiceEmailDetails;
        }

        public ServiceOrderEmailDetails GetEmailTemplate(ServiceOrderEmailDetails serviceEmail)
        {
            ServiceOrderEmailDetails servicedetails = new ServiceOrderEmailDetails();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ServiceOrderEmailDetails> lstserviceEmaildetails = new List<ServiceOrderEmailDetails>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Service_GetOrder_EmailDetails]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@JobId", serviceEmail.JobId);
                        //cmd.Parameters.AddWithValue("@ActionFlag", serviceEmail.ActionFlag);
                        //cmd.Parameters.AddWithValue("@OrderId", serviceEmail.OrderId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ServiceOrderEmailDetails objServiceJobDetails = new ServiceOrderEmailDetails();
                                objServiceJobDetails.OrderId = string.IsNullOrEmpty(Convert.ToString(reader["OrderId"])) ? 0 : Convert.ToInt32(reader["OrderId"]);
                                objServiceJobDetails.EmailSubject = Convert.ToString(reader["EmailSubject"]);
                                objServiceJobDetails.Sentto = Convert.ToString(reader["Sentto"]);
                                objServiceJobDetails.EmailBody = Convert.ToString(reader["EmailBody"]);
                                objServiceJobDetails.CreatedOn = Convert.ToDateTime(reader["CreatedOn"]);
                                lstserviceEmaildetails.Add(objServiceJobDetails);
                            }
                        }
                    }
                    servicedetails.lstEmaildetails = lstserviceEmaildetails;
                }
                servicedetails.Status = Status.Success;
            }
            catch (Exception ex)
            {
                servicedetails.Status = Status.Failed;
                servicedetails.Message = ex.Message;
            }
            return servicedetails;
        }
    }
}
