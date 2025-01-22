List<T> MergeSort<T>(List<T> collection) where T : IComparable<T>
{
    if (collection.Count <= 1) return collection;
    var mid = (collection.Count) / 2;
    var left = MergeSort(collection[..mid]);
    var right = MergeSort(collection[mid..]);
    return Merge(left, right);
}

List<T> Merge<T>(List<T> left, List<T> right) where T : IComparable<T>
{
    var l = 0;
    var r = 0;
    List<T> result = [];
    while (l < left.Count && r < right.Count)
    {
        switch (left[l].CompareTo(right[r]))
        {
            case <= 0: result.Add(left[l++]); break;
            case > 0: result.Add(right[r++]); break;
        }
    }
    
    while (l < left.Count) result.Add(left[l++]);
    while (r < right.Count) result.Add(right[r++]);
    return result;
}

void InPlaceMergeSort<T>(List<T> collection, int start, int end) where T : IComparable<T>
{
    if (start >= end) return;
    var mid = start + (end - start) / 2;
    InPlaceMergeSort(collection, start, mid);
    InPlaceMergeSort(collection, mid + 1, end);
    InPlaceMerge(collection, start, mid, end);
}

void InPlaceMerge<T>(List<T> collection, int start, int mid, int end) where T : IComparable<T>
{
    var size1 = mid - start + 1;
    var temp1 = new T[size1];
    var size2 = end - mid;
    var temp2 = new T[size2];
    // start and (mid + 1) represent the starting in the original array that temp1 and temp2 represent
    for (var i = 0; i < size1; i++) temp1[i] = collection[start + i];
    for (var j = 0; j < size2; j++) temp2[j] = collection[mid + 1 + j];
    var temp1Index = 0;
    var temp2Index = 0;

    while (temp1Index < size1 && temp2Index < size2)
    {
        collection[start++] = temp1[temp1Index].CompareTo(temp2[temp2Index]) switch
        {
            <= 0 => temp1[temp1Index++],
            > 0 => temp2[temp2Index++]
        };
    }

    while (temp1Index < size1) collection[start++] = temp1[temp1Index++];
    while (temp2Index < size2) collection[start++] = temp2[temp2Index++];
}