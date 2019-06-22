using System;
using System.Threading.Tasks;
using BV.PACS.Shared.Models;
using BV.PACS.Shared.Utils;

namespace BV.PACS.Client.SearchPanels
{
    public class SourceSearchPanelCode : BaseSearchPanel
    {
        protected TemplateLookupItem[] _sourceTemplates;
        protected BaseLookupItem[] _testStatuses;

        protected BaseLookupItem[] _testTypes;
        protected BaseLookupItem[] _testResults;

        protected DateTime StartSourceCreationDate { get; set; }
        protected DateTime EndSourceCreationDate { get; set; }

        protected string SourceBarcode { get; set; }

        protected TemplateLookupItem SourceTemplate { get; set; }

        protected string SourceNotes { get; set; }

        protected string MaterialBarcode { get; set; }

        protected string AliquotBarcode { get; set; }

        protected BaseLookupItem TestStatus { get; set; }
        protected BaseLookupItem TestType { get; set; }
        protected BaseLookupItem TestResult { get; set; }

        protected override async Task OnInitAsync()
        {
            StartSourceCreationDate = DateTime.Now.Date.AddYears(-1);
            EndSourceCreationDate = DateTime.Now.Date;

            _sourceTemplates = await GetTemplatesLookup(FormTypes.Source);

            _testStatuses = await GetLookup(BaseLookupTables.rftTestStatus);
            _testTypes = await GetLookup(BaseLookupTables.rftTestType);
            _testResults = await GetLookup(BaseLookupTables.rftTestResult);
        }


        protected void DoSearch()
        {
            var cond = new AggregatedConditionDto();

            cond.AddStandardConditionIfNotEmpty("strSourceBarcode", "SourceBarcode", SourceBarcode, Operators.LikeOperator);

            var creationDateStartText = StartSourceCreationDate.Date.ToString(GlobalSettings.AnsiDateTimeFormatInfo);
            cond.AddStandardConditionIfNotEmpty("datCreationDate", "CreationDate", creationDateStartText, Operators.MoreOperator);
            var creationDateEndText = EndSourceCreationDate.Date.ToString(GlobalSettings.AnsiDateTimeFormatInfo);
            cond.AddStandardConditionIfNotEmpty("datCreationDate", "CreationDate", creationDateEndText, Operators.LessOperator);

            cond.AddStandardConditionIfNotEmpty("idfsCFormTemplateID", "Template", SourceTemplate?.Id, Operators.EqualsOperator);

            cond.AddStandardConditionIfNotEmpty("strNote", "Notes", SourceNotes, Operators.LikeOperator);

            cond.AddStandardConditionIfNotEmpty("strMaterialBarcode", "MaterialBarcode", MaterialBarcode, Operators.LikeOperator);

            cond.AddStandardConditionIfNotEmpty("strContainerBarcode", "AliquotBarcode", AliquotBarcode, Operators.LikeOperator);

            cond.AddStandardConditionIfNotEmpty("idfsTestStatus", "TestStatus", TestStatus?.Id, Operators.EqualsOperator);
            cond.AddStandardConditionIfNotEmpty("idfsTestTypeId", "TestType", TestType?.Id, Operators.EqualsOperator);
            cond.AddStandardConditionIfNotEmpty("idfsTestResultId", "TestResult", TestResult?.Id, Operators.EqualsOperator);


            OnSearch?.Invoke(cond);
        }
    }
}