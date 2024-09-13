using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    List<int[]>[] ways; // 간선 정보 {목적지, 시간}
    int[] intensitys;
    
    public int[] solution(int n, int[,] paths, int[] gates, int[] summits) {
        // 초기화
        ways = new List<int[]>[n + 1];
        intensitys = new int[n + 1];
        for (int i = 1; i <= n; i++)
        {
            ways[i] = new List<int[]>();
            intensitys[i] = int.MaxValue;
        }
        for (int i = 0; i < paths.GetLength(0); i++)
        {
            ways[paths[i, 0]].Add(new int[] { paths[i, 1], paths[i, 2] });
            ways[paths[i, 1]].Add(new int[] { paths[i, 0], paths[i, 2] });
        }

        // 다익스트라
        SortedSet<int[]> pq = new SortedSet<int[]>(new Mycompare()); // Priority Queue
        foreach (int gate in gates)
        {
            pq.Add(new int[] { gate, 0 });
            intensitys[gate] = 0;
        }
        while (pq.Count != 0)
        {
            int node = pq.First()[0];
            int w = pq.First()[1];
            pq.Remove(pq.First());
            // 최단 시간이 아닌 경우 스킵
            if (intensitys[node] < w || summits.Contains(node)) continue;
            foreach (int[] way in ways[node])
            {
                int next = way[0];
                // 더 작은지 비교, 교체
                if (Math.Max(way[1], intensitys[node]) < intensitys[next])
                {
                    intensitys[next] = Math.Max(way[1], intensitys[node]);
                    pq.Add(new int[] { next, Math.Max(way[1], intensitys[node]) });
                }
            }
        }
        // 결과
        int[] answer = new int[] { int.MaxValue, int.MaxValue };
        foreach (int summit in summits)
        {
            if (intensitys[summit] <= answer[1])
            {
                if (intensitys[summit] == answer[1])
                {
                    if (summit < answer[0])
                    {
                        answer = new int[] { summit, intensitys[summit] };
                    }
                }
                else answer = new int[] { summit, intensitys[summit] };
            }
        }

        return answer;
    }
    
    public class Mycompare : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            int result = x[1] - y[1];
            if (result == 0)
            {
                return x[0] - y[0];
            }
            else return x[1] - y[1];
        }
    }
}