namespace Damasio34.Seedwork.Specifications
{
    public abstract class CompositeSpecification<T> : Specification<T> where T : class
    {
        public abstract ISpecification<T> LeftSpecification { get; }

        public abstract ISpecification<T> RightSpecification { get; }
    }
}