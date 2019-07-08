using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Toolbelt.Blazor.I18nText.Interfaces;
using I18nTextService = Toolbelt.Blazor.I18nText.I18nText;

namespace BV.PACS.Client.Shared.Base
{
    public class TranslatablePanel<T> : ComponentBase where T : class, I18nTextFallbackLanguage, new()
    {
        [Inject] protected I18nTextService TranslationService { get; set; }

        protected T Translations { get; set; } = new T();

        protected override async Task OnInitAsync()
        {
            Translations = await TranslationService.GetTextTableAsync<T>(this);
        }
    }
}