namespace BV.PACS.WEB.Client.I18nText
{
    public partial class BatchContentPanel : global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage, global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextLateBinding
    {
        string global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage.FallBackLanguage => "en-US";

        public string this[string key] => global::Toolbelt.Blazor.I18nText.I18nTextExtensions.GetFieldValue(this, key);

        /// <summary>"Aliquot ID"</summary>
        public string AliquotBarcode;

        /// <summary>"Location"</summary>
        public string AliquotLocation;

        /// <summary>"Aliquots"</summary>
        public string Aliquots;

        /// <summary>"Aliquot Template"</summary>
        public string AliquotTemplate;

        /// <summary>"Generate"</summary>
        public string Generate;

        /// <summary>"Material ID"</summary>
        public string MaterialBarcode;

        /// <summary>"Materials"</summary>
        public string Materials;

        /// <summary>"Material Template"</summary>
        public string MaterialTemplate;

        /// <summary>"Material Type"</summary>
        public string MaterialType;

        /// <summary>"Source ID"</summary>
        public string SourceBarcode;

        /// <summary>"Sources"</summary>
        public string Sources;

        /// <summary>"Source Template"</summary>
        public string SourceTemplate;

        /// <summary>"Source Type"</summary>
        public string SourceType;
    }
}
