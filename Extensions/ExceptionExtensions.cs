using System;

namespace Damasio34.Seedwork.Extensions
{
    public static class ExceptionExtensions
    {

        /// <summary>
        ///     Pega o último nível de uma Exception através da propridade <c>InnerException</c>.
        /// </summary>
        public static Exception GetInnermostException(this Exception ex)
        {
            var innermostException = ex;
            if (innermostException == null) return null;

            var ttl = 0;

            while (innermostException.InnerException != null && ttl < 1000)
            {
                innermostException = innermostException.InnerException;
                ttl++;
            }

            return innermostException;
        }

    }
}
