namespace Damasio34.Seedwork.Specifications
{
    public interface ISpecification<in T> where T : class
    {
        bool SatisfiedBy(T cadidate);
    }
}