namespace BV.PACS.WEB.Shared.Models
{
    public class BaseLookupItem
    {
        [GetColumn("idfsReference")]
        public string Id { get; set; }

        [GetColumn("Name")]
        public string Name { get; set; }

        [GetColumn("strDefault")]
        public string DefaultName { get; set; }

        [GetColumn("intOrder")]
        public int Order { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Id})";
        }
    }
}