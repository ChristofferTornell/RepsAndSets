using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepsAndSets.Library
{
    public static class ListExtensions
    {
        public static bool RemoveIfContains<T>(this List<T> list, T item) {
            if (list.Contains(item)) {
                return list.Remove(item);
            }
            return false;
        }
    }
}
