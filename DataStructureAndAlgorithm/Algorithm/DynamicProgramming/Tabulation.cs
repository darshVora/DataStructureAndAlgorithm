using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithm.Algorithm.DynamicProgramming
{
    public class Tabulation
    {
        /// <summary>
        /// Gets Nth fibonacci element
        /// </summary>
        /// <param name="index">index</param>
        /// <param name="fibResults">Dictionary to store result</param>
        /// <returns>Fibonacci element at Nth index</returns>
        public static long GetNthFibonacci(int index)
        {
            var array = new long[index + 1];
            array[1] = 1;

            for (int i = 2; i < array.Length; i++)
            {
                array[i] = array[i - 1] + array[i - 2];
            }

            return array[index];
        }

        /// <summary>
        /// How many ways you can travel on gird with dimension m*n (2 Dimension)
        /// You can either go down or right
        /// </summary>
        /// <param name="m">Dimension</param>
        /// <param name="n">Dimension</param>
        /// <returns>Ways you can travel on 2D grid</returns>
        public static long GridTraveller(int m, int n)
        {
            if (m == 0 || n == 0) return 0;
            var grid = new long[m + 1, n + 1];
            grid[1, 1] = 1;

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    //Add current element to down neighbor only if it exists
                    if (i < m)
                    {
                        grid[i + 1, j] += grid[i, j];
                    }

                    //Add current element to right neighbor only if it exists
                    if (j < n)
                    {
                        grid[i, j + 1] += grid[i, j];
                    }
                }
            }

            return grid[m, n];
        }


        /// <summary>
        /// Can target sum be achieved using given numbers
        /// Use element of array multiple times
        /// All input numbers are non negative
        /// </summary>
        /// <param name="targetSum">Sum to achieve</param>
        /// <param name="numbers">Numbers array</param>
        /// <returns></returns>
        public static bool CanSum(int targetSum, int[] numbers)
        {
            var targetSumArray = new bool[targetSum + 1];

            //Can always do 0 without any numbers
            targetSumArray[0] = true;

            for(int i = 0;i < targetSum; i++)
            {
                if (targetSumArray[i])
                {
                    foreach (var number in numbers)
                    {
                        var arrayIndex = i + number;

                        if(arrayIndex <= targetSum)
                        {
                            targetSumArray[arrayIndex] = true;
                        }
                    }
                }
            }

            return targetSumArray[targetSum];
        }
        
        /// <summary>
        /// Can target sum be achieved using given numbers
        /// Use element of array multiple times
        /// All input numbers are non negative
        /// </summary>
        /// <param name="targetSum">Sum to achieve</param>
        /// <param name="numbers">Numbers array</param>
        /// <returns>Shortest sequence of elements to achieve target sum</returns>
        public static List<int> BestSum(int targetSum, List<int> numbers)
        {
            var targetSumSequences = new List<int>[targetSum + 1];

            //You can always reach 0 with empty array
            targetSumSequences[0] = new List<int>();

            for (int i = 0; i < targetSum; i++)
            {
                //target sum sequence should not be null means it's reachable by given numbers
                if (targetSumSequences[i] != null)
                {
                    foreach (var number in numbers)
                    {
                        var arrayIndex = i + number;

                        // Array index should not exceed target sum otherwise it'll be out of bound
                        if (arrayIndex <= targetSum)
                        {
                            //Add result to target sequence if it's null or result's count lesser
                            //means we can achieve target sum using less sequence
                            if (targetSumSequences[arrayIndex] == null || targetSumSequences[arrayIndex].Count > targetSumSequences[i].Count + 1)
                            {
                                //Copy list and add current number
                                targetSumSequences[arrayIndex] = [.. targetSumSequences[i], number];
                            }
                        }
                    }
                }
            }

            return targetSumSequences[targetSum];
        }
    }
}
