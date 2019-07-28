namespace BV.PACS.WEB.Client.I18nText
{
    public partial class OkCancelPanel : global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage, global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextLateBinding
    {
        string global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage.FallBackLanguage => "en-US";

        public string this[string key] => global::Toolbelt.Blazor.I18nText.I18nTextExtensions.GetFieldValue(this, key);

        /// <summary>"Cancel"</summary>
        public string ButtonCancel;

        /// <summary>"Ok"</summary>
        public string ButtonOk;
    }
}
