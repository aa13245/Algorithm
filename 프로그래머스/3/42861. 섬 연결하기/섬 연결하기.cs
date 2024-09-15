using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int solution(int n, int[,] costs) {
        // 크루스칼 알고리즘
        // 간선 정보 정렬
        List<int[]> edgeList = new List<int[]>();
        for (int i = 0; i < costs.GetLength(0); i++)
        {
            edgeList.Add(new int[] { costs[i, 0], costs[i, 1], costs[i, 2] });
        }
        edgeList = edgeList.OrderBy(edge => edge[edge.Length - 1]).ToList();
        // 부모 저장
        int[] parent = new int[costs.GetLength(0) + 1];
        for (int i = 1; i < parent.Length; i++) parent[i] = i;

        // 연결
        int sum = 0;
        foreach (int[] edge in edgeList)
        {   // 부모가 동일하지 않다면, 즉 사이클이 발생하지 않을 때
            if (!IsSameParent(parent, edge[0], edge[1]))
            {   
                sum += edge[2];
                UnionParent(parent, edge[0], edge[1]);
            }
        }

        int answer = sum;
        return answer;
    }
    public int GetParent(int[] parent, int x)
    {
        if (parent[x] == x) return x;
        else return parent[x] = GetParent(parent, parent[x]);
    }
    public void UnionParent(int[] parent, int a, int b)
    {
        a = GetParent(parent, a);
        b = GetParent(parent, b);
        if (a > b) parent[a] = b;
        else parent[b] = a;
    }
    public bool IsSameParent(int[] parent, int a, int b)
    {
        a = GetParent(parent, a);
        b = GetParent(parent, b);
        if (a == b) return true;
        else return false;
    }
}