using System;

namespace Damasio34.Seedwork.Exceptions
{
    public class SpecificationException : Exception
    {
        public SpecificationException(string message) : base(message) { }
    }
}