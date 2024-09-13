using System;
using System.Collections.Generic;

public class Solution {
    public string solution(string video_len, string pos, string op_start, string op_end, string[] commands) {
        int lenT = ConvertToSec(video_len);
        int posT = ConvertToSec(pos);
        int startT = ConvertToSec(op_start);
        int endT = ConvertToSec(op_end);
        Dictionary<string, Action> funcs = new Dictionary<string, Action>();
        funcs["prev"] = () =>
        {
            posT = Math.Max(0, posT - 10);
        };
        funcs["next"] = () =>
        {
            posT = Math.Min(lenT, posT + 10);
        };
        foreach (string cmd in commands)
        {
            if (startT <= posT && posT <= endT) posT = endT;
            funcs[cmd]();
        }
        if (startT <= posT && posT <= endT) posT = endT;
        string answer = ConvertToString(posT);
        return answer;
    }
    int ConvertToSec(string value)
    {
        int min = Convert.ToInt32(value.Substring(0, 2));
        int sec = Convert.ToInt32(value.Substring(3, 2));
        return min * 60 + sec;
    }
    string ConvertToString(int value)
    {
        int min = value / 60;
        int sec = value % 60;
        return min.ToString("D2") + ":" + sec.ToString("D2");
    }
}