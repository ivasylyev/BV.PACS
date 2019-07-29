using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BV.PACS.WEB.Client.I18nText;
using BV.PACS.WEB.Client.Shared.Base;
using BV.PACS.WEB.Shared.Models;

namespace BV.PACS.WEB.Client.Sources
{
    [FormTemplate(FormTypes.Source)]
    // ReSharper disable once InconsistentNaming
    public class SourceSearchPanelCode : SearchPanel<SourceSearchPanel>
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

        protected override void InitSearchCondition(AggregatedConditionDto cond)
        {
            var dates = new List<DateTime>();
            foreach (var item in cond.ConditionItems)
            {
                switch (item.FieldName)
                {
                    case "strSourceBarcode":
                        SourceBarcode = item.FieldValue;
                        break;
                    case "datCreationDate":
                        if (DateTime.TryParse(item.FieldValue, out var date))
                        {
                            dates.Add(date);
                        }

                        break;
                    case "idfsCFormTemplateID":
                        Template = Templates?.FirstOrDefault(t => t.Id == item.FieldValue);
                        break;
                    case "strNote":
                        SourceNotes = item.FieldValue;
                        break;
                    case "strMaterialBarcode":
                        MaterialBarcode = item.FieldValue;
                        break;
                    case "strContainerBarcode":
                        AliquotBarcode = item.FieldValue;
                        break;

                    case "idfsTestStatus":
                        TestStatus = _testStatuses?.FirstOrDefault(t => t.Id == item.FieldValue);
                        break;
                    case "idfsTestTypeId":
                        TestType = _testTypes?.FirstOrDefault(t => t.Id == item.FieldValue);
                        break;
                    case "idfsTestResultId":
                        TestResult = _testResults?.FirstOrDefault(t => t.Id == item.FieldValue);
                        break;
                }
            }

            if (dates.Count > 0)
            {
                StartDate = dates.Min();
                EndDate = dates.Max();
                //  SourceBarcode = cond.Serialize();
            }

            StateHasChanged();
        }

        protected override void DoSearch()
        {
            var condition = new AggregatedConditionDto();

            condition.AddStandardConditionIfNotEmpty("strSourceBarcode", SourceBarcode, Operators.LikeOperator);

            condition.AddStandardConditionIfNotEmpty("datCreationDate", StartDateText, Operators.MoreOperator);
            condition.AddStandardConditionIfNotEmpty("datCreationDate", EndDateText, Operators.LessOperator);

            condition.AddStandardConditionIfNotEmpty("idfsCFormTemplateID", Template?.Id, Operators.EqualsOperator);

            condition.AddStandardConditionIfNotEmpty("strNote", SourceNotes, Operators.LikeOperator);

            condition.AddStandardConditionIfNotEmpty("strMaterialBarcode", MaterialBarcode, Operators.LikeOperator);

            condition.AddStandardConditionIfNotEmpty("strContainerBarcode", AliquotBarcode, Operators.LikeOperator);

            condition.AddStandardConditionIfNotEmpty("idfsTestStatus", TestStatus?.Id, Operators.EqualsOperator);
            condition.AddStandardConditionIfNotEmpty("idfsTestTypeId", TestType?.Id, Operators.EqualsOperator);
            condition.AddStandardConditionIfNotEmpty("idfsTestResultId", TestResult?.Id, Operators.EqualsOperator);


            OnSearch?.Invoke(condition);
        }

        protected override void DoClear()
        {
            base.DoClear();
            SourceBarcode = string.Empty;
            Template = null;
            SourceNotes = string.Empty;
            MaterialBarcode = string.Empty;
            AliquotBarcode = string.Empty;
            TestStatus = null;
            TestType = null;
            TestResult = null;
        }
    }
}