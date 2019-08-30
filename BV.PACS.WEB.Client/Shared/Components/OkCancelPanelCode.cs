using System;
using System.Threading.Tasks;
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


        public async Task DoOk()
        {
            if (OnOk != null)
            {
                await InvokeAsync(OnOk);
            }
        }

        public async Task DoCancel()
        {
            if (OnCancel != null)
            {
                await InvokeAsync(OnCancel);
            }
        }
    }
}