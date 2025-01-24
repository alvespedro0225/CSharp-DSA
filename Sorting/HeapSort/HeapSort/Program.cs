using HeapSort;

var random = new Random();
var en = from i in Enumerable.Range(0, 9999) select random.Next();
var list = en.ToList();
Console.WriteLine(IsSorted(list));
HeapSort(list);
Console.WriteLine(IsSorted(list));
return;

// Inserts all elements of the array into a heap then extracts them into the array by decreasing index,
// making the array sorted.
void HeapSort(IList<int> collection)
{
    var heap = new BinaryHeap
    {
        MaxSize = collection.Count
    };
        
    for (var i = 0; i < collection.Count; i++)
    {
        heap.Insert(collection[i]);
    }
    
    for (var i = collection.Count - 1; i >= 0; i--)
    {
        collection[i] = heap.ExtractTop();
    }
}

bool IsSorted(IList<int> collection)
{
    for (var i = 0; i < collection.Count - 1; i++)
    {
        if (collection[i] > collection[i + 1]) return false;
    }
    return true;
}