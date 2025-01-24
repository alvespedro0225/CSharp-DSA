// Loops through the collection, storing the minimum value each iteration. Then swaps it with the current index in case
// the current index and minimum value index are not the same.
void SelectionSort<T>(IList<T> collection) where T : IComparable<T>
{
    for (var i = 0; i < collection.Count - 1; i++)
    {
        var min = i;
        for (var j = i + 1; j < collection.Count; j++)
        {
            if (collection[j].CompareTo(collection[min]) < 0) min = j;
        }
        if (min == i) continue;
        (collection[i], collection[min]) = (collection[min], collection[i]);
    }
}