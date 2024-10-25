using System;
using System.Collections.Generic;
using System.Linq;

namespace Cote1
{
    internal class Program
    {

        static void Main()
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = input[0]; // 정점의 개수
            int m = input[1]; // 간선의 개수
            int v = input[2]; // 탐색을 시작할 정점의 번호
            List<int>[] edges = new List<int>[n + 1];
            for (int i = 1; i < n + 1; i++) edges[i] = new List<int>();
            for (int i = 1; i <= m; i++)
            {
                input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                edges[input[0]].Add(input[1]);
                edges[input[1]].Add(input[0]);
            }
            for (int i = 1; i < n + 1; i++) edges[i].Sort();
            DFS(n, m, v, edges);
            BFS(n, m, v, edges);
        }
        static void DFS(int n, int m, int v, List<int>[] edges)
        {
            Stack<int> stack = new Stack<int>();
            bool[] isSearched = new bool[n + 1];
            stack.Push(v);
            while (stack.Count != 0)
            {
                int top = stack.Pop();
                if (!isSearched[top])
                {
                    isSearched[top] = true;
                    Console.Write(top + " ");
                    for (int i = edges[top].Count - 1; i >= 0; i--)
                    {
                        stack.Push(edges[top][i]);
                    }
                }
            }
            Console.WriteLine();
        }
        static void BFS(int n, int m, int v, List<int>[] edges)
        {
            Queue<int> queue = new Queue<int>();
            bool[] isSearched = new bool[n + 1];
            queue.Enqueue(v);
            while (queue.Count != 0)
            {
                int top = queue.Dequeue();
                if (!isSearched[top])
                {
                    isSearched[top] = true;
                    Console.Write(top + " ");
                    for (int i = 0; i < edges[top].Count; i++)
                    {
                        queue.Enqueue(edges[top][i]);
                    }
                }
            }
        }
    }
}
