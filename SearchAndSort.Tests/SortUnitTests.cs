using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SearchAndSort.Tests
{
    [TestClass]
    public class SortUnitTests
    {
        private int[] testNumsUnordered = { 56, 9, 7, 90, 4, 13, 3, 37, 45 };
        private int[] testNumsOrderedAsc = { 3, 4, 7, 9, 13, 37, 45, 56, 90 };
        private int[] testNumsOrderedDesc = { 90, 56, 45, 37, 13, 9, 7, 4, 3 };

        #region Selection sort unit tests

        [TestMethod]
        public void SelectionSort_Success_Ascending()
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
    }
}
