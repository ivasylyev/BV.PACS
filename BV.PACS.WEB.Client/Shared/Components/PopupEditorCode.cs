using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace BV.PACS.WEB.Client.Shared.Components
{
    public class PopupEditorCode : ComponentBase
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
        public string EditorText { get; set; }

        [Parameter]
        public string ModalTitle { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        protected bool _modalVisible;

        protected async Task ShowModal()
        {
            _modalVisible = true;
            await InvokeAsync(StateHasChanged);
        }


        protected async Task Cancel()
        {
            _modalVisible = false;

            await InvokeAsync(OnCancel);
            await InvokeAsync(StateHasChanged);
        }

        protected async Task Ok()
        {
            _modalVisible = false;
            
            await InvokeAsync(OnOk);
            await InvokeAsync(StateHasChanged);
        }
    }
}