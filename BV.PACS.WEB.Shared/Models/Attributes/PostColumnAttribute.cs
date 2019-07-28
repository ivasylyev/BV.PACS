using System.ComponentModel.DataAnnotations.Schema;

namespace BV.PACS.WEB.Shared.Models
{
    public class PostColumnAttribute : ColumnAttribute
    {
        public PostColumnAttribute()
        {
        }

        public PostColumnAttribute(string name) : base(name)
        {
        }
    }
}