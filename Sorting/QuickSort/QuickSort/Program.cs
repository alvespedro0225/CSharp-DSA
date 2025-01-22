void QuickSort<T>(IList<T> collection, int start, int end) where T : IComparable<T>
{
    if (start >= end) return;
    var mid = Partition(collection, start, end);
    QuickSort(collection, start, mid-1);
    QuickSort(collection, mid + 1, end);
}

int Partition<T>(IList<T> collection, int start, int end) where T : IComparable<T>
{
    var bigger = start - 1;
    var pivot = collection[end];
    for (var i = start; i < end; i++)
    {
        if (collection[i].CompareTo(pivot) >= 0) continue;
        bigger++;
        (collection[i], collection[bigger]) = (collection[bigger], collection[i]);
    }

    bigger++;
    (collection[bigger], collection[end]) = (collection[end], collection[bigger]);
    return bigger;
}