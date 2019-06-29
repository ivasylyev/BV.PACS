using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BV.PACS.Shared.Models;
using BV.PACS.Shared.Models.Parameters;
using BV.PACS.Shared.Utils;
using Microsoft.AspNetCore.Components;

namespace BV.PACS.Client.Shared.Base
{
    public class SearchPanel : ComponentBase
    {
        [Inject]
        private HttpClient Http { get; set; }

        [Parameter]
        public Action<AggregatedConditionDto> OnSearch { get; set; }

        protected TemplateLookupItem[] Templates { get; set; }
        protected TemplateLookupItem Template { get; set; }

        protected DateTime StartDate { get; set; }
        protected DateTime EndDate { get; set; }

        protected string StartDateText => StartDate.Date.ToString(GlobalSettings.AnsiDateTimeFormatInfo);
        protected string EndDateText => EndDate.Date.ToString(GlobalSettings.AnsiDateTimeFormatInfo);

        protected override async Task OnInitAsync()
        {
            StartDate = DateTime.Now.Date.AddYears(-1);
            EndDate = DateTime.Now.Date;

            var attr = GetType().GetCustomAttributes(typeof(FormTemplateAttribute), true).FirstOrDefault();
            Templates = attr is FormTemplateAttribute templateAttribute
                ? await GetTemplatesLookup(templateAttribute.FormType)
                : new TemplateLookupItem[0];
        }


        protected async Task<TemplateLookupItem[]> GetTemplatesLookup(string lookupType)
        {
            return await Http.PostJsonAsync<TemplateLookupItem[]>("api/Lookup/GetTemplatesLookup",
                new TemplateLookupParameter(lookupType, GlobalSettings.CurrentLanguage));
        }

        protected async Task<BaseLookupItem[]> GetLookup(BaseLookupTables lookupType)
        {
            return await Http.PostJsonAsync<BaseLookupItem[]>("api/Lookup/GetLookup",
                new BaseLookupParameter(lookupType, GlobalSettings.CurrentLanguage));
        }
    }
}