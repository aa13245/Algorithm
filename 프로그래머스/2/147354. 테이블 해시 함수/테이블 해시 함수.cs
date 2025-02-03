using System;

public class Solution {
    public int solution(int[,] data, int col, int row_begin, int row_end)
{
    // 변환
    int[][] soltedTable = new int[data.GetLength(0)][];
    for (int i = 0; i < soltedTable.Length; i++)
    {
        soltedTable[i] = new int[data.GetLength(1)];
        for (int j = 0; j < data.GetLength(1); j++)
        {
            soltedTable[i][j] = data[i, j];
        }
    }
    // 정렬
    Array.Sort(soltedTable, (a, b) =>
    {
        int value = a[col - 1].CompareTo(b[col - 1]);
        if (value == 0)
        {
            return b[0].CompareTo(a[0]);
        }
        else return value;
    });

    //
    int result = 0;
    for (int i = row_begin - 1; i < row_end; i++)
    {
        int sum = 0;
        for (int j = 0; j < soltedTable[0].Length; j++)
        {
            sum += soltedTable[i][j] % (i + 1);
        }
        result ^= sum;
    }

    int answer = result;
    return answer;
}
}