using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Scheduler.Commons
{
    using System.Collections;
    using System.Reflection;

    public static class Extensions
    {
        /// <summary>
        ///     Turn anonymous object to dictionary
        /// </summary>
        /// <param name="data">Anonymous object</param>
        /// <returns>Dictionary</returns>
        public static Dictionary<string, object> ToDictionary(this object data)
        {
            return (from property in data.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                where property.CanRead
                select property)
                .ToDictionary(property => property.Name, property => property.GetValue(data, null));
        }

        public static IEnumerable<TData> ForEach<TData>(this IEnumerable<TData> enumerable, Action<TData> action)
        {
            var enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                action(current);
                yield return current;
            }
        }
    }
}
