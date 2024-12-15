using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataStructureAndAlgorithm.Algorithm.DynamicProgramming.Patterns
{
    public class FibonacciPatterns
    {
        /// <summary>
        /// https://leetcode.com/problems/climbing-stairs/description/
        /// You are climbing a staircase. It takes n steps to reach the top.
        /// Each time you can either climb 1 or 2 steps.In how many distinct ways can you climb to the top?
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int ClimbStairs(int n)
        {
            var stairsArray = new int[n + 1];
            stairsArray[1] = 1;

            if (n > 1)
            {
                stairsArray[2] = 1;
            }

            for (int i = 1; i < n; i++)
            {
                stairsArray[i + 1] += stairsArray[i] + stairsArray[i - 1];
            }

            return stairsArray[n];
        }
    }
}
