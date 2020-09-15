using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class ApprovedPricingSolutionUDT
    {
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string AccountDescription { get; set; }
        public string PaymentType { get; set; }
        public string AC_Title { get; set; }
        public string AC_FirstName { get; set; }
        public string AC_Surname { get; set; }
        public string AC_ContactNumber { get; set; }
        public string AC_MainEmailAddress { get; set; }
        public string AC_AdditionalEmailAddress { get; set; }
        public string AC_AddressLine1 { get; set; }
        public string AC_AddressLine2 { get; set; }
        public string AC_Town { get; set; }
        public string AC_County { get; set; }
        public string AC_Postcode { get; set; }       
        public string Sitecode { get; set; }
        public string Sitename { get; set; }
        public string Site_Addressline1 { get; set; }
        public string Site_Addressline2 { get; set; }
        public string Site_Town { get; set; }
        public string Site_county { get; set; }
        public string Site_Postcode { get; set; }
        public string Site_AccessComments { get; set; }
        public string SC_WC_Title { get; set; }
        public string SC_WC_FirstName { get; set; }
        public string SC_WC_Surname { get; set; }
        public string SC_WC_ContactNumber { get; set; }
        public string SC_WC_MainEmailAddress { get; set; }
        public string SC_WC_AdditionalEmailAddress { get; set; }
        public string SC_KC_Title { get; set; }
        public string SC_KC_FirstName { get; set; }
        public string SC_KC_Surname { get; set; }
        public string SC_KC_ContactNumber { get; set; }
        public string SC_KC_MainEmailAddress { get; set; }
        public string SC_KC_AdditionalEmailAddress { get; set; }
        public string Service_PONumber { get; set; }
        public string Service_TicketNo { get; set; }
        public string Wastetype { get; set; }
        public string MaterialType { get; set; }
        public string ContainerType { get; set; }
        public string ContainerSize { get; set; }  
        public string Service_BagType { get; set; }
        public string quantity { get; set; }
        public string visits_per_weekly { get; set; }
        public string service_comments { get; set; }
        public string CustPrice_price_per_lift { get; set; }
        public string CustPrice_additional_charge { get; set; }
        public string CustPrice_additional_charge_frequency { get; set; }
        public string CustPrice_reason_for_additional_charge { get; set; }
        public string CustPrice_transport { get; set; }
        public string CustPrice_transport_per_quantity { get; set; }
        public string CustPrice_minimum_transport_charge { get; set; }
        public string CustPrice_price_per_quantity { get; set; }
        public string CustPrice_quantity_type { get; set; }
        public string CustPrice_minimum_quantity { get; set; }
        public string CustPrice_max_quantity { get; set; }
        public string CustPrice_excess_weight_charge { get; set; }
        public string CustPrice_rental_day_per_container { get; set; }
        public string CustPrice_demurrage_charge_per_hour { get; set; }
        public string CustPrice_actual_demurrage { get; set; }
        public string CustPrice_consignment_note_Charge_vist { get; set; }
        public string WeightType { get; set; }
        public string Service_DeliveryDate { get; set; }
        public string Service_Monday { get; set; }
        public string Service_Tuesday { get; set; }
        public string Service_Wednesday { get; set; }
        public string Service_Thursday { get; set; }
        public string Service_Friday { get; set; }
        public string Service_Saturday { get; set; }
        public string Service_Sunday { get; set; }
        public string Service_InternalComments { get; set; }
        public string ContrPrice_contractor_name { get; set; }
        public string ContrPrice_depot { get; set; }
        public string ContrPrice_Cost_per_lift { get; set; }
        public string ContrPrice_additional_charge { get; set; }
        public string ContrPrice_additional_charge_frequency { get; set; }
        public string ContrPrice_reason_for_additional_charge { get; set; }
        public string ContrPrice_transportcost { get; set; }
        public string ContrPrice_transport_per_quantity { get; set; }
        public string ContrPrice_minimum_transport_charge { get; set; }
        public string ContrPrice_price_per_quantity { get; set; }
        public string ContrPrice_quantity_type { get; set; }
        public string ContrPrice_minimum_quantity { get; set; }
        public string ContrPrice_max_quantity { get; set; }
        public string ContrPrice_excess_weight_charge { get; set; }
        public string ContrPrice_rental_day_per_container { get; set; }
        public string ContrPrice_demurrage_charge_per_hour { get; set; }
        public string ContrPrice_actual_demurrage { get; set; }
        public string ContrPrice_consignment_note_visit { get; set; }
        public string ContrPrice_EndDestination { get; set; }
        public string custom_field1 { get; set; }
        public string custom_field2 { get; set; }
        public string custom_field3 { get; set; }
        public string custom_field4 { get; set; }
        public string custom_field5 { get; set; }
        //DP 4.4 changes
        public string actual_delivery_date { get; set; }
        public string delivery_failure_reason { get; set; }
        public string losing_contractor_name { get; set; }
        public string losing_contractor_email { get; set; }
        public string removal_date_given_by_contractor { get; set; }
        public string actual_removal_date_given_by_contractor { get; set; }
        public string cancel_letter_point_of_contact { get; set; }
        public string telephone_audit_req { get; set; }
        public string room_for_dual_bins { get; set; }
        public string welcome_pack_sent_to_site { get; set; }
        public string mobilisation_comments { get; set; }
        public string expected_annual_turnover { get; set; }
        public string expected_annual_CoS { get; set; }
        public string expected_annual_margin { get; set; }
        public string actual_annual_turnover { get; set; }
        public string actual_annual_CoS { get; set; }
        public string actual_annual_margin { get; set; }
    }
}
