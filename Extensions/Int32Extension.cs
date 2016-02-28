using System;
using System.Collections.Generic;

namespace Damasio34.Seedwork.Extensions
{
    public static class Int32Extension
    {
        public static int IsNull(this int? value, int constante)
        {
            return value.HasValue ? value.Value : constante;
        }

        public static IEnumerable<T> For<T>(this int totalinteracao, Func<int, T> funcao)
        {
            for (int i = 0; i < totalinteracao; i++)
                yield return funcao(i);
        }
    }
}