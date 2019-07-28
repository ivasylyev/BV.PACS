namespace BV.PACS.WEB.Shared.Models.Parameters
{
    public class GridParameter
    {
        public int Id { get; set; }
        public string Language { get; set; }

        public GridParameter(int id, string language)
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