using System.Globalization;

namespace BV.PACS.Shared.Utils
{
    public class GlobalSettings
    {
        //Do not change value for this variable!!! 
        private static DateTimeFormatInfo m_AnsiDateTimeFormatInfo;
     
        public static DateTimeFormatInfo AnsiDateTimeFormatInfo
        {
            get
            {
                if (m_AnsiDateTimeFormatInfo == null)
                {
                    m_AnsiDateTimeFormatInfo = new DateTimeFormatInfo
                    {
                        ShortDatePattern = "yyyy-MM-dd",
                        ShortTimePattern = "HH:mm:ss.fff"
                    };
                    m_AnsiDateTimeFormatInfo.LongDatePattern = m_AnsiDateTimeFormatInfo.ShortDatePattern;
                    m_AnsiDateTimeFormatInfo.LongTimePattern = m_AnsiDateTimeFormatInfo.ShortTimePattern;
                }

                return m_AnsiDateTimeFormatInfo;
            }
        }

        public static string CurrentLanguage { get; set; } = "en";

    }
}