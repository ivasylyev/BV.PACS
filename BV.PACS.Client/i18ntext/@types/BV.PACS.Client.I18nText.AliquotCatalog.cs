namespace BV.PACS.Client.I18nText
{
    public partial class AliquotCatalog : global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage, global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextLateBinding
    {
        string global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage.FallBackLanguage => "en-US";

        public string this[string key] => global::Toolbelt.Blazor.I18nText.I18nTextExtensions.GetFieldValue(this, key);

        /// <summary>"Aliquot ID"</summary>
        public string AliquotBarcode;

        /// <summary>"Creation Date"</summary>
        public string AliquotCreationDate;

        /// <summary>"Aliquot Status"</summary>
        public string AliquotStatus;

        /// <summary>"Template"</summary>
        public string AliquotTemplateName;

        /// <summary>"Aliquot Catalog"</summary>
        public string Caption;
    }
}
