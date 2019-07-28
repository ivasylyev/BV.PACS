namespace BV.PACS.WEB.Shared.Models.Parameters
{
    public class TrackingPostParameter<T> where T:new()
    {
        public T Data { get; set; }
        public string Language { get; set; }

        public TrackingPostParameter(T data, string language)
        {
            Data = data;
            Language = language;
        }

        public override string ToString()
        {
            return $"{Data}, {Language}";
        }
    }
}