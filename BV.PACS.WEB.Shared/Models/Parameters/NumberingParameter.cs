namespace BV.PACS.WEB.Shared.Models.Parameters
{
    public class NumberingParameter
    {
        public string Name { get; set; }
        public int Count { get; set; }

        public NumberingParameter(string name, int count)
        {
            Name = name;
            Count = count;
        }
    }
}