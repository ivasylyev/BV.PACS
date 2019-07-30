namespace BV.PACS.WEB.Client.I18nText
{
    public partial class AliquotSearchPanel : global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage, global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextLateBinding
    {
        string global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage.FallBackLanguage => "en-US";

        public string this[string key] => global::Toolbelt.Blazor.I18nText.I18nTextExtensions.GetFieldValue(this, key);

        /// <summary>"Aliquot ID"</summary>
        public string AliquotBarcode;

        /// <summary>"Creation Date (from)"</summary>
        public string AliquotCreationDateFrom;

        /// <summary>"Creation Date (to)"</summary>
        public string AliquotCreationDateTo;

        /// <summary>"Aliquot Template"</summary>
        public string AliquotTemplateName;

        /// <summary>"Clear"</summary>
        public string Clear;

        /// <summary>"Search"</summary>
        public string Search;
    }
}