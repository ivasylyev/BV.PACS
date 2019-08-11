using System;
using System.Linq;
using System.Threading.Tasks;
using BV.PACS.WEB.Client.Services.Context;
using Microsoft.AspNetCore.Components;

namespace BV.PACS.WEB.Client.Shared.Components
{
    public class LanguageSelectorCode : ComponentBase
    {
        [Inject]
        protected ApplicationContextService ApplicationContextService { get; set; }

        [Inject]
        protected Toolbelt.Blazor.I18nText.I18nText I18NText { get; set; }


        protected string CurrentLang { get; set; }

        protected override async Task OnInitAsync()
        {
            await base.OnInitAsync();

            var lang = await I18NText.GetCurrentLanguageAsync();
            Console.WriteLine($"current lang: {lang}");
            if (new[] {"en-US", "ru-RU"}.Contains(lang))
            {
                CurrentLang = lang;
            }
            else
            {
                CurrentLang = "en-US";
            }
        }

        protected async Task OnChangeCurrentLang(UIChangeEventArgs args)
        {
            Console.WriteLine($"OnChange: {args.Type}, {args.Value}");
            CurrentLang = args.Value as string;
            await I18NText.SetCurrentLanguageAsync(CurrentLang);
        }
    }
}