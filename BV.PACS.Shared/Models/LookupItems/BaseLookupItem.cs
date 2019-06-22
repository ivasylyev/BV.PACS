using System.ComponentModel.DataAnnotations.Schema;

namespace BV.PACS.Shared.Models
{
    public class BaseLookupItem
    {
        [Column("idfsReference")]
        public string Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("strDefault")]
        public string DefaultName { get; set; }

        [Column("intOrder")]
        public int Order { get; set; }

        public override string ToString()
         {
             return $"{Name} ({Id})";
         }
    }
}