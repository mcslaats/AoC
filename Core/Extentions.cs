using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public static class Extentions
    {
        /// <summary>
        /// Uses a sliding window of size windowSize to return a stream of groups.
        /// 
        /// Example: [1, 2, 3, 4, 5, 6] with windowSize = 3 => [[1, 2, 3], [2, 3, 4], [3, 4, 5], [4, 5, 6]]
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="windowSize"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> SlidingWindow<T>(this IEnumerable<T> @this, int windowSize)
        {
            foreach (var index in Enumerable.Range(0, @this.Count() - (windowSize - 1)))
            {
                yield return @this.Skip(index).Take(windowSize);
            };
        }

        /// <summary>
        /// Uses a window of size windowSize to return a stream of groups.
        /// 
        /// Example: [1, 2, 3, 4, 5, 6] with windowSize = 3 => [[1, 2, 3], [4, 5, 6]]
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="windowSize"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Window<T>(this IEnumerable<T> @this, int windowSize)
        {
            foreach (var index in Enumerable.Range(0, @this.Count() - (windowSize - 1)))
            {
                yield return @this.Skip(index + windowSize - 1).Take(windowSize);
            };
        }

        public static string GetMostAccuringAtIndex(this IEnumerable<string> @this, int index, int length, string value, string value2, string defaultValue)
        {
            int valueCount = @this.Count(t => t.Substring(index, length) == value);
            int value2Count = @this.Count(t => t.Substring(index, length) == value2);
            if(valueCount == value2Count)
            {
                return defaultValue;
            }
            return valueCount > value2Count ? value : value2;
        }
        public static string GetLeastAccuringAtIndex(this IEnumerable<string> @this, int index, int length, string value, string value2, string defaultValue)
        {
            int valueCount = @this.Count(t => t.Substring(index, length) == value);
            int value2Count = @this.Count(t => t.Substring(index, length) == value2);
            if (valueCount == value2Count && defaultValue != null)
            {
                return defaultValue;
            }

            return valueCount < value2Count ? value : value2;
        }
        
        /// <summary>
        /// Transposes a matrix (rows become columns)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Transpose<T>(this IEnumerable<IEnumerable<T>> @this)
        {
            var enumerators = @this.Select(t => t.GetEnumerator()).Where(e => e.MoveNext());
            while (enumerators.Any())
            {
                yield return enumerators.Select(e => e.Current);
                enumerators = enumerators.Where(e => e.MoveNext());
            }
        }

        /// <summary>
        /// Get start of range based on string
        /// Example: '33-56' with seperator '-' => 33;
        /// </summary>
        /// <param name="this"></param>
        /// <param name="seperator"></param>
        /// <returns></returns>

        public static int GetStartOfRange(this string @this, char seperator)
        {
            return int.Parse(@this.Split(seperator)[0]);
        }

        /// <summary>
        /// Get end of range based on string
        /// Example: '33-56' with seperator '-' => 56;
        /// </summary>
        /// <param name="this"></param>
        /// <param name="seperator"></param>
        /// <returns></returns>

        public static int GetEndOfRange(this string @this, char seperator)
        {
            return int.Parse(@this.Split(seperator)[1]);
        }
    }
}
