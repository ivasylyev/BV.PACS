namespace BV.PACS.Client.I18nText
{
    public partial class StartForm : global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage, global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextLateBinding
    {
        string global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage.FallBackLanguage => "en-US";

        public string this[string key] => global::Toolbelt.Blazor.I18nText.I18nTextExtensions.GetFieldValue(this, key);

        /// <summary>"Welcome to the new PACS app."</summary>
        public string Caption;

        /// <summary>"Pathogen Asset Control System - Start Page"</summary>
        public string Description;
    }
}
