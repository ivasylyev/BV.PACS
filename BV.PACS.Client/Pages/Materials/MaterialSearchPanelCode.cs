
using BV.PACS.Client.Shared;
using BV.PACS.Shared.Models;

namespace BV.PACS.Client.Materials
{
    [FormTemplate(FormTypes.Material)]
    public class MaterialSearchPanelCode : BaseSearchPanel
    {
        protected string SourceBarcode { get; set; }
        protected string AliquotBarcode { get; set; }
        protected string MaterialBarcode { get; set; }

        protected string MaterialNotes { get; set; }


        protected void DoSearch()
        {
            var cond = new AggregatedConditionDto();

            cond.AddStandardConditionIfNotEmpty("strSourceBarcode", SourceBarcode, Operators.LikeOperator);

            cond.AddStandardConditionIfNotEmpty("strContainerNumber", AliquotBarcode, Operators.LikeOperator);

            cond.AddStandardConditionIfNotEmpty("strBarcode", MaterialBarcode, Operators.LikeOperator);

            cond.AddStandardConditionIfNotEmpty("datCreationDate", StartDateText, Operators.MoreOperator);
            cond.AddStandardConditionIfNotEmpty("datCreationDate", EndDateText, Operators.LessOperator);

            cond.AddStandardConditionIfNotEmpty("idfsCFormTemplateID", Template?.Id, Operators.EqualsOperator);

            cond.AddStandardConditionIfNotEmpty("strNote", MaterialNotes, Operators.LikeOperator);

            //    cond.AddStandardConditionIfNotEmpty("strContainerBarcode", "AliquotBarcode",AliquotBarcode, Operators.LikeOperator);
            //  cond.AddStandardConditionIfNotEmpty("idfOwner", "Owner", cbOwner.EditValue,Operators.EqualsOperator);

            OnSearch?.Invoke(cond);
        }
    }
}