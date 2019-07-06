using System.Collections.Generic;
using System.Threading.Tasks;
using BV.PACS.Shared.Models;

namespace BV.PACS.Client.Shared.Base
{
    public class AuditPanel<T> : GridPanel<T> where T : AuditGridDto, new()
    {
        protected Dictionary<string, AuditGroupedDto<T>> GroupedSource { get; set; }

        public void OnClick(string groupName)
        {
            GroupedSource[groupName].GroupVisibility = !GroupedSource[groupName].GroupVisibility;
            StateHasChanged();
        }

        protected override async Task OnInitAsync()
        {
            await base.OnInitAsync();
            GroupedSource = new Dictionary<string, AuditGroupedDto<T>>();

            foreach (var dto in DataSource)
            {
                if (!GroupedSource.ContainsKey(dto.GroupHeader))
                {
                    GroupedSource.Add(dto.GroupHeader, new AuditGroupedDto<T>(dto.GroupHeader));
                }
                GroupedSource[dto.GroupHeader].Data.Add(dto);
            }
        }
    }
}