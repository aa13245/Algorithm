using System;
using System.Collections.Generic;

public class Solution
{
    public double[] solution(int k, int[,] ranges)
    {
        double[] answer = new double[ranges.GetLength(0)];
        List<int> function = new List<int>();
        function.Add(k);
        while(k != 1)
        {
            if (k % 2 == 0) k /= 2;
            else k = k * 3 + 1;
            function.Add(k);
        }
        int n = function.Count;
        for(int i = 0; i < ranges.GetLength(0); i++)
        {
            if (ranges[i,0] > n - 1 + ranges[i, 1])
            {
                answer[i] = -1;
                continue;
            }
            float value = 0;
            
            int startIndex = ranges[i, 0];
            int endIndex = n - 1 + ranges[i, 1];
            
            for (int j = startIndex; j < endIndex; j++)
            {
                value += (function[j] + function[j + 1]) / 2f;
            }
            answer[i] = value;
        }

        return answer;
    }
}