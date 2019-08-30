namespace BV.PACS.WEB.Shared.Models
{
    public class BatchRegistrationDto
    {
        public int SourceId { get; set; }

        public TemplateLookupItem SourceTemplate { get; set; }

        public string SourceBarcode { get; set; }

        public string SourceNote { get; set; }

        public string SourceTypeId { get; set; }

        public string SourceType { get; set; }

        public int? SourceOwnerId { get; set; }

        public string SourceGeoLocationId { get; set; }

        public int MaterialId { get; set; }

        public TemplateLookupItem MaterialTemplate { get; set; }

        public string MaterialBarcode { get; set; }

        public string MaterialNote { get; set; }

        public string MaterialTypeId { get; set; }

        public string MaterialType { get; set; }

        public int? MaterialOwnerId { get; set; }

        public string MaterialGeoLocationId { get; set; }

        public int AliquotId { get; set; }


        public TemplateLookupItem AliquotTemplate { get; set; }

        public string AliquotBarcode { get; set; }

        public string AliquotNote { get; set; }

        public int? AliquotSubdivision { get; set; }

        public string AliquotStructureAlpha { get; set; }

        public int? AliquotStructureNumber { get; set; }

        public double? AliquotVolume { get; set; }

        public string AliquotVolumeUnit { get; set; }

        public int? AliquotGeneration { get; set; }

        public double? AliquotWeight { get; set; }

        public string AliquotWeightUnit { get; set; }

        public string AliquotDerivativeType { get; set; }

        public string AliquotStatus { get; set; }

        public string AliquotLocation { get; set; }

        public override string ToString()
        {
            return $"Source Id:'{SourceBarcode}', Material Id: {MaterialBarcode}, Aliquot Id:{AliquotBarcode}";
        }
    }
}