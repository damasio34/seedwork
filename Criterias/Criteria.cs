using System;
using System.Linq;
using System.Linq.Expressions;

namespace Damasio34.Seedwork.Criterias
{

    public class Criteria<TEntidade> : ICriteria<TEntidade> where TEntidade : class
    {
        protected Expression<Func<TEntidade, bool>> Predicado;

        public Criteria(Expression<Func<TEntidade, bool>> predicado)
        {
            this.Predicado = predicado;
        }

        public IQueryable<TEntidade> MeetCriteria(IQueryable<TEntidade> query)
        {
            return query.Where(this.Predicado);
        }

    }

}
