using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Task2
{
    class Program
    {  
        public static bool isprime(int x)
        {
            if (x <= 1)
            {
                return false;
            }
            for(int i = 2; i <=Math.Sqrt(x); i++)
            {
                if (x % i == 0)
                    return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            StreamReader s = new StreamReader(@"C:\Users\Aser\Documents\input.txt");
            string sr = s.ReadToEnd();
            string[] a = sr.Split();


            StreamWriter op = new StreamWriter(@"C:\Users\Aser\Documents\output.txt");

            for(int i = 0; i < a.Count(); i++)
            {
                int b = int.Parse(a[i]);
                if (isprime(b) == true)
                    op.Write(b + " ");
            }
            op.Close();
            Console.ReadKey();
        }
    }
}
