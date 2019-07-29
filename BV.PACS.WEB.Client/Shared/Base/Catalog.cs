using System;
using System.Net.Http;
using System.Threading.Tasks;
using BV.PACS.WEB.Client.Services.Api;
using BV.PACS.WEB.Client.Services.Context;
using BV.PACS.WEB.Shared.Models;
using Microsoft.AspNetCore.Components;
using Toolbelt.Blazor.I18nText.Interfaces;

namespace BV.PACS.WEB.Client.Shared.Base
{
    public class Catalog<TModel, TTranslation> : TranslatablePanel<TTranslation> 
        where TModel : new() 
        where TTranslation : class, I18nTextFallbackLanguage, new()
    {
        [Inject]
        private HttpClient Http { get; set; }

        [Inject]
        private CatalogService ApiCatalogService { get; set; }


        [Parameter]
        public Action<string, int> OnOpenTrackingForm { get; set; }

        protected CatalogContext<TModel> PageContext
        {
            get
            {
                var context = ApplicationContextService.CurrentApplicationContext.PageContext as CatalogContext<TModel>;
                if (context == null)
                {
                    context = new CatalogContext<TModel>();
                    ApplicationContextService.CurrentApplicationContext.PageContext = context;
                }

                return context;
            }
        }


        protected int PageCount
        {
            get => PageContext.PageCount;
            set => PageContext.PageCount = value;
        }

        public int ActivePageNumber
        {
            get => PageContext.Condition.PageNumber;
            set
            {
                PageContext.Condition.PageNumber = value;

                GetData().ContinueWith(x => { StateHasChanged(); });
            }
        }


        protected TModel[] DataSource
        {
            get => PageContext.DataSource;
            set => PageContext.DataSource = value;
        }

        protected override async Task OnInitAsync()
        {
            await base.OnInitAsync();

            await GetData();
            await GetPageCount();
        }


        protected void OnSelectItem(string pageName, int id)
        {
            OnOpenTrackingForm?.Invoke(pageName, id);
        }

        protected void OnSearchPanelToggle()
        {
            PageContext.SearchPanelToggle();

            DoSearch();
        }

        protected void OnSearchPanelSearch(AggregatedConditionDto cond)
        {
            PageContext.SetSearchPanelCondition(cond);

            DoSearch();
        }


        private void DoSearch()
        {
            GetData().ContinueWith(x => { StateHasChanged(); });
            GetPageCount().ContinueWith(x => { StateHasChanged(); });
        }

        private async Task GetPageCount()
        {
            PageCount = await ApiCatalogService.GetPageCount<TModel>(Http, PageContext.Condition);
        }

        private async Task GetData()
        {
            DataSource = await ApiCatalogService.GetData<TModel>(Http, PageContext.Condition);

        }
    }
}