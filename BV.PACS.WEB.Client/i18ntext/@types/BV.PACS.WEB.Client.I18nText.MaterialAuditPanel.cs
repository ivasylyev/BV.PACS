namespace BV.PACS.WEB.Client.I18nText
{
    public partial class MaterialAuditPanel : global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage, global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextLateBinding
    {
        string global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage.FallBackLanguage => "en-US";

        public string this[string key] => global::Toolbelt.Blazor.I18nText.I18nTextExtensions.GetFieldValue(this, key);

        /// <summary>"Column Name"</summary>
        public string ColumnName;

        /// <summary>"New Value"</summary>
        public string NewValue;

        /// <summary>"Object"</summary>
        public string Object;

        /// <summary>"Old Value"</summary>
        public string OldValue;
    }
}
