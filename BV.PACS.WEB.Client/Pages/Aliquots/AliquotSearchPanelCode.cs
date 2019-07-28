
using BV.PACS.WEB.Client.Shared;
using BV.PACS.WEB.Client.Shared.Base;
using BV.PACS.WEB.Shared.Models;

namespace BV.PACS.WEB.Client.Aliquots
{
    [FormTemplate(FormTypes.Aliquot)]
    public class AliquotSearchPanelCode : SearchPanel<BV.PACS.WEB.Client.I18nText.Text>
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