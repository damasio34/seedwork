using System;
using System.Linq;
using System.Linq.Expressions;
using Damasio34.Seedwork.Domain;
using Damasio34.Seedwork.UnitOfWork;

namespace Damasio34.Seedwork.Repositories.Queryable
{
    public class QueryableRepository<TEntidade> : IQueryableRepository<TEntidade> where TEntidade : class, IEntidadeBase
    {
        #region ' Construtor '

        protected QueryableRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");

            UnitOfWork = unitOfWork;
        }

        #endregion

        #region ' IQueryableRepository '

        public IUnitOfWork UnitOfWork { get; }

        public virtual IQueryable<TEntidade> BaseQuery
        {
            get { return UnitOfWork.Set<TEntidade>(); }
        }

        public int Contar(Expression<Func<TEntidade, bool>> @where = null)
        {
            return UnitOfWork.CreateQueryBuilder<TEntidade>().GetQuery(BaseQuery, @where).Count();
        }

        public bool Existe(Expression<Func<TEntidade, bool>> criterio)
        {
            return UnitOfWork.CreateQueryBuilder<TEntidade>().GetQuery(BaseQuery, criterio).Any();
        }

        public IQueryable<TEntidade> Listar(Expression<Func<TEntidade, bool>> @where = null,
            Func<IQueryable<TEntidade>, IOrderedQueryable<TEntidade>> orderBy = null, string[] includeProperties = null)
        {
            return UnitOfWork.CreateQueryBuilder<TEntidade>().GetQuery(BaseQuery, where, orderBy, includeProperties);
        }

        public IQueryable<TOutput> Listar<TOutput>(Expression<Func<TEntidade, TOutput>> output,
            Expression<Func<TEntidade, bool>> @where = null,
            Func<IQueryable<TEntidade>, IOrderedQueryable<TEntidade>> orderBy = null)
        {
            return UnitOfWork.CreateQueryBuilder<TEntidade>().GetQuery(BaseQuery, output, @where, orderBy);
        }

        public TOutput Max<TOutput>(Expression<Func<TEntidade, TOutput>> output,
            Expression<Func<TEntidade, bool>> @where)
        {
            return UnitOfWork.CreateQueryBuilder<TEntidade>().GetQuery(BaseQuery, output, @where).Max();
        }

        public TEntidade Selecionar(Expression<Func<TEntidade, bool>> @where, string[] joinWith = null)
        {
            return
                UnitOfWork.CreateQueryBuilder<TEntidade>()
                    .GetQuery(BaseQuery, @where, joinWith: joinWith)
                    .SingleOrDefault();
        }

        public TOutput Selecionar<TOutput>(Expression<Func<TEntidade, bool>> @where,
            Expression<Func<TEntidade, TOutput>> output)
        {
            var query = UnitOfWork.CreateQueryBuilder<TEntidade>().GetQuery(BaseQuery, output, @where);
            return query.SingleOrDefault();
        }

        #endregion
    }
}