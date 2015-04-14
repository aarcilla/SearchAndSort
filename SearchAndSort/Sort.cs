using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAndSort
{
    public enum SortOrder
    {
        Asc, Desc
    }

    public class Sort
    {
        public Sort(SortOrder order = SortOrder.Asc)
        {
            SortOrder = order;
        }

        public SortOrder SortOrder { get; set; }

        /// <summary>
        /// Performs a selection sort for provided array of integers.
        /// </summary>
        /// <param name="numbers">Array of integers to be sorted.</param>
        /// <returns>Array of integers in the specified (ascending or descending) order.</returns>
        public int[] Selection(int[] numbers)
        {
            if (numbers.Length <= 0)
                throw new ArgumentNullException("numbers", "'numbers' does not contain any integers.");

            int currSortIndex;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                currSortIndex = i;

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (SortOrder == SortOrder.Asc)
                    {
                        if (numbers[j] < numbers[currSortIndex])
                        {
                            currSortIndex = j;
                        }
                    }
                    else if (SortOrder == SortOrder.Desc)
                    {
                        if (numbers[j] > numbers[currSortIndex])
                        {
                            currSortIndex = j;
                        }
                    }
                }

                int temp = numbers[i];
                numbers[i] = numbers[currSortIndex];
                numbers[currSortIndex] = temp;
            }

            return numbers;
        }
    }
}
