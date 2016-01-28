using System.Linq;

namespace Damasio34.Seedwork.Criterias
{

    public interface ICriteria<TEntidade, TOutput>
    {
        IQueryable<TOutput> MeetCriteria(IQueryable<TEntidade> query);
    }


    public interface ICriteria<TEntidade> : ICriteria<TEntidade, TEntidade>
    {
        
    }

}