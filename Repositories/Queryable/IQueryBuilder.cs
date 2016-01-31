using System;
using System.Linq;
using System.Linq.Expressions;

namespace Damasio34.Seedwork.Repositories.Queryable
{
    public interface IQueryBuilder<TEntidade> where TEntidade : class
    {
        IQueryable<TReturn> GetQuery<TReturn>(
            IQueryable<TEntidade> from,
            Expression<Func<TEntidade, TReturn>> output,
            Expression<Func<TEntidade, bool>> @where = null,
            Func<IQueryable<TEntidade>, IOrderedQueryable<TEntidade>> orderBy = null);

        IQueryable<TEntidade> GetQuery(
            IQueryable<TEntidade> from,
            Expression<Func<TEntidade, bool>> @where = null,
            Func<IQueryable<TEntidade>, IOrderedQueryable<TEntidade>> orderBy = null,
            dynamic joinWith = null);

        IQueryable<TEntidade> JoinQueryWith(IQueryable<TEntidade> query, string[] joinWith);
    }
}