using System;
using BV.PACS.Client.Services.Context;
using Microsoft.AspNetCore.Components;

namespace BV.PACS.Client.Shared.Base
{
    public class TrackingForm : ComponentBase
    {
        private int _activeTabIndex;

        [Inject]
        private ApplicationContextService ApplicationContextService { get; set; }

        [Parameter]
        public Action<DialogResult> OnClose { get; set; }

        public int Id => PageContext?.Id ?? 0;

        private TrackingFormContext PageContext => ApplicationContextService.CurrentApplicationContext.PageContext as TrackingFormContext;


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