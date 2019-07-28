namespace BV.PACS.WEB.Client.I18nText
{
    public partial class MaterialCatalog : global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage, global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextLateBinding
    {
        string global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage.FallBackLanguage => "en-US";

        public string this[string key] => global::Toolbelt.Blazor.I18nText.I18nTextExtensions.GetFieldValue(this, key);

        /// <summary>"# of aliquots"</summary>
        public string AliquotsCount;

        /// <summary>"Material Catalog"</summary>
        public string Caption;

        /// <summary>"Material ID"</summary>
        public string MaterialBarcode;

        /// <summary>"Point Of Origin"</summary>
        public string MaterialPointOfOrigin;

        /// <summary>"Creation Date"</summary>
        public string MaterialRegistrationDate;

        /// <summary>"Template"</summary>
        public string MaterialTemplateName;

        /// <summary>"Material Type"</summary>
        public string MaterialType;
    }
}
