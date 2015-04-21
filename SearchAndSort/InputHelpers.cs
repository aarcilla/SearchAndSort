using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAndSort
{
    public class InputHelpers
    {
        // Used hash table for efficient O(1) lookup
        private readonly HashSet<char> validDelimiters
            = new HashSet<char> { ' ', ';', ',', '&' };

        /// <summary>
        /// Processes a string of integers separated by valid delimiters
        /// to be stored in an array.
        /// </summary>
        /// <param name="numsString">String of delimited integers.</param>
        /// <returns>Array of integers as found within the provided string.</returns>
        public int[] ParseDelimitedIntegers(string numsString)
        {
            List<int> nums = new List<int>();

            var addToNumsList = new Action<string>((numAsString) =>
            {
                int num;

                // Int32.TryParse() will disallow non-integer strings from 
                // being inserted into the result array
                bool tryParseNum = Int32.TryParse(numAsString, out num);

                if (tryParseNum)
                    nums.Add(num);
            });

            var isDelimiterValid = new Func<char, bool>((delimiter) =>
            {
                if (validDelimiters.Contains(delimiter))
                    return true;

                return false;
            });

            string currNumAsString = string.Empty;
            for (int currIndex = 0; currIndex < numsString.Length; currIndex++)
            {
                char currDigitChar = numsString[currIndex];
                if (isDelimiterValid(currDigitChar))
                {
                    addToNumsList(currNumAsString);

                    currNumAsString = string.Empty;
                }
                else
                {
                    currNumAsString += currDigitChar;
                }
            }

            // Add last/remaining number in space-delimited string
            if (currNumAsString != string.Empty)
            {
                addToNumsList(currNumAsString);
            }

            return nums.ToArray();
        }
    }
}
