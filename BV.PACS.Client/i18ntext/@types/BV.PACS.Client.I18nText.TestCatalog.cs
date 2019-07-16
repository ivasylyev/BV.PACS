namespace BV.PACS.Client.I18nText
{
    public partial class TestCatalog : global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage, global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextLateBinding
    {
        string global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage.FallBackLanguage => "en-US";

        public string this[string key] => global::Toolbelt.Blazor.I18nText.I18nTextExtensions.GetFieldValue(this, key);

        /// <summary>"Aliquot ID"</summary>
        public string AliquotBarcode;

        /// <summary>"Test Catalog"</summary>
        public string Caption;

        /// <summary>"Material ID"</summary>
        public string MaterialBarcode;

        /// <summary>"Material Type"</summary>
        public string MaterialType;

        /// <summary>"Source ID"</summary>
        public string SourceBarcode;

        /// <summary>"Test ID"</summary>
        public string TestBarcode;

        /// <summary>"Test Date"</summary>
        public string TestDate;

        /// <summary>"Creation Date"</summary>
        public string TestRegistrationDate;

        /// <summary>"Test Result"</summary>
        public string TestResult;

        /// <summary>"Test Status"</summary>
        public string TestStatus;

        /// <summary>"Template"</summary>
        public string TestTemplateName;

        /// <summary>"Test Type"</summary>
        public string TestType;
    }
}
