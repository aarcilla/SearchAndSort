using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAndSort
{
    public class InputHelpers
    {
        /// <summary>
        /// Processes a string of integers separated by whitespaces
        /// to be stored in an array.
        /// </summary>
        /// <param name="numsString">String of space-delimited integers.</param>
        /// <returns>Array of integers as found within the provided string.</returns>
        public int[] ParseSpaceDelimitedIntegers(string numsString)
        {
            List<int> nums = new List<int>();

            var addToNumsList = new Action<string>((numAsString) =>
            {
                int num;
                bool tryParseNum = Int32.TryParse(numAsString, out num);

                if (tryParseNum)
                    nums.Add(num);
            });

            string currentNumAsString = string.Empty;
            int currentIndex = 0;
            while (currentIndex < numsString.Length)
            {
                if (numsString.Substring(currentIndex, 1) == " ")
                {
                    addToNumsList(currentNumAsString);

                    currentNumAsString = string.Empty;
                }
                else
                {
                    currentNumAsString += numsString.Substring(currentIndex, 1);
                }

                currentIndex++;
            }

            // Add last number in space-delimited string
            if (!string.IsNullOrWhiteSpace(currentNumAsString))
            {
                addToNumsList(currentNumAsString);
            }

            return nums.ToArray();
        }
    }
}
