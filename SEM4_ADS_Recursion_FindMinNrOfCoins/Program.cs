using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEM4_ADS_Recursion_FindMinNrOfCoins
{
    class Program
    {
        //NOTE: The time requirements for this solution is EXPONENTIAL
        // m is size of coins array (number of different coins) 
        static int minCoins(int[] coins, int coinArraySize, int valueOfInterest)
        {
            // base case 
            if (valueOfInterest == 0) return 0;

            // checking if there exists such a coin inside the array that equals the valueOfInterest and returning 1 if yes
            foreach (int nr in coins)
            {
                if (nr == valueOfInterest)
                    return 1;
            }

            // Initialize result 
            int res = int.MaxValue;

            // Try every coin that has smaller value than V 
            for (int i = 0; i < coinArraySize; i++)
            {
                if (coins[i] <= valueOfInterest)
                {
                    //sub Result is the inimum number of coins required to make the value which is equal to (valueOfInterest - coins[i])
                    int sub_res = minCoins(coins, coinArraySize, valueOfInterest - coins[i]);

                    // Check for INT_MAX to avoid overflow and see if result can minimized 
                    // registering the newely found result if it is smaller then the previously found result
                    if (sub_res != int.MaxValue && sub_res + 1 < res)
                        res = sub_res + 1;
                }
            }
            return res;
        }

        // Driver Code 
        public static void Main()
        {
            int[] coins = { 1, 7, 10, 22, 47 };
            int m = coins.Length;
            int V = 47;
            Console.Write("Minimum coins required is " +
                                 minCoins(coins, m, V));
            Console.ReadLine();
        }
    }
}