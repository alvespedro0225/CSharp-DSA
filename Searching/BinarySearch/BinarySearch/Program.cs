namespace BinarySearch;

public static class Program
{
    /// <summary>
    /// Searches for an element <c>target</c> in a sorted array and returns it's index if present and -1 is not.
    /// </summary>
    /// <param name="collection">Any collection that implements IList</param>
    /// <param name="target">The target elements to be searched in the array </param>
    /// <typeparam name="T">Any type that supports comparison</typeparam>
    /// <returns>The index of the element if present and -1 if it isn't</returns>
    private static int IterBinarySearch<T>(IList<T> collection, T target) where T : IComparable<T>
    {
        if (collection.Count == 0) return -1;
        var max = collection.Count - 1;
        var min = 0;
        while (min <= max)
        {
            var mid = (min + max) / 2;
            switch (target.CompareTo(collection[mid]))
            {
                case > 0: min = mid + 1; break;
                case < 0: max = mid - 1; break;
                case 0: return mid;
            }
        }

        return -1;
    }

    private static int RecBinarySearch<T>(IList<T> collection, T target, int start, int end) where T : IComparable<T>
    {
        if (start > end) return -1;
        var mid = (end - start) / 2 + start;
        return target.CompareTo(collection[mid]) switch
        {
            > 0 => RecBinarySearch(collection, target, mid + 1, end),
            < 0 => RecBinarySearch(collection, target, start, mid - 1),
            0 => mid
        };
    }
}

