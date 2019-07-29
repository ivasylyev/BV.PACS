using System.Net.Http;
using System.Threading.Tasks;
using BV.PACS.WEB.Client.Services.Api;
using BV.PACS.WEB.Shared.Models;
using BV.PACS.WEB.Shared.Models.Parameters;
using Microsoft.AspNetCore.Components;
using Toolbelt.Blazor.I18nText.Interfaces;

namespace BV.PACS.WEB.Client.Shared.Base
{
    public class TrackingPanel<TModel, TTranslation> : TranslatablePanel<TTranslation>, IPostable
        where TModel : new()
        where TTranslation : class, I18nTextFallbackLanguage, new()

    {
        [Parameter] public int Id { get; set; }

        [Inject] protected HttpClient Http { get; set; }

        [Inject] protected TrackingService ApiTrackingService { get; set; }

        [Inject] protected LookupService ApiLookupService { get; set; }

        public TModel TrackingObject { get; set; }
        protected TemplateLookupItem[] Templates { get; set; }

        public bool HasChanges { get; set; } = true;

        public virtual bool Post()
        {
            ApiTrackingService.PostData(Http, new TrackingPostParameter<TModel>(TrackingObject, BaseSettings.Language))
                .ContinueWith(x => StateHasChanged());
            return true;
        }

        protected override async Task OnInitAsync()
        {
            await base.OnInitAsync();

            await GetLookups();
            await GetData();
        }

        protected virtual async Task GetLookups()
        {
            await Task.Run(() => Templates = new TemplateLookupItem[0]);
        }

        protected async Task GetLookups(string lookupType)
        {
            Templates = await ApiLookupService.GetTemplatesLookup(Http, lookupType);
        }

        private async Task GetData()
        {
            TrackingObject =
                await ApiTrackingService.GetData<TModel>(Http, new TrackingParameter(Id, BaseSettings.Language));

            var context = ApplicationContextService.CurrentApplicationContext?.PageContext;
            if (context != null)
            {
                context.SerializedData = "xxx";
            }
        }
    }
}