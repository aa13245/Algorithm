using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int[] solution(string[] id_list, string[] report, int k) {
        Dictionary<string, List<int>> reported = id_list.ToDictionary(s => s, v => new List<int>());
        Dictionary<string, int> userId = new Dictionary<string, int>();
        for (int i = 0; i < id_list.Length; i++) userId[id_list[i]] = i;
        int[] answer = new int[id_list.Length];
        for (int i = 0; i < report.Length; i++) {
            string[] log = report[i].Split(' ');
            if (!reported[log[1]].Contains(userId[log[0]])) reported[log[1]].Add(userId[log[0]]);
        }
        for (int i = 0; i < id_list.Length; i++) {   // 신고 k회 이상 시
            if (reported[id_list[i]].Count >= k) {
                foreach(int reporter in reported[id_list[i]]) {
                    answer[reporter]++;
                }
            }
        }
        return answer;
    }
}