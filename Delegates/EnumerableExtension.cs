using System.Collections;

namespace Delegates
{
    internal static class EnumerableExtension
    {
        public static T? GetMax<T>(this IEnumerable collection, Func<T, float> convertToNumber) where T : class
        {
            ArgumentNullException.ThrowIfNull(collection);
            ArgumentNullException.ThrowIfNull(convertToNumber);

            T? maxNum = null;
            var num = float.MinValue;
            
            foreach(T item in collection)
            {
                float itemNumber = convertToNumber(item);

                if (itemNumber > num)
                {
                    num = itemNumber;
                    maxNum = item;
                }
            }
            return maxNum;
        }
    }
}
