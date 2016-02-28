using System;
using System.ComponentModel;
using System.Linq;

namespace Damasio34.Seedwork.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum enumValue)
        {
            var descricao = (
                from member in enumValue.GetType().GetMember(enumValue.ToString())
                from attr in
                    member.GetCustomAttributes(typeof (DescriptionAttribute), false).Cast<DescriptionAttribute>()
                select attr.Description
                )
                .DefaultIfEmpty(enumValue.ToString())
                .First();

            return descricao;
        }
    }
}