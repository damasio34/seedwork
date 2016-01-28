
namespace Damasio34.Seedwork.Repositorios.Queryable
{
    public interface IQueryableUnitOfWork
    {
        IQueryBuilder<TEntidade> CreateQueryBuilder<TEntidade>() where TEntidade : class;
    }
}
