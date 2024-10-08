using System;
using System.Collections.Generic;
using System.Linq;

namespace Cote
{
    internal class Program
    {
        static int v; // 정점의 개수
        static int e; // 간선의 개수
        static List<int>[] adjacentNodes; // 인접노드 리스트

        static List<int[]> scc = new List<int[]>();
        static int idCnt;
        static int[] nodeIds;
        static bool[] finished; // 처리된 노드인지 저장
        static Stack<int> stack = new Stack<int>();
        // DFS는 총 정점의 개수만큼 실행
        static int DFS(int x)
        {
            nodeIds[x] = ++idCnt; // 자신의 고유 번호를 할당
            stack.Push(x); // 스택에 자기 자신을 삽입
            
            // 부모 : 초기값은 자기 자신
            int parent = nodeIds[x];
            // 모든 인접 노드에서
            foreach (int each in adjacentNodes[x])
            {   
                // 방문하지 않은 인접 노드 : DFS실행 (최상위 부모가 반환), 비교 적용
                if (nodeIds[each] == 0) parent = Math.Min(parent, DFS(each));
                // 방문했던 인접 노드 : 그 노드 부모와 비교 적용
                else if (!finished[each]) parent = Math.Min(parent, nodeIds[each]);
            }
            // 자신이 부모노드인 경우
            if (parent == nodeIds[x])
            {
                List<int> newScc = new List<int>();
                while (true)
                {
                    int top = stack.Pop();
                    newScc.Add(top);
                    finished[top] = true;
                    if (top == x) break;
                }
                newScc.Sort(); // 정점들을 오름차순 정렬
                scc.Add(newScc.ToArray());
            }
            return parent;
        }
        static void Main() 
        {
            // 입력
            int[] inputs = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            v = inputs[0]; // 정점의 개수
            e = inputs[1]; // 간선의 개수
            adjacentNodes = new List<int>[v + 1]; // 인접노드 리스트
            for (int i = 0; i < adjacentNodes.Length; i++) adjacentNodes[i] = new List<int>();
            for (int i = 0; i < e; i++)
            {
                inputs = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                adjacentNodes[inputs[0]].Add(inputs[1]);
            }
            nodeIds = new int[v + 1];
            finished = new bool[v + 1];

            // 실행
            for (int i = 1; i <= v; i++)
            {
                if (nodeIds[i] == 0) DFS(i);
            }
            scc = scc.OrderBy(nodes => nodes[0]).ToList(); // scc리스트를 첫번째 정점 기준 오름차순 정렬

            // 결과 출력
            Console.WriteLine(scc.Count);
            foreach (int[] each in scc)
            {
                foreach (int node in each) Console.Write(node + " ");
                Console.WriteLine(-1);
            }
        }
    }
}
