using System;
using System.Diagnostics.CodeAnalysis;

namespace Damasio34.Seedwork.Specifications
{
    public abstract class Specification<T> : ISpecification<T> where T : class
    {
        public abstract bool SatisfiedBy(T candidate);

        #region Override Operators

        /// <summary>
        ///     Operador And(&)
        /// </summary>
        /// <param name="leftSideSpecification">left operand in this AND operation</param>
        /// <param name="rightSideSpecification">right operand in this AND operation</param>
        /// <returns>New specification</returns>
        public static Specification<T> operator &(
            Specification<T> leftSideSpecification, Specification<T> rightSideSpecification)
        {
            if (leftSideSpecification == null) throw new ArgumentNullException("leftSideSpecification");
            if (rightSideSpecification == null) throw new ArgumentNullException("rightSideSpecification");

            return new AndSpecification<T>(leftSideSpecification, rightSideSpecification);
        }

        /// <summary>
        ///     Or operator
        /// </summary>
        /// <param name="leftSideSpecification">left operand in this OR operation</param>
        /// <param name="rightSideSpecification">left operand in this OR operation</param>
        /// <returns>New specification </returns>
        public static Specification<T> operator |(
            Specification<T> leftSideSpecification, Specification<T> rightSideSpecification)
        {
            if (leftSideSpecification == null) throw new ArgumentNullException("leftSideSpecification");
            if (rightSideSpecification == null) throw new ArgumentNullException("rightSideSpecification");

            return new OrSpecification<T>(leftSideSpecification, rightSideSpecification);
        }

        /// <summary>
        ///     Not specification
        /// </summary>
        /// <param name="specification">Specification to negate</param>
        /// <returns>New specification</returns>
        public static Specification<T> operator !(Specification<T> specification)
        {
            if (specification == null) throw new ArgumentNullException("specification");
            return new NotSpecification<T>(specification);
        }

        /// <summary>
        ///     Override operator false, only for support AND OR operators
        /// </summary>
        /// <param name="specification">Specification instance</param>
        /// <returns>See False operator in C#</returns>
        public static bool operator false(Specification<T> specification)
        {
            return false;
        }

        /// <summary>
        ///     Override operator True, only for support AND OR operators
        /// </summary>
        /// <param name="specification">Specification instance</param>
        /// <returns>See True operator in C#</returns>
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "specification")]
        public static bool operator true(Specification<T> specification)
        {
            return false;
        }

        #endregion
    }
}