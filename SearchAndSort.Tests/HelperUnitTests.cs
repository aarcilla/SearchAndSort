using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SearchAndSort.Tests
{
    [TestClass]
    public class HelperUnitTests
    {
        private InputHelpers inputHelpers;

        [TestInitialize]
        public void Init()
        {
            inputHelpers = new InputHelpers();
        }

        [TestMethod]
        public void ParseSpaceDelimitedIntegers_Success()
        {
            // ARRANGE
            string stringOfNums = "1 2 3 4 5 11 12 13 14 15 111";

            // ACT
            int[] result = inputHelpers.ParseSpaceDelimitedIntegers(stringOfNums);

            // ASSERT
            int[] expected = { 1, 2, 3, 4, 5, 11, 12, 13, 14, 15, 111 };
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestMethod]
        public void ParseSpaceDelimitedIntegers_Success_MultipleConsecutiveWhitespace()
        {
            // ARRANGE
            string stringOfNums = "  1 2  3 4   5 11 12 13 14 15  111  ";
             
            // ACT
            int[] result = inputHelpers.ParseSpaceDelimitedIntegers(stringOfNums);

            // ASSERT
            int[] expected = { 1, 2, 3, 4, 5, 11, 12, 13, 14, 15, 111 };
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestMethod]
        public void ParseSpaceDelimitedIntegers_Success_IgnoreInvalidCharacters()
        {
            // ARRANGE
            string stringOfThings = "1 ! bb 5 11 12 34.7 13 14 @tweet 15 111 19.";

            // ACT
            int[] result = inputHelpers.ParseSpaceDelimitedIntegers(stringOfThings);

            // ASSERT
            int[] expected = { 1, 5, 11, 12, 13, 14, 15, 111 };
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestMethod]
        public void ParseSpaceDelimitedIntegers_Fail_AllWhitespace()
        {
            // ARRANGE
            string whiteSpaceString = "  ";

            // ACT
            int[] result = inputHelpers.ParseSpaceDelimitedIntegers(whiteSpaceString);

            // ASSERT
            Assert.IsTrue(result.Length == 0);
        }
    }
}
