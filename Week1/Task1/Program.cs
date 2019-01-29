using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = Console.ReadLine();//input a number in first liner
            string s2 = Console.ReadLine();//input an array
            int n = int.Parse(s1);//change the string type of first liner to integer type
            string[] s = s2.Split();//separate a string by array of string
            int count=0;//counter of whole prime numbers 
            string t = "";//create a new empty string
            for(int i = 0; i < n; i++)//creat a cycle that run through number of array
            {
               int z = int.Parse(s[i]);//change the string type of array to the integer type
                int cnt = 0;//creat new counter and refresh the mean to 0 for each new i
                for (int j = 2; j <= Math.Sqrt(z); j++)//creat a cycle that run from 2 to mean sqrt of integers in array
                {
                    if (z % j == 0)//condition to find whole divisor of z
                       cnt++;     // count whole divisor of z
                }
                if (cnt == 0&&z!=1)//condition to find prime 
                {
                    count++;//count prime
                    t += s[i] + " ";//enter primes in new string t
                }

            }
            Console.WriteLine(count);//input count of primes
            Console.WriteLine(t);//input prime numbers
        }
    }
}
