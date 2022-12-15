using System;
using System.Collections.Generic;
using System.Linq;

namespace recordsure.interview
{
    public class Questions {
        /// <summary>
        /// Given an enumerable of strings, 
        /// 
        /// attempt to parse each string and 
        /// if it is an integer, 
        /// 
        /// add it to the returned enumerable.
        ///
        /// 
        /// For example:
        /// ExtractNumbers(new List<string> { "123", "hello", "234" });
        ///
        /// ; would return:
        ///
        /// {
        ///   123,
        ///   234
        /// }
        /// </summary>
        /// <param name="strings">An enumerable containing words</param>
        /// <returns> List of numbers. </returns>
        public IEnumerable<int> ExtractNumbers(IEnumerable<string> strings) 
        {
            var numbers = new List<int>();

            foreach (var stringItem in strings)
            {
                var isInteger = int.TryParse(stringItem, out var number);

                if (isInteger)
                    numbers.Add(number);
            }

            return numbers;
        }

        /// <summary>
        /// Given two enumerables of strings, find the longest common word.
        ///
        /// For example:
        ///
        /// LongestCommonWord(
        ///     new List<string> {
        ///         "love",
        ///         "wandering",
        ///         "goofy",
        ///         "sweet",
        ///         "mean",
        ///         "show",
        ///         "fade",
        ///         "scissors",
        ///         "shoes",
        ///         "gainful",
        ///         "wind",
        ///         "warn"
        ///     },
        ///     new List<string> {
        ///         "wacky",
        ///         "fabulous",
        ///         "arm",
        ///         "rabbit",
        ///         "force",
        ///         "wandering",
        ///         "scissors",
        ///         "fair",
        ///         "homely",
        ///         "wiggly",
        ///         "thankful",
        ///         "ear"
        ///     }
        /// );
        ///
        /// ; would return "wandering" as the longest common word.
        /// </summary>
        /// <param name="firstList">First list of words</param>
        /// <param name="secondList">Second list of words</param>
        /// <returns> Longest common word. </returns>
        public string LongestCommonWord(IEnumerable<string> firstList, IEnumerable<string> secondList) 
        {
            var longestCommonWord = firstList.Intersect(secondList)
                                             .OrderByDescending(text => text.Length)
                                             .FirstOrDefault();

            return longestCommonWord;
        }

        /// <summary>
        /// Write a method that converts kilometers to miles, given that there are
        /// 1.6 kilometers per mile.
        ///
        /// For example:
        ///
        /// DistanceInMiles(16.00);
        ///
        /// ; would return 10.00;
        /// </summary>
        /// <param name="km">distance in kilometers</param>
        /// <returns> The distance in miles. </returns>
        public double DistanceInMiles(double km) 
        {
            return km / 1.6;
        }

        /// <summary>
        /// Write a method that converts miles to kilometers, give that there are
        /// 1.6 kilometers per mile.
        ///
        /// For example:
        ///
        /// DistanceInKm(10.00);
        ///
        /// ; would return 16.00;
        /// </summary>
        /// <param name="miles">distance in miles</param>
        /// <returns> The distance in kilometers. </returns>
        public double DistanceInKm(double miles)
        {
            return miles * 1.6;
        }

        /// <summary>
        /// Write a method that returns true if the word is a palindrome, false if
        /// it is not.
        ///
        /// For example:
        ///
        /// IsPalindrome("bolton");
        ///
        /// ; would return false, and:
        ///
        /// IsPalindrome("Anna");
        ///
        /// ; would return true.
        ///
        /// Also complete the related test case for this method.
        /// </summary>
        /// <param name="word">The word to check</param>
        /// <returns></returns>
        public bool IsPalindrome(string word) 
        {
            var wordLowercase = word.ToLower();

            return wordLowercase.SequenceEqual(wordLowercase.Reverse());
        }

        /// <summary>
        /// Write a method that takes an enumerable list of objects and 
        /// shuffles them into a different order.
        ///
        /// For example:
        ///
        /// Shuffle(new List<string>{ "one", "two" });
        ///
        /// ; would return:
        ///
        /// {
        ///   "two",
        ///   "one"
        /// }
        /// </summary>
        /// <param name="objects"></param>
        /// <returns> Shuffled list of objects. </returns>
        public IEnumerable<object> Shuffle(IEnumerable<object> objects) 
        {
            var randomNumberGenerator = new Random();
            var shuffledObjects = new List<object>();
            var shouldContinue = false;

            do
            {
                shuffledObjects = objects.OrderBy(item => randomNumberGenerator.Next())
                                         .ToList();

                var haveSameFirstItems = shuffledObjects.FirstOrDefault().Equals(objects.FirstOrDefault());

                shouldContinue = haveSameFirstItems && (objects.Count() != 1);
            } while (shouldContinue);

            return shuffledObjects;
        }

        /// <summary>
        /// Write a method that sorts an array of integers into ascending
        /// order - do not use any built in sorting mechanisms or frameworks.
        ///
        /// Complete the test for this method.
        /// </summary>
        /// <param name="integers"></param>
        /// <returns> Array of sorted integers in an ascending order. </returns>
        public int[] Sort(int[] integers) 
        {
            var valueHolder = 0;

            for (var i = 0; i <= integers.Length - 1; i++)
            {
                for (var j = i + 1; j < integers.Length; j++)
                {

                    if (integers[i] > integers[j])
                    {
                        valueHolder = integers[i];

                        integers[i] = integers[j];
                        integers[j] = valueHolder;
                    }
                }
            }

            return integers;
        }

        /// <summary>
        /// Each new term in the Fibonacci sequence is generated by adding the
        /// previous two terms. By starting with 1 and 2, the first 10 terms will be:
        ///
        /// 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
        ///
        /// By considering the terms in the Fibonacci sequence whose values do
        /// not exceed four million, find the sum of the even-valued terms.
        /// </summary>
        /// <returns> The sum of even-valued terms in the Fibonacci sequence. </returns>
        public int FibonacciSum() 
        {
            var counter = 2;
            var shouldContinue = true;

            var number = 0;
            var nextNumber = 1;

            var sumOfTerms = 0;
            var sumOfEvenTerms = 0;

            do
            {
                for (var i = 1; i < counter; i++)
                {
                    sumOfTerms = number + nextNumber;

                    if (sumOfTerms % 2 == 0)
                        sumOfEvenTerms += sumOfTerms;

                    number = nextNumber;
                    nextNumber = sumOfTerms;

                    if (nextNumber > 4_000_000)
                    {
                        shouldContinue = false;
                        break;
                    }

                    counter++;
                }
            } while (shouldContinue);

            return sumOfEvenTerms;
        }

        /// <summary>
        /// Generate a list of integers from 1 to 100.
        ///
        /// This method is currently broken, fix it so that the tests pass.
        /// </summary>
        /// <returns> A list of integers from 1 to 100. </returns>
        public IEnumerable<int> GenerateList() 
        {
            return Enumerable.Range(1, 100);
        }
    }
}
