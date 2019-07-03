using System.ComponentModel.DataAnnotations.Schema;

namespace BV.PACS.Shared.Models
{
    public class TemplateLookupItem
    {
        [GetColumn("idfsReference")]
        public string Id { get; set; }

        [GetColumn("Name")]
        public string Name { get; set; }
         
         public override string ToString()
         {
             return $"{Name} ({Id})";
         }
    }
}