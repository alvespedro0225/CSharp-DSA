// Good for saving memory. Good for collections that don't support random access and can't store a lot of info in memory.
// Compares the current value to the next one and swaps them in case the current is bigger, taking the biggest value to
// the end of the array with each iteration.
// Swapped variable makes it better in case the array is already sorted.
void BubbleSort<T>(IList<T> collection) where T : IComparable<T>
{
    for (var i = collection.Count - 1; i > 0; i--)
    {
        var swapped = false;
        for (var j = 0; j < i; j++)
        {
            if (collection[j].CompareTo(collection[j + 1]) <= 0) continue;
            (collection[j], collection[j + 1]) = (collection[j + 1], collection[j]);
            swapped = true;
        }
        if (!swapped) break;
    }
}