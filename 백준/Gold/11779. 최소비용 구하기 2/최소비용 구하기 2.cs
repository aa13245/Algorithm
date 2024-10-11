using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main()
    {
        int start, destination, nodeNum, busNum;
        List<int[]>[] edges; // 각 노드의 버스 리스트 {목적지, 비용}
        int[] mins; // 시작노드부터 각 노드까지의 최소 비용
        List<int>[] paths; // 각 노드의 최소 비용 루트

        // 입력 & 초기화
        nodeNum = int.Parse(Console.ReadLine());
        busNum = int.Parse(Console.ReadLine());
        edges = Enumerable.Range(0, nodeNum + 1).Select(i => new List<int[]>()).ToArray();
        mins = Enumerable.Repeat(int.MaxValue, nodeNum + 1).ToArray(); // 초기 최소비용은 전부 무제한
        paths = new List<int>[nodeNum + 1];
        for (int i = 0; i < busNum; i++)
        {
            int[] busInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
            edges[busInfo[0]].Add(new int[] { busInfo[1], busInfo[2] });
            /* 버스가 왕복일 경우 반대편도 추가
            edges[busInfo[1]].Add(new int[] { busInfo[0], busInfo[2] });
            */
        }
        int[] sd = Console.ReadLine().Split().Select(int.Parse).ToArray();
        start = sd[0];
        destination = sd[1];

        // 다익스트라
        // 1번인덱스(비용)을 기준으로 오름차순 정렬하는 우선순위 큐
        SortedSet<int[]> priorityQueue = new SortedSet<int[]>(Comparer<int[]>.Create((x, y) =>
        {
            int compare = x[1].CompareTo(y[1]);
            if (compare == 0) return x[0].CompareTo(y[0]);
            return compare;
        }));
        priorityQueue.Add(new int[] { start, 0 }); // 큐에 시작노드 삽입
        paths[start] = new List<int> { start }; // 시작지점 경로 초기화
        mins[start] = 0; // 시작지점 비용은 0
        // 큐가 빌 때까지 반복
        while (priorityQueue.Count != 0)
        {
            int node = priorityQueue.First()[0]; // 현재 위치
            int intensity = priorityQueue.First()[1]; // 현재 위치로 오는 최소 비용
            priorityQueue.Remove(priorityQueue.First());
            // 큐에 저장된 비용 > mins에 저장된 비용 일 경우 스킵
            if (intensity > mins[node]) continue;
            // 노드의 모든 이웃노드에서 (지금 위치에서 탈 수 있는 모든 버스)
            foreach (int[] bus in edges[node])
            {   // 현재 노드를 경유해서 이웃노드로 가는 비용이
                int newPathValue = intensity + bus[1];
                // 원래 알고있던 이웃노드로 가는 최소 비용보다 싸다면
                if (mins[bus[0]] > newPathValue)
                {   // 그 값으로 업데이트
                    mins[bus[0]] = newPathValue;
                    // 경로 업데이트
                    paths[bus[0]] = new List<int>(paths[node]) { bus[0] };

                    // 그리고 큐에 추가
                    priorityQueue.Add(new int[] { bus[0], newPathValue });
                }
            }
        }
        // 출력
        Console.WriteLine(mins[destination]);
        Console.WriteLine(paths[destination].Count);
        Console.WriteLine(string.Join(" ", paths[destination]));
    }
}