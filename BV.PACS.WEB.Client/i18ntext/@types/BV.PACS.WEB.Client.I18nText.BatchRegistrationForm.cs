namespace BV.PACS.WEB.Client.I18nText
{
    public partial class BatchRegistrationForm : global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage, global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextLateBinding
    {
        string global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage.FallBackLanguage => "en-US";

        public string this[string key] => global::Toolbelt.Blazor.I18nText.I18nTextExtensions.GetFieldValue(this, key);

        /// <summary>"Batch Material Registration"</summary>
        public string Caption;

        /// <summary>"Content"</summary>
        public string ContentTab;

        /// <summary>"Registration"</summary>
        public string RegistrationTab;
    }
}
