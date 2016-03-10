using System;
using System.Collections.Generic;
using System.Linq;

namespace Damasio34.Seedwork.Extensions
{

    public static class EnumerableExtensions
    {
        #region ' CompareWith '

        public static void CompareWith<TPara, TDe>(
            this IEnumerable<TPara> para,
            IEnumerable<TDe> de,
            Func<TDe, TPara, bool> comparer,
            Action<IList<TPara>, IList<Tuple<TPara, TDe>>, IList<TDe>> callback)
            where TDe : class
        {
            if (para == null) throw new ArgumentNullException("para");
            if (de == null) throw new ArgumentNullException("de");
            if (comparer == null) throw new ArgumentNullException("comparer");
            if (callback == null) throw new ArgumentNullException("callback");

            // identifica itens novos
            IEnumerable<TDe> novos = de.Where(deItem => !para.Any(paraItem => comparer(deItem, paraItem)));

            // identifica os itens excluidos
            IEnumerable<TPara> excluidos = para.Where(paraItem => !de.Any(deItem => comparer(deItem, paraItem)));

            // identifica itens alterados
            IEnumerable<Tuple<TPara, TDe>> alterados = (from paraItem in para
                let deItem = de.FirstOrDefault(deItem => comparer(deItem, paraItem))
                where deItem != null
                select new Tuple<TPara, TDe>(paraItem, deItem)
                );

            // executa callback
            callback(excluidos.ToList(), alterados.ToList(), novos.ToList());
        }

        #endregion
    }

}