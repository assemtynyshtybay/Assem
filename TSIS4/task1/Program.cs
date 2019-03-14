using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace task1
{
    public class Complex
    {
        public double real;
        public double imaginary;
        public Complex() { }
        public Complex(double real, double imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }
        public void PrintInfo()
        {
            Console.WriteLine(String.Format("{0}+{1}i", real, imaginary));
        }
    }
    class Program
    {
        private static void F1()
        {
            Complex number = new Complex();
            number.real = 4;
            number.imaginary = 7;
            FileStream fs = new FileStream("complex.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(Complex));

            xs.Serialize(fs, number);
            fs.Close();
        }
        private static void F2()
        {
            FileStream fs = new FileStream("complex.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            Complex number = xs.Deserialize(fs) as Complex;
            number.PrintInfo();
            fs.Close();
        }
        static void Main(string[] args)
        {
            F1();
            F2();
            Console.ReadKey();
        }
    }
}
