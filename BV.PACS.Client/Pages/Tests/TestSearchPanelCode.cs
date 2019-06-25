
using BV.PACS.Client.Shared;
using BV.PACS.Shared.Models;

namespace BV.PACS.Client.Tests
{
    [FormTemplate(FormTypes.Test)]
    public class TestSearchPanelCode : BaseSearchPanel
    {
        protected string TestBarcode { get; set; }

        protected string TestNotes { get; set; }

        protected string AliquotBarcode { get; set; }


        protected void DoSearch()
        {
            var cond = new AggregatedConditionDto();

            cond.AddStandardConditionIfNotEmpty("strBarcode", TestBarcode, Operators.LikeOperator);

            cond.AddStandardConditionIfNotEmpty("datCreationDate", StartDateText, Operators.MoreOperator);

            cond.AddStandardConditionIfNotEmpty("datCreationDate", EndDateText, Operators.LessOperator);

            cond.AddStandardConditionIfNotEmpty("idfsCFormTemplateID", Template?.Id, Operators.EqualsOperator);

            OnSearch?.Invoke(cond);
        }
    }
}