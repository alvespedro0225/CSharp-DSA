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


bool IsSorted<T>(IList<T> collection) where T : IComparable<T>
{
    for (var i = 0; i < collection.Count - 1; i++)
    {
        if (collection[i].CompareTo(collection[i + 1]) > 0) return false;
    }
    return true;
}

var random = new Random();
var en = from i in Enumerable.Range(0, 1000) select random.Next(0, 10000);
var list = en.ToList();
Console.WriteLine(IsSorted(list));
QuickSort(list, 0, list.Count - 1);
Console.WriteLine(IsSorted(list));

