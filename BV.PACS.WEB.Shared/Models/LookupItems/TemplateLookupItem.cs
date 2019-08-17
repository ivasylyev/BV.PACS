namespace BV.PACS.WEB.Shared.Models
{
    public class TemplateLookupItem
    {
        [GetColumn("idfsReference")]
        public string Id { get; set; }

        [GetColumn("Name")]
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}