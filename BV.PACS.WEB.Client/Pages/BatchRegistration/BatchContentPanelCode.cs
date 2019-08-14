using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BV.PACS.WEB.Client.I18nText;
using BV.PACS.WEB.Client.Services.Api;
using BV.PACS.WEB.Client.Shared.Base;
using BV.PACS.WEB.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BV.PACS.WEB.Client.Materials
{
    public class BatchContentPanelCode : TranslatablePanel<BatchContentPanel>
    {
        [Inject]
        protected LookupService ApiService { get; set; }

        [Inject]
        protected HttpClient Http { get; set; }


        protected TemplateLookupItem[] SourceTemplates { get; set; }
        protected TemplateLookupItem[] MaterialTemplates { get; set; }
        protected TemplateLookupItem[] AliquotTemplates { get; set; }

        protected TemplateLookupItem SourceTemplate { get; set; }
        protected TemplateLookupItem MaterialTemplate { get; set; }
        protected TemplateLookupItem AliquotTemplate { get; set; }

        protected int SourceCount { get; set; }
        protected int MaterialCount { get; set; }
        protected int AliquotCount { get; set; }

        protected List<BatchRegistrationDto> DataSource { get; set; } = new List<BatchRegistrationDto>();

        protected override async Task OnInitAsync()
        {
            await base.OnInitAsync();

            SourceTemplates = await ApiService.GetTemplatesLookup(Http, FormTypes.Source);
            MaterialTemplates = await ApiService.GetTemplatesLookup(Http, FormTypes.Material);
            AliquotTemplates = await ApiService.GetTemplatesLookup(Http, FormTypes.Aliquot);
        }

        protected void GenerateClick()
        {
            for (int sIndex = 0; sIndex < SourceCount; sIndex++)
            {
                for (int mIndex = 0; mIndex < MaterialCount; mIndex++)
                {
                    for (int aIndex = 0; aIndex < AliquotCount; aIndex++)
                    {
                        BatchRegistrationDto dto = new BatchRegistrationDto();
                        DataSource.Add(dto);
                    }
                }
            }
            
        }
    }
}