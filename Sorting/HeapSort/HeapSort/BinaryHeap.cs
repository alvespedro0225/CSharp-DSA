namespace HeapSort;

struct BinaryHeap
{
    private readonly int[] _heap;
    private readonly int _maxSize;
    private int Count { get; set; }

    public required int MaxSize
    {
        get => _maxSize;
        init
        {
            _maxSize = value;
            _heap = new int[_maxSize];
        }
    }

    private static int ParentIndex(int index) => (index - 1) / 2;
    private static int LeftIndex(int index) => index * 2 + 1;
    private static int RightIndex(int index) => index * 2 + 2;

    private void SiftDown(int index)
    {
        while (true)
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThan((uint) index,(uint) Count - 1);
            var biggestIndex = index;
            var left = LeftIndex(index);
            var right = RightIndex(index);
            if (left < Count) biggestIndex = _heap[left] > _heap[biggestIndex] ? left : biggestIndex;
            if (right < Count) biggestIndex = _heap[right] > _heap[biggestIndex] ? right : biggestIndex;
            if (biggestIndex == index) return;
            (_heap[index], _heap[biggestIndex]) = (_heap[biggestIndex], _heap[index]);
            index = biggestIndex;
        }
    }

    private void SiftUp(int index)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan((uint) index,(uint) Count - 1);
        while (index > 0 && _heap[index] > _heap[ParentIndex(index)])
        {
            (_heap[index], _heap[ParentIndex(index)]) = (_heap[index], _heap[index]);
            index = ParentIndex(index);
        }
    }
    
    public void Insert(int value)
    {
        if (Count++ == MaxSize) throw new InvalidOperationException("Heap is full");
        _heap[Count - 1] = value;
        SiftUp(Count - 1);
    }

    public int ExtractTop()
    {
        if (Count == 0) throw new InvalidOperationException("The heap is empty.");
        var extracted = _heap[0];
        _heap[0] = _heap[--Count];
        SiftDown(0);
        return extracted;
    }
    
}