using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public string solution(string number, int k) {
        // 인덱스 k 이내의 최댓값 탐색
        // 앞에 값 제거, 제거한만큼 k 감소
        // 이전에 탐색했던 값 뒷 값들끼리 위 반복
        // 남은 수가 k보다 많지 않으면 중지
        List<int> numList = number.Select(c => int.Parse(c.ToString())).ToList();
        string answer = "";
        while (k > 0 && numList.Count > k)
        {
            int max = 0, maxIdx = 0;
            for (int i = 0; i < k + 1; i++)
            {
                int num = numList[i];
                if (num > max)
                {
                    max = num;
                    maxIdx = i;
                }
                if (max == 9) break;
            }
            k -= maxIdx;
            answer += numList[maxIdx];
            numList.RemoveRange(0, maxIdx + 1);
        }
        numList.RemoveRange(0, k);
        answer += string.Join("", numList);
        return answer;
    }
}