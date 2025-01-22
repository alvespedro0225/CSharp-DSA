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
