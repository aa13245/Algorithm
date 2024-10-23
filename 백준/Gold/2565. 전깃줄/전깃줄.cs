using System;
using System.Collections.Generic;
using System.Linq;

namespace Cote
{
    internal class Program
    {
        static void Main()
        {
            // 입력
            int lineNum = int.Parse(Console.ReadLine());
            List<(int, int)> lines = new List<(int, int)>();
            for (int i = 0; i < lineNum; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                lines.Add((input[0], input[1]));
            }
            lines.Sort(Comparer<(int, int)>.Create((a, b) =>
            {
                return a.Item1.CompareTo(b.Item1);
            }));
            int[] dp = new int[lineNum];
            for (int i = 0; i < lineNum; i++)
            {
                dp[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (lines[i].Item2 > lines[j].Item2)
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }
            }
            int max = dp.Max();
            Console.WriteLine(lineNum - max);
        }
    }
}
