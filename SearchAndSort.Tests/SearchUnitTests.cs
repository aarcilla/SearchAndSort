using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SearchAndSort.Tests
{
    /// <summary>
    /// Summary description for SearchUnitTests
    /// </summary>
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
        public void LinearSearch_CorrectIndex()
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
        public void LinearSearch_NotFound()
        {
            // ARRANGE
            int[] testNums = { 56, 9, 7, 90, 4, 13, 3, 37, 45 };
            int desiredNum = 100;

            // ACT
            int? result = searchAlgos.Linear(testNums, desiredNum);

            // ASSERT
            Assert.IsFalse(result.HasValue);
        }
    }
}
