﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BV.PACS.WEB.Client.I18nText;
using BV.PACS.WEB.Client.Shared.Base;
using BV.PACS.WEB.Shared.Models;

namespace BV.PACS.WEB.Client.Materials
{
    [FormTemplate(FormTypes.Material)]
    public class MaterialSearchPanelCode : SearchPanel<MaterialSearchPanel>
    {
        protected string SourceBarcode { get; set; }
        protected string AliquotBarcode { get; set; }
        protected string MaterialBarcode { get; set; }

        protected string MaterialNotes { get; set; }

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
                    case "strContainerNumber":
                        AliquotBarcode = item.FieldValue;
                        break;
                    case "strBarcode":
                        MaterialBarcode = item.FieldValue;
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
                        MaterialNotes = item.FieldValue;
                        break;
                }
            }

            if (dates.Count > 0)
            {
                StartDate = dates.Min();
                EndDate = dates.Max();
            }

            StateHasChanged();
        }

        protected override async Task DoSearch()
        {
            var cond = new AggregatedConditionDto();

            cond.AddStandardConditionIfNotEmpty("strSourceBarcode", SourceBarcode, Operators.LikeOperator);

            cond.AddStandardConditionIfNotEmpty("strContainerNumber", AliquotBarcode, Operators.LikeOperator);

            cond.AddStandardConditionIfNotEmpty("strBarcode", MaterialBarcode, Operators.LikeOperator);

            cond.AddStandardConditionIfNotEmpty("datCreationDate", StartDateText, Operators.MoreOperator);
            cond.AddStandardConditionIfNotEmpty("datCreationDate", EndDateText, Operators.LessOperator);

            cond.AddStandardConditionIfNotEmpty("idfsCFormTemplateID", Template?.Id, Operators.EqualsOperator);

            cond.AddStandardConditionIfNotEmpty("strNote", MaterialNotes, Operators.LikeOperator);

            //todo: implement the rest
            //    cond.AddStandardConditionIfNotEmpty("strContainerBarcode", "AliquotBarcode",AliquotBarcode, Operators.LikeOperator);
            //  cond.AddStandardConditionIfNotEmpty("idfOwner", "Owner", cbOwner.EditValue,Operators.EqualsOperator);

            await InvokeAsync(() => OnSearch?.Invoke(cond));
        }

        protected override void DoClear()
        {
            base.DoClear();
            SourceBarcode = string.Empty;
            Template = null;
            MaterialNotes = string.Empty;
            MaterialBarcode = string.Empty;
            AliquotBarcode = string.Empty;
        }
    }
}