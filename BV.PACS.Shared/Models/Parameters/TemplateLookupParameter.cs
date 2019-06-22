namespace BV.PACS.Shared.Models.Parameters
{
    public class TemplateLookupParameter
    {
        public string LookupType { get; set; }
        public string Language { get; set; }

        public TemplateLookupParameter(string lookupType, string language)
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