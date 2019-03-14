using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace task2
{
    public class Mark
    {
        public int point;
        public Mark() { }
        public Mark(int point)
        {
            this.point = point;
        }
        public string GetLetter(int point)
        {
            string f = "Retake";
            if (point <= 50)
                f = "F";
            if (point > 50 && point < 55)
                f = "D-";
            if (point >= 55 && point < 60)
                f = "D";
            if (point >= 60 && point < 65)
                f = "C-";
            if (point >= 65 && point < 70)
                f = "C";
            if (point >= 70 && point < 75)
                f = "C+";
            if (point >= 75 && point < 80)
                f = "B-";
            if (point >= 80 && point < 85)
                f = "B";
            if (point >= 85 && point < 90)
                f = "B+";
            if (point >= 90 && point < 95)
                f = "A-";
            if (point >= 95 && point <= 100)
                f = "A+";
            if (point > 100)
                f = "Sorry.You are very clever and we don't have mark for you";

            return f;
        }
        public override string ToString()
        {
            return this.point+"="+GetLetter(point);
        }
    }

    class Program
    {
        private static void F1(List<Mark>marks)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Mark>));
            FileStream fs = new FileStream("Mark.xml", FileMode.Create, FileAccess.Write);
            xs.Serialize(fs, marks);
            fs.Close();

        }
        private static void F2()
        {
            FileStream fs = new FileStream("Mark.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(List<Mark>));
            List<Mark> marks = xs.Deserialize(fs) as List<Mark>;
            fs.Close();
        }
        static void Main(string[] args)
        {
            Mark m1 = new Mark(55);
            Mark m2 = new Mark(101);
            Mark m3 = new Mark(88);
            List<Mark> marks = new List<Mark>();
            marks.Add(m1);
            marks.Add(m2);
            marks.Add(m3);
            F1(marks);
            F2();
            foreach(Mark m in marks)
            {
                Console.WriteLine(m);
            }
            Console.ReadKey();

        }
    }
}
