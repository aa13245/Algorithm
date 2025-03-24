using System;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int count = 0;
            while (input.Length != 0)
            {
                count++;

                // 맨 앞 알파벳 추출
                string s = input[0].ToString();
                input = input.Substring(1);

                // 확인
                if (input.Length == 0) continue;
                if (s == "c")
                {
                    if (input[0].ToString() == "=")
                    {
                        input = input.Substring(1);
                    }
                    else if (input[0].ToString() == "-")
                    {
                        input = input.Substring(1);
                    }
                }
                else if (s == "d")
                {
                    if (input.Length >= 2 && input.Substring(0, 2) == "z=")
                    {
                        input = input.Substring(2);
                    }
                    else if (input[0].ToString() == "-")
                    {
                        input = input.Substring(1);
                    }
                }
                else if (s == "l")
                {
                    if (input[0].ToString() == "j")
                    {
                        input = input.Substring(1);
                    }
                }
                else if (s == "n")
                {
                    if (input[0].ToString() == "j")
                    {
                        input = input.Substring(1);
                    }
                }
                else if (s == "s")
                {
                    if (input[0].ToString() == "=")
                    {
                        input = input.Substring(1);
                    }
                }
                else if (s == "z")
                {
                    if (input[0].ToString() == "=")
                    {
                        input = input.Substring(1);
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
