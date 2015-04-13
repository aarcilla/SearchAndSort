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
        /// <param name="numbers">An enumerable of integers.</param>
        /// <returns>The array index of the desired integer (i.e. starting with 0).</returns>
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
    }
}
