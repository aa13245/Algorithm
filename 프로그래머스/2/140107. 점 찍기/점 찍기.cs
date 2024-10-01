using System;

public class Solution {
    public long solution(int k, int d) {
        long answer = 0;
        for (int i = 0; i <= d; i += k)
        {
            double y = Circle(i, d);
            answer += (long)(y / k) + 1;
        }
        return answer;
    }
    public double Circle(int x, int d)
    {
        return Math.Sqrt(Math.Pow(d, 2) - Math.Pow(x, 2));
    }
}