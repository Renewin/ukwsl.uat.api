using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class ImportActualWeightUDT
    {
        public string contractor_po_number { get; set; }
        public string site_name { get; set; }
        public string site_address { get; set; }
        public string site_town { get; set; }
        public string site_postcode { get; set; }
        public string waste_type { get; set; }
        public string material_type { get; set; }
        public string container_type { get; set; }
        public string container_Size { get; set; }
        public decimal actual_weight { get; set; }
        public string quantity_type1 { get; set; }
        public DateTime actual_collection_date { get; set; }
    }
}
