namespace BV.PACS.WEB.Client.I18nText
{
    public partial class AliquotTrackingPanel : global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage, global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextLateBinding
    {
        string global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage.FallBackLanguage => "en-US";

        public string this[string key] => global::Toolbelt.Blazor.I18nText.I18nTextExtensions.GetFieldValue(this, key);

        /// <summary>"Derivative Type"</summary>
        public string DerivativeType;

        /// <summary>"Material Type"</summary>
        public string MaterialType;

        /// <summary>"Source Type"</summary>
        public string SourceType;
    }
}
