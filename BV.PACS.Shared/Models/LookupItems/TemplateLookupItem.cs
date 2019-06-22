using System.ComponentModel.DataAnnotations.Schema;

namespace BV.PACS.Shared.Models
{
    public class TemplateLookupItem
    {
        [Column("idfsReference")]
        public string Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }
         
         public override string ToString()
         {
             return $"{Name} ({Id})";
         }
    }
}