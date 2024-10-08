using System;

namespace Cote
{
    internal class Program
    {
        static void Main() 
        {
            string s = Console.ReadLine();
            string[] ss = s.Split(' ');
            Console.WriteLine(int.Parse(ss[0]) + int.Parse(ss[1]));
        }        
    }
}
