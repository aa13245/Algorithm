using System;

public class Solution
{
    public int solution(int n, int[,] results)
    {
        int answer = 0;
        // 승패 정보 - 0 : 데이터 없음, 1 : 이김, 2 : 짐
        int[,] infos = new int[n + 1, n + 1];
        for (int i = 0; i < results.GetLength(0); i++)
        {
            infos[results[i, 0], results[i, 1]] = 1;
            infos[results[i, 1], results[i, 0]] = 2;
        }

        // 플로이드 와샬
        for (int k = 1; k <= n; k++) // 중간 노드
        {
            for (int i = 1; i <= n; i++) // 시작 노드
            {
                for (int j = 1; j <= n; j++) // 도착 노드
                {   // 은가누를 이긴 정찬성
                    if (infos[i, k] == 1 && infos[k, j] == 1)
                    {
                        infos[i, j] = 1;
                        infos[j, i] = 2;
                    }
                }
            }
        }
        // 순위가 특정된 사람 수 카운팅
        for (int i = 1; i <= n; i++)
        {
            int cnt = 0;
            for (int j = 1; j <= n; j++)
            {
                if (infos[i, j] != 0)
                {
                    cnt++;
                }
            }
            if (cnt == n - 1) answer++;
        }
        return answer;
    }
}