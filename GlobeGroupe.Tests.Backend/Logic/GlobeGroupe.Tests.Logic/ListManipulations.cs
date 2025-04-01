namespace GlobeGroupe.Tests.Logic;

public static class ListManipulations
{
    /// <summary>
    ///     Take a sorted array of unique integer and count the elements that are less than the parameter "lessThan"
    ///     ex: ({1, 3, 5, 7}, 4) = 2 (2 elements less than 4)
    /// </summary>
    /// <param name="sortedArray"></param>
    /// <param name="lessThan"></param>
    /// <returns></returns>
    public static int CountLessThan(int[] sortedArray, int lessThan)
    {
        // use of Array.BinarySearch() is forbidden
        if (sortedArray == null)
        {
            throw new ArgumentNullException(nameof(sortedArray));
        }

        int startIndex = 0;
        int endIndex = sortedArray.Length - 1;

        while (startIndex <= endIndex)
        {
            int halfIndex = startIndex + (endIndex - startIndex) / 2;

            if (sortedArray[halfIndex] < lessThan)
            {
                startIndex = halfIndex + 1;
            }
            else
            {
                endIndex = halfIndex - 1;
            }
        }

        return startIndex;
    }
}
