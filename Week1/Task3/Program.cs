using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        public static void twice(string s2,int n)
            {
            string[] a = s2.Split();//separate a string by array of string 
            for(int i = 0; i < n; i++)//run through the elements of array
            {
                int b = int.Parse(a[i]);//change type of array's elements to integer
                for(int j = 0; j < 2; j++)//creat a new integer j and run through the elements of array to write elements twice
                {
                    Console.Write(b+" ");//write element twice 
                }
            }
            Console.ReadKey();
            }

        static void Main(string[] args)
        {
            string s1 = Console.ReadLine();//read first liner
            string s2 = Console.ReadLine();//read second liner
            int n = int.Parse(s1);//change  string type to integer type
            /* string[] a = s2.Split();//separate a string by array of string 
            for(int i = 0; i < n; i++)//run through the elements of array
            {
                int b = int.Parse(a[i]);//change type of array's elements to integer
                for(int j = 0; j < 2; j++)//creat a new integer j and run through the elements of array to write elements twice
                {
                    Console.Write(b+" ");//write element twice 
                }
            }*/
            twice(s2,n);
        }
    }
}
