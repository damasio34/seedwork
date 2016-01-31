using System;
using System.Linq.Expressions;

namespace Damasio34.Seedwork.Specifications
{
    public sealed class DirectSpecification<T> : Specification<T> where T : class
    {
        #region Members

        private readonly Expression<Func<T, bool>> _matchingCriteria;

        #endregion

        #region Constructor

        public DirectSpecification(Expression<Func<T, bool>> matchingCriteria)
        {
            if (matchingCriteria == null) throw new ArgumentNullException("matchingCriteria");

            _matchingCriteria = matchingCriteria;
        }

        #endregion

        #region Override

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override bool SatisfiedBy(T candidate)
        {
            return _matchingCriteria.Compile().Invoke(candidate);
        }

        #endregion
    }
}