using System;
using BV.PACS.WEB.Client.Services.Context;
using Microsoft.AspNetCore.Components;
using Toolbelt.Blazor.I18nText.Interfaces;

namespace BV.PACS.WEB.Client.Shared.Base
{
    public class BatchRegistrationFormCode: TranslatablePanel<BV.PACS.WEB.Client.I18nText.BatchRegistrationForm>
      
    {
        private int _activeTabIndex;

        [Parameter]
        public Action<DialogResult> OnClose { get; set; }

        protected IPostable TrackingPanel { get; set; }


        protected int ActiveTabIndex
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