namespace BV.PACS.Shared.Models.Parameters
{
    public class LookupParameter
    {
        public BaseLookupTables LookupType { get; set; }
        public string Language { get; set; }

        public LookupParameter(BaseLookupTables lookupType, string language)
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