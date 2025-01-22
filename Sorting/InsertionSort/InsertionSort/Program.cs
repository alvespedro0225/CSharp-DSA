void InsertionSort<T>(IList<T> collection) where T : IComparable<T>
{
    for (var i = 0; i < collection.Count; i++)
    {
        for (var j = i - 1; j >= 0; j--)
        {
            if (collection[j].CompareTo(collection[j+1]) > 0)
            {
                (collection[j], collection[j+1]) = (collection[j+1], collection[j]);
            }
            else break;
        }
    }
}

