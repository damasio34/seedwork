using Damasio34.Seedwork.Domain;

namespace Damasio34.Seedwork.Extensions
{
    public static class EntityBaseExtension
    {
        public static bool IsNullOrTransient(this EntidadeBase entityBase)
        {
            return entityBase == null;
        }
    }
}