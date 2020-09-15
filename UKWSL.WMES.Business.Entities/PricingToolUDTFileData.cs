using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
   public class PricingToolUDTFileData
    {

        public int Data_ID { get; set; }
        public string PostCode { get; set; }
        public string Quantity { get; set; }
        public  string Visits { get; set; }
        public string MaterialTypeName { get; set; }
        public string ContainerTypeName { get; set; }
        public string ContainerSizeName { get; set; }
        public string No_Suppliers { get; set; }
        public string Preferred_Supplier { get; set; }
        public string Preferred_Supplier_Name { get; set; }

        public decimal Preferred_Price { get; set; }

        public string ContractorName_1 { get; set; }
        public decimal Price_1 { get; set; }

        public string ContractorName_2 { get; set; }
        public decimal Price_2 { get; set; }

        public string ContractorName_3 { get; set; }
        public decimal Price_3 { get; set; }

        public string ContractorName_4 { get; set; }
        public decimal Price_4 { get; set; }

        public string ContractorName_5 { get; set; }
        public decimal Price_5 { get; set; }
    }
}
