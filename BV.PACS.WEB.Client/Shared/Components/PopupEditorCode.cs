using System;
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
        public string EditorLabel { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        protected bool _modalVisible;

        protected void ShowModal()
        {
            _modalVisible = true;
            StateHasChanged();
        }


        protected void Cancel()
        {
            _modalVisible = false;
            OnCancel?.Invoke();

            StateHasChanged();
        }

        protected void Ok()
        {
            _modalVisible = false;
            OnOk?.Invoke();

            StateHasChanged();
        }
    }
}