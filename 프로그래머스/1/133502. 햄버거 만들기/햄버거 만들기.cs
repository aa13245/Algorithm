using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int[] ingredient) {
        int answer = 0;
        List<int> list = new List<int>();
        for (int i = 0; i < ingredient.Length; i++){
            if (ingredient[i] == 1){
                if (list.Count != 0 && list[list.Count - 1] == 3){
                    list.RemoveAt(list.Count - 1);
                    answer++;
                }
                else {
                    list.Add(1);
                }
            }
            else {
                if (list.Count != 0 && list[list.Count - 1] + 1 == ingredient[i]) {
                    list[list.Count - 1]++;
                }
                else list = new List<int>();
            }
        }
        
        return answer;
    }
}