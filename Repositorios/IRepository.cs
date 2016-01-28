using System;
using System.Linq;
using System.Linq.Expressions;
using Damasio34.Seedwork.Criterias;
using Damasio34.Seedwork.Repositorios.Queryable;

namespace Damasio34.Seedwork.Repositorios
{

    public interface IRepository<TEntidade> : IQueryableRepository<TEntidade> where TEntidade : class
    {

        void Incluir(TEntidade item);

        void Alterar(TEntidade item);

        void Excluir(TEntidade item);

        /// <summary>
        /// Retorna uma lista dos objetos contidos no repositório, filtrados baseado em um critério.
        /// </summary>
        IQueryable<TOutput> Listar<TOutput>(ICriteria<TEntidade, TOutput> criterio);

        IQueryable<TReturn> Listar<TOutput, TReturn>(ICriteria<TEntidade, TOutput> criterio, Expression<Func<TOutput, TReturn>> output);

        IQueryable<TEntidade> Listar();

        TOutput Selecionar<TOutput>(ICriteria<TEntidade, TOutput> criterio);

        TReturn Selecionar<TOutput, TReturn>(ICriteria<TEntidade, TOutput> criterio, Expression<Func<TOutput, TReturn>> output);

    }

}