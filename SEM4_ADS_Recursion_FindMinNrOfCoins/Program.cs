using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEM4_ADS_Recursion_FindMinNrOfCoins
{
    class Program
    {
        // m is size of coins array  
        // (number of different coins) 
        static int minCoins(int[] coins, int coinArraySize, int totalValue)
        {
            // base case 
            if (totalValue == 0) return 0;

            // Initialize result 
            int res = int.MaxValue;

            // Try every coin that has 
            // smaller value than V 
            for (int i = 0; i < coinArraySize; i++)
            {
                if (coins[i] <= totalValue)
                {
                    int sub_res = minCoins(coins, coinArraySize,
                                      totalValue - coins[i]);

                    // Check for INT_MAX to  
                    // avoid overflow and see  
                    // if result can minimized 
                    if (sub_res != int.MaxValue &&
                                sub_res + 1 < res)
                        res = sub_res + 1;
                }
            }
            return res;
        }

        // Driver Code 
        public static void Main()
        {
            int[] coins = { 1,7,10,22 };
            int m = coins.Length;
            int V = 47;
            Console.Write("Minimum coins required is " +
                                 minCoins(coins, m, V));
            Console.ReadLine();
        }
    }
}