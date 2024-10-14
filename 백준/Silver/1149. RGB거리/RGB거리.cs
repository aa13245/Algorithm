using System;
using System.Linq;

namespace Cote1
{
    internal class Program
    {
        static void Main()
        {
            // 집의 수
            int n = int.Parse(Console.ReadLine());
            // 비용
            (int, int, int)[] cost = new (int, int, int)[n + 1];
            for (int i = 1; i <= n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                cost[i].Item1 = input[0];
                cost[i].Item2 = input[1];
                cost[i].Item3 = input[2];
            }
            // 최소 비용 합 저장
            int[,] mins = new int[n + 1, 3];
            for (int i = 1; i <= n; i++)
            {
                mins[i, 0] = cost[i].Item1 + Math.Min(mins[i - 1, 1], mins[i - 1, 2]);
                mins[i, 1] = cost[i].Item2 + Math.Min(mins[i - 1, 0], mins[i - 1, 2]);
                mins[i, 2] = cost[i].Item3 + Math.Min(mins[i - 1, 0], mins[i - 1, 1]);
            }
            Console.WriteLine(Math.Min(Math.Min(mins[n, 0], mins[n, 1]), mins[n, 2]));
        }
    }
}
