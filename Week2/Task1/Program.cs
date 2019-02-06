using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Task1
{
    class Program
    {
        public static void T1()
        {
        
            StreamReader sr = new StreamReader(@"C:\Users\Aser\Documents\input.txt");

            string line = sr.ReadLine();

            sr.Close();

            Console.WriteLine(line);

            F(line);
        }
        public static void F(string line)
        {
            string s = line;
            char[] x = line.ToCharArray();
            Array.Reverse(x);
            if (s == new string(x))// Receives string and returns the string with its letters reversed.
               Console.WriteLine("Yes");
            else
               Console.WriteLine("No");
        }
                
        static void Main(string[] args)
        {
            T1();
            Console.ReadKey();
        }
    }
}
