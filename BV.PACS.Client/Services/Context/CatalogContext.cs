using BV.PACS.Client.Shared;
using BV.PACS.Shared.Models;

namespace BV.PACS.Client.Services.Context
{
    public class CatalogContext<T> : IPageContext where T : new()
    {
        private readonly AggregatedConditionDto _condition = new AggregatedConditionDto();
        private AggregatedConditionDto _lastSearchPanelCondition = new AggregatedConditionDto();
        private T[] _dataSource;

        public AggregatedConditionDto Condition => SearchPanelCollapsed ? _condition : _lastSearchPanelCondition;


        public string SearchPanelCssClass => SearchPanelCollapsed ? "collapse" : "col-sm-3 alert alert-primary background-white";

        public string GridPanelCssClass => SearchPanelCollapsed
            ? "col-sm-12 alert alert-primary background-white"
            : "col-sm-9 alert alert-primary background-white";

        public string ShowHideSearchPanelCaption => SearchPanelCollapsed ? "Show Search Panel" : "Hide Search Panel";
        private bool SearchPanelCollapsed { get; set; } = true;

        public int PageCount { get; set; }

        public T[] DataSource
        {
            get
            {
                if (_dataSource == null)
                {
                    _dataSource = new T[Condition.PageSize];
                    for (var i = 0; i < _dataSource.Length; i++)
                    {
                        _dataSource[i] = CatalogDtoFactory.CreateEmptyItem<T>("Loading...");
                    }
                }

                return _dataSource;
            }
            set => _dataSource = value;
        }

        public void SetSearchPanelCondition(AggregatedConditionDto cond)
        {
            _lastSearchPanelCondition = cond;
        }

        public void SearchPanelToggle()
        {
            SearchPanelCollapsed = !SearchPanelCollapsed;
        }
    }
}