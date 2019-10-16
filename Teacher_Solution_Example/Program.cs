using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teacher_Solution_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(change(47));
            Console.ReadLine();
        }

        static Dictionary<int, int> minCoinsForValue = new Dictionary<int, int>();

        public static int change(int amount)
        {
            if (amount == 1 || amount == 7 || amount == 10 || amount == 22)
            {
                return 1;
            }
            else
            {
                if (minCoinsForValue.ContainsKey(amount))
                {
                    int temp;
                    minCoinsForValue.TryGetValue(amount, out temp);
                    return temp;
                }

                int ch1 = change(amount - 1) + 1;
                int min = ch1;
                minCoinsForValue.Add(amount, min);

                if (amount - 7 > 0)
                {
                    int ch7;

                    if (minCoinsForValue.ContainsKey(amount))
                    { minCoinsForValue.TryGetValue(amount, out ch7); }
                    else
                    {
                        ch7 = (change(amount - 7) + 1);
                        minCoinsForValue.Add(amount, ch7);
                    }
                    if (ch7 < min)
                        min = ch7;
                }
                if (amount - 10 > 0)
                {
                    int ch10;

                    if (minCoinsForValue.ContainsKey(amount))
                    { minCoinsForValue.TryGetValue(amount, out ch10); }
                    else
                    {
                        ch10 = (change(amount - 10) + 1);
                        minCoinsForValue.Add(amount, ch10);
                    }
                    if (ch10 < min)
                        min = ch10;
                }
                if (amount - 22 > 0)
                {
                    int ch22;

                    if (minCoinsForValue.ContainsKey(amount))
                    { minCoinsForValue.TryGetValue(amount, out ch22); }
                    else
                    {
                        ch22 = (change(amount - 22) + 1);
                        minCoinsForValue.Add(amount, ch22);
                    }
                    if (ch22 < min)
                        min = ch22;
                }
                return min;
            }
        }
    }
}
