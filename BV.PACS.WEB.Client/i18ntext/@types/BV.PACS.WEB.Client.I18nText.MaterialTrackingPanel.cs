namespace BV.PACS.WEB.Client.I18nText
{
    public partial class MaterialTrackingPanel : global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage, global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextLateBinding
    {
        string global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage.FallBackLanguage => "en-US";

        public string this[string key] => global::Toolbelt.Blazor.I18nText.I18nTextExtensions.GetFieldValue(this, key);

        /// <summary>"Material ID"</summary>
        public string MaterialBarcode;

        /// <summary>"Notes"</summary>
        public string MaterialNote;

        /// <summary>"Materail Owner"</summary>
        public string MaterialOwnerName;

        /// <summary>"Point Of Origin"</summary>
        public string MaterialPointOfOrigin;

        /// <summary>"Creation Date"</summary>
        public string MaterialRegistrationDate;

        /// <summary>"Template"</summary>
        public string MaterialTemplateName;

        /// <summary>"Material Type"</summary>
        public string MaterialType;

        /// <summary>"Parent Material ID"</summary>
        public string ParentMaterialBarcode;

        /// <summary>"Source ID"</summary>
        public string SourceBarcode;

        /// <summary>"Source Type"</summary>
        public string SourceType;
    }
}