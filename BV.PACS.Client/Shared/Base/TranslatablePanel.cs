using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Toolbelt.Blazor.I18nText.Interfaces;
using I18nTextService = Toolbelt.Blazor.I18nText.I18nText;

namespace BV.PACS.Client.Shared.Base
{
    public class TranslatablePanel<TTranslation> : ComponentBase
        where TTranslation : class, I18nTextFallbackLanguage, new()
    {
        [Inject] protected I18nTextService TranslationService { get; set; }

        protected TTranslation Translations { get; set; } = new TTranslation();

        protected override async Task OnInitAsync()
        {
            await base.OnInitAsync();
            Translations = await TranslationService.GetTextTableAsync<TTranslation>(this);
            StateHasChanged();
        }
    }
}