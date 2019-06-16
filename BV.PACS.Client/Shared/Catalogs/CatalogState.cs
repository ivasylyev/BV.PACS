using BV.PACS.Shared.Models;

namespace BV.PACS.Client.Shared.Catalog
{
    public class CatalogState
    {
        public const int CollapseButtonCount = 10;

        private readonly AggregatedConditionDto _condition = new AggregatedConditionDto();
        private AggregatedConditionDto _lastSearchPanelCondition = new AggregatedConditionDto();
        public AggregatedConditionDto Condition => SearchPanelCollapsed ? _condition : _lastSearchPanelCondition;

        private bool SearchPanelCollapsed { get; set; } = true;

        public string SearchPanelCssClass => SearchPanelCollapsed ? "collapse" : "col-sm-3";
        public string GridPanelCssClass => SearchPanelCollapsed ? "col-sm-12" : "col-sm-9";


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