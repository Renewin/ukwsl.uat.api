namespace UKWSL.WMES.Business.Entities
{
    public class ContainerConfigurations : Log
    {
        public int CMpapingId { get; set; }
        public string WasteTypeName { get; set; }
        public int WasteTypeId { get; set; }
        public string MaterialTypeName { get; set; }
        public int MaterialTypeId { get; set; }
        public string ContainerTypeName { get; set; }
        public int ContainerTypeId { get; set; }
        public string ContainerSizeName { get; set; }
        public int ContainerSizeId { get; set; }
        public decimal AverageContainerWeightTonnes { get; set; }

    }
}
