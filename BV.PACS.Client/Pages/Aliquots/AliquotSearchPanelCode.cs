
using BV.PACS.Client.Shared;
using BV.PACS.Shared.Models;

namespace BV.PACS.Client.Aliquots
{
    [FormTemplate(FormTypes.Aliquot)]
    public class AliquotSearchPanelCode : BaseSearchPanel
    {
        protected string AliquotBarcode { get; set; }

        protected string AliquotNotes { get; set; }

        protected void DoSearch()
        {
            var cond = new AggregatedConditionDto();

            cond.AddStandardConditionIfNotEmpty("strBarcode", AliquotBarcode, Operators.LikeOperator);

            cond.AddStandardConditionIfNotEmpty("datCreationDate", StartDateText, Operators.MoreOperator);
            cond.AddStandardConditionIfNotEmpty("datCreationDate", EndDateText, Operators.LessOperator);

            cond.AddStandardConditionIfNotEmpty("idfsCFormTemplateID", Template?.Id, Operators.EqualsOperator);

            OnSearch?.Invoke(cond);
        }
    }
}