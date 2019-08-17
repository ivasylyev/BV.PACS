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
    public class BatchContentTemplatePanelCode : TranslatablePanel<BatchContentTemplatePanel>
    {
        [Inject]
        protected LookupService ApiService { get; set; }

        [Inject]
        protected HttpClient Http { get; set; }

        [Parameter]
        public Action<BatchTemplateViewModel> OnValidSubmit { get; set; }

        protected TemplateLookupItem[] SourceTemplates { get; set; }
        protected TemplateLookupItem[] MaterialTemplates { get; set; }
        protected TemplateLookupItem[] AliquotTemplates { get; set; }

        protected BatchTemplateViewModel TemplatesViewModel { get; set; } = new BatchTemplateViewModel();

        protected override async Task OnInitAsync()
        {
            await base.OnInitAsync();

            SourceTemplates = await ApiService.GetTemplatesLookup(Http, FormTypes.Source);
            MaterialTemplates = await ApiService.GetTemplatesLookup(Http, FormTypes.Material);
            AliquotTemplates = await ApiService.GetTemplatesLookup(Http, FormTypes.Aliquot);

            StateHasChanged();
        }

        protected void HandleValidSubmit()
        {
            OnValidSubmit?.Invoke(TemplatesViewModel);
            Console.WriteLine("OnValidSubmit");
        }

        protected void HandleInvalidSubmit()
        {
            Console.WriteLine("OnInvalidSubmit");
        }
    }
}