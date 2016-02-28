namespace Damasio34.Seedwork.Extensions
{
    public static class EntidadeBaseExtension
    {
        public static bool IsNull<IEntidadeBase>(this IEntidadeBase entidade)
        {
            return entidade == null;
        }
    }
}