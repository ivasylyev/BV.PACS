namespace BV.PACS.WEB.Client.I18nText
{
    public partial class TopMenu : global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage, global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextLateBinding
    {
        string global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage.FallBackLanguage => "en-US";

        public string this[string key] => global::Toolbelt.Blazor.I18nText.I18nTextExtensions.GetFieldValue(this, key);

        /// <summary>"Aliquot Catalog"</summary>
        public string AliquotCatalog;

        /// <summary>"BV.PACS"</summary>
        public string Logo;

        /// <summary>"Material Catalog"</summary>
        public string MaterialCatalog;

        /// <summary>"Source Catalog"</summary>
        public string SourceCatalog;

        /// <summary>"Test Catalog"</summary>
        public string TestCatalog;
    }
}
