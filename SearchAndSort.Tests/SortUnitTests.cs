using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SearchAndSort.Tests
{
    [TestClass]
    public class SortUnitTests
    {
        private int[] testNumsUnordered = { 56, 9, 7, 90, 4, 13, 3, 37, 45 };

        [TestMethod]
        public void SelectionSort_AscendingSuccess()
        {
            // ARRANGE
            Sort sortAlgos = new Sort();

            // ACT
            int[] result = sortAlgos.Selection(testNumsUnordered);

            // ASSERT
            int[] testNumsOrdered = { 3, 4, 7, 9, 13, 37, 45, 56, 90 };
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(testNumsOrdered[i], result[i]);
            }
        }

        [TestMethod]
        public void SelectionSort_DescendingSuccess()
        {
            // ARRANGE
            Sort sortAlgos = new Sort(SortOrder.Desc);

            // ACT
            int[] result = sortAlgos.Selection(testNumsUnordered);

            // ASSERT
            int[] testNumsOrdered = { 90, 56, 45, 37, 13, 9, 7, 4, 3 };
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(testNumsOrdered[i], result[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SelectionSort_EmptyArrayFail()
        {
            // ARRANGE
            Sort sortAlgos = new Sort();
            int[] testNums = { };

            // ACT
            sortAlgos.Selection(testNums);

            // ASSERT
            // ExpectedException attribute
        }
    }
}
