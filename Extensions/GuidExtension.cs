using System;

namespace Damasio34.Seedwork.Extensions
{
    public static class GuidExtension
    {
        public static bool EhValido(this Guid guid)
        {
            return !guid.Equals(Guid.Empty);
        }

        public static bool EhValido(this Guid? guid)
        {
            return guid.HasValue && guid.Value.EhValido();
        }
    }
}
