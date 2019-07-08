using System.Threading.Tasks;
using BV.PACS.Client.Shared.Base;
using BV.PACS.Shared.Models;

namespace BV.PACS.Client.Sources
{
    [FormTemplate(FormTypes.Source)]
    // ReSharper disable once InconsistentNaming
    public class SourceSearchPanelCode : SearchPanel< BV.PACS.Client.I18nText.Text>
    {
        protected BaseLookupItem[] _testStatuses;

        protected BaseLookupItem[] _testTypes;
        protected BaseLookupItem[] _testResults;

        protected string SourceBarcode { get; set; }


        protected string SourceNotes { get; set; }

        protected string MaterialBarcode { get; set; }

        protected string AliquotBarcode { get; set; }

        protected BaseLookupItem TestStatus { get; set; }
        protected BaseLookupItem TestType { get; set; }
        protected BaseLookupItem TestResult { get; set; }

        protected override async Task OnInitAsync()
        {
            await base.OnInitAsync();

            _testStatuses = await ApiService.GetLookup(Http, BaseLookupTables.rftTestStatus);
            _testTypes = await ApiService.GetLookup(Http, BaseLookupTables.rftTestType);
            _testResults = await ApiService.GetLookup(Http, BaseLookupTables.rftTestResult);
        }


        protected void DoSearch()
        {
            var cond = new AggregatedConditionDto();

            cond.AddStandardConditionIfNotEmpty("strSourceBarcode", SourceBarcode, Operators.LikeOperator);

            cond.AddStandardConditionIfNotEmpty("datCreationDate", StartDateText, Operators.MoreOperator);
            cond.AddStandardConditionIfNotEmpty("datCreationDate", EndDateText, Operators.LessOperator);

            cond.AddStandardConditionIfNotEmpty("idfsCFormTemplateID", Template?.Id, Operators.EqualsOperator);

            cond.AddStandardConditionIfNotEmpty("strNote", SourceNotes, Operators.LikeOperator);

            cond.AddStandardConditionIfNotEmpty("strMaterialBarcode", MaterialBarcode, Operators.LikeOperator);

            cond.AddStandardConditionIfNotEmpty("strContainerBarcode", AliquotBarcode, Operators.LikeOperator);

            cond.AddStandardConditionIfNotEmpty("idfsTestStatus", TestStatus?.Id, Operators.EqualsOperator);
            cond.AddStandardConditionIfNotEmpty("idfsTestTypeId", TestType?.Id, Operators.EqualsOperator);
            cond.AddStandardConditionIfNotEmpty("idfsTestResultId", TestResult?.Id, Operators.EqualsOperator);


            OnSearch?.Invoke(cond);
        }
    }
}