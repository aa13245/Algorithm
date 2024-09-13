using System;
using System.Text.RegularExpressions;

public class Solution {
    public int solution(string[] friends, string[] gifts) {
        int answer = 0;
        int[,] logs = new int[friends.Length, friends.Length];
        int[] indexs = new int[friends.Length];
        int[] predictions = new int[friends.Length];
        Regex regex = new Regex(" ");
        foreach (string each in gifts) {
            string[] names = regex.Split(each);
            int senderIdx = 0, recipientIdx = 0;
            for (int i = 0; i < friends.Length; i++) {
                if (names[0] == friends[i]) senderIdx = i;
                else if (names[1] == friends[i]) recipientIdx = i;
            }
            logs[senderIdx, recipientIdx]++;
            indexs[senderIdx]++;
            indexs[recipientIdx]--;
        }
        for (int i = 0; i < friends.Length; i++) {
            for (int j = 0; j < i; j++) {
                if (logs[i, j] > logs[j, i]) {
                    predictions[i]++;
                }
                else if (logs[i, j] < logs[j, i]) {
                    predictions[j]++;
                }
                else {
                    if (indexs[i] > indexs[j]) {
                        predictions[i]++;
                    }
                    else if (indexs[i] < indexs[j]) {
                        predictions[j]++;
                    }
                }
            }
        }
        foreach (int each in predictions) {
            if (each > answer) answer = each;
        }
        return answer;
    }
}