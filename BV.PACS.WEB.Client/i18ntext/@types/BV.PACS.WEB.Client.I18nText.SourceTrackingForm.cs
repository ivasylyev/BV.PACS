namespace BV.PACS.WEB.Client.I18nText
{
    public partial class SourceTrackingForm : global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage, global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextLateBinding
    {
        string global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage.FallBackLanguage => "en-US";

        public string this[string key] => global::Toolbelt.Blazor.I18nText.I18nTextExtensions.GetFieldValue(this, key);

        /// <summary>"Audit log"</summary>
        public string AuditLog;

        /// <summary>"Source Tracking Form"</summary>
        public string Caption;

        /// <summary>"История проверок"</summary>
        public string CheckoutHistory;

        /// <summary>"Diagnostics"</summary>
        public string Diagnostics;

        /// <summary>"General info"</summary>
        public string GeneralInfo;

        /// <summary>"Materials"</summary>
        public string Materials;

        /// <summary>"Tests"</summary>
        public string Tests;
    }
}
