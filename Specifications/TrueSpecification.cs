namespace Damasio34.Seedwork.Specifications
{
    public class TrueSpecification<T> : Specification<T> where T : class
    {
        #region Specification overrides

        public override bool SatisfiedBy(T candidate)
        {
            return true;
        }

        #endregion
    }
}