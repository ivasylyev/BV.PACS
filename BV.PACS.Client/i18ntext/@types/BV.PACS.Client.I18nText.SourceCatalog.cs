namespace BV.PACS.Client.I18nText
{
    public partial class SourceCatalog : global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage, global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextLateBinding
    {
        string global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage.FallBackLanguage => "en-US";

        public string this[string key] => global::Toolbelt.Blazor.I18nText.I18nTextExtensions.GetFieldValue(this, key);

        /// <summary>"Source Catalog"</summary>
        public string Caption;

        /// <summary>"Materials And Aliquots Count"</summary>
        public string MaterialsAndAliquotsCount;

        /// <summary>"Barcode"</summary>
        public string SourceBarcode;

        /// <summary>"Creation Date"</summary>
        public string SourceCreationDate;

        /// <summary>"Template"</summary>
        public string SourceTemplateName;

        /// <summary>"Type"</summary>
        public string SourceType;
    }
}
