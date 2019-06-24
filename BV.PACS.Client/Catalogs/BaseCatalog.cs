using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BV.PACS.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BV.PACS.Client.Catalogs
{
    public class BaseCatalog<T> : ComponentBase where T : new()
    {
        [Inject]
        private HttpClient Http { get; set; }

        [Inject]
        private IUriHelper UriHelper { get; set; }

        private T[] _dataSource;

        protected CatalogState CatalogState { get; } = new CatalogState();

        protected int PageCount { get; set; }

        public int ActivePageNumber
        {
            get => CatalogState.Condition.PageNumber;
            set
            {
                CatalogState.Condition.PageNumber = value;
                BeginGetDataAsync(CatalogState.Condition).ContinueWith(x => { StateHasChanged(); });
            }
        }

        protected T[] DataSource
        {
            get
            {
                if (_dataSource == null)
                {
                    _dataSource = new T[CatalogState.Condition.PageSize];
                    for (var i = 0; i < _dataSource.Length; i++)
                    {
                        _dataSource[i] = ListItemFactory.CreateEmptyItem<T>("Loading...");
                    }
                }

                return _dataSource;
            }
            set => _dataSource = value;
        }

        protected override async Task OnInitAsync()
        {
            await BeginGetDataAsync(CatalogState.Condition);
            await BeginGetPageCountAsync(CatalogState.Condition);
        }

        protected void OnRowEditRedirecting(string objectRoute, int id)
        {
            UriHelper.NavigateTo($@"/{objectRoute}/{id}");
        }

        protected void OnSearchPanelToggle()
        {
            CatalogState.SearchPanelToggle();

            DoSearch();
        }

        protected void OnSearchPanelSearch(AggregatedConditionDto cond)
        {
            CatalogState.SetSearchPanelCondition(cond);

            DoSearch();
        }

        private void DoSearch()
        {
            BeginGetDataAsync(CatalogState.Condition).ContinueWith(x => { StateHasChanged(); });
            BeginGetPageCountAsync(CatalogState.Condition).ContinueWith(x => { StateHasChanged(); });
        }

        private async Task BeginGetPageCountAsync(AggregatedConditionDto cond)
        {
            var attr = typeof(T).GetCustomAttributes(typeof(CountUrlAttribute), false).FirstOrDefault();
            if (attr is CountUrlAttribute urlAttribute)
            {
                PageCount = await Http.PostJsonAsync<int>(urlAttribute.Url, cond) / cond.PageSize;
            }
        }

        private async Task BeginGetDataAsync(AggregatedConditionDto cond)
        {
            var attr = typeof(T).GetCustomAttributes(typeof(DataUrlAttribute), false).FirstOrDefault();
            if (attr is DataUrlAttribute urlAttribute)
            {
                DataSource = await Http.PostJsonAsync<T[]>(urlAttribute.Url, cond);
            }
        }
    }
}