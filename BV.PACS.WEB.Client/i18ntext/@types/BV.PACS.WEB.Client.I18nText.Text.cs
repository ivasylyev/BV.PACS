namespace BV.PACS.WEB.Client.I18nText
{
    public partial class Text : global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage, global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextLateBinding
    {
        string global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage.FallBackLanguage => "en-US";

        public string this[string key] => global::Toolbelt.Blazor.I18nText.I18nTextExtensions.GetFieldValue(this, key);

        /// <summary>"About"</summary>
        public string About;

        /// <summary>"Balmy"</summary>
        public string Balmy;

        /// <summary>"Bracing"</summary>
        public string Bracing;

        /// <summary>"Chilly"</summary>
        public string Chilly;

        /// <summary>"Click me"</summary>
        public string ClickMe;

        /// <summary>"Cool"</summary>
        public string Cool;

        /// <summary>"Counter"</summary>
        public string Counter;

        /// <summary>"Current count"</summary>
        public string CurrentCount;

        /// <summary>"Date"</summary>
        public string Date;

        /// <summary>"Fetch data"</summary>
        public string FetchData;

        /// <summary>"Freezing"</summary>
        public string Freezing;

        /// <summary>"Hello, world!!"</summary>
        public string HelloWorld;

        /// <summary>"Home"</summary>
        public string Home;

        /// <summary>"Hosted App"</summary>
        public string HostedApp;

        /// <summary>"Hot"</summary>
        public string Hot;

        /// <summary>"Loading..."</summary>
        public string Loading;

        /// <summary>"Mild"</summary>
        public string Mild;

        /// <summary>"Scorching"</summary>
        public string Scorching;

        /// <summary>"Summary"</summary>
        public string Summary;

        /// <summary>"Please take our [brief survey]({0}) and tell us what you think."</summary>
        public string SurveyPrompt;

        /// <summary>"How is Blazor working for you?"</summary>
        public string SurveyTitle;

        /// <summary>"Sweltering"</summary>
        public string Sweltering;

        /// <summary>"Temp. (C)"</summary>
        public string TempC;

        /// <summary>"Temp. (F)"</summary>
        public string TempF;

        /// <summary>"Warm"</summary>
        public string Warm;

        /// <summary>"Weather forecast"</summary>
        public string WeatherForecast;

        /// <summary>"This component demonstrates fetching data from the server."</summary>
        public string WeatherForecast_Description;

        /// <summary>"Welcome to your new app."</summary>
        public string WelcomeToYourNewApp;
    }
}