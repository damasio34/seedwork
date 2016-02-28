using System;
using System.Linq;
using System.Linq.Expressions;
using Damasio34.Seedwork.Aggregates;
using Damasio34.Seedwork.Criterias;
using Damasio34.Seedwork.Domain;
using Damasio34.Seedwork.Repositories.Queryable;
using Damasio34.Seedwork.UnitOfWork;

namespace Damasio34.Seedwork.Repositories
{
    public class Repository<TEntidade>
        : QueryableRepository<TEntidade>
            , IRepository<TEntidade> where TEntidade : class, IEntidadeBase
    {
        #region ' Construtor '

        public Repository(IUnitOfWork uow) : base(uow)
        {
        }

        #endregion

        protected void AlterarAgregacao(TEntidade item,
            Expression<Func<IAggregateConfiguration<TEntidade>, object>> aggregateConfiguration)
        {
            UnitOfWork.AggregateUpdateStrategy.AlterarAgregacao(UnitOfWork, item, aggregateConfiguration);
        }

        #region ' IRepository<TEntidade> '

        public virtual void Incluir(TEntidade item)
        {
            UnitOfWork.RegisterNew(item);
        }

        public virtual void Alterar(TEntidade item)
        {
            AlterarAgregacao(item, null);
        }

        public virtual void Excluir(TEntidade item)
        {
            UnitOfWork.RegisterDeleted(item);
        }

        #endregion

        #region ' IReadonlyRepository '

        public virtual IQueryable<TOutput> Listar<TOutput>(ICriteria<TEntidade, TOutput> criterio)
        {
            return criterio.MeetCriteria(BaseQuery);
        }

        public virtual IQueryable<TEntidade> Listar()
        {
            return BaseQuery;
        }

        public virtual IQueryable<TReturn> Listar<TOutput, TReturn>(ICriteria<TEntidade, TOutput> criterio,
            Expression<Func<TOutput, TReturn>> output)
        {
            return criterio.MeetCriteria(BaseQuery).Select(output);
        }

        public virtual TOutput Selecionar<TOutput>(ICriteria<TEntidade, TOutput> criterio)
        {
            return criterio.MeetCriteria(BaseQuery).SingleOrDefault();
        }

        public virtual TReturn Selecionar<TOutput, TReturn>(ICriteria<TEntidade, TOutput> criterio,
            Expression<Func<TOutput, TReturn>> output)
        {
            return criterio.MeetCriteria(BaseQuery).Select(output).SingleOrDefault();
        }

        #endregion
    }
}