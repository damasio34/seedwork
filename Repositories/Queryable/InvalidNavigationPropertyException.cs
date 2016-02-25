using System;

namespace Damasio34.Seedwork.Repositories.Queryable
{
    public class InvalidNavigationPropertyException : Exception
    {
        public readonly String InvalidNavigationProperty;
        public readonly Type Type;

        public InvalidNavigationPropertyException(String navigationPropertyName, Type type)
            : base(String.Format("Navigation Property não encontrado: {0}.{1}", type.Name, navigationPropertyName))
        {
            if (navigationPropertyName == null) throw new ArgumentNullException("navigationPropertyName");
            if (type == null) throw new ArgumentNullException("type");

            this.InvalidNavigationProperty = navigationPropertyName;
            this.Type = type;
        }
    }
}
