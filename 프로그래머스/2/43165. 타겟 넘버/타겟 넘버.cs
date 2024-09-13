using System;

public class Solution {
    public int solution(int[] numbers, int target) {
        int answer = 0;
        for (int i = 0; i < 1 << numbers.Length; i++)
        {
            int sum = 0;
            for (int j = 0; j < numbers.Length; j++)
            {
                if ((i & (1 << j)) != 0) { sum += numbers[j]; }
                else { sum -= numbers[j]; }
            }
            if (sum == target) answer++;
        }
        return answer;
    }
}