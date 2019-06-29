namespace BV.PACS.Shared.Models.Parameters
{
    public class TrackingParameter
    {
        public int Id { get; set; }
        public string Language { get; set; }

        public TrackingParameter(int id, string language)
        {
            Id = id;
            Language = language;
        }

        public override string ToString()
        {
            return $"{Id}, {Language}";
        }
    }
}