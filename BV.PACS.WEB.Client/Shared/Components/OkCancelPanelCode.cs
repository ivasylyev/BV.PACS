using System;
using BV.PACS.WEB.Client.Shared.Base;
using Microsoft.AspNetCore.Components;

namespace BV.PACS.WEB.Client.Shared.Components
{
    public class OkCancelPanelCode : TranslatablePanel<I18nText.OkCancelPanel>
    {
        [Parameter]
        public Action OnOk { get; set; }

        [Parameter]
        public Action OnCancel { get; set; }


        public void DoOk()
        {
            OnOk?.Invoke();
        }

        public void DoCancel()
        {
            OnCancel?.Invoke();
        }
    }
}