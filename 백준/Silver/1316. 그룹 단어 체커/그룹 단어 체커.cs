using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main()
        {

            int n = int.Parse(Console.ReadLine());
            string[] ss = new string[n];
            for (int i = 0; i < n; i++)
                ss[i] = Console.ReadLine();
            int result = n;

            foreach (string s in ss)
            {
                List<string> exists = new List<string>();
                string last = "";
                for (int i = 0; i < s.Length; i++)
                {
                    string alphabet = s[i].ToString();
                    if (alphabet != last)
                    {
                        if (exists.Contains(alphabet))
                        {
                            result--;
                            break;
                        }
                        else
                        {
                            exists.Add(alphabet);
                            last = alphabet;
                        }
                    }
                }
            }
            Console.WriteLine(result);
        }
    }
}
