static bool LinearSearchBool<T>(IEnumerable<T> array, T key) where T : IComparable<T>
{
    foreach (var element in array)
    {
        if (element.CompareTo(key) == 0) return true;
    }
    return false;
}

static int LinearSearch<T>(IList<T> array, T key) where T : IComparable<T>
{
    for (var i = 0; i < array.Count; i++)
    {
        if (array[i].CompareTo(key) == 0) return i;
    }
    return -1;
}
