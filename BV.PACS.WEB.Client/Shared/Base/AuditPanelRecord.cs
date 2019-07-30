using System;
using System.Collections.Generic;
using BV.PACS.WEB.Shared.Models;
using Microsoft.AspNetCore.Components;
using Toolbelt.Blazor.I18nText.Interfaces;

namespace BV.PACS.WEB.Client.Shared.Base
{
    public class AuditPanelRecord<TModel, TTranslation> : GridPanel<TModel, TTranslation>
        where TModel : AuditGridDto, new()
        where TTranslation : class, I18nTextFallbackLanguage, new()
    {
        [Parameter]
        public Action OnClick { get; set; }

        [Parameter]
        public KeyValuePair<string, AuditGroupedDto<TModel>> AuditData { get; set; }

        public void DoClick()
        {
            AuditData.Value.GroupVisibility = !AuditData.Value.GroupVisibility;
            StateHasChanged();
            OnClick.Invoke();
        }
    }
}