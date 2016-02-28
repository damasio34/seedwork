using System;

namespace Damasio34.Seedwork.Extensions
{
    public static class DateTimeExtension
    {
        public static string ToShortDateString(this DateTime data)
        {
            return data.ToShortDate().ToString();
        }

        public static string ToShortDateString(this DateTime? data)
        {
            if (!data.HasValue) return string.Empty;

            return data.Value.ToShortDate().ToString("dd/MM/yyyy");
        }

        public static DateTime ToShortDate(this DateTime data)
        {
            return new DateTime(data.Year, data.Month, data.Day);
        }

        public static bool EhValida(this DateTime data)
        {
            return !data.Equals(DateTime.MinValue) && !data.Equals(DateTime.MaxValue);
        }

        public static bool EhValida(this DateTime? data)
        {
            if (!data.HasValue) return false;

            return data.Value.EhValida();
        }
    }
}