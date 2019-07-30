namespace BV.PACS.WEB.Client.I18nText
{
    public partial class PacsMessages : global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage, global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextLateBinding
    {
        string global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage.FallBackLanguage => "en-US";

        public string this[string key] => global::Toolbelt.Blazor.I18nText.I18nTextExtensions.GetFieldValue(this, key);

        /// <summary>"Hide Search Panel"</summary>
        public string HideSearchPanel;

        /// <summary>"Loading..."</summary>
        public string Loading;

        /// <summary>"Show Search Panel"</summary>
        public string ShowSearchPanel;
    }
}
