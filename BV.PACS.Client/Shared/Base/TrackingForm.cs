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

        public IPostable TrackingPanel { get; set; }

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

        public virtual void DoOk()
        {
            if (TrackingPanel == null || !TrackingPanel.HasChanges || TrackingPanel.Post())
            {
                OnClose?.Invoke(DialogResult.Ok);
            }
            else
            {
                ActiveTabIndex = 0;
            }
        }

        public virtual void DoCancel()
        {
            OnClose?.Invoke(DialogResult.Cancel);
        }
    }
}