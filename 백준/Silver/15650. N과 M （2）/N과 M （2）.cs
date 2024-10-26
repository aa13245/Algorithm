using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

namespace Cote
{
    internal class Program
    {
        static int n, m;
        static List<int> sequence = new List<int>();
        static bool[] visited;
        static void Main() 
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            n = input[0];
            m = input[1];

            visited = new bool[n + 1];

            BackTrack(0);
        }
        static void BackTrack(int depth)
        {
            if (depth == m)
            {
                Console.WriteLine(string.Join(" ", sequence));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                if (!visited[i] && (sequence.Count == 0 || sequence[sequence.Count - 1] < i))
                {
                    visited[i] = true;
                    sequence.Add(i);

                    BackTrack(depth + 1);

                    visited[i] = false;
                    sequence.RemoveAt(sequence.Count - 1);
                }
            }
        }
    }
}
