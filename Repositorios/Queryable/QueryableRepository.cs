using System;
using System.Linq;
using System.Linq.Expressions;
using Damasio34.Seedwork.UnitOfWork;

namespace Damasio34.Seedwork.Repositorios.Queryable
{
    public class QueryableRepository<TEntidade> : IQueryableRepository<TEntidade> where TEntidade : class
    {
        private readonly IUnitOfWork _unitOfWork;

        #region ' Construtor '

        protected QueryableRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");

            _unitOfWork = unitOfWork;
        }

        #endregion

        #region ' IQueryableRepository '

        public IUnitOfWork UnitOfWork
        {
            get { return this._unitOfWork;  }
        }

        public virtual IQueryable<TEntidade> BaseQuery
        {
            get { return this._unitOfWork.Set<TEntidade>(); }
        }

        public int Contar(Expression<Func<TEntidade, bool>> @where = null)
        {
            return _unitOfWork.CreateQueryBuilder<TEntidade>().GetQuery(BaseQuery, @where: @where).Count();
        }

        public bool Existe(Expression<Func<TEntidade, bool>> criterio)
        {
            return this._unitOfWork.CreateQueryBuilder<TEntidade>().GetQuery(BaseQuery, @where: criterio).Any();
        }

        public IQueryable<TEntidade> Listar(Expression<Func<TEntidade, bool>> @where = null, Func<IQueryable<TEntidade>, IOrderedQueryable<TEntidade>> orderBy = null, string[] includeProperties = null)
        {
            return this._unitOfWork.CreateQueryBuilder<TEntidade>().GetQuery(BaseQuery, where, orderBy, includeProperties);
        }

        public IQueryable<TOutput> Listar<TOutput>(Expression<Func<TEntidade, TOutput>> output, Expression<Func<TEntidade, bool>> @where = null, Func<IQueryable<TEntidade>, IOrderedQueryable<TEntidade>> orderBy = null)
        {
            return this._unitOfWork.CreateQueryBuilder<TEntidade>().GetQuery(BaseQuery, output, @where, orderBy);
        }

        public TOutput Max<TOutput>(Expression<Func<TEntidade, TOutput>> output, Expression<Func<TEntidade, bool>> @where)
        {
            return this._unitOfWork.CreateQueryBuilder<TEntidade>().GetQuery(BaseQuery, output, @where).Max();
        }

        public TEntidade Selecionar(Expression<Func<TEntidade, bool>> @where, string[] joinWith = null)
        {
            return this._unitOfWork.CreateQueryBuilder<TEntidade>().GetQuery(BaseQuery, @where: @where, joinWith: joinWith).SingleOrDefault();
        }

        public TOutput Selecionar<TOutput>(Expression<Func<TEntidade, bool>> @where, Expression<Func<TEntidade, TOutput>> output)
        {
            var query = this._unitOfWork.CreateQueryBuilder<TEntidade>().GetQuery(BaseQuery, output, @where);
            return query.SingleOrDefault();
        }

        #endregion

    }
}
