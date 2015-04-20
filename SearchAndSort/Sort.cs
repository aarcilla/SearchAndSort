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

        public int[] InsertionSlow(int[] numbers)
        {
            if (numbers.Length <= 0)
                throw new ArgumentNullException("numbers", "'numbers' does not contain any integers.");

            for (int i = 1; i < numbers.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    // The array item swapping for ALL greater (ascending)
                    // or lesser (descending) integers compared to the current integer
                    // (numbers[j]) is what makes this a slightly slower insertion sort algorithm;
                    // the faster version only makes an assignment ONCE at its rightful position
                    if ((SortOrder == SortOrder.Asc && numbers[j] < numbers[j - 1])
                        || (SortOrder == SortOrder.Desc && numbers[j] > numbers[j - 1]))
                    {
                        int temp = numbers[j - 1];
                        numbers[j - 1] = numbers[j];
                        numbers[j] = temp;
                    }
                }
            }

            return numbers;
        }

        /// <summary>
        /// Performs a insertion sort for provided array of integers.
        /// </summary>
        /// <param name="numbers">Array of integers to be sorted.</param>
        /// <returns>Array of integers in the specified (ascending or descending) order.</returns>
        public int[] Insertion(int[] numbers)
        {
            if (numbers.Length <= 0)
                throw new ArgumentNullException("numbers", "'numbers' does not contain any integers.");

            for (int i = 1; i < numbers.Length; i++)
            {
                int currNum = numbers[i];
                int j = i;

                // Shift numbers greater (ascending) or lesser (descending) 
                // than the current number in the sorted portion to the right
                while(j > 0 && ((SortOrder == SortOrder.Asc && currNum < numbers[j - 1])
                    || (SortOrder == SortOrder.Desc && currNum > numbers[j - 1])))
                {
                    numbers[j] = numbers[j - 1];
                    j--;
                }

                // Once there are no other greater (ascending) or lesser (descending)
                // numbers in the sorted portion, assign the currently evaluated number
                // to its rightful position in the sorted portion
                numbers[j] = currNum;
            }

            return numbers;
        }
    }
}
