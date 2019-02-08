using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
     class Program
{

      class Student
      {
        private string name;
        private string id;
        private int yearos;
        public Student(string name,string id)
        {
           this.name = name;
            this.id=id;
        }
        public void increase()
        {
            yearos++;
        }
        public int Yearos
            {
            get
            {
                return yearos;
            }
            set
            {
                yearos=value;
            }
            }
        
   
        static void Main(string[] args)
        {    
            Student s=new Student("Assem","18BD23456");
            s.yearos=2018;
            s.increase();
            
            Console.WriteLine(s.yearos);
                Console.ReadKey();
        }
      
    }
 }
}
