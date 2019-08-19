namespace BV.PACS.WEB.Shared.Models.Parameters
{
    public class SourceMaterialTypeLookupParameter
    {
        public const string Material = "Material";
        public const string Source = "Source";
        public string LookupType { get; set; }
        public string Language { get; set; }

        public SourceMaterialTypeLookupParameter(string lookupType, string language)
        {
            LookupType = lookupType;
            Language = language;
        }

        public override string ToString()
        {
            return $"{LookupType}, {Language}";
        }
    }
}