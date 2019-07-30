namespace BV.PACS.WEB.Client.I18nText
{
    public partial class SourceSearchPanel : global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage, global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextLateBinding
    {
        string global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage.FallBackLanguage => "en-US";

        public string this[string key] => global::Toolbelt.Blazor.I18nText.I18nTextExtensions.GetFieldValue(this, key);

        /// <summary>"Aliquot ID"</summary>
        public string AliquotBarcodes;

        /// <summary>"Clear"</summary>
        public string Clear;

        /// <summary>"Material ID"</summary>
        public string MaterialBarcodes;

        /// <summary>"Search"</summary>
        public string Search;

        /// <summary>"Source ID"</summary>
        public string SourceBarcode;

        /// <summary>"Creation Date (to)"</summary>
        public string SourceCreationDateFrom;

        /// <summary>"Дата создания (до)"</summary>
        public string SourceCreationDateTo;

        /// <summary>"Notes"</summary>
        public string SourceNote;

        /// <summary>"Source Template"</summary>
        public string SourceTemplateName;

        /// <summary>"Test Result"</summary>
        public string TestResults;

        /// <summary>"Test Status"</summary>
        public string TestStatuses;

        /// <summary>"Test Type"</summary>
        public string TestTypes;
    }
}
