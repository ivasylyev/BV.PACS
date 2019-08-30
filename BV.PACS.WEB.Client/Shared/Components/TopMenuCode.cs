using System;
using System.Threading.Tasks;
using BV.PACS.WEB.Client.Pages.Aliquots;
using BV.PACS.WEB.Client.Pages.BatchRegistration;
using BV.PACS.WEB.Client.Pages.Materials;
using BV.PACS.WEB.Client.Pages.Sources;
using BV.PACS.WEB.Client.Pages.Tests;
using BV.PACS.WEB.Client.Shared.Base;
using Microsoft.AspNetCore.Components;

namespace BV.PACS.WEB.Client.Shared.Components
{
    public class TopMenuCode : TranslatablePanel<I18nText.TopMenu>
    {
        [Parameter]
        public Action OnMenuClick { get; set; }


        protected async Task DoOpenBatchRegistration()
        {
            ApplicationContextService.OpenBatchRegistrationPage(nameof(BatchRegistrationForm));
            await InvokeAsync(OnMenuClick);
        }

        protected async Task DoOpenSourceCatalog()
        {
            await DoOpenCatalogPage(nameof(SourceCatalog));
        }

        protected async Task DoOpenMaterialCatalog()
        {
            await DoOpenCatalogPage(nameof(MaterialCatalog));
        }

        protected async Task DoOpenAliquotCatalog()
        {
            await DoOpenCatalogPage(nameof(AliquotCatalog));
        }

        protected async Task DoOpenTestCatalog()
        {
           await DoOpenCatalogPage(nameof(TestCatalog));
        }

        private async Task DoOpenCatalogPage(string pageName)
        {
            ApplicationContextService.OpenLastOrNewCatalogPage(pageName);
            await InvokeAsync(OnMenuClick);
        }

        private async Task DoOpenTrackingPage(string pageName, int context)
        {
            ApplicationContextService.OpenTrackingPage(pageName, context);
            await InvokeAsync(OnMenuClick);
        }
    }
}