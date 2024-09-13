using System;

public class Solution {
    public long solution(int w, int h) {
        long answer = (long)w * h;
        // 함수
        Func<double, double> y = (x) => { return (double)h * x / w; };
        // y값 캐시
        double value = 0f;
        for (int i = 1; i <= w; i++)
        {
            double newValue = y(i);

            answer -= (long)Math.Ceiling(newValue) - (long)value;

            value = newValue;
        }

        return answer;
    }
}