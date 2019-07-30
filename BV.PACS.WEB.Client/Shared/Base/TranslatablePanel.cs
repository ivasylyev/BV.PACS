using System.Threading.Tasks;
using BV.PACS.WEB.Client.I18nText;
using BV.PACS.WEB.Client.Services.Context;
using Microsoft.AspNetCore.Components;
using Toolbelt.Blazor.I18nText.Interfaces;
using I18nTextService = Toolbelt.Blazor.I18nText.I18nText;

namespace BV.PACS.WEB.Client.Shared.Base
{
    public abstract class TranslatablePanel<TTranslation> : ComponentBase
        where TTranslation : class, I18nTextFallbackLanguage, new()
    {
        [Inject]
        protected I18nTextService TranslationService { get; set; }

        [Inject]
        protected ApplicationContextService ApplicationContextService { get; set; }

        protected TTranslation Translations { get; set; } = new TTranslation();

        protected PacsMessages PacsMessagesTranslations { get; set; } = new PacsMessages();

        protected override async Task OnInitAsync()
        {
            await base.OnInitAsync();
            Translations = await TranslationService.GetTextTableAsync<TTranslation>(this);
            PacsMessagesTranslations = await TranslationService.GetTextTableAsync<PacsMessages>(this);
            StateHasChanged();
        }
    }
}