// Used to sort collections of many repeated small numbers.
// Since it's not comparison based, not bounded by O(n log(n)).
// Loops through the collection, using an auxiliary array to store how many times each element repeats, then loops
// through that array, replacing the elements in the original collection.
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