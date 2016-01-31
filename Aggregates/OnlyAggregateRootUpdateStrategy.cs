using System;
using System.Linq.Expressions;
using Damasio34.Seedwork.UnitOfWork;

namespace Damasio34.Seedwork.Aggregates
{
    /// <summary>
    ///     Classe utilizada por um repositório que define que somente a classe
    ///     agregadora será atualizada em um Unit of Work.
    /// </summary>
    public class OnlyAggregateRootUpdateStrategy : IAggregateUpdateStrategy
    {
        public virtual void AlterarAgregacao<TAggRoot>(IUnitOfWork unitOfWork, TAggRoot aggRoot,
            Expression<Func<IAggregateConfiguration<TAggRoot>, object>> aggregateConfiguration) where TAggRoot : class
        {
            if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");
            unitOfWork.RegisterDirty(aggRoot);
        }
    }
}