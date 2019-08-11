namespace BV.PACS.WEB.Client.I18nText
{
    public partial class SourceTrackingPanel : global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage, global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextLateBinding
    {
        string global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage.FallBackLanguage => "en-US";

        public string this[string key] => global::Toolbelt.Blazor.I18nText.I18nTextExtensions.GetFieldValue(this, key);

        /// <summary>"# of materials (aliquots)"</summary>
        public string MaterialsAndAliquotsCount;

        /// <summary>"Source ID"</summary>
        public string SourceBarcode;

        /// <summary>"Notes"</summary>
        public string SourceNote;

        /// <summary>"Point Of Origin"</summary>
        public string SourcePointOfOrigin;

        /// <summary>"Creation Date"</summary>
        public string SourceRegistrationDate;

        /// <summary>"Template"</summary>
        public string SourceTemplateName;

        /// <summary>"Source Type"</summary>
        public string SourceType;
    }
}
