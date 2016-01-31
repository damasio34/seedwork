using Damasio34.Seedwork.Domain;

namespace Damasio34.Seedwork.Repositories
{
    public interface IRepositorioDoGrupo<TEntidade> : IRepository<TEntidade>
        where TEntidade : class, IEntidadeDoGrupo
    {
    }
}