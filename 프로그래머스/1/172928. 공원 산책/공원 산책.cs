using System;

public class Solution {
    public int[] solution(string[] park, string[] routes) {
        // 현재 위치
        int[] pos = new int[2];
        for (int i = 0; i < park.Length; i++) {
            for (int j = 0; j < park[0].Length; j++) {
                if (park[i][j].ToString() == "S") {
                    pos = new int[2] {i, j};
                }
            }
        }
        foreach (string route in routes) {
            string dir = route.Substring(0, 1);
            int value = int.Parse(route.Substring(2));
            bool enable = true;
            int[] nextPos = {pos[0], pos[1]};
            for (int i = 1; i <= value; i++) {
                if (dir == "N") {
                    if (--nextPos[0] < 0 || park[nextPos[0]][nextPos[1]].ToString() == "X") {
                        enable = false; break;
                    }
                }
                else if(dir == "E") {
                    if (++nextPos[1] >= park[0].Length || park[nextPos[0]][nextPos[1]].ToString() == "X") {
                        enable = false; break;
                    }
                }
                else if(dir == "S") {
                    if (++nextPos[0] >= park.Length || park[nextPos[0]][nextPos[1]].ToString() == "X") {
                        enable = false; break;
                    }
                }
                else if(dir == "W") {
                    if (--nextPos[1] < 0 || park[nextPos[0]][nextPos[1]].ToString() == "X") {
                        enable = false; break;
                    }
                }
            }
            if (enable) pos = nextPos;
        }
        int[] answer = pos;
        return answer;
    }
}