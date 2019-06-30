using System;
using System.Net.Http;
using System.Threading.Tasks;
using BV.PACS.Client.Services.Api;
using BV.PACS.Client.Services.Context;
using BV.PACS.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BV.PACS.Client.Shared.Base
{
    public class Catalog<T> : ComponentBase where T : new()
    {
        [Inject]
        private HttpClient Http { get; set; }

        [Inject]
        private CatalogService ApiCatalogService { get; set; }

        [Inject]
        private ApplicationContextService ApplicationContextService { get; set; }


        [Parameter]
        public Action<string, int> OnOpenTrackingForm { get; set; }

        protected CatalogContext<T> PageContext
        {
            get
            {
                var context = ApplicationContextService.CurrentApplicationContext.PageContext as CatalogContext<T>;
                if (context == null)
                {
                    context = new CatalogContext<T>();
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


        protected T[] DataSource
        {
            get => PageContext.DataSource;
            set => PageContext.DataSource = value;
        }

        protected override async Task OnInitAsync()
        {
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
            PageCount = await ApiCatalogService.GetPageCount<T>(Http, PageContext.Condition);
        }

        private async Task GetData()
        {
            DataSource = await ApiCatalogService.GetData<T>(Http, PageContext.Condition);
        }
    }
}