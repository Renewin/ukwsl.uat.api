namespace UKWSL.WMES.Business.Entities
{
    /// <summary>
    /// Class for binding the Data grid fro schedule of service
    /// </summary>
    public class ScheduleService
    {
        public int TempSOSId { get; set; }
        public int SOSId { get; set; }

        public string Address_line1 { get; set; }

        public string Address_line2 { get; set; }

        public string SiteCode { get; set; }

        public string SiteName { get; set; }

        public string PostCode { get; set; }

        public string Address { get; set; }

        public string Town { get; set; }
        public string County { get; set; }

        public string WasteTypeName { get; set; }
        public string MaterialTypeName { get; set; }
        public string ContainerTypeName { get; set; }
        public string ContainerSizeName { get; set; }

        public string EWCCode { get; set; }

        public string QuantityTypeName { get; set; }
        public string Quantity { get; set; }
        public string FrequencyTypeName { get; set; }
        public string FrequencyName { get; set; }

        public string AverageContainerWeightTonnes { get; set; }
        public string PricingMethodName { get; set; }
        public string Comment { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string UploadComment { get; set; }
    }
}
