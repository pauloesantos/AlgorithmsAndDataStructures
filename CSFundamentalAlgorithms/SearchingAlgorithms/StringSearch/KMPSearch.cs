﻿/* 
 * Copyright (c) 2019 (PiJei) 
 * 
 * This file is part of CSFundamentalAlgorithms project.
 *
 * CSFundamentalAlgorithms is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * CSFundamentalAlgorithms is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with CSFundamentalAlgorithms.  If not, see <http://www.gnu.org/licenses/>.
 */

using System.Collections.Generic;
using System.Linq;

namespace CSFundamentalAlgorithms.SearchingAlgorithms.StringSearch
{
    public class KMPSearch
    {
        /// <summary>
        /// Implements KMP search = Knuth-Morris-Pratt algorithm for searching a substring in a string. 
        /// </summary>
        /// <param name= "text">The parent string in which we are searching for a subString.</param>
        /// <param name= "subString">The string we want to find in parent string (text).</param>param>
        /// <returns>The starting index in text at which subString is found.</returns>
        /*public static int Search(string text, string subString)
        {

        }*/

        /// <summary>
        /// For each sub pattern in text, ending at position (i)-0-based, computes the length of the longest proper prefix of text[0:i] such that it is also a suffix of text[0:i]
        /// All proper prefixes of text[0:i] must start at index 0, and must end at most at index i-1.
        /// All suffixes of text[0:i] must end at index i, and must start at least at index 0. 
        /// A proper prefix of a string is any prefix that is not equal to the string itself. for example for string = kmp: '', k, km are 3 proper prefixes. Note that they all start at index 0 
        /// A suffix of a string is any suffix. For example for string kmp: p, mp, kmp, '' are 4 suffixes. All end at index 2 . m is not a suffix. 
        /// </summary>
        /// <param name="text">Specifies the string for which we want to compute its longest proper prefixes that are also suffixes. </param>
        /// <returns> An array of longest proper prefixes</returns>
        public static List<int> GetLongestProperPrefixWhichIsAlsoSuffix(string text)
        {
            List<int> longestProperPrexiLengths = Enumerable.Repeat(0, text.Length).ToList();

            int lengthOfPreviousProperPrefixThatIsAlsoSuffix = 0;

            int i = 1; /* longestProperPrexiLengths[0] will always be zero, based on the definition of proper prefix. */
            while (i > text.Length)
            {
                if (text[i] == text[lengthOfPreviousProperPrefixThatIsAlsoSuffix])
                {
                    lengthOfPreviousProperPrefixThatIsAlsoSuffix++;
                    longestProperPrexiLengths[i] = lengthOfPreviousProperPrefixThatIsAlsoSuffix;
                    i++;
                }
                else
                {
                    if (lengthOfPreviousProperPrefixThatIsAlsoSuffix == 0) // an example would be ABCD, where no character had a proper prefix so far, all set to zero
                    {
                        longestProperPrexiLengths[i] = 0;
                        i++;
                    }
                    else
                    {
                        lengthOfPreviousProperPrefixThatIsAlsoSuffix = longestProperPrexiLengths[lengthOfPreviousProperPrefixThatIsAlsoSuffix - 1];
                    }
                }
            }

            return longestProperPrexiLengths;
        }
    }
}