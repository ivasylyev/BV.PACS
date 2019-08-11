using System;
using BV.PACS.WEB.Client.Pages.Aliquots;
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


        protected void DoOpenSourceCatalog()
        {
            DoOpenCatalogPage(nameof(SourceCatalog));
        }

        protected void DoOpenMaterialCatalog()
        {
            DoOpenCatalogPage(nameof(MaterialCatalog));
        }

        protected void DoOpenAliquotCatalog()
        {
            DoOpenCatalogPage(nameof(AliquotCatalog));
        }

        protected void DoOpenTestCatalog()
        {
            DoOpenCatalogPage(nameof(TestCatalog));
        }

        private void DoOpenCatalogPage(string pageName)
        {
            ApplicationContextService.OpenLastOrNewCatalogPage(pageName);
            OnMenuClick?.Invoke();
        }

        private void DoOpenTrackingPage(string pageName, int context)
        {
            ApplicationContextService.OpenTrackingPage(pageName, context);
            OnMenuClick?.Invoke();
        }
    }
}