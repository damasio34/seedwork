using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Damasio34.Seedwork.Aggregates
{
    public interface IAggregateConfiguration<T>
    {
        IAggregateConfiguration<T> HasMany<TMember>(Expression<Func<T, ICollection<TMember>>> memberExpression);

        IAggregateConfiguration<T> HasMany<TMember>(
            Expression<Func<T, ICollection<TMember>>> memberExpression,
            Expression<Func<IAggregateConfiguration<TMember>, object>> memberConfiguration
            );

        IAggregateConfiguration<T> HasRequired<TMember>(Expression<Func<T, TMember>> memberExpression);

        IAggregateConfiguration<T> HasRequired<TMember>(
            Expression<Func<T, TMember>> memberExpression,
            Expression<Func<IAggregateConfiguration<TMember>, object>> memberConfiguration
            );
    }
}