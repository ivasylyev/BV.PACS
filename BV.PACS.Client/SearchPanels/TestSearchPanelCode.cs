using System;
using System.Threading.Tasks;
using BV.PACS.Shared.Models;
using BV.PACS.Shared.Utils;

namespace BV.PACS.Client.SearchPanels
{
    public class TestSearchPanelCode : BaseSearchPanel
    {
        protected TemplateLookupItem[] _testTemplates;

        protected DateTime StartTestCreationDate { get; set; }
        protected DateTime EndTestCreationDate { get; set; }

        protected string TestBarcode { get; set; }

        protected TemplateLookupItem TestTemplate { get; set; }

        protected string TestNotes { get; set; }

        protected string AliquotBarcode { get; set; }

        protected override async Task OnInitAsync()
        {
            StartTestCreationDate = DateTime.Now.Date.AddYears(-1);
            EndTestCreationDate = DateTime.Now.Date;

            _testTemplates = await GetTemplatesLookup(FormTypes.Test);
        }


        protected void DoSearch()
        {
            var cond = new AggregatedConditionDto();

            cond.AddStandardConditionIfNotEmpty("strBarcode", "TestBarcode", TestBarcode, Operators.LikeOperator);

            var creationDateStartText = StartTestCreationDate.Date.ToString(GlobalSettings.AnsiDateTimeFormatInfo);
            cond.AddStandardConditionIfNotEmpty("datCreationDate", "CreationDate", creationDateStartText, Operators.MoreOperator);

            var creationDateEndText = EndTestCreationDate.Date.ToString(GlobalSettings.AnsiDateTimeFormatInfo);
            cond.AddStandardConditionIfNotEmpty("datCreationDate", "CreationDate", creationDateEndText, Operators.LessOperator);

            cond.AddStandardConditionIfNotEmpty("idfsCFormTemplateID", "Template", TestTemplate?.Id, Operators.EqualsOperator);

            OnSearch?.Invoke(cond);
        }
    }
}