using System;
using System.Collections.Generic;
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
    public class BatchContentPanelCode : TranslatablePanel<BatchContentPanel>
    {
        [Inject]
        protected LookupService ApiService { get; set; }

        [Inject]
        protected HttpClient Http { get; set; }


        protected TemplateLookupItem[] SourceTemplates { get; set; }
        protected TemplateLookupItem[] MaterialTemplates { get; set; }
        protected TemplateLookupItem[] AliquotTemplates { get; set; }

        protected BatchTemplateViewModel TemplatesViewModel { get; set; } = new BatchTemplateViewModel();
        protected List<BatchRegistrationDto> DataSource { get; set; } = new List<BatchRegistrationDto>();

        protected override async Task OnInitAsync()
        {
            await base.OnInitAsync();

            SourceTemplates = await ApiService.GetTemplatesLookup(Http, FormTypes.Source);
            MaterialTemplates = await ApiService.GetTemplatesLookup(Http, FormTypes.Material);
            AliquotTemplates = await ApiService.GetTemplatesLookup(Http, FormTypes.Aliquot);
        }


        protected void HandleValidSubmit()
        {
            Console.WriteLine("OnValidSubmit");

            for (var sIndex = 0; sIndex < TemplatesViewModel.SourceCount; sIndex++)
            {
                for (var mIndex = 0; mIndex < TemplatesViewModel.MaterialCount; mIndex++)
                {
                    for (var aIndex = 0; aIndex < TemplatesViewModel.AliquotCount; aIndex++)
                    {
                        var dto = new BatchRegistrationDto
                        {
                            SourceTemplate = TemplatesViewModel.SourceTemplate,
                            MaterialTemplate = TemplatesViewModel.MaterialTemplate,
                            AliquotTemplate = TemplatesViewModel.AliquotTemplate
                        };
                        DataSource.Add(dto);
                    }
                }
            }

            StateHasChanged();
        }

        protected void HandleInvalidSubmit()
        {
            Console.WriteLine("OnInvalidSubmit");
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
                        case nameof(BatchRegistrationDto.SourceTemplateName):
                            if (field.Value is TemplateLookupItem template)
                            {
                                item.SourceTemplate = template;
                                Console.WriteLine($"SelectedTEmp= {template}");
                            }
                            break;
                        
                    }
                }
            }
        }
    }
}