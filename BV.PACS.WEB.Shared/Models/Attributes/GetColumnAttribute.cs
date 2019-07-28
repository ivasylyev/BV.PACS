using System.ComponentModel.DataAnnotations.Schema;

namespace BV.PACS.WEB.Shared.Models
{
    // ReSharper disable once InconsistentNaming
    public class GetColumnAttribute: ColumnAttribute
    {
        public GetColumnAttribute()
        {
        }

        public GetColumnAttribute(string name) : base(name)
        {
        }
    }
}