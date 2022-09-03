using System.Collections.Generic;
using System.Linq;

namespace Extensions.Enumerable
{
    public static class EnumerableExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> list)
        {
            return list == null || !list.Any();
        }
        public static bool NotNullOrEmpty<T>(this IEnumerable<T> list)
        {
            return !list.IsNullOrEmpty();
        }
    }
}