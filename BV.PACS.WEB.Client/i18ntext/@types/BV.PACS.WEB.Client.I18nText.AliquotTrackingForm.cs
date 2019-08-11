namespace BV.PACS.WEB.Client.I18nText
{
    public partial class AliquotTrackingForm : global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage, global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextLateBinding
    {
        string global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage.FallBackLanguage => "en-US";

        public string this[string key] => global::Toolbelt.Blazor.I18nText.I18nTextExtensions.GetFieldValue(this, key);

        /// <summary>"Audit log"</summary>
        public string AuditLog;

        /// <summary>"Aliquot Tracking Form"</summary>
        public string Caption;

        /// <summary>"Checkout history"</summary>
        public string CheckoutHistory;

        /// <summary>"General info"</summary>
        public string GeneralInfo;

        /// <summary>"Tests"</summary>
        public string Tests;
    }
}
