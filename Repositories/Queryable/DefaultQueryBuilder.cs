using System;
using System.Linq;
using System.Linq.Expressions;

namespace Damasio34.Seedwork.Repositories.Queryable
{
    public class DefaultQueryBuilder<TEntidade> : IQueryBuilder<TEntidade> where TEntidade : class
    {
        #region " IQueryBuilder<> "

        public IQueryable<TReturn> GetQuery<TReturn>(
            IQueryable<TEntidade> from,
                    Expression<Func<TEntidade, TReturn>> output,
                    Expression<Func<TEntidade, bool>> @where = null,
                    Func<IQueryable<TEntidade>, IOrderedQueryable<TEntidade>> orderBy = null)
        {
            var query = GetQuery(from, @where, orderBy);
            return query.Select(output).AsQueryable();
        }

        public IQueryable<TEntidade> GetQuery(
            IQueryable<TEntidade> from,
            Expression<Func<TEntidade, bool>> @where = null,
            Func<IQueryable<TEntidade>, IOrderedQueryable<TEntidade>> orderBy = null,
            dynamic joinWith = null)
        {
            if (from == null) throw new ArgumentException("from");

            var query = from;

            if (@where != null) query = query.Where(@where);
            if (joinWith != null) query = JoinQueryWith(query, joinWith);
            if (orderBy != null) query = orderBy(query);

            return query;

        }

        public virtual IQueryable<TEntidade> JoinQueryWith(
            IQueryable<TEntidade> query, string[] joinWith)
        {
            ValidaArrayDeNavigationProperties(navigationProperties: joinWith);
            return query;
        }

        #endregion

        #region ' Metodos Internos '

        /// <summary>
        /// Valida se array de strings contem nomes válidos de navigation properties.
        /// </summary>
        /// <param name="navigationProperties">Array de strings com os nomes das propriedades existentes em <c>TEntidade</c>.</param>
        protected static void ValidaArrayDeNavigationProperties(string[] navigationProperties)
        {
            if (navigationProperties == null) throw new ArgumentNullException("navigationProperties");

            ValidaArrayDeNavigationProperties(navigationProperties, typeof(TEntidade));
        }

        /// <summary>
        /// Valida se array de strings contem nomes válidos de navigation properties para um determinado tipo de class.
        /// </summary>
        /// <param name="navigationProperties">Array de strings com os nomes dos navigation Properties existentes em <c>T</c>.</param>
        /// <param name="T"></param>
        /// <remarks>
        /// Um navigation property pode conter instruções de acesso à propriedades em mais de um nível. Por exemplo, 
        /// uma entidade 'Cidade' poderia conter o seguinte navigation property: "Estado.Pais"
        ///  </remarks>
        protected static void ValidaArrayDeNavigationProperties(string[] navigationProperties, Type T)
        {
            if (navigationProperties == null) throw new ArgumentNullException("navigationProperties");
            if (T == null) throw new ArgumentNullException("T");

            // Recupera lista das propriedades da classe a ser testada.
            var propriedadesDeT = T.GetProperties().Select(prop => prop.Name).ToArray();

            var directNavigationProperties = navigationProperties.Select(navProp => navProp.Split('.')[0]).Distinct();

            foreach (var _navProp in directNavigationProperties)
            {
                var navProp = _navProp;
                var navPropLenght = navProp.Length;

                if (!propriedadesDeT.Contains(navProp)) throw new InvalidNavigationPropertyException(navProp, T);


                // No caso de haver navigation properties de mais de um nivel, seleciona os níveis inferiores
                // considerando o escolpo da propriedade atual. 
                // E.g.: se inicialmente foi informado o navigation property 'Estado.Pais.Continente', a instrução
                // abaixo determina os navigation properties para a class 'Estado', ou seja, 'Pais.Continente'.
                var twoLevelNavProperties = (from x in navigationProperties
                                             where x != navProp && x.Length >= navPropLenght && x.Substring(0, navPropLenght) == navProp
                                             select x.Substring(navPropLenght + 1)).ToArray();

                // Valida, para o escopo da propriedade atual, os navigation properties.
                if (!twoLevelNavProperties.Any()) continue;
                var navPropType = T.GetProperty(navProp).PropertyType;

                if (navPropType.GetInterface("IEnumerable") != null) navPropType = navPropType.GenericTypeArguments.Single();

                ValidaArrayDeNavigationProperties(twoLevelNavProperties, navPropType);

            }

        }

        #endregion
    }
}
