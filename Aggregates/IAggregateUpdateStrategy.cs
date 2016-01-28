using System;
using System.Linq.Expressions;
using Damasio34.Seedwork.UnitOfWork;

namespace Damasio34.Seedwork.Aggregates
{
    /// <summary>
    ///     Interface utilizada por um repositório que encapsular o algoritmo que será usado
    ///     para atualizar uma agregação em um Unit Of Work.
    /// </summary>
    /// <see cref="http://en.wikipedia.org/wiki/Aggregate_pattern"/>
    public interface IAggregateUpdateStrategy
    {
        void AlterarAgregacao<T>(IUnitOfWork unitOfWork, T item, Expression<Func<IAggregateConfiguration<T>, object>> aggregateConfiguration) where T : class;
    }

}
