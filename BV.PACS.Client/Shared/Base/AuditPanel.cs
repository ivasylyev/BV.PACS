using System.Collections.Generic;
using System.Threading.Tasks;
using BV.PACS.Shared.Models;

namespace BV.PACS.Client.Shared.Base
{
    public class AuditPanel<TModel> : GridPanel<TModel> where TModel : AuditGridDto, new()
    {
        protected Dictionary<string, AuditGroupedDto<TModel>> GroupedData { get; set; }

        public void OnClick(string groupName)
        {
            GroupedData[groupName].GroupVisibility = !GroupedData[groupName].GroupVisibility;
            StateHasChanged();
        }

        protected override async Task OnInitAsync()
        {
            await base.OnInitAsync();
            GroupedData = new Dictionary<string, AuditGroupedDto<TModel>>();

            foreach (var dto in DataSource)
            {
                if (!GroupedData.ContainsKey(dto.GroupHeader))
                {
                    GroupedData.Add(dto.GroupHeader, new AuditGroupedDto<TModel>(dto.GroupHeader));
                }
                GroupedData[dto.GroupHeader].Data.Add(dto);
            }
        }
    }
}