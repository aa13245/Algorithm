using System;
using System.Linq;

namespace Cote1
{
    internal class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = input[0];
            int k = input[1];

            int[] nums = new int[k + 1];
            for (int i = 0; i < n; i++)
            {
                int coin = int.Parse(Console.ReadLine());
                if (coin > k) continue;
                nums[coin] += 1;
                for (int j = coin + 1; j < k + 1; j++)
                {
                    nums[j] += nums[j - coin];
                }
            }
            Console.WriteLine(nums[k]);
        }
    }
}
