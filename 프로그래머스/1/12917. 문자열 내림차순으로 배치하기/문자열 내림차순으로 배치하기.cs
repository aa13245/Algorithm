using System;
using System.Collections.Generic;
using System.Linq;
public class Solution {
    public string solution(string s) {
        char[] chars = s.ToCharArray();
        List<char> list = new List<char>(chars);
        list.Sort();
        string answer = "";
        foreach (char c in list) answer = c + answer;
        return answer;
    }
}