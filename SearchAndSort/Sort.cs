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
                    if ((SortOrder == SortOrder.Asc && numbers[currSortIndex] > numbers[j])
                        || (SortOrder == SortOrder.Desc && numbers[currSortIndex] < numbers[j]))
                    {
                        currSortIndex = j;
                    }
                }

                int temp = numbers[i];
                numbers[i] = numbers[currSortIndex];
                numbers[currSortIndex] = temp;
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
                while(j > 0 && ((SortOrder == SortOrder.Asc && numbers[j - 1] > currNum)
                    || (SortOrder == SortOrder.Desc && numbers[j - 1] < currNum)))
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

        /// <summary>
        /// Performs a bubble sort for provided array of integers.
        /// </summary>
        /// <param name="numbers">Array of integers to be sorted.</param>
        /// <returns>Array of integers in the specified (ascending or descending) order.</returns>
        public int[] Bubble(int[] numbers)
        {
            if (numbers.Length <= 0)
                throw new ArgumentNullException("numbers", "'numbers' does not contain any integers.");

            int maxIndex = numbers.Length;
            int currMaxSwapIndex;

            do {
                currMaxSwapIndex = 0;        // Reset for each full pass

                for(int i = 1; i < maxIndex; i++)
                {
                    if ((SortOrder == SortOrder.Asc && numbers[i - 1] > numbers[i])
                        || (SortOrder == SortOrder.Desc && numbers[i - 1] < numbers[i]))
                    {
                        int temp = numbers[i - 1];
                        numbers[i - 1] = numbers[i];
                        numbers[i] = temp;

                        currMaxSwapIndex = i;
                    }
                }

                maxIndex = currMaxSwapIndex;
            } while (maxIndex > 0);

            return numbers;
        }

        public int[] Quick(int[] numbers)
        {
            if (numbers.Length <= 0)
                throw new ArgumentNullException("numbers", "'numbers' does not contain any integers.");

            return QuickRecursive(numbers, 0, numbers.Length - 1);
        }

        #region Quick sort helper methods

        private int[] QuickRecursive(int[] numbers, int low, int high)
        {
            if (low < high)
            {
                int p = Partition(numbers, low, high);
                QuickRecursive(numbers, low, p - 1);
                QuickRecursive(numbers, p + 1, high);
            }

            return numbers;
        }

        private int Partition(int[] numbers, int low, int high)
        {
            int pivotIndex = (new Random()).Next(low, high);
            int pivotValue = numbers[pivotIndex];

            // Move pivot value to highest position of the subarray
            int temp = numbers[high];
            numbers[high] = pivotValue;
            numbers[pivotIndex] = temp;

            int storeIndex = low;

            // Compare other array elements against pivot value
            for (int i = low; i < high; i++)
            {
                if ((SortOrder == SortOrder.Asc && numbers[i] <= pivotValue)
                    || (SortOrder == SortOrder.Desc && numbers[i] >= pivotValue))
                {
                    temp = numbers[storeIndex];
                    numbers[storeIndex] = numbers[i];
                    numbers[i] = temp;
                    
                    // By the end of the loop traversal, this will hold the correct position 
                    //for the pivot, as we have essentially counted how many subarray values 
                    // are lesser than or equal to it (for asc.; greater than for desc.)
                    storeIndex++;
                }
            }

            // Move pivot into its correct position in the subarray
            temp = numbers[high];
            numbers[high] = numbers[storeIndex];
            numbers[storeIndex] = temp;

            return storeIndex;
        }

        #endregion

        #region Unoptimised sorting algorithms

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
                    if ((SortOrder == SortOrder.Asc && numbers[j - 1] > numbers[j])
                        || (SortOrder == SortOrder.Desc && numbers[j - 1] < numbers[j]))
                    {
                        int temp = numbers[j - 1];
                        numbers[j - 1] = numbers[j];
                        numbers[j] = temp;
                    }
                }
            }

            return numbers;
        }

        public int[] BubbleSlowest(int[] numbers)
        {
            if (numbers.Length <= 0)
                throw new ArgumentNullException("numbers", "'numbers' does not contain any integers.");

            bool swapped;
            do
            {
                swapped = false;        // Reset for each full pass
                for (int i = 1; i < numbers.Length; i++)
                {
                    if ((SortOrder == SortOrder.Asc && numbers[i - 1] > numbers[i])
                        || (SortOrder == SortOrder.Desc && numbers[i - 1] < numbers[i]))
                    {
                        int temp = numbers[i - 1];
                        numbers[i - 1] = numbers[i];
                        numbers[i] = temp;

                        swapped = true;
                    }
                }
            } while (swapped);

            return numbers;
        }

        public int[] BubbleSlower(int[] numbers)
        {
            if (numbers.Length <= 0)
                throw new ArgumentNullException("numbers", "'numbers' does not contain any integers.");

            bool swapped;
            do
            {
                int unsortedPortionLength = numbers.Length;
                swapped = false;

                for (int i = 1; i < unsortedPortionLength; i++)
                {
                    if ((SortOrder == SortOrder.Asc && numbers[i - 1] > numbers[i])
                        || (SortOrder == SortOrder.Desc && numbers[i - 1] < numbers[i]))
                    {
                        int temp = numbers[i - 1];
                        numbers[i - 1] = numbers[i];
                        numbers[i] = temp;

                        swapped = true;
                    }
                }

                // After the n-th pass, the n-th largest number (i.e. from end) is already in its 
                // sorted position, so don't bother with checking them in future passes
                unsortedPortionLength--;
            } while (swapped);

            return numbers;
        }

        #endregion
    }
}
