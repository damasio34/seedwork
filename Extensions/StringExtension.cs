using System;

namespace Damasio34.Seedwork.Extensions
{
    public static class StringExtension
    {
        public static bool IsNullOrEmptyOrWhiteSpace(this string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                return true;

            return false;
        }

        public static DateTime? ToDateTimeOrNull(this string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                return null;

            return Convert.ToDateTime(value);
        }
    }
}