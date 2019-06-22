using System;
using System.Threading.Tasks;
using BV.PACS.Shared.Models;
using BV.PACS.Shared.Utils;

namespace BV.PACS.Client.SearchPanels
{
    public class MaterialSearchPanelCode : BaseSearchPanel
    {
        protected string SourceBarcode { get; set; }
        protected string AliquotBarcode { get; set; }
        protected string MaterialBarcode { get; set; }

        protected TemplateLookupItem[] _materialTemplates;

        protected DateTime StartMaterialCreationDate { get; set; }
        protected DateTime EndMaterialCreationDate { get; set; }


        protected TemplateLookupItem MaterialTemplate { get; set; }

        protected string MaterialNotes { get; set; }


        protected override async Task OnInitAsync()
        {
            StartMaterialCreationDate = DateTime.Now.Date.AddYears(-1);
            EndMaterialCreationDate = DateTime.Now.Date;

            _materialTemplates = await GetTemplatesLookup(FormTypes.Material);
        }


        protected void DoSearch()
        {
            var cond = new AggregatedConditionDto();

            cond.AddStandardConditionIfNotEmpty("strSourceBarcode", "SourceBarcode", SourceBarcode, Operators.LikeOperator);

            cond.AddStandardConditionIfNotEmpty("strContainerNumber", "AliquotBarcode", AliquotBarcode, Operators.LikeOperator);

            cond.AddStandardConditionIfNotEmpty("strBarcode", "MaterialBarcode", MaterialBarcode, Operators.LikeOperator);

            var creationDateStartText = StartMaterialCreationDate.Date.ToString(GlobalSettings.AnsiDateTimeFormatInfo);
            cond.AddStandardConditionIfNotEmpty("datCreationDate", "CreationDate", creationDateStartText, Operators.MoreOperator);

            var creationDateEndText = EndMaterialCreationDate.Date.ToString(GlobalSettings.AnsiDateTimeFormatInfo);
            cond.AddStandardConditionIfNotEmpty("datCreationDate", "CreationDate", creationDateEndText, Operators.LessOperator);


            cond.AddStandardConditionIfNotEmpty("idfsCFormTemplateID", "Template", MaterialTemplate?.Id, Operators.EqualsOperator);

            cond.AddStandardConditionIfNotEmpty("strNote", "Notes", MaterialNotes, Operators.LikeOperator);


            //    cond.AddStandardConditionIfNotEmpty("strContainerBarcode", "AliquotBarcode",AliquotBarcode, Operators.LikeOperator);
            //  cond.AddStandardConditionIfNotEmpty("idfOwner", "Owner", cbOwner.EditValue,Operators.EqualsOperator);

            OnSearch?.Invoke(cond);
        }
    }
}