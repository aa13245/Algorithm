using System;
using System.Collections.Generic;

public class Solution {
    public string[] solution(string[] players, string[] callings) {
        Dictionary<string, int> lank = new Dictionary<string, int>();
        for (int i = 0; i < players.Length; i++) {
            lank[players[i]] = i;
        }
        for (int i = 0; i < callings.Length; i++) {
            int index = lank[callings[i]];
            Swap(players, index, index - 1, lank);
        }
        
        string[] answer = players;
        return answer;
    }
    // 스왑 매서드
    void Swap(string[] players, int index1, int index2, Dictionary<string, int> lank) {
        string temp = players[index1];
        players[index1] = players[index2];
        players[index2] = temp;
        lank[players[index1]] ++;
        lank[players[index2]] --;
    }
}