using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Poc.Distributed.Application.Infra.Bootstrap
{
    public static class TypeExtension
    {
        public static IList<T> GetAllPublicConstantValues<T>(this Type type)
        {
            return type
                .GetFields(BindingFlags.Static | BindingFlags.Public)
                .Where(fi => fi.IsLiteral && !fi.IsInitOnly && fi.FieldType == typeof(T))
                .Select(x => (T)x.GetRawConstantValue())
                .ToList();
        }
    }
}
