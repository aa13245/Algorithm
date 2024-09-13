using System;

public class Solution {
    public int[] solution(string[] wallpaper) {
        int lux = wallpaper[0].Length;
        int luy = wallpaper.Length;
        int rdx = 0, rdy = 0;
        for (int i = 0; i < wallpaper[0].Length; i++) // 가로
        {
            for (int j = 0; j < wallpaper.Length; j++) // 세로
            {
                bool isFile = false;
                if (wallpaper[j].Substring(i, 1) == "#") isFile = true;
                if (isFile)
                {
                    if (i < lux) lux = i;
                    if (j < luy) luy = j;
                    if (i + 1 > rdx) rdx = i + 1;
                    if (j + 1 > rdy) rdy = j + 1;
                }
            }
        }
        int[] answer = new int[] {luy, lux, rdy, rdx};
        return answer;
    }
}