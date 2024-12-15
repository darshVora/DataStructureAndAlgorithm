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
            if(m == 0 || n == 0) return 0;
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
    }
}
