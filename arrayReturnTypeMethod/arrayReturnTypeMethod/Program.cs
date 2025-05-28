using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arrayReturnTypeMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int target = 30;
            int[] coins = new int[] { 5, 5, 50, 25, 25, 10, 5 };
            int[,] results = TwoCoins(coins, target);

            if (results.Length == 0)
            {
                Console.WriteLine("No two coins make change");
            }
            else
            {
                Console.WriteLine("Change found at positions:");
                for (int i = 0; i < results.GetLength(0); i++)
                {
                    if (results[i, 0] == -1)
                    {
                        break;
                    }
                    Console.WriteLine($"{results[i, 0]},{results[i, 1]}");
                }
            }

            int[,] TwoCoins(int[] coinss, int targets)
            {
                int[,] result ={ { -1, -1 }, { -1, -1 }, { -1, -1 }, { -1, -1 }, { -1, -1 } };
                int count = 0;

                for (int curr = 0; curr < coinss.Length; curr++)
                {
                    for (int next = curr + 1; next < coinss.Length; next++)
                    {
                        if (coinss[curr] + coinss[next] == targets)
                        {
                            result[count, 0] = curr;
                            result[count, 1] = next;
                            count++;
                        }
                        if (count == result.GetLength(0))
                        {
                            return result;
                        }
                    }
                }
                return (count == 0) ? new int[0, 0] : result;
            }
            Console.ReadLine();
        }
    }
}
