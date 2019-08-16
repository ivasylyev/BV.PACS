using System;
using Microsoft.AspNetCore.Components;

namespace BV.PACS.WEB.Client.Shared.Components
{
    public class ModalDialogCode: ComponentBase
    {

        [Parameter]
        public Action OnCancel { get; set; }
        [Parameter]
        public string CancelText { get; set; }

        [Parameter]
        public Action OnOk { get; set; }

        [Parameter]
        public string OkText { get; set; } 

        [Parameter]
        public bool Show { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        protected void Cancel()
        {
            Show = false;
            OnCancel?.Invoke();

            StateHasChanged();
        }

        protected void Ok()
        {
            Show = false;
            OnOk?.Invoke();

            StateHasChanged();
        }
    }
}