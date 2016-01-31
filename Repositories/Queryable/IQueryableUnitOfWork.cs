namespace Damasio34.Seedwork.Repositories.Queryable
{
    public interface IQueryableUnitOfWork
    {
        IQueryBuilder<TEntidade> CreateQueryBuilder<TEntidade>() where TEntidade : class;
    }
}