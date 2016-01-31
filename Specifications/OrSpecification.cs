using System;

namespace Damasio34.Seedwork.Specifications
{
    /// <summary>
    ///     A Logic OR Specification
    /// </summary>
    /// <typeparam name="T">Type of entity that check this specification</typeparam>
    public sealed class OrSpecification<T> : CompositeSpecification<T> where T : class
    {
        #region Public Constructor

        /// <summary>
        ///     Default constructor for AndSpecification
        /// </summary>
        /// <param name="left">Left side specification</param>
        /// <param name="right">Right side specification</param>
        public OrSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            if (left == null) throw new ArgumentNullException("left");
            if (right == null) throw new ArgumentNullException("right");


            _leftSideSpecification = left;
            _rightSideSpecification = right;
        }

        #endregion

        #region Members

        private readonly ISpecification<T> _rightSideSpecification;
        private readonly ISpecification<T> _leftSideSpecification;

        #endregion

        #region Composite Specification overrides

        /// <summary>
        ///     Left side specification
        /// </summary>
        public override ISpecification<T> LeftSpecification
        {
            get { return _leftSideSpecification; }
        }

        /// <summary>
        ///     Righ side specification
        /// </summary>
        public override ISpecification<T> RightSpecification
        {
            get { return _rightSideSpecification; }
        }

        /// <summary>
        ///     <see cref="Microsoft.Samples.NLayerApp.Domain.Seedwork.Specification.ISpecification{T}" />
        /// </summary>
        /// <returns>
        ///     <see cref="Microsoft.Samples.NLayerApp.Domain.Seedwork.Specification.ISpecification{T}" />
        /// </returns>
        public override bool SatisfiedBy(T candidate)
        {
            var left = _leftSideSpecification.SatisfiedBy(candidate);
            var right = _rightSideSpecification.SatisfiedBy(candidate);

            return left || right;
        }

        #endregion
    }
}