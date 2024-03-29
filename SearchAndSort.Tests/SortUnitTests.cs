﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SearchAndSort.Tests
{
    [TestClass]
    public class SortUnitTests
    {
        private readonly int[] testNumsUnordered = { 56, 9, 7, 90, 4, 13, 3, -37, 45 };
        private readonly int[] testNumsOrderedAsc = { -37, 3, 4, 7, 9, 13, 45, 56, 90 };
        private readonly int[] testNumsOrderedDesc = { 90, 56, 45, 13, 9, 7, 4, 3, -37 };

        #region Selection sort unit tests

        [TestMethod]
        public void SelectionSort_Success()
        {
            // ARRANGE
            Sort sortAlgos = new Sort();

            // ACT
            int[] result = sortAlgos.Selection(testNumsUnordered);

            // ASSERT
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(testNumsOrderedAsc[i], result[i]);
            }
        }

        [TestMethod]
        public void SelectionSort_Success_Descending()
        {
            // ARRANGE
            Sort sortAlgos = new Sort(SortOrder.Desc);

            // ACT
            int[] result = sortAlgos.Selection(testNumsUnordered);

            // ASSERT
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(testNumsOrderedDesc[i], result[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SelectionSort_Fail_EmptyArray()
        {
            // ARRANGE
            Sort sortAlgos = new Sort();
            int[] testNums = { };

            // ACT
            sortAlgos.Selection(testNums);

            // ASSERT
            // ExpectedException attribute
        }

        #endregion

        #region Insertion sort unit tests

        [TestMethod]
        public void InsertionSort_Success()
        {
            // ARRANGE
            Sort sortAlgos = new Sort();

            // ACT
            int[] result = sortAlgos.Insertion(testNumsUnordered);

            // ASSERT
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(testNumsOrderedAsc[i], result[i]);
            }
        }

        [TestMethod]
        public void InsertionSort_Success_Descending()
        {
            // ARRANGE
            Sort sortAlgos = new Sort(SortOrder.Desc);

            // ACT
            int[] result = sortAlgos.Insertion(testNumsUnordered);

            // ASSERT
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(testNumsOrderedDesc[i], result[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InsertionSort_Fail_EmptyArray()
        {
            // ARRANGE
            Sort sortAlgos = new Sort();
            int[] testNums = { };

            // ACT
            sortAlgos.Insertion(testNums);

            // ASSERT
            // ExpectedException attribute
        }

        [TestMethod]
        public void InsertionSortSlow_Success()
        {
            // ARRANGE
            Sort sortAlgos = new Sort();

            // ACT
            int[] result = sortAlgos.InsertionSlow(testNumsUnordered);

            // ASSERT
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(testNumsOrderedAsc[i], result[i]);
            }
        }

        [TestMethod]
        public void InsertionSortSlow_Success_Descending()
        {
            // ARRANGE
            Sort sortAlgos = new Sort(SortOrder.Desc);

            // ACT
            int[] result = sortAlgos.InsertionSlow(testNumsUnordered);

            // ASSERT
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(testNumsOrderedDesc[i], result[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InsertionSortSlow_Fail_EmptyArray()
        {
            // ARRANGE
            Sort sortAlgos = new Sort();
            int[] testNums = { };

            // ACT
            sortAlgos.Insertion(testNums);

            // ASSERT
            // ExpectedException attribute
        }

        #endregion

        #region Bubble sort unit tests

        [TestMethod]
        public void BubbleSortSlowest_Success()
        {
            // ARRANGE
            Sort sortAlgos = new Sort();

            // ACT
            int[] result = sortAlgos.BubbleSlowest(testNumsUnordered);

            // ASSERT
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(testNumsOrderedAsc[i], result[i]);
            }
        }

        [TestMethod]
        public void BubbleSortSlowest_Success_Descending()
        {
            // ARRANGE
            Sort sortAlgos = new Sort(SortOrder.Desc);

            // ACT
            int[] result = sortAlgos.BubbleSlowest(testNumsUnordered);

            // ASSERT
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(testNumsOrderedDesc[i], result[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BubbleSortSlowest_Fail_EmptyArray()
        {
            // ARRANGE
            Sort sortAlgos = new Sort();
            int[] testNums = { };

            // ACT
            sortAlgos.BubbleSlowest(testNums);

            // ASSERT
            // ExpectedException attribute
        }

        [TestMethod]
        public void BubbleSortSlower_Success()
        {
            // ARRANGE
            Sort sortAlgos = new Sort();

            // ACT
            int[] result = sortAlgos.BubbleSlower(testNumsUnordered);

            // ASSERT
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(testNumsOrderedAsc[i], result[i]);
            }
        }

        [TestMethod]
        public void BubbleSortSlower_Success_Descending()
        {
            // ARRANGE
            Sort sortAlgos = new Sort(SortOrder.Desc);

            // ACT
            int[] result = sortAlgos.BubbleSlower(testNumsUnordered);

            // ASSERT
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(testNumsOrderedDesc[i], result[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BubbleSortSlower_Fail_EmptyArray()
        {
            // ARRANGE
            Sort sortAlgos = new Sort();
            int[] testNums = { };

            // ACT
            sortAlgos.BubbleSlower(testNums);

            // ASSERT
            // ExpectedException attribute
        }

        [TestMethod]
        public void BubbleSort_Success()
        {
            // ARRANGE
            Sort sortAlgos = new Sort();

            // ACT
            int[] result = sortAlgos.Bubble(testNumsUnordered);

            // ASSERT
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(testNumsOrderedAsc[i], result[i]);
            }
        }

        [TestMethod]
        public void BubbleSort_Success_Descending()
        {
            // ARRANGE
            Sort sortAlgos = new Sort(SortOrder.Desc);

            // ACT
            int[] result = sortAlgos.Bubble(testNumsUnordered);

            // ASSERT
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(testNumsOrderedDesc[i], result[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BubbleSort_Fail_EmptyArray()
        {
            // ARRANGE
            Sort sortAlgos = new Sort();
            int[] testNums = { };

            // ACT
            sortAlgos.Bubble(testNums);

            // ASSERT
            // ExpectedException attribute
        }

        #endregion

        #region Quick sort unit tests

        [TestMethod]
        public void QuickSort_Success()
        {
            // ARRANGE
            Sort sortAlgos = new Sort();

            // ACT
            int[] result = sortAlgos.Quick(testNumsUnordered);

            // ASSERT
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(testNumsOrderedAsc[i], result[i]);
            }
        }

        [TestMethod]
        public void QuickSort_Success_Descending()
        {
            // ARRANGE
            Sort sortAlgos = new Sort(SortOrder.Desc);

            // ACT
            int[] result = sortAlgos.Quick(testNumsUnordered);

            // ASSERT
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(testNumsOrderedDesc[i], result[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void QuickSort_Fail_EmptyArray()
        {
            // ARRANGE
            Sort sortAlgos = new Sort();
            int[] testNums = { };

            // ACT
            sortAlgos.Quick(testNums);

            // ASSERT
            // ExpectedException attribute
        }

        #endregion

        #region Merge sort unit tests
        [TestMethod]
        public void MergeSort_Success()
        {
            // ARRANGE
            Sort sortAlgos = new Sort();

            // ACT
            int[] result = sortAlgos.Merge(testNumsUnordered);

            // ASSERT
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(testNumsOrderedAsc[i], result[i]);
            }
        }

        [TestMethod]
        public void MergeSort_Success_Descending()
        {
            // ARRANGE
            Sort sortAlgos = new Sort(SortOrder.Desc);

            // ACT
            int[] result = sortAlgos.Merge(testNumsUnordered);

            // ASSERT
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(testNumsOrderedDesc[i], result[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MergeSort_Fail_EmptyArray()
        {
            // ARRANGE
            Sort sortAlgos = new Sort();
            int[] testNums = { };

            // ACT
            sortAlgos.Merge(testNums);

            // ASSERT
            // ExpectedException attribute
        }

        #endregion

        #region Heap sort unit tests

        [TestMethod]
        public void HeapSort_Success()
        {
            // ARRANGE
            Sort sortAlgos = new Sort();

            // ACT
            int[] result = sortAlgos.Heap(testNumsUnordered);

            // ASSERT
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(testNumsOrderedAsc[i], result[i]);
            }
        }

        [TestMethod]
        public void HeapSort_Success_Descending()
        {
            // ARRANGE
            Sort sortAlgos = new Sort(SortOrder.Desc);

            // ACT
            int[] result = sortAlgos.Heap(testNumsUnordered);

            // ASSERT
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(testNumsOrderedDesc[i], result[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void HeapSort_Fail_EmptyArray()
        {
            // ARRANGE
            Sort sortAlgos = new Sort();
            int[] testNums = { };

            // ACT
            sortAlgos.Heap(testNums);

            // ASSERT
            // ExpectedException attribute
        }

        #endregion

        #region .NET sort unit tests

        [TestMethod]
        public void DotNetSort_Success()
        {
            // ARRANGE
            Sort sortAlgos = new Sort();

            // ACT
            int[] result = sortAlgos.DotNet(testNumsUnordered);

            // ASSERT
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(testNumsOrderedAsc[i], result[i]);
            }
        }

        [TestMethod]
        public void DotNetSort_Success_Descending()
        {
            // ARRANGE
            Sort sortAlgos = new Sort(SortOrder.Desc);

            // ACT
            int[] result = sortAlgos.DotNet(testNumsUnordered);

            // ASSERT
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(testNumsOrderedDesc[i], result[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DotNetSort_Fail_EmptyArray()
        {
            // ARRANGE
            Sort sortAlgos = new Sort();
            int[] testNums = { };

            // ACT
            sortAlgos.DotNet(testNums);

            // ASSERT
            // ExpectedException attribute
        }

        #endregion
    }
}
