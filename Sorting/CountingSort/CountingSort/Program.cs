void CountingSort(List<int> collection)
{
    var size = collection.Max() + 1;
    var counter = new int[size];
    for (var i = 0; i < collection.Count; i++)
    {
        var number = collection[i];
        counter[number]++;
    }

    var j = 0;
    for (var i = 0; i < size; i++)
    {
        var repetitions = counter[i];
        var count = 0;
        while (count < repetitions)
        {
            collection[j++] = i;
            count++;
        }
    }
}