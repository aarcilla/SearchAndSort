using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// <returns>The array index of the desired integer (i.e. starting with 0), 
        /// or null if desired integer was not found.</returns>
        public int? Binary(int[] numbers, int desiredNum)
        {
            // First check if array is sorted
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                // If the preceding integer in a pair of adjacent integers 
                // is greater than the following integer, array isn't sorted
                if (numbers[i] > numbers[i + 1])
                {
                    throw new SearchAndSort.Exceptions.NotInOrderException(i, numbers[i]);
                }
            }

            int? result = BinaryRecursive(numbers, desiredNum, 0, numbers.Length - 1);
            
            return result;
        }

        /// <summary>
        /// Responsible for recursive calls in divide-and-conquer searching process.
        /// </summary>
        /// <param name="numbers">A sorted array of integers.</param>
        /// <param name="desiredNum">The integer to be searched for.</param>
        /// <param name="minInd">Minimum array index for current valid search range.</param>
        /// <param name="maxInd">Maximum array index for current valid search range.</param>
        /// <returns>The array index of the desired integer (i.e. starting with 0), 
        /// or null if desired integer was not found.</returns>
        private int? BinaryRecursive(int[] numbers, int desiredNum, int minInd, int maxInd)
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
                if (desiredNum < numbers[middleInd])
                    return BinaryRecursive(numbers, desiredNum, minInd, middleInd - 1);
                else if (desiredNum > numbers[middleInd])
                    return BinaryRecursive(numbers, desiredNum, middleInd + 1, maxInd);
                else
                    return middleInd;
            }
        }
    }
}
