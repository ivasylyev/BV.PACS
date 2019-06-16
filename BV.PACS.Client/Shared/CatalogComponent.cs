using System;
using System.Threading.Tasks;
using BV.PACS.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BV.PACS.Client.Shared
{
    public class CatalogComponent : ComponentBase
    {
        protected const int CollapseButtonCount = 10;
       


        protected readonly AggregatedConditionDto _condition = new AggregatedConditionDto();
        protected AggregatedConditionDto _lastSearchPanelCondition = new AggregatedConditionDto();


        protected AggregatedConditionDto Condition => SearchPanelCollapsed ? _condition : _lastSearchPanelCondition;

        protected bool SearchPanelCollapsed { get; set; } = true;

        protected string SearchPanelCssClass => SearchPanelCollapsed ? "collapse" : "col-sm-3";
        protected string GridPanelCssClass => SearchPanelCollapsed ? "col-sm-12" : "col-sm-9";

        protected int ActivePageNumber
        {
            get => Condition.PageNumber;
            set
            {
                Condition.PageNumber = value;
                BeginGetDataAsync(Condition).ContinueWith(x => { StateHasChanged(); });
                StateHasChanged();
            }
        }

        protected void ToggleSearchPanel()
        {
            SearchPanelCollapsed = !SearchPanelCollapsed;

            DoSearch();
        }

        protected void DoSearch()
        {
            BeginGetDataAsync(Condition).ContinueWith(x => { StateHasChanged(); });
            BeginGetPageCountAsync(Condition).ContinueWith(x => { StateHasChanged(); });
        }

        protected override async Task OnInitAsync()
        {
            await BeginGetDataAsync(Condition);
            await BeginGetPageCountAsync(Condition);
        }

        protected void OnSearchPanelSearch(AggregatedConditionDto cond)
        {
            _lastSearchPanelCondition = cond;

            DoSearch();
        }


        protected virtual async Task BeginGetPageCountAsync(AggregatedConditionDto cond)
        {
            throw new NotImplementedException("Must be overriden in the child class");
        }

        protected virtual async Task BeginGetDataAsync(AggregatedConditionDto cond)
        {
            throw new NotImplementedException("Must be overriden in the child class");
        }
    }
}