// Loops through the collection, slowly increasing the maximum bound of the array, while another loop sorts the array
// by swapping the current value to the preceding index until it's in the right place.  
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
            // The sub-array is already sorted from previous iterations, so if the current element is greater than the 
            // last element, it's also greater than every element before.
            else break;
        }
    }
}

