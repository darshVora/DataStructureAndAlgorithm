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

        /// <summary>
        /// You are a professional robber planning to rob houses along a street. 
        /// Each house has a certain amount of money stashed, 
        /// the only constraint stopping you from robbing each of them is that adjacent houses 
        /// have security systems connected and it will automatically contact the police 
        /// if two adjacent houses were broken into on the same night.
        /// https://leetcode.com/problems/house-robber/description/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int Rob(int[] nums)
        {
            return Rob(nums, 0, new int?[nums.Length]);
        }

        static int Rob(int[] nums, int index, int?[] robResult)
        {
            if (robResult[index] != null)
            {
                //Return result if already computed
                return robResult[index].Value;
            }

            // base case scenario
            if (index == nums.Length - 1) return nums[index];

            //You can either rob current house + from houses not including next one
            var rob1 = nums[index] + (index + 2 >= nums.Length ? 0 : Rob(nums, index + 2, robResult));
            
            //Or you can rob next house
            var rob2 = (index + 1) >= nums.Length ? 0 : Rob(nums, index + 1, robResult);

            //Take maximum amount
            var maxRobberyOpportunity = Math.Max(rob1, rob2);

            //Store result
            robResult[index] = maxRobberyOpportunity;

            return maxRobberyOpportunity;
        }
    }
}
