using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BV.PACS.WEB.Client.I18nText;
using BV.PACS.WEB.Client.Services.Api;
using BV.PACS.WEB.Client.Shared.Base;
using BV.PACS.WEB.Client.Shared.ViewModels;
using BV.PACS.WEB.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BV.PACS.WEB.Client.Materials
{
    public class BatchContentGridPanelCode : TranslatablePanel<BatchContentGridPanel>
    {
        [Inject]
        protected LookupService ApiService { get; set; }

        [Inject]
        protected HttpClient Http { get; set; }


        protected TemplateLookupItem[] SourceTemplates { get; set; }
        protected TemplateLookupItem[] MaterialTemplates { get; set; }
        protected TemplateLookupItem[] AliquotTemplates { get; set; }


        protected List<BatchRegistrationDto> DataSource { get; set; } = new List<BatchRegistrationDto>();

        protected override async Task OnInitAsync()
        {
            await base.OnInitAsync();

            SourceTemplates = await ApiService.GetTemplatesLookup(Http, FormTypes.Source);
            MaterialTemplates = await ApiService.GetTemplatesLookup(Http, FormTypes.Material);
            AliquotTemplates = await ApiService.GetTemplatesLookup(Http, FormTypes.Aliquot);
        }


        public void HandleValidSubmit(BatchTemplateViewModel model)
        {
            Console.WriteLine("OnValidSubmit");

            for (var sIndex = 0; sIndex < model.SourceCount; sIndex++)
            {
                var sourceTemplate = SourceTemplates.FirstOrDefault(s => s.Id == model.SourceTemplate.Id);
                for (var mIndex = 0; mIndex < model.MaterialCount; mIndex++)
                {
                    var materialTemplate = MaterialTemplates.FirstOrDefault(m => m.Id == model.MaterialTemplate.Id);
                    for (var aIndex = 0; aIndex < model.AliquotCount; aIndex++)
                    {
                        var aliquotTemplate = AliquotTemplates.FirstOrDefault(a => a.Id == model.AliquotTemplate.Id);
                        var dto = new BatchRegistrationDto
                        {
                            SourceTemplate = sourceTemplate,
                            MaterialTemplate = materialTemplate,
                            AliquotTemplate = aliquotTemplate
                        };
                        DataSource.Add(dto);
                    }
                }
            }

            StateHasChanged();
        }


        protected void OnRowUpdating(BatchRegistrationDto item, Dictionary<string, object> newValue)
        {
            if (item != null && newValue != null)
            {
                foreach (var field in newValue)
                {
                    Console.WriteLine(field.Key);
                    Console.WriteLine(field.Value);
                    switch (field.Key)
                    {
                        case nameof(BatchRegistrationDto.SourceTemplate):
                            if (field.Value is TemplateLookupItem sTemplate)
                            {
                                item.SourceTemplate = sTemplate;
                            }

                            break;
                        case nameof(BatchRegistrationDto.MaterialTemplate):
                            if (field.Value is TemplateLookupItem mTemplate)
                            {
                                item.SourceTemplate = mTemplate;
                            }

                            break;
                        case nameof(BatchRegistrationDto.AliquotTemplate):
                            if (field.Value is TemplateLookupItem aTemplate)
                            {
                                item.SourceTemplate = aTemplate;
                            }

                            break;
                    }
                }
            }
        }
    }
}