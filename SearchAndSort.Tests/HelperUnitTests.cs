using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SearchAndSort.Tests
{
    [TestClass]
    public class HelperUnitTests
    {
        private InputHelpers inputHelpers;
        private int[] expected = { 1, 2, 3, 4, 5, 11, 12, 13, 14, 15, 111 };

        [TestInitialize]
        public void Init()
        {
            inputHelpers = new InputHelpers();
        }

        [TestMethod]
        public void ParseDelimitedIntegers_Success_Whitespace()
        {
            // ARRANGE
            string stringOfNums = "1 2 3 4 5 11 12 13 14 15 111";

            // ACT
            int[] result = inputHelpers.ParseDelimitedIntegers(stringOfNums);

            // ASSERT
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestMethod]
        public void ParseDelimitedIntegers_Success_Commas()
        {
            // ARRANGE
            string stringOfNums = "1, 2 ,3, 4, 5,11, 12,13,14, 15, 111";

            // ACT
            int[] result = inputHelpers.ParseDelimitedIntegers(stringOfNums);

            // ASSERT
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestMethod]
        public void ParseDelimitedIntegers_Success_Semicolons()
        {
            // ARRANGE
            string stringOfNums = "1; 2; 3;4 ;5; 11;12;13; 14 ; 15; 111";

            // ACT
            int[] result = inputHelpers.ParseDelimitedIntegers(stringOfNums);

            // ASSERT
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestMethod]
        public void ParseDelimitedIntegers_Success_Ampersand()
        {
            // ARRANGE
            string stringOfNums = "1 & 2&3 4 5 11& 12 &13 14 15 & 111";

            // ACT
            int[] result = inputHelpers.ParseDelimitedIntegers(stringOfNums);

            // ASSERT
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }
        [TestMethod]
        public void ParseDelimitedIntegers_Success_ValidDelimiters()
        {
            // ARRANGE
            string stringOfNums = "1 2; 3, 4; 5,11, 12;13;14, 15 & 111";

            // ACT
            int[] result = inputHelpers.ParseDelimitedIntegers(stringOfNums);

            // ASSERT
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestMethod]
        public void ParseDelimitedIntegers_Success_MultipleConsecutiveWhitespace()
        {
            // ARRANGE
            string stringOfNums = "  1 2  3 4   5 11 12 13 14 15  111  ";
             
            // ACT
            int[] result = inputHelpers.ParseDelimitedIntegers(stringOfNums);

            // ASSERT
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestMethod]
        public void ParseDelimitedIntegers_Success_IgnoreInvalidCharacters()
        {
            // ARRANGE
            string stringOfThings = "1 ! bb 5 11 12 34.7 13 14 @tweet 15 111 19.";

            // ACT
            int[] result = inputHelpers.ParseDelimitedIntegers(stringOfThings);

            // ASSERT
            int[] expected = { 1, 5, 11, 12, 13, 14, 15, 111 };
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestMethod]
        public void ParseDelimitedIntegers_Fail_AllWhitespace()
        {
            // ARRANGE
            string whiteSpaceString = "  ";

            // ACT
            int[] result = inputHelpers.ParseDelimitedIntegers(whiteSpaceString);

            // ASSERT
            Assert.IsTrue(result.Length == 0);
        }
    }
}
