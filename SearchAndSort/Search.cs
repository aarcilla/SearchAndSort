namespace SearchAndSort
{
    public class Search
    {
        /// <summary>
        /// Performs a linear search of the provided integer array.
        /// </summary>
        /// <param name="numbers">An array of integers.</param>
        /// <param name="desiredNum">The integer to be searched for.</param>
        /// <returns>The array index of the desired integer (i.e. starting with 0), 
        /// or null if desired integer was not found.</returns>
        public int? Linear(int[] numbers, int desiredNum)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == desiredNum)
                {
                    return i;
                }
            }

            return null;
        }

        /// <summary>
        /// Performs a binary search of the provided sorted integer array.
        /// </summary>
        /// <param name="numbers">An array of integers, assumed to be sorted.</param>
        /// <param name="desiredNum">The integer to be searched for.</param>
        /// <param name="checkIfSorted">Option to skip the check of whether the array is 
        /// sorted or not; mostly for benchmarking purposes.</param>
        /// <param name="descending">For when sort check is disabled, 'descending'
        /// denotes whether the array of integers is sorted in descending order or not.</param>
        /// <returns>The array index of the desired integer (i.e. starting with 0), 
        /// or null if desired integer was not found.</returns>
        public int? Binary(int[] numbers, int desiredNum, bool checkIfSorted = true, bool descending = false)
        {
            // First check if array is sorted (O(n) time operation) 
            if (checkIfSorted)
            {
                bool ascending = true;
                descending = true;
                
                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    // For all integers in array: If the preceding integer in a pair of adjacent integers 
                    // is greater than the following integer, array isn't sorted in ascending order
                    if (numbers[i] > numbers[i + 1])
                    {
                        ascending = false;
                    }

                    if (numbers[i] < numbers[i + 1])
                    {
                        descending = false;
                    }
                }

                // Throw NotInOrderException() if array is neither in ascending nor descending order
                if (!ascending && !descending)
                    throw new SearchAndSort.Exceptions.NotInOrderException();
            }

            int? result = BinaryRecursive(numbers, desiredNum, 0, numbers.Length - 1, descending);
            
            return result;
        }

        /// <summary>
        /// Responsible for recursive calls in divide-and-conquer searching process.
        /// </summary>
        /// <param name="numbers">A sorted array of integers.</param>
        /// <param name="desiredNum">The integer to be searched for.</param>
        /// <param name="minInd">Minimum array index for current valid search range.</param>
        /// <param name="maxInd">Maximum array index for current valid search range.</param>
        /// <param name="isDescending">Boolean denoting whether or not the array of integers is sorted in descending order.</param>
        /// <returns>The array index of the desired integer (i.e. starting with 0), 
        /// or null if desired integer was not found.</returns>
        private int? BinaryRecursive(int[] numbers, int desiredNum, int minInd, int maxInd, bool isDescending)
        {
            if (minInd > maxInd)
            {
                return null;
            }
            else
            {
                // Retrieve mid-point index of array
                int middleInd = (minInd + maxInd) / 2;

                // Compare desired integer with middle integer in array
                if ((!isDescending && desiredNum < numbers[middleInd]) || (isDescending && desiredNum > numbers[middleInd]))
                    return BinaryRecursive(numbers, desiredNum, minInd, middleInd - 1, isDescending);
                else if ((!isDescending && desiredNum > numbers[middleInd]) || (isDescending && desiredNum < numbers[middleInd]))
                    return BinaryRecursive(numbers, desiredNum, middleInd + 1, maxInd, isDescending);
                else
                    return middleInd;
            }
        }
    }
}
