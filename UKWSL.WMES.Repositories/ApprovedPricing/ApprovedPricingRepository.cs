using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UKWSL.WMES.Business.Entities;

namespace UKWSL.WMES.Repositories.ApprovedPricing
{
    public class ApprovedPricingRepository : IApprovedPricingRepository
    {

        private string _connectionString;
        public ApprovedPricingRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public SOSInfo UploadApprovedPricingSolutionCSVRawData(SOSInfo sOSInfo, DataTable dataTable)
        {
            SOSInfo objSOSInfo = new SOSInfo();
            int _upooadedId = 0;
            List<ApprovedPricingSolution> lstApprovedPricingSolution = new List<ApprovedPricingSolution>();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_ApprovedPricing_InsertRawData";
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter param = new SqlParameter("@ApprovedPricigData", SqlDbType.Structured)
                        {
                            TypeName = "dbo.UDT_ApprovedPricingSolution",
                            Value = dataTable
                        };
                        cmd.Parameters.Add(param);
                        cmd.Parameters.AddWithValue("@CompanyId", sOSInfo.CompanyId);
                        cmd.Parameters.AddWithValue("@DealId", sOSInfo.DealId);
                        cmd.Parameters.AddWithValue("@CreatedBy", sOSInfo.CreatedBy);
                        cmd.Parameters.Add("@ApprovedPricingId", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        _upooadedId = Convert.ToInt32(cmd.Parameters["@ApprovedPricingId"].Value);
                        objSOSInfo.ApprovedPricingId = _upooadedId;
                        objSOSInfo.Status = Status.Success;
                    }

                    using (var cmd1 = conn.CreateCommand())
                    {
                        cmd1.CommandText = "SP_ApprovedPricing_ProcessData";
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@ApprovedPricingId", objSOSInfo.ApprovedPricingId);
                        cmd1.CommandTimeout = 600;
                        SqlDataReader reader = cmd1.ExecuteReader();

                        while (reader.Read())
                        {
                            objSOSInfo.Message = Convert.ToString(reader["ReturnMsg"]);
                        }
                        reader.NextResult();
                        while (reader.Read())
                        {
                            ApprovedPricingSolution objEntity = new ApprovedPricingSolution();
                            objEntity.Id = string.IsNullOrEmpty(Convert.ToString(reader["Id"])) ? 0 : Convert.ToInt32(reader["Id"]);
                            objEntity.Sitecode = Convert.ToString(reader["Sitecode"]);
                            objEntity.Sitename = Convert.ToString(reader["Sitename"]);
                            objEntity.Site_Addressline1 = Convert.ToString(reader["Site_Addressline1"]);
                            objEntity.Site_Addressline2 = Convert.ToString(reader["Site_Addressline2"]);
                            objEntity.Site_Town = Convert.ToString(reader["Site_Town"]);
                            objEntity.Site_county = Convert.ToString(reader["Site_County"]);
                            objEntity.Site_Postcode = Convert.ToString(reader["Site_Postcode"]);
                            objEntity.Wastetype = Convert.ToString(reader["Wastetype"]);
                            objEntity.MaterialType = Convert.ToString(reader["MaterialType"]);
                            objEntity.ContainerType = Convert.ToString(reader["ContainerType"]);
                            objEntity.ContainerSize = Convert.ToString(reader["ContainerSize"]);
                            objEntity.Service_BagType = Convert.ToString(reader["BagType"]);
                            objEntity.quantity = Convert.ToString(reader["Quantity"]);
                            objEntity.Frequency = Convert.ToString(reader["EstimatedFrequency"]);
                            objEntity.Service_Comments = Convert.ToString(reader["Service_Comments"]);
                            objEntity.UploadComment = Convert.ToString(reader["UploadComment"]);
                            objEntity.Site_AccessComments = Convert.ToString(reader["Site_AccessComments"]);
                            objEntity.AccountName = Convert.ToString(reader["AccountName"]);
                            objEntity.AccountNumber = Convert.ToString(reader["AccountNumber"]);
                            objEntity.AccountDescription = Convert.ToString(reader["AccountDescription"]);
                            objEntity.PaymentType = Convert.ToString(reader["PaymentType"]);
                            objEntity.AC_Title = Convert.ToString(reader["AC_Title"]);
                            objEntity.AC_FirstName = Convert.ToString(reader["AC_FirstName"]);
                            objEntity.AC_Surname = Convert.ToString(reader["AC_Surname"]);
                            objEntity.AC_ContactNumber = Convert.ToString(reader["AC_ContactNumber"]);
                            objEntity.AC_MainEmailAddress = Convert.ToString(reader["AC_MainEmailAddress"]);
                            objEntity.AC_AdditionalEmailAddress = Convert.ToString(reader["AC_AdditionalEmailAddress"]);
                            objEntity.AC_AddressLine1 = Convert.ToString(reader["AC_AddressLine1"]);
                            objEntity.AC_AddressLine2 = Convert.ToString(reader["AC_AddressLine2"]);
                            objEntity.AC_Town = Convert.ToString(reader["AC_Town"]);
                            objEntity.AC_County = Convert.ToString(reader["AC_County"]);
                            objEntity.AC_Postcode = Convert.ToString(reader["AC_Postcode"]);

                            objEntity.SC_WC_Title = Convert.ToString(reader["SC_WC_Title"]);
                            objEntity.SC_WC_FirstName = Convert.ToString(reader["SC_WC_FirstName"]);
                            objEntity.SC_WC_Surname = Convert.ToString(reader["SC_WC_Surname"]);
                            objEntity.SC_WC_ContactNumber = Convert.ToString(reader["SC_WC_ContactNumber"]);
                            objEntity.SC_WC_MainEmailAddress = Convert.ToString(reader["SC_WC_MainEmailAddress"]);
                            objEntity.SC_WC_AdditionalEmailAddress = Convert.ToString(reader["SC_WC_AdditionalEmailAddress"]);
                            objEntity.SC_KC_Title = Convert.ToString(reader["SC_KC_Title"]);
                            objEntity.SC_KC_FirstName = Convert.ToString(reader["SC_KC_FirstName"]);
                            objEntity.SC_KC_Surname = Convert.ToString(reader["SC_KC_Surname"]);
                            objEntity.SC_KC_ContactNumber = Convert.ToString(reader["SC_KC_ContactNumber"]);
                            objEntity.SC_KC_MainEmailAddress = Convert.ToString(reader["SC_KC_MainEmailAddress"]);
                            objEntity.SC_KC_AdditionalEmailAddress = Convert.ToString(reader["SC_KC_AdditionalEmailAddress"]);

                            objEntity.CustPrice_price_per_lift = Convert.ToString(reader["CustPrice_price_per_lift"]);
                            objEntity.CustPrice_additional_charge = Convert.ToString(reader["CustPrice_additional_charge"]);
                            objEntity.CustPrice_additional_charge_frequency = Convert.ToString(reader["CustPrice_additional_charge_frequency"]);
                            objEntity.CustPrice_reason_for_additional_charge = Convert.ToString(reader["CustPrice_reason_for_additional_charge"]);
                            objEntity.CustPrice_transport = Convert.ToString(reader["CustPrice_transport"]);
                            objEntity.CustPrice_transport_per_quantity = Convert.ToString(reader["CustPrice_transport_per_quantity"]);
                            objEntity.CustPrice_minimum_transport_charge = Convert.ToString(reader["CustPrice_minimum_transport_charge"]);
                            objEntity.CustPrice_price_per_quantity = Convert.ToString(reader["CustPrice_price_per_quantity"]);
                            objEntity.CustPrice_quantity_type = Convert.ToString(reader["CustPrice_quantity_type"]);
                            objEntity.CustPrice_minimum_quantity = Convert.ToString(reader["CustPrice_minimum_quantity"]);
                            objEntity.CustPrice_max_quantity = Convert.ToString(reader["CustPrice_max_quantity"]);
                            objEntity.CustPrice_excess_weight_charge = Convert.ToString(reader["CustPrice_excess_weight_charge"]);
                            objEntity.CustPrice_rental_day_per_container = Convert.ToString(reader["CustPrice_rental_day_per_container"]);
                            objEntity.CustPrice_demurrage_charge_per_hour = Convert.ToString(reader["CustPrice_demurrage_charge_per_hour"]);
                            objEntity.CustPrice_actual_demurrage = Convert.ToString(reader["CustPrice_actual_demurrage"]);
                            objEntity.CustPrice_consignment_note_Charge_vist = Convert.ToString(reader["CustPrice_consignment_note_Charge_vist"]);
                            objEntity.WeightType = Convert.ToString(reader["WeightType"]);

                            objEntity.ContrPrice_contractor_name = Convert.ToString(reader["ContrPrice_contractor_name"]);
                            objEntity.ContrPrice_depot = Convert.ToString(reader["ContrPrice_depot"]);
                            objEntity.ContrPrice_Cost_per_lift = Convert.ToString(reader["ContrPrice_Cost_per_lift"]);
                            objEntity.ContrPrice_additional_charge = Convert.ToString(reader["ContrPrice_additional_charge"]);
                            objEntity.ContrPrice_additional_charge_frequency = Convert.ToString(reader["ContrPrice_additional_charge_frequency"]);
                            objEntity.ContrPrice_reason_for_additional_charge = Convert.ToString(reader["ContrPrice_reason_for_additional_charge"]);
                            objEntity.ContrPrice_transportcost = Convert.ToString(reader["ContrPrice_transportcost"]);
                            objEntity.ContrPrice_transport_per_quantity = Convert.ToString(reader["ContrPrice_transport_per_quantity"]);
                            objEntity.ContrPrice_minimum_transport_charge = Convert.ToString(reader["ContrPrice_minimum_transport_charge"]);
                            objEntity.ContrPrice_price_per_quantity = Convert.ToString(reader["ContrPrice_price_per_quantity"]);
                            objEntity.ContrPrice_quantity_type = Convert.ToString(reader["ContrPrice_quantity_type"]);
                            objEntity.ContrPrice_minimum_quantity = Convert.ToString(reader["ContrPrice_minimum_quantity"]);
                            objEntity.ContrPrice_max_quantity = Convert.ToString(reader["ContrPrice_max_quantity"]);
                            objEntity.ContrPrice_excess_weight_charge = Convert.ToString(reader["ContrPrice_excess_weight_charge"]);
                            objEntity.ContrPrice_rental_day_per_container = Convert.ToString(reader["ContrPrice_rental_day_per_container"]);
                            objEntity.ContrPrice_demurrage_charge_per_hour = Convert.ToString(reader["ContrPrice_demurrage_charge_per_hour"]);
                            objEntity.ContrPrice_actual_demurrage = Convert.ToString(reader["ContrPrice_actual_demurrage"]);
                            objEntity.ContrPrice_consignment_note_visit = Convert.ToString(reader["ContrPrice_consignment_note_visit"]);
                            objEntity.ContrPrice_EndDestinationType = Convert.ToString(reader["ContrPrice_EndDestinationType"]);

                            objEntity.Service_PONumber = Convert.ToString(reader["Service_PONumber"]);
                            objEntity.Service_TicketNo = Convert.ToString(reader["Service_TicketNo"]);
                            objEntity.Service_DeliveryDate = Convert.ToString(reader["Service_DeliveryDate"]);
                            objEntity.Service_Monday = string.IsNullOrEmpty(Convert.ToString(reader["Service_Monday"])) ? false : Convert.ToBoolean(Convert.ToInt32(reader["Service_Monday"]));
                            objEntity.Service_Tuesday = string.IsNullOrEmpty(Convert.ToString(reader["Service_Tuesday"])) ? false : Convert.ToBoolean(Convert.ToInt32(reader["Service_Tuesday"]));
                            objEntity.Service_Wednesday = string.IsNullOrEmpty(Convert.ToString(reader["Service_Wednesday"])) ? false : Convert.ToBoolean(Convert.ToInt32(reader["Service_Wednesday"]));
                            objEntity.Service_Thursday = string.IsNullOrEmpty(Convert.ToString(reader["Service_Thursday"])) ? false : Convert.ToBoolean(Convert.ToInt32(reader["Service_Thursday"]));
                            objEntity.Service_Friday = string.IsNullOrEmpty(Convert.ToString(reader["Service_Friday"])) ? false : Convert.ToBoolean(Convert.ToInt32(reader["Service_Friday"]));
                            objEntity.Service_Saturday = string.IsNullOrEmpty(Convert.ToString(reader["Service_Saturday"])) ? false : Convert.ToBoolean(Convert.ToInt32(reader["Service_Saturday"]));
                            objEntity.Service_Sunday = string.IsNullOrEmpty(Convert.ToString(reader["Service_Sunday"])) ? false : Convert.ToBoolean(Convert.ToInt32(reader["Service_Sunday"]));
                            objEntity.Service_InternalComments = Convert.ToString(reader["Service_InternalComments"]);

                            objEntity.custom_field1 = Convert.ToString(reader["custom_field1"]);
                            objEntity.custom_field2 = Convert.ToString(reader["custom_field2"]);
                            objEntity.custom_field3 = Convert.ToString(reader["custom_field3"]);
                            objEntity.custom_field4 = Convert.ToString(reader["custom_field4"]);
                            objEntity.custom_field5 = Convert.ToString(reader["custom_field5"]);

                            objEntity.actual_delivery_date = Convert.ToString(reader["actual_delivery_date"]);
                            objEntity.delivery_failure_reason = Convert.ToString(reader["delivery_failure_reason"]);
                            objEntity.losing_contractor_name = Convert.ToString(reader["losing_contractor_name"]);
                            objEntity.losing_contractor_email = Convert.ToString(reader["losing_contractor_email"]);
                            objEntity.removal_date_given_by_contractor = Convert.ToString(reader["removal_date_given_by_contractor"]);
                            objEntity.actual_removal_date_given_by_contractor = Convert.ToString(reader["actual_removal_date_given_by_contractor"]);
                            objEntity.cancel_letter_point_of_contact = Convert.ToString(reader["cancel_letter_point_of_contact"]);
                            objEntity.telephone_audit_req = Convert.ToString(reader["telephone_audit_req"]);
                            objEntity.room_for_dual_bins = Convert.ToString(reader["room_for_dual_bins"]);
                            objEntity.welcome_pack_sent_to_site = Convert.ToString(reader["welcome_pack_sent_to_site"]);
                            objEntity.mobilisation_comments = Convert.ToString(reader["mobilisation_comments"]);
                            objEntity.expected_annual_turnover = Convert.ToString(reader["expected_annual_turnover"]);
                            objEntity.expected_annual_CoS = Convert.ToString(reader["expected_annual_CoS"]);
                            objEntity.expected_annual_margin = Convert.ToString(reader["expected_annual_margin"]);
                            objEntity.actual_annual_turnover = Convert.ToString(reader["actual_annual_turnover"]);
                            objEntity.actual_annual_CoS = Convert.ToString(reader["actual_annual_CoS"]);
                            objEntity.actual_annual_margin = Convert.ToString(reader["actual_annual_margin"]);
                            lstApprovedPricingSolution.Add(objEntity);
                        }
                        objSOSInfo.lstPassedApprovedPricingSolution = lstApprovedPricingSolution;
                        lstApprovedPricingSolution = new List<ApprovedPricingSolution>();
                        reader.NextResult();
                        while (reader.Read())
                        {
                            ApprovedPricingSolution objEntity = new ApprovedPricingSolution();
                            objEntity.Id = string.IsNullOrEmpty(Convert.ToString(reader["Id"])) ? 0 : Convert.ToInt32(reader["Id"]);
                            objEntity.Sitecode = Convert.ToString(reader["Sitecode"]);
                            objEntity.Sitename = Convert.ToString(reader["Sitename"]);
                            objEntity.Site_Addressline1 = Convert.ToString(reader["Site_Addressline1"]);
                            objEntity.Site_Addressline2 = Convert.ToString(reader["Site_Addressline2"]);
                            objEntity.Site_Town = Convert.ToString(reader["Site_Town"]);
                            objEntity.Site_county = Convert.ToString(reader["Site_County"]);
                            objEntity.Site_Postcode = Convert.ToString(reader["Site_Postcode"]);
                            objEntity.Wastetype = Convert.ToString(reader["Wastetype"]);
                            objEntity.MaterialType = Convert.ToString(reader["MaterialType"]);
                            objEntity.ContainerType = Convert.ToString(reader["ContainerType"]);
                            objEntity.ContainerSize = Convert.ToString(reader["ContainerSize"]);
                            objEntity.Service_BagType = Convert.ToString(reader["BagType"]);
                            objEntity.quantity = Convert.ToString(reader["Quantity"]);
                            objEntity.Frequency = Convert.ToString(reader["EstimatedFrequency"]);
                            objEntity.Service_Comments = Convert.ToString(reader["Service_Comments"]);
                            objEntity.UploadComment = Convert.ToString(reader["UploadComment"]);
                            objEntity.Site_AccessComments = Convert.ToString(reader["Site_AccessComments"]);
                            objEntity.AccountName = Convert.ToString(reader["AccountName"]);
                            objEntity.AccountNumber = Convert.ToString(reader["AccountNumber"]);
                            objEntity.AccountDescription = Convert.ToString(reader["AccountDescription"]);
                            objEntity.PaymentType = Convert.ToString(reader["PaymentType"]);
                            objEntity.AC_Title = Convert.ToString(reader["AC_Title"]);
                            objEntity.AC_FirstName = Convert.ToString(reader["AC_FirstName"]);
                            objEntity.AC_Surname = Convert.ToString(reader["AC_Surname"]);
                            objEntity.AC_ContactNumber = Convert.ToString(reader["AC_ContactNumber"]);
                            objEntity.AC_MainEmailAddress = Convert.ToString(reader["AC_MainEmailAddress"]);
                            objEntity.AC_AdditionalEmailAddress = Convert.ToString(reader["AC_AdditionalEmailAddress"]);
                            objEntity.AC_AddressLine1 = Convert.ToString(reader["AC_AddressLine1"]);
                            objEntity.AC_AddressLine2 = Convert.ToString(reader["AC_AddressLine2"]);
                            objEntity.AC_Town = Convert.ToString(reader["AC_Town"]);
                            objEntity.AC_County = Convert.ToString(reader["AC_County"]);
                            objEntity.AC_Postcode = Convert.ToString(reader["AC_Postcode"]);

                            objEntity.SC_WC_Title = Convert.ToString(reader["SC_WC_Title"]);
                            objEntity.SC_WC_FirstName = Convert.ToString(reader["SC_WC_FirstName"]);
                            objEntity.SC_WC_Surname = Convert.ToString(reader["SC_WC_Surname"]);
                            objEntity.SC_WC_ContactNumber = Convert.ToString(reader["SC_WC_ContactNumber"]);
                            objEntity.SC_WC_MainEmailAddress = Convert.ToString(reader["SC_WC_MainEmailAddress"]);
                            objEntity.SC_WC_AdditionalEmailAddress = Convert.ToString(reader["SC_WC_AdditionalEmailAddress"]);
                            objEntity.SC_KC_Title = Convert.ToString(reader["SC_KC_Title"]);
                            objEntity.SC_KC_FirstName = Convert.ToString(reader["SC_KC_FirstName"]);
                            objEntity.SC_KC_Surname = Convert.ToString(reader["SC_KC_Surname"]);
                            objEntity.SC_KC_ContactNumber = Convert.ToString(reader["SC_KC_ContactNumber"]);
                            objEntity.SC_KC_MainEmailAddress = Convert.ToString(reader["SC_KC_MainEmailAddress"]);
                            objEntity.SC_KC_AdditionalEmailAddress = Convert.ToString(reader["SC_KC_AdditionalEmailAddress"]);

                            objEntity.CustPrice_price_per_lift = Convert.ToString(reader["CustPrice_price_per_lift"]);
                            objEntity.CustPrice_additional_charge = Convert.ToString(reader["CustPrice_additional_charge"]);
                            objEntity.CustPrice_additional_charge_frequency = Convert.ToString(reader["CustPrice_additional_charge_frequency"]);
                            objEntity.CustPrice_reason_for_additional_charge = Convert.ToString(reader["CustPrice_reason_for_additional_charge"]);
                            objEntity.CustPrice_transport = Convert.ToString(reader["CustPrice_transport"]);
                            objEntity.CustPrice_transport_per_quantity = Convert.ToString(reader["CustPrice_transport_per_quantity"]);
                            objEntity.CustPrice_minimum_transport_charge = Convert.ToString(reader["CustPrice_minimum_transport_charge"]);
                            objEntity.CustPrice_price_per_quantity = Convert.ToString(reader["CustPrice_price_per_quantity"]);
                            objEntity.CustPrice_quantity_type = Convert.ToString(reader["CustPrice_quantity_type"]);
                            objEntity.CustPrice_minimum_quantity = Convert.ToString(reader["CustPrice_minimum_quantity"]);
                            objEntity.CustPrice_max_quantity = Convert.ToString(reader["CustPrice_max_quantity"]);
                            objEntity.CustPrice_excess_weight_charge = Convert.ToString(reader["CustPrice_excess_weight_charge"]);
                            objEntity.CustPrice_rental_day_per_container = Convert.ToString(reader["CustPrice_rental_day_per_container"]);
                            objEntity.CustPrice_demurrage_charge_per_hour = Convert.ToString(reader["CustPrice_demurrage_charge_per_hour"]);
                            objEntity.CustPrice_actual_demurrage = Convert.ToString(reader["CustPrice_actual_demurrage"]);
                            objEntity.CustPrice_consignment_note_Charge_vist = Convert.ToString(reader["CustPrice_consignment_note_Charge_vist"]);
                            objEntity.WeightType = Convert.ToString(reader["WeightType"]);

                            objEntity.ContrPrice_contractor_name = Convert.ToString(reader["ContrPrice_contractor_name"]);
                            objEntity.ContrPrice_depot = Convert.ToString(reader["ContrPrice_depot"]);
                            objEntity.ContrPrice_Cost_per_lift = Convert.ToString(reader["ContrPrice_Cost_per_lift"]);
                            objEntity.ContrPrice_additional_charge = Convert.ToString(reader["ContrPrice_additional_charge"]);
                            objEntity.ContrPrice_additional_charge_frequency = Convert.ToString(reader["ContrPrice_additional_charge_frequency"]);
                            objEntity.ContrPrice_reason_for_additional_charge = Convert.ToString(reader["ContrPrice_reason_for_additional_charge"]);
                            objEntity.ContrPrice_transportcost = Convert.ToString(reader["ContrPrice_transportcost"]);
                            objEntity.ContrPrice_transport_per_quantity = Convert.ToString(reader["ContrPrice_transport_per_quantity"]);
                            objEntity.ContrPrice_minimum_transport_charge = Convert.ToString(reader["ContrPrice_minimum_transport_charge"]);
                            objEntity.ContrPrice_price_per_quantity = Convert.ToString(reader["ContrPrice_price_per_quantity"]);
                            objEntity.ContrPrice_quantity_type = Convert.ToString(reader["ContrPrice_quantity_type"]);
                            objEntity.ContrPrice_minimum_quantity = Convert.ToString(reader["ContrPrice_minimum_quantity"]);
                            objEntity.ContrPrice_max_quantity = Convert.ToString(reader["ContrPrice_max_quantity"]);
                            objEntity.ContrPrice_excess_weight_charge = Convert.ToString(reader["ContrPrice_excess_weight_charge"]);
                            objEntity.ContrPrice_rental_day_per_container = Convert.ToString(reader["ContrPrice_rental_day_per_container"]);
                            objEntity.ContrPrice_demurrage_charge_per_hour = Convert.ToString(reader["ContrPrice_demurrage_charge_per_hour"]);
                            objEntity.ContrPrice_actual_demurrage = Convert.ToString(reader["ContrPrice_actual_demurrage"]);
                            objEntity.ContrPrice_consignment_note_visit = Convert.ToString(reader["ContrPrice_consignment_note_visit"]);
                            objEntity.ContrPrice_EndDestinationType = Convert.ToString(reader["ContrPrice_EndDestinationType"]);

                            objEntity.Service_PONumber = Convert.ToString(reader["Service_PONumber"]);
                            objEntity.Service_TicketNo = Convert.ToString(reader["Service_TicketNo"]);
                            objEntity.Service_DeliveryDate = Convert.ToString(reader["Service_DeliveryDate"]);
                            objEntity.Service_Monday = string.IsNullOrEmpty(Convert.ToString(reader["Service_Monday"])) ? false : Convert.ToBoolean(Convert.ToInt32(reader["Service_Monday"]));
                            objEntity.Service_Tuesday = string.IsNullOrEmpty(Convert.ToString(reader["Service_Tuesday"])) ? false : Convert.ToBoolean(Convert.ToInt32(reader["Service_Tuesday"]));
                            objEntity.Service_Wednesday = string.IsNullOrEmpty(Convert.ToString(reader["Service_Wednesday"])) ? false : Convert.ToBoolean(Convert.ToInt32(reader["Service_Wednesday"]));
                            objEntity.Service_Thursday = string.IsNullOrEmpty(Convert.ToString(reader["Service_Thursday"])) ? false : Convert.ToBoolean(Convert.ToInt32(reader["Service_Thursday"]));
                            objEntity.Service_Friday = string.IsNullOrEmpty(Convert.ToString(reader["Service_Friday"])) ? false : Convert.ToBoolean(Convert.ToInt32(reader["Service_Friday"]));
                            objEntity.Service_Saturday = string.IsNullOrEmpty(Convert.ToString(reader["Service_Saturday"])) ? false : Convert.ToBoolean(Convert.ToInt32(reader["Service_Saturday"]));
                            objEntity.Service_Sunday = string.IsNullOrEmpty(Convert.ToString(reader["Service_Sunday"])) ? false : Convert.ToBoolean(Convert.ToInt32(reader["Service_Sunday"]));
                            objEntity.Service_InternalComments = Convert.ToString(reader["Service_InternalComments"]);

                            objEntity.custom_field1 = Convert.ToString(reader["custom_field1"]);
                            objEntity.custom_field2 = Convert.ToString(reader["custom_field2"]);
                            objEntity.custom_field3 = Convert.ToString(reader["custom_field3"]);
                            objEntity.custom_field4 = Convert.ToString(reader["custom_field4"]);
                            objEntity.custom_field5 = Convert.ToString(reader["custom_field5"]);

                            objEntity.actual_delivery_date = Convert.ToString(reader["actual_delivery_date"]);
                            objEntity.delivery_failure_reason = Convert.ToString(reader["delivery_failure_reason"]);
                            objEntity.losing_contractor_name = Convert.ToString(reader["losing_contractor_name"]);
                            objEntity.losing_contractor_email = Convert.ToString(reader["losing_contractor_email"]);
                            objEntity.removal_date_given_by_contractor = Convert.ToString(reader["removal_date_given_by_contractor"]);
                            objEntity.actual_removal_date_given_by_contractor = Convert.ToString(reader["actual_removal_date_given_by_contractor"]);
                            objEntity.cancel_letter_point_of_contact = Convert.ToString(reader["cancel_letter_point_of_contact"]);
                            objEntity.telephone_audit_req = Convert.ToString(reader["telephone_audit_req"]);
                            objEntity.room_for_dual_bins = Convert.ToString(reader["room_for_dual_bins"]);
                            objEntity.welcome_pack_sent_to_site = Convert.ToString(reader["welcome_pack_sent_to_site"]);
                            objEntity.mobilisation_comments = Convert.ToString(reader["mobilisation_comments"]);
                            objEntity.expected_annual_turnover = Convert.ToString(reader["expected_annual_turnover"]);
                            objEntity.expected_annual_CoS = Convert.ToString(reader["expected_annual_CoS"]);
                            objEntity.expected_annual_margin = Convert.ToString(reader["expected_annual_margin"]);
                            objEntity.actual_annual_turnover = Convert.ToString(reader["actual_annual_turnover"]);
                            objEntity.actual_annual_CoS = Convert.ToString(reader["actual_annual_CoS"]);
                            objEntity.actual_annual_margin = Convert.ToString(reader["actual_annual_margin"]);
                            lstApprovedPricingSolution.Add(objEntity);
                        }
                        objSOSInfo.lstFailedApprovedPricingSolution = lstApprovedPricingSolution;
                    }
                }
            }
            catch (Exception ex)
            {
                objSOSInfo.Status = Status.Failed;
                objSOSInfo.Message = ex.Message;
            }
            return objSOSInfo;
        }
        public SOSInfo GetProcessedAPSData(SOSInfo sOSInfo)
        {
            SOSInfo objSOSInfo = new SOSInfo();
            List<ApprovedPricingSolution> lstApprovedPricingSolution = new List<ApprovedPricingSolution>();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd1 = conn.CreateCommand())
                    {
                        cmd1.CommandText = "SP_ApprovedPricing_GetProcessedData";
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@ApprovedPricingId", sOSInfo.ApprovedPricingId);
                        cmd1.CommandTimeout = 600;
                        SqlDataReader reader = cmd1.ExecuteReader();

                        while (reader.Read())
                        {
                            ApprovedPricingSolution objEntity = new ApprovedPricingSolution();
                            objEntity.Id = string.IsNullOrEmpty(Convert.ToString(reader["Id"])) ? 0 : Convert.ToInt32(reader["Id"]);
                            objEntity.Sitecode = Convert.ToString(reader["Sitecode"]);
                            objEntity.Sitename = Convert.ToString(reader["Sitename"]);
                            objEntity.Site_Addressline1 = Convert.ToString(reader["Site_Addressline1"]);
                            objEntity.Site_Addressline2 = Convert.ToString(reader["Site_Addressline2"]);
                            objEntity.Site_Town = Convert.ToString(reader["Site_Town"]);
                            objEntity.Site_county = Convert.ToString(reader["Site_County"]);
                            objEntity.Site_Postcode = Convert.ToString(reader["Site_Postcode"]);
                            objEntity.Wastetype = Convert.ToString(reader["Wastetype"]);
                            objEntity.MaterialType = Convert.ToString(reader["MaterialType"]);
                            objEntity.ContainerType = Convert.ToString(reader["ContainerType"]);
                            objEntity.ContainerSize = Convert.ToString(reader["ContainerSize"]);
                            objEntity.Service_BagType = Convert.ToString(reader["BagType"]);
                            objEntity.quantity = Convert.ToString(reader["Quantity"]);
                            objEntity.Frequency = Convert.ToString(reader["Frequency"]);
                            objEntity.Service_Comments = Convert.ToString(reader["Service_Comments"]);
                            objEntity.UploadComment = Convert.ToString(reader["UploadComment"]);
                            objEntity.Site_AccessComments = Convert.ToString(reader["Site_AccessComments"]);

                            objEntity.AccountName = Convert.ToString(reader["AccountName"]);
                            objEntity.AccountNumber = Convert.ToString(reader["AccountNumber"]);
                            objEntity.AccountDescription = Convert.ToString(reader["AccountDescription"]);
                            objEntity.PaymentType = Convert.ToString(reader["PaymentType"]);
                            objEntity.AC_Title = Convert.ToString(reader["AC_Title"]);
                            objEntity.AC_FirstName = Convert.ToString(reader["AC_FirstName"]);
                            objEntity.AC_Surname = Convert.ToString(reader["AC_Surname"]);
                            objEntity.AC_ContactNumber = Convert.ToString(reader["AC_ContactNumber"]);
                            objEntity.AC_MainEmailAddress = Convert.ToString(reader["AC_MainEmailAddress"]);
                            objEntity.AC_AdditionalEmailAddress = Convert.ToString(reader["AC_AdditionalEmailAddress"]);
                            objEntity.AC_AddressLine1 = Convert.ToString(reader["AC_AddressLine1"]);
                            objEntity.AC_AddressLine2 = Convert.ToString(reader["AC_AddressLine2"]);
                            objEntity.AC_Town = Convert.ToString(reader["AC_Town"]);
                            objEntity.AC_County = Convert.ToString(reader["AC_County"]);
                            objEntity.AC_Postcode = Convert.ToString(reader["AC_Postcode"]);

                            objEntity.SC_WC_Title = Convert.ToString(reader["SC_WC_Title"]);
                            objEntity.SC_WC_FirstName = Convert.ToString(reader["SC_WC_FirstName"]);
                            objEntity.SC_WC_Surname = Convert.ToString(reader["SC_WC_Surname"]);
                            objEntity.SC_WC_ContactNumber = Convert.ToString(reader["SC_WC_ContactNumber"]);
                            objEntity.SC_WC_MainEmailAddress = Convert.ToString(reader["SC_WC_MainEmailAddress"]);
                            objEntity.SC_WC_AdditionalEmailAddress = Convert.ToString(reader["SC_WC_AdditionalEmailAddress"]);
                            objEntity.SC_KC_Title = Convert.ToString(reader["SC_KC_Title"]);
                            objEntity.SC_KC_FirstName = Convert.ToString(reader["SC_KC_FirstName"]);
                            objEntity.SC_KC_Surname = Convert.ToString(reader["SC_KC_Surname"]);
                            objEntity.SC_KC_ContactNumber = Convert.ToString(reader["SC_KC_ContactNumber"]);
                            objEntity.SC_KC_MainEmailAddress = Convert.ToString(reader["SC_KC_MainEmailAddress"]);
                            objEntity.SC_KC_AdditionalEmailAddress = Convert.ToString(reader["SC_KC_AdditionalEmailAddress"]);

                            objEntity.CustPrice_price_per_lift = Convert.ToString(reader["CustPrice_price_per_lift"]);
                            objEntity.CustPrice_additional_charge = Convert.ToString(reader["CustPrice_additional_charge"]);
                            objEntity.CustPrice_additional_charge_frequency = Convert.ToString(reader["CustPrice_additional_charge_frequency"]);
                            objEntity.CustPrice_reason_for_additional_charge = Convert.ToString(reader["CustPrice_reason_for_additional_charge"]);
                            objEntity.CustPrice_transport = Convert.ToString(reader["CustPrice_transport"]);
                            objEntity.CustPrice_transport_per_quantity = Convert.ToString(reader["CustPrice_transport_per_quantity"]);
                            objEntity.CustPrice_minimum_transport_charge = Convert.ToString(reader["CustPrice_minimum_transport_charge"]);
                            objEntity.CustPrice_price_per_quantity = Convert.ToString(reader["CustPrice_price_per_quantity"]);
                            objEntity.CustPrice_quantity_type = Convert.ToString(reader["CustPrice_quantity_type"]);
                            objEntity.CustPrice_minimum_quantity = Convert.ToString(reader["CustPrice_minimum_quantity"]);
                            objEntity.CustPrice_max_quantity = Convert.ToString(reader["CustPrice_max_quantity"]);
                            objEntity.CustPrice_excess_weight_charge = Convert.ToString(reader["CustPrice_excess_weight_charge"]);
                            objEntity.CustPrice_rental_day_per_container = Convert.ToString(reader["CustPrice_rental_day_per_container"]);
                            objEntity.CustPrice_demurrage_charge_per_hour = Convert.ToString(reader["CustPrice_demurrage_charge_per_hour"]);
                            objEntity.CustPrice_actual_demurrage = Convert.ToString(reader["CustPrice_actual_demurrage"]);
                            objEntity.CustPrice_consignment_note_Charge_vist = Convert.ToString(reader["CustPrice_consignment_note_Charge_vist"]);
                            objEntity.WeightType = Convert.ToString(reader["WeightType"]);

                            objEntity.ContrPrice_contractor_name = Convert.ToString(reader["ContrPrice_contractor_name"]);
                            objEntity.ContrPrice_depot = Convert.ToString(reader["ContrPrice_depot"]);
                            objEntity.ContrPrice_Cost_per_lift = Convert.ToString(reader["ContrPrice_Cost_per_lift"]);
                            objEntity.ContrPrice_additional_charge = Convert.ToString(reader["ContrPrice_additional_charge"]);
                            objEntity.ContrPrice_additional_charge_frequency = Convert.ToString(reader["ContrPrice_additional_charge_frequency"]);
                            objEntity.ContrPrice_reason_for_additional_charge = Convert.ToString(reader["ContrPrice_reason_for_additional_charge"]);
                            objEntity.ContrPrice_transportcost = Convert.ToString(reader["ContrPrice_transportcost"]);
                            objEntity.ContrPrice_transport_per_quantity = Convert.ToString(reader["ContrPrice_transport_per_quantity"]);
                            objEntity.ContrPrice_minimum_transport_charge = Convert.ToString(reader["ContrPrice_minimum_transport_charge"]);
                            objEntity.ContrPrice_price_per_quantity = Convert.ToString(reader["ContrPrice_price_per_quantity"]);
                            objEntity.ContrPrice_quantity_type = Convert.ToString(reader["ContrPrice_quantity_type"]);
                            objEntity.ContrPrice_minimum_quantity = Convert.ToString(reader["ContrPrice_minimum_quantity"]);
                            objEntity.ContrPrice_max_quantity = Convert.ToString(reader["ContrPrice_max_quantity"]);
                            objEntity.ContrPrice_excess_weight_charge = Convert.ToString(reader["ContrPrice_excess_weight_charge"]);
                            objEntity.ContrPrice_rental_day_per_container = Convert.ToString(reader["ContrPrice_rental_day_per_container"]);
                            objEntity.ContrPrice_demurrage_charge_per_hour = Convert.ToString(reader["ContrPrice_demurrage_charge_per_hour"]);
                            objEntity.ContrPrice_actual_demurrage = Convert.ToString(reader["ContrPrice_actual_demurrage"]);
                            objEntity.ContrPrice_consignment_note_visit = Convert.ToString(reader["ContrPrice_consignment_note_visit"]);
                            objEntity.ContrPrice_EndDestinationType = Convert.ToString(reader["ContrPrice_EndDestinationType"]);

                            objEntity.Service_PONumber = Convert.ToString(reader["Service_PONumber"]);
                            objEntity.Service_TicketNo = Convert.ToString(reader["Service_TicketNo"]);
                            objEntity.Service_DeliveryDate = Convert.ToString(reader["Service_DeliveryDate"]);
                            objEntity.Service_Monday = string.IsNullOrEmpty(Convert.ToString(reader["Service_Monday"])) ? false : Convert.ToBoolean(Convert.ToInt32(reader["Service_Monday"]));
                            objEntity.Service_Tuesday = string.IsNullOrEmpty(Convert.ToString(reader["Service_Tuesday"])) ? false : Convert.ToBoolean(Convert.ToInt32(reader["Service_Tuesday"]));
                            objEntity.Service_Wednesday = string.IsNullOrEmpty(Convert.ToString(reader["Service_Wednesday"])) ? false : Convert.ToBoolean(Convert.ToInt32(reader["Service_Wednesday"]));
                            objEntity.Service_Thursday = string.IsNullOrEmpty(Convert.ToString(reader["Service_Thursday"])) ? false : Convert.ToBoolean(Convert.ToInt32(reader["Service_Thursday"]));
                            objEntity.Service_Friday = string.IsNullOrEmpty(Convert.ToString(reader["Service_Friday"])) ? false : Convert.ToBoolean(Convert.ToInt32(reader["Service_Friday"]));
                            objEntity.Service_Saturday = string.IsNullOrEmpty(Convert.ToString(reader["Service_Saturday"])) ? false : Convert.ToBoolean(Convert.ToInt32(reader["Service_Saturday"]));
                            objEntity.Service_Sunday = string.IsNullOrEmpty(Convert.ToString(reader["Service_Sunday"])) ? false : Convert.ToBoolean(Convert.ToInt32(reader["Service_Sunday"]));
                            objEntity.Service_InternalComments = Convert.ToString(reader["Service_InternalComments"]);

                            objEntity.custom_field1 = Convert.ToString(reader["custom_field1"]);
                            objEntity.custom_field2 = Convert.ToString(reader["custom_field2"]);
                            objEntity.custom_field3 = Convert.ToString(reader["custom_field3"]);
                            objEntity.custom_field4 = Convert.ToString(reader["custom_field4"]);
                            objEntity.custom_field5 = Convert.ToString(reader["custom_field5"]);

                            objEntity.actual_delivery_date = Convert.ToString(reader["actual_delivery_date"]);
                            objEntity.delivery_failure_reason = Convert.ToString(reader["delivery_failure_reason"]);
                            objEntity.losing_contractor_name = Convert.ToString(reader["losing_contractor_name"]);
                            objEntity.losing_contractor_email = Convert.ToString(reader["losing_contractor_email"]);
                            objEntity.removal_date_given_by_contractor = Convert.ToString(reader["removal_date_given_by_contractor"]);
                            objEntity.actual_removal_date_given_by_contractor = Convert.ToString(reader["actual_removal_date_given_by_contractor"]);
                            objEntity.cancel_letter_point_of_contact = Convert.ToString(reader["cancel_letter_point_of_contact"]);
                            objEntity.telephone_audit_req = Convert.ToString(reader["telephone_audit_req"]);
                            objEntity.room_for_dual_bins = Convert.ToString(reader["room_for_dual_bins"]);
                            objEntity.welcome_pack_sent_to_site = Convert.ToString(reader["welcome_pack_sent_to_site"]);
                            objEntity.mobilisation_comments = Convert.ToString(reader["mobilisation_comments"]);
                            objEntity.expected_annual_turnover = Convert.ToString(reader["expected_annual_turnover"]);
                            objEntity.expected_annual_CoS = Convert.ToString(reader["expected_annual_CoS"]);
                            objEntity.expected_annual_margin = Convert.ToString(reader["expected_annual_margin"]);
                            objEntity.actual_annual_turnover = Convert.ToString(reader["actual_annual_turnover"]);
                            objEntity.actual_annual_CoS = Convert.ToString(reader["actual_annual_CoS"]);
                            objEntity.actual_annual_margin = Convert.ToString(reader["actual_annual_margin"]);
                            lstApprovedPricingSolution.Add(objEntity);
                        }
                        objSOSInfo.lstPassedApprovedPricingSolution = lstApprovedPricingSolution;
                        lstApprovedPricingSolution = new List<ApprovedPricingSolution>();
                        reader.NextResult();
                        while (reader.Read())
                        {
                            ApprovedPricingSolution objEntity = new ApprovedPricingSolution();
                            objEntity.Id = string.IsNullOrEmpty(Convert.ToString(reader["Id"])) ? 0 : Convert.ToInt32(reader["Id"]);
                            objEntity.Sitecode = Convert.ToString(reader["Sitecode"]);
                            objEntity.Sitename = Convert.ToString(reader["Sitename"]);
                            objEntity.Site_Addressline1 = Convert.ToString(reader["Site_Addressline1"]);
                            objEntity.Site_Addressline2 = Convert.ToString(reader["Site_Addressline2"]);
                            objEntity.Site_Town = Convert.ToString(reader["Site_Town"]);
                            objEntity.Site_county = Convert.ToString(reader["Site_County"]);
                            objEntity.Site_Postcode = Convert.ToString(reader["Site_Postcode"]);
                            objEntity.Wastetype = Convert.ToString(reader["Wastetype"]);
                            objEntity.MaterialType = Convert.ToString(reader["MaterialType"]);
                            objEntity.ContainerType = Convert.ToString(reader["ContainerType"]);
                            objEntity.ContainerSize = Convert.ToString(reader["ContainerSize"]);
                            objEntity.Service_BagType = Convert.ToString(reader["BagType"]);
                            objEntity.quantity = Convert.ToString(reader["Quantity"]);
                            objEntity.Frequency = Convert.ToString(reader["Frequency"]);
                            objEntity.Service_Comments = Convert.ToString(reader["Service_Comments"]);
                            objEntity.UploadComment = Convert.ToString(reader["UploadComment"]);
                            objEntity.Site_AccessComments = Convert.ToString(reader["Site_AccessComments"]);
                            objEntity.AccountName = Convert.ToString(reader["AccountName"]);
                            objEntity.AccountNumber = Convert.ToString(reader["AccountNumber"]);
                            objEntity.AccountDescription = Convert.ToString(reader["AccountDescription"]);
                            objEntity.PaymentType = Convert.ToString(reader["PaymentType"]);
                            objEntity.AC_Title = Convert.ToString(reader["AC_Title"]);
                            objEntity.AC_FirstName = Convert.ToString(reader["AC_FirstName"]);
                            objEntity.AC_Surname = Convert.ToString(reader["AC_Surname"]);
                            objEntity.AC_ContactNumber = Convert.ToString(reader["AC_ContactNumber"]);
                            objEntity.AC_MainEmailAddress = Convert.ToString(reader["AC_MainEmailAddress"]);
                            objEntity.AC_AdditionalEmailAddress = Convert.ToString(reader["AC_AdditionalEmailAddress"]);
                            objEntity.AC_AddressLine1 = Convert.ToString(reader["AC_AddressLine1"]);
                            objEntity.AC_AddressLine2 = Convert.ToString(reader["AC_AddressLine2"]);
                            objEntity.AC_Town = Convert.ToString(reader["AC_Town"]);
                            objEntity.AC_County = Convert.ToString(reader["AC_County"]);
                            objEntity.AC_Postcode = Convert.ToString(reader["AC_Postcode"]);

                            objEntity.SC_WC_Title = Convert.ToString(reader["SC_WC_Title"]);
                            objEntity.SC_WC_FirstName = Convert.ToString(reader["SC_WC_FirstName"]);
                            objEntity.SC_WC_Surname = Convert.ToString(reader["SC_WC_Surname"]);
                            objEntity.SC_WC_ContactNumber = Convert.ToString(reader["SC_WC_ContactNumber"]);
                            objEntity.SC_WC_MainEmailAddress = Convert.ToString(reader["SC_WC_MainEmailAddress"]);
                            objEntity.SC_WC_AdditionalEmailAddress = Convert.ToString(reader["SC_WC_AdditionalEmailAddress"]);
                            objEntity.SC_KC_Title = Convert.ToString(reader["SC_KC_Title"]);
                            objEntity.SC_KC_FirstName = Convert.ToString(reader["SC_KC_FirstName"]);
                            objEntity.SC_KC_Surname = Convert.ToString(reader["SC_KC_Surname"]);
                            objEntity.SC_KC_ContactNumber = Convert.ToString(reader["SC_KC_ContactNumber"]);
                            objEntity.SC_KC_MainEmailAddress = Convert.ToString(reader["SC_KC_MainEmailAddress"]);
                            objEntity.SC_KC_AdditionalEmailAddress = Convert.ToString(reader["SC_KC_AdditionalEmailAddress"]);

                            objEntity.CustPrice_price_per_lift = Convert.ToString(reader["CustPrice_price_per_lift"]);
                            objEntity.CustPrice_additional_charge = Convert.ToString(reader["CustPrice_additional_charge"]);
                            objEntity.CustPrice_additional_charge_frequency = Convert.ToString(reader["CustPrice_additional_charge_frequency"]);
                            objEntity.CustPrice_reason_for_additional_charge = Convert.ToString(reader["CustPrice_reason_for_additional_charge"]);
                            objEntity.CustPrice_transport = Convert.ToString(reader["CustPrice_transport"]);
                            objEntity.CustPrice_transport_per_quantity = Convert.ToString(reader["CustPrice_transport_per_quantity"]);
                            objEntity.CustPrice_minimum_transport_charge = Convert.ToString(reader["CustPrice_minimum_transport_charge"]);
                            objEntity.CustPrice_price_per_quantity = Convert.ToString(reader["CustPrice_price_per_quantity"]);
                            objEntity.CustPrice_quantity_type = Convert.ToString(reader["CustPrice_quantity_type"]);
                            objEntity.CustPrice_minimum_quantity = Convert.ToString(reader["CustPrice_minimum_quantity"]);
                            objEntity.CustPrice_max_quantity = Convert.ToString(reader["CustPrice_max_quantity"]);
                            objEntity.CustPrice_excess_weight_charge = Convert.ToString(reader["CustPrice_excess_weight_charge"]);
                            objEntity.CustPrice_rental_day_per_container = Convert.ToString(reader["CustPrice_rental_day_per_container"]);
                            objEntity.CustPrice_demurrage_charge_per_hour = Convert.ToString(reader["CustPrice_demurrage_charge_per_hour"]);
                            objEntity.CustPrice_actual_demurrage = Convert.ToString(reader["CustPrice_actual_demurrage"]);
                            objEntity.CustPrice_consignment_note_Charge_vist = Convert.ToString(reader["CustPrice_consignment_note_Charge_vist"]);
                            objEntity.WeightType = Convert.ToString(reader["WeightType"]);

                            objEntity.ContrPrice_contractor_name = Convert.ToString(reader["ContrPrice_contractor_name"]);
                            objEntity.ContrPrice_depot = Convert.ToString(reader["ContrPrice_depot"]);
                            objEntity.ContrPrice_Cost_per_lift = Convert.ToString(reader["ContrPrice_Cost_per_lift"]);
                            objEntity.ContrPrice_additional_charge = Convert.ToString(reader["ContrPrice_additional_charge"]);
                            objEntity.ContrPrice_additional_charge_frequency = Convert.ToString(reader["ContrPrice_additional_charge_frequency"]);
                            objEntity.ContrPrice_reason_for_additional_charge = Convert.ToString(reader["ContrPrice_reason_for_additional_charge"]);
                            objEntity.ContrPrice_transportcost = Convert.ToString(reader["ContrPrice_transportcost"]);
                            objEntity.ContrPrice_transport_per_quantity = Convert.ToString(reader["ContrPrice_transport_per_quantity"]);
                            objEntity.ContrPrice_minimum_transport_charge = Convert.ToString(reader["ContrPrice_minimum_transport_charge"]);
                            objEntity.ContrPrice_price_per_quantity = Convert.ToString(reader["ContrPrice_price_per_quantity"]);
                            objEntity.ContrPrice_quantity_type = Convert.ToString(reader["ContrPrice_quantity_type"]);
                            objEntity.ContrPrice_minimum_quantity = Convert.ToString(reader["ContrPrice_minimum_quantity"]);
                            objEntity.ContrPrice_max_quantity = Convert.ToString(reader["ContrPrice_max_quantity"]);
                            objEntity.ContrPrice_excess_weight_charge = Convert.ToString(reader["ContrPrice_excess_weight_charge"]);
                            objEntity.ContrPrice_rental_day_per_container = Convert.ToString(reader["ContrPrice_rental_day_per_container"]);
                            objEntity.ContrPrice_demurrage_charge_per_hour = Convert.ToString(reader["ContrPrice_demurrage_charge_per_hour"]);
                            objEntity.ContrPrice_actual_demurrage = Convert.ToString(reader["ContrPrice_actual_demurrage"]);
                            objEntity.ContrPrice_consignment_note_visit = Convert.ToString(reader["ContrPrice_consignment_note_visit"]);
                            objEntity.ContrPrice_EndDestinationType = Convert.ToString(reader["ContrPrice_EndDestinationType"]);

                            objEntity.Service_PONumber = Convert.ToString(reader["Service_PONumber"]);
                            objEntity.Service_TicketNo = Convert.ToString(reader["Service_TicketNo"]);
                            objEntity.Service_DeliveryDate = Convert.ToString(reader["Service_DeliveryDate"]);
                            objEntity.Service_Monday = string.IsNullOrEmpty(Convert.ToString(reader["Service_Monday"])) ? false : Convert.ToBoolean(Convert.ToInt32(reader["Service_Monday"]));
                            objEntity.Service_Tuesday = string.IsNullOrEmpty(Convert.ToString(reader["Service_Tuesday"])) ? false : Convert.ToBoolean(Convert.ToInt32(reader["Service_Tuesday"]));
                            objEntity.Service_Wednesday = string.IsNullOrEmpty(Convert.ToString(reader["Service_Wednesday"])) ? false : Convert.ToBoolean(Convert.ToInt32(reader["Service_Wednesday"]));
                            objEntity.Service_Thursday = string.IsNullOrEmpty(Convert.ToString(reader["Service_Thursday"])) ? false : Convert.ToBoolean(Convert.ToInt32(reader["Service_Thursday"]));
                            objEntity.Service_Friday = string.IsNullOrEmpty(Convert.ToString(reader["Service_Friday"])) ? false : Convert.ToBoolean(Convert.ToInt32(reader["Service_Friday"]));
                            objEntity.Service_Saturday = string.IsNullOrEmpty(Convert.ToString(reader["Service_Saturday"])) ? false : Convert.ToBoolean(Convert.ToInt32(reader["Service_Saturday"]));
                            objEntity.Service_Sunday = string.IsNullOrEmpty(Convert.ToString(reader["Service_Sunday"])) ? false : Convert.ToBoolean(Convert.ToInt32(reader["Service_Sunday"]));
                            objEntity.Service_InternalComments = Convert.ToString(reader["Service_InternalComments"]);

                            objEntity.custom_field1 = Convert.ToString(reader["custom_field1"]);
                            objEntity.custom_field2 = Convert.ToString(reader["custom_field2"]);
                            objEntity.custom_field3 = Convert.ToString(reader["custom_field3"]);
                            objEntity.custom_field4 = Convert.ToString(reader["custom_field4"]);
                            objEntity.custom_field5 = Convert.ToString(reader["custom_field5"]);

                            objEntity.actual_delivery_date = Convert.ToString(reader["actual_delivery_date"]);
                            objEntity.delivery_failure_reason = Convert.ToString(reader["delivery_failure_reason"]);
                            objEntity.losing_contractor_name = Convert.ToString(reader["losing_contractor_name"]);
                            objEntity.losing_contractor_email = Convert.ToString(reader["losing_contractor_email"]);
                            objEntity.removal_date_given_by_contractor = Convert.ToString(reader["removal_date_given_by_contractor"]);
                            objEntity.actual_removal_date_given_by_contractor = Convert.ToString(reader["actual_removal_date_given_by_contractor"]);
                            objEntity.cancel_letter_point_of_contact = Convert.ToString(reader["cancel_letter_point_of_contact"]);
                            objEntity.telephone_audit_req = Convert.ToString(reader["telephone_audit_req"]);
                            objEntity.room_for_dual_bins = Convert.ToString(reader["room_for_dual_bins"]);
                            objEntity.welcome_pack_sent_to_site = Convert.ToString(reader["welcome_pack_sent_to_site"]);
                            objEntity.mobilisation_comments = Convert.ToString(reader["mobilisation_comments"]);
                            objEntity.expected_annual_turnover = Convert.ToString(reader["expected_annual_turnover"]);
                            objEntity.expected_annual_CoS = Convert.ToString(reader["expected_annual_CoS"]);
                            objEntity.expected_annual_margin = Convert.ToString(reader["expected_annual_margin"]);
                            objEntity.actual_annual_turnover = Convert.ToString(reader["actual_annual_turnover"]);
                            objEntity.actual_annual_CoS = Convert.ToString(reader["actual_annual_CoS"]);
                            objEntity.actual_annual_margin = Convert.ToString(reader["actual_annual_margin"]);
                            lstApprovedPricingSolution.Add(objEntity);
                        }
                        objSOSInfo.lstFailedApprovedPricingSolution = lstApprovedPricingSolution;
                    }
                }
            }
            catch (Exception ex)
            {
                objSOSInfo.Status = Status.Failed;
                objSOSInfo.Message = ex.Message;
            }
            return objSOSInfo;
        }
        public SOSInfo InsertUploadedApprovedPricingSolutionData(SOSInfo sOSInfo)
        {
            SOSInfo objEntity = new SOSInfo();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SP_ApprovedPricing_UpdateUploadAction";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ApprovedPricingId", sOSInfo.ApprovedPricingId);
                    cmd.Parameters.AddWithValue("@Status", sOSInfo.APSStatus);
                    cmd.Parameters.Add("@ReturnId", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    sOSInfo.ReturnValue = Convert.ToInt32(cmd.Parameters["@ReturnId"].Value);
                    sOSInfo.Status = Status.Success;
                }
            }
            return objEntity;
        }
        public ApprovedPricingSolution UpdateAPIdStatus(ApprovedPricingSolution approvedPricingSolution)
        {
            ApprovedPricingSolution objEntity = new ApprovedPricingSolution();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SP_ApprovedPricing_UpdateAPIdStatus";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@APId", approvedPricingSolution.Id);
                    cmd.ExecuteNonQuery();
                    objEntity.Status = Status.Success;
                }
            }
            return objEntity;
        }
        public SOSInfo GetApprovedPricingDataByDealIdCompanyId(SOSInfo sOSInfo)
        {
            SOSInfo objSOSInfo = new SOSInfo();
            List<ApprovedPricingSolution> lstEntity = new List<ApprovedPricingSolution>();
            List<ApprovedPricingSolution> lstAccountEntity = new List<ApprovedPricingSolution>();
            List<ApprovedPricingSolution> lstSiteEntity = new List<ApprovedPricingSolution>();
            List<ApprovedPricingSolution> lstContactEntity = new List<ApprovedPricingSolution>();

            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_ApprovedPricing_GetDataByDeal_CompanyId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DealId", sOSInfo.DealId);
                        cmd.Parameters.AddWithValue("@CompanyId", sOSInfo.CompanyId);
                        cmd.Parameters.AddWithValue("@DataTypeId", sOSInfo.DataTypeId);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            objSOSInfo.ApprovedPricingId = string.IsNullOrEmpty(Convert.ToString(reader["ApprovedPricingId"])) ? 0 : Convert.ToInt32(reader["ApprovedPricingId"]);
                        }
                        reader.NextResult();
                        while (reader.Read())
                        {
                            ApprovedPricingSolution objEntity = new ApprovedPricingSolution();
                            objEntity.Id = string.IsNullOrEmpty(Convert.ToString(reader["APId"])) ? 0 : Convert.ToInt32(reader["APId"]);
                            objEntity.UploadStatus = string.IsNullOrEmpty(Convert.ToString(reader["UploadStatus"])) ? 0 : Convert.ToInt32(reader["UploadStatus"]);
                            objEntity.Sitecode = Convert.ToString(reader["Sitecode"]);
                            objEntity.Sitename = Convert.ToString(reader["Sitename"]);
                            objEntity.AccountNumber = Convert.ToString(reader["AccountNumber"]);
                            objEntity.AccountName = Convert.ToString(reader["AccountName"]);
                            objEntity.Wastetype = Convert.ToString(reader["Wastetype"]);
                            objEntity.WasteTypeId = string.IsNullOrEmpty(Convert.ToString(reader["WasteTypeId"])) ? 0 : Convert.ToInt32(reader["WasteTypeId"]);
                            objEntity.MaterialType = Convert.ToString(reader["MaterialType"]);
                            objEntity.MaterialTypeId = string.IsNullOrEmpty(Convert.ToString(reader["MaterialTypeId"])) ? 0 : Convert.ToInt32(reader["MaterialTypeId"]);
                            objEntity.ContainerType = Convert.ToString(reader["ContainerType"]);
                            objEntity.ContainerTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ContainerTypeId"])) ? 0 : Convert.ToInt32(reader["ContainerTypeId"]);
                            objEntity.ContainerSize = Convert.ToString(reader["ContainerSize"]);
                            objEntity.ContainerSizeId = string.IsNullOrEmpty(Convert.ToString(reader["ContainerSizeId"])) ? 0 : Convert.ToInt32(reader["ContainerSizeId"]);
                            objEntity.WeightType = Convert.ToString(reader["WeightType"]);
                            objEntity.quantity = Convert.ToString(reader["quantity"]);
                            objEntity.Frequency = Convert.ToString(reader["visits_per_weekly"]);
                            objEntity.FrequencyId = string.IsNullOrEmpty(Convert.ToString(reader["FrequencyId"])) ? 0 : Convert.ToInt32(reader["FrequencyId"]);
                            objEntity.CustPrice_price_per_lift = Convert.ToString(reader["CustPrice_price_per_lift"]);
                            objEntity.CustPrice_additional_charge = Convert.ToString(reader["CustPrice_additional_charge"]);
                            objEntity.CustPrice_additional_charge_frequency = Convert.ToString(reader["CustPrice_additional_charge_frequency"]);
                            objEntity.CustPrice_reason_for_additional_charge = Convert.ToString(reader["CustPrice_reason_for_additional_charge"]);
                            objEntity.CustPrice_transport = Convert.ToString(reader["CustPrice_transport"]);
                            objEntity.CustPrice_transport_per_quantity = Convert.ToString(reader["CustPrice_transport_per_quantity"]);
                            objEntity.CustPrice_minimum_transport_charge = Convert.ToString(reader["CustPrice_minimum_transport_charge"]);
                            objEntity.CustPrice_price_per_quantity = Convert.ToString(reader["CustPrice_price_per_quantity"]);
                            objEntity.CustPrice_quantity_type = Convert.ToString(reader["CustPrice_quantity_type"]);
                            objEntity.CustPrice_minimum_quantity = Convert.ToString(reader["CustPrice_minimum_quantity"]);
                            objEntity.CustPrice_max_quantity = Convert.ToString(reader["CustPrice_max_quantity"]);
                            objEntity.CustPrice_excess_weight_charge = Convert.ToString(reader["CustPrice_excess_weight_charge"]);
                            objEntity.CustPrice_rental_day_per_container = Convert.ToString(reader["CustPrice_rental_day_per_container"]);
                            objEntity.CustPrice_demurrage_charge_per_hour = Convert.ToString(reader["CustPrice_demurrage_charge_per_hour"]);
                            objEntity.CustPrice_actual_demurrage = Convert.ToString(reader["CustPrice_actual_demurrage"]);
                            objEntity.CustPrice_consignment_note_Charge_vist = Convert.ToString(reader["CustPrice_consignment_note_Charge_vist"]);
                            objEntity.ContrPrice_contractor_name = Convert.ToString(reader["ContrPrice_contractor_name"]);
                            objEntity.ContrPrice_depot = Convert.ToString(reader["ContrPrice_depot"]);
                            objEntity.ContrPrice_Cost_per_lift = Convert.ToString(reader["ContrPrice_Cost_per_lift"]);
                            objEntity.ContrPrice_additional_charge = Convert.ToString(reader["ContrPrice_additional_charge"]);
                            objEntity.ContrPrice_additional_charge_frequency = Convert.ToString(reader["ContrPrice_additional_charge_frequency"]);
                            objEntity.ContrPrice_reason_for_additional_charge = Convert.ToString(reader["ContrPrice_reason_for_additional_charge"]);
                            objEntity.ContrPrice_transportcost = Convert.ToString(reader["ContrPrice_transportcost"]);
                            objEntity.ContrPrice_transport_per_quantity = Convert.ToString(reader["ContrPrice_transport_per_quantity"]);
                            objEntity.ContrPrice_minimum_transport_charge = Convert.ToString(reader["ContrPrice_minimum_transport_charge"]);
                            objEntity.ContrPrice_price_per_quantity = Convert.ToString(reader["ContrPrice_price_per_quantity"]);
                            objEntity.ContrPrice_quantity_type = Convert.ToString(reader["ContrPrice_quantity_type"]);
                            objEntity.ContrPrice_minimum_quantity = Convert.ToString(reader["ContrPrice_minimum_quantity"]);
                            objEntity.ContrPrice_max_quantity = Convert.ToString(reader["ContrPrice_max_quantity"]);
                            objEntity.ContrPrice_excess_weight_charge = Convert.ToString(reader["ContrPrice_excess_weight_charge"]);
                            objEntity.ContrPrice_rental_day_per_container = Convert.ToString(reader["ContrPrice_rental_day_per_container"]);
                            objEntity.ContrPrice_demurrage_charge_per_hour = Convert.ToString(reader["ContrPrice_demurrage_charge_per_hour"]);
                            objEntity.ContrPrice_actual_demurrage = Convert.ToString(reader["ContrPrice_actual_demurrage"]);
                            objEntity.ContrPrice_consignment_note_visit = Convert.ToString(reader["ContrPrice_consignment_note_visit"]);
                            objEntity.ContrPrice_EndDestinationType = Convert.ToString(reader["ContrPrice_EndDestinationType"]);
                            objEntity.Service_PONumber = Convert.ToString(reader["Service_PONumber"]);
                            objEntity.Service_TicketNo = Convert.ToString(reader["Service_TicketNo"]);
                            objEntity.Service_DeliveryDate = Convert.ToString(reader["Service_DeliveryDate"]);
                            objEntity.Service_Monday = string.IsNullOrEmpty(Convert.ToString(reader["Service_Monday"])) ? false : Convert.ToBoolean(Convert.ToInt32(reader["Service_Monday"]));
                            objEntity.Service_Tuesday = string.IsNullOrEmpty(Convert.ToString(reader["Service_Tuesday"])) ? false : Convert.ToBoolean(Convert.ToInt32(reader["Service_Tuesday"]));
                            objEntity.Service_Wednesday = string.IsNullOrEmpty(Convert.ToString(reader["Service_Wednesday"])) ? false : Convert.ToBoolean(Convert.ToInt32(reader["Service_Wednesday"]));
                            objEntity.Service_Thursday = string.IsNullOrEmpty(Convert.ToString(reader["Service_Thursday"])) ? false : Convert.ToBoolean(Convert.ToInt32(reader["Service_Thursday"]));
                            objEntity.Service_Friday = string.IsNullOrEmpty(Convert.ToString(reader["Service_Friday"])) ? false : Convert.ToBoolean(Convert.ToInt32(reader["Service_Friday"]));
                            objEntity.Service_Saturday = string.IsNullOrEmpty(Convert.ToString(reader["Service_Saturday"])) ? false : Convert.ToBoolean(Convert.ToInt32(reader["Service_Saturday"]));
                            objEntity.Service_Sunday = string.IsNullOrEmpty(Convert.ToString(reader["Service_Sunday"])) ? false : Convert.ToBoolean(Convert.ToInt32(reader["Service_Sunday"]));
                            objEntity.Service_InternalComments = Convert.ToString(reader["Service_InternalComments"]);
                            objEntity.Service_BagType = Convert.ToString(reader["Service_BagType"]);
                            objEntity.Service_BagTypeId = string.IsNullOrEmpty(Convert.ToString(reader["Service_BagTypeId"])) ? 0 : Convert.ToInt32(reader["Service_BagTypeId"]);
                            objEntity.custom_field1 = Convert.ToString(reader["custom_field1"]);
                            objEntity.custom_field2 = Convert.ToString(reader["custom_field2"]);
                            objEntity.custom_field3 = Convert.ToString(reader["custom_field3"]);
                            objEntity.custom_field4 = Convert.ToString(reader["custom_field4"]);
                            objEntity.custom_field5 = Convert.ToString(reader["custom_field5"]);

                            objEntity.actual_delivery_date = Convert.ToString(reader["actual_delivery_date"]);
                            objEntity.delivery_failure_reason = Convert.ToString(reader["delivery_failure_reason"]);
                            objEntity.losing_contractor_name = Convert.ToString(reader["losing_contractor_name"]);
                            objEntity.losing_contractor_email = Convert.ToString(reader["losing_contractor_email"]);
                            objEntity.removal_date_given_by_contractor = Convert.ToString(reader["removal_date_given_by_contractor"]);
                            objEntity.actual_removal_date_given_by_contractor = Convert.ToString(reader["actual_removal_date_given_by_contractor"]);
                            objEntity.cancel_letter_point_of_contact = Convert.ToString(reader["cancel_letter_point_of_contact"]);
                            objEntity.telephone_audit_req = Convert.ToString(reader["telephone_audit_req"]);
                            objEntity.room_for_dual_bins = Convert.ToString(reader["room_for_dual_bins"]);
                            objEntity.welcome_pack_sent_to_site = Convert.ToString(reader["welcome_pack_sent_to_site"]);
                            objEntity.mobilisation_comments = Convert.ToString(reader["mobilisation_comments"]);
                            objEntity.expected_annual_turnover = Convert.ToString(reader["expected_annual_turnover"]);
                            objEntity.expected_annual_CoS = Convert.ToString(reader["expected_annual_CoS"]);
                            objEntity.expected_annual_margin = Convert.ToString(reader["expected_annual_margin"]);
                            objEntity.actual_annual_turnover = Convert.ToString(reader["actual_annual_turnover"]);
                            objEntity.actual_annual_CoS = Convert.ToString(reader["actual_annual_CoS"]);
                            objEntity.actual_annual_margin = Convert.ToString(reader["actual_annual_margin"]);
                            lstEntity.Add(objEntity);
                        }
                        reader.NextResult();
                        while (reader.Read())
                        {
                            ApprovedPricingSolution objEntity = new ApprovedPricingSolution();
                            objEntity.AccountName = Convert.ToString(reader["AccountName"]);
                            objEntity.AccountNumber = Convert.ToString(reader["AccountNumber"]);
                            objEntity.AccountDescription = Convert.ToString(reader["AccountDescription"]);
                            objEntity.PaymentType = Convert.ToString(reader["PaymentType"]);
                            objEntity.UploadStatus = string.IsNullOrEmpty(Convert.ToString(reader["UploadStatus"])) ? 0 : Convert.ToInt32(reader["UploadStatus"]);
                            lstAccountEntity.Add(objEntity);
                        }
                        reader.NextResult();
                        while (reader.Read())
                        {
                            ApprovedPricingSolution objEntity = new ApprovedPricingSolution();
                            objEntity.Sitecode = Convert.ToString(reader["Sitecode"]);
                            objEntity.Sitename = Convert.ToString(reader["Sitename"]);
                            objEntity.Site_Addressline1 = Convert.ToString(reader["Site_Addressline1"]);
                            objEntity.Site_Addressline2 = Convert.ToString(reader["Site_Addressline2"]);
                            objEntity.Site_Town = Convert.ToString(reader["Site_Town"]);
                            objEntity.Site_county = Convert.ToString(reader["Site_county"]);
                            objEntity.Site_Postcode = Convert.ToString(reader["Site_Postcode"]);
                            objEntity.Site_Country = Convert.ToString(reader["Site_Country"]);
                            objEntity.Site_Region = Convert.ToString(reader["Site_Region"]);
                            objEntity.Site_AccessComments = Convert.ToString(reader["Site_AccessComments"]);
                            objEntity.UploadStatus = string.IsNullOrEmpty(Convert.ToString(reader["UploadStatus"])) ? 0 : Convert.ToInt32(reader["UploadStatus"]);
                            lstSiteEntity.Add(objEntity);
                        }
                        reader.NextResult();
                        while (reader.Read())
                        {
                            ApprovedPricingSolution objEntity = new ApprovedPricingSolution();
                            objEntity.ContactType = Convert.ToString(reader["ContactType"]);
                            objEntity.AccountName = Convert.ToString(reader["AccountName"]);
                            objEntity.AccountNumber = Convert.ToString(reader["AccountNumber"]);
                            objEntity.Sitecode = Convert.ToString(reader["Sitecode"]);
                            objEntity.Sitename = Convert.ToString(reader["Sitename"]);
                            objEntity.Title = Convert.ToString(reader["Title"]);
                            objEntity.FirstName = Convert.ToString(reader["FirstName"]);
                            objEntity.SurName = Convert.ToString(reader["SurName"]);
                            objEntity.ContactNumber = Convert.ToString(reader["ContactNumber"]);
                            objEntity.MainEmailAddress = Convert.ToString(reader["MainEmailAddress"]);
                            objEntity.AdditionalEmailAddress = Convert.ToString(reader["AdditionalEmailAddress"]);
                            objEntity.UploadStatus = string.IsNullOrEmpty(Convert.ToString(reader["UploadStatus"])) ? 0 : Convert.ToInt32(reader["UploadStatus"]);
                            lstContactEntity.Add(objEntity);
                        }
                        reader.Close();


                    }
                    objSOSInfo.lstApprovedPricingSolution = lstEntity;
                    objSOSInfo.lstAPSAccounts = lstAccountEntity;
                    objSOSInfo.lstAPSSites = lstSiteEntity;
                    objSOSInfo.lstAPSContacts = lstContactEntity;
                }
                objSOSInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objSOSInfo.Status = Status.Failed;
                objSOSInfo.Message = ex.Message;
            }

            return objSOSInfo;
        }

        public SOSInfo AddUpdateApprovedPricingSolution(SOSInfo sOSInfo)
        {
            
            SOSInfo objSOSInfo = new SOSInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_ApprovedPricing_Sales_InsertUpdateData";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DealId", sOSInfo.DealId);
                        cmd.Parameters.AddWithValue("@CompanyId", sOSInfo.CompanyId);
                        cmd.Parameters.AddWithValue("@APId", sOSInfo.ApprovedPricingSolution.Id);
                        cmd.Parameters.AddWithValue("@SiteCode", sOSInfo.ApprovedPricingSolution.Sitecode);
                        cmd.Parameters.AddWithValue("@SiteName", sOSInfo.ApprovedPricingSolution.Sitename);
                        cmd.Parameters.AddWithValue("@Wastetype", sOSInfo.ApprovedPricingSolution.Wastetype);
                        cmd.Parameters.AddWithValue("@WasteTypeId", sOSInfo.ApprovedPricingSolution.WasteTypeId);
                        cmd.Parameters.AddWithValue("@ewc", sOSInfo.ApprovedPricingSolution.ewc);
                        cmd.Parameters.AddWithValue("@MaterialType", sOSInfo.ApprovedPricingSolution.MaterialType);
                        cmd.Parameters.AddWithValue("@MaterialTypeId", sOSInfo.ApprovedPricingSolution.MaterialTypeId);
                        cmd.Parameters.AddWithValue("@ContainerType", sOSInfo.ApprovedPricingSolution.ContainerType);
                        cmd.Parameters.AddWithValue("@ContainerTypeId", sOSInfo.ApprovedPricingSolution.ContainerTypeId);
                        cmd.Parameters.AddWithValue("@ContainerSize", sOSInfo.ApprovedPricingSolution.ContainerSize);
                        cmd.Parameters.AddWithValue("@ContainerSizeId", sOSInfo.ApprovedPricingSolution.ContainerSizeId);
                        cmd.Parameters.AddWithValue("@AssumedContainerWeight", sOSInfo.ApprovedPricingSolution.AssumedContainerWeight);
                        cmd.Parameters.AddWithValue("@quantity", sOSInfo.ApprovedPricingSolution.quantity);
                        cmd.Parameters.AddWithValue("@visits_per_weekly", sOSInfo.ApprovedPricingSolution.EstimatedFrequency);
                        cmd.Parameters.AddWithValue("@FrequencyId", sOSInfo.ApprovedPricingSolution.FrequencyId);
                        cmd.Parameters.AddWithValue("@service_comments", sOSInfo.ApprovedPricingSolution.service_comments);
                        cmd.Parameters.AddWithValue("@CustPrice_price_per_lift", sOSInfo.ApprovedPricingSolution.CustPrice_price_per_lift);
                        cmd.Parameters.AddWithValue("@CustPrice_additional_charge", sOSInfo.ApprovedPricingSolution.CustPrice_additional_charge);
                        cmd.Parameters.AddWithValue("@CustPrice_additional_charge_frequency", sOSInfo.ApprovedPricingSolution.CustPrice_additional_charge_frequency);
                        cmd.Parameters.AddWithValue("@CustPrice_reason_for_additional_charge", sOSInfo.ApprovedPricingSolution.CustPrice_reason_for_additional_charge);
                        cmd.Parameters.AddWithValue("@CustPrice_transport", sOSInfo.ApprovedPricingSolution.CustPrice_transport);
                        cmd.Parameters.AddWithValue("@CustPrice_transport_per_quantity", sOSInfo.ApprovedPricingSolution.CustPrice_transport_per_quantity);
                        cmd.Parameters.AddWithValue("@CustPrice_minimum_transport_charge", sOSInfo.ApprovedPricingSolution.CustPrice_minimum_transport_charge);
                        cmd.Parameters.AddWithValue("@CustPrice_price_per_quantity", sOSInfo.ApprovedPricingSolution.CustPrice_price_per_quantity);
                        cmd.Parameters.AddWithValue("@CustPrice_quantity_type", sOSInfo.ApprovedPricingSolution.CustPrice_quantity_type);
                        cmd.Parameters.AddWithValue("@CustPrice_minimum_quantity", sOSInfo.ApprovedPricingSolution.CustPrice_minimum_quantity);
                        cmd.Parameters.AddWithValue("@CustPrice_max_quantity", sOSInfo.ApprovedPricingSolution.CustPrice_max_quantity);
                        cmd.Parameters.AddWithValue("@CustPrice_excess_weight_charge", sOSInfo.ApprovedPricingSolution.CustPrice_excess_weight_charge);
                        cmd.Parameters.AddWithValue("@CustPrice_rental_day_per_container", sOSInfo.ApprovedPricingSolution.CustPrice_rental_day_per_container);
                        cmd.Parameters.AddWithValue("@CustPrice_demurrage_charge_per_hour", sOSInfo.ApprovedPricingSolution.CustPrice_demurrage_charge_per_hour);
                        cmd.Parameters.AddWithValue("@CustPrice_actual_demurrage", sOSInfo.ApprovedPricingSolution.CustPrice_actual_demurrage);
                        cmd.Parameters.AddWithValue("@CustPrice_consignment_note_Charge_vist", sOSInfo.ApprovedPricingSolution.CustPrice_consignment_note_Charge_vist);
                        cmd.Parameters.AddWithValue("@ContrPrice_contractor_name", sOSInfo.ApprovedPricingSolution.ContrPrice_contractor_name);
                        cmd.Parameters.AddWithValue("@ContrPrice_depot", sOSInfo.ApprovedPricingSolution.ContrPrice_depot);
                        cmd.Parameters.AddWithValue("@ContrPrice_Cost_per_lift", sOSInfo.ApprovedPricingSolution.ContrPrice_Cost_per_lift);
                        cmd.Parameters.AddWithValue("@ContrPrice_additional_charge", sOSInfo.ApprovedPricingSolution.ContrPrice_additional_charge);
                        cmd.Parameters.AddWithValue("@ContrPrice_additional_charge_frequency", sOSInfo.ApprovedPricingSolution.ContrPrice_additional_charge_frequency);
                        cmd.Parameters.AddWithValue("@ContrPrice_reason_for_additional_charge", sOSInfo.ApprovedPricingSolution.ContrPrice_reason_for_additional_charge);
                        cmd.Parameters.AddWithValue("@ContrPrice_transportcost", sOSInfo.ApprovedPricingSolution.ContrPrice_transportcost);
                        cmd.Parameters.AddWithValue("@ContrPrice_transport_per_quantity", sOSInfo.ApprovedPricingSolution.ContrPrice_transport_per_quantity);
                        cmd.Parameters.AddWithValue("@ContrPrice_minimum_transport_charge", sOSInfo.ApprovedPricingSolution.CustPrice_minimum_transport_charge);
                        cmd.Parameters.AddWithValue("@ContrPrice_price_per_quantity", sOSInfo.ApprovedPricingSolution.ContrPrice_price_per_quantity);
                        cmd.Parameters.AddWithValue("@ContrPrice_quantity_type", sOSInfo.ApprovedPricingSolution.ContrPrice_quantity_type);
                        cmd.Parameters.AddWithValue("@ContrPrice_minimum_quantity", sOSInfo.ApprovedPricingSolution.ContrPrice_minimum_quantity);
                        cmd.Parameters.AddWithValue("@ContrPrice_max_quantity", sOSInfo.ApprovedPricingSolution.ContrPrice_max_quantity);
                        cmd.Parameters.AddWithValue("@ContrPrice_excess_weight_charge", sOSInfo.ApprovedPricingSolution.ContrPrice_excess_weight_charge);
                        cmd.Parameters.AddWithValue("@ContrPrice_rental_day_per_container", sOSInfo.ApprovedPricingSolution.ContrPrice_rental_day_per_container);
                        cmd.Parameters.AddWithValue("@ContrPrice_demurrage_charge_per_hour", sOSInfo.ApprovedPricingSolution.ContrPrice_demurrage_charge_per_hour);
                        cmd.Parameters.AddWithValue("@ContrPrice_actual_demurrage", sOSInfo.ApprovedPricingSolution.ContrPrice_actual_demurrage);
                        cmd.Parameters.AddWithValue("@ContrPrice_consignment_note_visit", sOSInfo.ApprovedPricingSolution.ContrPrice_consignment_note_visit);
                        cmd.Parameters.AddWithValue("@ContrPrice_EndDestinationType", sOSInfo.ApprovedPricingSolution.ContrPrice_EndDestinationType);
                        cmd.Parameters.AddWithValue("@Service_PONumber ", sOSInfo.ApprovedPricingSolution.Service_PONumber);
                        cmd.Parameters.AddWithValue("@Service_TicketNo", sOSInfo.ApprovedPricingSolution.Service_TicketNo);
                        cmd.Parameters.AddWithValue("@Service_BagType", sOSInfo.ApprovedPricingSolution.Service_BagType);
                        cmd.Parameters.AddWithValue("@Service_BagTypeId", sOSInfo.ApprovedPricingSolution.Service_BagTypeId);
                        cmd.Parameters.AddWithValue("@CreatedBy", sOSInfo.CreatedBy);
                        SqlDataReader reader = cmd.ExecuteReader();
                        objSOSInfo.ApprovedPricingSolution = new ApprovedPricingSolution();
                        while (reader.Read())
                        {
                            objSOSInfo.ApprovedPricingId = string.IsNullOrEmpty(Convert.ToString(reader["ApprovedPricingId"])) ? 0 : Convert.ToInt32(reader["ApprovedPricingId"]);
                        }
                        reader.NextResult();
                        while (reader.Read())
                        {
                            objSOSInfo.ApprovedPricingSolution.Id = string.IsNullOrEmpty(Convert.ToString(reader["APId"])) ? 0 : Convert.ToInt32(reader["APId"]);
                        }
                    }
                }
                objSOSInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objSOSInfo.Status = Status.Failed;
                objSOSInfo.Message = ex.Message;
                throw ex;
            }

            return objSOSInfo;
        }
        public SOSInfo AddUpdateApprovedPricingSolutionByMobilization(SOSInfo sOSInfo)
        {
            SOSInfo objSOSInfo = new SOSInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Sp_approvedpricing_mobi_insertupdatedata";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DealId", sOSInfo.DealId);
                        cmd.Parameters.AddWithValue("@CompanyId", sOSInfo.CompanyId);
                        cmd.Parameters.AddWithValue("@APId", sOSInfo.ApprovedPricingSolution.Id);
                        cmd.Parameters.AddWithValue("@SiteCode", sOSInfo.ApprovedPricingSolution.Sitecode);
                        cmd.Parameters.AddWithValue("@SiteName", sOSInfo.ApprovedPricingSolution.Sitename);
                        cmd.Parameters.AddWithValue("@Wastetype", sOSInfo.ApprovedPricingSolution.Wastetype);
                        cmd.Parameters.AddWithValue("@WasteTypeId", sOSInfo.ApprovedPricingSolution.WasteTypeId);
                        cmd.Parameters.AddWithValue("@ewc", sOSInfo.ApprovedPricingSolution.ewc);
                        cmd.Parameters.AddWithValue("@MaterialType", sOSInfo.ApprovedPricingSolution.MaterialType);
                        cmd.Parameters.AddWithValue("@MaterialTypeId", sOSInfo.ApprovedPricingSolution.MaterialTypeId);
                        cmd.Parameters.AddWithValue("@ContainerType", sOSInfo.ApprovedPricingSolution.ContainerType);
                        cmd.Parameters.AddWithValue("@ContainerTypeId", sOSInfo.ApprovedPricingSolution.ContainerTypeId);
                        cmd.Parameters.AddWithValue("@ContainerSize", sOSInfo.ApprovedPricingSolution.ContainerSize);
                        cmd.Parameters.AddWithValue("@ContainerSizeId", sOSInfo.ApprovedPricingSolution.ContainerSizeId);
                        cmd.Parameters.AddWithValue("@AssumedContainerWeight", sOSInfo.ApprovedPricingSolution.AssumedContainerWeight);
                        cmd.Parameters.AddWithValue("@quantity", sOSInfo.ApprovedPricingSolution.quantity);
                        cmd.Parameters.AddWithValue("@visits_per_weekly", sOSInfo.ApprovedPricingSolution.EstimatedFrequency);
                        cmd.Parameters.AddWithValue("@FrequencyId", sOSInfo.ApprovedPricingSolution.FrequencyId);
                        cmd.Parameters.AddWithValue("@service_comments", sOSInfo.ApprovedPricingSolution.service_comments);
                        cmd.Parameters.AddWithValue("@CustPrice_price_per_lift", sOSInfo.ApprovedPricingSolution.CustPrice_price_per_lift);
                        cmd.Parameters.AddWithValue("@CustPrice_additional_charge", sOSInfo.ApprovedPricingSolution.CustPrice_additional_charge);
                        cmd.Parameters.AddWithValue("@CustPrice_additional_charge_frequency", sOSInfo.ApprovedPricingSolution.CustPrice_additional_charge_frequency);
                        cmd.Parameters.AddWithValue("@CustPrice_reason_for_additional_charge", sOSInfo.ApprovedPricingSolution.CustPrice_reason_for_additional_charge);
                        cmd.Parameters.AddWithValue("@CustPrice_transport", sOSInfo.ApprovedPricingSolution.CustPrice_transport);
                        cmd.Parameters.AddWithValue("@CustPrice_transport_per_quantity", sOSInfo.ApprovedPricingSolution.CustPrice_transport_per_quantity);
                        cmd.Parameters.AddWithValue("@CustPrice_minimum_transport_charge", sOSInfo.ApprovedPricingSolution.CustPrice_minimum_transport_charge);
                        cmd.Parameters.AddWithValue("@CustPrice_price_per_quantity", sOSInfo.ApprovedPricingSolution.CustPrice_price_per_quantity);
                        cmd.Parameters.AddWithValue("@CustPrice_quantity_type", sOSInfo.ApprovedPricingSolution.CustPrice_quantity_type);
                        cmd.Parameters.AddWithValue("@CustPrice_minimum_quantity", sOSInfo.ApprovedPricingSolution.CustPrice_minimum_quantity);
                        cmd.Parameters.AddWithValue("@CustPrice_max_quantity", sOSInfo.ApprovedPricingSolution.CustPrice_max_quantity);
                        cmd.Parameters.AddWithValue("@CustPrice_excess_weight_charge", sOSInfo.ApprovedPricingSolution.CustPrice_excess_weight_charge);
                        cmd.Parameters.AddWithValue("@CustPrice_rental_day_per_container", sOSInfo.ApprovedPricingSolution.CustPrice_rental_day_per_container);
                        cmd.Parameters.AddWithValue("@CustPrice_demurrage_charge_per_hour", sOSInfo.ApprovedPricingSolution.CustPrice_demurrage_charge_per_hour);
                        cmd.Parameters.AddWithValue("@CustPrice_actual_demurrage", sOSInfo.ApprovedPricingSolution.CustPrice_actual_demurrage);
                        cmd.Parameters.AddWithValue("@CustPrice_consignment_note_Charge_vist", sOSInfo.ApprovedPricingSolution.CustPrice_consignment_note_Charge_vist);
                        cmd.Parameters.AddWithValue("@ContrPrice_contractor_name", sOSInfo.ApprovedPricingSolution.ContrPrice_contractor_name);
                        cmd.Parameters.AddWithValue("@ContrPrice_depot", sOSInfo.ApprovedPricingSolution.ContrPrice_depot);
                        cmd.Parameters.AddWithValue("@ContrPrice_Cost_per_lift", sOSInfo.ApprovedPricingSolution.ContrPrice_Cost_per_lift);
                        cmd.Parameters.AddWithValue("@ContrPrice_additional_charge", sOSInfo.ApprovedPricingSolution.ContrPrice_additional_charge);
                        cmd.Parameters.AddWithValue("@ContrPrice_additional_charge_frequency", sOSInfo.ApprovedPricingSolution.ContrPrice_additional_charge_frequency);
                        cmd.Parameters.AddWithValue("@ContrPrice_reason_for_additional_charge", sOSInfo.ApprovedPricingSolution.ContrPrice_reason_for_additional_charge);
                        cmd.Parameters.AddWithValue("@ContrPrice_transportcost", sOSInfo.ApprovedPricingSolution.ContrPrice_transportcost);
                        cmd.Parameters.AddWithValue("@ContrPrice_transport_per_quantity", sOSInfo.ApprovedPricingSolution.ContrPrice_transport_per_quantity);
                        cmd.Parameters.AddWithValue("@ContrPrice_minimum_transport_charge", sOSInfo.ApprovedPricingSolution.CustPrice_minimum_transport_charge);
                        cmd.Parameters.AddWithValue("@ContrPrice_price_per_quantity", sOSInfo.ApprovedPricingSolution.ContrPrice_price_per_quantity);
                        cmd.Parameters.AddWithValue("@ContrPrice_quantity_type", sOSInfo.ApprovedPricingSolution.ContrPrice_quantity_type);
                        cmd.Parameters.AddWithValue("@ContrPrice_minimum_quantity", sOSInfo.ApprovedPricingSolution.ContrPrice_minimum_quantity);
                        cmd.Parameters.AddWithValue("@ContrPrice_max_quantity", sOSInfo.ApprovedPricingSolution.ContrPrice_max_quantity);
                        cmd.Parameters.AddWithValue("@ContrPrice_excess_weight_charge", sOSInfo.ApprovedPricingSolution.ContrPrice_excess_weight_charge);
                        cmd.Parameters.AddWithValue("@ContrPrice_rental_day_per_container", sOSInfo.ApprovedPricingSolution.ContrPrice_rental_day_per_container);
                        cmd.Parameters.AddWithValue("@ContrPrice_demurrage_charge_per_hour", sOSInfo.ApprovedPricingSolution.ContrPrice_demurrage_charge_per_hour);
                        cmd.Parameters.AddWithValue("@ContrPrice_actual_demurrage", sOSInfo.ApprovedPricingSolution.ContrPrice_actual_demurrage);
                        cmd.Parameters.AddWithValue("@ContrPrice_consignment_note_visit", sOSInfo.ApprovedPricingSolution.ContrPrice_consignment_note_visit);
                        cmd.Parameters.AddWithValue("@ContrPrice_EndDestinationType", sOSInfo.ApprovedPricingSolution.ContrPrice_EndDestinationType);
                        cmd.Parameters.AddWithValue("@Service_PONumber", sOSInfo.ApprovedPricingSolution.Service_PONumber);
                        cmd.Parameters.AddWithValue("@Service_TicketNo", sOSInfo.ApprovedPricingSolution.Service_TicketNo);
                        cmd.Parameters.AddWithValue("@Service_BagType", sOSInfo.ApprovedPricingSolution.Service_BagType);
                        cmd.Parameters.AddWithValue("@Service_BagTypeId", sOSInfo.ApprovedPricingSolution.Service_BagTypeId);
                        cmd.Parameters.AddWithValue("@DeliveryDate", sOSInfo.ApprovedPricingSolution.Service_DeliveryDate);
                        cmd.Parameters.AddWithValue("@Monday", sOSInfo.ApprovedPricingSolution.Service_Monday);
                        cmd.Parameters.AddWithValue("@Tuesday", sOSInfo.ApprovedPricingSolution.Service_Tuesday);
                        cmd.Parameters.AddWithValue("@Wednesday", sOSInfo.ApprovedPricingSolution.Service_Wednesday);
                        cmd.Parameters.AddWithValue("@Thursday", sOSInfo.ApprovedPricingSolution.Service_Thursday);
                        cmd.Parameters.AddWithValue("@Friday", sOSInfo.ApprovedPricingSolution.Service_Friday);
                        cmd.Parameters.AddWithValue("@Saturday", sOSInfo.ApprovedPricingSolution.Service_Saturday);
                        cmd.Parameters.AddWithValue("@Sunday", sOSInfo.ApprovedPricingSolution.Service_Sunday);
                        cmd.Parameters.AddWithValue("@InternalComments", sOSInfo.ApprovedPricingSolution.Service_InternalComments);
                        cmd.Parameters.AddWithValue("@WeightType", sOSInfo.ApprovedPricingSolution.WeightType);

                        cmd.Parameters.AddWithValue("@actual_delivery_date", sOSInfo.ApprovedPricingSolution.actual_delivery_date);
                        cmd.Parameters.AddWithValue("@delivery_failure_reason", sOSInfo.ApprovedPricingSolution.delivery_failure_reason);
                        cmd.Parameters.AddWithValue("@losing_contractor_name", sOSInfo.ApprovedPricingSolution.losing_contractor_name);
                        cmd.Parameters.AddWithValue("@losing_contractor_email", sOSInfo.ApprovedPricingSolution.losing_contractor_email);
                        cmd.Parameters.AddWithValue("@removal_date_given_by_contractor", sOSInfo.ApprovedPricingSolution.removal_date_given_by_contractor);
                        cmd.Parameters.AddWithValue("@actual_removal_date_given_by_contractor", sOSInfo.ApprovedPricingSolution.actual_removal_date_given_by_contractor);
                        cmd.Parameters.AddWithValue("@cancel_letter_point_of_contact", sOSInfo.ApprovedPricingSolution.cancel_letter_point_of_contact);
                        cmd.Parameters.AddWithValue("@telephone_audit_req", sOSInfo.ApprovedPricingSolution.telephone_audit_req);
                        cmd.Parameters.AddWithValue("@room_for_dual_bins", sOSInfo.ApprovedPricingSolution.room_for_dual_bins);
                        cmd.Parameters.AddWithValue("@welcome_pack_sent_to_site", sOSInfo.ApprovedPricingSolution.welcome_pack_sent_to_site);
                        cmd.Parameters.AddWithValue("@mobilisation_comments", sOSInfo.ApprovedPricingSolution.mobilisation_comments);
                        cmd.Parameters.AddWithValue("@expected_annual_turnover", sOSInfo.ApprovedPricingSolution.expected_annual_turnover);
                        cmd.Parameters.AddWithValue("@expected_annual_CoS", sOSInfo.ApprovedPricingSolution.expected_annual_CoS);
                        cmd.Parameters.AddWithValue("@expected_annual_margin", sOSInfo.ApprovedPricingSolution.expected_annual_margin);
                        cmd.Parameters.AddWithValue("@actual_annual_turnover", sOSInfo.ApprovedPricingSolution.actual_annual_turnover);
                        cmd.Parameters.AddWithValue("@actual_annual_CoS", sOSInfo.ApprovedPricingSolution.actual_annual_CoS);
                        cmd.Parameters.AddWithValue("@actual_annual_margin", sOSInfo.ApprovedPricingSolution.actual_annual_margin);

                        cmd.Parameters.AddWithValue("@CreatedBy", sOSInfo.CreatedBy);
                        SqlDataReader reader = cmd.ExecuteReader();
                        objSOSInfo.ApprovedPricingSolution = new ApprovedPricingSolution();
                        while (reader.Read())
                        {
                            objSOSInfo.ApprovedPricingId = string.IsNullOrEmpty(Convert.ToString(reader["ApprovedPricingId"])) ? 0 : Convert.ToInt32(reader["ApprovedPricingId"]);
                        }
                        reader.NextResult();
                        while (reader.Read())
                        {
                            objSOSInfo.ApprovedPricingSolution.Id = string.IsNullOrEmpty(Convert.ToString(reader["APId"])) ? 0 : Convert.ToInt32(reader["APId"]);
                        }
                    }
                }
                objSOSInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objSOSInfo.Status = Status.Failed;
                objSOSInfo.Message = ex.Message;
                throw ex;
            }

            return objSOSInfo;
        }
        public SOSInfo DeleteApprovedPricingSolution(SOSInfo sOSInfo)
        {
            SOSInfo objSOSInfo = new SOSInfo();
            var results = 0;
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_ApprovedPricing_DeleteService";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@APids", sOSInfo.ApprovedPricingSolution.Id);
                        cmd.ExecuteNonQuery();
                        results = sOSInfo.ApprovedPricingSolution.Id;
                    }
                }
                if (results == 0)
                {
                    objSOSInfo.Status = Status.Failed;
                }
                else if (results > 0)
                {
                    objSOSInfo.ApprovedPricingSolution = new ApprovedPricingSolution();
                    objSOSInfo.ApprovedPricingSolution.Id = sOSInfo.ApprovedPricingSolution.Id;
                    objSOSInfo.Status = Status.Success;
                }
            }
            catch (Exception ex)
            {
                objSOSInfo.Status = Status.Failed;
                objSOSInfo.Message = ex.Message;
                throw ex;
            }

            return objSOSInfo;
        }

        public ApprovedPricingSolution GetApprovedPricingAccountbyAccountNumber(ApprovedPricingSolution approvedPricingSolution)
        {
            ApprovedPricingSolution objEntity = new ApprovedPricingSolution();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_ApprovedPricing_GetAccountByAccountNumber]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AccountNumber", approvedPricingSolution.AccountNumber);
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            objEntity.AccountName = Convert.ToString(reader["AccountName"]);
                            objEntity.AccountNumber = Convert.ToString(reader["AccountNumber"]);
                            objEntity.AccountDescription = Convert.ToString(reader["AccountDescription"]);
                            objEntity.PaymentType = Convert.ToString(reader["PaymentType"]);
                        }
                        reader.Close();
                    }
                }
                objEntity.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objEntity.Status = Status.Failed;
                objEntity.Message = ex.Message;
            }

            return objEntity;
        }

        public ApprovedPricingSolution GetApprovedPricingSitesbySiteCode(ApprovedPricingSolution approvedPricingSolution)
        {
            ApprovedPricingSolution objEntity = new ApprovedPricingSolution();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_ApprovedPricing_GetSiteBySitecode]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Sitecode", approvedPricingSolution.Sitecode);
                        cmd.Parameters.AddWithValue("@Sitename", approvedPricingSolution.Sitename);
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            objEntity.Sitecode = Convert.ToString(reader["Sitecode"]);
                            objEntity.Sitename = Convert.ToString(reader["Sitename"]);
                            objEntity.Site_Addressline1 = Convert.ToString(reader["Site_Addressline1"]);
                            objEntity.Site_Addressline2 = Convert.ToString(reader["Site_Addressline2"]);
                            objEntity.Site_Town = Convert.ToString(reader["Site_Town"]);
                            objEntity.Site_county = Convert.ToString(reader["Site_county"]);
                            objEntity.Site_Postcode = Convert.ToString(reader["Site_Postcode"]);
                            objEntity.Site_AccessComments = Convert.ToString(reader["Site_AccessComments"]);
                        }
                        reader.Close();
                    }
                }
                objEntity.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objEntity.Status = Status.Failed;
                objEntity.Message = ex.Message;
            }

            return objEntity;
        }

        public ApprovedPricingSolution GetApprovedPricingContactsByEmail(ApprovedPricingSolution approvedPricingSolution)
        {
            ApprovedPricingSolution objEntity = new ApprovedPricingSolution();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_ApprovedPricing_GetContactsByEmail]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MainEmailAddress", approvedPricingSolution.MainEmailAddress);
                        cmd.Parameters.AddWithValue("@ContactNumber", approvedPricingSolution.ContactNumber);
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            objEntity.ContactType = Convert.ToString(reader["ContactType"]);
                            objEntity.Title = Convert.ToString(reader["Title"]);
                            objEntity.FirstName = Convert.ToString(reader["FirstName"]);
                            objEntity.SurName = Convert.ToString(reader["SurName"]);
                            objEntity.ContactNumber = Convert.ToString(reader["ContactNumber"]);
                            objEntity.MainEmailAddress = Convert.ToString(reader["MainEmailAddress"]);
                            objEntity.AdditionalEmailAddress = Convert.ToString(reader["AdditionalEmailAddress"]);
                        }
                        reader.Close();
                    }
                }
                objEntity.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objEntity.Status = Status.Failed;
                objEntity.Message = ex.Message;
            }
            return objEntity;
        }

        public ApprovedPricingSolution UpdateApprovedPricingAccountbyAccountNumber(ApprovedPricingSolution approvedPricingSolution)
        {
            ApprovedPricingSolution objEntity = new ApprovedPricingSolution();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_ApprovedPricing_UpdateAccount]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AccountName", approvedPricingSolution.AccountName);
                        cmd.Parameters.AddWithValue("@AccountNumber", approvedPricingSolution.AccountNumber);
                        cmd.Parameters.AddWithValue("@AccountDescription", approvedPricingSolution.AccountDescription);
                        cmd.Parameters.AddWithValue("@PaymentType", approvedPricingSolution.PaymentType);
                        cmd.Parameters.AddWithValue("@CreatedBy", approvedPricingSolution.CreatedBy);
                        cmd.Parameters.Add("@ReturnId", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objEntity.AccountNumber = Convert.ToString(cmd.Parameters["@ReturnId"].Value);
                        objEntity.Status = Status.Success;
                    }
                }
            }
            catch (Exception ex)
            {
                objEntity.Status = Status.Failed;
                objEntity.Message = ex.Message;
            }

            return objEntity;
        }

        public ApprovedPricingSolution UpdateApprovedPricingSitesbySiteCode(ApprovedPricingSolution approvedPricingSolution)
        {
            ApprovedPricingSolution objEntity = new ApprovedPricingSolution();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_ApprovedPricing_UpdateSite]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Sitecode", approvedPricingSolution.Sitecode);
                        cmd.Parameters.AddWithValue("@Sitename", approvedPricingSolution.Sitename);
                        cmd.Parameters.AddWithValue("@Site_Addressline1", approvedPricingSolution.Site_Addressline1);
                        cmd.Parameters.AddWithValue("@Site_Addressline2", approvedPricingSolution.Site_Addressline2);
                        cmd.Parameters.AddWithValue("@Site_Town", approvedPricingSolution.Site_Town);
                        cmd.Parameters.AddWithValue("@Site_county", approvedPricingSolution.Site_county);
                        cmd.Parameters.AddWithValue("@Site_Postcode", approvedPricingSolution.Site_Postcode);
                        cmd.Parameters.AddWithValue("@Site_AccessComments", approvedPricingSolution.Site_AccessComments);
                        cmd.Parameters.AddWithValue("@CreatedBy", approvedPricingSolution.CreatedBy);
                        cmd.Parameters.Add("@ReturnId", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objEntity.Sitecode = Convert.ToString(cmd.Parameters["@ReturnId"].Value);
                        objEntity.Status = Status.Success;
                    }
                }
            }
            catch (Exception ex)
            {
                objEntity.Status = Status.Failed;
                objEntity.Message = ex.Message;
            }

            return objEntity;
        }

        public ApprovedPricingSolution UpdateApprovedPricingContactsByEmail(ApprovedPricingSolution approvedPricingSolution)
        {
            ApprovedPricingSolution objEntity = new ApprovedPricingSolution();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_ApprovedPricing_UpdateContacts]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContactType", approvedPricingSolution.ContactType);
                        cmd.Parameters.AddWithValue("@Title", approvedPricingSolution.Title);
                        cmd.Parameters.AddWithValue("@FirstName", approvedPricingSolution.FirstName);
                        cmd.Parameters.AddWithValue("@SurName", approvedPricingSolution.SurName);
                        cmd.Parameters.AddWithValue("@ContactNumber", approvedPricingSolution.ContactNumber);
                        cmd.Parameters.AddWithValue("@MainEmailAddress", approvedPricingSolution.MainEmailAddress);
                        cmd.Parameters.AddWithValue("@AdditionalEmailAddress", approvedPricingSolution.AdditionalEmailAddress);
                        cmd.Parameters.AddWithValue("@CreatedBy", approvedPricingSolution.CreatedBy);
                        cmd.Parameters.Add("@ReturnId", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objEntity.MainEmailAddress = Convert.ToString(cmd.Parameters["@ReturnId"].Value);
                        objEntity.Status = Status.Success;
                    }
                }
                objEntity.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objEntity.Status = Status.Failed;
                objEntity.Message = ex.Message;
            }
            return objEntity;
        }

        public ApprovedPricingSolution DeleteApprovedPricingAccountbyAccountNumber(ApprovedPricingSolution approvedPricingSolution)
        {
            ApprovedPricingSolution objEntity = new ApprovedPricingSolution();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_ApprovedPricing_DeleteAccount]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AccountNumber", approvedPricingSolution.AccountNumber);
                        cmd.Parameters.Add("@ReturnId", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objEntity.AccountNumber = Convert.ToString(cmd.Parameters["@ReturnId"].Value);
                        objEntity.Status = Status.Success;
                    }
                }
            }
            catch (Exception ex)
            {
                objEntity.Status = Status.Failed;
                objEntity.Message = ex.Message;
            }

            return objEntity;
        }

        public ApprovedPricingSolution DeleteApprovedPricingSitesbySiteCode(ApprovedPricingSolution approvedPricingSolution)
        {
            ApprovedPricingSolution objEntity = new ApprovedPricingSolution();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_ApprovedPricing_DeleteSite]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Sitecode", approvedPricingSolution.Sitecode);
                        cmd.Parameters.AddWithValue("@Sitename", approvedPricingSolution.Sitename);
                        cmd.Parameters.Add("@ReturnId", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objEntity.Sitecode = Convert.ToString(cmd.Parameters["@ReturnId"].Value);
                        objEntity.Status = Status.Success;
                    }
                }
            }
            catch (Exception ex)
            {
                objEntity.Status = Status.Failed;
                objEntity.Message = ex.Message;
            }

            return objEntity;
        }

        public ApprovedPricingSolution DeleteApprovedPricingContactsByEmail(ApprovedPricingSolution approvedPricingSolution)
        {
            ApprovedPricingSolution objEntity = new ApprovedPricingSolution();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_ApprovedPricing_DeleteContact]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContactNumber", approvedPricingSolution.ContactNumber);
                        cmd.Parameters.AddWithValue("@MainEmailAddress", approvedPricingSolution.MainEmailAddress);
                        cmd.Parameters.Add("@ReturnId", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objEntity.MainEmailAddress = Convert.ToString(cmd.Parameters["@ReturnId"].Value);
                        objEntity.Status = Status.Success;
                    }
                }
                objEntity.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objEntity.Status = Status.Failed;
                objEntity.Message = ex.Message;
            }
            return objEntity;
        }
        public SOSInfo BulkDeleteApprovedPricingSolution(SOSInfo sOSInfo)
        {
            SOSInfo objSOSInfo = new SOSInfo();
            var results = 0;
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    foreach (var approvedPricingSolution in sOSInfo.lstApprovedPricingSolution)
                    {
                        using (var cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = "SP_ApprovedPricing_DeleteService";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@APids", approvedPricingSolution.Id);
                            cmd.ExecuteNonQuery();
                            results = 1;
                        }
                    }
                }
                if (results == 0)
                {
                    objSOSInfo.Status = Status.Failed;
                }
                else if (results > 0)
                {
                    objSOSInfo.ReturnValue = 1;
                    objSOSInfo.Status = Status.Success;
                }
            }
            catch (Exception ex)
            {
                objSOSInfo.Status = Status.Failed;
                objSOSInfo.Message = ex.Message;
                throw ex;
            }
            return objSOSInfo;
        }
        public ApprovedPricingSolution BulkDeleteApprovedPricingAccountbyAccountNumber(List<ApprovedPricingSolution> lstApprovedPricingSolution)
        {
            ApprovedPricingSolution objEntity = new ApprovedPricingSolution();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    foreach (var approvedPricingSolution in lstApprovedPricingSolution)
                    {
                        using (var cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = "[dbo].[SP_ApprovedPricing_DeleteAccount]";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@AccountNumber", approvedPricingSolution.AccountNumber);
                            cmd.Parameters.Add("@ReturnId", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
                            cmd.ExecuteNonQuery();
                            objEntity.AccountNumber = Convert.ToString(cmd.Parameters["@ReturnId"].Value);
                            objEntity.Status = Status.Success;
                        }
                    }
                    objEntity.ReturnId = 1;
                }
            }
            catch (Exception ex)
            {
                objEntity.Status = Status.Failed;
                objEntity.Message = ex.Message;
            }

            return objEntity;
        }

        public ApprovedPricingSolution BulkDeleteApprovedPricingSitesbySiteCode(List<ApprovedPricingSolution> lstApprovedPricingSolution)
        {
            ApprovedPricingSolution objEntity = new ApprovedPricingSolution();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    foreach (var approvedPricingSolution in lstApprovedPricingSolution)
                    {
                        using (var cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = "[dbo].[SP_ApprovedPricing_DeleteSite]";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Sitecode", approvedPricingSolution.Sitecode);
                            cmd.Parameters.AddWithValue("@Sitename", approvedPricingSolution.Sitename);
                            cmd.Parameters.Add("@ReturnId", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
                            cmd.ExecuteNonQuery();
                            objEntity.Sitecode = Convert.ToString(cmd.Parameters["@ReturnId"].Value);
                            objEntity.Status = Status.Success;
                        }
                    }
                    objEntity.ReturnId = 1;
                }
            }
            catch (Exception ex)
            {
                objEntity.Status = Status.Failed;
                objEntity.Message = ex.Message;
            }

            return objEntity;
        }

        public ApprovedPricingSolution BulkDeleteApprovedPricingContactsByEmail(List<ApprovedPricingSolution> lstApprovedPricingSolution)
        {
            ApprovedPricingSolution objEntity = new ApprovedPricingSolution();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    foreach (var approvedPricingSolution in lstApprovedPricingSolution)
                    {
                        using (var cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = "[dbo].[SP_ApprovedPricing_DeleteContact]";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ContactNumber", approvedPricingSolution.ContactNumber);
                            cmd.Parameters.AddWithValue("@MainEmailAddress", approvedPricingSolution.MainEmailAddress);
                            cmd.Parameters.Add("@ReturnId", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
                            cmd.ExecuteNonQuery();
                            objEntity.MainEmailAddress = Convert.ToString(cmd.Parameters["@ReturnId"].Value);
                            objEntity.Status = Status.Success;
                        }
                    }
                    objEntity.ReturnId = 1;
                }
                objEntity.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objEntity.Status = Status.Failed;
                objEntity.Message = ex.Message;
            }
            return objEntity;
        }
    }
}
