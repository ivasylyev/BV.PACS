using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BV.PACS.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BV.PACS.Client.Shared
{
    public class BaseCatalog<T> : ComponentBase where T : new()
    {
        [Inject]
        private HttpClient Http { get; set; }

        [Inject]
        private IUriHelper UriHelper { get; set; }

        [Parameter]
        public Action<int> OnOpenTrackingForm { get; set; }

        private T[] _dataSource;

        public CatalogState State { get; set; } = new CatalogState();

        protected int PageCount { get; set; }

        public int ActivePageNumber
        {
            get => State.Condition.PageNumber;
            set
            {
                State.Condition.PageNumber = value;
                BeginGetDataAsync(State.Condition).ContinueWith(x => { StateHasChanged(); });
            }
        }

        protected T[] DataSource
        {
            get
            {
                if (_dataSource == null)
                {
                    _dataSource = new T[State.Condition.PageSize];
                    for (var i = 0; i < _dataSource.Length; i++)
                    {
                        _dataSource[i] = CatalogDtoFactory.CreateEmptyItem<T>("Loading...");
                    }
                }

                return _dataSource;
            }
            set => _dataSource = value;
        }

        protected override async Task OnInitAsync()
        {
            await BeginGetDataAsync(State.Condition);
            await BeginGetPageCountAsync(State.Condition);
        }

        protected void OnSearchPanelToggle()
        {
            State.SearchPanelToggle();

            DoSearch();
        }

        protected void OnSearchPanelSearch(AggregatedConditionDto cond)
        {
            State.SetSearchPanelCondition(cond);

            DoSearch();
        }

        private void DoSearch()
        {
            BeginGetDataAsync(State.Condition).ContinueWith(x => { StateHasChanged(); });
            BeginGetPageCountAsync(State.Condition).ContinueWith(x => { StateHasChanged(); });
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