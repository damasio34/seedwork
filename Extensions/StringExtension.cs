using System;

namespace Damasio34.Seedwork.Extensions
{
    public static class StringExtension
    {
        public static bool IsNullOrEmptyOrWhiteSpace(this string value)
        {
            return string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
        }

        public static DateTime? ToDateTimeOrNull(this string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) return null;

            return Convert.ToDateTime(value);
        }
    }
}