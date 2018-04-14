using System;
using System.Linq;

namespace Pips.Test.Extensions
{
    public static class TypeExtensions
    {
        public static bool HasPropertyOfType<T>(this Type type, string propertyName)
        {
            if (type.GetProperties().Any(x => x.Name == propertyName && x.PropertyType == typeof(T)))
            {
                return true;
            }
            return false;
        }
    }
}
