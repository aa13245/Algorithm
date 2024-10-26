using System;

namespace Cote
{
    internal class Program
    {
        
        static void Main() 
        {
            string s1 = Console.ReadLine();
            string s2 = Console.ReadLine();

            int[,] dp = new int[s1.Length + 1, s2.Length + 1];

            for (int i = 1; i <= s1.Length; i++)
            {
                for (int j = 1; j <= s2.Length; j++)
                {
                    // 같다면
                    if (s1[i - 1] == s2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    // 다르다면
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }
            Console.WriteLine(dp[s1.Length, s2.Length]);
            if (dp[s1.Length, s2.Length] == 0) return;

            string lcs = "";
            int row = s1.Length;
            int cal = s2.Length;
            while (dp[row, cal] != 0)
            {   // 위쪽과 같다면
                if (dp[row, cal] == dp[row - 1, cal])
                {
                    row--;
                }
                // 왼쪽과 같다면
                else if (dp[row, cal] == dp[row, cal - 1])
                {
                    cal--;
                }
                // 둘다 다르면
                else
                {
                    // 현재 위치 추가하고 왼쪽 위로 이동
                    lcs = s1[row - 1].ToString() + lcs;
                    row--;
                    cal--;
                }
            }
            Console.WriteLine(lcs);
        }
    }
}
