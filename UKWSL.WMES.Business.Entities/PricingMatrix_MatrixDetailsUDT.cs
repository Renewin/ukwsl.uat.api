﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class PricingMatrix_MatrixDetailsUDT
    {
        public string PostCode { get; set; }
        public string WasteType { get; set; }
        public string MaterialType { get; set; }
        public string ContainerType { get; set; }
        public string ContainerSize { get; set; }
        public int QuantityFrom { get; set; }
        public int QuantityTo { get; set; }
        public decimal CustPrice_PricePerlift { get; set; }
        public decimal CustPrice_TransportCost { get; set; }
        public decimal CustPrice_TransportPerQuantity { get; set; }
        public decimal CustPrice_MinimumTransportCharge { get; set; }
        public decimal CustPrice_PricePerQuantity { get; set; }
        public string CustPrice_QuantityType { get; set; }
        public int CustPrice_MinimumQuantity { get; set; }
        public int CustPrice_MaxQuantity { get; set; }
        public decimal CustPrice_ExcessWeightCharge { get; set; }
        public decimal CustPrice_RentalPerUnit_PerDay { get; set; }
        public decimal CustPrice_DemurragePerHour { get; set; }
        public decimal CustPrice_ConsignmentNoteCharge_PerVisit { get; set; }
        public decimal ContPrice_CostPerlift { get; set; }
        public decimal ContrPrice_TransportCost { get; set; }
        public decimal ContrPrice_TransportPerQuantity { get; set; }
        public decimal ContrPrice_MinimumTransportCharge { get; set; }
        public decimal ContrPrice_CostPerQuantity { get; set; }
        public string ContrPrice_QuantityType { get; set; }
        public int ContrPrice_MinimumQuantity { get; set; }
        public int ContrPrice_MaxQuantity { get; set; }
        public decimal ContrPrice_ExcessWeightCharge { get; set; }
        public decimal ContrPrice_RentalPerUnit_PerDay { get; set; }
        public decimal ContrPrice_DemurragePerHour { get; set; }
        public decimal ContrPrice_ConsignmentNoteCharge_PerVisit { get; set; }
    }
}
