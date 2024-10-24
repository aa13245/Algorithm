using System;
using System.Collections.Generic;
using System.Linq;

namespace Cote1
{
    internal class Program
    {
        static int raw, cal;
        static int[][] map;
        static int[,] dp;
        static SortedSet<(int, int, int)> pq;
        static void Main()
        {   
            // 입력
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            raw = input[0];
            cal = input[1];
            map = new int[raw][];
            dp = new int[raw, cal];
            for (int i = 0; i < raw; i++)
            {
                map[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            // dp
            pq = new SortedSet<(int, int, int)>(Comparer<(int, int, int)>.Create((a, b) =>
            {   // 내림차순
                int result = b.Item3.CompareTo(a.Item3);
                if (result == 0)
                {
                    result = a.Item1.CompareTo(b.Item1);
                    if (result == 0)
                    {
                        result = a.Item2.CompareTo(b.Item2);
                    }
                }
                return result;
            }));
            dp[0, 0] = 1;
            pq.Add((0, 0, map[0][0]));
            while (pq.Count != 0)
            {
                var value = pq.First();
                pq.Remove(value);
                DP(value.Item2, value.Item1);
            }
            Console.WriteLine(dp[raw - 1, cal - 1]);
        }
        static void DP(int y, int x)
        {
            // 좌
            if (x > 0 && (map[y][x] > map[y][x - 1]))
            {
                dp[y, x - 1] += dp[y, x];
                pq.Add((x - 1, y, map[y][x - 1]));
            }
            // 우
            if (x < cal - 1 && (map[y][x] > map[y][x + 1]))
            {
                dp[y, x + 1] += dp[y, x];
                pq.Add((x + 1, y, map[y][x + 1]));
            }
            // 상
            if (y > 0 && (map[y][x] > map[y - 1][x]))
            {
                dp[y - 1, x] += dp[y, x];
                pq.Add((x, y - 1, map[y - 1][x]));
            }
            // 하
            if (y < raw - 1 && (map[y][x] > map[y + 1][x]))
            {
                dp[y + 1, x] += dp[y, x];
                pq.Add((x, y + 1, map[y + 1][x]));
            }
        }
    }
}
