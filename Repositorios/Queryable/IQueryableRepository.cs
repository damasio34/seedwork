using System;
using System.Linq;
using System.Linq.Expressions;
using Damasio34.Seedwork.UnitOfWork;

namespace Damasio34.Seedwork.Repositorios.Queryable
{
    public interface IQueryableRepository<TEntidade> where TEntidade : class
    {
        IUnitOfWork UnitOfWork { get; }

        IQueryable<TEntidade> BaseQuery { get; }

        IQueryable<TEntidade> Listar(
            Expression<Func<TEntidade, bool>> @where = null,
            Func<IQueryable<TEntidade>, IOrderedQueryable<TEntidade>> orderBy = null,
            string[] joinWith = null);

        IQueryable<TOutput> Listar<TOutput>(
            Expression<Func<TEntidade, TOutput>> output,
            Expression<Func<TEntidade, bool>> @where = null,
            Func<IQueryable<TEntidade>, IOrderedQueryable<TEntidade>> orderBy = null);

        /// <summary>
        /// Retorna um único objeto do reposítorio.
        /// </summary>
        TEntidade Selecionar(Expression<Func<TEntidade, bool>> @where, string[] joinWith = null);

        /// <summary>
        /// Retorna um único registro do repositório, realizando um Select somente nas colunas selecionadas.
        /// </summary>
        TOutput Selecionar<TOutput>(Expression<Func<TEntidade, bool>> @where, Expression<Func<TEntidade, TOutput>> output);


    }
}
