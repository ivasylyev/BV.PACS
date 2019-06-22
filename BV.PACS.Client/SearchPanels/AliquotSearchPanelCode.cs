using System;
using System.Threading.Tasks;
using BV.PACS.Shared.Models;
using BV.PACS.Shared.Utils;

namespace BV.PACS.Client.SearchPanels
{
    public class AliquotSearchPanelCode : BaseSearchPanel
    {
        protected TemplateLookupItem[] _aliquotTemplates;

        protected DateTime StartAliquotCreationDate { get; set; }
        protected DateTime EndAliquotCreationDate { get; set; }

        protected string AliquotBarcode { get; set; }

        protected TemplateLookupItem AliquotTemplate { get; set; }

        protected string AliquotNotes { get; set; }


        protected override async Task OnInitAsync()
        {
            StartAliquotCreationDate = DateTime.Now.Date.AddYears(-1);
            EndAliquotCreationDate = DateTime.Now.Date;

            _aliquotTemplates = await GetTemplatesLookup(FormTypes.Aliquot);
        }


        protected void DoSearch()
        {
            var cond = new AggregatedConditionDto();

            cond.AddStandardConditionIfNotEmpty("strBarcode", "AliquotBarcode", AliquotBarcode, Operators.LikeOperator);

            var creationDateStartText = StartAliquotCreationDate.Date.ToString(GlobalSettings.AnsiDateTimeFormatInfo);
            cond.AddStandardConditionIfNotEmpty("datCreationDate", "CreationDate", creationDateStartText, Operators.MoreOperator);

            var creationDateEndText = EndAliquotCreationDate.Date.ToString(GlobalSettings.AnsiDateTimeFormatInfo);
            cond.AddStandardConditionIfNotEmpty("datCreationDate", "CreationDate", creationDateEndText, Operators.LessOperator);

            cond.AddStandardConditionIfNotEmpty("idfsCFormTemplateID", "Template", AliquotTemplate?.Id, Operators.EqualsOperator);

            OnSearch?.Invoke(cond);
        }
    }
}