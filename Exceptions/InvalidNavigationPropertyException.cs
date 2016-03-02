using System;

namespace Damasio34.Seedwork.Exceptions
{
    public class InvalidNavigationPropertyException : Exception
    {
        public readonly string InvalidNavigationProperty;
        public readonly Type Type;

        public InvalidNavigationPropertyException(string navigationPropertyName, Type type) : base(string.Format("Navigation Property não encontrado: {0}.{1}", type.Name, navigationPropertyName))
        {
            if (navigationPropertyName == null) throw new ArgumentNullException("navigationPropertyName");
            if (type == null) throw new ArgumentNullException("type");

            this.InvalidNavigationProperty = navigationPropertyName;
            this.Type = type;
        }
    }
}
