using System;

namespace BV.PACS.Shared.Utils
{
    public static class ObjectExtender
    {
        public static bool IsNullOrEmpty(this object obj)
        {
            if (obj == null || obj == DBNull.Value || obj.ToString().Trim() == string.Empty)
            {
                return true;
            }

            return false;
        }
        public static string Str(this object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return string.Empty;
            }

            return obj.ToString();
        }
    }
}