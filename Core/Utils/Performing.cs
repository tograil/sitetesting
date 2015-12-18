using System;
using System.Collections.Generic;

namespace Core.Utils
{
    public static class Performing
    {
        public static T Perform<T>(this T obj, Action<T> operation) where T : class 
        {
            operation(obj);

            return obj;
        }

        public static void DoWithEach<T>(this IEnumerable<T> enumeration, Action<T> operation) where T : class 
        {
            foreach (var element in enumeration)
            {
                operation(element);
            }
        } 
    }
}
