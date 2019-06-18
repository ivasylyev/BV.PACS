using System;
using System.Threading.Tasks;
using BV.PACS.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BV.PACS.Client.Shared.Catalogs
{
    public class CatalogComponent<T> : ComponentBase where T: new()
    {
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
        private T[] _dataSource;

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

        protected void DoSearch()
        {
            BeginGetDataAsync(CatalogState.Condition).ContinueWith(x => { StateHasChanged(); });
            BeginGetPageCountAsync(CatalogState.Condition).ContinueWith(x => { StateHasChanged(); });
        }

        protected virtual async Task BeginGetPageCountAsync(AggregatedConditionDto cond)
        {
            await Task.Run(() => throw new NotImplementedException("Must be overriden in the child class"));
        }

        protected virtual async Task BeginGetDataAsync(AggregatedConditionDto cond)
        {
            await Task.Run(() => throw new NotImplementedException("Must be overriden in the child class"));
        }
    }
}