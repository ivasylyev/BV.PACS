namespace BV.PACS.WEB.Client.I18nText
{
    public partial class MaterialSearchPanel : global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage, global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextLateBinding
    {
        string global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage.FallBackLanguage => "en-US";

        public string this[string key] => global::Toolbelt.Blazor.I18nText.I18nTextExtensions.GetFieldValue(this, key);

        /// <summary>"Aliquots"</summary>
        public string Aliquots;

        /// <summary>"Clear"</summary>
        public string Clear;

        /// <summary>"Material ID"</summary>
        public string MaterialBarcode;

        /// <summary>"Notes"</summary>
        public string MaterialNote;

        /// <summary>"Creation Date (from)"</summary>
        public string MaterialRegistrationDateFrom;

        /// <summary>"Creation Date (to)"</summary>
        public string MaterialRegistrationDateTo;

        /// <summary>"Material Template"</summary>
        public string MaterialTemplateName;

        /// <summary>"Search"</summary>
        public string Search;

        /// <summary>"Source ID"</summary>
        public string SourceBarcode;
    }
}
