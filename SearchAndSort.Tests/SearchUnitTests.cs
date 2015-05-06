using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SearchAndSort.Tests
{
    [TestClass]
    public class SearchUnitTests
    {
        private Search searchAlgos;

        public SearchUnitTests()
        {
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestInitialize]
        public void Init()
        {
            searchAlgos = new Search();
        }

        [TestMethod]
        public void LinearSearch_Success_CorrectIndex()
        {
            // ARRANGE
            int[] testNums = { 56, 9, 7, 90, 4, 13, 3, 37, 45 };
            int desiredNum = 37;

            // ACT
            int? result = searchAlgos.Linear(testNums, desiredNum);

            // ASSERT
            Assert.IsTrue(result.HasValue);
            Assert.IsTrue(result.Value == 7);
        }

        [TestMethod]
        public void LinearSearch_Fail_NotFound()
        {
            // ARRANGE
            int[] testNums = { 56, 9, 7, 90, 4, 13, 3, 37, 45 };
            int desiredNum = 100;

            // ACT
            int? result = searchAlgos.Linear(testNums, desiredNum);

            // ASSERT
            Assert.IsFalse(result.HasValue);
        }


        [TestMethod]
        public void BinarySearch_Success_Last()
        {
            // ARRANGE
            int[] testNumsOrdered = { 3, 4, 7, 9, 13, 37, 45, 56, 90 };
            int desiredNum = 90;

            // ACT
            int? result = searchAlgos.Binary(testNumsOrdered, desiredNum);

            // ASSERT
            Assert.IsTrue(result == 8);
        }

        [TestMethod]
        public void BinarySearch_Success_First()
        {
            // ARRANGE
            int[] testNumsOrdered = { 3, 4, 7, 9, 13, 37, 45, 56, 90 };
            int desiredNum = 3;

            // ACT
            int? result = searchAlgos.Binary(testNumsOrdered, desiredNum);

            // ASSERT
            Assert.IsTrue(result == 0);
        }

        [TestMethod]
        public void BinarySearch_Success_Middle()
        {
            // ARRANGE
            int[] testNumsOrdered = { 3, 4, 7, 9, 13, 37, 45, 56, 90 };
            int desiredNum = 13;

            // ACT
            int? result = searchAlgos.Binary(testNumsOrdered, desiredNum);

            // ASSERT
            Assert.IsTrue(result == 4);
        }

        [TestMethod]
        public void BinarySearch_Success_FirstHalf()
        {
            // ARRANGE
            int[] testNumsOrdered = { 3, 4, 7, 9, 13, 37, 45, 56, 90 };
            int desiredNum = 7;

            // ACT
            int? result = searchAlgos.Binary(testNumsOrdered, desiredNum);

            // ASSERT
            Assert.IsTrue(result == 2);
        }

        [TestMethod]
        public void BinarySearch_Success_SecondHalf()
        {
            // ARRANGE
            int[] testNumsOrdered = { 3, 4, 7, 9, 13, 37, 45, 56, 90 };
            int desiredNum = 56;

            // ACT
            int? result = searchAlgos.Binary(testNumsOrdered, desiredNum);

            // ASSERT
            Assert.IsTrue(result == 7);
        }

        [TestMethod]
        public void BinarySearch_Success_EvenLengthArray_FirstHalf()
        {
            // ARRANGE
            int[] testNumsOrdered = { 3, 4, 7, 9, 13, 45, 56, 90 };
            int desiredNum = 9;

            // ACT
            int? result = searchAlgos.Binary(testNumsOrdered, desiredNum);

            // ASSERT
            Assert.IsTrue(result == 3);
        }

        [TestMethod]
        public void BinarySearch_Success_EvenLengthArray_SecondHalf()
        {
            // ARRANGE
            int[] testNumsOrdered = { 3, 4, 7, 9, 13, 45, 56, 90 };
            int desiredNum = 90;

            // ACT
            int? result = searchAlgos.Binary(testNumsOrdered, desiredNum);

            // ASSERT
            Assert.IsTrue(result == 7);
        }

        [TestMethod]
        public void BinarySearch_Success_DescendingOrderArray_FirstHalf()
        {
            // ARRANGE
            int[] testNumsOrderedDesc = { 90, 56, 45, 37, 13, 9, 7, 4, 3 };
            int desiredNum = 37;

            // ACT
            int? result = searchAlgos.Binary(testNumsOrderedDesc, desiredNum);

            // ASSERT
            Assert.IsTrue(result == 3);
        }

        [TestMethod]
        public void BinarySearch_Success_DescendingOrderArray_SecondHalf()
        {
            // ARRANGE
            int[] testNumsOrderedDesc = { 90, 56, 45, 37, 13, 9, 7, 4, 3 };
            int desiredNum = 4;

            // ACT
            int? result = searchAlgos.Binary(testNumsOrderedDesc, desiredNum);

            // ASSERT
            Assert.IsTrue(result == 7);
        }

        [TestMethod]
        public void BinarySearch_Fail_NotFound()
        {
            // ARRANGE
            int[] testNumsOrdered = { 3, 4, 7, 9, 13, 45, 56, 90 };
            int desiredNum = 1;

            // ACT
            int? result = searchAlgos.Binary(testNumsOrdered, desiredNum);

            // ASSERT
            Assert.IsNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(SearchAndSort.Exceptions.NotInOrderException))]
        public void BinarySearch_Fail_UnsortedArray1()
        {
            // ARRANGE
            int[] testNums = { 1, 56, 9, 7, 90, 4, 13, 3, 37, 45 };
            int desiredNum = 37;

            // ACT
            int? result = searchAlgos.Binary(testNums, desiredNum);

            // ASSERT
            // ExpectedException attribute
        }

        [TestMethod]
        [ExpectedException(typeof(SearchAndSort.Exceptions.NotInOrderException))]
        public void BinarySearch_Fail_UnsortedArray2()
        {
            // ARRANGE
            int[] testNums = { 3, 4, 7, 9, 13, 45, 56, 90, 89 };
            int desiredNum = 37;

            // ACT
            int? result = searchAlgos.Binary(testNums, desiredNum);

            // ASSERT
            // ExpectedException attribute
        }
    }
}
