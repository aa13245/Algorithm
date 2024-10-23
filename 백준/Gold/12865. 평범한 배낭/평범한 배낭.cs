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
            int n = input[0]; // 물품의 수
            int k = input[1]; // 최대 무게

            int[] dp = new int[k + 1]; // 각 무게별 최대 가치를 저장하는 배열

            // 물품 정보 입력 및 동적 계획법 실행
            for (int i = 0; i < n; i++)
            {
                int[] item = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int w = item[0]; // 물건의 무게
                int v = item[1]; // 물건의 가치

                // 무게가 큰 것부터 처리 (뒤쪽부터 업데이트하여 중복 선택 방지)
                for (int j = k; j >= w; j--)
                {
                    dp[j] = Math.Max(dp[j], dp[j - w] + v);
                }
            }

            // 최대 가치 출력
            Console.WriteLine(dp[k]);
        }
    }
}
