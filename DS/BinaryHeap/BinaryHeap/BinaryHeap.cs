namespace BinaryHeap;
/// <summary>
/// Represents a MaxHeap of ints that can be accessed by index. Provides methods to add, remove and sort elements,
/// as well as a method to extract the top element. 
/// </summary>
public struct BinaryHeap
{
    private readonly int _maxSize;
    private readonly int[] _heap;
    /// <summary>
    /// Gets the number of elements currently in the heap.
    /// </summary>
    public int Count { get; private set; }
    /// <summary>
    /// Gets the maximum number of elements the heap supports.
    /// </summary>
    public required int MaxSize
    {
        get => _maxSize;
        init
        {
            _maxSize = value;
            _heap = new int[_maxSize];
        }
    }
    /// <summary>
    /// Gets or sets indexed element to a value. Reorganizes the heap in case of setting. 
    /// </summary>
    /// <param name="index">The zero-based index of the element to get or set.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="index"/> is less than 0.
    /// -or-
    /// <paramref name="index"/> is equal to or greater than Count.
    /// </exception>
    public int this[int index]
    {
        get
        {
            if ((uint) index > (uint) Count - 1) throw new ArgumentOutOfRangeException
            (
                nameof(index),
                "Index was out of range. Must be non-negative and less than the size of the collection."
            );
            return _heap[index];
        }
        set
        {
            if ((uint) index > (uint) Count - 1) throw new ArgumentOutOfRangeException
            (
                nameof(index),
                "Index was out of range. Must be non-negative and less than the size of the collection."
            );
            ChangePriority(index, value);
        }
    }
    public static int ParentIndex(int index) => (index - 1) / 2;
    public static int LeftIndex(int index) => 2 * index + 1;
    public static int RightIndex(int index) => 2 * index + 2;

    private void SiftUp(int index)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan((uint) index,(uint) Count - 1);
        while (index > 0 && _heap[ParentIndex(index)].CompareTo(_heap[index]) < 0)
        {
            (_heap[index], _heap[ParentIndex(index)]) = (_heap[ParentIndex(index)], _heap[index]);
            index = ParentIndex(index);
        }
    }

    private void SiftDown(int index)
    {
        while (true)
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThan((uint) index,(uint) Count - 1);
            var indexBiggest = index;
            var left = LeftIndex(index);
            var right = RightIndex(index);
            if (left <= Count - 1 && _heap[left].CompareTo(_heap[indexBiggest]) > 0) indexBiggest = left;
            if (right <= Count - 1 && _heap[right].CompareTo(_heap[indexBiggest]) > 0) indexBiggest = right;
            if (indexBiggest == index) return;
            (_heap[index], _heap[indexBiggest]) = (_heap[indexBiggest], _heap[index]);
            index = indexBiggest;
        }
    }
    /// <summary>
    /// Adds an element into it's correct spot in the heap.
    /// </summary>
    /// <param name="value">The value to be added into the heap.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if an element is added to the heap while it's full.
    /// </exception>
    public void Insert(int value)
    {
        if (Count++ == MaxSize) throw new InvalidOperationException("The heap is full.");
        _heap[Count - 1] = value;
        SiftUp(Count - 1);
    }
    /// <summary>
    /// Gets and removes the top element of the heap. 
    /// </summary>
    /// <returns>The top element of the heap.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the heap is empty.</exception>
    public int ExtractMax()
    {
        if (Count == 0) throw new InvalidOperationException("The heap is empty.");
        var extracted = _heap[0];
        _heap[0] = _heap[--Count];
        SiftDown(0);
        return extracted;
    }
    /// <summary>
    /// Removes the element at given <paramref name="index"/>. 
    /// </summary>
    /// <param name="index">The index of the element to be removed.</param>
    public void Remove(int index)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan((uint) index,(uint) Count - 1);
        _heap[index] = int.MaxValue;
        SiftUp(index);
        ExtractMax();
    }

    private void ChangePriority(int index, int newPriority)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan((uint) index,(uint) Count - 1);
        var oldPriority = _heap[index];
        _heap[index] = newPriority;
        if (newPriority < oldPriority) SiftDown(index);
        else SiftUp(index);
    }
    /// <summary>
    /// Sorts given collection using the HeapSort algorithm.
    /// </summary>
    /// <param name="collection">Collection to be sorted. Must implement the IList interface.</param>
    public static void HeapSort(IList<int> collection)
    {
            var heap = new BinaryHeap
            {
                MaxSize = collection.Count,
            };
            for (var i = 0; i < collection.Count; i++)
            {
                heap.Insert(collection[i]);
            }
            for (var i = collection.Count - 1; i >= 0; i--)
            {
                collection[i] = heap.ExtractMax();
            }
    }
    
    public override string ToString()
    {
        var retVal = "[";
        for (var i = 0; i < Count; i++)
        {
            retVal += $"{_heap[i]}";
            if (i != Count - 1) retVal += ", ";
        }
        retVal += "]";
        return retVal;
    }
}
