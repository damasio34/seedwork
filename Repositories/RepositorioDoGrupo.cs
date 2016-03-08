using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Damasio34.Seedwork.Aggregates;
using Damasio34.Seedwork.Domain;
using Damasio34.Seedwork.UnitOfWork;

namespace Damasio34.Seedwork.Repositories
{
    public class RepositorioDoGrupo<TEntidade> : Repository<TEntidade>, IRepositorioDoGrupo<TEntidade>
        where TEntidade : EntidadeDoGrupo
    {
        private readonly IAutenticacao _autenticacao;

        #region ' Constructor '

        public RepositorioDoGrupo(IUnitOfWork uow, IAutenticacao autenticacao) : base(uow)
        {
            _autenticacao = autenticacao;
        }

        #endregion

        protected Guid IdGrupo
        {
            get { return _autenticacao.IdGrupo; }
        }

        public override IQueryable<TEntidade> BaseQuery
        {
            get { return base.BaseQuery.Where(entidade => entidade.IdGrupo == IdGrupo); }
        }

        public override void Incluir(TEntidade item)
        {
            if (item == null) throw new ArgumentNullException("item");
            item.IdGrupo = IdGrupo;
            base.Incluir(item);
        }

        public override void Alterar(TEntidade item)
        {
            if (item == null) throw new ArgumentNullException("item");
            // ToDo: Validar IdGrupo @ RepositorioDoGrupo
            item.IdGrupo = IdGrupo;
            base.Alterar(item);
        }

        public override void Excluir(TEntidade item)
        {
            if (item == null) throw new ArgumentNullException("item");
            item.IdGrupo = IdGrupo;
            base.Excluir(item);
        }

        protected override void AlterarAgregacao(TEntidade item,
            Expression<Func<IAggregateConfiguration<TEntidade>, object>> aggregateConfiguration)
        {
            if (item == null) throw new ArgumentNullException("item");
            item.IdGrupo = IdGrupo;
            base.AlterarAgregacao(item, aggregateConfiguration);
        }

        /// <summary>
        ///     Configura as FK Properties dos itens agregados informados.
        /// </summary>
        /// <typeparam name="TDestino">Tipo do item agregado.</typeparam>
        /// <param name="aggregateRoot">Instância do aggregate root.</param>
        /// <param name="navigationProperty">Expressão lambda de acesso à lista de itens agregados.</param>
        /// <param name="fkPropertyExpression">Expressão lambda de acesso à FK property</param>
        protected void AjustarRelacionamentoComItensAgregados<TDestino>(
            TEntidade aggregateRoot,
            Expression<Func<TEntidade,
                IEnumerable<TDestino>>> navigationProperty,
            Expression<Func<TDestino, Guid>> fkPropertyExpression
            ) where TDestino : class
        {
            var itensAgregados = navigationProperty.Compile().Invoke(aggregateRoot);
            var fkProperty = (PropertyInfo) ((MemberExpression) fkPropertyExpression.Body).Member;

            // ToDo: Validar IdGrupo @ RepositorioDoGrupo
            aggregateRoot.IdGrupo = IdGrupo;

            if (itensAgregados != null)
                foreach (var item in itensAgregados)
                {
                    // seta o valor para o fk property.
                    fkProperty.SetValue(item, aggregateRoot.Id);
                    //if (item is IEntidadeDoGrupoEmpresa) 
                    //((IEntidadeDoGrupoEmpresa) item).IdGrupo = aggregateRoot.IdGrupo;
                }
        }
    }
}