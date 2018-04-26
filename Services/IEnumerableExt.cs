using System;
using System.Collections.Generic;

namespace Services
{
    public static class IEnumerableExt
    {
        public static void Foreach<T>(this IEnumerable<T> enumerable, Action<T> act)
        {
            foreach (var val in enumerable)
            {
                act.Invoke(val);
            }
        } 
    }
}
