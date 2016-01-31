using System;

namespace Damasio34.Seedwork.Specifications
{
    /// <summary>
    ///     NotEspecification convert a original
    ///     specification with NOT logic operator
    /// </summary>
    /// <typeparam name="T">Type of element for this specificaiton</typeparam>
    public sealed class NotSpecification<T> : Specification<T> where T : class
    {
        #region Members

        private readonly ISpecification<T> _originalSpecification;

        #endregion

        #region Constructor

        /// <summary>
        ///     Constructor for NotSpecificaiton
        /// </summary>
        /// <param name="originalSpecification">Original specification</param>
        public NotSpecification(ISpecification<T> originalSpecification)
        {
            if (originalSpecification == null) throw new ArgumentNullException("originalSpecification");

            _originalSpecification = originalSpecification;
        }

        #endregion

        #region Override Specification methods

        /// <summary>
        ///     <see cref="Microsoft.Samples.NLayerApp.Domain.Seedwork.Specification.ISpecification{TEntity}" />
        /// </summary>
        /// <returns>
        ///     <see cref="Microsoft.Samples.NLayerApp.Domain.Seedwork.Specification.ISpecification{TEntity}" />
        /// </returns>
        public override bool SatisfiedBy(T candidate)
        {
            return !_originalSpecification.SatisfiedBy(candidate);
        }

        #endregion
    }
}