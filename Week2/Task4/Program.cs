using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string fname = "a";
            string fip1 = @"C:\Users\Aser\Desktop\cake\salt";
            string fip2 = @"C:\Users\Aser\Desktop\cake\salt\bad";
            string soufile = Path.Combine(fip1, fname);
            string desfile = Path.Combine(fip2, fname);
            if (!Directory.Exists(fip2))
            {
                Directory.CreateDirectory(fip2);
            }
            File.Copy(soufile,desfile, true);
            if(Directory.Exists(fip1))
            {
                string[] files = Directory.GetFiles(fip1);
                foreach(string s in files)
                {
                    fname = Path.GetFileName(s);
                    desfile = Path.Combine(fip2, fname);
                    File.Copy(s,desfile,true);
                }
            }
            File.Delete(fip1);
            Console.ReadKey();
        }
    }
}
