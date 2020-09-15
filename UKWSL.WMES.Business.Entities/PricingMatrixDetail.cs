using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class PricingMatrixDetail: Log
    {
        public int PMId { get; set; }
        public int MatrixId { get; set; }
        public WasteType WasteType { get; set; }
        public MaterialType MaterialType { get; set; }
        public ContainerType ContainerType { get; set; }
        public ContainerSize ContainerSize { get; set; }
        public bool IsPostCodeSpecific { get; set; }
        public string Postcode { get; set; }
        public bool IsTiredRate { get; set; }
        public int? QuantityFrom { get; set; }
        public int? QuantityTo { get; set; }
        public bool IsPriceUpdated { get; set; }
        public string PMIds { get; set; }
        public int CanDelete { get; set; }

        public decimal? CustPricePerlift { get; set; }
        public decimal? CustTransportCost { get; set; }
        public decimal? CustTransportPerQuantity { get; set; }
        public decimal? CustMinimumTransportCharge { get; set; }
        public decimal? CustPricePerQuantity { get; set; }
        public int? CustQtyTypeId { get; set; }
        public int? CustMinimumQuantity { get; set; }
        public int? CustMaxQuantity { get; set; }
        public decimal? CustExcessWeightCharge { get; set; }
        public decimal? CustRentalPerUnit_PerDay { get; set; }
        public decimal? CustDemurragePerHour { get; set; }
        public decimal? CustConsignmentNoteCharge_PerVisit { get; set; }

        public decimal? ContrPricePerlift { get; set; }
        public decimal? ContrTransportCost { get; set; }
        public decimal? ContrTransportPerQuantity { get; set; }
        public decimal? ContrMinimumTransportCharge { get; set; }
        public decimal? ContrPricePerQuantity { get; set; }
        public int? ContrQtyTypeId { get; set; }
        public int? ContrMinimumQuantity { get; set; }
        public int? ContrMaxQuantity { get; set; }
        public decimal? ContrExcessWeightCharge { get; set; }
        public decimal? ContrRentalPerUnit_PerDay { get; set; }
        public decimal? ContrDemurragePerHour { get; set; }
        public decimal? ContrConsignmentNoteCharge_PerVisit { get; set; }

        public PricingMatrixDetail()
        {
            WasteType = new WasteType();
            MaterialType = new MaterialType();
            ContainerType = new ContainerType();
            ContainerSize = new ContainerSize();
        }
    }
}
