using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithm.Algorithm.DynamicProgramming
{
    public class RecursiveMemorization
    {
        /// <summary>
        /// Gets Nth fibonacci element
        /// </summary>
        /// <param name="index">index</param>
        /// <param name="fibResults">Dictionary to store result</param>
        /// <returns>Fibonacci element at Nth index</returns>
        public static long GetNthFibonacci(int index, Dictionary<int, long> fibResults = null)
        {
            if (index <= 1) return index;

            //Initialize it if null
            fibResults ??= new Dictionary<int, long>(index);

            //Return result directly if already calculated
            if (fibResults.TryGetValue(index, out long result))
            {
                return result;
            }

            //Add calculation to dictionary
            fibResults.Add(index, GetNthFibonacci(index - 1, fibResults) + GetNthFibonacci(index - 2, fibResults));

            return fibResults[index];
        }

        /// <summary>
        /// How many ways you can travel on gird with dimension m*n
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns>Ways you can travel on 2D grid</returns>
        public static long GridTraveller(int m, int n, Dictionary<string, long> gridTravellerResult = null)
        {
            if (m == 0 || n == 0) return 0;
            if (m == 1 && n == 1) return 1;

            gridTravellerResult ??= new Dictionary<string, long>(m + n);

            string key = $"{m},{n}";

            //Return result directly if already calculated
            if (gridTravellerResult.TryGetValue(key, out long result))
            {
                return result;
            }

            result = GridTraveller(m, n - 1, gridTravellerResult) + GridTraveller(m - 1, n, gridTravellerResult);

            //Add calculation to dictionary
            gridTravellerResult.Add(key, result);

            return result;
        }

        /// <summary>
        /// Can target sum be achieved using given numbers
        /// Use element of array multiple times
        /// All input numbers are non negative
        /// </summary>
        /// <param name="targetSum">Sum to achieve</param>
        /// <param name="numbers">Numbers array</param>
        /// <returns></returns>
        public static bool CanSum(int targetSum, int[] numbers, Dictionary<int, bool> canSumResult = null)
        {
            if (targetSum == 0)
            {
                return true;
            }

            if (targetSum < 0)
            {
                return false;
            }

            canSumResult ??= [];

            if (canSumResult.TryGetValue(targetSum, out bool result))
            {
                return result;
            }

            foreach (var number in numbers)
            {
                var remainder = targetSum - number;
                result = CanSum(remainder, numbers, canSumResult);
                canSumResult.TryAdd(targetSum, result);
                if (result == true)
                {
                    return true;
                }
            }

            canSumResult.TryAdd(targetSum, false);
            return false;
        }

        /// <summary>
        /// Can target sum be achieved using given numbers
        /// Use element of array multiple times
        /// All input numbers are non negative
        /// </summary>
        /// <param name="targetSum">Sum to achieve</param>
        /// <param name="numbers">Numbers array</param>
        /// <returns>Shortest sequence of elements to achieve target sum</returns>
        public static List<int> BestSum(int targetSum, List<int> numbers, Dictionary<int, List<int>> bestSumResult = null)
        {
            if (targetSum == 0)
            {
                //Return empty list if 0 is reached
                return [];
            }

            if (targetSum < 0)
            {
                return null;
            }

            bestSumResult ??= [];

            if (bestSumResult.TryGetValue(targetSum, out List<int> result))
            {
                // Return deep copy of list
                return result != null ? [.. result] : result;
            }

            List<int> targetSumSequence = null;
            foreach (var number in numbers)
            {
                var remainder = targetSum - number;
                result = BestSum(remainder, numbers, bestSumResult);
                if (result != null)
                {
                    result.Add(number);

                    //Add result to target sequence if it's null or result's count lesser
                    //means we can achieve target sum using less sequence
                    if(targetSumSequence == null || targetSumSequence?.Count > result.Count)
                    {
                        targetSumSequence = result;
                    }
                }
            }

            //Add best sum to result
            bestSumResult.TryAdd(targetSum, targetSumSequence);

            return targetSumSequence;
        }
    } 
}
