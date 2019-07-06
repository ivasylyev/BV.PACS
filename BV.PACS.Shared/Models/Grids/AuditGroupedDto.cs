using System.Collections.Generic;

namespace BV.PACS.Shared.Models
{
    public class AuditGroupedDto<T> where T : AuditGridDto, new()
    {
        public string GroupName { get; set; }
        public bool GroupVisibility { get; set; }

        public List<T> Data { get; set; }

        public AuditGroupedDto(string groupName)
        {
            GroupName = groupName;
            GroupVisibility = false;
            Data = new List<T>();
        }
    }
}