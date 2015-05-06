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

            int currSortInd;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                currSortInd = i;

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if ((SortOrder == SortOrder.Asc && numbers[currSortInd] > numbers[j])
                        || (SortOrder == SortOrder.Desc && numbers[currSortInd] < numbers[j]))
                    {
                        currSortInd = j;
                    }
                }

                if (currSortInd != i)
                {
                    Swap<int>(numbers, i, currSortInd);
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

            int maxInd = numbers.Length;
            int currMaxSwapInd;

            do {
                currMaxSwapInd = 0;        // Reset for each full pass

                for(int i = 1; i < maxInd; i++)
                {
                    if ((SortOrder == SortOrder.Asc && numbers[i - 1] > numbers[i])
                        || (SortOrder == SortOrder.Desc && numbers[i - 1] < numbers[i]))
                    {
                        Swap<int>(numbers, i - 1, i);
                        currMaxSwapInd = i;
                    }
                }

                maxInd = currMaxSwapInd;
            } while (maxInd > 0);

            return numbers;
        }

        /// <summary>
        /// Performs a quicksort for provided array of integers.
        /// </summary>
        /// <param name="numbers">Array of integers to be sorted.</param>
        /// <returns>Array of integers in the specified (ascending or descending) order.</returns>
        public int[] Quick(int[] numbers)
        {
            if (numbers.Length <= 0)
                throw new ArgumentNullException("numbers", "'numbers' does not contain any integers.");

            QuickRecursive(numbers, 0, numbers.Length - 1);

            return numbers;
        }

        #region Quick sort helper methods

        private void QuickRecursive(int[] numbers, int low, int high)
        {
            if (low < high)
            {
                int p = Partition(numbers, low, high);
                QuickRecursive(numbers, low, p - 1);
                QuickRecursive(numbers, p + 1, high);
            }
        }

        private int Partition(int[] numbers, int low, int high)
        {
            int pivotInd = (new Random()).Next(low, high);
            int pivotValue = numbers[pivotInd];

            // Move pivot value to highest position of the subarray
            Swap<int>(numbers, high, pivotInd);

            int storeInd = low;

            // Compare other array elements against pivot value
            for (int i = low; i < high; i++)
            {
                if ((SortOrder == SortOrder.Asc && numbers[i] <= pivotValue)
                    || (SortOrder == SortOrder.Desc && numbers[i] >= pivotValue))
                {
                    Swap<int>(numbers, storeInd, i);
                    
                    // By the end of the loop traversal, this will hold the correct position 
                    //for the pivot, as we have essentially counted how many subarray values 
                    // are lesser than or equal to it (for asc.; greater than for desc.)
                    storeInd++;
                }
            }

            // Move pivot into its correct position in the subarray
            Swap<int>(numbers, high, storeInd);

            return storeInd;
        }

        #endregion

        /// <summary>
        /// Performs a merge sort for provided array of integers.
        /// </summary>
        /// <param name="numbers">Array of integers to be sorted.</param>
        /// <returns>Array of integers in the specified (ascending or descending) order.</returns>
        public int[] Merge(int[] numbers)
        {
            if (numbers.Length <= 0)
                throw new ArgumentNullException("numbers", "'numbers' does not contain any integers.");

            MergeRecursive(numbers, 0, numbers.Length, new int[numbers.Length]);

            return numbers;
        }

        #region Merge sort helper methods

        private void MergeRecursive(int[] numbers, int iBegin, int iEnd, int[] mergingNumbers)
        {
            if (iEnd - iBegin > 1)
            {
                // Recursively split runs into 2 halves until run size == 1
                int iMiddle = (iBegin + iEnd) / 2;
                MergeRecursive(numbers, iBegin, iMiddle, mergingNumbers);
                MergeRecursive(numbers, iMiddle, iEnd, mergingNumbers);
                MergeHalves(numbers, iBegin, iMiddle, iEnd, mergingNumbers);

                // Copy sorted array (from merging process) into initial array
                for (int i = iBegin; i < iEnd; i++)
                {
                    numbers[i] = mergingNumbers[i];
                }
            }
        }

        private void MergeHalves(int[] numbers, int iBegin, int iMiddle, int iEnd, int[] mergingNumbers)
        {
            // Traversal pointers for left and right halves
            int currLeftInd = iBegin, currRightInd = iMiddle;

            Func<int, int, bool> conditionBySortOrder = (numLeft, numRight) =>
                (SortOrder == SortOrder.Asc && numLeft <= numRight)
                    || (SortOrder == SortOrder.Desc && numLeft >= numRight);

            for (int i = iBegin; i < iEnd; i++)
            {
                // 1. Left half still unsorted, AND EITHER
                // 1a. Right half all sorted (i.e. left is all that's left to sort) OR
                // 1b. Curr left half num <= curr right half num (for asc.; >= for desc.)
                if (currLeftInd < iMiddle && (currRightInd >= iEnd || conditionBySortOrder(numbers[currLeftInd], numbers[currRightInd])))
                {
                    mergingNumbers[i] = numbers[currLeftInd];
                    currLeftInd++;
                }
                else
                {
                    mergingNumbers[i] = numbers[currRightInd];
                    currRightInd++;
                }
            }
        }

        #endregion


        /// <summary>
        /// Performs a heapsort for provided array of integers.
        /// </summary>
        /// <param name="numbers">Array of integers to be sorted.</param>
        /// <returns>Array of integers in the specified (ascending or descending) order.</returns>
        public int[] Heap(int[] numbers)
        {
            if (numbers.Length <= 0)
                throw new ArgumentNullException("numbers", "'numbers' does not contain any integers.");

            // Build heap in array so that the largest value is at the root
            Heapify(numbers);

            int endInd = numbers.Length - 1;

            while (endInd > 0)
            {
                Swap<int>(numbers, 0, endInd);   // Place current largest value in sorted section

                endInd--;                           // Set new end point for unsorted heap section
                SiftDown(numbers, 0, endInd);       // Flush out largest value in unsorted heap section
            }

            return numbers;
        }

        #region Heap sort helper methods

        private void Heapify(int[] numbers)
        {
            // Start index is parent of last element in 'numbers' array (i.e. reverse 2n + 1);
            int startInd = (int)Math.Floor((numbers.Length - 2.0) / 2.0);

            while (startInd >= 0)
            {
                // Sift down node at index 'startInd' to proper place such that
                // all nodes below are in heap order
                SiftDown(numbers, startInd, numbers.Length - 1);

                startInd--;
            }
        }

        private void SiftDown(int[] numbers, int startInd, int endInd)
        {
            Func<int, int, bool> conditionBySortOrder = (numChild, numSwap) =>
                (SortOrder == SortOrder.Asc && numChild > numSwap)
                    || (SortOrder == SortOrder.Desc && numChild < numSwap);

            int rootInd = startInd;

            // While at least one child node exists for current root node
            while (rootInd * 2 + 1 <= endInd)
            {
                int childInd = rootInd * 2 + 1;
                int swapInd = rootInd;     // keep track of child to swap with

                // If left child is greater (asc.), assign its index as current swap index
                if (conditionBySortOrder(numbers[childInd], numbers[swapInd]))
                    swapInd = childInd;

                // If right child exists and it's greater (asc.), assign its index as swap index
                if (childInd + 1 <= endInd && conditionBySortOrder(numbers[childInd + 1], numbers[swapInd]))
                    swapInd = childInd + 1;

                // No order sifting occured
                if (swapInd == rootInd)
                    return;
                else
                {
                    Swap<int>(numbers, swapInd, rootInd);
                    rootInd = swapInd;     // Update rootInd index
                }
            }
        }

        #endregion


        /// <summary>
        /// Performs a .NET Framework sort (i.e. Array.Sort()) for provided array of integers.
        /// </summary>
        /// <param name="numbers">Array of integers to be sorted.</param>
        /// <returns>Array of integers in the specified (ascending or descending) order.</returns>
        public int[] DotNet(int[] numbers)
        {
            if (numbers.Length <= 0)
                throw new ArgumentNullException("numbers", "'numbers' does not contain any integers.");

            Array.Sort(numbers, 
                SortOrder == SortOrder.Desc ? new IntArrayDescendingComparer() : null);
            return numbers;
        }


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
                        Swap<int>(numbers, j - 1, j);
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
                        Swap<int>(numbers, i - 1, i);

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
                        Swap<int>(numbers, i - 1, i);
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


        #region General helper methods

        private void Swap<T>(T[] arr, int t1Ind, int t2Ind)
        {
            T temp = arr[t1Ind];
            arr[t1Ind] = arr[t2Ind];
            arr[t2Ind] = temp;
        }

        #endregion
    }
}
