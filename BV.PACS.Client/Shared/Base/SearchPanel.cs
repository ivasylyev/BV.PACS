using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BV.PACS.Client.Services.Api;
using BV.PACS.Shared.Models;
using BV.PACS.Shared.Utils;
using Microsoft.AspNetCore.Components;
using Toolbelt.Blazor.I18nText.Interfaces;

namespace BV.PACS.Client.Shared.Base
{
    public class SearchPanel<TTranslation> : TranslatablePanel<TTranslation>  
        where TTranslation : class, I18nTextFallbackLanguage, new()
    {
        [Inject]
        protected LookupService ApiService { get; set; }

        [Inject]
        protected HttpClient Http { get; set; }

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
                ? await ApiService.GetTemplatesLookup(Http, templateAttribute.FormType)
                : new TemplateLookupItem[0];
        }
    }
}