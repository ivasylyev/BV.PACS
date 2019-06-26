using System;
using Microsoft.AspNetCore.Components;

namespace BV.PACS.Client.Shared
{
    public class BaseTrackingForm : ComponentBase
    {
        private int _activeTabIndex;

        [Parameter]
        public int Id { get; set; }

        [Parameter]
        public Action<DialogResult> OnClose { get; set; }


        public int ActiveTabIndex
        {
            get => _activeTabIndex;
            set
            {
                _activeTabIndex = value;
                StateHasChanged();
            }
        }

        public void DoOk()
        {
            OnClose?.Invoke(DialogResult.Ok);
        }

        public void DoCancel()
        {
            OnClose?.Invoke(DialogResult.Cancel);
        }
    }
}