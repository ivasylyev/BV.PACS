using System.Globalization;

namespace BV.PACS.WEB.Shared.Utils
{
    public class GlobalSettings
    {
        //Do not change value for this variable!!! 
        private static DateTimeFormatInfo _ansiDateTimeFormatInfo;

        public static string CurrentLanguage { get; set; } = "en";

        public static DateTimeFormatInfo AnsiDateTimeFormatInfo
        {
            get
            {
                if (_ansiDateTimeFormatInfo == null)
                {
                    _ansiDateTimeFormatInfo = new DateTimeFormatInfo
                    {
                        ShortDatePattern = "yyyy-MM-dd",
                        ShortTimePattern = "HH:mm:ss.fff"
                    };
                    _ansiDateTimeFormatInfo.LongDatePattern = _ansiDateTimeFormatInfo.ShortDatePattern;
                    _ansiDateTimeFormatInfo.LongTimePattern = _ansiDateTimeFormatInfo.ShortTimePattern;
                }

                return _ansiDateTimeFormatInfo;
            }
        }


    }
}